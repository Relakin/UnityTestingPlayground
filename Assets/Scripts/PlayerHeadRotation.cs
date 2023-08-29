using UnityEngine;

public class PlayerHeadRotation : MonoBehaviour
{
    public Transform headTransform;

    private CameraMovement cameraMovement;

    private void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        if (headTransform != null)
        {
            Quaternion defaultHeadRotation = cameraMovement.GetDefaultRotation();
            headTransform.localRotation = defaultHeadRotation;
        }
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
            Quaternion headRotation = Quaternion.Euler(-cameraMovement.cameraRotationX, 0, -cameraMovement.cameraRotationY);
            headTransform.localRotation = headRotation;
        }
        else
        {
            Debug.LogWarning("PlayerHeadRotation: headTransform is null in ApplyHeadRotation");
        }
    }
}