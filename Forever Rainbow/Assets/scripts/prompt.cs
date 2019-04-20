using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prompt : MonoBehaviour {
    public GameObject showprompt;

    // Use this for initialization
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "player") {
            showprompt.SetActive(true);
            
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "player")
        {
            Destroy(gameObject);

        }
    }
}
