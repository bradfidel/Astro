using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private ShipConfig config;

    // TODO shared ship controller -> player and enemy will modify it in different ways

    [SerializeField]
    private new Rigidbody rigidbody = null;

    [SerializeField]
    private InputController inputController = null;

    //private Vector3 currentVelocity = Vector3.zero;
    //private Vector3 currentRotationSpeed = Vector3.zero;

    [SerializeField]
    private bool invertRightX;
    [SerializeField]
    private bool invertRightY;

    private float currentSpeed = 0;

    private void Update()
    {
        DebugUI.instance.DisplayValue("SPD: " + ((int)currentSpeed).ToString());
        DebugUI.instance.DisplayValue("AngularVelo: " + rigidbody.angularVelocity);
    }

    private void FixedUpdate()
    {
        float xAngle = inputController.leftAnalog.y * Time.fixedDeltaTime * config.yMaxRotationSpeed * (invertRightY ? -1 : 1);
        float zAngle = inputController.leftAnalog.x * Time.fixedDeltaTime * config.xMaxRotationSpeed * (invertRightX ? -1 : 1);
        transform.Rotate(xAngle, 0, zAngle, Space.Self);

        float velocityChange = config.velocityAcceleration * (inputController.rightTrigger - inputController.leftTrigger) * Time.fixedDeltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed + velocityChange, 0, config.maxVelocity);

        rigidbody.velocity = transform.forward * currentSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SlowDownUponCollision(collision);
    }

    private void SlowDownUponCollision(Collision collision)
    {
        if (currentSpeed > 0)
        {
            currentSpeed *= currentSpeed / (currentSpeed + collision.impulse.magnitude);
        }
    }
}
