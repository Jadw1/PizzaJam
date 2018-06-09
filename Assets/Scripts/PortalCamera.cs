using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform oppositePortal;
    public Transform cameraPortal;
    private Transform playerCamera;

	// Use this for initialization
	void Start () {
        playerCamera = Camera.main.transform;
	}

    private float ClampAngle(float angle) {
        if (angle >= 360) {
            return angle - 360;
        }
        else if (angle < 0) {
            return angle + 360;
        }
        else
            return angle;
    }
	
	void LateUpdate () {
        float angularDifference = cameraPortal.rotation.eulerAngles.y - oppositePortal.rotation.eulerAngles.y;
        angularDifference = Mathf.Abs(angularDifference);
        Debug.Log(angularDifference);

        if(angularDifference >= -5 && angularDifference <= 5) {
            if(gameObject.name == "Camera_A") {
                angularDifference += 180;
            }
        }
        else if (angularDifference >= 85 && angularDifference <= 95) {
            if (gameObject.name == "Camera_B") {
                angularDifference += 180;
            }
        }
        else if (angularDifference >= 175 && angularDifference <= 185) {
            if (gameObject.name == "Camera_A") {
                angularDifference += 180;
            }
            if (gameObject.name == "Camera_B") {
                angularDifference += 180;
            }
        }
        else if (angularDifference >= 265 && angularDifference <= 275) {
            if (gameObject.name == "Camera_B") {
                angularDifference += 180;
            }
        }


        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);

        Vector3 offset = playerCamera.position - oppositePortal.position;
        transform.position = cameraPortal.position + portalRotationalDifference * offset;

        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}