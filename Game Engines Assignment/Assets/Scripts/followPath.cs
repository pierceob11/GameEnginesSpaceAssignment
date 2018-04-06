using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MovementManager {

    public Path pathScript;
    public Vector3 targetWaypoint;
    float nearEnough = 200.0f;

	// Use this for initialization
	void Start () {
		
	}
	
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, targetWaypoint);
    }

    
    public override Vector3 CalculateForce()
    {
        targetWaypoint = pathScript.nextWaypoint();

        if((transform.position - targetWaypoint).sqrMagnitude <= nearEnough)
        {
            pathScript.SelectNext();
        }

        return boidScript.Seeking(targetWaypoint);
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
