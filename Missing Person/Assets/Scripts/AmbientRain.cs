using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientRain : MonoBehaviour {

    private bool isRaining = true;
    void Start () {
        AkSoundEngine.PostEvent("StartRain", this.gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRaining)
            {
                AkSoundEngine.PostEvent("StopRain", this.gameObject);
                isRaining = false;
            }
            else
            {
                AkSoundEngine.PostEvent("StartRain", this.gameObject);
                isRaining = true;
            }
        }
    }
}
