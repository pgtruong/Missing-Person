using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

    public GameObject dependency;
    private bool hasStarted = false;

    void Update()
    {        
        if (dependency == null && !hasStarted)
        {
            hasStarted = true;            
            AkSoundEngine.PostEvent("StartPiano", this.gameObject);
        }        
    }
}
