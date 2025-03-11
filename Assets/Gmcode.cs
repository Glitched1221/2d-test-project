using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using UnityEngine.UI;
using System;

public class Gmcode : MonoBehaviour
{
    // Start is called before the first frame update
     
     public GameObject Pausemenu;
     public static bool GameIsPaused = false;
     public Slider HealthBar;
     public GameObject deathmenu;
      public static bool Gameover = false;
    public GameObject winnmenu;
     public static bool winn = false;
     


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
      if (Gameover == true)
      {
        deathmenu.SetActive(true);
        Time.timeScale = 0f;

        if (winn == true)
        {
           winnmenu.SetActive(true);
        Time.timeScale = 0f;
        }
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
public void UpdateHealthBar(float value)
    {
      HealthBar.value = value;
    }

   
    public void Retry()
    {
      Time.timeScale = 1;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Gameover = false;
    }
   


}