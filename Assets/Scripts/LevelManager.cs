using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public bool switchScenes;
    private Scene scene;
    public GameObject duckManager;
    public GameObject plane;
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        switchScenes = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(scene.name == "MainScene" && duckManager.GetComponent<DuckManager>().noOfDucksKilled == 1)
        {
           plane.GetComponent<FadeInAndOut>().fIn = true;
            Invoke("Switch", 5f);
        }
        
        if(duckManager.GetComponent<DuckManager>().noOfDucksEscaped == 3)
        {
            Debug.Log("GAME OVER MOTHERFUCKER!");
        }
	}

    void Switch()
    {
        SceneManager.LoadScene("MainScene2");
    }
}
