using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ResourceAttribute
{
    public string name;
    public string path;
    public string abname;
    public ResourceType rtype;
    public string nextPages;

}

public enum ResourceType
{
    Sprite = 1,
    Prefab = 2,
    // 可重复生成的预制体
    Module = 3,
    //功能模块
    GameObject = 4
    // 不属于 2和3的游戏体
}

public class ResourceManager
{
    

    public enum UIType
    {
        ROOT = 1,
        MAIN = 2,
        SECOND = 3,
        POP = 4
    }


#if UNITY_5 || UNITY_2017 || UNITY_2019
#if UNITY_ANDROID && !UNITY_EDITOR
        static string pathRoot = LoadTools.assetBundlePath ;       // Application.dataPath + "!assets" ;
         static string     assetBundlePath= "";
#elif UNITY_IOS && !UNITY_EDITOR  
	static string pathRoot = LoadTools.assetBundlePath ;       // Application.dataPath + "!assets" ;
	static string     assetBundlePath= ""; 

#else
    static string assetBundlePath = "/AssetBundles";
    static string pathRoot = Application.dataPath ;
    #endif
#endif


    public static Dictionary<string, Sprite> DicSprite = new Dictionary<string, Sprite>();

    public static Dictionary<string, ResourceAttribute> DicRecource = new Dictionary<string, ResourceAttribute>();

	public static Dictionary<string, Sprite> allSprite = new Dictionary<string, Sprite>(); 
    public static Dictionary<string, GameObject> allPrefab = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> allGameObject = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> allModule = new Dictionary<string, GameObject>();
    public static  Dictionary<string , AssetBundle> allAssetBundle = new Dictionary<string, AssetBundle>();
    public static  Dictionary<string , byte[]> allLuaByte = new Dictionary<string,  byte[]>();
    public static  Dictionary<string ,AudioClip> allAudioClip = new Dictionary<string,  AudioClip>();
	public static Dictionary<string, Font> allFont = new Dictionary<string, Font>();
	public static Dictionary<string, Texture> allTexture = new Dictionary<string, Texture>(); 






    static string Type = "one";

   public static string luaFileName ; // 更新下来的 lua ab文件的名字，每次更新后都不一样，后拼着md5等
     public static void InitFontResource(string name)
    {
    	  AssetBundle ab = Load(name); 
        // ab.LoadAsset<Font>(key);
        //  allFont.Add(temp,  System.Text.UTF8Encoding.Default.GetBytes (ab.LoadAsset<TextAsset>(abs[i]).text   )     );
    }
    public static void InitSpriteResource(string name)
    {
        // 公告放到base里，所以不需要专门解析base
        ////Debug.Log("InitSpriteResource ****** ");
        //AssetBundle ab = Load("base");
        //string[] abs = ab.GetAllAssetNames();
        //for (int i = 0; i < abs.Length; i++)
        //{
        //    SetAsset(abs[i], ab);
        //}
        
    }


    public static string[] GetNextPages(string name)
    {
      
        // ////Debug.Log("GetNextPages " + name);
        string temp = DicRecource[name].nextPages;
        

        return temp.Split('*');
    }
	static Texture GetTexture(string key ,string path){

		path = path.ToLower();

		if (allTexture.ContainsKey( key))
		{
			////Debug.Log("存在Sprite " + key); 
			return allTexture[ key];
		}
		else
		{   
			if(allAssetBundle.ContainsKey("Texture")){
				SetAssetOne("Texture",key,"Texture", allAssetBundle["Texture"]);
			}else{
				AssetBundle ab = Load("Texture"); 

				allAssetBundle["Texture"] = ab;
				SetAssetOne("Texture",key,"Texture", ab);
			}

		 
			return allTexture[ key];
		}
	}
	public static Texture GetTexturePath(string key, string path)
	{ 
		//Debug.Log("public GetModule 2 " + key  );
		if (!GameConfig.UseAssetsBundle)
		{
			#if UNITY_EDITOR 
                       
                        
			return   AssetDatabase.LoadAssetAtPath<Texture>("Assets/AssetBundlesLocal/texture/"  + key + ".png");
			#else 
			return GetTexture(key,path);
			#endif
		}
		else
		{

			return GetTexture(key,path);
		}
	}



