using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofEffect : MonoBehaviour {

    public GameObject anim;
    private Camera main;
	// Use this for initialization
	void Start () {
        main = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<DucksFlyingManager>().isShot)
        {
            Invoke("ShowAnim", 0.5f);
            Destroy(gameObject, 0.5f);
        }
	}

    void ShowAnim()
    {
        GameObject obj = Instantiate(anim, transform.position, Quaternion.identity, transform.parent);
        obj.transform.LookAt(main.transform);
        Destroy(obj, 0.5f);
    }
}
