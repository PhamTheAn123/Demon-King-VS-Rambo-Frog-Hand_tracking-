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

    public float MoveX { get; private set; }
    public bool JumpDown { get; private set; }
    public bool JumpHeld { get; private set; }
    public bool JumpUp { get; private set; }
    public bool HasHand { get; private set; }

    private bool lastFourFingers;

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

        // Two-hands mode: choose movement source based on actual hand x positions
        IReadOnlyList<NormalizedLandmark> moveSource = null;

        if (result.handLandmarks != null && result.handLandmarks.Count >= 2)
        {
            // determine which detected hand is on the left side of the screen
            var h0 = result.handLandmarks[0].landmarks;
            var h1 = result.handLandmarks[1].landmarks;

            // use index fingertip x (landmark 8) as representative
            float x0 = h0 != null && h0.Count > 8 ? h0[8].x : 0.5f;
            float x1 = h1 != null && h1.Count > 8 ? h1[8].x : 0.5f;

            if (x0 <= x1)
            {
                moveSource = h0;
            }
            else
            {
                moveSource = h1;
            }
        }
        else
        {
            // fallback: prefer left-labeled landmarks, then first detected, then right-labeled
            moveSource = leftLandmarks ?? fallbackLandmarks ?? rightLandmarks;
        }

        UpdateMovementFromHand(moveSource);
        UpdateLeftHandGestures(moveSource ?? (leftLandmarks ?? fallbackLandmarks));
    }


    private void ResetFrameInputs()
    {
        JumpDown = false;
        JumpHeld = false;
        JumpUp = false;
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

    // Aim / shoot / reload related helpers removed.

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
