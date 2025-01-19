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
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Toggle hardModeToggle;

    private int minimalValue = 1;
    private int maximalValue = 101;

    private int targetNumber;
    private int attempts;

    private void Start()
    {
        SetGame();
        restartButton.onClick.AddListener(RestartGame);
        checkButton.onClick.AddListener(CheckGuess);
    }

    public void OnToggleChanged(bool v)
    {
        if (v)
        {
            minimalValue = 1;
            maximalValue = 101;
        }
        else
        {
            minimalValue = 1;
            maximalValue = 51;
        }
        
        RestartGame();
    }

    private void OnDestroy()
    {
        checkButton.onClick.RemoveListener(CheckGuess);
        restartButton.onClick.RemoveListener(RestartGame);  
    }

    private void SetGame()
    {
        targetNumber = Random.Range(minimalValue, maximalValue);
        attempts = 0;
        messageText.text = $"I'm thinking of a number between {minimalValue} and {maximalValue-1}.";
        attemptsText.text = "Current attempts : 0";
        inputField.text = "";
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
                audioSource.Play();
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
