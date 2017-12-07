using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject controllerRight;

    private GameObject currentDuck;
    public GameObject fireAnim1;
    public GameObject fireAnim2;
    private ParticleSystem partSys1;
    private ParticleSystem partSys2;
    private AudioSource audio;
    public int ducksKilled;
    public int nrOfBullets;
    public bool reloaded = true;
    // Use this for initialization
    void Start () {
        ducksKilled = 0;
        partSys1 = fireAnim1.GetComponent<ParticleSystem>();
        partSys2 = fireAnim2.GetComponent<ParticleSystem>();

        nrOfBullets = 5;
    }
	// Update is called once per frame
	void Update () {
        if (controllerRight.GetComponent<GetControllerFunctions>().Controller.GetHairTriggerDown())
        {
            if (nrOfBullets > 0)
            {
                Debug.Log("shoot animation");
                partSys1.Play();
                partSys2.Play();
                Fire();
                controllerVibration();
                nrOfBullets--;
            }
            else
            {
                Debug.Log("No more bullets!");
            }
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

                ducksKilled++;
                Debug.Log("Duck number " + ducksKilled.ToString() + " killed.");
            }
        }
    }
    
    void controllerVibration()
    {
        if(controllerRight.GetComponent<GetControllerFunctions>().Controller.GetHairTriggerDown())
        {
            StartCoroutine(vibration(0.2f, 3999));
        }
    }
    IEnumerator vibration(float length, float strength)
    {
        for(float i=0; i<length; i+=Time.deltaTime)
        {
            SteamVR_Controller.Input((int)controllerRight.GetComponent<GetControllerFunctions>().trackedObj.index).TriggerHapticPulse(3999);
            yield return null;
        }
    }
}
