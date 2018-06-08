using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform portalA;
    public Transform portalB;
    private Transform playerCamera;

	// Use this for initialization
	void Start () {
        playerCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = playerCamera.position - portalA.position;
        transform.position = portalB.position + offset;

        float angularDifference = Quaternion.Angle(portalB.rotation, portalA.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
