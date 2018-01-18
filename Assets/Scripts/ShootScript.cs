using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject controllerRight;
    public GameObject reloader;
    private GameObject currentDuck;
    public GameObject fireAnim1;
    public GameObject fireAnim2;
    private ParticleSystem partSys1;
    private ParticleSystem partSys2;
    private AudioSource audio;
    public AudioSource audioSource;
    public AudioClip fireClip;
    public AudioClip emptyGunClip;
    public int noOfDucksKilled;
    public int noOfBullets;
    public bool reloaded;

    // Use this for initialization
    void Start () {
        noOfDucksKilled = 0;
        partSys1 = fireAnim1.GetComponent<ParticleSystem>();
        partSys2 = fireAnim2.GetComponent<ParticleSystem>();
        reloaded = false;
        noOfBullets = 5;
    }
	// Update is called once per frame
	void Update () {
        if (controllerRight.GetComponent<GetControllerFunctions>().Controller.GetHairTriggerDown())
        {
            if (noOfBullets > 0 && reloaded)
            {
                partSys1.Play();
                partSys2.Play();
                Fire();
                controllerVibration();
                noOfBullets--;
                reloaded = false;
                reloader.GetComponent<ReloadScript>().chargedDown = false;
                reloader.GetComponent<ReloadScript>().chargedUp = false;
            }
            else if(noOfBullets<=0)
            {
                Debug.Log("No more bullets!");
                audioSource.clip = emptyGunClip;
                audioSource.Play();
            }
            else if(!reloaded)
            {
                Debug.Log("Reload please!");
            }
        }
        // Check if required number of ducks killed
        if (noOfDucksKilled >= 10)
        {
            Debug.Log("Level Cleared");
        }
        if (currentDuck != null && currentDuck.GetComponentInParent<DuckManager>().noOfDucksEscaped == 5)
        {
            Debug.Log("Game Over");
        }
    }
    
    // Fire when trigger on controller clicks
    void Fire()
    {
        Debug.Log("Fired");
        audioSource.clip = fireClip;
        audioSource.Play();
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

                noOfDucksKilled++;
                Debug.Log("No. of ducks killed: " + noOfDucksKilled);
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
