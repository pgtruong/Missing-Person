using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<DoorOpener>();
        GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
