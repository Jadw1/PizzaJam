using UnityEngine;

public class Door : MonoBehaviour {

    public float maxOffset = 2.0f;
    public float speed = 2.0f;
    public float closeTime = 5.0f;
    public Door symmetricDoor;

    private float offset = 0.0f;
    private float timeToClose = 0.0f;
    private bool isOpening = false;
    private Portal portal;

    public void Open() {
        isOpening = true;
        symmetricDoor.SymmetricalOpen();
        PortalManager.CreatePortal(portal, symmetricDoor.portal);
    }

    public void SymmetricalOpen() {
        isOpening = true;
    }

    private void Start() {
        portal = transform.parent.GetComponent<Portal>();
    }

    private void Update() {

        if (isOpening) {
            float deltaOffset = speed * Time.deltaTime;

            if(offset + deltaOffset >= maxOffset) {
                deltaOffset = maxOffset - offset;
                offset = maxOffset;
                isOpening = false;
                timeToClose = closeTime;
            }
            else {
                offset += deltaOffset;
            }
            transform.Translate(Vector3.right * deltaOffset);
        }

        if (!isOpening && offset > 0.0f && timeToClose <= 0.0f) {
            float deltaOffset = speed * Time.deltaTime;

            if(offset - deltaOffset <= 0.0f) {
                deltaOffset = offset;
                offset = 0.0f;
            }
            else {
                offset -= deltaOffset;
            }
            transform.Translate(Vector3.right * deltaOffset * -1);
        }

        timeToClose -= Time.deltaTime;
    }

    public void Deactivate() {
        transform.parent.gameObject.SetActive(false);
    }

	public void Activate() {
		transform.parent.gameObject.SetActive(true);
	}
}
