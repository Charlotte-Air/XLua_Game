using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EditorBase : EditorWindow
{
    protected float width, height;
    protected float splitLineHeight = 5;
    private Vector2 scrollPosition;
    private void OnGUI ( )
    {
        width = height > Screen.height ? Screen.width - 15 : Screen.width;
        //scrollPosition = GUI.BeginScrollView(new Rect(0, 0, Screen.width, Screen.height), scrollPosition, new Rect(0, 0, Screen.width, height));
        height = 0;
        OnEditor ( );
        //GUI.EndScrollView();
    }
    protected virtual void OnEditor ( ) { }
    protected void SplitLine ( )
    {
        Color color = GUI.backgroundColor;
        GUI.backgroundColor = Color.grey;
        GUILayout.Button ( "", GUILayout.Height ( splitLineHeight ) );
        GUI.backgroundColor = color;
    }
    protected bool Button ( string text, Color color, int fontSize, bool enable, params GUILayoutOption[] options )
    {
        Color _color = GUI.backgroundColor;
        int _fontSize = GUI.skin.button.fontSize;
        GUI.backgroundColor = enable ? color : Color.grey;
        GUI.skin.button.fontSize = fontSize;
        bool result = GUILayout.Button ( text, options );
        GUI.backgroundColor = _color;
        GUI.skin.button.fontSize = _fontSize;
        return result && enable;
    }
    protected int IntField ( string text, float labelWidth, int fontSize, int value, int minValue, int maxValue, bool enable, params GUILayoutOption[] options )
    {
        int _fontSize = GUI.skin.textField.fontSize;
        Color color = GUI.backgroundColor;
        GUI.backgroundColor = enable ? color : Color.grey;
        GUI.skin.textField.fontSize = fontSize;
        EditorGUIUtility.labelWidth = labelWidth;
        int result = EditorGUILayout.IntField ( text, value, options );
        GUI.skin.textField.fontSize = _fontSize;
        GUI.backgroundColor = color;
        return enable ? Mathf.Clamp ( result, minValue, maxValue ) : value;
    }
    protected float PercentField ( string text, float labelWidth, int fontSize, float value, int minValue, int maxValue, bool enable, params GUILayoutOption[] options )
    {
        int _fontSize = GUI.skin.textField.fontSize;
        Color color = GUI.backgroundColor;
        GUI.backgroundColor = enable ? color : Color.grey;
        GUI.skin.textField.fontSize = fontSize;
        EditorGUIUtility.labelWidth = labelWidth;
        int _rs=(int)( value * 100 );
        _rs = EditorGUILayout.IntField ( text, _rs, options );
        float result = _rs / 100f;
        GUI.skin.textField.fontSize = _fontSize;
        GUI.backgroundColor = color;
        return enable ? Mathf.Clamp ( result, minValue / 100f, maxValue / 100f ) : value;
    }

    protected void Label ( string text, Color color, int fontSize, TextAnchor alignment, params GUILayoutOption[] options )
    {
        Color _color = GUI.skin.label.normal.textColor;
        int _fontSize = GUI.skin.label.fontSize;
        TextAnchor _alignment = GUI.skin.label.alignment;
        GUI.skin.label.normal.textColor = color;
        GUI.skin.label.fontSize = fontSize;
        GUI.skin.label.alignment = alignment;
        GUILayout.Label ( text, options );
        GUI.skin.label.normal.textColor = _color;
        GUI.skin.label.fontSize = _fontSize;
        GUI.skin.label.alignment = _alignment;
    }
    protected bool Toggle ( bool value, string text, bool enble, params GUILayoutOption[] options )
    {
        Color color = GUI.backgroundColor;
        GUI.backgroundColor = enble ? color : Color.grey;
        bool result = GUILayout.Toggle ( value, text, options );
        GUI.backgroundColor = color;
        return enble ? result : value;
    }

    public static T[] GetSelectedPrefabs<T>(GameObject obj)
    {
        T[] result = obj.GetComponentsInChildren<T>(true);
        return result;
    }

    public static GameObject[] GetSelectedPrefabs()
    {
        UnityEngine.Object[] prefabs = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);

        List<GameObject> result = new List<GameObject>();
        Debug.Log(prefabs.Length);
        foreach (UnityEngine.Object obj in prefabs)
        {
            if (obj is GameObject)
            {

                GameObject prefab = obj as GameObject;
                result.Add(prefab);
            }
        }

        return result.ToArray();
    }
}
