using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private bool pickUp = false;
    public GameObject[] dependencies;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUp)
        {
            foreach (GameObject dependent in dependencies)
            {
                if (dependent != null)
                    return;
            }
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUp = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUp = false;
        }
    }
}
