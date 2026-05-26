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

    [Header("Gestures")]
    [SerializeField] private float pinchThreshold = 0.06f;
    [SerializeField] private float openThreshold = 0.18f;
    [SerializeField] private float fistThreshold = 0.10f;

    public float MoveX { get; private set; }
    public bool JumpDown { get; private set; }
    public bool JumpHeld { get; private set; }
    public bool JumpUp { get; private set; }
    public bool ShootDown { get; private set; }
    public bool ReloadDown { get; private set; }
    public Vector2 AimScreenPos { get; private set; }
    public bool HasHand { get; private set; }

    private bool lastPinch;
    private bool lastOpen;
    private bool lastFist;

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

        var landmarks = result.handLandmarks[0].landmarks;
        if (landmarks == null || landmarks.Count < 21)
        {
            HasHand = false;
            return;
        }

        HasHand = true;

        var wrist = landmarks[0];
        var thumbTip = landmarks[4];
        var indexTip = landmarks[8];
        var middleTip = landmarks[12];
        var ringTip = landmarks[16];
        var pinkyTip = landmarks[20];

        float targetMoveX = (wrist.x - 0.5f) * 2f;
        if (Mathf.Abs(targetMoveX) < moveDeadzone)
        {
            targetMoveX = 0f;
        }
        MoveX = Mathf.MoveTowards(MoveX, targetMoveX, moveSmoothing * Time.deltaTime);

        AimScreenPos = new Vector2(indexTip.x * Screen.width, (1f - indexTip.y) * Screen.height);

        float pinchDistance = Distance(thumbTip, indexTip);
        bool pinch = pinchDistance < pinchThreshold;

        float avgFingerDistance = (Distance(wrist, indexTip) + Distance(wrist, middleTip) + Distance(wrist, ringTip) + Distance(wrist, pinkyTip)) * 0.25f;
        bool open = avgFingerDistance > openThreshold;
        bool fist = avgFingerDistance < fistThreshold;

        JumpDown = open && !lastOpen;
        JumpHeld = open;
        JumpUp = !open && lastOpen;

        ShootDown = pinch && !lastPinch;
        ReloadDown = fist && !lastFist;

        lastPinch = pinch;
        lastOpen = open;
        lastFist = fist;
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
}
