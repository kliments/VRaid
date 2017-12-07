using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject controllerRight;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private SteamVR_TrackedController controller;

    private GameObject currentDuck;
    public GameObject fireAnim1;
    public GameObject fireAnim2;
    private ParticleSystem partSys1;
    private ParticleSystem partSys2;
    private AudioSource audio;
    public int ducksKilled;
    // Use this for initialization
    void Start () {
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
        
        ducksKilled = 0;
        partSys1 = fireAnim1.GetComponent<ParticleSystem>();
        partSys2 = fireAnim2.GetComponent<ParticleSystem>();
    }
	// Update is called once per frame
	void Update () {
		if(Controller.GetHairTriggerDown())
        {
            Debug.Log("shoot animation");
            partSys1.Play();
            partSys2.Play();
            Fire();
        }
        else
        {
            partSys1.Stop();
        }
        if(Controller.GetHairTrigger())
        {
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(3999);
        }

        // Check if required number of ducks killed
        if (ducksKilled >= 10)
        {
            Debug.Log("Level Cleared");
        }
        if (currentDuck != null && currentDuck.GetComponentInParent<DuckManager>().noOfDucksSpawned - ducksKilled >= 15)
        {
            Debug.Log("Game Over");
        }
	}
    

    // Fire when trigger on controller clicks
    void Fire()
    {
        Debug.Log("Fired");
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 5.0f);
            if(hit.transform.gameObject.tag == "Ducks")
            {
                currentDuck = hit.transform.gameObject;
                currentDuck.GetComponent<DucksFlyingManager>().isShot = true;
                audio = currentDuck.GetComponent<DucksFlyingManager>().audioSource;
                audio.clip = currentDuck.GetComponent<DucksFlyingManager>().audioWhenDie;
                audio.Play();

                currentDuck.AddComponent<Rigidbody>();
                //Destroy(hit.collider.gameObject.GetComponent<MeshRenderer>());
                //Destroy(hit.collider.gameObject, 1f);
                ducksKilled++;
                Debug.Log("Duck number " + ducksKilled.ToString() + " killed.");
            }
        }
    }
    
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
}
