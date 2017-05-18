using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour {

	void Start () {
        AkSoundEngine.PostEvent("Static", this.gameObject);
	}

}
