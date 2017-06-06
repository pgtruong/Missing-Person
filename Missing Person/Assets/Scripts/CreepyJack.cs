using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyJack : MonoBehaviour {

    void Start()
    {
        AkSoundEngine.PostEvent("EndPiano", this.gameObject);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 1.1f, transform.position.z), Time.deltaTime * 2f);
    }
}
