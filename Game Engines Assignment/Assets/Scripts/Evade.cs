using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : MovementManager {

    public Boid targetObj;
    public Vector3 evadeTarget;

	// Use this for initialization
	void Start () {
		
	}

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, evadeTarget);
        }
    }

    public override Vector3 CalculateForce()
    {
        Vector3 distanceBetween = targetObj.transform.position - transform.position;
        float prediction = distanceBetween.magnitude / boidScript.maxSpeed;

        evadeTarget = targetObj.transform.position + (targetObj.velocity * prediction);

        return boidScript.Fleeing(evadeTarget);
    }
	
	// Update is called once per frame
	void Update () 
    {
        
	}
}
