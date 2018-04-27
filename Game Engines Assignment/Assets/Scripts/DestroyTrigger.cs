using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour {

    public GameObject ussCallister;

    public void OnTriggerEnter(Collider col)
    {
        Destroy(ussCallister);
        Destroy(this.gameObject);
    }
}
