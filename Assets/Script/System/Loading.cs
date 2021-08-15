using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour 
{

	// Use this for initialization 
	 public	IEnumerator Startloading()
    { 
         while(true)
         {
 			yield return new WaitForSeconds(0.02f); 
          this.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -1) * 8f); 
		 }
    }

	void Update()
    {
		//	this.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -1) * 4f); 
    }

	void OnEnable(){
		Debug.Log("Loading -> OnEnable");
 			StartCoroutine(Startloading());
	}

	void OnDisable(){
		Debug.Log("Loading -> OnDisable");
		 StopAllCoroutines();
	}
}
