using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucksFlyingManager : MonoBehaviour {
    private float x, y;
    public bool isShot = false;
    public AudioSource audioSource;
    public AudioClip audioWhenSpawn;
    public AudioClip audioWhenDie;
    private ParticleSystem blood;
    Vector3 forwardV;
    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        UpdateRotation();
        InvokeRepeating("UpdateRotation", 2f, 2f);
        blood = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        //Destroys after 10 seconds
        //DuckDestroyer();
        spawnSound();
    }
    
    // Update is called once per frame
    void Update () {
        if(isShot)
        {
            blood.Play();
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime;
        }
	}

    void UpdateRotation()
    {
        if(!isShot)
        {
            x = Random.Range(-60f, -20f);
            y = Random.Range(0f, 360f);
            transform.rotation = Quaternion.Euler(x, y, 0f);
        }
    }

    void DuckDestroyer()
    {
        if(!isShot)
        {
            Destroy(gameObject, 10.0f);
        }
    }

    void spawnSound()
    {
        audioSource.clip = audioWhenSpawn;
        audioSource.Play();
    }

    public void deathSound()
    {
        audioSource.clip = audioWhenDie;
        audioSource.Play();
    }
}
