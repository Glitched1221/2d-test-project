using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelOn : MonoBehaviour
{
    // Start is called before the first frame update public string levelName;
    public string levelName;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
