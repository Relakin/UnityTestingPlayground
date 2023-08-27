using UnityEngine;

public class CameraMovementOnly : MonoBehaviour
{
    public float sensitivity = 2.0f;    // Mouse sensitivity
    public float maxYAngle = 50.0f;     // Maximum vertical angle
    public float minYAngle = -60.0f;    // Minimum vertical angle
    public float maxXAngle = 80.0f;     // Maximum horizontal angle
    public float minXAngle = -80.0f;    // Minimum horizontal angle
    
    private Vector2 currentRotation;    // Current rotation angles for the camera

    void Start()
    {
        // Locks and hides the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Sets the initial camera angle
        currentRotation = new Vector2(0f, 0f);
    }

    void Update()
    {
        // Gets raw mouse input
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = -Input.GetAxisRaw("Mouse Y"); // Invert Y-axis for intuitive controls, if you don't do this, the vertical looking will be inverted.

        // Update the rotation angles based on mouse input scaled by sensitivity
        currentRotation.x += mouseX * sensitivity;
        currentRotation.y += mouseY * sensitivity;

        // Clamp the vertical rotation angle to avoid over-rotating
        currentRotation.x = Mathf.Clamp(currentRotation.x, minXAngle, maxXAngle);

        // Clamp the horizontal rotation angle to avoid over-rotating
        currentRotation.y = Mathf.Clamp(currentRotation.y, minYAngle, maxYAngle);

        // Apply the rotations to the camera to control its orientation
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }
}

// To use this script, create a new script. Name it whatever, just be sure to change the class name to whatever you name the file.
// Then, once this code has been pasted into the new script and saved, simply drag and drop the script onto the main camera object.

// This script only allows the camera to rotate with your mouse while adding a limit (clamp) to how far you can look around (rotate).
// It also allows you to set the look sensitivity.
// This script does not rotate the player, nor the head. It's just a simple camera rotation with limitations and sensitivity script.