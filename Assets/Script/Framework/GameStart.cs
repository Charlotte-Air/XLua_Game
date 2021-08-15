using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [Header("模式")]
    public GameMode GameMode;
    [Header("Loading")]
    public Text txtVersion;
    public Text txtRes;
    public Text txtSize;
    public Text txtSize2;
    public Text txtSpeed;
    public Slider progressBar1;
    public Slider progressBar2;
    public GameObject Tip;

    void Start()
    {
        StartLogin();
    }

    private void StartLogin()
    {
        progressBar1.value = 0f;
        progressBar2.value = 0f;
        StartCoroutine(InitGame());
    }

    private IEnumerator InitGame()
    {
        txtRes.gameObject.SetActive(false);
        txtRes.text = "游戏初始化";
        progressBar1.gameObject.SetActive(true);
        progressBar2.gameObject.SetActive(true);
        txtSize2.gameObject.SetActive(true);
        txtVersion.gameObject.SetActive(true);
        txtSpeed.gameObject.SetActive(false);
        txtSize.gameObject.SetActive(false);

        for (float i = 1; i < 100;)
        {
            i += Random.Range(0.1f, 0.5f);
            progressBar1.value = i;
            progressBar2.value = i;
            txtSize2.text = (int) i + "%";
            yield return new WaitForEndOfFrame();
        }

        LoadTools.Init();
        GameObject go = Resources.Load<GameObject>("Main");
        Instantiate(go);
        Destroy(this.gameObject);
        AppBoot.instance.Init();
    }


    public class AssetBundleInfo
    {
        public string name;
        public string md5;
        public float size;
        public int type;
        public int level;
        public AssetBundleInfo(int type, string name, string md5, float size, int level)
        {
            this.type = type;
            this.name = name;
            this.size = size;
            this.md5 = md5;
            this.level = level;
        }
    }

}

