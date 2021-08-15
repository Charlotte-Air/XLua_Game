using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;  
using XLua;
public class AntTimer : MonoBehaviour {

	protected int leftMinute;
	protected   Text timeText ; 
	protected int startHTtime ;
	protected   string  ID ; 
	protected void Awake()
    { 
		timeText = this.GetComponent<Text>();
	}
	public bool startflag = true ;
	[CSharpCallLua]
     public delegate void AntTimerCallBackDelegate(string rpc);
	 public AntTimerCallBackDelegate  antTimerCallBack;
	void Update(){
		if (leftMinute>=0 && startflag ){ //startflag
				startflag = false;
				 TimeStartWork();
		}
	}
	protected void TimeStartWork()
    { 
		if (Application.isPlaying == false)
			return;

			StartCoroutine("timerWorking");
	}
	public void SetTime(int leftMinute, bool startflag, string ID)
	{	
		StopAllCoroutines();
		this.leftMinute = leftMinute; 
		this.startflag = startflag;
		this.ID = ID;
	}
	protected  IEnumerator timerWorking()
    {   
        while (leftMinute >= 0)
        {
			if ((leftMinute) / 3600 ==0){
  timeText.text =   (((leftMinute % 86400) % 3600) / 60) + "分" + (leftMinute % 60) + "秒";
			}else{
  timeText.text = ((leftMinute) / 3600) + "时" + (((leftMinute % 86400) % 3600) / 60) + "分" + (leftMinute % 60) + "秒";
			}
          
            yield return new WaitForSeconds(1);
            leftMinute--; 
        }
		 if(antTimerCallBack != null)
            antTimerCallBack(	this.ID );
    }
	public void OnApplicationPause(bool isPause)
    { 
        if (isPause)
        { 
            startHTtime = ((int)Time.realtimeSinceStartup); 
        }
        else
        {  
            Refresh((int)Time.realtimeSinceStartup - startHTtime); 
        }
    }

    public void Refresh(int num)
    {
		leftMinute = leftMinute - num > 2 ? leftMinute - num : 2 ; 
	}
   
}
