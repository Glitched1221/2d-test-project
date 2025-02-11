using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static bool GameIsPaused;
    public float slowdownFactor= 0.05f;
    public float slowndownLength = 2f;

void Update ()
{
   Time.timeScale += (1f / slowndownLength * Time.unscaledDeltaTime);

   if (GameIsPaused == false)
   {
    Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
   }


   
}

public void DoSlowMotion ()
{
 Time.timeScale = slowdownFactor;
 Time.fixedDeltaTime = Time.timeScale * 0.02f;
}
    
}
