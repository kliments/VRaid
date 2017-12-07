using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetControllerFunctions : MonoBehaviour {
    
    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        
    }
	
	// Update is called once per frame
	void Update () {
    }

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
}
