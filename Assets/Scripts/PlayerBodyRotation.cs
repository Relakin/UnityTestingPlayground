using UnityEngine;

public class PlayerBodyRotation : MonoBehaviour
{
    public Transform bodyTransform;
    public PlayerHeadRotation headRotationScript;

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");

        if (headRotationScript.IsHeadRotationAtClamp())
        {
            bodyTransform.Rotate(Vector3.up, mouseX * headRotationScript.cameraMovement.sensitivity);
        }
    }
}