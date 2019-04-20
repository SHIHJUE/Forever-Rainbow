using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerConroller : MonoBehaviour {
	public gamecontroll game;
    private bool isjump;
    private bool isslide;
    public bool isturn=false;

    private int stopint = 1;
	private int directint;
    
    public Animation camanim;
    private float speed;
	public float maxspeed;
    public float minspeed;
	public float defaultspeed;
    
    public bool canturn=false;
	private Quaternion targetrot;
    public Vector3 direction = new Vector3(0,0,1f);
    public Transform[] hitmovepos;
    public Transform targetmove;
    public Transform targetpos;
    private float dir;
    private Vector3 hitdir;

    private Vector2 x;
    private int amount;
    public int reachamount;
	public Animation clearanim;
    
    private float pangle;
    public AudioSource[] soundeffect;
    int prestopint;
    
    void Start () {
		game.ispause = false;
        pangle = 90;
        speed = defaultspeed;
        targetpos = null;
        
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        if (game.canmove && !game.ispause)
        {
            Move();
            rotate_0();
            hitrightleft();
        }
        
    }
   
    void rotate_0(){
		transform.rotation = Quaternion.RotateTowards (transform.rotation, targetrot, 500 * Time.deltaTime);
	}
	void OnTriggerEnter(Collider col){

        if (col.tag == "obj")
        {
           
            soundeffect[1].Play();
            game.playerlife -= 10;
            

            if (col.name != "arrow")
            {
                hitdir = (col.transform.position - targetmove.position);
                float angle = Vector3.Angle(hitdir, Vector3.forward);

                if (angle >= pangle - 45 && angle <= pangle + 45)
                {

                    speed = -0.8f;
                    dir = -1;
                    targetpos = null;
                    directint = 1;
                }
                else
                {

                    if (stopint != 1)
                    {
                        targetpos = hitmovepos[1];
                    }
                    else
                    {
                        targetpos = hitmovepos[prestopint];
                    }
                    stopint = prestopint;
                }

            }

            col.GetComponent<BoxCollider>().enabled = false;

        }
        else if (col.tag == "wall")
        {
            game.playerlife -= 100;
        }
        else if (col.tag == "color")
        {
            amount += 1;
            soundeffect[0].Play();
           
            Destroy(col.gameObject);
        }
        else if (col.tag == "final")
        {
            clearanim.gameObject.SetActive(true);
            StartCoroutine(game.delaychagescene(2.5f, 1));
            game.ispause = true;
            Destroy(col.gameObject);
            clearanim.Play("clearanim");
            if (amount == reachamount)
                gamecontroll.planetint += 1;
            gamecontroll.level++;
            

        }
        else if (col.tag == "rainbow")
        {
            game.playerlife += 10;
            if (game.playerlife > 100)
                game.playerlife = 100;
            Destroy(col.gameObject);
            soundeffect[0].Play();
        }

        }
    void checkangle()
    {
        if (transform.rotation.y == 0 || transform.rotation.y == 1)
            pangle = 0;
        else
        {
            pangle = 90;
        }
    }
    private void hit()
    {
        if (dir < 0)
        {
            if (speed < 0)
                speed += Time.deltaTime*3;
            else if (speed >= 0)
                speed = 0;
            StartCoroutine(refoward());
        }
        else speed = defaultspeed;
    }
    IEnumerator refoward()
    {
        yield return new WaitForSeconds(1f);
        dir = 1;
        directint = 0;
    }

    
    void Move(){
        
       
		transform.Translate (Vector3.forward * speed);
        hit();
        if (dir == 1)
            {
            if (Input.GetButton("R1"))
            {
                speed = maxspeed;
            }
            else if (Input.GetButton("L1"))
            {
                speed = minspeed;
                Debug.Log(0);
            }
            
        }


            if (Input.GetButton("R04"))
            {
                if (!canturn && stopint > 0 && directint == 0 && !isturn)
                {
                    checkangle();
                    prestopint = stopint;
                    if (stopint == 1)
                    {
                        targetpos = hitmovepos[0];
                        stopint = 0;

                    }
                    else if (stopint == 2)
                    {
                        targetpos = hitmovepos[1];
                        stopint = 1;
                    }
                    directint = 1;

                    StartCoroutine(stopdelay());

                }
                else if (canturn)
                    turnaround(-1);
            }
            if (Input.GetButton("R02"))
            {
                if (!canturn && stopint < 2 && directint == 0 && !isturn)
                {
                    checkangle();
                    prestopint = stopint;
                    if (stopint == 1)
                    {
                        targetpos = hitmovepos[2];
                        stopint = 2;
                    }
                    else if (stopint == 0)
                    {
                        targetpos = hitmovepos[1];

                        stopint = 1;
                    }
                    directint = 1;

                    StartCoroutine(stopdelay());
                }
                else if (canturn)
                    turnaround(1);
            }

        if (Input.GetButton("R03") && !isslide && !isturn)
        {

            camanim.Play("cameraslider");
            isjump = true;
            isslide = true;
            StartCoroutine(delaytime(1.5f));
        }
        else if (Input.GetButton("R01") && !isjump && !isturn)
        {
            camanim.Play("camerajump");
            isslide = true;
            isjump = true;
            StartCoroutine(delaytime(1.5f));

        }
        
		
	}
    void turnaround(float dir) {
        isturn = true;
        canturn = false;
        targetrot = Quaternion.LookRotation(transform.right* dir);
        direction = transform.right* dir;
    }
	IEnumerator stopdelay(){
		yield return new WaitForSeconds(0.5f);
		directint = 0;
        pangle = 90;
	}
	IEnumerator delaytime(float delaytime)
	{
		yield return new WaitForSeconds(delaytime);
		
		isslide = false;
		isjump = false;

	}
    void hitrightleft() {
        if(targetpos !=null)
            targetmove.transform.position = new Vector3(Mathf.MoveTowards(targetmove.transform.position.x, targetpos.position.x, speed), 
                targetmove.transform.position.y, Mathf.MoveTowards(targetmove.transform.position.z,  targetpos.position.z, speed));

    }
    


}
