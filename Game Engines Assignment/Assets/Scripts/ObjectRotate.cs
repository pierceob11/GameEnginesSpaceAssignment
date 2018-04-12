using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour {

    public float RotSpeed = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.up * (RotSpeed * Time.deltaTime), Space.World);
	}
}
