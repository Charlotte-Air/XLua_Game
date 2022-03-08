using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpFollow : MonoBehaviour {

 
    public Camera m_camera;
    public Transform m_target;
    public RectTransform m_ui;
    public GameObject canvas;
    private Vector3 position_sp;

    private void Awake()
    {
        if (m_camera == null)
        {
            m_camera = Camera.main;
        }
        if (m_ui == null && transform is RectTransform)
        {
            m_ui = (RectTransform)transform;
        }
    }

    private void LateUpdate()
    {
        if (m_target != null)
        {
			

            Vector2 uisize = canvas.GetComponent<RectTransform>().sizeDelta;//得到画布的尺寸
			Vector2 screenpos = UnityEngine.Camera.main.WorldToScreenPoint(m_target.transform.position);//将世界坐标转换为屏幕坐标
            Vector2 screenpos2;
            screenpos2.x = screenpos.x - (Screen.width / 2);//转换为以屏幕中心为原点的屏幕坐标
            screenpos2.y = screenpos.y - (Screen.height / 2);
            Vector2 uipos;
            uipos.x = (screenpos2.x / Screen.width) * uisize.x;
            uipos.y = (screenpos2.y / Screen.height) * uisize.y;//得到UGUI的anchoredPosition

            m_ui.anchoredPosition = uipos;




        }
    }

 
}
