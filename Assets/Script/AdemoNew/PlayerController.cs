using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour 
{
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            Debug.Log("PlayerController ->OnTriggerEnter");
            LuaBehaviour.TriggerEnter_(other.gameObject.name);
            //LuaBehaviour.rayF(other.gameObject.name);
            //LuaBehaviour.TriggerEnter_(other.gameObject.name);
        }
    }
}
