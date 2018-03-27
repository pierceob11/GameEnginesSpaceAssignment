using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour {

    //Think these two variables will be needed later but have commented out for the moment as not sure what they do
    public float weight = 1.0f;
    public Vector3 force;


    //We currently seem to be using this class as a parent/master for boid
    //Would like to later investigate if Boid can be used as the parent/master and to skip this script
    [HideInInspector]
    public Boid boid;

    public void Awake()
    {
        boid = GetComponent<Boid>();
    }

    public abstract Vector3 Calculate();
}
