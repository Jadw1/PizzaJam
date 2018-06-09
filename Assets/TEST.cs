using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

    public Door doorA;
    public Door doorB;

	// Use this for initialization
	void Start () {
        PortalManager.MergeDoors(doorA, doorB);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
