using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoNew : MonoBehaviour {

    // Use this for initialization
    public Transform player;
    public Transform mainCam;
    Vector3 offset;
	void Start () {
        offset = mainCam.position  - player.position;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        mainCam.position = player.position + offset;

    }
}
