using System.Collections.Generic;
using Mediapipe.Tasks.Components.Containers;
using Mediapipe.Tasks.Vision.HandLandmarker;
using Mediapipe.Unity.Sample.HandLandmarkDetection;
using Mediapipe.Unity.Sample;
using UnityEngine;

public class HandInputProvider : MonoBehaviour
{
    [Header("Source")]
    [SerializeField] private HandLandmarkerRunner runner;

    [Header("Movement")]
    [SerializeField] private float moveDeadzone = 0.15f;
    [SerializeField] private float moveSmoothing = 8f;
    [SerializeField] private float fingerExtendThreshold = 0.03f;
    [SerializeField] private bool useTwoHands = true;

    public float MoveX { get; private set; }
    public bool JumpDown { get; private set; }
    public bool JumpHeld { get; private set; }
    public bool JumpUp { get; private set; }
    public bool ShootDown { get; private set; }
    public bool ShootHeld { get; private set; }
    public Vector2 AimScreenPos { get; private set; }
    public bool HasHand { get; private set; }

    private bool lastFourFingers;
    private HandLandmarkerResult _cachedResult;

    private void Start()
    {
        // Allocate space for up to 2 hands to prevent GC allocation on CloneTo
        _cachedResult = HandLandmarkerResult.Alloc(2);
    }

    private void Update()
    {
        ResetFrameInputs();

        if (runner == null)
        {
            HasHand = false;
            return;
        }

        if (!runner.TryGetLatestResult(ref _cachedResult) || _cachedResult.handLandmarks == null || _cachedResult.handLandmarks.Count == 0)
        {
            HasHand = false;
            return;
        }

        var imageSource = ImageSourceProvider.ImageSource;
        bool swapHandedness = imageSource != null && imageSource.GetTransformationOptions().flipHorizontally;

        var leftLandmarks = GetHandLandmarks(_cachedResult, "Left", swapHandedness);
        var rightLandmarks = GetHandLandmarks(_cachedResult, "Right", swapHandedness);
        var fallbackLandmarks = GetFirstHandLandmarks(_cachedResult);

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

        // Two-hands mode: left hand moves/jumps, right hand aims and shoots.
        IReadOnlyList<NormalizedLandmark> moveSource = leftLandmarks;
        IReadOnlyList<NormalizedLandmark> aimSource = rightLandmarks;

        UpdateMovementFromHand(moveSource);
        UpdateLeftHandGestures(moveSource);
        UpdateRightHandAim(aimSource);
    }


    private void ResetFrameInputs()
    {
        JumpDown = false;
        JumpHeld = false;
        JumpUp = false;
        ShootDown = false;
        ShootHeld = false;
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
        UpdateRightHandAim(landmarks);
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

    

    private void UpdateLeftHandGestures(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        if (landmarks == null || landmarks.Count < 21)
        {
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

    private void UpdateRightHandAim(IReadOnlyList<NormalizedLandmark> landmarks)
    {
        if (landmarks == null || landmarks.Count < 21)
        {
            return;
        }

        AimScreenPos = ToScreenPoint(landmarks[8]);
        // Shoot when exactly 1 finger is extended (index finger pointing)
        int extendedFingers = CountExtendedFingers(landmarks);
        ShootHeld = extendedFingers == 1;
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

    private static Vector2 ToScreenPoint(NormalizedLandmark landmark)
    {
        return new Vector2(landmark.x * Screen.width, (1f - landmark.y) * Screen.height);
    }

    private static IReadOnlyList<NormalizedLandmark> GetHandLandmarks(HandLandmarkerResult result, string targetHand, bool swapHandedness)
    {
        if (result.handedness == null || result.handLandmarks == null)
        {
            return null;
        }

        if (swapHandedness)
        {
            targetHand = string.Equals(targetHand, "Left", System.StringComparison.OrdinalIgnoreCase) ? "Right" : "Left";
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
