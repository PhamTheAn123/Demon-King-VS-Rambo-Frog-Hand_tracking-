using System.Collections;
using UnityEngine;

/// <summary>
/// CameraShake - Rung camera. Gan vao Main Camera.
/// Goi Shake() tu BossController hoac cac su kien khac.
/// </summary>
public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPos;
    private bool    _shaking;

    private void Awake() => _originalPos = transform.localPosition;

    public void Shake(float duration, float intensity)
    {
        if (_shaking) StopAllCoroutines();
        StartCoroutine(DoShake(duration, intensity));
    }

    private IEnumerator DoShake(float dur, float intensity)
    {
        _shaking = true;
        float t = 0f;
        while (t < dur)
        {
            float x = Random.Range(-1f, 1f) * intensity;
            float y = Random.Range(-1f, 1f) * intensity;
            transform.localPosition = _originalPos + new Vector3(x, y, 0f);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _originalPos;
        _shaking = false;
    }
}