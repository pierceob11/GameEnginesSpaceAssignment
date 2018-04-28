using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : MovementManager {

    
     public float rayCastOffset = 5.0f;
    float detectionDistance = 40.0f;
    public float avoidFactor = 0.3f;

    public override Vector3 CalculateForce()
    {
        RaycastHit hit;
        Vector3 avoidanceForce = Vector3.zero;


        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.blue);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.blue);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.blue);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.blue);

        if(Physics.Raycast(left, transform.forward, out hit, detectionDistance))
        {
            avoidanceForce = hit.transform.position - Vector3.right;
            Debug.Log("Ray hit");
        }
        else if(Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            avoidanceForce = hit.transform.position + Vector3.right;
            Debug.Log("Ray hit");
        }
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            avoidanceForce = hit.transform.position - Vector3.up;
            Debug.Log("Ray hit");
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
        {
            avoidanceForce = hit.transform.position + Vector3.up;
            Debug.Log("Ray hit");
        }

       
        if(avoidanceForce != Vector3.zero)
        {
            return avoidanceForce *= avoidFactor;
        }
        else
        {
            return Vector3.zero;
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
