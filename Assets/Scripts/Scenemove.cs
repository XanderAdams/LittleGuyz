using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemove : MonoBehaviour
{
    public string sceneName;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadScene();
        }

    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
