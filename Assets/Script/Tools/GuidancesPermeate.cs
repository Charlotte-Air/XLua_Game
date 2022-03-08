using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuidancesPermeate : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    //监听按下
    public void OnPointerDown(PointerEventData eventData)
    {
        // PassEvent(eventData, ExecuteEvents.pointerDownHandler);
    }

    //监听抬起
    public void OnPointerUp(PointerEventData eventData)
    {
        // PassEvent(eventData, ExecuteEvents.pointerUpHandler);
    }

    //监听点击
    public void OnPointerClick(PointerEventData eventData)
    {
         PassEvent(eventData, ExecuteEvents.submitHandler);
        // PassEvent(eventData, ExecuteEvents.pointerClickHandler);
    }

     //把事件透下去
    public void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function)
        where T : IEventSystemHandler
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        GameObject current = data.pointerCurrentRaycast.gameObject;
         Debug.Log("把事件透下去"+results.Count);
        for (int i = 0; i < results.Count; i++)
        { 
            Debug.Log("results[i].gameObject="+results[i].gameObject.name);
            if (current != results[i].gameObject){
             Button btn =results[i].gameObject.GetComponent<Button>(); 
             if  ( btn  != null ) {
                 Debug.Log("进来了几次");
                ExecuteEvents.Execute(results[i].gameObject, data, function); 
                //RaycastAll后ugui会自己排序，如果你只想响应透下去的最近的一个响应，这里ExecuteEvents.Execute后直接break就行。
                 break;
              } 
             }  
           }
    } 

}
