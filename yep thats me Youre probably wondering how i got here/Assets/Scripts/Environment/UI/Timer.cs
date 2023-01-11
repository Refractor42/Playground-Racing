using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
  private float startTime;
  private bool finished = false;

    void Start()
    {
        startTime = Time.time;

    }
    // Update is called once per frame 
    void Update()
    {
        if (finished)
            return;

        float timer = Time.time - startTime;

        System.TimeSpan t = System.TimeSpan.FromSeconds(timer);
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);
        // timerText.text = minutes + ":" + seconds;
    }
        public void Finish()
        {
            finished = true;
        timerText.color = Color.gray;

        }
           
    
}
