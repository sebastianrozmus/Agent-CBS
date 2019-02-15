using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Vector3 playerVelocity;
    Animator animator;
    float horizontal;
    float vertical;
    float moveLimiter = 0.75f;
    public float runSpeed = 0.1f;
    Rigidbody2D body;

    void Start()
    {
        playerVelocity = Vector3.zero;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) {
            body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter); 
        }
        else {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

        if(horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);

        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("asdasd");
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
