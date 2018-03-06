using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour {

    public Path pathScript;
    Vector3 newWaypoint;
    float minDistance = 0.3f;

	// Use this for initialization
	void Start () 
    {
		
	}

    public void FollowPath()
    {
        newWaypoint = pathScript.nextWaypoint;
        transform.LookAt(newWaypoint);
        transform.position = Vector3.Lerp(transform.position, newWaypoint, Time.deltaTime);
        if((transform.position - newWaypoint).sqrMagnitude <= minDistance)
        {
            pathScript.next++;
        }
        //transform.position = Vector3.Slerp(transform.position, newWaypoint, Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () 
    {
        FollowPath();
	}

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, newWaypoint);
    }
}
