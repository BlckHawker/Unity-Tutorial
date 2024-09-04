using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    Text timerText;
    Text buttonText;
    private float timerTime;
    [SerializeField]
    private bool useDeltaTime, startTimer;
    // Start is called before the first frame update
    void Start()
    {
        timerText = transform.Find("Timer Text").GetComponent<Text>();
        timerTime = 0;
        buttonText = transform.Find("Toggle Button/Text").GetComponent<Text>();
        buttonText.text = startTimer ? "Stop" : "Start";
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            if (useDeltaTime)
            {
                timerTime += Time.deltaTime;
            }
            else
            {
                timerTime++;
            }

            timerText.text = $"{(timerTime == 0 ? "0 seconds" : timerTime.ToString("#.## seconds"))}";
        }
    }

    public void ToggleStopwatch()
    {
        startTimer = !startTimer;
        buttonText.text = startTimer ? "Stop" : "Start";
    }


}
