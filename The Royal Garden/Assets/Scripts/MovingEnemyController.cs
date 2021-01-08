using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 1.0f;
    public GameObject walkSpace;
    public enum walkSpaceOrientations
    {
        Horizontal,
        Vertical
    };
    public walkSpaceOrientations walkSpaceOrientation;
    void Start()
    {
        switch (walkSpaceOrientation)
        {
            case walkSpaceOrientations.Horizontal:
                break;
        }
        walkSpace.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
