using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {
    public GameObject fireAnim;
    private ParticleSystem partSys;
	// Use this for initialization
	void Start () {
        partSys = fireAnim.GetComponent<ParticleSystem>();
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("shoot animation");
            partSys.Play();
        }
        else
        {
            partSys.Stop();
        }
        
	}
}
