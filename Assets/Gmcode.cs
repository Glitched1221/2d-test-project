using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gmcode : MonoBehaviour
{
    // Start is called before the first frame update
     
     public GameObject Pausemenu;
     public static bool GameIsPaused = false;


    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      
      
       if (GameIsPaused)
       {
        ResumeGame();
       }
      else{
        Pause();
      }


    }
    public void StartGame()
    {
      SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
      Pausemenu.SetActive(false);
      Time.timeScale = 1;
      GameIsPaused = false;
    }
   
    public void Pause()
    {
      Pausemenu.SetActive(true);
      Time.timeScale = 0;
      GameIsPaused = true;
    }

    public void LoadMenu()
    {
      SceneManager.LoadScene("Mainmenu");
    }
}
