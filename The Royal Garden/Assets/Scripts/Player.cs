using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats:")]
    /*public Vector2 movementDirection;
    public float movementSpeed;*/

    [Header("Properties:")]
    /*public float addMovementSpeed = 1;*/
    public bool frozen = false;

    [Header("Inserts:")]
    public Rigidbody2D rb;
    public Animator animator;
    //public Animator sword_animator;
    public GameObject director;
    public Movement movement;
    public Weapon sword;

    [Header("Prefabs:")]
    public GameObject fireBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.ProcessInputs(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        if (!frozen)
        {
            movement.Move();
            Aim();
            if (Input.GetKey(KeyCode.Space)) {
                sword.Attack(true);
            } else {
                sword.Attack(false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
        Animate();
    }
    void Animate()
    {
        if (movement.direction != Vector2.zero)
        {
            if (movement.direction.x != 0)
            {
                animator.SetFloat("Horizontal", movement.direction.x);
            }
            //animator.SetFloat("Vertical", movement.direction.y);
        }
        animator.SetFloat("Speed", movement.speed);
    }
    void Aim() 
    {
        if (movement.direction != Vector2.zero && movement.direction.x != 0) 
        {
            Vector2 directorDirection = new Vector2(movement.direction.x, 0);
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
