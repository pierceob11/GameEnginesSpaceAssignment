using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject ussCallister;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine("StoryStart");
	}

    public IEnumerator StoryStart()
    {
        ussCallister.GetComponent<FollowPath>().enabled = false; //Boid will not move

        //Play audio clip "Just fucking go"
        //Wait for clip to be over

        ussCallister.GetComponent<FollowPath>().enabled = true;

        yield return null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
