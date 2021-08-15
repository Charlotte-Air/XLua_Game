using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using XLua;


using System.IO;

[LuaCallCSharp]
public class Public  : MonoBehaviour
{

    GameObject LoadScene;

    public static Public instance;

       public bool isGuide = false;//是否引导

    public GameObject canvas;
    public GameObject canvasLoad;
    public GameObject TextDrama;
    // public GameObject GameInit;
    GameObject warn_prefabs;
    GameObject panel_warn;
    bool warnmove = false;
    //战斗动画的游戏物体
    public GameObject fightAnimation;
    //结算界面
    public GameObject settlement;
    GameObject heropos;
    GameObject Temp_hero;
    GameObject settlement_hero;
    GameObject getGain;
    GameObject xuezhan_esc;
    GameObject lunjian_esc;
    GameObject xingxia_esc;

    //通用阵容展示
    GameObject tongyongzr; 
    //通用弟子详情
    GameObject tongyongdzxq;
    //重播按钮
    private GameObject replay;

    //储存模块状态
    public Dictionary<int,int> SaveMoldState = new Dictionary<int, int>();


 

    //弟子介绍页面
    private GameObject PersonPage_Prefab;
    //装备介绍页面
    private GameObject EquipPage_Prefab;
    //武功介绍页面
    private GameObject BookPage_Prefab;
    //雕像介绍页面
    private GameObject StatuePage_Prefab;
    //道具介绍页面
    private GameObject PropPage_Prefab;
[HideInInspector]
      public float Xend1 ,Xegde1, Yend1 ,Yegde1 , Xend2 ,Xegde2, Yend2 ,Yegde2  ;
    [LuaCallCSharp]
      public void setXyInfo(  float Xend1 ,float Xegde1,float  Yend1 ,float Yegde1 , float Xend2 ,float Xegde2,float  Yend2 ,float Yegde2   ){

          Debug.Log("setXyInfo  ****  Xegde2 "+ Xegde2 );
            this.Xend1  = Xend1 ; 
            this.Xegde1  = Xegde1 ; 
            this.Yend1  = Yend1 ; 
            this.Yegde1  = Yegde1 ; 
            this.Xend2  = Xend2 ; 
            this.Xegde2  = Xegde2 ; 
            this.Yend2  = Yend2 ; 
            this.Yegde2  = Yegde2 ;  
           
      }

    //单独的页面的所用到的资源
    //甲字红底白字
    //public Sprite JiaZi_Sprite_RedBottom;
    ////乙字红底白字
    //public Sprite YiZi_Sprite_RedBottom;
    ////丙字红底白字
    //public Sprite BingZi_Sprite_RedBottom;
    ////丁字红底白字
    //public Sprite DingZi_Sprite_RedBottom;

    ////甲字图标
    //public Sprite JiaZi_Sprite;
    ////乙字图标
    //public Sprite YiZi_Sprite;
    ////丙字图标
    //public Sprite BingZi_Sprite;
    ////丁字图标
    //public Sprite DingZi_Sprite;

    ////攻字图标
    //public Sprite GongZi_Sprite;
    ////防字图标
    //public Sprite FangZi_Sprite;
    ////血字图标
    //public Sprite XueZi_Sprite;
    ////内字图标
    //public Sprite NeiZi_Sprite;
    ////势字图标
    //public Sprite ShiZi_Sprite;

    //攻加字图标
    //   public Sprite GongJiaZi_Sprite;
    //防加字图标
    //   public Sprite FangJiaZi_Sprite;
    //血加字图标
    //   public Sprite XueJiaZi_Sprite;
    //内加字图标
    //   public Sprite NeiJiaZi_Sprite;

    //通用按钮，灰色
    //  public Sprite tongyonganniu1;
    //通用按钮，黄色
    //  public Sprite tongyonganniu2;
    //通用按钮，橙色
    //   public Sprite tongyonganniu4;

    //行舟页面的奇遇灰色按钮
    //  public Sprite qiyu001;
    //行舟页面的奇遇橙色按钮
    // public Sprite qiyu002;

    //通用阵容按钮灰色
    //  public Sprite tongyongzhenrong5;
    //通用阵容按钮橙色
    //  public Sprite tongyongzhenrong4;

