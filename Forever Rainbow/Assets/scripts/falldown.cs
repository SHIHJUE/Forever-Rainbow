using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falldown : MonoBehaviour {
    public Animation[] anims;
    int randomint;
    void OnTriggerEnter(Collider col) {

        if (col.tag == "player") {
            randomint = Random.Range(0, 2);
            anims[randomint].Play("flowerfalldown");
            gameObject.SetActive(false);
        }
    }
}
