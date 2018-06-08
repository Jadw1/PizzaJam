using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform portalA;
    public Transform portalB;
    private Transform playerCamera;

	// Use this for initialization
	void Start () {
        playerCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = playerCamera.position - portalA.position;
        transform.position = portalB.position + offset;
	}
}
