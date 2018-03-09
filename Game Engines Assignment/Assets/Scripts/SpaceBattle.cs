using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBattle : MonoBehaviour {

    public int maxAsteroids;
    public GameObject sphere;
    float x, y, z;
    Vector3 asteroidPos;
    //Vector3 asteroidScale;
    int asteroidCount;
    bool spawning = true;
    

	// Use this for initialization
    void Start()
    {
        //Asteroid field
        asteroidCount = 0;

        if (asteroidCount < maxAsteroids && spawning == true)
        {
            spawnAsteroids();
        }
        if (asteroidCount >= maxAsteroids && spawning == true)
        {
            spawning = false;
        }

    }

	// Update is called once per frame
	void Update () 
    {
        //Debug.Log(sphere.transform.rotation);
        //sphere.transform.rotation = new Quaternion(1, 0, 0, 0) * Time.deltaTime;
	}


    void Seek()
    {
        Vector3 currentPos = transform.position;
        //Vector3 target = GameObject.FindGameObjectWithTag("Target");

    }


    void spawnAsteroids()
    {
        spawning = true;
        //Creating asteroid field
        for (int xfor = 0; xfor <= maxAsteroids; xfor++)
        {
            asteroidPos = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
            Instantiate(sphere, asteroidPos, Quaternion.identity);
            sphere.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
            asteroidCount++;
            
        }
        
    }

}
