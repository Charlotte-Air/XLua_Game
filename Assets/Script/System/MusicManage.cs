using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using XLua;

[LuaCallCSharp]
//DaHai创建于2018.7.7  用于音乐和音效的控制
public class MusicManage : MonoBehaviour
{

    public static MusicManage instance;

    AudioSource buttonVoice;
    //按钮音效
    AudioSource backgroundMusic;
    //背景音乐
    AudioSource fightMusic;
    //战斗音乐
    AudioSource openBox;
    //开箱子音效
    AudioSource jianmoFightMusic;
    //开局剑魔战斗专用
    AudioSource jianghuMusic;
    //江湖模块的音效


    GameObject musicB;
    //音乐按钮
    GameObject soundB;
    //音效按钮
    GameObject musicBTXT;
    //音乐按钮 TXT
    GameObject soundBTXT;
    //音效按钮TXT
    //存储所有战斗音效的List
    List<AudioClip> audioClip_List = new List<AudioClip>();

    //是否战斗音效静音
    bool is_FightingSoundEffectMute = false;

    void Awake()
    {

       // Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace);
        instance = this;
    }
     void Start(){
          Init();
     }
     public void Init()
    {
     
         buttonVoice = GameObject.Find("buttonVoice").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
        fightMusic = GameObject.Find("fightMusic").GetComponent<AudioSource>();
        openBox = GameObject.Find("openBox").GetComponent<AudioSource>();
        jianmoFightMusic = GameObject.Find("jianmozhandou").GetComponent<AudioSource>();
        jianghuMusic= GameObject.Find("jianghuMusic").GetComponent<AudioSource>();
        
        openSp = ResourceManager.GetSpritePath("huangbuttondi","public"); 
        closeSp = ResourceManager.GetSpritePath("huibuttondi","public"); 
        LoadAllFightClip();
     }

    

    //取到所有的音频片段，存入列表
    void   LoadAllFightClip()
    {
        //按照顺序依次存入List中，以后调用，只是传入索引
        //攻击,格挡，闪避,暴击，单体技能，群体技能
        audioClip_List.Add(Resources.Load<AudioClip>("Music/hit"));
        audioClip_List.Add(Resources.Load<AudioClip>("Music/gedang"));
        audioClip_List.Add(Resources.Load<AudioClip>("Music/shanbi"));
        audioClip_List.Add(Resources.Load<AudioClip>("Music/baoji"));
        audioClip_List.Add(Resources.Load<AudioClip>("Music/OneSkill"));
        audioClip_List.Add(Resources.Load<AudioClip>("Music/AllSkill"));

        audioClip_List.Add(Resources.Load<AudioClip>("Music/shenzhao"));  //回命
        audioClip_List.Add(Resources.Load<AudioClip>("Music/hudun"));  //护盾
        audioClip_List.Add(Resources.Load<AudioClip>("Music/xiao"));  //王者的无视
    }

    Sprite openSp;
    //打开按钮的显示
    Sprite closeSp;
    //关闭按钮的背景音乐
	
    public void InItMusicEnvironment()  //初始化音乐环境   绑定更改音乐按钮控制事件
    {
        musicB = Public.instance.canvas.transform.Find("level2/a_menpai/menpai_interface/A_setUp/setup_interface/list/viewport/content/musicB/yes").gameObject; 
        soundB = Public.instance.canvas.transform.Find("level2/a_menpai/menpai_interface/A_setUp/setup_interface/list/viewport/content/soundB/yes").gameObject;
        musicBTXT = musicB.transform.Find("Text").gameObject;
        soundBTXT = soundB.transform.Find("Text").gameObject;
 
        if (PlayerPrefs.GetString("music") != "")
        {
            if (PlayerPrefs.GetString("music").Equals("on"))
            {
                backgroundMusicControl(0);
                musicB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(1));	
                musicBTXT.GetComponent<Text>().text = "关闭";
                musicB.GetComponent<Image>().sprite = closeSp; 
              
            }
            else
            {
                backgroundMusicControl(1);
                musicB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(0));	
                musicBTXT.GetComponent<Text>().text = "打开";
                musicB.GetComponent<Image>().sprite = openSp; 
   
              
            }
		
