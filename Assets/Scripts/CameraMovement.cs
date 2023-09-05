using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public float sensitivity = 2.0f;
    [SerializeField] public float maxYAngle = 40.0f;
    [SerializeField] public float minYAngle = -45.0f;
    [SerializeField] public float maxXAngle = 65.0f;
    [SerializeField] public float minXAngle = -65.0f;
    
    private const string mouseXInputAxis = "Mouse X";
    private const string mouseYInputAxis = "Mouse Y";

    private Transform _transform;

    public float cameraRotationY { get; private set; }
    public float cameraRotationX { get; private set; }

    private void Start()
    {
        _transform = transform;
        InitializeCursorLock();
        InitializeDefaultRotation();
    }

    private void Update()
    {
        RotateCamera();
    }

    private void InitializeCursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void InitializeDefaultRotation()
    {
        cameraRotationX = 0.0f;
        cameraRotationY = 0.0f;
        ApplyCameraRotation();
    }

    public void SetCameraRotationX(float value)
    {
        cameraRotationX = value;
    }

    public void RotateCamera()
    {
        float mouseX = Input.GetAxisRaw(mouseXInputAxis);
        float mouseY = Input.GetAxisRaw(mouseYInputAxis);

        cameraRotationX += mouseX * sensitivity;
        cameraRotationY -= mouseY * sensitivity;

        cameraRotationX = Mathf.Clamp(cameraRotationX, minXAngle, maxXAngle);
        cameraRotationY = Mathf.Clamp(cameraRotationY, minYAngle, maxYAngle);

        ApplyCameraRotation();
    }

    private void ApplyCameraRotation()
    {
        if (_transform != null)
        {
            _transform.rotation = Quaternion.Euler(cameraRotationY, cameraRotationX, 0);
        }
        else
        {
            Debug.LogWarning("CameraMovement: Transform reference is null in ApplyCameraRotation");
        }
    }

    public Quaternion GetDefaultRotation()
    {
        return Quaternion.Euler(0, 0, 0);
    }
}