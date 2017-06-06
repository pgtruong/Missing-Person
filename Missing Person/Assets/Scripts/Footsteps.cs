using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public float maxStepInterval;
    private float interval;
    Vector3 lastPos;
    bool isWalk = false;
    public string footstep;

    void Start()
    {
        interval = maxStepInterval;
        lastPos = transform.position;
        footstep = "Grass";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
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
                AkSoundEngine.PostEvent(footstep, this.gameObject);
            }
        }
        lastPos = transform.position;
    }
}
