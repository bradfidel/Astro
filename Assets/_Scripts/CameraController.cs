using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 basePosition;

    [SerializeField]
    private float maxShakePower;
    [SerializeField]
    private float shakePowerModifier;

    [SerializeField]
    private float maxShakeDuration;
    [SerializeField]
    private float shakeDurationModifier;

    //
    private float shakeActiveTime;
    private float shakePower;

    private void Awake()
    {
        basePosition = transform.localPosition;
    }

    private void Update()
    {
        if(shakeActiveTime > Time.time)
        {
            Shake();
        }
        else
        {
            FinishShake();
        }
    }

    public void ShakeAfterImpulse(Vector3 impulse)
    {
        float impulseMagnitude = impulse.magnitude;
        shakePower = Mathf.Min(maxShakePower, impulseMagnitude) * shakePowerModifier;
        float shakeDuration = Mathf.Min(maxShakeDuration, impulseMagnitude) * shakeDurationModifier;
        shakeActiveTime = Time.time + shakeDuration;
        enabled = true;
    }

    bool hue;
    private void Shake()
    {
        hue = !hue;
        if(hue)
        {
            return;
        }

        // TODO shake every Xth frame? OR transition between selected points using Lerp
        transform.localPosition = basePosition + new Vector3(Random.Range(-shakePower, shakePower), Random.Range(-shakePower, shakePower), Random.Range(-shakePower, shakePower));
    }

    private void FinishShake()
    {
        enabled = false;
        transform.localPosition = basePosition;
    }
}
