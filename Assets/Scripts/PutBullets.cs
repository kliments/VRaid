using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBullets : MonoBehaviour {
    private Vector3 position;
    private Transform parent;
    private Vector3 scale;
    private Quaternion rotation;
    private GameObject clone;
    public AudioSource audioSource;
    public AudioClip reloadClip;
	// Use this for initialization
	void Start () {
        position = transform.position;
        parent = transform.parent;
        scale = transform.localScale;
        rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Reloader")
        {
            audioSource.clip = reloadClip;
            audioSource.Play();
            col.gameObject.GetComponent<ReloadScript>().shooter.GetComponent<ShootScript>().noOfBullets+=1;
            clone = Instantiate(gameObject, parent);
            clone.transform.position = position;
            clone.transform.localScale = scale;
            clone.transform.rotation = rotation;
            Destroy(gameObject);
        }
        else if(col.gameObject.name == "LeftHand")
        {
            gameObject.transform.parent = col.gameObject.transform;
        }
    }
}
