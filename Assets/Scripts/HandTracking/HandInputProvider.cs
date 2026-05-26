using System.Collections.Generic;
using Mediapipe.Tasks.Components.Containers;
using Mediapipe.Tasks.Vision.HandLandmarker;
using Mediapipe.Unity.Sample.HandLandmarkDetection;
using UnityEngine;

public class HandInputProvider : MonoBehaviour
{
    [Header("Source")]
    [SerializeField] private HandLandmarkerRunner runner;

    [Header("Movement")]
    [SerializeField] private float moveDeadzone = 0.15f;
    [SerializeField] private float moveSmoothing = 8f;
    [SerializeField] private float fingerExtendThreshold = 0.03f;

    [Header("Gestures")]
    [SerializeField] private float pinchThreshold = 0.06f;
    [SerializeField] private float openThreshold = 0.18f;
    [SerializeField] private float fistThreshold = 0.10f;
    [SerializeField] private bool useTwoHands = true;
    [SerializeField] private bool enableRightHand = false;

    public float MoveX { get; private set; }
    public bool JumpDown { get; private set; }
    public bool JumpHeld { get; private set; }
    public bool JumpUp { get; private set; }
    public bool ShootDown { get; private set; }
    public bool ReloadDown { get; private set; }
    public Vector2 AimScreenPos { get; private set; }
    public bool HasHand { get; private set; }

    private bool lastPinchLeft;
    private bool lastOpenLeft;
    private bool lastFistLeft;
    private bool lastFourFingers;
    private bool lastPinchRight;
    private bool lastOpenRight;
    private bool lastFistRight;

    private void Update()
    {
        ResetFrameInputs();

        if (runner == null)
        {
            HasHand = false;
            return;
        }

        if (!runner.TryGetLatestResult(out HandLandmarkerResult result) || result.handLandmarks == null || result.handLandmarks.Count == 0)
        {
            HasHand = false;
            return;
        }

        var leftLandmarks = GetHandLandmarks(result, "Left");
        var rightLandmarks = GetHandLandmarks(result, "Right");
        var fallbackLandmarks = GetFirstHandLandmarks(result);

        HasHand = leftLandmarks != null || rightLandmarks != null || fallbackLandmarks != null;

        if (!HasHand)
        {
            return;
        }

        if (!useTwoHands)
        {
            ProcessSingleHand(fallbackLandmarks ?? leftLandmarks ?? rightLandmarks);
            return;
        }

        var moveSource = leftLandmarks ?? fallbackLandmarks;
        var aimSource = rightLandmarks ?? fallbackLandmarks;

        UpdateMovementFromHand(moveSource);
        UpdateLeftHandGestures(leftLandmarks ?? fallbackLandmarks);

        if (enableRightHand)
        {
            UpdateAimFromHand(aimSource);
            UpdateRightHandGestures(rightLandmarks ?? fallbackLandmarks);
        }
        else
        {
            UpdateAimFromMouse();
            ResetRightHandGestures();
        }
    }

    private static float Distance(NormalizedLandmark a, NormalizedLandmark b)
    {
        return Vector2.Distance(new Vector2(a.x, a.y), new Vector2(b.x, b.y));
    }

    private void ResetFrameInputs()
    {
        JumpDown = false;
        JumpHeld = false;
        JumpUp = false;
        ShootDown = false;
        ReloadDown = false;
    }

    private void ProcessSingleHand(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        if (landmarks == null || landmarks.Count < 21)
        {
            HasHand = false;
            return;
        }

        UpdateMovementFromHand(landmarks);
        UpdateLeftHandGestures(landmarks);

        if (enableRightHand)
        {
            UpdateAimFromHand(landmarks);
            UpdateRightHandGestures(landmarks);
        }
        else
        {
            UpdateAimFromMouse();
            ResetRightHandGestures();
        }
    }

    private void UpdateMovementFromHand(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        if (landmarks == null || landmarks.Count < 21)
        {
            MoveX = Mathf.MoveTowards(MoveX, 0f, moveSmoothing * Time.deltaTime);
            return;
        }

        int extendedFingers = CountExtendedFingers(landmarks);
        float targetMoveX = 0f;

        if (extendedFingers == 1)
        {
            targetMoveX = -1f;
        }
        else if (extendedFingers >= 2)
        {
            targetMoveX = 1f;
        }

        if (Mathf.Abs(targetMoveX) < moveDeadzone)
        {
            targetMoveX = 0f;
        }

        MoveX = Mathf.MoveTowards(MoveX, targetMoveX, moveSmoothing * Time.deltaTime);
    }

