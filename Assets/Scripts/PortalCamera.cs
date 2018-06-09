using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform oppositePortal;
    public Transform cameraPortal;
    private Transform playerCamera;

	// Use this for initialization
	void Start () {
        playerCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float angularDifference = Quaternion.Angle(cameraPortal.rotation, oppositePortal.rotation);
        angularDifference += 180;
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);

        Vector3 offset = playerCamera.position - oppositePortal.position;
        transform.position = cameraPortal.position + portalRotationalDifference * offset;

        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
