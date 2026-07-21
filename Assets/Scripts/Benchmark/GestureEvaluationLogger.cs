using System;
using System.IO;
using System.Text;
using Mediapipe.Unity.Sample.HandLandmarkDetection;
using UnityEngine;

/// <summary>
/// Logs gesture accuracy trials and response-time samples for the paper.
/// Attach to a GameObject and assign HandInputProvider + HandLandmarkerRunner.
///
/// Manual trial keys (during Play Mode):
///   1 = record G1 move left attempt
///   2 = record G2 move right attempt
///   3 = record G3 jump attempt
///   4 = record G4 aim attempt
///   5 = record G5 shoot attempt
///   L = mark incorrect (observer override)
/// </summary>
public class GestureEvaluationLogger : MonoBehaviour
{
    public enum GestureId
    {
        MoveLeft = 1,
        MoveRight = 2,
        Jump = 3,
        Aim = 4,
        Shoot = 5
    }

    [Header("References")]
    [SerializeField] private HandInputProvider handInput;
    [SerializeField] private HandLandmarkerRunner runner;

    [Header("Settings")]
    [SerializeField] private float responseWindowMs = 500f;
    [SerializeField] private float moveThreshold = 0.5f;
    [SerializeField] private bool logToConsole = true;

    private readonly StringBuilder _csv = new StringBuilder();
    private double _lastInferenceMs = -1;
    private PendingTrial _pending;

    private struct PendingTrial
    {
        public GestureId Gesture;
        public double StartMs;
        public double InferenceMs;
        public double MappingMs;
        public bool Completed;
    }

    private void OnEnable()
    {
        if (runner != null)
        {
            runner.OnResult += OnHandResult;
        }

        _csv.AppendLine("gesture,trial_start_ms,inference_ms,mapping_ms,action_ms,total_ms,success");
    }

    private void OnDisable()
    {
        if (runner != null)
        {
            runner.OnResult -= OnHandResult;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) BeginTrial(GestureId.MoveLeft);
        if (Input.GetKeyDown(KeyCode.Alpha2)) BeginTrial(GestureId.MoveRight);
        if (Input.GetKeyDown(KeyCode.Alpha3)) BeginTrial(GestureId.Jump);
        if (Input.GetKeyDown(KeyCode.Alpha4)) BeginTrial(GestureId.Aim);
        if (Input.GetKeyDown(KeyCode.Alpha5)) BeginTrial(GestureId.Shoot);

        if (_pending.Completed || _pending.Gesture == 0)
        {
            return;
        }

        double nowMs = NowMs();
        if (nowMs - _pending.StartMs > responseWindowMs)
        {
            CompleteTrial(false, nowMs);
            return;
        }

        if (handInput == null)
        {
            return;
        }

        if (_pending.InferenceMs < 0 && _lastInferenceMs >= _pending.StartMs)
        {
            _pending.InferenceMs = _lastInferenceMs;
        }

        if (_pending.MappingMs < 0 && IsGestureMapped(_pending.Gesture))
        {
            _pending.MappingMs = nowMs;
        }

        if (IsGestureAction(_pending.Gesture))
        {
            CompleteTrial(true, nowMs);
        }
    }

    private void BeginTrial(GestureId gesture)
    {
        _pending = new PendingTrial
        {
            Gesture = gesture,
            StartMs = NowMs(),
            InferenceMs = -1,
            MappingMs = -1,
            Completed = false
        };

        if (logToConsole)
        {
            Debug.Log($"[GestureEval] Trial started: {gesture}");
        }
    }

    private void CompleteTrial(bool success, double endMs)
    {
        double inference = _pending.InferenceMs >= 0 ? _pending.InferenceMs - _pending.StartMs : -1;
        double mapping = _pending.MappingMs >= 0 ? _pending.MappingMs - _pending.StartMs : -1;
        double action = success ? endMs - _pending.StartMs : -1;
        double total = success ? endMs - _pending.StartMs : -1;

        _csv.AppendLine(string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "{0},{1:F1},{2:F1},{3:F1},{4:F1},{5:F1},{6}",
            _pending.Gesture,
            _pending.StartMs,
            inference,
            mapping,
            action,
            total,
            success ? 1 : 0));

        if (logToConsole)
        {
            Debug.Log($"[GestureEval] { _pending.Gesture } success={success} total={total:F1} ms");
        }

        _pending.Completed = true;
        _pending.Gesture = 0;
    }

    private void OnHandResult(Mediapipe.Tasks.Vision.HandLandmarker.HandLandmarkerResult result)
    {
        _lastInferenceMs = NowMs();
    }

    private bool IsGestureMapped(GestureId gesture)
    {
        if (!handInput.HasHand && gesture != GestureId.Aim && gesture != GestureId.Shoot)
        {
            return false;
        }

        switch (gesture)
        {
            case GestureId.MoveLeft:
                return handInput.MoveX < -moveThreshold;
            case GestureId.MoveRight:
                return handInput.MoveX > moveThreshold;
            case GestureId.Jump:
                return handInput.JumpDown || handInput.JumpHeld;
            case GestureId.Aim:
                return handInput.HasHand;
            case GestureId.Shoot:
                return handInput.ShootHeld;
            default:
                return false;
        }
    }

    private bool IsGestureAction(GestureId gesture)
    {
        return IsGestureMapped(gesture);
    }

    [ContextMenu("Export Gesture CSV")]
    public void ExportCsv()
    {
        string folder = Path.Combine(Application.persistentDataPath, "GestureEval");
        Directory.CreateDirectory(folder);
        string path = Path.Combine(folder, $"gesture_eval_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
        File.WriteAllText(path, _csv.ToString());
        Debug.Log($"[GestureEval] Saved: {path}");
    }

    private static readonly System.Diagnostics.Stopwatch _stopwatch = System.Diagnostics.Stopwatch.StartNew();

    private static double NowMs()
    {
        return _stopwatch.Elapsed.TotalMilliseconds;
    }
}
