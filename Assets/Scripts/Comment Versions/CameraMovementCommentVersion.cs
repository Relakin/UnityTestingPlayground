using UnityEngine;

/// <summary>
/// Controls the camera movement based on mouse input.
/// </summary>
public class CameraMovementCommentVersion : MonoBehaviour
{
    [Header("Mouse Settings")]
    [SerializeField] private float sensitivity = 2.0f; // Sensitivity of camera movement

    [Header("Rotation Limits")]
    [SerializeField] private const float maxYAngle = 40.0f; // Maximum angle camera can rotate upwards
    [SerializeField] private const float minYAngle = -45.0f; // Maximum angle camera can rotate downwards
    [SerializeField] private const float maxXAngle = 65.0f; // Maximum angle camera can rotate to the right
    [SerializeField] private const float minXAngle = -65.0f; // Maximum angle camera can rotate to the left
    
    private const string mouseXInputAxis = "Mouse X"; // Input axis name for horizontal mouse movement
    private const string mouseYInputAxis = "Mouse Y"; // Input axis name for vertical mouse movement

    private Transform _transform; // Reference to the transform component of the GameObject

    public float cameraRotationY { get; private set; } // Current vertical camera rotation
    public float cameraRotationX { get; private set; } // Current horizontal camera rotation

    private void Start()
    {
        _transform = transform; // Store the transform component of the GameObject
        InitializeCursorLock(); // Initialize cursor lock and visibility settings
        InitializeDefaultRotation(); // Initialize default camera rotation angles
    }

    private void Update()
    {
        RotateCamera(); // Handle camera rotation each frame
    }

    /// <summary>
    /// Locks the cursor to the center of the screen and hides it.
    /// </summary>
    private void InitializeCursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Initializes the default camera rotation angles.
    /// </summary>
    private void InitializeDefaultRotation()
    {
        cameraRotationX = 0.0f; // Initialize horizontal rotation angle to zero
        cameraRotationY = 0.0f; // Initialize vertical rotation angle to zero

        ApplyCameraRotation(); // Apply the default rotation immediately
    }

    /// <summary>
    /// Handles camera rotation based on mouse input.
    /// </summary>
    public void RotateCamera()
    {
        float mouseX = Input.GetAxisRaw(mouseXInputAxis); // Get raw horizontal mouse input
        float mouseY = Input.GetAxisRaw(mouseYInputAxis); // Get raw vertical mouse input

        cameraRotationX += mouseX * sensitivity; // Update horizontal rotation based on mouse input
        cameraRotationY -= mouseY * sensitivity; // Update vertical rotation based on mouse input (invert due to camera convention)

        cameraRotationX = Mathf.Clamp(cameraRotationX, minXAngle, maxXAngle); // Clamp horizontal rotation angle
        cameraRotationY = Mathf.Clamp(cameraRotationY, minYAngle, maxYAngle); // Clamp vertical rotation angle

        ApplyCameraRotation(); // Apply the calculated rotation to the camera
    }

    /// <summary>
    /// Applies the calculated camera rotation to the transform.
    /// </summary>
    private void ApplyCameraRotation()
    {
        if (_transform != null) // Check if the transform reference is not null
        {
            _transform.rotation = Quaternion.Euler(cameraRotationY, cameraRotationX, 0); // Apply the calculated rotation angles
        }
        else
        {
            Debug.LogWarning("CameraMovementCommentVersion: Transform reference is null in ApplyCameraRotation"); // Display a warning if the transform is null
        }
    }

    /// <summary>
    /// Returns the default rotation quaternion.
    /// </summary>
    public Quaternion GetDefaultRotation()
    {
        return Quaternion.Euler(0, 0, 0); // Return a quaternion representing no rotation
    }
}

// This script is an extensively modified iteration of the 'BasicCameraMovementOnly.cs' script.
// The modifications are substantial enough that this may as well be an entirely new movement script.
// The process involved significant effort and time investment, leading to a more optimized, readable, and less prone-to-errors codebase.

// The objective was to enhance performance, readability, and code stability, while still maintaining accessibility for other scripts.
// The primary reasoning behind this script's creation was to facilitate the development of another script, 'PlayerHeadRotation.cs,'..
// which enables controlled head movement for the player. Future plans include creating a script that handles body rotation once the..
// head reaches its rotational limits.

// Instructions:
// 1. Create a new C# script.
// 2. Name the script whatever you prefer (e.g., CameraMovement.cs).
// 3. Open the script and replace its content with this code.
// 4. Save the script and attach it to the Main Camera.