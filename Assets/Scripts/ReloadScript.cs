﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScript : MonoBehaviour {
    public GameObject shooter;
    private Vector3 tempPos;
    public GameObject controllerLeft;
    public bool chargedDown;
    public bool chargedUp;
    private Vector3 chargerPos;
    public AudioClip firstReload;
    public AudioClip secondReload;
    public AudioSource audioSource;
    private byte green, blue;
    private bool goUp, goDown;
	// Use this for initialization
	void Start () {
        goUp = true;
        goDown = false;
        green = 0;
        blue = 0;
        chargedDown = false;
        chargedUp = false;
		chargerPos = new Vector3(-0.034f, -0.004f, 0);
        GetComponent<AudioSource>().clip = firstReload;
    }
	
	// Update is called once per frame
	void Update () {
        if (shooter.GetComponent<ShootScript>().noOfBullets < 1)
        {
            if (goUp)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color32(255, green+=5, blue+=5, 255);
                if (green == 255 || blue == 255)
                {
                    goUp = false;
                    goDown = true;
                }
            }
            else if (goDown)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color32(255, green-=5, blue-=5, 255);
                if (green == 0 || blue == 0)
                {
                    goUp = true;
                    goDown = false;
                }
            } 
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        }
        if(chargedDown && chargedUp)
        {
            shooter.GetComponent<ShootScript>().reloaded = true;
            gameObject.transform.localPosition = chargerPos;
        }

        else if(gameObject.transform.localPosition.x <= -0.034f)
        {
            gameObject.transform.localPosition = chargerPos;
        }
	       
	}

    void OnTriggerStay(Collider col)
    {
        if(shooter.GetComponent<ShootScript>().noOfBullets>0)
        {
            if(col.gameObject.name == "LeftHand")
            {
                if(controllerLeft.GetComponent<GetControllerFunctions>().Controller.GetHairTrigger())
                {
                    Debug.Log(gameObject.transform.forward);
                    col.transform.parent = gameObject.transform.parent;
                    tempPos = new Vector3(col.gameObject.transform.localPosition.x, -0.004f, 0);
                    gameObject.transform.localPosition = tempPos;
                    col.transform.parent = controllerLeft.transform;

                    if(gameObject.transform.localPosition.x >= -0.024f)
                    {
                        gameObject.transform.localPosition = new Vector3(-0.024f, -0.004f, 0);
                        chargedDown = true;
                        if (!audioSource.isPlaying)
                        {
                            audioSource.clip = firstReload;
                            audioSource.Play();
                        }
                    
                    }
                    if (gameObject.transform.localPosition.x <= -0.030f && chargedDown)
                    {
                        gameObject.transform.localPosition = chargerPos;
                        chargedUp = true;
                        audioSource.clip = secondReload;
                        audioSource.Play();
                    
                    }
                }
            }
        }
    }
}
