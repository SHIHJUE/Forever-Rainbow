using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamecontroll : MonoBehaviour {
	public int playerlife;
	public TextMesh lifetext;
    
    public TextMesh starttxt;
    
    public bool canmove;
    public bool ispause = false;
    public static bool isstart=true;
    
	public float time;
    public static int level;
	
    public static int planetint;
    public static float vol = 0.5f;
    public AudioSource bgm;
    public Animation lose;
    void Start() {
        StartCoroutine(delayrun());
        bgm.volume = vol;
    }
	void Update () {

        if (!ispause)
        {
            lifetext.text = "Life:" + playerlife;
            
            if (playerlife < 0)
                playerlife = 0;
            else if (playerlife == 0)
            {
                ispause = true;
                isstart = false;
                lose.gameObject.SetActive(true);
                lose.Play("clearanim");
                bgm.volume -= Time.deltaTime;
                if (bgm.volume < 0)
                    bgm.volume = 0;
                StartCoroutine(returnhome(4f));

            }
            
        }
          
	}
    public IEnumerator delayrun()
    {
        starttxt.text = "1";
        
        yield return new WaitForSeconds(1f);
        starttxt.text = "2";
        
        yield return new WaitForSeconds(1f);
        starttxt.text = "3";
        
        yield return new WaitForSeconds(1f);
        starttxt.text = "Start";
        
        yield return new WaitForSeconds(1f);
        starttxt.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        canmove = true;

    }
    public IEnumerator delaychagescene(float delaytime,int i){
		yield return new WaitForSeconds(delaytime);
		SceneManager.LoadSceneAsync (i);
	}

    public IEnumerator returnhome(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        SceneManager.LoadSceneAsync (5);
        
	}
}