      static Sprite GetSprite(string key ,string path )
    {  path = path.ToLower();
        
        if (allSprite.ContainsKey(path+"_"+key))
        {
            ////Debug.Log("存在Sprite " + key); 
            return allSprite[path+"_"+key];
        }
        else
        {  
            // if (Type.Equals("one"))
            // { 
                if(allAssetBundle.ContainsKey(path)){
                     SetAssetOne("Sprite",key,path, allAssetBundle[path]);
                }else{
                     AssetBundle ab = Load(path); 
                     
                    allAssetBundle[path] = ab;
                    SetAssetOne("Sprite",key,path, ab);
                }
                  
                // }

            
            // }else
            // {
            //     AssetBundle ab = Load(DicRecource[key].abname);
            //     string[] abs = ab.GetAllAssetNames();
            //     for (int i = 0; i < abs.Length; i++)
            //     {
            //         SetAsset(abs[i], ab);
            //     }
            // } 
            return allSprite[path+"_"+key];
        }
    }
 public static  AudioClip LoadAudioClip(string path, string name)
    {
#if UNITY_EDITOR
      
            return AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/AssetBundlesLocal/" + path + "/" + name + ".mp3");
      
#endif

        return GetAudioClip(name , path );
    }
    public static AudioClip LoadAudioClipWAV(string path, string name)
    {
#if UNITY_EDITOR

        return AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/AssetBundlesLocal/" + path + "/" + name + ".wav");

#endif

        return GetAudioClip(name, path);
    }


    static AudioClip GetAudioClip(string key ,string path )
    {  path = path.ToLower();
        
        if (allSprite.ContainsKey(path+"_"+key))
        {
            ////Debug.Log("存在Sprite " + key); 
            return allAudioClip[path+"_"+key];
        }
        else
        {  
            // if (Type.Equals("one"))
            // { 
                if(allAssetBundle.ContainsKey(path)){
                     SetAssetOne("AudioClip",key,path, allAssetBundle[path]);
                }else{
                     AssetBundle ab = Load(path); 
                     
                    allAssetBundle[path] = ab;
                    SetAssetOne("AudioClip",key,path, ab);
                }
                  
                // }

            
            // }else
            // {
            //     AssetBundle ab = Load(DicRecource[key].abname);
            //     string[] abs = ab.GetAllAssetNames();
            //     for (int i = 0; i < abs.Length; i++)
            //     {
            //         SetAsset(abs[i], ab);
            //     }
            // } 
            return allAudioClip[path+"_"+key];
        }
    }




    
    public static Sprite GetSpritePath(string key, string path)
    {
        //Debug.Log("Assets/AssetBundlesLocal/Sprite/public" + "/" + path + "/" + key + ".png");
        if (!GameConfig.UseAssetsBundle)
        {
            #if UNITY_EDITOR 
           
            return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/AssetBundlesLocal/Sprite/public"+ "/" + path + "/" + key + ".png");
             #else 
               return GetSprite(key,path);
             #endif
        }
        else
        {

            return GetSprite(key,path);
        }
    } 
     public static void SetAssetOne( string type , string key ,string path , AssetBundle  ab )
    {
        Debug.Log("SetAssetOne key === " + key );
        Debug.Log("SetAssetOne type === " + type );
        Debug.Log("SetAssetOne path === " + path );

        if (type == "GameObject")
        {
            allGameObject[path+"_"+key] = ab.LoadAsset<GameObject>(key);
        }
        else if (type == "Sprite")
        {  
            allSprite[path+"_"+key] = ab.LoadAsset<Sprite>(key);
        }
        else if (type == "Prefab")
        {
            allPrefab[path+"_"+key] = ab.LoadAsset<GameObject>(key);
        }
        else if (type == "Module")
        {
            allModule[path+"_"+key] = ab.LoadAsset<GameObject>(key);
        }
         else if (type == "AudioClip")
        {
            allAudioClip[path+"_"+key] = ab.LoadAsset<AudioClip>(key);
		}
		else if (type == "Texture")
		{
			allTexture[ key] = ab.LoadAsset<Texture>(key);
		}
         //  allAssetBundle[ path ] = ab;
    } 




