using UnityEngine;

public class RoomController : MonoBehaviour {
	public Door[] doors;
    public int entryDoorIndex;
    public int exitDoorIndex;

    public Door entryDoor {
        get { return doors[entryDoorIndex]; }
    }
    public Door exitDoor {
        get { return doors[exitDoorIndex]; }
    }


    private void Awake() {
        doors = transform.GetComponentsInChildren<Door>();
        if(gameObject.tag != "StartRoom" && gameObject.tag != "EndRoom") {
            entryDoorIndex = Random.Range(0, doors.Length);
            exitDoorIndex = Random.Range(0, doors.Length);
            while(entryDoorIndex == exitDoorIndex) {
                exitDoorIndex = Random.Range(0, doors.Length);
            }
        }
        else {
            entryDoorIndex = exitDoorIndex = 0;
        }
    }

    public void DeactivateDoors() {
        for(int i = 0; i < doors.Length; i++) {
            if (i == entryDoorIndex || i == exitDoorIndex) {
                continue;
            }
            
            doors[i].Deactivate();
        }
    }
}
