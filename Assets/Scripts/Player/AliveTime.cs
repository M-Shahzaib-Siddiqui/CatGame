using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliveTime : MonoBehaviour
{
    private float timeRemaining = 0f;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining>=0) {
            timeRemaining += Time.deltaTime;
            DisplayTime(timeRemaining);    
        }
    }

    private void DisplayTime(float timeToDisplay) {
        timeToDisplay+=1;
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes,seconds);
    }
}