   static GameObject GetPrefab(string key ,string path )
    {  path = path.ToLower();
 
            Debug.LogError(path + "   GetPrefab    key  " +key);
       
        if (allPrefab.ContainsKey(path+"_"+key))
        {
            ////Debug.Log("存在Sprite " + key); 
            return allPrefab[path+"_"+key];
        }
        else
        {      if(allAssetBundle.ContainsKey(path)){
                     SetAssetOne("Prefab",key,path, allAssetBundle[path]);
                }else{
                    AssetBundle ab = Load(path);
                    allAssetBundle[path] = ab;
                    SetAssetOne("Prefab",key,path, ab);
                }
                
            return allPrefab[path+"_"+key];
        }
    }


   static GameObject GetGameObject(string key ,string path )
    {    path = path.ToLower();
              Debug.LogError(path + "   GetGameObject    key  " +key);
       
        if (allGameObject.ContainsKey(path+"_"+key))
        {
            ////Debug.Log("存在Sprite " + key); 
            return allGameObject[path+"_"+key];
        }
        else
        {      if(allAssetBundle.ContainsKey(path)){
                     SetAssetOne("GameObject",key,path, allAssetBundle[path]);
                }else{
                    AssetBundle ab = Load(path);
                    
                    allAssetBundle[path] = ab;
                   // allAssetBundle[DicRecource[key].abname] = ab;
                    SetAssetOne("GameObject",key,path, ab);
                }
            return allGameObject[path+"_"+key];
        }
    }
   static GameObject GetModule(string key ,string path )
    {       Debug.Log( "   GetModule  path = "+path +"  key = " +key);

        path = path.ToLower();
        if (allModule.ContainsKey(path+"_"+key))
        {
            Debug.Log(" have Module " + path+"_"+key); 
            return allModule[path+"_"+key];
        }
        else
        
        {      if(allAssetBundle.ContainsKey(path)){

                     Debug.Log("ContainsKey GetModule  " + path);   
                     SetAssetOne("Module",key,path, allAssetBundle[path]);
                }else{
                    
                     Debug.Log("!ContainsKey GetModule  " + path);   
                    AssetBundle ab = Load(path);
                    
                    allAssetBundle[path] = ab;
                   // allAssetBundle[DicRecource[key].abname] = ab;
                    SetAssetOne("Module",key,path, ab);
                }
            return allModule[path+"_"+key];
        }
    }












    public static GameObject GetPrefabPath(string key, string path)
    { 
        if (!GameConfig.UseAssetsBundle)
        {
            #if UNITY_EDITOR 
           
            return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/AssetBundlesLocal/Prefab/" + path + "/" + key + ".prefab");
             #else 
               return GetPrefab(key,path);
             #endif
        }
        else
        {

            return GetPrefab(key,path);
        }
    }



    public static GameObject GetModulePath(string key, string path)
    {
        //Debug.Log("public GetModule 2 " + key  );
        if (!GameConfig.UseAssetsBundle)
        {
            #if UNITY_EDITOR 
           
            return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/AssetBundlesLocal/Module/" + path + "/" + key + ".prefab");
             #else 
               return GetModule(key,path);
             #endif
        }
        else
        {

            return GetModule(key,path);
        }
    } 
    public static GameObject GetGameObjectPath(string key, string path)
    {
        if (!GameConfig.UseAssetsBundle)
        {    
           #if UNITY_EDITOR 
                  return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/AssetBundlesLocal/Prefab/" + path + "/" + key + ".prefab");
            #else  
                 return GetGameObject(key,path);
            #endif
        }
        else
        {

            return GetGameObject(key,path);
        }
    } 

