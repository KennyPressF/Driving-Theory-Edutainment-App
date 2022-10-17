using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    TextQuiz textQuiz;
    ImageQuiz imageQuiz;
    QuizEndScreen quizEndScreen;

    public bool quizIsComplete;
    public int quizCoinValue;

    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Text Quiz")
        {
            textQuiz = FindObjectOfType<TextQuiz>();
            quizEndScreen = FindObjectOfType<QuizEndScreen>();

            textQuiz.gameObject.SetActive(true);
            quizEndScreen.gameObject.SetActive(false);
        }

        else if (SceneManager.GetActiveScene().name == "Image Quiz")
        {
            imageQuiz = FindObjectOfType<ImageQuiz>();
            quizEndScreen = FindObjectOfType<QuizEndScreen>();

            imageQuiz.gameObject.SetActive(true);
            quizEndScreen.gameObject.SetActive(false);
        }

        else
        {
            Debug.Log("Scene name probably wrong ya dummy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (quizIsComplete == true)
        {
            quizEndScreen.gameObject.SetActive(true);
        }
    }
}
