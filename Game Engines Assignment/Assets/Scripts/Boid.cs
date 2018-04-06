using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    List<MovementManager> behaviours = new List<MovementManager>();

    public float maxSpeed = 10.0f;
    float mass = 1.0f;
    public float fleeRadius = 75.0f;
    public float maxForce = 10.0f;
    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 force = Vector3.zero;
    public Vector3 target;


	// Use this for initialization
	void Start () //BC
    {

        MovementManager[] behaviours = GetComponents<MovementManager>();

        foreach (MovementManager b in behaviours)
        {
            this.behaviours.Add(b);
        }
	}
       

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (force * 10));
    }

   public Vector3 Seeking(Vector3 target) //Seek behaviour
    {
        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= maxSpeed;
        Vector3 steering = desiredVelocity - velocity;
        steering = steering / mass;
        return steering;
    }

    
    public Vector3 Fleeing(Vector3 target) //Flee behaviour
    {
        Vector3 desiredVelocity = transform.position - target;

        if(desiredVelocity.magnitude > fleeRadius) //Not in flee range (Not fleeing)
        {
            return Vector3.zero;
        }
        else //Fleeing
        {
            desiredVelocity.Normalize();
            desiredVelocity *= maxSpeed;
            Vector3 steering = velocity - desiredVelocity; //This line may need to be velocity - deisred?
            steering = steering / mass;
            return steering;
        }
       
    }
    
   public Vector3 Arriving(Vector3 target, float arrivalRadius = 10.0f)
    {
        Vector3 desiredVelocity = target - transform.position;
        float distance = desiredVelocity.magnitude;

        if(distance < arrivalRadius)
        {
            //Inside slowing area
            desiredVelocity.Normalize();
            desiredVelocity *= maxSpeed * (distance / arrivalRadius);
        }
        else
        {
            //Outside slowing area
            desiredVelocity.Normalize();
            desiredVelocity *= maxSpeed;
        }

        return desiredVelocity - velocity;
    }

   Vector3 CalculateForce()
   {
       force = Vector3.zero;

       foreach (MovementManager b in behaviours)
       {
           if (b.isActiveAndEnabled)
           {
               force += b.CalculateForce() * b.weight;
           }
       }

       return force;
   }
	

	void Update () 
    {

        force = CalculateForce();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if(velocity.magnitude > float.Epsilon)
        {
            transform.forward = velocity;
        }

        
	}
}
