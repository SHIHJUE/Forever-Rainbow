using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyball : MonoBehaviour {
    public GameObject targetball;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * speed, Space.World);
        if (targetball != null)
            return;
        else
            Destroy(gameObject);
        
    }
}
