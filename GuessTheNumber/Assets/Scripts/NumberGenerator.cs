using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NumberGenerator : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text attemptsText;
    [SerializeField] private Button checkButton;
    [SerializeField] private Button restartButton;

    private int targetNumber;
    private int attempts;

    private void Start()
    {
        SetGame();
        restartButton.onClick.AddListener(RestartGame);
        checkButton.onClick.AddListener(CheckGuess);
    }

    private void OnDestroy()
    {
        checkButton.onClick.RemoveListener(CheckGuess);
        restartButton.onClick.RemoveListener(RestartGame);  
    }

    private void SetGame()
    {
        targetNumber = Random.Range(1, 101);
        attempts = 0;
        messageText.text = "I'm thinking of a number between 1 and 100.";
        attemptsText.text = "Current attempts : 0";
    }

    private void CheckGuess()
    {
        int playerGuess;
        if (int.TryParse(inputField.text, out playerGuess))
        {
            attempts++;
            attemptsText.text = "Current attempts: " + attempts;

            if (playerGuess == targetNumber)
            {
                messageText.text = "Correct! You've guessed the number!";
            }
            else if (playerGuess < targetNumber)
            {
                messageText.text = "Too low! Try again.";
            }
            else
            {
                messageText.text = "Too high! Try again.";
            }
        }
        else
        {
            messageText.text = "Please enter a valid number.";
        }
    }
    
    private void RestartGame()
    {
        SetGame();
    }
}
