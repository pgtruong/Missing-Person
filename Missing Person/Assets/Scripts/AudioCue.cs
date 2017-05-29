using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCue : MonoBehaviour {

    public GameObject dependency;
    private bool hasStarted = false;
    public string soundToPlay;

    void Update()
    {        
        if (dependency == null && !hasStarted)
        {
            hasStarted = true;            
            AkSoundEngine.PostEvent(soundToPlay, this.gameObject);
        }        
    }
}
