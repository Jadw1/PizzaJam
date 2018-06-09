using UnityEngine;

public class RoomController : MonoBehaviour {
	public Door[] doors;
    public int entryDoor;
    public int exitDoor;

    private void Start() {
        doors = transform.GetComponentsInChildren<Door>();
    }
}
