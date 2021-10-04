using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotFishActions : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
