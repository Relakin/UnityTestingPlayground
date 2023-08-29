using UnityEngine;

/// <summary>
/// Controls the rotation of the player's head based on the camera's movement.
/// </summary>
public class PlayerHeadRotationCommentVersion : MonoBehaviour
{
    public Transform headTransform; // The transform of the head object to be rotated

    private CameraMovement cameraMovement; // Reference to the CameraMovement script

    private void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>(); // Get the CameraMovement component from the main camera

        // Set the default rotation for the headTransform
        if (headTransform != null)
        {
            Quaternion defaultHeadRotation = cameraMovement.GetDefaultRotation(); // Get the default head rotation from the CameraMovement script
            headTransform.localRotation = defaultHeadRotation; // Apply the default head rotation
        }
    }

    private void Update()
    {
        cameraMovement.RotateCamera(); // Update the camera rotation based on mouse input
        ApplyHeadRotation(); // Apply the head rotation to the headTransform
    }

    /// <summary>
    /// Applies the camera's rotation to the player's head.
    /// </summary>
    private void ApplyHeadRotation()
    {
        if (headTransform != null) // Check if the headTransform is not null
        {
            // Calculate the head rotation based on camera rotation and apply it to the headTransform
            Quaternion headRotation = Quaternion.Euler(-cameraMovement.cameraRotationX, 0, -cameraMovement.cameraRotationY);
            headTransform.localRotation = headRotation;
        }
        else
        {
            Debug.LogWarning("PlayerHeadRotation: headTransform is null in ApplyHeadRotation"); // Display a warning if the headTransform is null
        }
    }
}

// This script is designed to control the rotation of the player's head based on the camera's movement.
// It relies on the CameraMovement script to handle camera rotation and provides a smooth interaction between camera movement and head rotation.

// Instructions:
// 1. Create a new C# script.
// 2. Name the script whatever you prefer (e.g., PlayerHeadRotation.cs).
// 3. Open the script and replace its content with this code.
// 4. Save the script and attach it to the GameObject that represents the player's head. NOTE: I had to make a new object in the prefab that has the head..
// ..as the child and made sure the new GameObjects rotation was set to 0,0,0 in order to get it to work.
// 5. Drag and drop the script onto the GameObject
// 5. Ensure that the headTransform field in the script's Inspector is linked to the head GameObject.
// 6. Attach the CameraMovement script to your main camera.