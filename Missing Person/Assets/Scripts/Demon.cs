using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demon : MonoBehaviour {

    public float rayDistance;
    public bool iAmClose;
    public float timeToWait;
    private float timer;
    private bool seen;

	// Use this for initialization
	void Start () {
        timer = timeToWait;
        seen = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!seen)
        {
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.forward * rayDistance);
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
            {
                iAmClose = (hit.collider.tag == "Demon");
            }
            if (iAmClose)
            {
                seen = true;
            }
        }
        else
        {
            if (!GetComponent<DisableMovement>().isDisabled)
            {
                this.GetComponent<DisableMovement>().toggleDisable(false);
                GameObject.Find("Void Demon").GetComponent<Animation>().Play();
                AkSoundEngine.PostEvent("Roar", gameObject);
            }
            else
            {
                if (timer <= 0.0f)
                {
                    Application.Quit();
                }
                else
                    timer -= Time.deltaTime;
            }
        }
    }
}
