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

    public string doorToUnlock;

    /// <summary>
    /// The length of the tape (or at least how long you want to wait until the object destroys itself and unlocks the next door).
    /// </summary>
    public float tapeLength;
    private bool isPlaying;
    private float timer;

    private void Start()
    {
        timer = tapeLength;
    }

    void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E) && pickUp)
            {
                foreach (GameObject dependent in dependencies)
                {
                    if (dependent != null)
                        return;

                }
                if (play != "")
                {
                    AkSoundEngine.PostEvent("LoadCassette", gameObject);
                    AkSoundEngine.PostEvent(play, this.gameObject);
                    isPlaying = true;
                }
                if (stop != "")
                {
                    AkSoundEngine.PostEvent(stop, this.gameObject);
                }
                text.enabled = false;
            }
        }
        else if (isPlaying)
        {
            if (timer <= 0.0f)
            {
                if (doorToUnlock != "")
                    GameObject.Find(doorToUnlock).GetComponent<DoorOpener>().setLockStatus(false);
                Destroy(this.gameObject);
            }
            timer -= Time.deltaTime;
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
