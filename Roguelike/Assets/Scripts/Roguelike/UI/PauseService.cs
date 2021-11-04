using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseService : MonoBehaviour
{
    bool Paused = false;

    public void CamelCase()
    {
        if(Paused)
        {
            Time.timeScale = 1;
             Paused = false;
        }
        else
        {
            Time.timeScale = 0;
            Paused = true;
        }
        
    }
}
