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
        if(oppositePortal == null || cameraPortal == null) {
            return;
        }

        float angularDifference = cameraPortal.rotation.eulerAngles.y - oppositePortal.rotation.eulerAngles.y;
        angularDifference = ClampAngle(angularDifference);
        Debug.Log(gameObject.name + angularDifference);

        if (gameObject.name == "Camera_A") {
            if (angularDifference == 0) {
                angularDifference += 180;
            }
            else if (angularDifference == 90) {
                angularDifference += 180;
            }
            else if (angularDifference == 180) {
                angularDifference += 180;
            }
            else if (angularDifference == 270) {
                angularDifference += 180;
            }
        }
        else if (gameObject.name == "Camera_B") {
            if (angularDifference == 0) {

            }
            else if (angularDifference == 90) {
                angularDifference += 180;
            }
            else if (angularDifference == 180) {
                angularDifference += 180;
            }
            else if (angularDifference == 270) {
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