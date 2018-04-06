using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementManager : MonoBehaviour 
{
    public float weight = 1.0f;
    public Vector3 force;

    [HideInInspector]
    public Boid boidScript;

    public void Awake()
    {
        boidScript = GetComponent<Boid>();
    }

    public abstract Vector3 CalculateForce();
}


    
