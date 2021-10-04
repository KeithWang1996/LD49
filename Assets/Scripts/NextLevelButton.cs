using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    Image image;

    public string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonDown()
    {
        image.color = new Color32(100, 100, 100, 255);
        SceneManager.LoadScene(nextLevelName);
    }

    public void ButtonUp()
    {
        image.color = new Color32(255, 255, 255, 255);
    }
}
