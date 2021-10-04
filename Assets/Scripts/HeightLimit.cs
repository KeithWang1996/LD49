using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightLimit : MonoBehaviour
{
    public Image victoryMenu;

    SpriteRenderer spriteRenderer;
    int catCounter = 0;
    bool isBeingTouched = true;
    bool isGameOver = false;
    float untouchedTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(catCounter > 0 && !isBeingTouched)
        {
            spriteRenderer.color = new Color32(255, 0, 0, 100);
            isBeingTouched = true;
            untouchedTimer = 3f;
        }

        if(catCounter <= 0 && isBeingTouched)
        {
            spriteRenderer.color = new Color32(0, 255, 0, 100);
            isBeingTouched = false;
        }

        if(!isBeingTouched)
        {
            untouchedTimer -= Time.deltaTime;
            if(untouchedTimer <= 0f && !isGameOver)
            {
                Victory();
                isGameOver = true;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void Victory()
    {
        victoryMenu.gameObject.SetActive(true);
        Debug.Log("Victory!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cat")
        {
            catCounter++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            catCounter--; 
        }
    }
}
