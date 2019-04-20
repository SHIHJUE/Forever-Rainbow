using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerGravityBody : MonoBehaviour {

    public PlanetScript attractorPlanet;
    private Transform playerTransform;
   
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Crystal") {
            
            if (gamecontroll.planetint == gamecontroll.level) {

                SceneManager.LoadSceneAsync(gamecontroll.level+2);
            }
                
            else
                SceneManager.LoadSceneAsync(5);

        }
    }
    
}
