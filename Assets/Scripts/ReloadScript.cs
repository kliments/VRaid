using System.Collections;
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
	// Use this for initialization
	void Start () {
        chargedDown = false;
        chargedUp = false;
		chargerPos = new Vector3(-0.35f, 0.0306f, 0);
        GetComponent<AudioSource>().clip = firstReload;
    }
	
	// Update is called once per frame
	void Update () {
        if(chargedDown && chargedUp)
        {
            shooter.GetComponent<ShootScript>().reloaded = true;
            gameObject.transform.localPosition = chargerPos;
        }

        else if(gameObject.transform.localPosition.x <= -0.35f)
        {
            gameObject.transform.localPosition = chargerPos;
        }
	       
	}

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "LeftHand")
        {
            if(controllerLeft.GetComponent<GetControllerFunctions>().Controller.GetHairTrigger())
            {
                Debug.Log(gameObject.transform.forward);
                col.transform.parent = gameObject.transform.parent;
                tempPos = new Vector3(col.gameObject.transform.localPosition.x, 0.0306f, 0);
                gameObject.transform.localPosition = tempPos;
                col.transform.parent = controllerLeft.transform;

                if(gameObject.transform.localPosition.x >= -0.26f)
                {
                    gameObject.transform.localPosition = new Vector3(-0.26f, 0.0306f, 0);
                    chargedDown = true;
                    //call script to make chk chk sound
                    /*
                    GetComponent<AudioSource>().clip = firstReload;
                    GetComponent<AudioSource>().Play();*/
                }
                if (gameObject.transform.localPosition.x <= -0.3f && chargedDown)
                {
                    gameObject.transform.localPosition = chargerPos;
                    chargedUp = true;
                    //call script to make chk chk sound
                    /*
                    GetComponent<AudioSource>().clip = secondReload;
                    GetComponent<AudioSource>().Play();*/
                }
            }
        }
    }
}
