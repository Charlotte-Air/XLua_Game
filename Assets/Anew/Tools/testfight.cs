using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class testfight : MonoBehaviour {

    public GameObject[] allheroGO;
    public List<Hero> allhero   = new List<Hero>();
    public List<Hero> Mheros = new List<Hero>();
    public List<Hero> Eheros = new List<Hero>();
    public GameObject heroPrefab; 
    public GameObject panel ;
    public GameObject camSkill;
    public GameObject p1;
    Vector3 offset =  new Vector3(0,0,-5); 
    public class Hero
    {
        public string name;
        public int speed;
        public int side;
        public int volume; // 体积
        public GameObject go;
        public Vector3 initpos;
    }

    int index = 0;
	// Use this for initialization
	void Start () {
      //  Debug.Log(  camSkill.transform.position - p1.transform.position);
		for(int i = 0; i < 4; i++)
        {
            Hero temp = new Hero();
            temp.name = "M" + i ;
            temp.volume = 1;
            temp.side = -1;
            GameObject go_  = Instantiate(heroPrefab);
            go_.name = temp.name;
            go_.transform.position = new Vector3( 0 + 2.5f*i  , go_.transform.position.y  , 2f);
            go_.transform.LookAt(new Vector3(go_.transform.position.x, go_.transform.position.y, 1));
            temp.go = go_;
            temp.initpos = go_.transform.position;
		
            Mheros.Add(temp);
            allhero.Add(temp);
        }

        for (int i = 0; i < 4; i++)
        {
            Hero temp = new Hero();
            temp.name = "E" + i; 
            temp.volume = 1; 
            temp.side = 1;
            GameObject go_ = Instantiate(heroPrefab);
            go_.name = temp.name;
            go_.transform.position = new Vector3(0 + 2.5f * i, go_.transform.position.y, -2f);
            go_.transform.LookAt(new Vector3(go_.transform.position.x, go_.transform.position.y, -1));
            temp.go = go_;
            temp.initpos = temp.go.transform.position;
            Eheros.Add(temp);
            allhero.Add(temp);
        }

         


    }
	
	// Update is called once per frame
	void Update () {
	        	
	}
    public void clickFight()
    {
        panel.SetActive(false);
        // Destroy(allhero[index % 8].go);
        Hero next = allhero[index % 8];
        
        if (next.side == -1)
        {
            atk_Action(next, Eheros[Random.Range(0, 4)]);
        }
        else
        {
            atk_Action(next, Mheros[Random.Range(0, 4)]);
        }    

        //(1, 10);


        index++;
    }
    public void clickSkill()
    {
        panel.SetActive(false);
        // Destroy(allhero[index % 8].go);
        Hero next = allhero[index % 8];

        if (next.side == -1)
        {

            skill_Action(next, Eheros[Random.Range(0, 4)]);
        }
        else
        {
            skill_Action(next, Mheros[Random.Range(0, 4)]);
        }

        //(1, 10);


        index++;
    }

    public void clickManaOne()
    {
        panel.SetActive(false);
        // Destroy(allhero[index % 8].go);
        Hero next = allhero[index % 8];

        if (next.side == -1)
        {

            skill_Mana_Action(next, Eheros[Random.Range(0, 4)]);
        }
        else
        {
            skill_Mana_Action(next, Mheros[Random.Range(0, 4)]);
        }

        //(1, 10);


        index++;
    }


    public void skill_Mana_Action(Hero akter, Hero target)
    {
        camSkill.transform.position = akter.go.transform.position + akter.go.transform.forward*5;
        camSkill.transform.LookAt(akter.go.transform.position);
        camSkill.GetComponent<Camera>().depth = 10;
        akter.go.transform.DOScale(new Vector3(1f, 1f, 1f), 1.5f).OnComplete(delegate
        {
            
            camSkill.transform.position = target.go.transform.position + target.go.transform.forward * 5; ;
            camSkill.transform.LookAt(target.go.transform.position);

            akter.go.transform.DOScale(new Vector3(1f, 1f, 1f), 1.5f).OnComplete(delegate
            {
                camSkill.GetComponent<Camera>().depth = -10;
                panel.SetActive(true);


            });
        });

    }
    public  void skill_Action(Hero akter , Hero target)
    {
        camSkill.transform.position = akter.go.transform.position + akter.go.transform.forward * 5;
        camSkill.transform.LookAt(akter.go.transform.position);
        camSkill.GetComponent<Camera>().depth = 10;
        akter.go.transform.DOScale(new Vector3(1f, 1f, 1f),1f).OnComplete(delegate
        {
          
            camSkill.GetComponent<Camera>().depth = -10;
            //  
            akter.go.transform.DOMove(target.go.transform.position, 0.3f).OnComplete(delegate
            {
                akter.go.transform.DOMove(akter.initpos, 0.3f).SetDelay(0.5f).OnComplete(delegate {
                    panel.SetActive(true);
                });

            });
        }); 

    }
    public void atk_Action(Hero akter, Hero target)
    {
       
            //  
            akter.go.transform.DOMove(target.go.transform.position, 0.3f).OnComplete(delegate
            {
                akter.go.transform.DOMove(akter.initpos, 0.3f).SetDelay(0.5f).OnComplete(delegate {
                    panel.SetActive(true);
                });

            }); 



        // 再返回


    }
    public void move()
    {
        
    }

   










} 
