using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateFloor : MonoBehaviour {

    public GameObject spawn;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Should TP.");
        other.gameObject.transform.position = spawn.transform.position;
    }
}
