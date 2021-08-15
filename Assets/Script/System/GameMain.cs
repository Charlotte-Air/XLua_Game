using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;


public class GameMain : MonoBehaviour {

//	//银两 黄金   
//	//按钮
//	GameObject Jianghu_Button;
//	GameObject Minshan_Button;
//	GameObject Xinxia_Button;
//	GameObject Qianzhuang_Button;
//	GameObject Youshang_Button;
//	GameObject Lunjian_Button;
//	GameObject Jiulou_Button;
//	//界面
//	GameObject main_ui;
//	GameObject backpack_ui;
//	GameObject jianghu_ui;
//	GameObject equip_ui;
//	GameObject zhenrong_ui;
//	GameObject xinxia_ui;




//	GameObject disciple_ui;



//	GameObject wugong_ui;



//	GameObject mingshan_ui;

//	GameObject findman_ui;
//	GameObject xunxia_ui;
//	GameObject youshang_ui;
//	GameObject qianzhuang_ui;
//	GameObject borrowmoney_ui;
//	GameObject savemoney_ui;
//	GameObject save_ms;


//	GameObject fight_ui;
//	GameObject c_landing_ui;
//	GameObject retroactive_tishi;
//	GameObject world_news;
//	GameObject systems_news;
//	GameObject chuanshu_ui;
//	GameObject chuanshu_reward_over;
//	GameObject lunjian_ui;
//	GameObject signin_ui;


//	public static GameMain instance2;
//	//经验值,等级
//	public int exp_now;
//	public int exp_need;
//	public int level;
//	public Text exp_now_text;
//	public Text exp_need_text;
//	public Text level_text;
//	//获得经验冷却,倍数
//	public float time_gx;
//	public int times_gx;









//	//寻侠ui
//	public int xunxiaui_state=0;



//	public Image jia_image;
//	public Image yi_image;
//	public Image bing_image;
//	public Image ding_image;



//	public int fight_state=0;
//	public GameObject knife_prefab;

//	public int retroactive_tishi_state=0;

//	public string world_word;
//	public int world_news_state=0;
//	float world_news_time=0;
//	public string systems_word;
//	public int systems_news_state=0;
//	float systems_news_time=0;

//	public int xinxia_state=0;

//	string chuanshu_word="滴滴滴滴滴滴滴多多多多多多多多多多多多多多多多多多多多多多多多多多多多";
//	public string chuanshu_reward;
//	int chuanshu_state;
//	public int chuanshuReward_state;

//	public GameObject pos_chuanshu;
//	public GameObject Temp_chuanshu;
//	public GameObject Chuanshu_prefab;

//	string top_systems;
//	int tops_num=0;
//	public GameObject top_systems_finsh;
//	public GameObject top_systems_begin;
//	public Text top_systems_text;

//	public int lunjian_state = 0;

//	public int clandingX_state = 0;


//	//将武林谱页面设置
//	private GameObject WuLinPuPage;
//	//奇遇页面
//	private GameObject QiYuPage;
//	//canvas
//	private GameObject canvas;
//	//血战页面
//	private GameObject XueZhanPage;


//	void Awake () {
//        Debug.Log3("GameMain Awake" + Time.realtimeSinceStartup);
//        instance = this;
//        Debug.Log3("GameMain Awake end " + Time.realtimeSinceStartup);
//    }

//	#region Start
//	void Start () {
 
//		Application.runInBackground = true;
//		times_gx = 1;
//		level = 20;
//		chuanshu_reward="wupin1|wupin2|wupin3";


////		canvas=GameObject.Find("Canvas").gameObject;
//		QiYuPage=this.transform.Find("QiYuPage").gameObject;
//		//拿到武林谱页面
//		WuLinPuPage=this.transform.Find("WuLinPuPage").gameObject;
//		XueZhanPage=this.transform.Find("XueZhanPage").gameObject;
////		Jianghu_Button = GameObject.Find ("main_ui/Jianghu");
////		Minshan_Button = GameObject.Find ("main_ui/Minshan");
////		Xinxia_Button = GameObject.Find ("main_ui/Xinxia");
////		Qianzhuang_Button = GameObject.Find ("main_ui/Qianzhuang");
////		Youshang_Button = GameObject.Find ("main_ui/Youshang");
////		Lunjian_Button = GameObject.Find ("main_ui/Lunjian");
////		Jiulou_Button = GameObject.Find ("main_ui/Jiulou");
//		main_ui = GameObject.Find ("main_ui");
//		backpack_ui = GameObject.Find ("backpack_ui");
//		jianghu_ui = GameObject.Find ("jianghu_ui");
//		equip_ui = GameObject.Find ("equip_ui");
//		zhenrong_ui = GameObject.Find ("zhenrong_ui");

//		disciple_ui = GameObject.Find ("disciple_ui");

//		wugong_ui = GameObject.Find ("wugong_ui");

//		mingshan_ui = GameObject.Find ("mingshan_ui");

//		findman_ui = GameObject.Find ("findman_ui");
//		xunxia_ui = GameObject.Find ("xunxia_ui");
//		youshang_ui = GameObject.Find ("youshang_ui");
//		qianzhuang_ui = GameObject.Find ("qianzhuang_ui");
//		borrowmoney_ui = GameObject.Find ("borrowmoney_ui");
//		savemoney_ui = GameObject.Find ("savemoney_ui");
//		save_ms = GameObject.Find ("save_ms");



//		fight_ui = GameObject.Find ("fight_ui");
//		retroactive_tishi = GameObject.Find ("retroactive_tishi");

////		world_news = GameObject.Find ("world_news");
//		systems_news = GameObject.Find ("systems_news");

//		chuanshu_ui = GameObject.Find ("chuanshu_ui");
//		chuanshu_reward_over = GameObject.Find ("chuanshu_reward_over");

//		lunjian_ui = GameObject.Find ("lunjian_ui");

//		signin_ui = GameObject.Find ("signin_ui");



//		c_landing_ui = GameObject.Find ("c_landing_ui");

	




////		Jianghu_Button.SetActive (false);
////		Minshan_Button.SetActive (false);
////		Xinxia_Button.SetActive (false);
////		Qianzhuang_Button.SetActive (false);
////		Youshang_Button.SetActive (false);
////		Lunjian_Button.SetActive (false);
////		Jiulou_Button.SetActive (false);
//		backpack_ui.SetActive(false);
//		jianghu_ui.SetActive (false);
//		equip_ui.SetActive (false);
//		zhenrong_ui.SetActive (false);
	
//		disciple_ui.SetActive (false);
//		wugong_ui.SetActive (false);
//		mingshan_ui.SetActive (false);
//		findman_ui.SetActive (false);
//		youshang_ui.SetActive (false);
//		qianzhuang_ui.SetActive (false);
////		world_news.SetActive (true);
//		systems_news.SetActive (false);
//		chuanshu_ui.SetActive (false);
//		signin_ui.SetActive (false);
////		lunjian_ui.SetActive (false);

////		tBox_ui.SetActive (false);
////		mRobber_button.SetActive (false);
////		mBeggar_button.SetActive (false);
////		merChant_button.SetActive (false);
////		blackMarker_button.SetActive (false);
////		fallCliff_button.SetActive (false);
////		masterPlay_button.SetActive (false);
////		douWine_button.SetActive (false);

////		refreshUseYuanbao_ui.SetActive (false);




	
////		ms_qiBao ();
////		enemy_player ();
////		zhenrong_start ();
////		test_G ();



////		xinxia_ms ();
////		equip_bag.Add ("wuqi101");
////		equip_bag.Add ("wuqi102");
////		equip_bag.Add ("fangju101");
////		equip_bag.Add ("fangju102");
////		equip_bag.Add ("fangju103");
////		equip_bag.Add ("shipin101");
////		equip_bag.Add ("shipin102");
////
////		qibao_bag.Add ("qibao101");
////		qibao_bag.Add ("qibao102");
////		qibao_bag.Add ("qibao103");
////		qibao_bag.Add ("qibao104");
////		qibao_bag.Add ("qibao105");
////		qibao_bag.Add ("qibao106"); 
//		top_systems="wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww|ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
//		string[] topsystems_word = top_systems.Split ('|');
//		top_systems_text.text = topsystems_word [tops_num];
//		top_systems_text.transform.DOMove (top_systems_finsh.transform.position, 20f, false).OnComplete (topsysTems_);
  
////		getPlayerMoney ("id101");
	

//	}
//	#endregion
     
//	// 重复滚动
//	public void topsysTems_(){
//		tops_num += 1;
//		top_systems_text.transform.position = top_systems_begin.transform.position;
//		string[] topsystems_word = top_systems.Split ('|');
//		top_systems_text.text = topsystems_word [tops_num];
//		top_systems_text.transform.DOMove (top_systems_finsh.transform.position, 20f, false).OnComplete (topsysTems_);
//	}

//	//传书测试
//	public void chuanshu_test(){ 
//		chuanshu_state = 1;
//	} 



//	#region mainUi
//	public void mainUi(){
//		main_ui.SetActive (true);
//		backpack_ui.SetActive (false);
//		equip_ui.SetActive (false);
//		zhenrong_ui.SetActive (false);
//		jianghu_ui.SetActive (false);
//		disciple_ui.SetActive (false);
//		qianzhuang_ui.SetActive (false);
//		youshang_ui.SetActive (false);
//		findman_ui.SetActive (false);
//		mingshan_ui.SetActive (false);
//		wugong_ui.SetActive (false);
//		lunjian_ui.SetActive (false);
//		signin_ui.SetActive (false);
//		chuanshu_ui.SetActive (false);

//		QiYuPage.SetActive (false);
//		WuLinPuPage.SetActive (false);
//		XueZhanPage.SetActive (false);


//		//Debug.Log ("进入mainUi");

//	}
//	#endregion


//	#region backpackUi
//	public void backpackUi(){
//		main_ui.SetActive (false);
//		backpack_ui.SetActive (true);
//		equip_ui.SetActive (false);
//		disciple_ui.SetActive (false);
//		wugong_ui.SetActive (false);
//		zhenrong_ui.SetActive (false);

//		QiYuPage.SetActive (false);
//		WuLinPuPage.SetActive (false);
//		XueZhanPage.SetActive (false);
//		//Debug.Log ("进入backpackUi");
//	}
//	#endregion


//	#region zhenrongUi
//	public void zhenrongUi(){
//		main_ui.SetActive (false);
//		backpack_ui.SetActive (false);
//		zhenrong_ui.SetActive (true);
	
//		QiYuPage.SetActive (false);
//		WuLinPuPage.SetActive (false);
//		XueZhanPage.SetActive (false);
//		ZhenRong.instance.zr_init ();
//		//Debug.Log ("进入zhenrongUi");

//	}
//	#endregion

//	public void chuanshuUi(){
//		main_ui.SetActive (false);
//		chuanshu_ui.SetActive (true);
//		chuanshu_reward_over.SetActive (false);

//	}

//	#region equipUi
//	public void equipUi(){
//		//Debug.Log ("进入equipUi");
//		QiYuPage.SetActive (false);
//		WuLinPuPage.SetActive (false);
//		XueZhanPage.SetActive (false);

//		main_ui.SetActive (false);
//		backpack_ui.SetActive (false);
//		equip_ui.SetActive (true);

//		zhenrong_ui.SetActive (false);
//		jianghu_ui.SetActive (false);

//	}
//	#endregion




//	public void minshan_X(){
//		mingshan_ui.SetActive (false);
//		main_ui.SetActive (true);
//	}

//	public void findman_B(){
//		findman_ui.SetActive (true);
////		xunxia_ui.SetActive (false);
//		main_ui.SetActive (false);
//	}
//	public void youshang_B(){
//		youshang_ui.SetActive (true);
//		main_ui.SetActive (false);
//	}
//	public void qianzhuang_B(){
//		qianzhuang_ui.SetActive (true);
//		main_ui.SetActive (false);
//		borrowmoney_ui.SetActive (false);
//		savemoney_ui.SetActive (false);
//		save_ms.SetActive (false);
//	}
//	public void borrow_B(){
//		borrowmoney_ui.SetActive (true);
//	}
//	public void savems_B(){
//		save_ms.SetActive (true);
//	}
//	public void borrow_X(){
//		borrowmoney_ui.SetActive (false);
//	}
//	public void savems_X(){
//		save_ms.SetActive (false);
//	}
//	public void save_B(){
//		savemoney_ui.SetActive (true);
//	}
//	public void save_X(){
//		savemoney_ui.SetActive (false);
//	}
//	public void world_news_B(){
//		world_news.SetActive (true);
//		systems_news.SetActive (false);
//	}
//	public void systems_news_B(){
//		world_news.SetActive (false);
//		systems_news.SetActive (true);
//	}
//	public void test_w(){
//		world_news_state = 1;
//		worldnewsGet ("玩家1：我是玩家1");
//	}
//	void worldnewsGet(string worldnews){
//		world_word = worldnews;
//	}
//	public void test_s(){
//		systems_news_state = 1;
//		systemsnewsGet ("系统提示：********************************");
//	}
//	void systemsnewsGet(string systemsnews){
//		systems_word = systemsnews;
//	}

//	//升级  所需经验
//	void exp(){
//		exp_need = level * 10;
//		if (exp_now == exp_need) {
//			level += 1;
//			exp_now = 0;
//		}
//	}
////	public void getplayer(string player_id){
////		if (mp_.ContainsKey (player_id)) {
////		} else {
////			mp_ [player_id].mp_level = 1;
////
////		}
////
////	}

//	public void signinUi(){
//		signin_ui.SetActive (true);
//		main_ui.SetActive (false);
//		retroactive_tishi.SetActive (false);

//	}
//	public void signIn_ui_false(){
//		signin_ui.SetActive (false);
//		main_ui.SetActive (true);
//	}
//	public void clanding_X(){
//		clandingX_state = 1;
//		c_landing_ui.SetActive (false);
//	}

//	void Update () {
		

	




//		if (xunxiaui_state == 1) {
//			xunxia_ui.SetActive (true);
//			xunxiaui_state = 0;
//		}
//		if (xunxiaui_state == 2) {
//			xunxia_ui.SetActive (false);
//			xunxiaui_state = 0;
//		}
	


//		if (retroactive_tishi_state == 1) {
//			retroactive_tishi.SetActive (true);
//			retroactive_tishi_state = 0;
//		}
//		if (retroactive_tishi_state == 2) {
//			retroactive_tishi.SetActive (false);
//			retroactive_tishi_state = 0;
//		}
	
	
	
	
//		world_news_time -= Time.deltaTime;
//		if (world_news_time <= 0) {
//			world_news_state = 1;
//			worldnewsGet ("玩家1：我是玩家1");
//			world_news_time = 5f;
//		}



	
//	}
















}
