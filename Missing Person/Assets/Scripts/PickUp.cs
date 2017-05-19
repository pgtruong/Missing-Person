using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

    private bool pickUp = false;
    public GameObject[] dependencies;
    public string play;
    public string stop;
    public Text text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUp)
        {
            foreach (GameObject dependent in dependencies)
            {
                if (dependent != null)
                    return;

            }
            if (play != "")
                AkSoundEngine.PostEvent(play, this.gameObject);
            if (stop != "")
            {
                AkSoundEngine.PostEvent(stop, this.gameObject);
            }
            text.enabled = false;
            //temp
            if (gameObject.name == "Sphere")
            {
                text.text = "You win! Press Q to quit.";
                text.enabled = true;
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUp = true;
            text.text = "Press E to pick up " + gameObject.name;
            text.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUp = false;
            text.enabled = false;
        }
    }
}