    public static Sprite LoadSprite(string Path)
    {
//        //Debug.Log("ResourceManager的LoadSprite的Path=" + Path);
        if (Resources.Load<GameObject>("Sprites/" + Path) != null)
        {
            return Resources.Load<GameObject>("Sprites/" + Path).GetComponent<Image>().sprite;
        }
        else
        {
            return null;
        }
       
    }


    static public AssetBundle Load(string name)
    {
        Debug.Log(" Load  **************** name = " + name);  //+ pathRoot + assetBundlePath + "/" 
        //  return AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + name+".ud");
// if  (name == "mainui"){
//     Debug.Log("****************  load mainui " );
// }
        Debug.Log("*******yy "+LoadTools.assetBundlePath + "/" +  name);
         Debug.Log("Load ****  " + pathRoot + assetBundlePath + "/" + name);
        return AssetBundle.LoadFromFile(pathRoot + assetBundlePath + "/" +name);
        
    }


	//储存格式： 玩家账号|音乐|音效|是否跟随|是否显示聊天|同屏玩家 
    public static string GetPlayerData(){  
        string baseDate = "";
        if (PlayerPrefs.HasKey("baseDate")) {
            baseDate = PlayerPrefs.GetString("baseDate"); 
        }else{
            baseDate = " |1|1|0|1|1|ip";
        }
        return baseDate;
     }
     public static void SetPlayerData(string str){
       PlayerPrefs.SetString("baseDate",str); 
     }



     //设置引导位置
     public static void SetGuidePos(GameObject GuiObj,string posID,string posX,string posW){
        //入参posID  1 = Left  2 = Right  3 = top  4 = bottom
        float X = float.Parse(posX);
        float W = float.Parse(posW); 
        if (posID == "1"){
             GuiObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, X, W);   
        }else if (posID == "2"){
             GuiObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, X, W);     
        }else if (posID == "3"){
             GuiObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, X, W);  
        }else if (posID == "4"){
             GuiObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, X, W);    
        }
     }
 


    // static private void  SetAsset(string key, AssetBundle ab)
    // {
    //     string[] A_temporarymission = key.Split('.')[0].Split('/');
    //     key = A_temporarymission[A_temporarymission.Length - 1];
        
    //     //foreach (KeyValuePair<string, ResourceAttribute> pair in DicRecource)
    //     //{
    //     //    //  ////Debug.Log(pair.Key + " ****  " + pair.Value);
    //     //}

    //     if (!(DicRecource.ContainsKey(key)))
    //     {
    //         //Debug.LogRes("SetAsset error key "+key);
    //         return;
    //     }
    
    //     ////Debug.Log(" SetAsset key " + key + " rtype = " + DicRecource[key].rtype);
    //     ////Debug.Log(key+"  DicRecource[key].rtype " + DicRecource[key].rtype);
    //     if (DicRecource[key].rtype == ResourceType.GameObject)
    //     {
    //         allGameObject[key] = ab.LoadAsset<GameObject>(key);
    //     }
    //     else if (DicRecource[key].rtype == ResourceType.Sprite)
    //     {
    //         allSprite[key] = ab.LoadAsset<Sprite>(key);
    //     }
    //     else if (DicRecource[key].rtype == ResourceType.Prefab)
    //     {
    //         allPrefab[key] = ab.LoadAsset<GameObject>(key);
    //     }
    //     else if (DicRecource[key].rtype == ResourceType.Module)
    //     {
    //         allModule[key] = ab.LoadAsset<GameObject>(key);
    //     }


    // }

//  public static void TestLuaABLoad(string name){
//       // 清空原来的lua目录
//         string p = LoadTools.assetBundlePath + "/assets/lua" ; // 这里只考虑 安卓，PC并不需要更新lua
//         if (Directory.Exists(p) == true){ 
//             Directory.Delete(p, true);
//         }
//            Debug.Log("p " + p );
//         Directory.CreateDirectory(p);
//            Debug.Log("CreateDirectory  sucsess "  ); 
//  Debug.Log("name **********"  + name);
//           AssetBundle ab = Load(name); //"lua_945ca74524bdea802078acbf98db6f0b"
        
