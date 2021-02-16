using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transform;
    public float movementSpeed = 1.0f;
    public WalkSpace walkSpace;
    public Movement movement;
    public int currentJoint = 1;
    public int currentJointAdd = 1;
    /*public enum walkSpaceOrientations
    {
        Horizontal,
        Vertical
    };
    public walkSpaceOrientations walkSpaceOrientation;*/
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentJoint);
        if (movement.Target(walkSpace.joints[currentJoint].transform.position))
        {
            if (currentJoint == walkSpace.joints.Count - 1 || (currentJoint == 0 && currentJointAdd == -1))
            {
                //Debug.Log("Fy");
                currentJointAdd *= -1;
            }
            currentJoint += currentJointAdd;
        }
    }
    void Reset()
    {
        //Debug.Log(walkSpace.start.transform.position);
        transform.position = walkSpace.start.transform.position;
    }
}
