using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timecolldown;
    public float timeablitycolldown;
    public static bool GameIsPaused;
    public float slowdownFactor= 0.05f;
    public float slowndownLength = 2f;

void Update ()
{
   Time.timeScale += (1f / slowndownLength * Time.unscaledDeltaTime);
    timeablitycolldown -= Time.deltaTime;


   if (GameIsPaused == false)
   {
    Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
   }


   
}

public void DoSlowMotion ()
{
 if (timeablitycolldown > 0)
                return;
 Time.timeScale = slowdownFactor;
 Time.fixedDeltaTime = Time.timeScale * 0.02f;
 timeablitycolldown = timecolldown;
}
    
}
