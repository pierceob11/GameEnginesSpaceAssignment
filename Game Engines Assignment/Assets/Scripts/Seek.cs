using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour {

   public GameObject targetObj = null;
   public Vector3 target = Vector3.zero;


   //Line Drawer
   public void OnDrawGizmos()
   {
       if (isActiveAndEnabled && Application.isPlaying)
       {
           Gizmos.color = Color.cyan;
           if (targetObj != null)
           {
               target = targetObj.transform.position;
           }
           Gizmos.DrawLine(transform.position, target);
       }
   }

    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);
    }
    

	// Update is called once per frame
	void Update () 
    {
		if(targetObj != null)
        {
            target = targetObj.transform.position;
        }
	}

}
