using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishActions : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 2f;
    bool isBeenEating = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeenEating)
        {
            if(lifeTime > 0f)
            {
                lifeTime -= Time.deltaTime;
            }
            else
            {
                Object.Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isBeenEating && collision.gameObject.tag == "Cat")
        {
            isBeenEating = true;
            GetComponent<Animator>().SetBool("FishIsBeenEating", true);
        }
    }
}
