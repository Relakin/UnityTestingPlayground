using UnityEngine;

public class BasicCameraMovementOnly : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float maxYAngle = 50.0f;
    public float minYAngle = -60.0f;
    public float maxXAngle = 80.0f;
    public float minXAngle = -80.0f;

    private Vector2 currentRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentRotation = new Vector2(0f, 0f);
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = -Input.GetAxisRaw("Mouse Y");

        currentRotation.x += mouseX * sensitivity;
        currentRotation.y += mouseY * sensitivity;

        currentRotation.x = Mathf.Clamp(currentRotation.x, minXAngle, maxXAngle);
        currentRotation.y = Mathf.Clamp(currentRotation.y, minYAngle, maxYAngle);

        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }
}
