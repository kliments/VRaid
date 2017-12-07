using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLeftController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex(4);
	}
	
	// Update is called once per frame
	void Update () {

    }
}
