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
    public AudioClip ThroughTheBelt;
    public AudioClip DalyBeginsChase;
    public AudioClip TheChaseIsOn;
    public AudioClip FuckingBiblical;
    public AudioClip powerBack;

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
        //Scene - Just fucking go

        chaser.GetComponent<Arrive>().enabled = false;
        chaser.GetComponent<Pursue>().enabled = false; //Chaser will not move
        ussCallister.GetComponent<FollowPath>().enabled = false; //Boid will not move


        audioSource.clip = Go; //Select audio clip "Just fucking go"
        audioSource.Play(); //Play audio clip 
        Debug.Log("Playing Go clip");

        yield return new WaitForSeconds(10);

        ussCallister.GetComponent<FollowPath>().enabled = true;


        yield return new WaitForSeconds(12); //Wait for audio to finish

        //Scene - Asteroid Field

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

        //Scene - Through The belt

        //Select audio
        audioSource.clip = ThroughTheBelt;
        audioSource.Play();

        //Chaser cam Front
        asteroidBeltCam.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.5f); //Wait for audio

        //Camera Uss front
        ChaserCamFront.gameObject.SetActive(false);
        UssCallisterCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(20);

        //Enable seek (disable Path follow)
        ussCallister.GetComponent<FollowPath>().enabled = false;
        ussCallister.GetComponent<Seek>().enabled = true;

        //Camera USS back
        UssCallisterCamFront.gameObject.SetActive(false);
        UssCallisterCamBack.gameObject.SetActive(true);

        yield return new WaitForSeconds(10); //Wait for audio to finish


        //Scene - Daly begins chase

        //Select clip
        audioSource.clip = DalyBeginsChase;
        audioSource.Play(); //Play clip


        //Camera Chaser front
        UssCallisterCamBack.gameObject.SetActive(false);
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

        yield return new WaitForSeconds(4); //Wait for audio to finish


        //Scene - The chase is on

        //Select Audio
        audioSource.clip = TheChaseIsOn;
        audioSource.Play();

        //Camera front USS
        ChaserCamBack.gameObject.SetActive(false);
        UssCallisterCamFront.gameObject.SetActive(true);

        //Wait 10
        yield return new WaitForSeconds(10);

        //Camera back
        UssCallisterCamFront.gameObject.SetActive(false);
        UssCallisterCamBack.gameObject.SetActive(true);

        //Wait 12
        yield return new WaitForSeconds(12);

        //Chaser front
        UssCallisterCamBack.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);

        //Wait five
        yield return new WaitForSeconds(5);

        //Chaser back
        ChaserCamFront.gameObject.SetActive(false);
        ChaserCamBack.gameObject.SetActive(true);

        //Scene - Fucking biblical

        //Select audio
        audioSource.clip = FuckingBiblical;
        audioSource.Play();

        //USS Back
        ChaserCamBack.gameObject.SetActive(false);
        UssCallisterCamBack.gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        //USS Front
        UssCallisterCamBack.gameObject.SetActive(false);
        UssCallisterCamFront.gameObject.SetActive(true);

        //Wait for audio
        yield return new WaitForSeconds(8);

       //Chaser Front
        UssCallisterCamFront.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(7); //Wait for zoom

        //Chaser front zoom
        ChaserCamFront.gameObject.GetComponent<Camera>().fieldOfView = 15.0f;

        //Hold zoom
        yield return new WaitForSeconds(12);

        //Reset FOV (Chaser)
        ChaserCamFront.gameObject.GetComponent<Camera>().fieldOfView = 39.0f;

        //USS front
        ChaserCamFront.gameObject.SetActive(false);
        UssCallisterCamFront.gameObject.SetActive(true);

        //Wait for audio
        yield return new WaitForSeconds(4);

        //USS back
        UssCallisterCamFront.gameObject.SetActive(false);
        UssCallisterCamBack.gameObject.SetActive(true);

        //Wait for auido (Power Failure)
        yield return new WaitForSeconds(6);

        //Power failure (Jet turn off to be added here)
        ussCallister.gameObject.GetComponent<Seek>().enabled = false;
        ussCallister.gameObject.GetComponent<Evade>().enabled = false;
        ussCallister.gameObject.GetComponent<Boid>().velocity = Vector3.zero; 

        //Scene - Power Back

        //Wait for power
        yield return new WaitForSeconds(2);

        //Select audio
        audioSource.clip = powerBack;
        audioSource.Play();

        yield return new WaitForSeconds(1); //Wait for audio

        //USS moves again
        ussCallister.gameObject.GetComponent<Seek>().enabled = true;

        yield return new WaitForSeconds(8);

        //Chaser front cam
        UssCallisterCamBack.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(9);

        //Uss front
        ChaserCamFront.gameObject.SetActive(false);
        UssCallisterCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(6);

        //Chaser front "CMON CMON"
        UssCallisterCamFront.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        //Uss front
        ChaserCamFront.gameObject.SetActive(false);
        UssCallisterCamFront.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        //uss back 
        UssCallisterCamFront.gameObject.SetActive(false);
        UssCallisterCamBack.gameObject.SetActive(true);

        yield return new WaitForSeconds(19);

        //Chaser back
        UssCallisterCamBack.gameObject.SetActive(false);
        ChaserCamBack.gameObject.SetActive(true);

        yield return new WaitForSeconds(5); //GOD DAMNIT

    }

	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
