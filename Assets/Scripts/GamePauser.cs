using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            if (isPaused) {Time.timeScale=1;}
            else {Time.timeScale=0;}
            isPaused = !isPaused;
        }
    }
}