    private void UpdateAimFromHand(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        if (landmarks == null || landmarks.Count < 21)
        {
            return;
        }

        var indexTip = landmarks[8];
        AimScreenPos = new Vector2(indexTip.x * Screen.width, (1f - indexTip.y) * Screen.height);
    }

    private void UpdateAimFromMouse()
    {
        AimScreenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    private void UpdateLeftHandGestures(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        if (landmarks == null || landmarks.Count < 21)
        {
            lastOpenLeft = false;
            lastFistLeft = false;
            lastFourFingers = false;
            return;
        }

        int extendedFingers = CountExtendedFingers(landmarks);
        bool fourFingers = extendedFingers >= 4;
        JumpDown = fourFingers && !lastFourFingers;
        JumpHeld = fourFingers;
        JumpUp = !fourFingers && lastFourFingers;
        lastFourFingers = fourFingers;
    }

    private void UpdateRightHandGestures(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        if (landmarks == null || landmarks.Count < 21)
        {
            lastPinchRight = false;
            lastFistRight = false;
            return;
        }

        var pinch = IsPinch(landmarks);
        var fist = IsFist(landmarks);

        ShootDown = pinch && !lastPinchRight;
        ReloadDown = fist && !lastFistRight;

        lastPinchRight = pinch;
        lastFistRight = fist;
    }

    private void ResetRightHandGestures()
    {
        ShootDown = false;
        ReloadDown = false;
        lastPinchRight = false;
        lastFistRight = false;
    }

    private bool IsPinch(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        var thumbTip = landmarks[4];
        var indexTip = landmarks[8];
        return Distance(thumbTip, indexTip) < pinchThreshold;
    }

    private bool IsOpen(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        var wrist = landmarks[0];
        var indexTip = landmarks[8];
        var middleTip = landmarks[12];
        var ringTip = landmarks[16];
        var pinkyTip = landmarks[20];
        float avgFingerDistance = (Distance(wrist, indexTip) + Distance(wrist, middleTip) + Distance(wrist, ringTip) + Distance(wrist, pinkyTip)) * 0.25f;
        return avgFingerDistance > openThreshold;
    }

    private bool IsFist(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        var wrist = landmarks[0];
        var indexTip = landmarks[8];
        var middleTip = landmarks[12];
        var ringTip = landmarks[16];
        var pinkyTip = landmarks[20];
        float avgFingerDistance = (Distance(wrist, indexTip) + Distance(wrist, middleTip) + Distance(wrist, ringTip) + Distance(wrist, pinkyTip)) * 0.25f;
        return avgFingerDistance < fistThreshold;
    }

    private int CountExtendedFingers(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        int count = 0;

        if (IsFingerExtended(landmarks[8], landmarks[6]))
        {
            count++;
        }

        if (IsFingerExtended(landmarks[12], landmarks[10]))
        {
            count++;
        }

        if (IsFingerExtended(landmarks[16], landmarks[14]))
        {
            count++;
        }

        if (IsFingerExtended(landmarks[20], landmarks[18]))
        {
            count++;
        }

        return count;
    }

    private bool IsFingerExtended(NormalizedLandmark tip, NormalizedLandmark pip)
    {
        return (pip.y - tip.y) > fingerExtendThreshold;
    }

    private static IReadOnlyList<NormalizedLandmark> GetHandLandmarks(HandLandmarkerResult result, string targetHand)
    {
        if (result.handedness == null || result.handLandmarks == null)
        {
            return null;
        }

        for (int i = 0; i < result.handedness.Count && i < result.handLandmarks.Count; i++)
        {
            var categories = result.handedness[i].categories;
            if (categories == null || categories.Count == 0)
            {
                continue;
            }

            var name = categories[0].categoryName;
            if (!string.IsNullOrEmpty(name) && string.Equals(name, targetHand, System.StringComparison.OrdinalIgnoreCase))
            {
                return result.handLandmarks[i].landmarks;
            }
        }

        return null;
    }

    private static IReadOnlyList<NormalizedLandmark> GetFirstHandLandmarks(HandLandmarkerResult result)
    {
        if (result.handLandmarks == null || result.handLandmarks.Count == 0)
        {
            return null;
        }

        return result.handLandmarks[0].landmarks;
    }
}
