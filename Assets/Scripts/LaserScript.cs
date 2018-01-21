using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserScript : MonoBehaviour {
    private LineRenderer lr;
    private GameObject crossHair;
    private RaycastHit hit;
    private Scene scene;
	// Use this for initialization
	void Start ()
    {
        scene = SceneManager.GetActiveScene();
        lr = GetComponent<LineRenderer>();
        crossHair = transform.GetChild(0).gameObject;
        hit = new RaycastHit();
    }
	
	// Update is called once per frame
	void Update () {
        if (scene.name == "MainScene" || scene.name == "MainScene2" || scene.name == "StartScene")
        {
            lr.SetPosition(0, transform.position + transform.forward * 0.6f);
            lr.SetPosition(1, transform.forward * 100 + transform.position);

            crossHair.SetActive(false);

            if (scene.name == "MainScene" || scene.name == "StartScene")
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
                {
                    Debug.DrawRay(transform.position, transform.forward * 1000, Color.red, 5.0f);
                    if (hit.transform.gameObject.tag == "Ducks")
                    {
                        crossHair.SetActive(true);
                        crossHair.transform.position = hit.transform.position;
                        crossHair.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        
                    }
                    else if(hit.transform.gameObject.name == "Start" || hit.transform.gameObject.name == "Quit")
                    {
                        crossHair.SetActive(true);
                        crossHair.transform.position = hit.transform.position;
                        crossHair.transform.localScale = new Vector3(2f,2f,2f);
                    }
                }
            }
        }
    }


}
