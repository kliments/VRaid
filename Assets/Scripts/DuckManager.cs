using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour {

    public GameObject duck;             // The duck prefab to be spawned
    public float spawnTime = 3f;        // Duration between each spawn
    public Transform[] spawnPoints;     // An array of spawn points duck can spawn from
    private GameObject duckInstance;
    public int noOfDucksSpawned;
    public int noOfDucksEscaped;

    // Use this for initialization
    void Start () {
        duckInstance = null;
        noOfDucksSpawned = 0;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if(duckInstance == null)
        {
            duckInstance = Instantiate(duck, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            duckInstance.transform.parent = transform;
            ++noOfDucksSpawned;
            Debug.Log("No. of ducks spawned: " + noOfDucksSpawned);
        }
        
        
    }


    // Update is called once per frame
    void Update () {
		
	}
}
