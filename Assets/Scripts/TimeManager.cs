using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timecolldown = 5f;
    public float timeablitycolldown = 0f;
    public static bool GameIsPaused;
    public float slowdownFactor= 0.05f;
    public float slowndownLength = 2f;
    public static Gmcode gmcode;
     public static bool Gameover;


void Update ()
{
    if (GameIsPaused == false)
    {

   Time.timeScale += 1f / slowndownLength * Time.deltaTime; 
    timeablitycolldown -= Time.deltaTime;
        
    }
    Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
   
}

public void DoSlowMotion ()
{
     if (GameIsPaused == true && Gameover == true)
    {
        return;
    }

 if (timeablitycolldown > 0)
                return;
                
 Time.timeScale = slowdownFactor;
 Time.fixedDeltaTime = Time.timeScale * 0.05f;
 timeablitycolldown = timecolldown;
}
    
}
