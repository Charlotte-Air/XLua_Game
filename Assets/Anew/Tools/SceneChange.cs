using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour {
	float time_ = 2 ;
	List<Sprite> spritelist = new List<Sprite>();
	float time2_ = 0.3f;
	int index= 0;
	Image uihead ;
	// Use this for initialization
	void Start () {
		// uihead = this.transform.GetChild (0).transform.GetChild(2).GetComponent<Image>();

		// for (int i = 0; i<=10;i++){
		// 	spritelist.Add (ResourceManager.GetSpritePath("ui_smallq_"+i,"mainui2"));
		// }
		// uihead.overrideSprite = spritelist [index];
	}
	public void close1(){
		time_ = 2;
		this.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		// time_ -= Time.deltaTime;
		// if (time_ <= 0) {
		// 	time_ = 2;
		// 	this.gameObject.SetActive (false); 
		// }
		// time2_ -= Time.deltaTime;
		// if (time2_ <= 0) {
		// 	time2_ = 0.3f;
		// 	uihead.overrideSprite = spritelist [++index %10];
		// }
	}
}
