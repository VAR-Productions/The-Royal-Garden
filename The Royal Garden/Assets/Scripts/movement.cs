using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform transform;
    public Vector2 direction;
    public float speed;
    public float addSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ProcessInputs(Vector2 dir)
    {
        direction = dir;
        speed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
        direction.Normalize();
        //Debug.Log(direction.x);
    }
    public void Move()
    {
        rb.velocity = direction * speed * addSpeed;
    }
    public bool Target(Vector3 target)
    {
        //Debug.Log(target.x);
        ProcessInputs(new Vector2(target.x - transform.position.x, target.y - transform.position.y));
        Move();
        return (Vector3.Distance(target, transform.position) < 0.1);
        /*float step =  speed * addSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, 0.001f);*/

    }
}
