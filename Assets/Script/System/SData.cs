using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstData  {
     
    public static Dictionary<string, float> SdataDic = new Dictionary<string, float>();
    public static Dictionary<string, string> SdataDic2 = new Dictionary<string, string>();
    public static float get(string id)
    {
        return SdataDic[id];
    }
}
