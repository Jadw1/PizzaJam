using UnityEngine;

public class PortalTeleport : MonoBehaviour {

    private Transform player;
    public Transform receiver;

    private bool playerIsOverlapping = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () {
        if (playerIsOverlapping) {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0.0f) {
                float rotationDiff = transform.rotation.eulerAngles.y - receiver.rotation.eulerAngles.y;
                if((rotationDiff >= 175 && rotationDiff <= 185) || (rotationDiff >= -5 && rotationDiff <= 5) || (rotationDiff >= -185 && rotationDiff <= -175)) {
                    rotationDiff += 180;
                }
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0.0f, rotationDiff, 0.0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;
            }
        }
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            playerIsOverlapping = false;
        }
    }
}
