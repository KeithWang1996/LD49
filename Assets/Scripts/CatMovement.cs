using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveForce;
    public float moveInverval;

    float moveTimer = 0f;
    Rigidbody2D rigidBody;
    Animator animator;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //Walk(horizontalInput);
        float xVelocity = rigidBody.velocity.x;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (xVelocity > 0.01)
        {

            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void Walk(float horizontalInput)
    {
        Vector2 walkForce = new Vector2(horizontalInput, 0);
        rigidBody.AddForce(walkForce);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if(otherObject.tag == "Fish")
        {
            if(moveTimer >= moveInverval)
            {
                Vector2 diff = otherObject.transform.position - transform.position;
                diff.Normalize();
                rigidBody.AddForce(diff * moveForce, ForceMode2D.Impulse);
                moveTimer = 0f;
            }
            else
            {
                moveTimer += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.tag == "Fish")
        {
            animator.SetBool("IsHappy", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.tag == "Fish")
        {
            animator.SetBool("IsHappy", false);
        }
    }
}