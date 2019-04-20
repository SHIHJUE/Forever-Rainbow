using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    
	// Update is called once per frame
	void Start () {
        
         StartCoroutine(hide());
	}
    IEnumerator hide() {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
