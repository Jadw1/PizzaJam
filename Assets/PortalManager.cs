using UnityEngine;

public class PortalManager : MonoBehaviour {

    public static PortalCamera cameraA;
    public static PortalCamera cameraB;

    private void Start() {
        /*if(cameraA == null) {
            Debug.LogError("No Camera A assigned!");
        }

        if (cameraB == null) {
            Debug.LogError("No Camera B assigned!");
        }*/
        SetCameras();
    }

    private static void SetCameras() {
        cameraA = GameObject.FindGameObjectWithTag("CameraA").GetComponent<PortalCamera>();
        cameraB = GameObject.FindGameObjectWithTag("CameraB").GetComponent<PortalCamera>();
    }

    public static void CreatePortals(Transform portalA, Transform portalB) {


        cameraA.cameraPortal = cameraB.oppositePortal = portalA;
        cameraA.oppositePortal = cameraB.cameraPortal= portalB;
        
    }
}
