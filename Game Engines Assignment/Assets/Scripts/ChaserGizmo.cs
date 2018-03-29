using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserGizmo : MonoBehaviour {

    public GameObject targetShip;

	// Use this for initialization
	void Start () 
    {
        targetShip = GameObject.FindGameObjectWithTag("Target");	
	}
	
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, targetShip.transform.position);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
