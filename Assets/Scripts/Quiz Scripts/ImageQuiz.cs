using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImageQuiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] Image questionImage;
    [SerializeField] List<ImageQuestionSO> questionList;
    ImageQuestionSO imageQuestionSO;
    public int currentQuestionIndex;
    public int maxQuestionIndex;
    [SerializeField] TextMeshProUGUI questionCounter;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button Sprites")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite chosenAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    QuizTimer timer;

    [Header("Misc")]
    Score score;
    QuizManager quizManager;
    GameManager gameManager;
    AudioManager audioManager;

    void Awake()
    {
        timer = FindObjectOfType<QuizTimer>();
        score = FindObjectOfType<Score>();
        quizManager = FindObjectOfType<QuizManager>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        quizManager.quizIsComplete = false;
        maxQuestionIndex = questionList.Count / 2;
    }

    // Update is called once per frame
    void Update()
    {
        currentQuestionIndex = score.GetQuestionsSeen();
        timerImage.fillAmount = timer.fillFraction;

        questionCounter.text = "Question: " + currentQuestionIndex + "/" + maxQuestionIndex;

        if (timer.loadNextQuestion == true)
        {
            if (currentQuestionIndex >= maxQuestionIndex)
            {
                quizManager.quizIsComplete = true;
                return;
            }

            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }

        else if (hasAnsweredEarly == false && timer.isAnsweringQuestion == false)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void GetNextQuestion()
    {
        if (questionList.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            score.IncrementQuestionsSeen();
        }
    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0, questionList.Count);
        imageQuestionSO = questionList[index];

        if (questionList.Contains(imageQuestionSO))
        {
            questionList.Remove(imageQuestionSO);
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = imageQuestionSO.GetQuestion();
        questionImage.sprite = imageQuestionSO.GetImage();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = imageQuestionSO.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        audioManager.PlayAudio("Button Press");
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void DisplayAnswer(int index)
    {
        Image selectedButtonImage;
        Image correctButtonImage;
        correctAnswerIndex = imageQuestionSO.GetCorrectAnswerIndex();
        string correctAnswerString = imageQuestionSO.GetAnswer(correctAnswerIndex);

        if (index == correctAnswerIndex)
        {
            audioManager.PlayAudio("Right Answer");
            questionText.text = "Correct!";
            selectedButtonImage = answerButtons[index].GetComponent<Image>();
            selectedButtonImage.sprite = chosenAnswerSprite;
            selectedButtonImage.color = Color.green;
            score.IncrementCorrectAnswers();
            gameManager.AddToCoins(quizManager.quizCoinValue);
        }

        else if (index != correctAnswerIndex && index >= 0)
        {
            audioManager.PlayAudio("Wrong Answer");
            questionText.text = "Incorrect. The answer was:\n" + correctAnswerString;
            selectedButtonImage = answerButtons[index].GetComponent<Image>();
            selectedButtonImage.sprite = chosenAnswerSprite;
            selectedButtonImage.color = Color.red;

            correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.color = Color.green;
        }

        else
        {
            questionText.text = "No answer selected.\n\nThe correct answer was:\n" + correctAnswerString;
            correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.color = Color.green;
        }
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
            buttonImage.color = Color.white;
        }
    }
}
