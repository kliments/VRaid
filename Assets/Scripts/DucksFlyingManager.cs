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
    private Vector3 forwardV;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateRotation();
        InvokeRepeating("UpdateRotation", 2f, 2f);
        blood = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

        //Call Destroy function after 10 seconds
        Invoke("DuckDestroyer", 10);
        spawnSound();
    }
    
    // Update is called once per frame
    void Update () {
        if(isShot)
        {
            blood.Play();
            Destroy(gameObject, 5);
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

            ++GetComponentInParent<DuckManager>().noOfDucksEscaped;
            Debug.Log("No. of ducks escaped:" + GetComponentInParent<DuckManager>().noOfDucksEscaped);
            Destroy(gameObject);
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
