using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{

    public Path pathScript;
    public Boid boidScript;
    public Vector3 newWaypoint;
    float minDistance = 250.0f;
    float rotationalDamp = 0.5f;
    //float detectionDistance = 20.0f;

    // Use this for initialization
    void Start()
    {

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, pathScript.nextWaypoint);
    }


    public void NextWaypoint()
    {
        newWaypoint = pathScript.nextWaypoint;
        if ((transform.position - newWaypoint).sqrMagnitude <= minDistance)
        {
            pathScript.SelectNext();
        }
    }

    public void TurntoFace() //Was originally a void and final line was the commented out one
    {
        Vector3 turn = newWaypoint - transform.position;
        Quaternion rotation = Quaternion.LookRotation(turn);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    /*
    public Vector3 Movement() // This function will replace FollowPath
    {
        /*
        if(!pathScript.looping && pathScript.lastWaypoint())
        {
            //return boid arrive force
        }
        
        //
        return boidScript.Seeking(newWaypoint);
    }
*/


    void Update()
    {
        NextWaypoint();
       // TurntoFace();
    }
}

    
