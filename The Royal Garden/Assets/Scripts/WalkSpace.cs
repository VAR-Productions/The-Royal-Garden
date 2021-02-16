using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSpace : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public List<GameObject> joints = new List<GameObject>();
    public Vector3 startPosition;
    public Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        joints.Insert(0, start);
        joints.Add(end);
    }

    // Update is called once per frame
    void Update()
    {
        startPosition = start.transform.position;
        endPosition = end.transform.position;
        /*Debug.Log(startPosition);
        Debug.Log(endPosition);*/
    }
}
