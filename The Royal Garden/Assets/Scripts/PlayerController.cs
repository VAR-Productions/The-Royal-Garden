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
    public bool frozen = false;

    [Header("Inserts:")]
    public Rigidbody2D rb;
    public Animator animator;
    public Animator sword_animator;
    public GameObject director;
    public GameObject weapon;

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
        if (!frozen)
        {
            Move();
            Aim();
            if (Input.GetKey(KeyCode.Space)) {
                sword_animator.SetBool("Attack", true);
            } else {
                sword_animator.SetBool("Attack", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
        Animate();
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
            if (movementDirection.x != 0)
            {
                animator.SetFloat("Horizontal", movementDirection.x);
            }
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);
    }
    void Aim() 
    {
        if (movementDirection != Vector2.zero && movementDirection.x != 0) 
        {
            Vector2 directorDirection = new Vector2(movementDirection.x, 0);
            directorDirection.Normalize();
            director.transform.localPosition = directorDirection;
        }
    }
    void Attack() {
        //Shoot(fireBall);
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
    void Reorder()
    {
        
    }
}
