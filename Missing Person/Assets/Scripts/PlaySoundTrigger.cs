using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTrigger : MonoBehaviour
{

    public string soundEvent;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AkSoundEngine.PostEvent(soundEvent, this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
