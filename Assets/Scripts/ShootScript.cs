using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int noOfBullets;
    public bool reloaded;
    public GameObject duckManager;
    public GameObject bulletsUI;
    public GameObject messageUI;
    public GameObject bulletArrow;


    // Use this for initialization
    void Start () {
        partSys1 = fireAnim1.GetComponent<ParticleSystem>();
        partSys2 = fireAnim2.GetComponent<ParticleSystem>();
        reloaded = true;
        noOfBullets = 5;
    }
	// Update is called once per frame
	void Update () {
        bulletsUI.GetComponent<TextMesh>().text = noOfBullets.ToString();
        if (noOfBullets > 0 && reloaded)
        {
            messageUI.GetComponent<TextMesh>().text = "READY";
            messageUI.GetComponent<TextMesh>().color = Color.green;
        } else if (noOfBullets == 0)
        {
            messageUI.GetComponent<TextMesh>().text = "NO BULLETS";
            messageUI.GetComponent<TextMesh>().color = Color.red;
            bulletArrow.SetActive(true);
        } else
        {
            messageUI.GetComponent<TextMesh>().text = "RELOAD";
            messageUI.GetComponent<TextMesh>().color = Color.red;
            bulletArrow.SetActive(false);
        }
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
            else if(noOfBullets == 0)
            {
                reloaded = false;
                Debug.Log("No more bullets!");
                messageUI.GetComponent<TextMesh>().text = "NO BULLETS";
                messageUI.GetComponent<TextMesh>().color = Color.red;
                audioSource.clip = emptyGunClip;
                audioSource.Play();
            }
            else if(!reloaded)
            {
                Debug.Log("Reload please!");
                messageUI.GetComponent<TextMesh>().text = "RELOAD";
                messageUI.GetComponent<TextMesh>().color = Color.red;
                audioSource.clip = emptyGunClip;
                audioSource.Play();
            }
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
                ++duckManager.GetComponent<DuckManager>().noOfDucksKilled;
                Debug.Log("Ducks killed = " + duckManager.GetComponent<DuckManager>().noOfDucksKilled);
            }

            else if(hit.transform.gameObject.name == "Start")
            {
                SceneManager.LoadScene("MainScene");
            } else if (hit.transform.gameObject.name == "Quit")
            {
                Application.Quit();
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
