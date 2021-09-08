using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float timer;
    public float timeLess;
    public Text timerText;

    public bool end;
    public bool reset;

    public static TimerManager instance;



    void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    void Start()
    {
        timerText.text = timer.ToString();
        reset = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0)
        {
            TimeLess(Time.deltaTime);
            timerText.text = ((int)timer).ToString();
        }
        else if (!end)
        {
            end = true;
            timerText.text = "0";
        }

    }

    public void TimeLess(float less)
    {
        timer -= less;
    }
}
