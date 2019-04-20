using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnZone : MonoBehaviour {
	PlayerConroller playercon;
	public GameObject pl;
	private float speed=10;
    public Animation[] birdanim;
    private float dir;
    
	public virtual void Start () {
        pl = GameObject.Find ("Player");
		playercon =pl.GetComponent<PlayerConroller> ();
	}
    
    void OnTriggerEnter(Collider col){
		if (col.tag == "player") {
            StartCoroutine(delaytrue());
            for (int i = 0; i < birdanim.Length; i++)
            {
                birdanim[i].gameObject.SetActive(true);
                birdanim[i].Play("fly");
            }
		}
	}
    IEnumerator delaytrue() {
        yield return new WaitForSeconds(0.1f);
        playercon.canturn = true;
    }
	void OnTriggerExit(Collider col){

		if (col.tag == "player") {
			playercon.canturn = false;
			playercon.isturn = false;
            
        }
	}
	void OnTriggerStay(Collider col){
        
        if (col.tag == "player") {
			if (playercon.isturn) {
                Fixposition ();
			}
		}

	}
    
	public virtual void Fixposition(){
        
		if (Mathf.Abs (playercon.direction.z) < 0.001f) {
			pl.transform.position=new Vector3 (pl.transform.position.x,pl.transform.position.y,Mathf.MoveTowards(pl.transform.position.z,transform.position.z,speed));
			
		}
		if (Mathf.Abs (playercon.direction.x) < 0.001f) {
			pl.transform.position=new Vector3 (Mathf.MoveTowards(pl.transform.position.x,transform.position.x,speed),pl.transform.position.y,pl.transform.position.z);

		}
	}
    
}
