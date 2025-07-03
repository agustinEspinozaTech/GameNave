using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUpdater : MonoBehaviour
{



    void Update()
    {
        if (UIManagerSingleton.instance != null)
        {
            UIManagerSingleton.instance.UpdateTimer();
        }
    }
}
