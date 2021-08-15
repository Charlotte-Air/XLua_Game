using UnityEngine;
using UnityEngine.UI;

[XLua.LuaCallCSharp]
public static class UnityExit
{
    /// <summary>
    /// Button事件监听
    /// </summary>
    /// <param name="button">按钮</param>
    /// <param name="callback">回调</param>
    public static void OnClickSet(this Button button, object callback )
    {
        XLua.LuaFunction func= callback as XLua.LuaFunction;
        button.onClick.RemoveAllListeners(); //所有事件清空
        button.onClick.AddListener(() =>    //重新监听
        {
            func?.Call();
        });
    }

    /// <summary>
    /// Slider事件监听
    /// </summary>
    /// <param name="button">按钮</param>
    /// <param name="callback">回调</param>
    public static void OnValueChangedSet(this Slider slider, object callback)
    {
        XLua.LuaFunction func = callback as XLua.LuaFunction;
        slider.onValueChanged.RemoveAllListeners(); //所有事件清空
        slider.onValueChanged.AddListener((float value) => //重新监听
        {
            func?.Call(value);
        });
    }

}