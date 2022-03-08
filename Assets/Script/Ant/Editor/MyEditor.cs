using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
//using Spine;
//using Spine.Unity;
using UnityEngine.UI;

public class MyEditor : EditorWindow
{

    /// <summary>
    /// 临时存储int[]
    /// </summary>
    private int[] IntArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7,8,9,10 };
    //Filter Mode
    private int ArrangementInt = 0;
    private string[] ArrangementString = new string[] { "Horizontal", "Vertical", "CellSnap" };

    private int PivotInt = 0;
    private string[] PivotString = new string[] { "TopLeft", "Top", "TopRight", "Left", "Center", "Right", "BottomLeft", "Bottom", "BottomRight" };

    private int PlaneDir = 0;
    private string[] PlaneDirStr = { "x-y", "x-z", "y-z" };


     [MenuItem("Tools/设置")]

    static void AddWindow()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 500, 500);
        MyEditor window = (MyEditor)EditorWindow.GetWindowWithRect(typeof(MyEditor), wr, true, "widow name");
        window.Show();

    }

    // private string materialPath;
     //private string depthStr = "0";
     //private int dep=1;
     bool setDepth = false, sortPos=false;

     private float  cellWidth = 10, cellHeight = 10;
     private int maxPerLine = 0;

     string nameStr;

    public void Awake()
    {

        //materialPath = "Spine/Bones";
    }
    AudioClip clip;
    [System.NonSerialized]
    Font font;
    //绘制窗口时调用
    void OnGUI()
    {
        //输入框控件
        setDepth = GUILayout.Toggle(setDepth, "批量设置层级");

        if (setDepth)
        {
            SetDepth();
        }

        sortPos = GUILayout.Toggle(sortPos, "位置排序");

        if (sortPos)
        {
            SortPostion();
        }
       
        clip= EditorGUILayout.ObjectField("按钮音乐",clip, typeof(Object),true) as AudioClip;
       // nameStr = EditorGUILayout.TextField("nameStr:", nameStr);
        if (GUILayout.Button("批量设置按钮音乐", GUILayout.Width(200)))
        {
            SetClip(clip);
        }
        font= EditorGUILayout.ObjectField("字体", font, typeof(Object), true) as Font;
        if (GUILayout.Button("批量字体", GUILayout.Width(200)))
        {
            SetFont(font);
        }
   
    }

    //更新
    void Update()
    {

    }

    private void SetClip(AudioClip clip)
    {
        GameObject[] prefabs = EditorBase.GetSelectedPrefabs();

        Debug.Log(prefabs.Length);
        foreach (GameObject obj in prefabs)
        {
            //string path = AssetDatabase.GetAssetPath(obj);

            GameObject prefab = obj as GameObject;

            EditorUtility.SetDirty(prefab);
        }
    }
    private void SetFont(Object f)
    {
        Font font = f as Font;
        GameObject[] prefabs = EditorBase.GetSelectedPrefabs();

        foreach (GameObject obj in prefabs)
        {
            //string path = AssetDatabase.GetAssetPath(obj);

            GameObject prefab = obj as GameObject;
            Text [] label= prefab.GetComponentsInChildren<Text>(true);

            for (int i = 0; i< label.Length; i++)
            {
                label[i].font=font ;
            }

            EditorUtility.SetDirty(prefab);
        }
    }

    void SetDepth()
    {

    }

    void SortPostion()
    {
        int arr = ArrangementInt;
        ArrangementInt = EditorGUILayout.IntPopup("Arrangement Mode", ArrangementInt, ArrangementString, IntArray);
        if (ArrangementInt != arr) PosSort();
        int piv = PivotInt;
        PivotInt = EditorGUILayout.IntPopup("Pivot Mode", PivotInt, PivotString, IntArray);
        if (PivotInt != piv) PosSort();
        int dir = PlaneDir;
        PlaneDir = EditorGUILayout.IntPopup("Plane Dir", PlaneDir, PlaneDirStr, IntArray);
        if (PlaneDir != dir) PosSort();

        GUILayout.BeginHorizontal();

        GUILayout.Label("maxPerLine:");

        float maxPerL = maxPerLine;
        maxPerLine = EditorGUILayout.IntSlider(maxPerLine, 0, 10 + maxPerLine);

        if (maxPerL != maxPerLine) PosSort();

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label("cellWidth:");
        float w = cellWidth;
        cellWidth = EditorGUILayout.Slider(cellWidth, -100 - cellWidth, 100 + cellWidth);

        if (w != cellWidth) PosSort();


        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label("cellHeight:");
     
        float h = cellHeight;
        cellHeight = EditorGUILayout.Slider(cellHeight, -100 - cellHeight, 100 + cellHeight);

        if (h != cellHeight) PosSort();

        GUILayout.EndHorizontal();
    }

    void PosSort()
    {
        // Debug.Log("--------" + Selection.gameObjects.Length); private string[] PlaneDirStr = { "x-y", "x-z", "y-z" };
         int x = 0;
         int y = 0;
         int maxX = 0;
         int maxY = 0;

         Transform[] child = Selection.gameObjects[0].GetComponentsInChildren<Transform>();
         for (int i = 0; i < child.Length; i++)
         {
             if (child[i].parent != Selection.gameObjects[0].transform) continue;
             Vector3 pos = child[i].localPosition;
             float depth = 0;
             if (PlaneDir == 0)
             {
                 depth = pos.z;
                 if (ArrangementInt == 2)
                 {
                     if (cellWidth > 0) pos.x = Mathf.Round(pos.x / cellWidth) * cellWidth;
                     if (cellHeight > 0) pos.y = Mathf.Round(pos.y / cellHeight) * cellHeight;
                 }
                 else pos = (ArrangementInt == 0) ?
                     new Vector3(cellWidth * x, -cellHeight * y, depth) :
                     new Vector3(cellWidth * y, -cellHeight * x, depth);
             }
             else if (PlaneDir == 1)
             {
                 depth = pos.y;
                 if (ArrangementInt == 2)
                 {
                     if (cellWidth > 0) pos.x = Mathf.Round(pos.x / cellWidth) * cellWidth;
                     if (cellHeight > 0) pos.y = Mathf.Round(pos.y / cellHeight) * cellHeight;
                 }
                 else pos = (ArrangementInt == 0) ?
                     new Vector3(cellWidth * x, depth, -cellHeight * y) :
                     new Vector3(cellWidth * y, depth, -cellHeight * x);

                // Debug.Log(y + "--------" + x + "--------" + pos);
             }
             else if (PlaneDir == 2)
             {
                 depth = pos.x;
                 if (ArrangementInt == 2)
                 {
                     if (cellWidth > 0) pos.x = Mathf.Round(pos.x / cellWidth) * cellWidth;
                     if (cellHeight > 0) pos.y = Mathf.Round(pos.y / cellHeight) * cellHeight;
                 }
                 else pos = (ArrangementInt == 0) ?
                     new Vector3(depth, cellWidth * x, -cellHeight * y) :
                     new Vector3(depth, cellWidth * y, -cellHeight * x);
             }

             child[i].localPosition = pos;
             maxX = Mathf.Max(maxX, x);
             maxY = Mathf.Max(maxY, y);

             if (++x >= maxPerLine && maxPerLine > 0)
             {
                
                 x = 0;
                 ++y;
                
             }
         }

        // new string[] { "TopLeft", "Top", "TopRight", "Left", "Center", "Right", "BottomLeft", "Bottom", "BottomRight" };
         Vector3 center=Vector3.zero;
         if (PlaneDir == 0)
         {
             if (PivotInt == 1)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 0.5f, cellHeight * maxY * 0.0f, 0) :
                        new Vector3(-cellWidth * maxY * 0.5f, cellHeight * maxX * 0.0f, 0);
             }
             else if (PivotInt == 2)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 1.0f, cellHeight * maxY * 0.0f, 0) :
                        new Vector3(-cellWidth * maxY * 1.0f, cellHeight * maxX * 0.0f, 0);
             }
             else if (PivotInt == 3)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(cellWidth * maxX * 0.0f, cellHeight * maxY * 0.5f, 0) :
                        new Vector3(cellWidth * maxY * 0.0f, cellHeight * maxX * 0.5f, 0);
             }
             else if (PivotInt == 4)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 0.5f, cellHeight * maxY * 0.5f, 0) :
                        new Vector3(-cellWidth * maxY * 0.5f, cellHeight * maxX * 0.5f, 0);
             }
             else if (PivotInt == 5)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 1.0f, cellHeight * maxY * 0.5f, 0) :
                        new Vector3(-cellWidth * maxY * 1.0f, cellHeight * maxX * 0.5f, 0);
             }
             else if (PivotInt == 6)
             {
                 center = (ArrangementInt == 0) ?
                       new Vector3(-cellWidth * maxX * 0.0f, cellHeight * maxY * 1.0f, 0) :
                       new Vector3(-cellWidth * maxY * 0.0f, cellHeight * maxX * 1.0f, 0);
             }
             else if (PivotInt == 7)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 0.5f, cellHeight * maxY * 1.0f, 0) :
                        new Vector3(-cellWidth * maxY * 0.5f, cellHeight * maxX * 1.0f, 0);
             }
             else if (PivotInt == 8)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 1.0f, cellHeight * maxY * 1.0f, 0) :
                        new Vector3(-cellWidth * maxY * 1.0f, cellHeight * maxX * 1.0f, 0);
             }

         }
         else if (PlaneDir == 1)
         {
             if (PivotInt == 1)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 0.5f, 0,cellHeight * maxY * 0.0f) :
                        new Vector3(-cellWidth * maxY * 0.5f,0, cellHeight * maxX * 0.0f);
             }
             else if (PivotInt == 2)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 1.0f, 0, cellHeight * maxY * 0.0f) :
                        new Vector3(-cellWidth * maxY * 1.0f, 0, cellHeight * maxX * 0.0f);
             }
             else if (PivotInt == 3)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(cellWidth * maxX * 0.0f, 0, cellHeight * maxY * 0.5f) :
                        new Vector3(cellWidth * maxY * 0.0f, 0, cellHeight * maxX * 0.5f);
             }
             else if (PivotInt == 4)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 0.5f, 0, cellHeight * maxY * 0.5f) :
                        new Vector3(-cellWidth * maxY * 0.5f, 0, cellHeight * maxX * 0.5f);
             }
             else if (PivotInt == 5)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 1.0f, 0, cellHeight * maxY * 0.5f) :
                        new Vector3(-cellWidth * maxY * 1.0f, 0, cellHeight * maxX * 0.5f);
             }
             else if (PivotInt == 6)
             {
                 center = (ArrangementInt == 0) ?
                       new Vector3(-cellWidth * maxX * 0.0f, 0, cellHeight * maxY * 1.0f) :
                       new Vector3(-cellWidth * maxY * 0.0f, 0, cellHeight * maxX * 1.0f);
             }
             else if (PivotInt == 7)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 0.5f, 0, cellHeight * maxY * 1.0f) :
                        new Vector3(-cellWidth * maxY * 0.5f, 0, cellHeight * maxX * 1.0f);
             }
             else if (PivotInt == 8)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(-cellWidth * maxX * 1.0f, 0, cellHeight * maxY * 1.0f) :
                        new Vector3(-cellWidth * maxY * 1.0f, 0, cellHeight * maxX * 1.0f);
             }
         }
         else if (PlaneDir == 2)
         {
             if (PivotInt == 1)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(0, -cellWidth * maxX * 0.5f, cellHeight * maxY * 0.0f) :
                        new Vector3(0, -cellWidth * maxY * 0.5f, cellHeight * maxX * 0.0f);
             }
             else if (PivotInt == 2)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(0, -cellWidth * maxX * 1.0f, cellHeight * maxY * 0.0f) :
                        new Vector3(0, -cellWidth * maxY * 1.0f, cellHeight * maxX * 0.0f);
             }
             else if (PivotInt == 3)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(0, cellWidth * maxX * 0.0f,  cellHeight * maxY * 0.5f) :
                        new Vector3(0, cellWidth * maxY * 0.0f,  cellHeight * maxX * 0.5f);
             }
             else if (PivotInt == 4)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(0, -cellWidth * maxX * 0.5f,  cellHeight * maxY * 0.5f) :
                        new Vector3(0, -cellWidth * maxY * 0.5f,  cellHeight * maxX * 0.5f);
             }
             else if (PivotInt == 5)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(0, -cellWidth * maxX * 1.0f,  cellHeight * maxY * 0.5f) :
                        new Vector3(0, -cellWidth * maxY * 1.0f,  cellHeight * maxX * 0.5f);
             }
             else if (PivotInt == 6)
             {
                 center = (ArrangementInt == 0) ?
                       new Vector3(0, -cellWidth * maxX * 0.0f,  cellHeight * maxY * 1.0f) :
                       new Vector3(0, -cellWidth * maxY * 0.0f,  cellHeight * maxX * 1.0f);
             }
             else if (PivotInt == 7)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(0, -cellWidth * maxX * 0.5f, cellHeight * maxY * 1.0f) :
                        new Vector3(0, -cellWidth * maxY * 0.5f,  cellHeight * maxX * 1.0f);
             }
             else if (PivotInt == 8)
             {
                 center = (ArrangementInt == 0) ?
                        new Vector3(0, -cellWidth * maxX * 1.0f,  cellHeight * maxY * 1.0f) :
                        new Vector3(0, -cellWidth * maxY * 1.0f,  cellHeight * maxX * 1.0f);
             }
         }
        for (int i = 0; i < child.Length; i++)
        {
            if (child[i].parent != Selection.gameObjects[0].transform) continue;

            child[i].localPosition += center;
        }
    }

    void OnFocus()
    {
       // Debug.Log("当窗口获得焦点时调用一次");
    }

    void OnLostFocus()
    {
        //Debug.Log("当窗口丢失焦点时调用一次");
    }

    void OnHierarchyChange()
    {
       // Debug.Log("当Hierarchy视图中的任何对象发生改变时调用一次");
    }

    void OnProjectChange()
    {
        //Debug.Log("当Project视图中的资源发生改变时调用一次");
    }

    void OnInspectorUpdate()
    {
        //Debug.Log("窗口面板的更新");
        //这里开启窗口的重绘，不然窗口信息不会刷新
        this.Repaint();
    }

    void OnSelectionChange()
    {
        //当窗口出去开启状态，并且在Hierarchy视图中选择某游戏对象时调用
        //foreach (Transform t in Selection.transforms)
        //{
        //    //有可能是多选，这里开启一个循环打印选中游戏对象的名称
        //    Debug.Log("OnSelectionChange" + t.name);
        //}
    }

    void OnDestroy()
    {
        Debug.Log("当窗口关闭时调用");
    }
    //private void LoopSetMaterial()
    //{
    //    Object[] AtlasAssets = GetSelectedMaterials();
    //    foreach (Material mMat in AtlasAssets)
    //    {
    //        mMat.shader = Shader.Find(materialPath);
    //        mMat.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f, 0.5f));

    //        string path = AssetDatabase.GetAssetPath(mMat);

    //        AssetDatabase.ImportAsset(path);
    //    }
    //}

    private Object[] GetSelectedPrefabs()
    {
        return Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
    }

    private void LoopSetSkeletonData()
    {

    }
    //private Object[] GetSelectedAtlasAssets()
    //{
    //    return Selection.GetFiltered(typeof(AtlasAsset), SelectionMode.DeepAssets);
    //}

    private Object[] GetSelectedMaterials()
    {
        return Selection.GetFiltered(typeof(Material), SelectionMode.DeepAssets);
    }
}
