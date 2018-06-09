using UnityEngine;

public class Interact : MonoBehaviour {

    public float range = 2.0f;

    private Camera camera;

    private void Start() {
        camera = Camera.main;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range)) {
                if(hit.transform.tag == "Door") {
                    Debug.Log("door");
                    hit.transform.GetComponent<Door>().Open();
                }
            }
        }
	}
}
