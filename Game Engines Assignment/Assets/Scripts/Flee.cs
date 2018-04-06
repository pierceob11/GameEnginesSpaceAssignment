using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MovementManager {

    public GameObject targetObj;
    public Vector3 fleeTarget;

	// Use this for initialization
	void Start () {
		
	}

    public override Vector3 CalculateForce()
    {
        return boidScript.Fleeing(fleeTarget);
    }
	
	// Update is called once per frame
	void Update () 
    {
        fleeTarget = targetObj.transform.position;	
	}
}
