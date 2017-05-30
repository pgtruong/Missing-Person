using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DisableMovement : MonoBehaviour {

    public float timeToDisable;
    [SerializeField] private float timer;
    [SerializeField] public bool isDisabled;

    public bool Enabled {
        get { return this.enabled; }
        set { this.enabled = value; }
    }


    // Use this for initialization
	void Start () {
        timer = timeToDisable;
        //toggleDisable(false);
	}

    // Update is called once per frame
    void Update () {
		if (isDisabled)
        {
            if (timer <= 0.0f)
            {
                toggleDisable(true);
                this.enabled = false;
            }
            else
                timer-= Time.deltaTime;
        }
	}

    public void toggleDisable(bool toggle)
    {
        timer = timeToDisable;
        isDisabled = !toggle;
        GetComponent<FirstPersonController>().enabled = toggle;
        Cursor.visible = false;
    }

    
}
