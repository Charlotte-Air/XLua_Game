using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MonsterShader : MonoBehaviour {
	float A  = 1;
	// Use this for initialization
	public void dieTX () {

		Texture  tt = GetComponent<Renderer> ().material.mainTexture;
		Material material = new Material(Shader.Find("Particles/Additive"));
		material.color = Color.green;
		material.mainTexture = tt;
		//material.SetVector("_Color",new Vector4(1,1,1,1));
	 
		GetComponent<Renderer>().material = material; 
		this.transform.DOScaleX (1, 1).OnUpdate (delegate {

			//Debug.Log("Time.deltaTime"+Time.deltaTime);
			A -= Time.deltaTime*1.5f;
			material.SetVector("_TintColor",new Vector4(1,1,1,A));
		}).OnComplete(delegate() {
			
			Destroy(this.transform.parent.gameObject);
		});
	}
	
	 
}
