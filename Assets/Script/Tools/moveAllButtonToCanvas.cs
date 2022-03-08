using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAllButtonToCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("mapTile");
		for(int i = 1;i< gos.Length;i++){
			Debug.Log (gos [i].name);
			gos [i].transform.parent = gos[0].transform.parent ;

		}
	}
	
	 
}
