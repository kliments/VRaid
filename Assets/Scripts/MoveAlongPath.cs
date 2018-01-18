using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPath : MonoBehaviour {

    private Vector3 start, con1, con2, end;
    private float bezierTime, timeToEnd;
    private Vector3 startPos, endPos;
	// Use this for initialization
	void Start () {
        timeToEnd = 10f;
        start = transform.position;
        genPoints();
    }
	
	// Update is called once per frame
	void Update () {
        bezierTime = bezierTime + Time.deltaTime/timeToEnd;
        if(bezierTime > 1f)
        {
            bezierTime = 0;
        }
        transform.position = Bezier3(start,con1, con2, end, bezierTime);
    }

    void genPoints()
    {
        con1 = new Vector3(Random.Range(-20f,20f), Random.Range(3f, 20f),Random.Range(-30f, 30f));
        con2 = new Vector3(Random.Range(-20f, 20f), Random.Range(3f, 20f), Random.Range(-30f, 30f));
        end = new Vector3(Random.Range(-20f, 20f), Random.Range(3f, 20f), Random.Range(-30f, 30f));
    }

    Vector3 Bezier3(Vector3 s, Vector3 st, Vector3 et, Vector3 e, float t)
    {
        return (((-s + 3 * (st - et) + e) * t + (3 * (s + et) - 6 * st)) * t + 3 * (st - s)) * t + s;
    }
}