            if (PlayerPrefs.GetString("sound").Equals("on"))
            {
                backgroundMusicControl(2);
                soundB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(3));
                soundBTXT.GetComponent<Text>().text = "关闭";
                soundB.GetComponent<Image>().sprite = closeSp; 

            }
            else
            {
                backgroundMusicControl(3);
                soundB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(2));
                soundBTXT.GetComponent<Text>().text = "打开";
                soundB.GetComponent<Image>().sprite = openSp; 
            
            }
        }
        else
        {
            backgroundMusicControl(0);
            backgroundMusicControl(2);
            //全部默认打开
            musicB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(1));	
            soundB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(3));
            musicBTXT.GetComponent<Text>().text = "关闭";
            soundBTXT.GetComponent<Text>().text = "关闭";
            musicB.GetComponent<Image>().sprite = closeSp; 
            soundB.GetComponent<Image>().sprite = closeSp; 

        }
    }

    public void Sound_PlayButton()  //按钮音效
    {
        buttonVoice.playOnAwake = true;
        buttonVoice.Play();
    }

    public void Sound_OpenBoxButton()  //开箱子音效
    {
        openBox.playOnAwake = true;
        openBox.Play();
    }

    private bool isJianghu = false;
    public void backgroundMusicControl(int playState)  //音乐控制
    { 
        switch (playState)
        {
            case 0:  //音乐打开
                backgroundMusic.Play();
                backgroundMusic.volume = 0.3f;
                PlayerPrefs.SetString("music", "on");
                // musicB.GetComponent<Button>().onClick.RemoveAllListeners();
                // musicB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(1));	
                // musicBTXT.GetComponent<Text>().text = "关闭";
                // musicB.GetComponent<Image>().sprite = closeSp; 
                is_FightingSoundEffectMute = false;  //设置为静音状态
                break; 
            case 1:  //音乐关闭
                backgroundMusic.Stop();
                backgroundMusic.volume = 0;
                PlayerPrefs.SetString("music", "off");
                // musicB.GetComponent<Button>().onClick.RemoveAllListeners();
                // musicB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(0));	
                // musicBTXT.GetComponent<Text>().text = "打开";
                // musicB.GetComponent<Image>().sprite = openSp; 
                is_FightingSoundEffectMute = true;  //设置为静音状态
                break; 		 	
            case 2: //音效打开
                buttonVoice.volume = 1f;
                openBox.volume = 1;
                PlayerPrefs.SetString("sound", "on");
                // soundB.GetComponent<Button>().onClick.RemoveAllListeners();
                // soundB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(3));
                // soundBTXT.GetComponent<Text>().text = "关闭";
                // soundB.GetComponent<Image>().sprite = closeSp; 
                break;
            case 3: //音效关闭
                buttonVoice.volume = 0;
                openBox.volume = 0;
                PlayerPrefs.SetString("sound", "off"); 
                // soundB.GetComponent<Button>().onClick.RemoveAllListeners();
                // soundB.GetComponent<Button>().onClick.AddListener(() => backgroundMusicControl(2));
                // soundBTXT.GetComponent<Text>().text = "打开";
                // soundB.GetComponent<Image>().sprite = openSp; 
                break;
            case 4: //播放战斗音乐
                if (backgroundMusic.volume > 0)
                {
                    backgroundMusic.Stop();
                    fightMusic.Play();
                    jianghuMusic.Stop();
                } 			
                break;
            case 5: //战斗音乐停止
                if (backgroundMusic.volume > 0)
                {
                    backgroundMusic.Play();
                    fightMusic.Stop();
                    if (isJianghu)
                    {
                        jianghuMusic.Play();
                     }
                } 
                break;
            case 6: //播放开局剑魔战斗专用音乐
                fightMusic.volume = 0;
                jianmoFightMusic.Play();
                break;
            case 7: //战斗开局剑魔战斗专用音乐
//				backgroundMusic.Play();
                jianmoFightMusic.Stop();
                 break;
            case 8: //播放江湖模块专属音乐
                if (backgroundMusic.volume > 0)
                {
                    backgroundMusic.Pause();
                    jianghuMusic.Play();
                    isJianghu = true;
                } 			
                break;
            case 9: //停止江湖模块专属音乐
                if (backgroundMusic.volume > 0)
                {
                    backgroundMusic.UnPause();
                    jianghuMusic.Stop();
                    isJianghu = false;
                } 
                break;
            default:
                break;
        }
     }


    /// <summary>
    /// 传入音效索引
    /// 普通攻击0,格挡1，闪避2,暴击3，单体技能4，群体技能5,回命6，护盾7，王者的无视8
    /// </summary>
    /// <param name="num">Number.</param>
    //播放战斗音效
    public void PlaySoundEffect(int num)
    {
        return;
        Debug.Log("PlaySoundEffect  "+num);
        
        //攻击,格挡，闪避,暴击，单体技能，群体技能

        if (!((num > audioClip_List.Count - 1) || is_FightingSoundEffectMute))
        {
            GameObject fightSoundEffect = new GameObject("fightSoundEffect");
            AudioSource audioSource = fightSoundEffect.AddComponent<AudioSource>();
            audioSource.volume = 1;
            //依据索引从表中取到音频片段
            audioSource.clip = audioClip_List[num];

            audioSource.Play();
            Destroy(fightSoundEffect, audioSource.clip.length);
        }




    }



    public void CloseAllMusic()
    {
	    
        backgroundMusic.Stop();
        fightMusic.Stop();
        fightMusic.volume = 1;
        jianmoFightMusic.Stop();
     
    }

    public bool  MusicSwitch(){
            bool rsl = false;
                if (PlayerPrefs.GetString("music") != ""){
                    if (!PlayerPrefs.GetString("music").Equals("on"))
                    {
                        backgroundMusicControl(0); 
                        rsl = true;
                    }
                    else
                    {
                        backgroundMusicControl(1); 
                        rsl = false;
                    } 
                }else{
                     backgroundMusicControl(0); 
                     rsl = true;
                }
 
                return rsl;
    }
    public bool SoundSwitch(){
          bool rsl = false;
        if (PlayerPrefs.GetString("sound") != ""){
            if (!PlayerPrefs.GetString("sound").Equals("on"))
            {
                backgroundMusicControl(2);   rsl = true;
            }
            else
            {
                backgroundMusicControl(3);  rsl = false;
            
            }
         }else{
                backgroundMusicControl(2);   rsl = true;
            
         }
	  return rsl;
    } 
}
