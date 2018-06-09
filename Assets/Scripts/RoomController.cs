using UnityEngine;

public class RoomController : MonoBehaviour {
	public Door[] doors;
    public int entryDoor;
    public int exitDoor;

    private void Start() {
        doors = transform.GetComponentsInChildren<Door>();
        if(gameObject.tag != "StartRoom" && gameObject.tag != "EndRoom") {
            entryDoor = Random.Range(0, doors.Length);
            exitDoor = Random.Range(0, doors.Length);
            while(entryDoor == exitDoor) {
                exitDoor = Random.Range(0, doors.Length);
            }
        }
        else {
            entryDoor = exitDoor = 0;
        }
    }

    public void DeactivateDoors() {
        Debug.Log("Deactivating");
        for(int i = 0; i < doors.Length; i++) {
            if (i == entryDoor || i == exitDoor) {
                continue;
            }

            doors[i].Deactivate();
        }
    }
}
