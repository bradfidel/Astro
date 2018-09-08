using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 leftAnalog;
    public Vector2 rightAnalog;
    public float leftTrigger;       // use left + right velocity axis?
    public float rightTrigger;      // 

    private void Update()
    {
        leftAnalog = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rightAnalog = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        leftTrigger = Input.GetAxis("LeftTrigger");
        rightTrigger = Input.GetAxis("RightTrigger");
    }
}
