using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour {

    public GameObject duck;             // The duck prefab to be spawned
    public float spawnTime = 4f;        // Duration between each spawn
    public Transform[] spawnPoints;     // An array of spawn points duck can spawn from
    private GameObject duckInstance;
    public int noOfDucksSpawned;
    public int noOfDucksEscaped;
    public int noOfDucksKilled;
    public GameObject bucket;
    public GameObject ducksKilledUI;
    public GameObject ducksEscapedUI;
    public GameObject dog;
    public AudioClip oneBark;
    public AudioClip twoBark;

    // Use this for initialization
    void Start () {
        duckInstance = null;
        noOfDucksSpawned = 0;
        noOfDucksEscaped = 0;
        noOfDucksKilled = 0;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if(duckInstance == null)
        {
            dog.GetComponent<Animation>().Play();
            Invoke("DogBark2", 1f);
            Invoke("DogBark1", 3f);
            Invoke("InstantiateDuck", 1f);
        }
        
        
    }


    // Update is called once per frame
    void Update () {
        ducksKilledUI.GetComponent<UnityEngine.UI.Text>().text = "Ducks Killed: " + noOfDucksKilled.ToString();
        ducksEscapedUI.GetComponent<UnityEngine.UI.Text>().text = "Ducks Escaped: " + noOfDucksEscaped.ToString();
	}

    void InstantiateDuck()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        duckInstance = Instantiate(duck, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        duckInstance.transform.parent = transform;
        ++noOfDucksSpawned;
        Debug.Log("No. of ducks spawned: " + noOfDucksSpawned);
        bucket.GetComponent<DeadDuckBucket>().tempDuck = true;
    }

    void DogBark1()
    {
        dog.GetComponent<AudioSource>().clip = oneBark;
        dog.GetComponent<AudioSource>().Play();
    }
    void DogBark2()
    {
        dog.GetComponent<AudioSource>().clip = twoBark;
        dog.GetComponent<AudioSource>().Play();
    }
}
