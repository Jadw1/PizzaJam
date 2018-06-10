using UnityEngine;

public class PortalManager : MonoBehaviour {

    private static PortalCamera cameraA;
    private static PortalCamera cameraB;

    private static Material materialA;
    private static Material materialB;

    private static Portal portal1;
    private static Portal portal2;

    public static void CreatePortal(Portal portalA, Portal portalB) {
        if ((portal1 == portalA && portal2 == portalB) || (portal1 == portalB && portal2 == portalA))
            return;

        cameraA.cameraPortal = cameraB.oppositePortal = portalA.transform;
        cameraA.oppositePortal = cameraB.cameraPortal = portalB.transform;
        portalA.renderPlane.material = materialB;
        portalB.renderPlane.material = materialA;
        portalA.colliderPlane.receiver = portalB.colliderPlane.transform;
        portalB.colliderPlane.receiver = portalA.colliderPlane.transform;

        portal1 = portalA;
        portal2 = portalB;
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

    public static void MergeDoors(Door doorA, Door doorB) {
        doorA.symmetricDoor = doorB;
        doorB.symmetricDoor = doorA;
    }

    public static void CloseAllDoors() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Door");
        Door[] doors = new Door[objects.Length];
        for(int i = 0; i < doors.Length; i++) {
            doors[i] = objects[i].GetComponent<Door>();
            //doors[i]
        }
    }
}
