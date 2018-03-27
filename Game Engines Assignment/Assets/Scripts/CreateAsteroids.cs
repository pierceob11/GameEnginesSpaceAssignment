using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAsteroids : MonoBehaviour {

    public int maxAsteroids;
    public GameObject sphere;
    float x, y, z;
    Vector3 asteroidPos;
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
    void Update()
    {

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