    // Sprite shibai_Sprite;
    // Sprite xibai_Sprite;
    // Sprite canbai_Sprite;
    //  Sprite shengli_Sprite;
    //  Sprite xiansheng_Sprite;
    //  Sprite dasheng_Sprite;
    //    Sprite shenglidi_Sprite;
    //   Sprite shengliqizi_Sprite;
    // Sprite shibaidi_Sprite;
    //  Sprite shibaiqizi_Sprite;
    //Sprite suo_Sprite;
    // Sprite tongyongtouxiang_Sprite;



//     public void changeCam(string  type)
//     {
//         if (type.Equals("P"))
//         {
			
//             Camera.main.GetComponent<Camera>().orthographic = false;
//         }
//         else
//         {

//             Camera.main.GetComponent<Camera>().orthographic = true;
//         }

//     }

//     public void WaySaveMoldState()
//     {
//         if (PDM.data.root.moduleControlList != null)
//         {
//             for (int i = 0; i < PDM.data.root.moduleControlList.Count; i++)
//             {
//                 SaveMoldState.Add(PDM.data.root.moduleControlList[i].moduleId, PDM.data.root.moduleControlList[i].moduleState);
//             }
//         }
//     }

//     public int getModuleState(int id)
//     {


//         return SaveMoldState[id];
//     }
//     //取到
  void Awake()
   {    

      
       
        instance = this; 
     } 

    

//     public void init()
//     {
//         //Debug.Log3("public init ************ " + Time.realtimeSinceStartup);
         
//         canvas = GameObject.Find("Canvas");
//         canvasLoad = GameObject.Find("CanvasLoad");
//         LoadScene = canvasLoad.transform.Find("LoadingScene").gameObject;

//         initWarnBar();

//         LoadResources();
//         //Debug.Log3("public init end ************ " + Time.realtimeSinceStartup);
//     }

//     void initWarnBar()
//     {

//         warn_prefabs = Resources.Load("warn/warn_ban") as GameObject;
//         panel_warn = Instantiate(warn_prefabs, warn_prefabs.transform.position, Quaternion.identity) as GameObject;
//         panel_warn.transform.SetParent(canvasLoad.transform, false);//将这个放在start下面
//         panel_warn.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
//         panel_warn.SetActive(false);
      
// //        panel_warn.transform.position = canvasLoad.transform.position + new Vector3(0, 200, 0);
//         // Debug.Log("生成提示搬。。。。。。。。。。。。。。。。。。。。。。。。");
//     }

//     // public void LoadResources()
//     // {
      


         

//     //     PersonPage_Prefab = ResourceManager.GetPrefab("personpage_prefab");
//     //     EquipPage_Prefab = ResourceManager.GetPrefab("equippage_prefab");
//     //     BookPage_Prefab = ResourceManager.GetPrefab("bookpage_prefab");
//     //     StatuePage_Prefab = ResourceManager.GetPrefab("statuepage_prefab");
//     //     PropPage_Prefab = ResourceManager.GetPrefab("proppage_prefab");

         
//     //     // GameInit = GameObject.Find("GameInit");


//     //     prizeTipPrefab = ResourceManager.GetPrefab("prizetip");
//     //     prizeDetPrefab = ResourceManager.GetPrefab("prizedet");
//     //     MPSJTipPrefab = ResourceManager.GetPrefab("lvuppage");
 
//     //     settlement = canvasLoad.transform.Find("A_settlement").gameObject;
//     //     heropos = settlement.transform.Find("hero_pos").gameObject;
        
//     //     settlement_hero = ResourceManager.GetPrefab("b_settlement_hero");

//     //     getGain = canvasLoad.transform.Find("A_settlement/getGain").gameObject;
//     //     xuezhan_esc = canvasLoad.transform.Find("A_settlement/xuezhan_esc").gameObject;
//     //     lunjian_esc = canvasLoad.transform.Find("A_settlement/lunjian_esc").gameObject;
//     //     xingxia_esc = canvasLoad.transform.Find("A_settlement/xingxia_esc").gameObject;
//     //     //给血战确定按钮赋值
//     //     xuezhan_esc.GetComponent<Button>().onClick.RemoveAllListeners();
//     //     xuezhan_esc.GetComponent<Button>().onClick.AddListener(delegate
//     //         {
//     //             Serverdata_UI.instance.GetNextBloodBattle();
//     //         });

//     //     lunjian_esc.GetComponent<Button>().onClick.RemoveAllListeners();
//     //     lunjian_esc.GetComponent<Button>().onClick.AddListener(delegate
//     //         {
//     //             settlement.SetActive(false);
//     //             schoolUpLenvel();
//     //             //Serverdata_UI.instance.GetNextBloodBattle();
//     //         });

//     //     replay = settlement.transform.Find("replay").gameObject;
//     //     //重播按钮
//     //     replay.GetComponent<Button>().onClick.RemoveAllListeners();
//     //     replay.GetComponent<Button>().onClick.AddListener(delegate
//     //         {
//     //             A_FightAnimation.instance.Replay();
//     //         });



//     //     xingxia_esc.GetComponent<Button>().onClick.RemoveAllListeners();
//     //     xingxia_esc.GetComponent<Button>().onClick.AddListener(delegate
//     //         {
//     //             settlement.SetActive(false);
//     //         });



//     //     settlement.SetActive(false);
         

//     //     //通用阵容
//     //     tongyongzr = ResourceManager.GetPrefab("a_tongyongzr");

//     //     tongyongdzxq = ResourceManager.GetPrefab("a_tydzxiangqing");

//     // }

//     public void  warning(string infor)
//     {
//         if (!warnmove)
//         { 
//             warnmove = true;
// //            panel_warn.transform.localPosition = Vector3.zero + new Vector3(0, 55, 0);
//             panel_warn.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 70, 0);
//             panel_warn.SetActive(true);
//             panel_warn.transform.SetAsLastSibling();
//             panel_warn.transform.GetComponentInChildren<Text>().text = infor;
//             RectTransform rt = panel_warn.GetComponent<RectTransform>();
//             if (Camera.main.orthographic)
//             {
//                 rt.DOAnchorPosY(1000, 1.2f, false).OnComplete(delegate
//                     {
//                         panel_warn.SetActive(false);
//                         warnmove = false;
//                     });
//             }
//             else
//             {
//                 rt.DOAnchorPosY(0, 0.5f, false).OnComplete(delegate
//                     {
//                         panel_warn.SetActive(false);
//                         warnmove = false;
//                     });
//             }
//         }
//     }

//     // 升级提示框
//     GameObject MPSJTipPrefab;
//     GameObject MPSJTipObj;

//     public void schoolUpLenvel()
//     {
//         if (PDM.data.root.leaderUpgradeData != null)
//         {
//             if (PDM.data.root.leaderUpgradeData[0].isUpLv == 1)
//             {
//                 MPSJTipObj = Instantiate(MPSJTipPrefab, MPSJTipPrefab.transform.position, Quaternion.identity)as GameObject;
//                 MPSJTipObj.transform.SetParent(canvasLoad.transform, false);
//                 MPSJTipObj.transform.SetSiblingIndex(-1);
//                 GameObject level = MPSJTipObj.transform.Find("lv").gameObject;
//                 level.GetComponent<Text>().text = "达到 " + PDM.data.root.leaderUpgradeData[0].level + " 级";

//                 GameObject yuanBao = MPSJTipObj.transform.Find("yb/num").gameObject;
//                 yuanBao.GetComponent<Text>().text = "数量：" + PDM.data.root.leaderUpgradeData[0].yuanBao;

//                 GameObject Sliver = MPSJTipObj.transform.Find("yl/num").gameObject;
//                 Sliver.GetComponent<Text>().text = "数量：" + PDM.data.root.leaderUpgradeData[0].silver;


//                 GameObject truec = MPSJTipObj.transform.Find("true").gameObject;
//                 truec.GetComponent<Button>().onClick.AddListener(() => CloseUp());	
//                 PDM.data.root.leaderUpgradeData[0].isUpLv = 0;

//                 UnLockNewMoudle unLockNewMoudle = LuaBehaviour.luaEnv.Global.Get<UnLockNewMoudle>("unLockNewMoudle");
//                 unLockNewMoudle();
//             }
//         }
//     }

//     [CSharpCallLua] 
//     public delegate void UnLockNewMoudle();
  




//     public void CloseUp()
//     {
//         Destroy(MPSJTipObj.gameObject);

//         //玩家点击升级的确定按钮 这个是时候引导出新的功能
//        // GameMainData.instance.PromoteOpenPage();

//     }



//     GameObject prizeTipPrefab;
//     public GameObject prizeTipObj;
//     GameObject head;
//     GameObject prizeDetPrefab;
//     //奖励预制体
//     GameObject head2;
//     //恭喜你获得：
//     GameObject head3;
//     //恭喜你获得额外奖励：
//     //额外奖励标题预制体
//     GameObject prizeContent;
//     GameObject CloseB;
//     GameObject trueB;

//     GameObject prizeyb;
//     //元宝
//     GameObject prizeGold;
//     //金叶子
//     GameObject prizeSliver;
//     //银两

	
//     Dictionary<string,int> SaveRepetitionPropPrize = new Dictionary<string, int>();
//     //用于储存重复的道具奖励

//     ArrayList savePropId = new ArrayList();
//     bool isGetprize = false;
//     int isGetNum = 0;
//     bool isextraGetprize = false;

//     //通用的奖励提示框
//     public void PrizeTip()
//     { 
//         if (PDM.data.root.rewardList != null)
//         {
//             prizeTipObj = Instantiate(prizeTipPrefab, prizeTipPrefab.transform.position, Quaternion.identity) as GameObject;
//             prizeTipObj.transform.SetParent(canvasLoad.transform, false);
//             prizeTipObj.transform.SetSiblingIndex(-1);
//             prizeContent = prizeTipObj.transform.Find("List/View/Content").gameObject;

//             head2 = prizeContent.transform.Find("head2").gameObject;
//             head3 = prizeContent.transform.Find("head3").gameObject;
//             prizeyb = prizeContent.transform.Find("prizeyb").gameObject;
//             prizeGold = prizeContent.transform.Find("prizeGold").gameObject;
//             prizeSliver = prizeContent.transform.Find("prizeSliver").gameObject;


//             head = prizeTipObj.transform.Find("head/name").gameObject;
//             head.GetComponent<Text>().text = PDM.data.root.rewardList[0].title;

//             CloseB = prizeTipObj.transform.Find("closeB").gameObject;
//             trueB = prizeTipObj.transform.Find("trueB").gameObject;
//             CloseB.GetComponent<Button>().onClick.AddListener(() => ClosePage());
//             trueB.GetComponent<Button>().onClick.AddListener(() => ClosePage());

//             int yb = 0;
//             int jyz = 0;
//             int yl = 0;
//             for (int i = 0; i < PDM.data.root.rewardList.Count; i++)
//             {

//                 if (PDM.data.root.rewardList[i].yuanBao > 0)
//                 {
//                     yb += PDM.data.root.rewardList[i].yuanBao;
//                 }

//                 if (PDM.data.root.rewardList[i].goldLeaf > 0)
//                 {
//                     jyz += PDM.data.root.rewardList[i].goldLeaf;

//                 }

//                 if (PDM.data.root.rewardList[i].sliver > 0)
//                 {
//                     yl += PDM.data.root.rewardList[i].sliver;

//                 }


//                 //道具
//                 if (PDM.data.root.rewardList[i].itemList != null)
//                 {
//                     isextraGetprize = true;
//                     for (int a = 0; a < PDM.data.root.rewardList[i].itemList.Count; a++)
//                     {
//                         if (SaveRepetitionPropPrize.ContainsKey(PDM.data.root.rewardList[i].itemList[a].itemId))
//                         {
//                             int number = SaveRepetitionPropPrize[PDM.data.root.rewardList[i].itemList[a].itemId] + PDM.data.root.rewardList[i].itemList[a].num;
//                             SaveRepetitionPropPrize[PDM.data.root.rewardList[i].itemList[a].itemId] = number; 
//                         }
//                         else
//                         {
//                             SaveRepetitionPropPrize.Add(PDM.data.root.rewardList[i].itemList[a].itemId, PDM.data.root.rewardList[i].itemList[a].num);
//                             savePropId.Add(PDM.data.root.rewardList[i].itemList[a].itemId);
//                         } 
//                     } 
//                 }

//                 //额外奖励


//                 //武功
//                 if (PDM.data.root.rewardList[i].bookList != null)
//                 {
//                     isextraGetprize = true;
//                     for (int b = 0; b < PDM.data.root.rewardList[i].bookList.Count; b++)
//                     {
//                         GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                         //奖励名字1
//                         GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                         pname1.GetComponent<Text>().text = GameMainData.instance.wg_[PDM.data.root.rewardList[i].bookList[b].metaId].wg_name;  
//                         //奖励名字2
//                         GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                         pname2.GetComponent<Text>().text = "武功"; 
//                         //数量
//                         GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                         pnum.GetComponent<Text>().text = "数量：1";
//                         prizeObj.transform.SetParent(prizeContent.transform, false);

//                         GameMainData.instance.getWugong(PDM.data.root.rewardList[i].bookList[b].bookId, PDM.data.root.rewardList[i].bookList[b].metaId);

//                     }

//                 }

//                 //装备
//                 if (PDM.data.root.rewardList[i].equipList != null)
//                 {
//                     isextraGetprize = true;
//                     for (int c = 0; c < PDM.data.root.rewardList[i].equipList.Count; c++)
//                     {
//                         GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                         //奖励名字1
//                         GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                         Debug.Log("PDM.data.root.rewardList[i].equipList[c].metaId -=====" + PDM.data.root.rewardList[i].equipList[c].metaId);
//                         pname1.GetComponent<Text>().text = "[" + GameMainData.instance.Zhuangbei[PDM.data.root.rewardList[i].equipList[c].metaId].equip_quality + "]" + GameMainData.instance.Zhuangbei[PDM.data.root.rewardList[i].equipList[c].metaId].equip_name;  
//                         //奖励名字2
//                         GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                         pname2.GetComponent<Text>().text = "装备"; 
//                         //数量
//                         GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                         pnum.GetComponent<Text>().text = "数量：1";
//                         prizeObj.transform.SetParent(prizeContent.transform, false);

//                         GameMainData.instance.getEquip(PDM.data.root.rewardList[i].equipList[c].equipId, PDM.data.root.rewardList[i].equipList[c].metaId);
//                     }

//                 }


//                 //武功碎片
//                 if (PDM.data.root.rewardList[i].bookSPList != null)
//                 {
//                     isextraGetprize = true;

//                     for (int d = 0; d < PDM.data.root.rewardList[i].bookSPList.Count; d++)
//                     {
//                         GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                         //奖励名字1
//                         GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                         pname1.GetComponent<Text>().text = GameMainData.instance.wg_[PDM.data.root.rewardList[i].bookSPList[d].bookSPId.Split(GameMainData.instance.maohao)[0]].wg_name + "(碎片)";  
//                         //奖励名字2
//                         GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                         pname2.GetComponent<Text>().text = "武功碎片"; 
//                         //数量
//                         GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                         pnum.GetComponent<Text>().text = "数量：" + PDM.data.root.rewardList[i].bookSPList[d].num;
//                         prizeObj.transform.SetParent(prizeContent.transform, false);

//                         GameMainData.instance.getWugongSp(PDM.data.root.rewardList[i].bookSPList[d].bookSPId.Split(GameMainData.instance.maohao)[0], PDM.data.root.rewardList[i].bookSPList[d].num);
//                     }

//                 }

//                 //心得 （xd1攻击心法  xd2防御心法 xd3内功心法
//                 if (PDM.data.root.rewardList[i].rewardxinDeList != null)
//                 {
//                     isextraGetprize = true;

//                     for (int e = 0; e < PDM.data.root.rewardList[i].rewardxinDeList.Count; e++)
//                     {
//                         GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                         string xdType = "";
//                         if (PDM.data.root.rewardList[i].rewardxinDeList[e].xinDeId == "xd1")
//                         {
//                             xdType = "攻击心法";
//                         }
//                         else if (PDM.data.root.rewardList[i].rewardxinDeList[e].xinDeId == "xd2")
//                         {
//                             xdType = "防御心法";
//                         }
//                         else
//                         {
//                             xdType = "内功心法";
//                         }
//                         //奖励名字1
//                         GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                         pname1.GetComponent<Text>().text = xdType;
//                         //奖励名字2
//                         GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                         pname2.GetComponent<Text>().text = "心法";
//                         //数量
//                         GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                         pnum.GetComponent<Text>().text = "数量：" + PDM.data.root.rewardList[i].rewardxinDeList[e].num;
//                         prizeObj.transform.SetParent(prizeContent.transform, false);

//                         GameMainData.instance.getWugongXd(PDM.data.root.rewardList[i].rewardxinDeList[e].xinDeId, xdType, 1);
//                     }

//                 }

//                 //装备碎片
//                 if (PDM.data.root.rewardList[i].equipSPList != null)
//                 {
//                     isextraGetprize = true;

//                     for (int f = 0; f < PDM.data.root.rewardList[i].equipSPList.Count; f++)
//                     {
//                         GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                         //奖励名字1
//                         GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                         pname1.GetComponent<Text>().text = "[" + GameMainData.instance.Zhuangbei[PDM.data.root.rewardList[i].equipSPList[f].equipSPId.Split(GameMainData.instance.maohao)[0]].equip_quality + "]" + GameMainData.instance.Zhuangbei[PDM.data.root.rewardList[i].equipSPList[f].equipSPId.Split(GameMainData.instance.maohao)[0]].equip_name + "(碎片)"; 
//                         //奖励名字2
//                         GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                         pname2.GetComponent<Text>().text = "装备碎片"; 
//                         //数量
//                         GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                         pnum.GetComponent<Text>().text = "数量：" + PDM.data.root.rewardList[i].equipSPList[f].num;
//                         prizeObj.transform.SetParent(prizeContent.transform, false);

//                         GameMainData.instance.getEquipSp(PDM.data.root.rewardList[i].equipSPList[f].equipSPId.Split(GameMainData.instance.maohao)[0], PDM.data.root.rewardList[i].equipSPList[f].num);
//                     }

//                 } 

//                 //弟子魂魄
//                 if (PDM.data.root.rewardList[i].heroSoulList != null)
//                 {
//                     isextraGetprize = true;

//                     for (int j = 0; j < PDM.data.root.rewardList[i].heroSoulList.Count; j++)
//                     {
//                         GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                         //奖励名字1
//                         GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                         pname1.GetComponent<Text>().text = "[" + GameMainData.instance.pl_[PDM.data.root.rewardList[i].heroSoulList[j].soulId.Split(GameMainData.instance.maohao)[0]].player_quality + "]" + GameMainData.instance.pl_[PDM.data.root.rewardList[i].heroSoulList[j].soulId.Split(GameMainData.instance.maohao)[0]].player_name + "(魂魄)"; 
//                         //奖励名字2
//                         GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                         pname2.GetComponent<Text>().text = "魂魄"; 
//                         //数量
//                         GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                         pnum.GetComponent<Text>().text = "数量：" + PDM.data.root.rewardList[i].heroSoulList[j].num;
//                         prizeObj.transform.SetParent(prizeContent.transform, false);

//                         GameMainData.instance.getDiziSoul(PDM.data.root.rewardList[i].heroSoulList[j].soulId.Split(GameMainData.instance.maohao)[0], PDM.data.root.rewardList[i].heroSoulList[j].num);
//                     }

//                 } 


//                 //弟子
//                 if (PDM.data.root.rewardList[i].heroList != null)
//                 {
//                     isextraGetprize = true;

//                     for (int j = 0; j < PDM.data.root.rewardList[i].heroList.Count; j++)
//                     {
//                         GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                         //奖励名字1
//                         GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                         if (GameMainData.instance.pl_.ContainsKey(PDM.data.root.rewardList[i].heroList[j].heroId))
//                         {
//                             pname1.GetComponent<Text>().text = "[" + GameMainData.instance.pl_[PDM.data.root.rewardList[i].heroList[j].heroId].player_quality + "]" + GameMainData.instance.pl_[PDM.data.root.rewardList[i].heroList[j].heroId].player_name; 
//                         }

//                         //奖励名字2
//                         GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                         pname2.GetComponent<Text>().text = "弟子"; 
//                         GameMainData.instance.getDizi(PDM.data.root.rewardList[i].heroList[j].heroId);
//                         //数量
//                         GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                         pnum.GetComponent<Text>().text = "数量：1";
//                         prizeObj.transform.SetParent(prizeContent.transform, false);
//                     }
//                 } 
//             }
//             if (savePropId.Count > 0)
//             {
 
//                 for (int k = 0; k < savePropId.Count; k++)
//                 {
//                     GameObject prizeObj = Instantiate(prizeDetPrefab, prizeDetPrefab.transform.position, Quaternion.identity)as GameObject;
//                     //奖励名字1
//                     GameObject pname1 = prizeObj.transform.Find("name").gameObject;
//                     pname1.GetComponent<Text>().text = GameMainData.instance.savePack[savePropId[k].ToString()].prop_name;
//                     //奖励名字2
//                     GameObject pname2 = prizeObj.transform.Find("nameMap/name").gameObject;
//                     pname2.GetComponent<Text>().text = "道具";
//                     //数量
//                     GameObject pnum = prizeObj.transform.Find("num").gameObject;
//                     pnum.GetComponent<Text>().text = "数量：" + SaveRepetitionPropPrize[savePropId[k].ToString()];
//                     prizeObj.transform.SetParent(prizeContent.transform, false);
//                     GameMainData.instance.gainProp(savePropId[k].ToString(), SaveRepetitionPropPrize[savePropId[k].ToString()]);

//                 }
//                 savePropId.Clear();
//                 SaveRepetitionPropPrize.Clear();
//             }

			
//             if (yl > 0)
//             {
//                 isGetprize = true;
//                 isGetNum++;
//                 //数量
//                 GameObject pnum = prizeSliver.transform.Find("num").gameObject;
//                 pnum.GetComponent<Text>().text = "数量：" + yl;
//                 prizeSliver.SetActive(true);
//                 prizeSliver.transform.SetSiblingIndex(0);

//             }
			
//             if (jyz > 0)
//             {
//                 isGetprize = true;
//                 isGetNum++;
//                 //数量
//                 GameObject pnum = prizeGold.transform.Find("num").gameObject;
//                 pnum.GetComponent<Text>().text = "数量：" + jyz;
//                 prizeGold.SetActive(true);
//                 prizeGold.transform.SetSiblingIndex(0);

			 
//             }
//             if (yb > 0)
//             {
//                 isGetprize = true;
//                 isGetNum++;
				 
//                 //数量
//                 GameObject pnum = prizeyb.transform.Find("num").gameObject;
//                 pnum.GetComponent<Text>().text = "数量：" + yb;
//                 prizeyb.SetActive(true);
//                 prizeyb.transform.SetSiblingIndex(0);

//             }

//             if (isGetprize == true)
//             {
//                 head2.SetActive(true);
//                 head2.transform.SetSiblingIndex(0);
//                 if (isextraGetprize == true)
//                 {
//                     head3.SetActive(true);
//                     head3.transform.SetSiblingIndex(isGetNum + 1);
//                 }
//             }
//             else
//             {
//                 head2.SetActive(true);
//                 head2.transform.SetSiblingIndex(0);
//             }
			 

//         }


//     }





 
//     public void ClosePage()
//     {
//         Destroy(prizeTipObj.gameObject);
//         isGetprize = false;
//         isextraGetprize = false;
//         isGetNum = 0;
        

//         schoolUpLenvel(); //是否升级
//     }


//     //播放战斗动画
//     public void PlayFightAnimation()
//     {
//         fightAnimation.transform.SetAsLastSibling();
//         fightAnimation.SetActive(true);

//     }
//     //关闭战斗动画
//     public void StopFightAnimation()
//     {
//         fightAnimation.SetActive(false);

//     }

//     //一整个的战斗流程
//     //	public void EntireFightAnimation(){
//     //		PlayFightAnimation ();
//     //		Invoke ("StopFightAnimation",2.5f);
//     //
//     //
//     //	}


//     [CSharpCallLua]
// 	public delegate string getNowQieCuo();
//     //打开结算界面
//     public void OpenSettlement(string mold)
//     {
//         Debug.Log("OpenSettlement方法中的mold=" + mold);
//         if (mold.Equals("lunjian"))
//         {
//             getGain.SetActive(false);
//             lunjian_esc.SetActive(true);
//             //				lunjian_esc.transform.SetSiblingIndex (2);
//             xuezhan_esc.SetActive(false);
//             int di_ = settlement.transform.parent.childCount;
//             settlement.transform.SetSiblingIndex(di_ - 2);
//             settlement.SetActive(true);
//             -- print("di_==" + di_);
//         }
//         else
//         {
//             settlement.SetActive(true);
//         }

//         int xing_get = 0;
//         if (!mold.Equals("xingxia"))
//         {

//             Debug.Log("(PDM.data.root.comBatResultData[0].mold =  " + (PDM.data.root.comBatResultData[0].mold));
//             switch (PDM.data.root.comBatResultData[0].mold)
//             {
//                 case"32":
//                     settlement.transform.Find("result").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("xibai");
//                     settlement.transform.Find("result_beijing").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shibaiqizi");
//                     settlement.transform.Find("result_di").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shibaidi");
//                     settlement.transform.Find("jiesuan/xing1").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     settlement.transform.Find("jiesuan/xing2").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     settlement.transform.Find("jiesuan/xing3").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     getGain.transform.Find("Text").GetComponent<Text>().text = "确定";
//                     getGain.GetComponent<Button>().onClick.RemoveAllListeners();
//                     getGain.GetComponent<Button>().onClick.AddListener(delegate
//                         {
//                             settlement.SetActive(false);
//                         });
//                     break;
//                 case"22":
//                     settlement.transform.Find("result").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shibai");
//                     settlement.transform.Find("result_beijing").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shibaiqizi");
//                     settlement.transform.Find("result_di").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shibaidi");
//                     settlement.transform.Find("jiesuan/xing1").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     settlement.transform.Find("jiesuan/xing2").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     settlement.transform.Find("jiesuan/xing3").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     getGain.transform.Find("Text").GetComponent<Text>().text = "确定";
//                     getGain.GetComponent<Button>().onClick.RemoveAllListeners();
//                     getGain.GetComponent<Button>().onClick.AddListener(delegate
//                         {
//                             settlement.SetActive(false);
//                         });
//                     break;
//                 case"12":
//                     Debug.Log("惨败了？");
//                     settlement.transform.Find("result").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("canbai");
//                     settlement.transform.Find("result_beijing").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shibaiqizi");
//                     settlement.transform.Find("result_di").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shibaidi");
//                     settlement.transform.Find("jiesuan/xing1").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     settlement.transform.Find("jiesuan/xing2").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     settlement.transform.Find("jiesuan/xing3").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     getGain.transform.Find("Text").GetComponent<Text>().text = "确定";
//                     getGain.GetComponent<Button>().onClick.RemoveAllListeners();
//                     getGain.GetComponent<Button>().onClick.AddListener(delegate
//                         {
//                             settlement.SetActive(false);
//                         });
//                     break;
//                 case"31":
//                     settlement.transform.Find("result").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("xiansheng");
//                     settlement.transform.Find("result_beijing").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shengliqizi");
//                     settlement.transform.Find("result_di").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shenglidi");
//                     settlement.transform.Find("jiesuan/xing1").gameObject.transform.Find("xing").gameObject.SetActive(true);
//                     settlement.transform.Find("jiesuan/xing2").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     settlement.transform.Find("jiesuan/xing3").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     xing_get = 1;
//                     getGain.transform.Find("Text").GetComponent<Text>().text = "查看奖励";
//                     getGain.GetComponent<Button>().onClick.RemoveAllListeners();
//                     getGain.GetComponent<Button>().onClick.AddListener(delegate
//                         {
//                             escSettlement();
//                         });
//                     break;
//                 case"21":
//                     settlement.transform.Find("result").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shengli");
//                     settlement.transform.Find("result_beijing").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shengliqizi");
//                     settlement.transform.Find("result_di").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shenglidi");
//                     settlement.transform.Find("jiesuan/xing1").gameObject.transform.Find("xing").gameObject.SetActive(true);
//                     settlement.transform.Find("jiesuan/xing2").gameObject.transform.Find("xing").gameObject.SetActive(true);
//                     settlement.transform.Find("jiesuan/xing3").gameObject.transform.Find("xing").gameObject.SetActive(false);
//                     xing_get = 2;
//                     getGain.transform.Find("Text").GetComponent<Text>().text = "查看奖励";
//                     getGain.GetComponent<Button>().onClick.RemoveAllListeners();
//                     getGain.GetComponent<Button>().onClick.AddListener(delegate
//                         {
//                             escSettlement();
//                         });
//                     break;
//                 case"11":
//                     settlement.transform.Find("result").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("dasheng");
//                     settlement.transform.Find("result_beijing").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shengliqizi");
//                     settlement.transform.Find("result_di").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shenglidi");
//                     settlement.transform.Find("jiesuan/xing1").gameObject.transform.Find("xing").gameObject.SetActive(true);
//                     settlement.transform.Find("jiesuan/xing2").gameObject.transform.Find("xing").gameObject.SetActive(true);
//                     settlement.transform.Find("jiesuan/xing3").gameObject.transform.Find("xing").gameObject.SetActive(true);
//                     xing_get = 3;
//                     getGain.transform.Find("Text").GetComponent<Text>().text = "查看奖励";
//                     getGain.GetComponent<Button>().onClick.RemoveAllListeners();
//                     getGain.GetComponent<Button>().onClick.AddListener(delegate
//                         {
//                             escSettlement();
//                         });
//                     if (mold.Equals("mingshan"))
//                     {
//                         if (B_mingShan.instance.minshan_id.Equals("1"))
//                         {
//                             if (GameMainData.instance.mssc_[B_mingShan.instance.minshan_id].minshan_jindu == 3)
//                             {
//                                 GameMainData.instance.mssc_[B_mingShan.instance.minshan_id].minshan_get3xing = 1;
//                             }
//                         }
//                         else
//                         {
//                             if (GameMainData.instance.mssc_[B_mingShan.instance.minshan_id].minshan_jindu == 5)
//                             {
//                                 GameMainData.instance.mssc_[B_mingShan.instance.minshan_id].minshan_get3xing = 1;
//                             }
//                         }
//                     }
//                     break;
//             }

//             settlement.transform.Find("jiesuan/weiwang").gameObject.GetComponent<Text>().text = PDM.data.root.comBatResultData[0].prestige + "";
//             if (PDM.data.root.rewardList != null)
//             {
//                 settlement.transform.Find("jiesuan/silver").gameObject.GetComponent<Text>().text = PDM.data.root.rewardList[0].sliver + "";
//             }
//             else
//             {
//                 settlement.transform.Find("jiesuan/silver").gameObject.GetComponent<Text>().text = "0";
//             }
//         }
//         else
//         {
//             settlement.transform.Find("result").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shengli");
//             settlement.transform.Find("result_beijing").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shengliqizi");
//             settlement.transform.Find("result_di").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("shenglidi");
//         }

//         if (mold.Equals("xuezhan"))
//         {
//             settlement.transform.Find("xuezhan_jiesuan").gameObject.SetActive(true);
//             settlement.transform.Find("xuezhan_jiesuan").gameObject.transform.Find("xing_num").GetComponent<Text>().text = xing_get + "";
//             settlement.transform.Find("xuezhan_jiesuan").gameObject.transform.Find("xing_beishu").GetComponent<Text>().text = B_bloodbattle.instance.degree + "";
//             settlement.transform.Find("xuezhan_jiesuan").gameObject.transform.Find("sx_up").GetComponent<Text>().text = B_bloodbattle.instance.until2GetAddition + "";
//             settlement.transform.Find("xuezhan_jiesuan").gameObject.transform.Find("gain_guan").GetComponent<Text>().text = B_bloodbattle.instance.until2GetReward + "";
//             getGain.SetActive(false);
//             xuezhan_esc.SetActive(true);
//             lunjian_esc.SetActive(false);
//             xingxia_esc.SetActive(false);
//             replay.SetActive(true);
//             settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//             settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//             settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//         }
//         else
//         {
//             settlement.transform.Find("xuezhan_jiesuan").gameObject.SetActive(false);
//             if (mold.Equals("lunjian"))
//             {
//                 getGain.SetActive(false);
//                 lunjian_esc.SetActive(true);
//                 //				lunjian_esc.transform.SetSiblingIndex (2);  
//                 xuezhan_esc.SetActive(false);
//                 xingxia_esc.SetActive(false);
//                 replay.SetActive(true);
//                 settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                 settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                 settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//             }
//             else if (mold.Equals("xingxia"))
//             {
//                 if (B_xingXia.instance.zongxiaohaoTime < 60)
//                 {
//                     settlement.transform.Find("xingxia_jiesuan").transform.Find("xingxia_time").GetComponent<Text>().text = "0小时0分钟" + B_xingXia.instance.zongxiaohaoTime + "秒";
//                 }
//                 if (B_xingXia.instance.zongxiaohaoTime >= 60 && B_xingXia.instance.zongxiaohaoTime < 3600)
//                 {
//                     settlement.transform.Find("xingxia_jiesuan").transform.Find("xingxia_time").GetComponent<Text>().text = "0小时" + (int)(B_xingXia.instance.zongxiaohaoTime / 60) + "分钟" + (B_xingXia.instance.zongxiaohaoTime % 60) + "秒";
//                 }
//                 if (B_xingXia.instance.zongxiaohaoTime >= 3600)
//                 {
//                     settlement.transform.Find("xingxia_jiesuan").transform.Find("xingxia_time").GetComponent<Text>().text = (int)(B_xingXia.instance.zongxiaohaoTime / 3600) + "小时" + (int)((B_xingXia.instance.zongxiaohaoTime % 3600) / 60) + "分钟" + ((B_xingXia.instance.zongxiaohaoTime % 3600) / 60) + "秒";
//                 }
//                 getGain.SetActive(false);
//                 lunjian_esc.SetActive(false);
//                 xingxia_esc.SetActive(true);
//                 replay.SetActive(false);
//                 settlement.transform.Find("jiesuan").gameObject.SetActive(false);
//                 settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(true);
//                 settlement.transform.Find("hero_pos").gameObject.SetActive(false);
//                 xuezhan_esc.SetActive(false);
//             }
//             else
//             {
//                 getGain.SetActive(true);
//                 lunjian_esc.SetActive(false);
//                 xuezhan_esc.SetActive(false);
//                 xingxia_esc.SetActive(false);
//                 replay.SetActive(true);
//                 settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                 settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                 settlement.transform.Find("hero_pos").gameObject.SetActive(true);

//             }
//             if (mold.Equals("10minshan"))
//             {
//                 replay.GetComponent<Button>().enabled = false;
//                 replay.GetComponent<Image>().sprite = ResourceManager.GetSprite("tongyonganniu1");
//             }
//             else
//             {
//                 replay.GetComponent<Button>().enabled = true;
//                 replay.GetComponent<Image>().sprite = ResourceManager.GetSprite("tongyonganniu2");
//             }
//             if (mold.Equals("jianghu"))
//             {
//                 TextAsset text_ = Resources.Load("a_jianghu2.lua") as TextAsset;
//                 LuaEnv luaEnv = LuaBehaviour.luaEnv;
//                 luaEnv.DoString(text_.text, "LuaBehaviour", null);  
//                 //LuaTable meta = luaEnv.NewTable();
//                 //meta.Set("__index", luaEnv.Global);
//                 getNowQieCuo getNowNpcQieCuo = luaEnv.Global.Get<getNowQieCuo>("getNowNpcQieCuo");
//                 getNowQieCuo getNowNpcJueDou = luaEnv.Global.Get<getNowQieCuo>("getNowNpcJueDou");
//                 getNowQieCuo getNowNpcFighttype = luaEnv.Global.Get<getNowQieCuo>("getNowNpcFighttype"); 
//                 if (getNowNpcFighttype().Equals("1"))
//                 {
//                     if (getNowNpcQieCuo().Equals("1"))
//                     {
//                         getGain.SetActive(false);
//                         lunjian_esc.SetActive(true);
//                         xuezhan_esc.SetActive(false);
//                         xingxia_esc.SetActive(false);
//                         replay.SetActive(true);
//                         settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                         settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                         settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                     }
// 					else if (getNowNpcQieCuo().Split('|')[0].Equals("2"))
//                     {
//                         getGain.SetActive(false);
//                         lunjian_esc.SetActive(true);
//                         xuezhan_esc.SetActive(false);
//                         xingxia_esc.SetActive(false);
//                         replay.SetActive(true);
//                         settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                         settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                         settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                     }
//                     else
//                     {
//                         if (getNowNpcQieCuo().Split('|')[0].Equals("0"))
//                         {
//                             getGain.SetActive(false);
//                             lunjian_esc.SetActive(true);
//                             xuezhan_esc.SetActive(false);
//                             xingxia_esc.SetActive(false);
//                             replay.SetActive(true);
//                             settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                             settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                             settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                         }
//                         else
//                         {
//                             if (getNowNpcQieCuo().Split('|')[1].Split('*')[0].Equals("2"))
//                             {
//                                 getGain.SetActive(false);
//                                 lunjian_esc.SetActive(true);
//                                 xuezhan_esc.SetActive(false);
//                                 xingxia_esc.SetActive(false);
//                                 replay.SetActive(true);
//                                 settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                                 settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                                 settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                             }
//                             else
//                             {
//                                 getGain.SetActive(true);
//                                 lunjian_esc.SetActive(false);
//                                 xuezhan_esc.SetActive(false);
//                                 xingxia_esc.SetActive(false);
//                                 replay.SetActive(true);
//                                 settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                                 settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                                 settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                             }
//                         }
//                     }
//                 }
//                 else
//                 {
//                     if (getNowNpcJueDou().Equals("1"))
//                     {
//                         getGain.SetActive(false);
//                         lunjian_esc.SetActive(true);
//                         xuezhan_esc.SetActive(false);
//                         xingxia_esc.SetActive(false);
//                         replay.SetActive(true);
//                         settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                         settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                         settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                     }
//                     else if (getNowNpcJueDou().Equals("2"))
//                     {
//                         getGain.SetActive(false);
//                         lunjian_esc.SetActive(true);
//                         xuezhan_esc.SetActive(false);
//                         xingxia_esc.SetActive(false);
//                         replay.SetActive(true);
//                         settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                         settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                         settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                     }
//                     else if (getNowNpcJueDou().Split('|')[0].Equals("0"))
//                     {
//                         getGain.SetActive(false);
//                         lunjian_esc.SetActive(true);
//                         xuezhan_esc.SetActive(false);
//                         xingxia_esc.SetActive(false);
//                         replay.SetActive(true);
//                         settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                         settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                         settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                     }
//                     else
//                     {
//                         if (getNowNpcJueDou().Split('|')[1].Split('*')[0].Equals("2"))
//                         {
//                             getGain.SetActive(false);
//                             lunjian_esc.SetActive(true);
//                             xuezhan_esc.SetActive(false);
//                             xingxia_esc.SetActive(false);
//                             replay.SetActive(true);
//                             settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                             settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                             settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                         }
//                         else
//                         {
//                             getGain.SetActive(true);
//                             lunjian_esc.SetActive(false);
//                             xuezhan_esc.SetActive(false);
//                             xingxia_esc.SetActive(false);
//                             replay.SetActive(true);
//                             settlement.transform.Find("jiesuan").gameObject.SetActive(true);
//                             settlement.transform.Find("xingxia_jiesuan").gameObject.SetActive(false);
//                             settlement.transform.Find("hero_pos").gameObject.SetActive(true);
//                         }
//                     }
//                 }
//             }
//         }
//         for (int i = 0; i < heropos.transform.childCount; i++)
//         {
//             Destroy(heropos.transform.GetChild(i).gameObject);
//         }
//         if (!mold.Equals("xingxia"))
//         {
//             if (PDM.data.root.heroUpgradeList != null && PDM.data.root.heroUpgradeList.Count > 0)
//             {
//                 for (int i = 0; i < PDM.data.root.heroUpgradeList.Count; i++)
//                 {
//                     Temp_hero = Instantiate(settlement_hero, settlement_hero.transform.position, Quaternion.identity)as GameObject;
//                     Temp_hero.transform.SetParent(heropos.transform, false);
//                     Temp_hero.transform.Find("name").GetComponent<Text>().text = GameMainData.instance.pl_[PDM.data.root.heroUpgradeList[i].heroId].player_name;
//                     Temp_hero.transform.Find("exp").GetComponent<Text>().text = PDM.data.root.heroUpgradeList[i].exp + "";
//                     if (!GameMainData.instance.getMyDiziById(PDM.data.root.heroUpgradeList[i].heroId).myplayer_level.Equals(PDM.data.root.heroUpgradeList[i].level))
//                     {
//                         Temp_hero.transform.Find("levelup").gameObject.SetActive(true);
//                         Temp_hero.transform.Find("lv").gameObject.SetActive(true);
//                         Temp_hero.transform.Find("level_new").gameObject.SetActive(true);
//                         Temp_hero.transform.Find("level").GetComponent<Text>().text = GameMainData.instance.getMyDiziById(PDM.data.root.heroUpgradeList[i].heroId).myplayer_level + "";
//                         Temp_hero.transform.Find("level_new").GetComponent<Text>().text = PDM.data.root.heroUpgradeList[i].level + "";
//                         GameMainData.instance.getMyDiziById(PDM.data.root.heroUpgradeList[i].heroId).myplayer_level = PDM.data.root.heroUpgradeList[i].level;
//                         Serverdata_UI.instance.UpdateHeroGFXN("fight");
//                     }
//                     else
//                     {
//                         Temp_hero.transform.Find("levelup").gameObject.SetActive(false);
//                         Temp_hero.transform.Find("lv").gameObject.SetActive(false);
//                         Temp_hero.transform.Find("level_new").gameObject.SetActive(false);
//                         Temp_hero.transform.Find("level").GetComponent<Text>().text = GameMainData.instance.getMyDiziById(PDM.data.root.heroUpgradeList[i].heroId).myplayer_level + "";
//                     }
//                 }
//             }
//         }
//         A_FightAnimation.instance.FightingPage.transform.SetAsFirstSibling();
//         settlement.transform.SetAsLastSibling();
//         CancelInvoke("ReplayEnable");
//         replay.GetComponent<Button>().interactable = false;
//         Invoke("ReplayEnable", 1.5f);
//     }

//     //重播按钮启用
//     void ReplayEnable()
//     {
//         replay.GetComponent<Button>().interactable = true;

//     }



//     public void escSettlement()
//     {
//         settlement.SetActive(false);
//         PrizeTip();
//     }

//     string[] tyzr_q = new string[6];
//     string[] tyzr_yang = new string[7];
//     //通用阵容
//     GameObject yang_zr;
//     GameObject toplayer_zr;
//     GameObject[] zr_posq = new GameObject[6];
//     GameObject person_ui;
//     GameObject gezi1ty_prefab;
//     GameObject tongyongzrObj;
//     GameObject esc_tyzr;
//     GameObject esc_typerson;
//     GameObject zhezhao;
//     GameObject dizizr_B;
//     GameObject yangzr_B;

//     public void tyzr_init()
//     {
//         tongyongzrObj = Instantiate(tongyongzr, tongyongzr.transform.position, Quaternion.identity)as GameObject;
//         tongyongzrObj.transform.SetParent(canvas.transform, false);
//         tongyongzr.transform.SetAsLastSibling();
//         yang_zr = tongyongzrObj.transform.Find("yang_zr").gameObject;
//         toplayer_zr = tongyongzrObj.transform.Find("toPlay_zr").gameObject;
//         zr_posq[0] = tongyongzrObj.transform.Find("zr_pos/q_gezi1pos1").gameObject;
//         zr_posq[1] = tongyongzrObj.transform.Find("zr_pos/q_gezi1pos2").gameObject;
//         zr_posq[2] = tongyongzrObj.transform.Find("zr_pos/q_gezi1pos3").gameObject;
//         zr_posq[3] = tongyongzrObj.transform.Find("zr_pos/q_gezi1pos4").gameObject;
//         zr_posq[4] = tongyongzrObj.transform.Find("zr_pos/q_gezi1pos5").gameObject;
//         zr_posq[5] = tongyongzrObj.transform.Find("zr_pos/h_gezi1pos1").gameObject;
//         person_ui = tongyongzrObj.transform.Find("person_ui").gameObject;
//         esc_tyzr = tongyongzrObj.transform.Find("esc_tyzr").gameObject;
//         esc_typerson = person_ui.transform.Find("esc_typerson").gameObject;
//         zhezhao = tongyongzrObj.transform.Find("zhezhao").gameObject;
//         dizizr_B = tongyongzrObj.transform.Find("dizizr_B").gameObject;
//         yangzr_B = tongyongzrObj.transform.Find("yangzr_B").gameObject;
//         gezi1ty_prefab = Resources.Load<GameObject>("Prefabs/Modules/B_gezi1ty_prefab").gameObject;
//         person_ui.SetActive(false);
//         yang_zr.SetActive(false);
//         tongyongzrObj.SetActive(true);
//         tyzr_q[0] = PDM.data.root.beenObservedGoBattleData[0].mateId;
//         tyzr_q[1] = PDM.data.root.beenObservedGoBattleData[1].mateId;
//         tyzr_q[2] = PDM.data.root.beenObservedGoBattleData[2].mateId;
//         tyzr_q[3] = PDM.data.root.beenObservedGoBattleData[3].mateId;
//         tyzr_q[4] = PDM.data.root.beenObservedGoBattleData[4].mateId;
//         tyzr_q[5] = PDM.data.root.beenObservedGoBattleData[5].mateId;
//         for (int y = 0; y < 7; y++)
//         {
//             tyzr_yang[y] = PDM.data.root.beenObservedSunBattleData[y].mateId;
//         }
//         esc_tyzr.GetComponent<Button>().onClick.RemoveAllListeners();
//         esc_tyzr.GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 esc_tyzhenrong();
//             });
//         esc_typerson.GetComponent<Button>().onClick.RemoveAllListeners();
//         esc_typerson.GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 esc_tyzrms();
//             });
//         zhezhao.GetComponent<Button>().onClick.RemoveAllListeners();
//         zhezhao.GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 esc_tyzhenrong();
//             });
//         dizizr_B.GetComponent<Button>().onClick.RemoveAllListeners();
//         dizizr_B.GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 zrtoPlay_B();
//             });
//         yangzr_B.GetComponent<Button>().onClick.RemoveAllListeners();
//         yangzr_B.GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 zrty_yangB();
//             });
//         zrty_init();
//     }

//     public void zrty_init()
//     {
//         GameObject zrplayer_dad = toplayer_zr.transform.Find("zr_parent").gameObject;

//         for (int i = 0; i < zrplayer_dad.transform.childCount; i++)
//         {
//             Destroy(zrplayer_dad.transform.GetChild(i).gameObject);
//         }
//         if (!tyzr_q[0].Equals(""))
//         {
//             GameObject player_cTemp = Instantiate(gezi1ty_prefab, zr_posq[0].transform.position, Quaternion.identity)as GameObject;
//             player_cTemp.gameObject.transform.SetParent(zrplayer_dad.gameObject.transform, false);
//             player_cTemp.gameObject.transform.position = zr_posq[0].transform.position;
//             player_cTemp.transform.Find("Text").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[tyzr_q[0]].player_name;
//             for (int a = 0; a < PDM.data.root.beenObservedHerosData.Count; a++)
//             {
//                 if (PDM.data.root.beenObservedHerosData[a].iD.Equals(tyzr_q[0]))
//                 {
//                     player_cTemp.transform.Find("level").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].level + "";
//                     if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(0))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "超常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(1))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "正常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(2))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "不佳";
//                     }
//                 }
//             }
//             player_cTemp.GetComponentInChildren<tyzrbutton>().tyzrbutton_id = tyzr_q[0];
//             player_cTemp.name = tyzr_q[0];
//         }
//         if (!tyzr_q[1].Equals(""))
//         {
//             GameObject player_cTemp = Instantiate(gezi1ty_prefab, zr_posq[1].transform.position, Quaternion.identity)as GameObject;
//             player_cTemp.gameObject.transform.SetParent(zrplayer_dad.gameObject.transform, false);
//             player_cTemp.gameObject.transform.position = zr_posq[1].transform.position;
//             player_cTemp.transform.Find("Text").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[tyzr_q[1]].player_name;
//             for (int a = 0; a < PDM.data.root.beenObservedHerosData.Count; a++)
//             {
//                 if (PDM.data.root.beenObservedHerosData[a].iD.Equals(tyzr_q[1]))
//                 {
//                     player_cTemp.transform.Find("level").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].level + "";
//                     if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(0))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "超常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(1))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "正常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(2))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "不佳";
//                     }
//                 }
//             }
//             player_cTemp.GetComponentInChildren<tyzrbutton>().tyzrbutton_id = tyzr_q[1];
//             player_cTemp.name = tyzr_q[1];
//         }
//         if (!tyzr_q[2].Equals(""))
//         {
//             GameObject player_cTemp = Instantiate(gezi1ty_prefab, zr_posq[2].transform.position, Quaternion.identity)as GameObject;
//             player_cTemp.gameObject.transform.SetParent(zrplayer_dad.gameObject.transform, false);
//             player_cTemp.gameObject.transform.position = zr_posq[2].transform.position;
//             player_cTemp.transform.Find("Text").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[tyzr_q[2]].player_name;
//             for (int a = 0; a < PDM.data.root.beenObservedHerosData.Count; a++)
//             {
//                 if (PDM.data.root.beenObservedHerosData[a].iD.Equals(tyzr_q[2]))
//                 {
//                     player_cTemp.transform.Find("level").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].level + "";
//                     if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(0))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "超常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(1))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "正常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(2))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "不佳";
//                     }
//                 }
//             }
//             player_cTemp.GetComponentInChildren<tyzrbutton>().tyzrbutton_id = tyzr_q[2];
//             player_cTemp.name = tyzr_q[2];
//         }
//         if (!tyzr_q[3].Equals(""))
//         {
//             GameObject player_cTemp = Instantiate(gezi1ty_prefab, zr_posq[3].transform.position, Quaternion.identity)as GameObject;
//             player_cTemp.gameObject.transform.SetParent(zrplayer_dad.gameObject.transform, false);
//             player_cTemp.gameObject.transform.position = zr_posq[3].transform.position;
//             player_cTemp.transform.Find("Text").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[tyzr_q[3]].player_name;
//             for (int a = 0; a < PDM.data.root.beenObservedHerosData.Count; a++)
//             {
//                 if (PDM.data.root.beenObservedHerosData[a].iD.Equals(tyzr_q[3]))
//                 {
//                     player_cTemp.transform.Find("level").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].level + "";
//                     if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(0))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "超常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(1))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "正常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(2))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "不佳";
//                     }
//                 }
//             }
//             player_cTemp.GetComponentInChildren<tyzrbutton>().tyzrbutton_id = tyzr_q[3];
//             player_cTemp.name = tyzr_q[3];
//         }


//         if (!tyzr_q[4].Equals(""))
//         {
//             GameObject player_cTemp = Instantiate(gezi1ty_prefab, zr_posq[4].transform.position, Quaternion.identity)as GameObject;
//             player_cTemp.gameObject.transform.SetParent(zrplayer_dad.gameObject.transform, false);
//             player_cTemp.gameObject.transform.position = zr_posq[4].transform.position;
//             player_cTemp.transform.Find("Text").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[tyzr_q[4]].player_name;
//             for (int a = 0; a < PDM.data.root.beenObservedHerosData.Count; a++)
//             {
//                 if (PDM.data.root.beenObservedHerosData[a].iD.Equals(tyzr_q[0]))
//                 {
//                     player_cTemp.transform.Find("level").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].level + "";
//                     if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(0))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "超常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(1))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "正常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(2))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "不佳";
//                     }
//                 }
//             }
//             player_cTemp.GetComponentInChildren<tyzrbutton>().tyzrbutton_id = tyzr_q[4];
//             player_cTemp.name = tyzr_q[4];
//         }
//         if (!tyzr_q[5].Equals(""))
//         {
//             GameObject player_cTemp = Instantiate(gezi1ty_prefab, zr_posq[5].transform.position, Quaternion.identity)as GameObject;
//             player_cTemp.gameObject.transform.SetParent(zrplayer_dad.gameObject.transform, false);
//             player_cTemp.gameObject.transform.position = zr_posq[5].transform.position;
//             player_cTemp.transform.Find("Text").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[tyzr_q[5]].player_name;
//             for (int a = 0; a < PDM.data.root.beenObservedHerosData.Count; a++)
//             {
//                 if (PDM.data.root.beenObservedHerosData[a].iD.Equals(tyzr_q[5]))
//                 {
//                     player_cTemp.transform.Find("level").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].level + "";
//                     if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(0))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "超常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(1))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "正常";
//                     }
//                     else if (PDM.data.root.beenObservedHerosData[a].heroState.Equals(2))
//                     {
//                         player_cTemp.transform.Find("zhuangtai").gameObject.GetComponent<Text>().text = "不佳";
//                     }
//                 }
//             }
//             player_cTemp.GetComponentInChildren<tyzrbutton>().tyzrbutton_id = tyzr_q[5];
//             player_cTemp.name = tyzr_q[5];
//         }

//     }

//     public void zrty_yangB()
//     {
//         yang_zr.SetActive(true);
//         toplayer_zr.SetActive(false);
//         for (int i = 0; i < 7; i++)
//         {
//             //Debug.Log("#!#@!#!@#!@#" + "yang" + (i + 1) + "");
//             GameObject yangn = yang_zr.transform.Find("yang" + (i + 1) + "").gameObject as GameObject;
//             if (tyzr_yang[i].Equals("-1"))
//             {
//                 yangn.transform.Find("suo").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("suo1");
//                 yangn.transform.Find("name").gameObject.GetComponent<Text>().text = "";
//             }
//             else if (tyzr_yang[i].Equals(""))
//             {
//                 yangn.transform.Find("suo").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("tongyongtouxiang");
//                 yangn.transform.Find("name").gameObject.GetComponent<Text>().text = "";
//             }
//             else
//             {
//                 yangn.transform.Find("suo").gameObject.GetComponent<Image>().sprite = ResourceManager.GetSprite("tongyongtouxiang");
//                 yangn.transform.Find("name").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[tyzr_yang[i]].player_name;
//             }
//         }
//         yang_zr.transform.Find("gfxn_yang").gameObject.transform.Find("gnum").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedSunAddGFXNData[0].atk + "";
//         yang_zr.transform.Find("gfxn_yang").gameObject.transform.Find("fnum").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedSunAddGFXNData[0].def + "";
//         yang_zr.transform.Find("gfxn_yang").gameObject.transform.Find("xnum").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedSunAddGFXNData[0].hp + "";
//         yang_zr.transform.Find("gfxn_yang").gameObject.transform.Find("nnum").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedSunAddGFXNData[0].within + "";
//     }

//     public void zrtoPlay_B()
//     {
//         yang_zr.SetActive(false);
//         toplayer_zr.SetActive(true);
//         zrty_init();
//     }

//     public void zrMs_init(string id)
//     {
//         person_ui.SetActive(true);
//         for (int a = 0; a < PDM.data.root.beenObservedHerosData.Count; a++)
//         {
//             if (PDM.data.root.beenObservedHerosData[a].iD.Equals(id))
//             {
//                 person_ui.transform.Find("name").gameObject.GetComponent<Text>().text = GameMainData.instance.pl_[PDM.data.root.beenObservedHerosData[a].iD].player_name;
//                 person_ui.transform.Find("Lv").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].level + "";
//                 person_ui.transform.Find("tupoNum").gameObject.GetComponent<Text>().text = "+" + PDM.data.root.beenObservedHerosData[a].tupocc + "";
//                 person_ui.transform.Find("propSx/G/num").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].atk + "";
//                 person_ui.transform.Find("propSx/F/num").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].def + "";
//                 person_ui.transform.Find("propSx/X/num").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].hp + "";
//                 person_ui.transform.Find("propSx/N/num").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].mana + "";
//                 person_ui.transform.Find("propSx/BJ/Text").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].crit + "";
//                 person_ui.transform.Find("propSx/PZ/Text").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].counter + "";
//                 person_ui.transform.Find("propSx/MZ/Text").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].hit + "";
//                 person_ui.transform.Find("propSx/FB/Text").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].explosionproof + "";
//                 person_ui.transform.Find("propSx/GD/Text").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].parry + "";
//                 person_ui.transform.Find("propSx/SB/Text").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].dodge + "";
//                 if (!GameMainData.instance.pl_[PDM.data.root.beenObservedHerosData[a].iD].player_tfwgId.Equals("-1"))
//                 {
//                     person_ui.transform.Find("WGname").gameObject.GetComponent<Text>().text = GameMainData.instance.tfwg_[GameMainData.instance.pl_[PDM.data.root.beenObservedHerosData[a].iD].player_tfwgId].tfwg_name;
//                     person_ui.transform.Find("WGlv").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].tfwglevel + "";
//                 }
//                 else
//                 {
//                     person_ui.transform.Find("WGname").gameObject.GetComponent<Text>().text = "";
//                 }
//                 person_ui.transform.Find("propSx/N/num").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].mana + "";
//                 if (!GameMainData.instance.pl_[PDM.data.root.beenObservedHerosData[a].iD].player_yfId.Equals("-1"))
//                 {
//                     string[] yf_str = GameMainData.instance.pl_[PDM.data.root.beenObservedHerosData[a].iD].player_yfId.Split('*');
//                     for (int i = 0; i < yf_str.Length; i++)
//                     {
//                         person_ui.transform.Find("YF/" + (i + 1) + "").gameObject.GetComponent<Text>().text = LuaBehaviour.configYuanFen_GetData("yf_id", yf_str[i] + "", "yf_name");//   
//                         person_ui.transform.Find("YF/" + (i + 1) + "").gameObject.GetComponent<Text>().color = Color.gray;
//                     }
//                 }
//                 //Debug.Log("yfqk" + PDM.data.root.beenObservedHerosData[a].yuanfenQk);
//                 if (!PDM.data.root.beenObservedHerosData[a].yuanfenQk.Equals("-1"))
//                 {
//                     string[] yfqkstr = PDM.data.root.beenObservedHerosData[a].yuanfenQk.Split('*');
//                     for (int i = 0; i < yfqkstr.Length; i++)
//                     {
//                         person_ui.transform.Find("YF/" + (i + 1) + "").gameObject.GetComponent<Text>().color = Color.white;
//                     }
//                 } 
//                 person_ui.transform.Find("tx_level").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedHerosData[a].tianxing + "阶";

//                 if (!PDM.data.root.beenObservedBooksData[a].metaID1.Equals("-1"))
//                 {
//                     person_ui.transform.Find("wg1/name").gameObject.GetComponent<Text>().text = GameMainData.instance.wg_[PDM.data.root.beenObservedBooksData[a].metaID1].wg_name;
//                     person_ui.transform.Find("wg1/Lv").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedBooksData[a].level1 + "";
//                     person_ui.transform.Find("wg1/jinjie").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedBooksData[a].order1 + "阶";
//                 }
//                 else
//                 {
//                     person_ui.transform.Find("wg1/name").gameObject.GetComponent<Text>().text = "无";
//                     person_ui.transform.Find("wg1/Lv").gameObject.GetComponent<Text>().text = "";
//                     person_ui.transform.Find("wg1/jinjie").gameObject.GetComponent<Text>().text = "";
//                 }

//                 if (!PDM.data.root.beenObservedBooksData[a].metaID2.Equals("-1"))
//                 {
//                     person_ui.transform.Find("wg2/name").gameObject.GetComponent<Text>().text = GameMainData.instance.wg_[PDM.data.root.beenObservedBooksData[a].metaID2].wg_name;
//                     person_ui.transform.Find("wg2/Lv").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedBooksData[a].level2 + "";
//                     person_ui.transform.Find("wg2/jinjie").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedBooksData[a].order2 + "阶";
//                 }
//                 else
//                 {
//                     person_ui.transform.Find("wg2/name").gameObject.GetComponent<Text>().text = "无";
//                     person_ui.transform.Find("wg2/Lv").gameObject.GetComponent<Text>().text = "";
//                     person_ui.transform.Find("wg2/jinjie").gameObject.GetComponent<Text>().text = "";
//                 }

//                 if (!PDM.data.root.beenObservedBooksData[a].metaID3.Equals("-1"))
//                 {
//                     person_ui.transform.Find("wg3/name").gameObject.GetComponent<Text>().text = GameMainData.instance.wg_[PDM.data.root.beenObservedBooksData[a].metaID3].wg_name;
//                     person_ui.transform.Find("wg3/Lv").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedBooksData[a].level3 + "";
//                     person_ui.transform.Find("wg3/jinjie").gameObject.GetComponent<Text>().text = PDM.data.root.beenObservedBooksData[a].order3 + "阶";
//                 }
//                 else
//                 {
//                     person_ui.transform.Find("wg3/name").gameObject.GetComponent<Text>().text = "无";
//                     person_ui.transform.Find("wg3/Lv").gameObject.GetComponent<Text>().text = "";
//                     person_ui.transform.Find("wg3/jinjie").gameObject.GetComponent<Text>().text = "";
//                 }

//                 if (!PDM.data.root.peenObservedEquipsData[a].equipID1.Equals("-1"))
//                 {
//                     person_ui.transform.Find("wq/name").gameObject.GetComponent<Text>().text = GameMainData.instance.Zhuangbei[PDM.data.root.peenObservedEquipsData[a].equipID1].equip_name;
//                     person_ui.transform.Find("wq/Lv").gameObject.GetComponent<Text>().text = PDM.data.root.peenObservedEquipsData[a].level1 + "";
//                     person_ui.transform.Find("wq/jinjie").gameObject.GetComponent<Text>().text = PDM.data.root.peenObservedEquipsData[a].refineLevel1 + "阶";
//                 }
//                 else
//                 {
//                     person_ui.transform.Find("wq/name").gameObject.GetComponent<Text>().text = "无";
//                     person_ui.transform.Find("wq/Lv").gameObject.GetComponent<Text>().text = "";
//                     person_ui.transform.Find("wq/jinjie").gameObject.GetComponent<Text>().text = "";
//                 }

//                 if (!PDM.data.root.peenObservedEquipsData[a].equipID2.Equals("-1"))
//                 {
//                     person_ui.transform.Find("yf/name").gameObject.GetComponent<Text>().text = GameMainData.instance.Zhuangbei[PDM.data.root.peenObservedEquipsData[a].equipID2].equip_name;
//                     person_ui.transform.Find("yf/Lv").gameObject.GetComponent<Text>().text = PDM.data.root.peenObservedEquipsData[a].level2 + "";
//                     person_ui.transform.Find("yf/jinjie").gameObject.GetComponent<Text>().text = PDM.data.root.peenObservedEquipsData[a].refineLevel2 + "阶";
//                 }
//                 else
//                 {
//                     person_ui.transform.Find("yf/name").gameObject.GetComponent<Text>().text = "无";
//                     person_ui.transform.Find("yf/Lv").gameObject.GetComponent<Text>().text = "";
//                     person_ui.transform.Find("yf/jinjie").gameObject.GetComponent<Text>().text = "";
//                 }

//                 if (!PDM.data.root.peenObservedEquipsData[a].equipID3.Equals("-1"))
//                 {
//                     person_ui.transform.Find("sp/name").gameObject.GetComponent<Text>().text = GameMainData.instance.Zhuangbei[PDM.data.root.peenObservedEquipsData[a].equipID3].equip_name;
//                     person_ui.transform.Find("sp/Lv").gameObject.GetComponent<Text>().text = PDM.data.root.peenObservedEquipsData[a].level3 + "";
//                     person_ui.transform.Find("sp/jinjie").gameObject.GetComponent<Text>().text = PDM.data.root.peenObservedEquipsData[a].refineLevel3 + "阶";
//                 }
//                 else
//                 {
//                     person_ui.transform.Find("sp/name").gameObject.GetComponent<Text>().text = "无";
//                     person_ui.transform.Find("sp/Lv").gameObject.GetComponent<Text>().text = "";
//                     person_ui.transform.Find("sp/jinjie").gameObject.GetComponent<Text>().text = "";
//                 }
//             }
//         }
//     }

//     public void esc_tyzrms()
//     {
//         person_ui.SetActive(false);
//     }

//     public void esc_tyzhenrong()
//     {
//         Destroy(tongyongzrObj.gameObject);
//     }


//     GameObject Temp_tongyongdzxq;

//     //通用弟子详情
//     public void xiangqing_B(string id)
//     {
//         Temp_tongyongdzxq = Instantiate(tongyongdzxq, tongyongdzxq.transform.position, Quaternion.identity)as GameObject;
//         Temp_tongyongdzxq.transform.SetParent(canvas.transform, false);
//         tongyongdzxq.transform.SetAsLastSibling();
//         tydzxiangqing.instance.dizixq_Init(id);
//     }

//     public void esc_tyxiangqing()
//     {
//         Destroy(Temp_tongyongdzxq.gameObject);
//     }




//     //时间常量值
//     public const int second = 60;
//     public const int minute = 60;
//     public const int hour = 24;

//     #region Calaculate_Time

//     //通过传回的数值进行计算
//     //每帧获取系统时间
//     public string  Calaculate_Time(float data)
//     { 
//         string rsl = "";
//         //拆分拿到对应的数值
//         //3天最长259200秒
//         //这个算法最大计算数值只有天，也就是说最大的计算结果是天
//         float day_R = 0f;
//         float hour_R = 0f;
//         float minute_R = 0f;
//         float second_R = 0f;

//         minute_R = data / second;
//         second_R = data % second;

//         hour_R = minute_R / minute;
//         minute_R = minute_R % minute;

//         day_R = hour_R / hour;
//         hour_R = hour_R % hour;
//         if (day_R > 1)
//         {
//             rsl = (int)day_R + "天" + (int)hour_R + "时" + (int)minute_R + "分" + (int)second_R + "秒";
//         }
//         else if (hour_R > 1)
//         {
//             rsl = (int)hour_R + "时" + (int)minute_R + "分" + (int)second_R + "秒";
//         }
//         else if (minute_R > 1)
//         {
//             rsl = (int)minute_R + "分" + (int)second_R + "秒";
//         }
//         else
//         {
//             rsl = (int)second_R + "秒";
//         }
//         return rsl;

//     }

//     #endregion

//     //Unix时间戳转换为年月日时分
//     public string ConvertTimeStampToString(string timeStamp)
//     {
//         DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
//         long lTime = long.Parse(timeStamp);
//         DateTime Rsl = dtStart.AddSeconds(lTime);
//         string month_Str = Rsl.Month + "";
//         string day_Str = Rsl.Day + "";
//         string hour_Str = Rsl.Hour + "";
//         string minute_Str = Rsl.Minute + "";
//         if (Rsl.Month < 10)
//         {
//             month_Str = "0" + month_Str;
//         }
//         if (Rsl.Day < 10)
//         {
//             day_Str = "0" + day_Str;
//         }
//         if (Rsl.Hour < 10)
//         {
//             hour_Str = "0" + hour_Str;
//         }
//         if (Rsl.Minute < 10)
//         {
//             minute_Str = "0" + minute_Str;
//         }
//         return Rsl.Year + "年" + month_Str + "月" + day_Str + "日" + hour_Str + "时" + minute_Str + "分";
//     }

//     //计算出时间戳
//     public string CalaculateTimeStamp()
//     {
//         System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
//         long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds; // 相差秒数
//         //Debug.Log("客户端算出的时间戳=" + timeStamp);
//         return timeStamp + "";
//     }


//     //生成
//     public void GenerateIntroductionPage(string ID, bool CanSeeAll)
//     {
//         //		//Debug.Log("GenerateIntroductionPage的ID=" + ID);
//         //		//Debug.Log("GenerateIntroductionPage的CanSeeAll=" + CanSeeAll);
//         //
//         //		//Debug.Log("ID.Substring(0, 1)=" + ID.Substring(0, 1));
//         if (!ID.Equals(""))
//         {
//             int propID = 0;
//             if (ID.Substring(0, 1).Equals("Z") && ID.Split(GameMainData.instance.maohao).Length == 2 && ID.Split(GameMainData.instance.maohao)[1].Equals("sp"))
//             {	//装备碎片
//                 Equip equip_ = new Equip();
//                 if (GameMainData.instance.Zhuangbei.TryGetValue(ID.Split(GameMainData.instance.maohao)[0], out equip_))
//                 {

//                     GenerateItroPage(equip_, true);

//                 }
//             }
//             else if (ID.Substring(0, 1).Equals("S") && ID.Split(GameMainData.instance.maohao).Length == 2 && ID.Split(GameMainData.instance.maohao)[1].Equals("hp"))
//             {	//弟子魂魄
//                 Player player = new Player();
//                 if (GameMainData.instance.pl_.TryGetValue(ID.Split(GameMainData.instance.maohao)[0], out player))
//                 {

//                     GenerateItroPage(player, CanSeeAll, true);

//                 }
//             }
//             else if (ID.Substring(0, 1).Equals("W") && ID.Split(GameMainData.instance.maohao).Length == 2 && ID.Split(GameMainData.instance.maohao)[1].Equals("sp"))
//             {	//武功碎片
//                 WuGong wugong = new WuGong();
//                 if (GameMainData.instance.wg_.TryGetValue(ID.Split(GameMainData.instance.maohao)[0], out wugong))
//                 {

//                     GenerateItroPage(wugong, true);

//                 }
//             }
//             else if (ID.Substring(0, 1).Equals("Z"))
//             {	//装备
//                 Equip equip_ = new Equip();
//                 if (GameMainData.instance.Zhuangbei.TryGetValue(ID, out equip_))
//                 {

//                     GenerateItroPage(equip_, false);

//                 }

//             }
//             else if (ID.Substring(0, 1).Equals("S"))
//             {	//弟子

//                 Player player = new Player();
//                 //			//Debug.Log();
//                 if (GameMainData.instance.pl_.TryGetValue(ID, out player))
//                 {

//                     GenerateItroPage(player, CanSeeAll, false);

//                 }
//             }
//             else if (ID.Substring(0, 1).Equals("W"))
//             {	//武功
//                 WuGong wugong = new WuGong();
//                 if (GameMainData.instance.wg_.TryGetValue(ID, out wugong))
//                 {

//                     GenerateItroPage(wugong, false);

//                 }
//             }
//             else if (ID.Contains("DX"))
//             {//雕像
//                 diaoxiang Dx = new diaoxiang();
//                 if (GameMainData.instance.diaoxiang_dic.TryGetValue(ID, out Dx))
//                 {

//                     GenerateItroPage(Dx);

//                 }
//             }
//             else if (int.TryParse(ID, out propID))
//             {//道具	
//                 PropDataMold prop = new PropDataMold();
//                 if (GameMainData.instance.savePack.TryGetValue(ID, out prop))
//                 {

//                     GenerateItroPage(prop);

//                 }
//             }
//         }
//     }

//     void GenerateItroPage(Equip equip_, bool IsSlice)
//     {

//         GameObject	EquipPage = GameObject.Instantiate(EquipPage_Prefab, EquipPage_Prefab.transform.position, Quaternion.identity);
		
//         EquipPage.transform.Find("Close").GetComponent<Button>().onClick.RemoveAllListeners();
//         EquipPage.transform.Find("Close").GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 Destroy(EquipPage.gameObject);
//             });
        
//         EquipPage.transform.SetParent(canvasLoad.transform, false);
//         EquipPage.transform.SetAsLastSibling();


//         //设置标题
//         EquipPage.transform.Find("Title/Text").GetComponent<Text>().text = "装备详情";

//         //关闭天赋武功
//         //		EquipPage.transform.Find("WuGong").gameObject.SetActive(false);
//         if (IsSlice)
//         {
//             EquipPage.transform.Find("Name").GetComponentInChildren<Text>().text = equip_.equip_name + "（碎片）";
//         }
//         else
//         {
//             EquipPage.transform.Find("Name").GetComponentInChildren<Text>().text = equip_.equip_name;
//         }


//         //激活攻防血内
//         //		EquipPage.transform.Find ("Gong").gameObject.SetActive(false);
//         //		EquipPage.transform.Find ("Fang").gameObject.SetActive(false);
//         //		EquipPage.transform.Find ("Xue").gameObject.SetActive(false);
//         //		EquipPage.transform.Find ("Nei").gameObject.SetActive(false);
//         //设置质量：甲乙丙丁
//         if (equip_.equip_quality.Equals("甲"))
//         {
//             EquipPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("jia");	
//         }
//         else if (equip_.equip_quality.Equals("乙"))
//         {
//             EquipPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("yi");	

//         }
//         else if (equip_.equip_quality.Equals("丙"))
//         {
//             EquipPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("bing");	

//         }
//         else if (equip_.equip_quality.Equals("丁"))
//         {
//             EquipPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("ding");	

//         }

//         //		go.transform.Find("Quality").GetComponent<RectTransform>().sizeDelta = EquipPage.transform.Find("Quality").GetComponent<Image>().sprite.pivot * 2;


//         EquipPage.transform.Find("Introduction").gameObject.SetActive(true);
//         EquipPage.transform.Find("Introduction").GetComponent<Text>().text = "  " + equip_.equip_info;

//         //		EquipPage.transform.Find ("ZhuJie").gameObject.SetActive (true);
//         EquipPage.transform.Find("Gong").gameObject.SetActive(true);
//         EquipPage.transform.Find("Fang").gameObject.SetActive(false);
//         EquipPage.transform.Find("Xue").gameObject.SetActive(false);
//         EquipPage.transform.Find("Nei").gameObject.SetActive(false);

//         if (equip_.equip_type.Equals("武器"))
//         {

//             EquipPage.transform.Find("Gong").GetComponent<Image>().sprite = ResourceManager.GetSprite("gongjia");

//             EquipPage.transform.Find("Gong").GetComponentInChildren<Text>().text = equip_.equip_initValue + "";


//         }
//         else if (equip_.equip_type.Equals("服装"))
//         {
//             EquipPage.transform.Find("Gong").GetComponent<Image>().sprite = ResourceManager.GetSprite("fangjia");

//             EquipPage.transform.Find("Gong").GetComponentInChildren<Text>().text = equip_.equip_initValue + "";


//         }
//         else if (equip_.equip_type.Equals("饰品"))
//         {
//             EquipPage.transform.Find("Gong").GetComponent<Image>().sprite = ResourceManager.GetSprite("xuejia");

//             EquipPage.transform.Find("Gong").GetComponentInChildren<Text>().text = equip_.equip_initValue + "";

//         }

       
//     }



//     void GenerateItroPage(Player player_, bool CanSeeAll, bool IsSoul)
//     {
		
//         GameObject PersonPage = GameObject.Instantiate(PersonPage_Prefab, PersonPage_Prefab.transform.position, Quaternion.identity);
		

//         PersonPage.transform.SetParent(canvasLoad.transform, false);
//         PersonPage.transform.SetAsLastSibling();

//         PersonPage.transform.Find("Close").GetComponent<Button>().onClick.RemoveAllListeners();
//         PersonPage.transform.Find("Close").GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 Destroy(PersonPage.gameObject);
//             });

//         //设置标题
//         PersonPage.transform.Find("Title/Text").GetComponent<Text>().text = "人物详情";
//         //设置质量：甲乙丙丁
//         if (player_.player_quality.Equals("甲"))
//         {
//             PersonPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("jia_r");	
//         }
//         else if (player_.player_quality.Equals("乙"))
//         {
//             PersonPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("yi_r");	

//         }
//         else if (player_.player_quality.Equals("丙"))
//         {
//             PersonPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("bing_r");	

//         }
//         else if (player_.player_quality.Equals("丁"))
//         {
//             PersonPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("ding_r");	

//         }

//         if (IsSoul)
//         {
//             PersonPage.transform.Find("Name/Title").GetComponent<Text>().text = player_.player_name + "（魂魄）";
//         }
//         else
//         {
//             PersonPage.transform.Find("Name/Title").GetComponent<Text>().text = player_.player_name;
//         }



//         PersonPage.transform.Find("Introduction").gameObject.SetActive(true);
//         PersonPage.transform.Find("Introduction").GetComponent<Text>().text = player_.introduction;
//         //		//Debug.Log("PersonPage.transform.Find(\"Introduction\").GetComponent<Text>().tex=" + PersonPage.transform.Find("Introduction").GetComponent<Text>().text);
//         //		//Debug.Log("player_.introductio=" + player_.introduction);


//         //人物下方的各种信息都是在content下的内容
//         PersonPage.transform.Find("Scroll View").gameObject.SetActive(true);
//         Transform content = PersonPage.transform.Find("Scroll View/Viewport/Content");
//         content.transform.Find("TalentBook").gameObject.SetActive(true);
//         Transform TalentBookContent = content.transform.Find("TalentBook/Content");
//         Transform TalentBookContent_1 = content.transform.Find("TalentBook/Content (1)");
//         //天赋武功
//         if (!player_.player_tfwgId.Equals("-1"))
//         {
//             //			//Debug.Log("player_.player_tfwgId=" + player_.player_tfwgId);
//             //			//Debug.Log("(GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).tfwg_name =" + (GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).tfwg_name);
//             TalentBookContent.GetComponent<Text>().text = "\u3000" + (GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).tfwg_name + "：" +
//             (GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).tfwg_info;
//             if ((GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).tfwg_tx == 1 && !(GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).character.Equals("") && !(GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).character.Equals("-1"))
//             {
//                 //天赋武功的特性
//                 TalentBookContent_1.GetComponent<Text>().text = "\u3000" + "武功特性：" + (GameMainData.instance.tfwg_[player_.player_tfwgId] as player_tfwg).character;

//             }
//             else
//             {
//                 TalentBookContent_1.GetComponent<Text>().text = "\u3000" + "武功特性：???"; 
//             }

//         }
//         else
//         {
//             TalentBookContent.GetComponent<Text>().text = "\u3000" + "天赋武功暂未开放";
//         }




//         int OneLineWords0 = (int)TalentBookContent.GetComponent<RectTransform>().sizeDelta.x / TalentBookContent.GetComponent<Text>().fontSize;
//         int Lines0 = TalentBookContent.GetComponent<Text>().text.Length / OneLineWords0 + 1;
//         TalentBookContent.GetComponent<RectTransform>().sizeDelta = new Vector2(TalentBookContent.GetComponent<RectTransform>().sizeDelta.x, Lines0 * (TalentBookContent.GetComponent<Text>().fontSize + 15));
//         TalentBookContent.GetComponent<LayoutElement>().preferredHeight = Lines0 * (TalentBookContent.GetComponent<Text>().fontSize + 15);


//         int OneLineWords3 = (int)TalentBookContent_1.GetComponent<RectTransform>().sizeDelta.x / TalentBookContent_1.GetComponent<Text>().fontSize;
//         int Lines3 = TalentBookContent_1.GetComponent<Text>().text.Length / OneLineWords3 + 1;
//         TalentBookContent_1.GetComponent<RectTransform>().sizeDelta = new Vector2(TalentBookContent_1.GetComponent<RectTransform>().sizeDelta.x, Lines3 * (TalentBookContent_1.GetComponent<Text>().fontSize + 15));
//         TalentBookContent_1.GetComponent<LayoutElement>().preferredHeight = Lines3 * (TalentBookContent_1.GetComponent<Text>().fontSize + 15);

//         content.transform.Find("TalentBook").GetComponent<LayoutElement>().preferredHeight = TalentBookContent.GetComponent<LayoutElement>().preferredHeight +
//         TalentBookContent_1.GetComponent<LayoutElement>().preferredHeight +
//         content.transform.Find("TalentBook/Title").GetComponent<LayoutElement>().preferredHeight;


//         //		if (CanSeeAll) {

//         //天性
//         content.transform.Find("TianXing").gameObject.SetActive(true);
//         Transform tianxingContent = content.transform.Find("TianXing/Content");
//         tianxing tx1 = new tianxing();
//         if (GameMainData.instance.saveTianXingData.TryGetValue(player_.player_id, out tx1))
//         {

//             tianxingContent.GetComponent<Text>().text = "\u3000" + "一阶：" + tx1.tx_rank1 +
//             System.Environment.NewLine +
//             "\u3000" + "二阶：" + tx1.tx_rank2 +
//             System.Environment.NewLine +
//             "\u3000" + "三阶：" + tx1.tx_rank3;
//         }
//         else
//         {
//             tianxingContent.GetComponent<Text>().text = "\u3000" + "天性暂未开放";

//         }
//         int OneLineWords1 = (int)tianxingContent.GetComponent<RectTransform>().sizeDelta.x / tianxingContent.GetComponent<Text>().fontSize;
//         int Lines1 = (tianxingContent.GetComponent<Text>().text.Length + 12) / OneLineWords1 + 1;   //+6代表3个首行缩进符
//         tianxingContent.GetComponent<RectTransform>().sizeDelta = new Vector2(tianxingContent.GetComponent<RectTransform>().sizeDelta.x, Lines1 * (tianxingContent.GetComponent<Text>().fontSize + 15));
//         tianxingContent.GetComponent<LayoutElement>().preferredHeight = Lines1 * (tianxingContent.GetComponent<Text>().fontSize + 15);

//         content.transform.Find("TianXing").GetComponent<LayoutElement>().preferredHeight = tianxingContent.GetComponent<LayoutElement>().preferredHeight +
//         content.transform.Find("TianXing/Title").GetComponent<LayoutElement>().preferredHeight;






//         content.transform.Find("YuanFen").gameObject.SetActive(true);
//         Transform yuanfenContent = content.transform.Find("YuanFen/Content");
//         //缘分
//         //只有甲级弟子才有缘分
//         if (!player_.player_yfId.Equals("-1"))
//         {
//             string[] each_info = player_.player_yfId.Split(GameMainData.instance.xing);
           
//             string rsl = "";
//             for (int i = 0; i < each_info.Length; i++)
//             {

//                 UnityEngine.Debug.Log("each_info[i]" + each_info[i]);
//                 YuanFen yf = new YuanFen();
// //                rsl = LuaBehaviour.configYuanFen_GetData("yf_id", each_info[i], "all");
//                 if (GameMainData.instance.dzyf_.TryGetValue(each_info[i], out yf))
//                 {
//                     rsl = yf.yf_id + '#' + yf.yf_name + '#' + yf.yf_info + '#' + yf.yf_type + '#' + yf.yf_xgrw + '#' + yf.addSx;
           
//                 }


//                 if (rsl.Equals(""))
//                 {
//                     yuanfenContent.GetComponent<Text>().text = "\u3000" + "缘分暂未开放";
//                 }
//                 else
//                 {
// //                    YuanFen yf = new YuanFen();
//                     string[] temp = rsl.Split('#');
//                     yf.yf_init(temp[0], temp[1], temp[2], int.Parse(temp[3]), temp[4], temp[5]); 

//                     if (yuanfenContent.GetComponent<Text>().text.Equals(""))
//                     {
//                         yuanfenContent.GetComponent<Text>().text = "\u3000" + RejectMyself(player_.player_id, yf);
//                     }
//                     else
//                     {
//                         yuanfenContent.GetComponent<Text>().text += (System.Environment.NewLine + "\u3000" + RejectMyself(player_.player_id, yf));
//                     }


//                 }
//                 //if (GameMainData.instance.dzyf_.TryGetValue(each_info[i], out yf))
//                 //{
//                 //    if (yuanfenContent.GetComponent<Text>().text.Equals(""))
//                 //    {
//                 //        yuanfenContent.GetComponent<Text>().text = "\u3000" + RejectMyself(player_.player_id, yf);
//                 //    }
//                 //    else
//                 //    {
//                 //        yuanfenContent.GetComponent<Text>().text += (System.Environment.NewLine + "\u3000" + RejectMyself(player_.player_id, yf));
//                 //    }
//                 //}
//                 //else
//                 //{
//                 //    yuanfenContent.GetComponent<Text>().text = "\u3000" + "缘分暂未开放";
//                 //}
//             }
//             int OneLineWords2 = (int)yuanfenContent.GetComponent<RectTransform>().sizeDelta.x / yuanfenContent.GetComponent<Text>().fontSize;
//             int Lines2 = (yuanfenContent.GetComponent<Text>().text.Length + each_info.Length) / OneLineWords2 + 1;
//             yuanfenContent.GetComponent<RectTransform>().sizeDelta = new Vector2(yuanfenContent.GetComponent<RectTransform>().sizeDelta.x, Lines2 * (yuanfenContent.GetComponent<Text>().fontSize + 15));
//             yuanfenContent.GetComponent<LayoutElement>().preferredHeight = Lines2 * (yuanfenContent.GetComponent<Text>().fontSize + 15);

//         }
//         else
//         {

//             yuanfenContent.GetComponent<Text>().text = "\u3000" + "缘分暂未开放";
//             yuanfenContent.GetComponent<RectTransform>().sizeDelta = new Vector2(yuanfenContent.GetComponent<RectTransform>().sizeDelta.x, yuanfenContent.GetComponent<Text>().fontSize + 15);
//             yuanfenContent.GetComponent<LayoutElement>().preferredHeight = yuanfenContent.GetComponent<Text>().fontSize + 15;
//         }

//         content.transform.Find("YuanFen").GetComponent<LayoutElement>().preferredHeight = yuanfenContent.GetComponent<LayoutElement>().preferredHeight +
//         content.transform.Find("YuanFen/Title").GetComponent<LayoutElement>().preferredHeight;


       
//     }

//     void GenerateItroPage(WuGong wugong_, bool IsSlice)
//     {

//         GameObject	BookPage = GameObject.Instantiate(BookPage_Prefab, BookPage_Prefab.transform.position, Quaternion.identity);
//         BookPage.transform.Find("Close").GetComponent<Button>().onClick.RemoveAllListeners();
//         BookPage.transform.Find("Close").GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 Destroy(BookPage.gameObject);
//             });


//         BookPage.transform.SetParent(canvasLoad.transform, false);
//         BookPage.transform.SetAsLastSibling();

//         //设置标题
//         BookPage.transform.Find("Title/Text").GetComponent<Text>().text = "武功信息";


//         //激活攻防血内
//         //		BookPage.transform.Find ("Gong").gameObject.SetActive(false);
//         if (IsSlice)
//         {
//             BookPage.transform.Find("Name").GetComponentInChildren<Text>().text = wugong_.wg_name + "（残页）";
//         }
//         else
//         {
//             BookPage.transform.Find("Name").GetComponentInChildren<Text>().text = wugong_.wg_name;
//         }



//         //该武功增加的数值
//         BookPage.transform.Find("Gong").gameObject.SetActive(true);
//         BookPage.transform.Find("Fang").gameObject.SetActive(false);
//         BookPage.transform.Find("Xue").gameObject.SetActive(false);
//         BookPage.transform.Find("Nei").gameObject.SetActive(false);
//         BookPage.transform.Find("Gong").GetComponentInChildren<Text>().text = wugong_.wg_initValue + "%";
//         //		//Debug.Log("wugong_.wg_type=" + wugong_.wg_type);
//         if (wugong_.wg_type.Equals("防"))
//         {
//             BookPage.transform.Find("Gong").GetComponent<Image>().sprite = ResourceManager.GetSprite("fangjia");
//             BookPage.transform.Find("Introduction").GetComponent<Text>().text = "  该武功增加防御力" + wugong_.wg_initValue + "%";
//         }
//         else if (wugong_.wg_type.Equals("攻"))
//         {
//             BookPage.transform.Find("Gong").GetComponent<Image>().sprite = ResourceManager.GetSprite("gongjia");
//             BookPage.transform.Find("Introduction").GetComponent<Text>().text = "  该武功增加攻击力" + wugong_.wg_initValue + "%";
//         }
//         else if (wugong_.wg_type.Equals("内"))
//         {
//             BookPage.transform.Find("Gong").GetComponent<Image>().sprite = ResourceManager.GetSprite("neijia");
//             BookPage.transform.Find("Introduction").GetComponent<Text>().text = "  该武功增加内力" + wugong_.wg_initValue + "%";
//         }
//         else if (wugong_.wg_type.Equals("血"))
//         {
//             BookPage.transform.Find("Gong").GetComponent<Image>().sprite = ResourceManager.GetSprite("xuejia");
//             BookPage.transform.Find("Introduction").GetComponent<Text>().text = "  该武功增加血量" + wugong_.wg_initValue + "%";
//         }



//         //设置质量：甲乙丙丁
//         if (wugong_.wg_quality.Equals("甲"))
//         {
//             BookPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("jia");	
//         }
//         else if (wugong_.wg_quality.Equals("乙"))
//         {
//             BookPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("yi");	
//         }
//         else if (wugong_.wg_quality.Equals("丙"))
//         {
//             BookPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("bing");	
//         }
//         else if (wugong_.wg_quality.Equals("丁"))
//         {
//             BookPage.transform.Find("Quality").GetComponent<Image>().sprite = ResourceManager.GetSprite("ding");	
//         }


      


//     }

//     void GenerateItroPage(diaoxiang Dx)
//     {

//         GameObject StatuePage = GameObject.Instantiate(StatuePage_Prefab, StatuePage_Prefab.transform.position, Quaternion.identity);
	
//         StatuePage.transform.Find("Close").GetComponent<Button>().onClick.RemoveAllListeners();
//         StatuePage.transform.Find("Close").GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 Destroy(StatuePage.gameObject);
//             });

//         StatuePage.transform.SetParent(canvasLoad.transform, false);
//         StatuePage.transform.SetAsLastSibling();
//         StatuePage.transform.Find("Title/Text").GetComponent<Text>().text = "雕像信息";


//         //激活攻防血内
//         //		BookPage.transform.Find ("Gong").gameObject.SetActive(false);

//         StatuePage.transform.Find("Name").GetComponentInChildren<Text>().text = Dx.dx_name;
//         StatuePage.transform.Find("Introduction").GetComponent<Text>().text = Dx.dx_info;

     

//     }

//     void GenerateItroPage(PropDataMold prop)
//     {

//         GameObject PropPage = GameObject.Instantiate(PropPage_Prefab, PropPage_Prefab.transform.position, Quaternion.identity);
//         PropPage.transform.Find("Close").GetComponent<Button>().onClick.RemoveAllListeners();
//         PropPage.transform.Find("Close").GetComponent<Button>().onClick.AddListener(delegate
//             {
//                 Destroy(PropPage.gameObject);
//             });
	
//         PropPage.transform.SetParent(canvasLoad.transform, false);
//         PropPage.transform.SetAsLastSibling();

//         PropPage.transform.Find("Title/Text").GetComponent<Text>().text = "道具信息";


//         //激活攻防血内
//         //		BookPage.transform.Find ("Gong").gameObject.SetActive(false);

//         PropPage.transform.Find("Name").GetComponentInChildren<Text>().text = prop.prop_name;
//         PropPage.transform.Find("Introduction").GetComponent<Text>().text = prop.prop_info;

       
//     }

//     //缘分里面剔除自己,入参为缘分信息，自己弟子的ID，
//     string RejectMyself(string myHeroID, YuanFen yf)
//     {
//         string rsl = "";
//         if (yf.yf_type == 1)
//         {//弟子
//             rsl = "与";
//             string type = yf.addSx.Split(GameMainData.instance.xing)[0];
//             string value = yf.addSx.Split(GameMainData.instance.xing)[1];
//             string[] soul_Array = yf.yf_xgrw.Split(GameMainData.instance.xing);
//             for (int i = 0; i < soul_Array.Length; i++)
//             {
//                 if (soul_Array[i].Equals(myHeroID))
//                 {
//                     continue;
//                 }
//                 else
//                 {
//                     //					//Debug.Log("rsl=" + rsl);
//                     if (type.Equals("攻"))
//                     {
//                         rsl = YuAddString(soul_Array[i], rsl);
//                     }
//                     else if (type.Equals("防"))
//                     {
//                         rsl = YuAddString(soul_Array[i], rsl);
//                     }
//                     else if (type.Equals("血"))
//                     {
//                         rsl = YuAddString(soul_Array[i], rsl);
//                     }
//                     else if (type.Equals("内"))
//                     {
//                         rsl = YuAddString(soul_Array[i], rsl);
//                     }
//                 }
//             }
//             if (type.Equals("攻"))
//             {
//                 rsl += "齐上阵，攻击提升" + value + "%";
//             }
//             else if (type.Equals("防"))
//             {
//                 rsl += "齐上阵，防御提升" + value + "%";
//             }
//             else if (type.Equals("血"))
//             {
//                 rsl += "齐上阵，血量提升" + value + "%";
//             }
//             else if (type.Equals("内"))
//             {
//                 rsl += "齐上阵，内力提升" + value + "%";
//             }
//             rsl = yf.yf_name + "：" + rsl;
//         }
//         else
//         {
//             rsl = yf.yf_info;
//         }
//         return rsl;

//     }


//     //第一个是与字，增加的字符串
//     string YuAddString(string OtherHeroID, string rsl)
//     {
        
//         Player pl = new Player();
//         if (GameMainData.instance.pl_.TryGetValue(OtherHeroID, out pl))
//         {
//             if (rsl.Equals("与"))
//             {
//                 rsl += pl.player_name;
//             }
//             else
//             {
//                 rsl += "，" + pl.player_name;
//             }
//         } 
//         return rsl;
//     }



//     //通过名字索要Sprite
//     public Sprite LoadSprite(string Path)
//     {
// //        Debug.Log("Public的LoadSprite的Path=" + Path);
//         if (Resources.Load<GameObject>("Sprites/" + Path) != null)
//         {
//             return Resources.Load<GameObject>("Sprites/" + Path).GetComponent<Image>().sprite;
//         }
//         else
//         {
//             return null;
//         }

       
//     }

//     /// <summary>
//     /// 此方法传入ID去掉前面的S，只传入后面的数字
//     /// </summary>
//     /// <returns>The portrait by I.</returns>
//     /// <param name="ID_NoS">I d no s.</param>

//     //通过元弟子ID，拿到对应的头像
//     public Sprite GetPortraitByID(string ID)
//     {
//         ID = ID.Substring(1, ID.Length - 1);
//         if (Resources.Load<GameObject>("Sprites/Portrait/" + ID) != null)
//         {
//             return Resources.Load<GameObject>("Sprites/Portrait/" + ID).GetComponent<Image>().sprite;  
//         }
//         else
//         {
//             return null;
//         }
       
//     }


  



//     //将游戏物体激活并且放置在最上层
//     public void  TrueAndLast(GameObject go)
//     {
//         go.SetActive(true);
//         go.transform.SetAsLastSibling();
//     }

//     //判断一下己方是否有上阵的弟子
//     public bool IsMyHeroOnBattle()
//     {
//         bool HeroOnBattle = false;
//         for (int i = 0; i < ZhenRong.instance.zr_frontRow.Length; i++)
//         {
//             if (!ZhenRong.instance.zr_frontRow[i].Equals(""))
//             {
//                 HeroOnBattle = true;
//                 break;
//             }
//         }
//         return HeroOnBattle;
       
//     }


//     //取到lua里面的全局方法
//     public void  LuaShowWhichPage(string pageName)
//     {
//         Action<string> ShowWhichPage = LuaBehaviour.luaEnv.Global.Get<Action<string>>("Show_Which_Page");
//         ShowWhichPage(pageName);
//     }

//     //取到lua里面的全局方法
//     public void  LuaDeletePage(string pageName)
//     {
//         Action<string> DeletePage = LuaBehaviour.luaEnv.Global.Get<Action<string>>("DeleteWhichPage");
//         DeletePage(pageName);
//     }

//     //取到lua里面的全局方法
//     public void  LuaAddPage(string pageName)
//     {
//         Action<string> AddPage = LuaBehaviour.luaEnv.Global.Get<Action<string>>("AddPage");
//         AddPage(pageName);
//     }

