using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public GameObject howplay;
    
    public TextMesh voltxt;
    int volint = 5;
    public GameObject pressbutton;
    bool ispress2 = false;
    bool ispress3 = false;
    // Use this for initialization
    void Start(){
        StartCoroutine(showbutton());
    }
    IEnumerator showbutton() {
        yield return new WaitForSeconds(2f);
        pressbutton.SetActive(true);
    }
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Z) && !ispress3) {
            SceneManager.LoadSceneAsync(5);
            gamecontroll.isstart = true;
        }
        else if (Input.GetKeyDown(KeyCode.X)&&!ispress3)
        {
            howplay.SetActive(!ispress2);
            ispress2 = !ispress2;
        }
        else if (Input.GetKeyDown(KeyCode.C)&& !ispress2)
        {
            voltxt.gameObject.SetActive(!ispress3);
            ispress3 = !ispress3;
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Application.Quit();
        }
        if (ispress3) {
            voltxt.text = "音量" + volint;
            if (Input.GetKeyDown(KeyCode.Z) && gamecontroll.vol > 0.1)
            {
                gamecontroll.vol -= 0.1f;
                volint--;
                
            }
            else if (Input.GetKeyDown(KeyCode.X) && gamecontroll.vol < 1)
            {
                gamecontroll.vol += 0.1f;
                volint++;
                
            }
        }
    }
    
    
}
