using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public string sceneName;
    public Transitioner transitioner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("SceneChange");
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }*/
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().frozen = true;
            Debug.Log("SceneChange");
            transitioner.TransitionScene(sceneName);
        }
    }
}
