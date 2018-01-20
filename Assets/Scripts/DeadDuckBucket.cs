using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDuckBucket : MonoBehaviour {

    public GameObject deadDuck;
    public GameObject anim;
    public GameObject duckManager;
    private GameObject duck;
    public bool tempDuck;

	// Use this for initialization
	void Start () {
        tempDuck = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(duckManager.transform.childCount>0)
        {
            duck = duckManager.transform.GetChild(0).gameObject;
        }

        if (duck != null && duck.GetComponent<DucksFlyingManager>().isShot && tempDuck)
        {
            tempDuck = false;
            Invoke("StartAnim", 1f);
        }
	}

    void StartAnim()
    {
        anim.GetComponent<ParticleSystem>().Play();
        Instantiate(deadDuck, anim.transform.position, Quaternion.identity, transform);
    }
}
