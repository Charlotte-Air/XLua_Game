using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.localEulerAngles = new Vector3 (0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (1, 0, 0) * Time.deltaTime*25); 
	}
}
