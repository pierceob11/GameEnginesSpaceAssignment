using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MovementManager {

    public Vector3 arriveTarget;
    public float arrivalRadius = 10.0f;
    public GameObject arriveObj;

	// Use this for initialization
	void Start () {
		
	}

    public override Vector3 CalculateForce()
    {
        return boidScript.Arriving(arriveTarget, arrivalRadius);
    }
	
	// Update is called once per frame
	void Update () 
    {
        arriveTarget = arriveObj.transform.position;	
	}
}
