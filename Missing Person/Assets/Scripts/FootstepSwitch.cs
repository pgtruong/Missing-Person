using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSwitch : MonoBehaviour {

    public Footsteps footsteps;

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "FootstepTrigger1")
            if (footsteps.footstep == "Grass")
            {
                footsteps.footstep = "House";
            }
            else
                footsteps.footstep = "Grass";
            else if (gameObject.name == "FootstepTrigger2")
            {
                if (footsteps.footstep == "House")
                {
                    footsteps.footstep = "Blood";
                }
                else
                    footsteps.footstep = "House";
            }
        }
    }
}
