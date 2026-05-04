using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float moveRange = 3f;

    private void Update()
    {
        float input = GetInput();
        Vector3 pos = transform.position;

        pos.x += input * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -moveRange, moveRange);

        transform.position = pos;
    }

    public float GetInput()
    {
        if (Keyboard.current != null)
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            return -1;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            return 1;
        }

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            float x = Touchscreen.current.primaryTouch.position.ReadValue().x;

            if (x < Screen.width / 2f)
                return -1;
            else
                return 1;
        }

        return 0;
    }
}
