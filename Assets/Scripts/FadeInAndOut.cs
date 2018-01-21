using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour {


    public GameObject plane;
    public bool fIn, fOut;
    private MeshRenderer rend;
    private float opacity;
    private Color col;
    public GameObject start, quit;
    private Scene scene;
	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();
        fIn = false;
        fOut = true;
        rend = plane.GetComponent<MeshRenderer>();

        if (scene.name != "StartScene")
        {
            start.SetActive(false);
            quit.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(fIn)
        {
            FadeIn();
        }

        if(fOut)
        {
            FadeOut();
        }

	}

    void FadeIn()
    {
        plane.SetActive(true);
        opacity = Time.deltaTime / 5f;
        col = rend.material.color;
        col.a += opacity;
        plane.GetComponent<Renderer>().material.color = col;
        if (rend.material.color.a == 1)
        {
            fIn = false;
            plane.SetActive(false);
        }
    }

    void FadeOut()
    {
        plane.SetActive(true);
        opacity = Time.deltaTime / 3f;
        col = rend.material.color;
        col.a -= opacity;
        plane.GetComponent<MeshRenderer>().material.color = col;
        if(rend.material.color.a <= 0f)
        {
            fOut = false;
            plane.SetActive(false);
        }
    }
}
