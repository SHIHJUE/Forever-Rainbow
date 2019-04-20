using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {
    
    public float gravity = -12;
    public Material[] planetmat;
    void Start() {
        if(gamecontroll.planetint==0)
            GetComponent<MeshRenderer>().material = planetmat[3];
        else
            GetComponent<MeshRenderer>().material = planetmat[gamecontroll.planetint - 1];
    }
    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
