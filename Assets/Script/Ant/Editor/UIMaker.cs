using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class UImaker : EditorWindow
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles",BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.Android);
      //  BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
        // BuildPipeline.BuildAssetBundles("Assets/AssetBundles");
    }



    [MenuItem("GameTools/CreateUI")]
    public static void ConfigDialog()
    {
        EditorWindow.GetWindow(typeof(UImaker));
    }

    public UnityEngine.Object go = null;

    string name = "";
    string path = "";
    
    int buttonNum = 1;
  //  float life = 100f;
 //   bool isAlive = true;
    bool isMain = true;
    bool isSecond = false;
    bool isPop = false;
    bool containOut = false;
    bool toggleEnabled;
    void OnGUI()
    {
        //Label  
        GUILayout.Label("页面选项", EditorStyles.boldLabel);
        //通过EditorGUILayout.ObjectField可以接受Object类型的参数进行相关操作  
       // go = EditorGUILayout.ObjectField(go, typeof(UnityEngine.Object), true);
        //Button  
       
        buttonNum = int.Parse( EditorGUILayout.TextField("按钮数量", buttonNum + ""));
        containOut = EditorGUILayout.Toggle("containOut", containOut);
        isMain = EditorGUILayout.Toggle("Main", isMain);
        isSecond = EditorGUILayout.Toggle("Second", isSecond);
        isPop = EditorGUILayout.Toggle("Pop", isPop);
        
        if (isMain)
        {
            isPop = isSecond = false; 
        }
        else if (isSecond)
        {
            isMain = isPop = false;
        }
        else if (isPop)
        {
            isMain = isSecond = false;
        }
        if (GUILayout.Button("创建按钮"))
        { 
                //Debug.Log(go.name); 
        }
        //toggleEnabled = EditorGUILayout.BeginToggleGroup("optional settings", toggleEnabled);
        //if (toggleEnabled)
        //{
        //    isAlive = EditorGUILayout.Toggle("isalive", isAlive);
        //    life = EditorGUILayout.Slider("life", life, 0, 100);
        //}
        //EditorGUILayout.EndToggleGroup();
    }



}