using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizEndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI awardedCoins;

    Score score;
    GameManager gameManager;
    QuizManager quizManager;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        score = FindObjectOfType<Score>();
        gameManager = FindObjectOfType<GameManager>();
        quizManager = FindObjectOfType<QuizManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        gameManager.AddToEnergy();
        audioManager.PlayAudio("Level Complete");
    }

    // Update is called once per frame
    void Update()
    {
        finalScoreText.text = score.CalculateScore() + "%";
        awardedCoins.text = (score.GetCorrectAnswers() * quizManager.quizCoinValue).ToString();
    }
}
