using UnityEngine;

public class PortalManager : MonoBehaviour {

    private static PortalCamera cameraA;
    private static PortalCamera cameraB;

    private static Material materialA;
    private static Material materialB;

    public static void CreatePortal(Portal portalA, Portal portalB) {
        cameraA.cameraPortal = cameraB.oppositePortal = portalA.transform;
        cameraA.oppositePortal = cameraB.cameraPortal = portalB.transform;
        portalA.renderPlane.material = materialB;
        portalB.renderPlane.material = materialA;
        portalA.colliderPlane.receiver = portalB.colliderPlane.transform;
        portalB.colliderPlane.receiver = portalA.colliderPlane.transform;
    }

    private static void SetCameras() {
        cameraA = GameObject.FindGameObjectWithTag("CameraA").GetComponent<PortalCamera>();
        cameraB = GameObject.FindGameObjectWithTag("CameraB").GetComponent<PortalCamera>();
    }

    private static void SetMaterials(PortalTextureSetup setup) {
        materialA = setup.cameraMatA;
        materialB = setup.cameraMatB;
    }

    private void Start() {
        SetMaterials(transform.GetComponent<PortalTextureSetup>());
        SetCameras();
    }
}
