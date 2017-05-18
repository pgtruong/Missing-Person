using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public float maxStepInterval;
    private float interval;
    Vector3 lastPos;
    bool isWalk = false;

    void Start()
    {
        interval = maxStepInterval;
        lastPos = transform.position;
    }

    void Update()
    {
        if (lastPos != transform.position)
            isWalk = true;
        else
            isWalk = false;
        
        if (isWalk)
        {
            interval -= Time.deltaTime;
            if (interval <= 0)
            {
                interval = maxStepInterval;
                AkSoundEngine.PostEvent("Footstep", this.gameObject);
            }
        }
        else        
            interval = 0;
        lastPos = transform.position; 
    }
}
