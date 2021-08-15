using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
  public class SystemTool : MonoBehaviour {

	///<summary>
	/// 摄像机对准目标
	/// </summary>
	private GameObject mTarget;
    ///<summary>
	/// 移动速度
	/// </summary>
	public float moveSpeed;
    ///<summary>
	/// 缩放速度
	/// </summary>
	public float scaleSpeed;
    ///<summary>
	/// 摄像机与目标位置偏移
	/// </summary>
	private Vector3 mOffset;
	///<summary>
	/// 单例
    /// </summary>
	public GameObject temp;
   float camSpeed = 30f;
   GameObject  mainCam ; 

	void OnEnable()
    {
        EasyTouch.On_TouchStart += On_Touch1;
        /// 游戏开始注册事件
        //	EasyTouch.On_TouchStart += On_Touch;

        //		EasyTouch.On_Pinch += On_Pinch;

        //EasyTouch.On_Cancel += On_Cancel;

        //   EasyTouch.On_TouchStart += On_Touch1;
        /*
		EasyTouch.On_SwipeEnd +=   On_SwipeEnd;
      
        EasyTouch.On_Swipe += On_Swipe;
        EasyTouch.On_Drag += On_Drag;
        EasyTouch.On_PinchIn += On_PinchIn;
        EasyTouch.On_PinchOut += On_PinchOut;*/
    }
    void OnDisEnable()
    {
        EasyTouch.On_TouchStart -= On_Touch1;
        /// <summary>
        /// 初始化
        /// </summary>
    }
        void Start()
	{
       
        mainCam = GameObject.Find("CameraFather");
		// mTarget = GameController._instance.currentPerson.gameObject;
		//初始化摄像机与目标位置偏移
		// mOffset = transform.position - mTarget.transform.position;
	}

	/// <summary>
	/// 控制摄像机锁定目标玩家
	/// </summary>
	//public void LockTarget()
	//{
	//    mTarget = GameController._instance.currentPerson.gameObject;
	//    //目标不为空则移动摄像机
	//    if (mTarget != null)
	//    {
	//        //计算摄像机当前位置
	//        Vector3 currentPostion = mTarget.transform.position + mOffset;
	//        //移动摄像机
	//        transform.position = currentPostion;
	//    }
	//}

	/// <summary>
	/// 清除注册事件
	/// </summary>
	void OnDestroy()
	{
		EasyTouch.On_PinchIn -= On_PinchIn;
		EasyTouch.On_PinchOut -= On_PinchOut;
//		EasyTouch.On_Pinch -= On_Pinch;
		EasyTouch.On_Swipe -= On_Swipe;
		EasyTouch.On_Drag -= On_Drag;
		EasyTouch.On_SwipeEnd -= On_SwipeEnd;
	}

	/// <summary>
	/// 拖动事件
	/// </summary>
	/// <param name="gesture"></param>
	void On_Touch(Gesture gesture)
	{ 
//		Debug.LogError2 (gesture.pickedUIElement.name);
if (gesture.pickedUIElement==null){
            return ; 
		if (gesture.pickedUIElement.name.Length > 3) {
			if (gesture.pickedUIElement.name.Substring (0, 3) == "map") {
				EasyTouch.SetEnablePinch (true);
			} else {
				EasyTouch.SetEnablePinch (false);
			}
		}
}
	}
	void On_Drag(Gesture gesture)
	{
		if (gesture.pickedUIElement==null){
            return ; 
		if (gesture.pickedUIElement.name.Length > 3) {
			if (gesture.pickedUIElement.name.Substring (0, 3) == "map") {
				On_Swipe (gesture);
			}
		}
		}
	}
bool  ifTouchOver  = true ;
	private Ray ray;
	private RaycastHit hit;
	public EventSystem eventSystem;
	public GraphicRaycaster graphicRaycaster;
 bool CheckGuiRaycastObjects()
    {
        PointerEventData eventData = new PointerEventData( eventSystem);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;

        List<RaycastResult> list = new List<RaycastResult>();
         graphicRaycaster.Raycast(eventData, list);
        //Debug.Log(list.Count);
        return list.Count > 0;
    }



	void On_Touch1(Gesture gesture)
	{ 
		if (CheckGuiRaycastObjects ())
			return;
		#if !UNITY_EDITOR  
		Debug.Log("EventSystem.current.IsPointerOverGameObject(   ) " + EventSystem.current.IsPointerOverGameObject(   ));
		Debug.Log("EventSystem.current.IsPointerOverGameObject(   Input.GetTouch(0).fingerId ) " + EventSystem.current.IsPointerOverGameObject(  Input.GetTouch(0).fingerId  ));
		Debug.Log("Input.GetTouch（0）.fingerId " + Input.GetTouch(0).fingerId);
		Debug.Log("gesture.GetGesture().fingerIndex " + gesture.GetGesture().fingerIndex);
		if (EventSystem.current.IsPointerOverGameObject(  Input.GetTouch(0).fingerId))   
		#else

		if (EventSystem.current.IsPointerOverGameObject())   
		#endif 
		{Debug.Log ("点到UI上");
			return;
		}
		//Debug.Log ("On_Touch1 穿透UI "  );
		 ray = Camera.main.ScreenPointToRay(gesture.position);
			//射线碰到了物体

		if (Physics.Raycast(ray,out hit,20000,(1 << 10) )) //1<<11 |   | (1 << 11) 
        {
            LuaBehaviour.ray(hit.point.x, hit.point.y, hit.point.z);
        }


        if (Physics.Raycast(ray, out hit, 20000, (1 << 11))) //1<<11 |   | (1 << 11) 
        { 
             LuaBehaviour.rayF (hit.collider.gameObject.name + "|" + hit.point.x + "|" + hit.point.y + "|" + hit.point.z); 
        }

        if (Physics.Raycast(ray, out hit, 20000, (1 << 10)))
        {
        //    Debug.Log(hit.collider.transform.name);
        //    Debug.Log(hit.point);
        //    Debug.Log(hit.point.x + "|" + hit.point.y + "|" + hit.point.z);

       

         }
    }

 

 void Update(){
	 if (mainCam==null){
		 	return ;
	 }
	 /*
 
			// 按鼠标左
		if (Input.GetMouseButtonDown(0))
			{

			Debug.Log ("22222  ");
				// 主相机屏幕点转换为射线
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//射线碰到了物体
				if (Physics.Raycast(ray,out hit))
				{

				Debug.Log ("111111111111111111111111111111  " + hit.collider.gameObject.name);
				LuaBehaviour.ray (hit.collider.gameObject.name);
					//销毁解除的游戏对象
					//GameObject.Destroy(hit.collider.gameObject);
				}
			} */
	 if (ifTouchOver){
				 Vector3 pos = mainCam.transform.localPosition;


		// 		   --    Public.Ptool.Xend1 =    -1.4   -- 这里从配置文件取出每个地图的边界
        // --    Public.Ptool.Xegde1 =  -0.92
        // --    Public.Ptool.Yend1 =  -0.19
        // --    Public.Ptool.Yegde1 =  -0.76

        // --    Public.Ptool.Xend2 =   1    -- 这里从配置文件取出每个地图的边界
        // --    Public.Ptool.Xegde2 =  0.29
        // --    Public.Ptool.Yend2 =  1.98
        // --    Public.Ptool.Yegde2 =    1.41
	 			// if (pos.x <-0.92f   ) {
				// 	  Debug.Log("move 1");
					 
				//  	 mainCam.transform.Translate(( (-0.92f  - pos.x)+1)*Time.deltaTime*2*camSpeed*Vector3.right , Space.Self);

				// }
				// if (pos.x > 0.29f) {
				// 	  Debug.Log("move 2");
				//  mainCam.transform.Translate(( (-0.29f  + pos.x)+1)*Time.deltaTime*2*camSpeed*Vector3.left, Space.Self);
				// }

				// if (pos.y < -0.19f   ) { 
					 
				//  	 mainCam.transform.Translate(( (-0.19f  - pos.y)+1)*Time.deltaTime*2*camSpeed*Vector3.up , Space.Self);

				// }
				// if (pos.y > 1.41f) { 
				//  mainCam.transform.Translate(( (-1.41f  + pos.y)+1)*Time.deltaTime*2*camSpeed*Vector3.down, Space.Self);
				// }
				// if (pos.x < Public.instance.Xegde1   ) {
				// 	  Debug.Log("move 1");
					 
				//  	 mainCam.transform.Translate(( (Public.instance.Xegde1  - pos.x)+1)*Time.deltaTime*2*camSpeed*Vector3.right , Space.Self);

				// }
				// if (pos.x > Public.instance.Xegde2) {
				// 	  Debug.Log("move 2 Public.instance.Xegde2 "+Public.instance.Xegde2);
				//  mainCam.transform.Translate(( ( -1*Public.instance.Xegde2  + pos.x)+1)*Time.deltaTime*2*camSpeed*Vector3.left, Space.Self);
				// }

				// if (pos.y < Public.instance.Yegde1  ) { 
					 
				//  	 mainCam.transform.Translate(( (Public.instance.Yegde1  - pos.y)+1)*Time.deltaTime*2*camSpeed*Vector3.up , Space.Self);

				// }
				// if (pos.y > Public.instance.Yegde2) { 
				//  mainCam.transform.Translate(( (    -1*Public.instance.Yegde2       + pos.y)+1)*Time.deltaTime*2*camSpeed*Vector3.down, Space.Self);
				// }

				  
	 }
	 
  }
	/// <summary>
	///控制视野移动
	/// </summary>
	/// <param name="gesture"></param>
	void On_Swipe(Gesture gesture)
	{

		#if !UNITY_EDITOR  
                if (EventSystem.current.IsPointerOverGameObject(gesture.GetGesture().fingerIndex))   
#else

        if (EventSystem.current.IsPointerOverGameObject())   
#endif 
        {
            return;
        }
        if (Public.instance.isGuide) {
				return;
			}	  
      if (gesture.pickedUIElement != null ) {
		  if (gesture.pickedUIElement.name == "Viewport" || gesture.pickedUIElement.name == "taskName" || gesture.pickedUIElement.name == "taskInfo" || gesture.pickedUIElement.name=="arrowsBup"){
		 	return;
		  }
			}	
 
	// 		   --    Public.Ptool.Xend1 =    -1.4   -- 这里从配置文件取出每个地图的边界
        // --    Public.Ptool.Xegde1 =  -0.92
        // --    Public.Ptool.Yend1 =  -0.19
        // --    Public.Ptool.Yegde1 =  -0.76

        // --    Public.Ptool.Xend2 =   1    -- 这里从配置文件取出每个地图的边界
        // --    Public.Ptool.Xegde2 =  0.29
        // --    Public.Ptool.Yend2 =  1.98
        // --    Public.Ptool.Yegde2 =    1.41

		if (gesture.touchCount ==1 ){
			ifTouchOver = false;
			 mainCam.transform.Translate(camSpeed*Vector3.left * gesture.deltaPosition.x / Screen.width , Space.Self);
			// if   (mainCam.transform.localPosition.x < -1.4f ) {
 			// 	mainCam.transform.localPosition = new Vector3 (-1.4f, mainCam.transform.localPosition.y, mainCam.transform.localPosition.z); 
			// }else if ( mainCam.transform.localPosition.x > 1f) {
 			// 	mainCam.transform.localPosition = new Vector3 (1f, mainCam.transform.localPosition.y, mainCam.transform.localPosition.z); 
			// }

			// 	if   (mainCam.transform.localPosition.x < Public.instance.Xend1 ) {
 			// 	mainCam.transform.localPosition = new Vector3 (Public.instance.Xend1, mainCam.transform.localPosition.y, mainCam.transform.localPosition.z); 
			// }else if ( mainCam.transform.localPosition.x > Public.instance.Xend2) {
 			// 	mainCam.transform.localPosition = new Vector3 (Public.instance.Xend2, mainCam.transform.localPosition.y, mainCam.transform.localPosition.z); 
			// }
			mainCam.transform.Translate (Vector3.down * gesture.deltaPosition.y / Screen.height * 9  , Space.Self);
			// if (mainCam.transform.localPosition.y > 1.98f){
 			// 	 	mainCam.transform.localPosition = new Vector3 ( mainCam.transform.localPosition.x,  1.98f,mainCam.transform.localPosition.z); 
 			
			// }else if ( mainCam.transform.localPosition.y < -0.76f) {
 			// 		mainCam.transform.localPosition = new Vector3 ( mainCam.transform.localPosition.x, -0.76f, mainCam.transform.localPosition.z); 
			// }
			// if ( mainCam.transform.localPosition.y < Public.instance.Yend1) {
 			// 		mainCam.transform.localPosition = new Vector3 ( mainCam.transform.localPosition.x, Public.instance.Yend1, mainCam.transform.localPosition.z); 
			// }else if (mainCam.transform.localPosition.y > Public.instance.Yend2){
 			// 	 	mainCam.transform.localPosition = new Vector3 ( mainCam.transform.localPosition.x,  Public.instance.Yend2 ,mainCam.transform.localPosition.z); 
 			
			// } 
           
		}


		// Vector3 pos = mainCam.transform.localPosition;
		 
		// if (gesture.pickedUIElement.name.Length > 3) {
		// 	if (gesture.pickedUIElement.name.Substring (0, 3) == "map") {
		// 		mainCam.transform.Translate (Vector3.left * gesture.deltaPosition.x / Screen.width * moveSpeed, Space.World);
		// 		mainCam.transform.Translate (Vector3.down * gesture.deltaPosition.y / Screen.height * moveSpeed, Space.World);
		// 		if (pos.x < -283f) {
		// 			mainCam.transform.localPosition = new Vector3 (-283f, pos.y, pos.z); 
		// 		}
		// 		if (pos.x > 1571f) {
		// 			mainCam.transform.localPosition = new Vector3 (1571f, pos.y, pos.z);
		// 		}
		// 		if (pos.y < 850f) {
		// 			mainCam.transform.localPosition = new Vector3 (pos.x, 850f, pos.z);
		// 		}
		// 		if (pos.y > 1899f) {
		// 			mainCam.transform.localPosition = new Vector3 (pos.x, 1899f, pos.z);
		// 		}
		// 	}
		// //}
		// }
	}

	/// <summary>
	/// 双指滑动,控制视野缩放
	/// </summary>
	/// <param name="gesture"></param>
	void On_PinchIn(Gesture gesture)
	{
//			mainCam.fieldOfView -= gesture.deltaPinch * Time.deltaTime;
//		mainCam.transform.position += transform.forward * gesture.deltaPinch * Time.deltaTime * scaleSpeed;
		// Vector3 pos = mainCam.transform.localPosition;
		// float zoom = gesture.deltaPinch *Time.deltaTime*20;
		// if (pos.z - zoom < -512f) {
		// 	zoom = (pos.z + 512f);
		// }
		// mainCam.transform.localPosition=new Vector3(pos.x,pos.y,pos.z-zoom); 
//		if (mainCam.transform.position.z > -580f) {
//			zoom = -580f;
//		     mainCam.transform.position = new Vector3 (pos.x, pos.y, zoom);
//	      } #endregion

if (mainCam.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize == 1.5f){

		mainCam.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize = 2.4f;
}else {
		
		mainCam.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize = 5f;
}
	}
	void On_SwipeEnd(Gesture gesture){
		ifTouchOver = true;		
	}
	void On_PinchOut(Gesture gesture)
	{
if (mainCam.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize == 4){

		mainCam.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize = 2.4f;
}else {
		
		mainCam.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize = 1.5f;
}
		
  mainCam.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize = 2.4f;
		// Vector3 pos = mainCam.transform.localPosition;
		// float zoom = gesture.deltaPinch *Time.deltaTime*20;
		// if (pos.z + zoom > -96f) {
		// 	zoom = (-96f - pos.z);
		// }
		// mainCam.transform.localPosition=new Vector3(pos.x,pos.y,pos.z+zoom); 
//		Debug.LogError2 ("zzzzzzz" + mainCam.transform.position.z);
//		if (mainCam.transform.position.z > -6f) {
//			zoom = -6f;
//			mainCam.transform.position = new Vector3 (pos.x, pos.y, zoom);
//		}
//		mainCam.transform.position += transform.forward * gesture.deltaPinch * Time.deltaTime * scaleSpeed;
//		if (mainCam.transform.position.z < -680f) {
//			mainCam.transform.position = new Vector3 (mainCam.transform.position.x, mainCam.transform.position.y, -680f);
//		}

	}

}
