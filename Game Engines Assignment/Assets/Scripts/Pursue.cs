using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MovementManager {

    public Boid targetObj;
    public Vector3 pursueTarget;

	// Use this for initialization
	void Start () {
		
	}

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, pursueTarget);
        }
    }

    public override Vector3 CalculateForce()
    {
        Vector3 distanceBetween = targetObj.transform.position - transform.position;
        float prediction = distanceBetween.magnitude / boidScript.maxSpeed;

        pursueTarget = targetObj.transform.position + (targetObj.velocity * prediction);

        return boidScript.Seeking(pursueTarget);
    }
	
	// Update is called once per frame
	void Update () 
    {
        
	}
}
