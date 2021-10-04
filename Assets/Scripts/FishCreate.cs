using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            CreateFish();
        }
    }

    public void CreateFish()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0.01f;
        Instantiate(fish, position, Quaternion.identity);
    }
}
