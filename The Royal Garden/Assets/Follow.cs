using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float cameraDistance = 30.0f;
    void Start()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
