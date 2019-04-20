using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbow : MonoBehaviour {
    public float speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.up * speed, Space.World);
    }
    void OnTriggerStay(Collider col) {
        if (col.tag == "obj")
            Destroy(gameObject);
    }
}
