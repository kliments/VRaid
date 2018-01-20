using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public bool switchScenes;
    private Scene scene;
    public GameObject duckManager;
    public GameObject cameraEye;
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        switchScenes = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(scene.name == "MainScene" && duckManager.GetComponent<DuckManager>().noOfDucksKilled == 1)
        {
           cameraEye.GetComponent<FadeInAndOut>().fIn = true;
            Invoke("Switch2", 5f);
        }
        
        if(scene.name == "MainScene2" && duckManager.GetComponent<DuckManager>().noOfDucksKilled == 1)
        {
            cameraEye.GetComponent<FadeInAndOut>().fIn = true;
            Debug.Log("change scene");
            Invoke("Switch3", 5f);
        }
        if(duckManager.GetComponent<DuckManager>().noOfDucksEscaped == 3)
        {
            Debug.Log("GAME OVER MOTHERFUCKER!");
        }
	}

    void Switch2()
    {
        SceneManager.LoadScene("MainScene2");
    }
    void Switch3()
    {
        SceneManager.LoadScene("MainScene4");
    }
}
