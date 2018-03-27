using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    //Brians code DNU
    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    //Variables
    [SerializeField]
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;
    public float mass = 1.0f;
    public float damping = 0.01f;
    public Vector3 velocity = Vector3.zero;
    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;

	// Use this for initialization
	void Start () 
    {
        //Brians code DNU
		 SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();

        foreach (SteeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);
        }
	}



    //Brians code, DONT UNDERSTAND
    private bool AccumulateForce(ref Vector3 runningTotal, ref Vector3 force)
    {
        float soFar = runningTotal.magnitude;
        float remaining = maxForce - soFar;
        Vector3 clampedforce = Vector3.ClampMagnitude(force, remaining);
        runningTotal += clampedforce;
        return (force.magnitude >= remaining);
    }

    Vector3 Calculate()
    {
        force = Vector3.zero;

        //Brians code DNU
        foreach (SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                Vector3 behaviourForce = b.Calculate() * b.weight;
                bool full = AccumulateForce(ref force, ref behaviourForce);
                if (full)
                {
                    break;
                }
            }
        }

        return force;
    }

    public Vector3 SeekForce(Vector3 targetPos)
    {
        Vector3 desired = targetPos - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }

	//A lot of Brians code here that I DNU
	void Update () 
    {
        force = Calculate();
        Vector3 newAcceleration = force / mass;

        float smoothRate = Mathf.Clamp(9.0f * Time.deltaTime, 0.15f, 0.4f) / 2.0f;
        acceleration = Vector3.Lerp(acceleration, newAcceleration, Time.deltaTime);

        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 globalUp = new Vector3(0, 0.2f, 0);
        Vector3 accelUp = acceleration * 0.05f;
        Vector3 bankUp = accelUp + globalUp;        
        Vector3 tempUp = transform.up;
        tempUp = Vector3.Lerp(tempUp, bankUp, Time.deltaTime * 3);

        if (velocity.magnitude  > 0.0001f)
        {
            transform.LookAt(transform.position + velocity, tempUp);
            velocity *= (1.0f - (damping * Time.deltaTime));
        }
        transform.position += velocity * Time.deltaTime;        
	}
}

    
