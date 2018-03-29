using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    public followPath followPathScript;
    //public GameObject seekTarget;
    float maxSpeed = 10.0f;
    float maxForce = 0.1f;
    float mass = 1.0f;
    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 force = Vector3.zero;

	// Use this for initialization
	void Start () 
    {
		
	}

    public Vector3 Seeking(Vector3 target)
    {
        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= maxSpeed;
        Vector3 steering = desiredVelocity - velocity;
        steering = steering / mass;
        return steering;
    }

    Vector3 CalculateForce()
    {
        force = Vector3.zero;
        return force;
    }
	
	// Update is called once per frame
	void Update () 
    {

        force = Seeking(followPathScript.newWaypoint);
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
	}
}
