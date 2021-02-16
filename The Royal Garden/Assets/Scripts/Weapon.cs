using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool flipAtStart = false;
    public Sprite idleSprite;
    public Sprite attackSprite;
    public GameObject spriteChild;
    // Start is called before the first frame update
    void Start()
    {
        spriteChild = transform.GetChild(0).gameObject;
        
        if (flipAtStart)
        {
            Flip();
        }
        spriteChild.GetComponent<SpriteRenderer>().sprite = idleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Flip()
    {
        //transform.Rotate(0f, 180f, 0f);
    }
    public void Attack(bool attackBool)
    {
        if (attackBool)
        {
            spriteChild.GetComponent<SpriteRenderer>().sprite = attackSprite;
        } else
        {
            spriteChild.GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
    }
}