	[LuaCallCSharp]
    //江湖2地图移动方法
	public void moveMap(string nowmap,string nowmapid,float x,float y,float z)
    {
		GameObject obj = GameObject.Find(nowmap).gameObject;
//        GameObject map1temp = GameObject.Find("map1temp").gameObject;
		cameraPosInit (x,y,z);
		GameObject mapbuttontemp = obj.transform.Find ("mapbuttontemp").gameObject;
		GameObject nowmapbutton = obj.transform.Find (nowmapid).gameObject;
		float yidongx = nowmapbutton.transform.position.x - mapbuttontemp.transform.position.x;
		float yidongy = nowmapbutton.transform.position.y - mapbuttontemp.transform.position.y;
		Vector3 postemp  = new Vector3(Camera.main.transform.position.x + yidongx, Camera.main.transform.position.y + yidongy, Camera.main.transform.position.z);
		Camera.main.transform.DOMove(postemp, 0.5f, false);
    }

    //打开江湖交互界面
    public void peopleJiaoHu()
    {
        GameObject obj = GameObject.Find("people_ui").gameObject;
        obj.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }
    //关闭江湖交互界面
    public void peopleJiaoHuClose()
    {
        GameObject obj = GameObject.Find("people_ui").gameObject;
        obj.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
	
    }


