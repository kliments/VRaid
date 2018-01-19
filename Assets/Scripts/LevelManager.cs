using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public bool switchScenes;
    private Scene scene;
    public GameObject duckManager;
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        switchScenes = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(scene.name == "MainScene" && duckManager.GetComponent<DuckManager>().noOfDucksKilled == 1)
        {
            SceneManager.LoadScene("MainScene2");
        }
        
        if(duckManager.GetComponent<DuckManager>().noOfDucksEscaped == 5)
        {
            Debug.Log("GAME OVER MOTHERFUCKER!");
        }
	}
}
