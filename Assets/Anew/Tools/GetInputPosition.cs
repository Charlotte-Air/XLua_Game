using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputPosition : MonoBehaviour {
	private Ray ray;
    private RaycastHit hit;

	private LayerMask mask;
	public static float posx;
	public static float posy;

	void Start () {
		mask = 1 << 9;
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetMouseButton(0))
        {
            // 主相机屏幕点转换为射线
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //射线碰到了物体
            if (Physics.Raycast(ray,out hit))
            {
                //销毁解除的游戏对象
				posx = hit.point.x;
				posy = hit.point.y;

              //  GameObject.Destroy(hit.collider.gameObject);
            }
        }
	}
}