//                 string[] abs = ab.GetAllAssetNames();
//                 for (int i = 0; i < abs.Length; i++)
//                 {   Debug.Log("abs[i] " + abs[i]);
//                   // LoadLuaAndSave(abs[i],ab);
                 
//                 }
//     }


// public static void LoadLuaAndSave( string name , AssetBundle ab){ 
//   #if UNITY_5 || UNITY_2017 || UNITY_2019
//    #if UNITY_ANDROID && !UNITY_EDITOR  
//         string name_ = name;
//       //  判断/ 长度是否大于2，大于的， 取出前面的部分创建目录。 然后写入文件。
//         int i = name.LastIndexOf('/'); //取出最后一个/
//         name = name.Substring(0,i );
//         //Debug.Log("zero dir   " +name); 
//         name = LoadTools.assetBundlePath +"\\"+name.Replace('\\','/');

//         name = name.Replace('\\','/');
//          Debug.Log("android create dir   " +name);
         
//             if (Directory.Exists(name) == false)  
//                 Directory.CreateDirectory(name);
         
//         string[] temp2 =  name_.Split('/');
      
//         string path =   name +"\\"+ temp2[temp2.Length- 1] ;
//         path = path.Replace('\\','/');
        
//          Debug.Log("android write file   " + path);
//         File.WriteAllText(  path  , ab.LoadAsset<TextAsset>(name_).text ,new System.Text.UTF8Encoding(false));
//     #else 
//          string name_ = name;
//       //  判断/ 长度是否大于2，大于的， 取出前面的部分创建目录。 然后写入文件。
//         int i = name.LastIndexOf('/'); //取出最后一个/
//         name = name.Substring( 0,i );
//         Debug.Log("zero dir   " +name); 
//         name = LoadTools.assetBundlePath +"\\"+name.Replace('\\','/');
//         Debug.Log("create dir   " +name);
         
//             if (Directory.Exists(name) == false)  
//                 Directory.CreateDirectory(name);
         
//         string[] temp2 =  name_.Split('/');
//         Debug.Log("write file   "+ name +"\\" + temp2[temp2.Length- 1]);
//         File.WriteAllText(  name +"\\"+ temp2[temp2.Length- 1] 
//                 , ab.LoadAsset<TextAsset>(name_).text ,new System.Text.UTF8Encoding(false));
      
//     #endif
    
//   #endif
    

    
// }

 public static   void  loadLuaToByte( string name   ){ 
     
     Debug.Log(" loadLuaToByte name  "+ name);
       AssetBundle ab = Load(name);  
        string[] abs = ab.GetAllAssetNames();
     Debug.Log(" loadLuaToByte name2  "+ name);
                for (int i = 0; i < abs.Length; i++)
                {    
               Debug.Log(" abs[i]  "+ abs[i]);
                //    string[] temp2 =  abs[i].Split('/'); 
                //    string temp =  temp2[temp2.Length- 1] ; 

                 string  temp = abs[i].Substring(11 );
                      temp = temp.Substring(0 , temp.Length-8);

                       
                            // Debug.Log(" key ***************  "+(  temp));  
                       
  


 
               //   if ( allLuaByte.ContainsKey(temp.Substring(0,temp.Length-8) )){
                    if ( allLuaByte.ContainsKey( temp)){

                     return ;
                 }
              //    allLuaByte.Add( temp.Substring(0,temp.Length-8) ,  System.Text.UTF8Encoding.Default.GetBytes (ab.LoadAsset<TextAsset>(abs[i]).text   )     );
                   
                 allLuaByte.Add(temp,  System.Text.UTF8Encoding.Default.GetBytes (ab.LoadAsset<TextAsset>(abs[i]).text   )     );
                 if(abs[i].IndexOf("login") !=-1){
   Debug.Log("**********loadLuaToByte  ** name  ************  "+abs[i]);
                 }
             
                }
     
    }

}
