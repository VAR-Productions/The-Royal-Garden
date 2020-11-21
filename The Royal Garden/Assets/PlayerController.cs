using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Header("Properties:")]
    public float addMovementSpeed = 1;

    [Header("Inserts:")]
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject director;

    [Header("Prefabs:")]
    public GameObject fireBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        Aim();
        Animate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(fireBall);
        }
    }
    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }
    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * addMovementSpeed;
    }
    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);
    }
    void Aim() 
    {
        if (movementDirection != Vector2.zero) 
        {
            director.transform.localPosition = movementDirection;
        }
    }
    void Shoot(GameObject type)
    {
        //print(transform.position.x);

        Vector3 shotPosition = new Vector3(director.transform.position.x, director.transform.position.y, 0);
        GameObject shot = Instantiate(type, shotPosition, Quaternion.identity);

        Vector2 shootingDirection = director.transform.localPosition;
        shootingDirection.Normalize();
        shot.GetComponent<ShotController>().Shoot(shootingDirection);
        Destroy(shot, 2.0f);
    }
}
