using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(Vector2 direction) {
        rb.velocity = direction * speed;
        transform.Rotate(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}
