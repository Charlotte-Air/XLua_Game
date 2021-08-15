using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour { 
    /********************************************************************
							需要的预制体定义区 
	********************************************************************/
	public GameObject test;


	/********************************************************************
							需要的模块变量定义区 
	********************************************************************/


	void Start(){
		init ();
	}


	// 初始化方法，  预制体的搜索赋值，关闭和打开状态的设置。
	public void init(){

		// 搜索子物体
		test = this.transform.Find("test").gameObject;

	}


	// 功能主按钮被点击的事件  只写自己的模块的打开操作，不要去管其他模块的
	public void mainClick(){



	}




  
}