    private void checkChildAndClose(Transform t)
    {
        foreach (Transform v in t)
        {
            if (v.gameObject.name == "level1" || v.gameObject.name == "level2")
            {
                checkChildAndClose(v.gameObject.transform);

            }else
            {

            if (

                  v.gameObject.name == "dangban"
                || v.gameObject.name == "a_package"
                || v.gameObject.name == "a_dizi"
                || v.gameObject.name == "a_wugong"
                || v.gameObject.name == "a_equip"
                || v.gameObject.name == "a_zhenrong"
                || v.gameObject.name == "a_mainui"
                || v.gameObject.name == "A_FightingAnimation")
            {
                continue;
            }
            if (v.gameObject.activeSelf)
            {
                listMudule.Add(v.gameObject);
                v.gameObject.SetActive(false);
            }

            }


        }
    }
     

    List<GameObject> listMudule = new List<GameObject>();
    // 获取所有的子物体，不包含孙物体 将多余的关闭
    public void setChildObjOfCanvas(string type)
    {
        Debug.Log("setChildObjOfCanvas  type  " + type);
        if (type == "1")
        { 
             
                checkChildAndClose(canvas.transform);
             
        }
        else
        { 
            foreach (GameObject v in listMudule)
            {
                v.SetActive(true);
            }
            listMudule.Clear();
        }

    }



    public void showLoadScene()
    {
        LoadScene.SetActive(true);
    }

    public void closeLoadScene()
    {
        LoadScene.SetActive(false);
    }

    
 
 
 
  
	[LuaCallCSharp]
	public void cameraPosInit(float x,float y,float z){
		Camera.main.transform.localPosition = new Vector3 (x, y, z);
	}





    //玩家第一次进来显示 欢迎玩家 IEnumerator
    [LuaCallCSharp]
 
    public void ShowXiTongChat_o(string  note)
    {
        //Debug.Log("弟子听闻酒馆有一位骨骼惊奇之士，掌门可前往查看究竟。");
      // A_chat.instance.SysChatDelay("掌门管家", "恭喜掌门升级，新的功能【"+ note+"】可以使用了！");

    }

     

    public string getType ( object ob)
    {
        return ob.GetType().ToString();
    }
}