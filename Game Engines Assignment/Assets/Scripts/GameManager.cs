using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //GameObjects
    public GameObject ussCallister;
    public GameObject chaser;
    public GameObject wormhole;

    //Audio components
    AudioSource audioSource;
    public AudioClip Go;
    public AudioClip AsteroidFieldClip;
    public AudioClip DalyBeginsChase;
    //public AudioClip Go;
    //public AudioClip Go;
    //public AudioClip Go;

    //Cameras
    public Camera UssCallisterCamBack;
    public Camera UssCallisterCamFront;
    public Camera ChaserCamBack;
    public Camera ChaserCamFront;
    public Camera pathCam;
    public Camera wormholeCam;
    public Camera asteroidBeltCam;



	// Use this for initialization
	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("JustFuckingGo");
	}

    public IEnumerator JustFuckingGo()
    {
        chaser.GetComponent<Arrive>().enabled = false;
        chaser.GetComponent<Pursue>().enabled = false; //Chaser will not move
        ussCallister.GetComponent<FollowPath>().enabled = false; //Boid will not move


        audioSource.clip = Go; //Select audio clip "Just fucking go"
        audioSource.Play(); //Play audio clip 
        Debug.Log("Playing Go clip");

        yield return new WaitForSeconds(10);

        ussCallister.GetComponent<FollowPath>().enabled = true;


        yield return new WaitForSeconds(12); //Wait for audio to finish

        //Next scene

        audioSource.clip = AsteroidFieldClip;
        audioSource.Play();

        //Swap to Path camera
        pathCam.gameObject.SetActive(true);
        UssCallisterCamBack.gameObject.SetActive(false);

        yield return new WaitForSeconds(8); //Wait for ship to pass camera

        //Back to ship camera
        pathCam.gameObject.SetActive(false);
        UssCallisterCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(8);

        //Asteroid field camera
        UssCallisterCamFront.gameObject.SetActive(false);
        asteroidBeltCam.gameObject.SetActive(true);

        yield return new WaitForSeconds(12); //Wait for audio to finish

        //Next Scene

        //Select clip
        audioSource.clip = DalyBeginsChase;
        audioSource.Play(); //Play clip


        //Camera Chaser front
        asteroidBeltCam.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(11); //Wait for audio

        //Wormhole Camera
        ChaserCamFront.gameObject.SetActive(false);
        wormholeCam.gameObject.SetActive(true);

        yield return new WaitForSeconds(5); //Wait for audio

        //Camera Chaser front
        wormholeCam.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(8);
        
        //Enable pursue
        chaser.GetComponent<Pursue>().enabled = true;

        //Camera Chaser Back
        ChaserCamFront.gameObject.SetActive(false);
        ChaserCamBack.gameObject.SetActive(true);


        //Next Scene

    }

  
	
	// Update is called once per frame
	void Update () {
		
	}
}
