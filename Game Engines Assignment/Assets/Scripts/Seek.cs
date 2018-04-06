using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MovementManager {

    public GameObject targetObj;
    public Vector3 seekTarget;

	// Use this for initialization
	void Start () 
    {
	    	
	}

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawLine(transform.position, seekTarget);
    }

    public override Vector3 CalculateForce()
    {

        return boidScript.Seeking(seekTarget);
    }
	
	// Update is called once per frame
	void Update () 
    {
        seekTarget = targetObj.transform.position;
	}
}
