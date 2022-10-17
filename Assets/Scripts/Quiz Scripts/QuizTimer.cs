using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTimer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    public float timeToShowCorrectAnswer = 5f;

    public bool loadNextQuestion;
    public float fillFraction;

    public bool isAnsweringQuestion;
    float timerValue;
    
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion == true)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }

        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
