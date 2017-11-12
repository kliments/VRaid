using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucksFlyingManager : MonoBehaviour {
    private float x, y;
    Vector3 forwardV;
    // Use this for initialization
    void Start()
    {
        UpdateRotation();
        InvokeRepeating("UpdateRotation", 2f, 2f);
    }
    
    // Update is called once per frame
    void Update () {
        transform.position += transform.forward*Time.deltaTime;
	}

    void UpdateRotation()
    {
        x = Random.Range(-60f, -20f);
        y = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(x, y, 0f);
    }
}
