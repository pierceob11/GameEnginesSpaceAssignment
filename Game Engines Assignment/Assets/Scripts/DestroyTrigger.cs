using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour {

    public GameObject ussCallister;
    public Camera UssCallisterCamFront;
    public Camera ChaserCamFront;

    public void OnTriggerEnter(Collider col)
    {
        UssCallisterCamFront.gameObject.SetActive(false);
        ChaserCamFront.gameObject.SetActive(true);
        Destroy(this.gameObject);
        Debug.Log("Trigger hit");
    }
}
