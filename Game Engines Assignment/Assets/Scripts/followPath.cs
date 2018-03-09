using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour {

    public Path pathScript;
    Vector3 newWaypoint;
    float minDistance = 120.0f;
    float shipSpeed = 10.0f;
    float rotSpeed = 1.0f;
    public Rigidbody rb;
   public float thrust = 3.0f;
    float rotationalDamp = 0.4f;
    float rayCastoffset = 7.5f;
    float detectionDistance = 20.0f;
    bool facing = false;

	// Use this for initialization
	void Start () 
    {
		rb = GetComponent<Rigidbody>();
	}

    //Using forces to move ship
    /*
    public void FollowPath()
    {
        newWaypoint = pathScript.nextWaypoint;
        transform.LookAt(newWaypoint);
        rb.AddForce(0, 0, thrust, ForceMode.Impulse);
        if((transform.position - newWaypoint).sqrMagnitude <= minDistance)
        {
            //Select new waypoint
            pathScript.next++;
        }
    }
    */

    public void TurntoFace()
    {
        Vector3 turn = newWaypoint - transform.position;
        Quaternion rotation = Quaternion.LookRotation(turn);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    public void FollowPath()
    {
        newWaypoint = pathScript.nextWaypoint;
        Invoke("TurntoFace", 0f);
        Vector3 orientation = newWaypoint - transform.position;
        //Move to point
        rb.AddForce(orientation * thrust * Time.deltaTime, ForceMode.Acceleration);
        //transform.position = Vector3.MoveTowards(transform.position, newWaypoint, Time.deltaTime * shipSpeed);
        if((transform.position - newWaypoint).sqrMagnitude <= minDistance)
        {
            //Select new waypoint
            pathScript.next++;
            
        }
        TurntoFace();
        facing = false;
        Debug.Log("Exiting FollowPath");
    }

    void Avoid()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastoffset;
        Vector3 right = transform.position + transform.right * rayCastoffset;
        Vector3 up = transform.position + transform.up * rayCastoffset;
        Vector3 down = transform.position - transform.up * rayCastoffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.green);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.green);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.green);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.green);


        if(Physics.Raycast(left, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.right;
        }
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.up;
        }

        if(raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * 5.0f * Time.deltaTime);
        }
        else
        {
            TurntoFace();
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        //Avoid();
        //FollowPath();
        //TurntoFace();
        if (facing == false)
        {
            Invoke("FollowPath", 0f);
            facing = true;
        }
        Debug.Log((transform.position - newWaypoint).sqrMagnitude);
	}

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, newWaypoint);
    }
}
