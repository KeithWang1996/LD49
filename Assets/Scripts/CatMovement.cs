using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveForce;
    public float moveInverval;

    public float moveTimer = 0f;

    public AudioClip meow1;
    public AudioClip meow2;
    public AudioClip meow3;
    Rigidbody2D rigidBody;
    Animator animator;
    bool hasCurrentFish = false;
    Transform currentFish;
    AudioSource audioSource;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveTimer = moveInverval;
        audioSource = GetComponent<AudioSource>();
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

        if(currentFish == null)
        {
            hasCurrentFish = false;
        }

        if(hasCurrentFish)
        {
            if (moveTimer >= moveInverval)
            {
                Vector2 diff = currentFish.position - transform.position;
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

    void Walk(float horizontalInput)
    {
        Vector2 walkForce = new Vector2(horizontalInput, 0);
        rigidBody.AddForce(walkForce);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.tag == "Fish")
        {
            animator.SetBool("IsHappy", true);
            if (moveTimer >= moveInverval)
            {
                Vector2 diff = otherObject.transform.position - transform.position;
                diff.Normalize();
                rigidBody.AddForce(diff * moveForce, ForceMode2D.Impulse);
                moveTimer = 0f;

                int randomInt = Random.Range(0, 2);
                switch(randomInt)
                {
                    case 0:
                        audioSource.clip = meow1;
                        break;
                    case 1:
                        audioSource.clip = meow2;
                        break;
                    case 2:
                        audioSource.clip = meow3;
                        break;
                    default:
                        break;
                }
                audioSource.Play();
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
            hasCurrentFish = true;
            currentFish = otherObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.tag == "Fish")
        {
            animator.SetBool("IsHappy", false);
            hasCurrentFish = false;
        }
    }
}
