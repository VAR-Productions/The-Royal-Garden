using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public GameObject transitioner;
    void Start()
    {
        button.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        Debug.Log("h");
    }
}
