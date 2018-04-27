using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreate : MonoBehaviour {

 public List<Vector3> waypoints = new List<Vector3>();
    public int next = 0;
    public bool looping = true;

    // Use this for initialization
    void Start()
    {
        waypoints.Clear();


        int count = transform.childCount;

        for(int i = 0; i < count; i ++)
        {
            waypoints.Add(transform.GetChild(i).position); //Adding all waypoints to list
        }
    }

    void Update()
    {
        //nextWaypoint = waypoints[next]; //Get next waypoint from list
    }

    public Vector3 nextWaypoint()
    {
        return waypoints[next];
    }


    public void OnDrawGizmos()
    {
        int count = transform.childCount;
        Gizmos.color = Color.red;

        for (int i = 1; i < count; i++)
        {
            Transform previousGizmo = transform.GetChild(i - 1);
            Transform nextGizmo = transform.GetChild(i % transform.childCount);
            Gizmos.DrawLine(previousGizmo.transform.position, nextGizmo.transform.position);
        }
    }

    public bool lastWaypoint()
    {
        return next == waypoints.Count - 1;
    }

    public void SelectNext()
    {
        if (looping)
        {
            next = (next + 1) % waypoints.Count;
        }
        else
        {
            if (next != waypoints.Count - 1)
            {
                next++;
            }
        }
    }
}
