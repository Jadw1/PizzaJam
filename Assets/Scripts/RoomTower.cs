using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTower : MonoBehaviour {
    public GameObject roomStarting;
    public GameObject roomEnding;
    public GameObject[] roomArray;

    public int layers = 8;

    public GameObject[] rooms;

    // create starting room, create layers, create ending room

    private void Start() {
        rooms = new GameObject[layers + 2];

        rooms[0] = Instantiate(roomStarting, transform, false);

        for (int i = 1; i <= layers; i++) {
            rooms[i] = Instantiate(roomArray[(int) Random.Range(0, roomArray.Length)], transform, false);
        }

        rooms[layers + 1] = Instantiate(roomEnding, transform, false);

        for (int i = 0; i < rooms.Length; i++) {
            rooms[i].name = "Room " + i;
            rooms[i].transform.localPosition = new Vector3(0, -5 * i, 0);
        }
    }
}
