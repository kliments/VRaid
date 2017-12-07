using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScript : MonoBehaviour {
    private bool chargeDown = false;
    private Vector3 tempPos;
    public GameObject controllerLeft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	       
	}

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "LeftHand")
        {
            Debug.Log("TOUCHINNNGGGG");
            if(controllerLeft.GetComponent<GetControllerFunctions>().Controller.GetHairTrigger())
            {
                tempPos = new Vector3(col.gameObject.transform.position.x, 0.0306f, 0);
                gameObject.transform.localPosition = tempPos;
            }
        }
    }
}
