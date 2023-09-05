using UnityEngine;

public class PlayerHeadRotation : MonoBehaviour
{
    public Transform headTransform;
    public CameraMovement cameraMovement;
    
    private void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    private void Update()
    {
        cameraMovement.RotateCamera();
        ApplyHeadRotation();
    }

    private void ApplyHeadRotation()
    {
        if (headTransform != null)
        {
            Quaternion headRotation = Quaternion.Euler(0, 0, -cameraMovement.cameraRotationY);
            headTransform.localRotation = headRotation;
        }
        else
        {
            Debug.LogWarning("PlayerHeadRotation: headTransform is null in ApplyHeadRotation");
        }
    }
    
    public bool IsHeadRotationAtClamp()
    {
        return cameraMovement.cameraRotationX == cameraMovement.minXAngle ||
               cameraMovement.cameraRotationX == cameraMovement.maxXAngle;
    }
}
