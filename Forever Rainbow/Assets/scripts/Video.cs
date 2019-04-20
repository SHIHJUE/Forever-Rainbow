using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Video : MonoBehaviour {
    public GameObject[] movieclip;
    

	// Use this for initialization
	void Start () {
        if (gamecontroll.isstart)
        {
            StartCoroutine(delayloadseace(2,85f));
            movieclip[0].SetActive(true);
            gamecontroll.isstart = false;
        }

        else if (gamecontroll.planetint == 3)
        {
            movieclip[1].SetActive(true);
            movieclip[0].SetActive(false);
            StartCoroutine(delayloadseace(0, 31f));
        }
        else {
            movieclip[2].SetActive(true);
            movieclip[1].SetActive(false);
            movieclip[0].SetActive(false);
            StartCoroutine(delayloadseace(0,21f));
        }

	}

    IEnumerator delayloadseace(int i ,float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadSceneAsync(i);
    }
	// Update is called once per frame
	void Update () {
        

    }
}
