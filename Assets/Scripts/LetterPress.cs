using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class LetterPress : MonoBehaviour
{
    [SerializeField]
    private int letterIndex; //The number the letter is in the word

    [SerializeField]
    private bool isCorrect;

    [SerializeField]
    private bool isLastLetter;

    [SerializeField]
    private bool newActivity; //If it is a new activity, this checks to see if the currentLetterIndex should be resetted to 0

    private static int currentLetterIndex = 0; //The current letter the player is on

    public List<string> letterList = new List<string>(); //List of the correct letters

    public List<GameObject> answerList = new List<GameObject>(); //List of the UI for the correct letters

    [SerializeField]
    private GameObject finishedMessage; //Assign UI to display a congratulatory message when the activity is finished

    [SerializeField]
    private GameObject mistakeMessage; //Assign UI to display a message when the player makes a mistake

    [SerializeField]
    private GameObject hideUponWinQn; //hide questions when the player wins
    [SerializeField]
    private GameObject hideUponWinObjects; //hide objects when the player wins

    public void pressLetter()
    {
        if (newActivity)
        {
            currentLetterIndex = 0;
            newActivity = false;
            
        }

        mistakeMessage.SetActive(false); //Remove the mistake message if the player presses another button after it appears

        if (isCorrect && (letterIndex == currentLetterIndex) && !isLastLetter)
        {
            Debug.Log(letterList[0] + letterList[1] + letterList[2] + "+" + answerList[0]);
            answerList[letterIndex].GetComponent<TextMeshProUGUI>().text = letterList[letterIndex];
            currentLetterIndex++;
            Destroy(gameObject); //Remove the letter once it is pressed
        }
        else if (isCorrect && (letterIndex == currentLetterIndex) && isLastLetter)
        {
            answerList[letterIndex].GetComponent<TextMeshProUGUI>().text = letterList[letterIndex];
            finishedMessage.SetActive(true);
            hideUponWinQn.SetActive(false);
            hideUponWinObjects.SetActive(false);
            Destroy(gameObject); //Remove the letter once it is pressed
        }
        else
        {
            mistakeMessage.SetActive(true);
            if (!isCorrect)
            {
                Destroy(gameObject); //Remove the letter once it is pressed
            }
        }
    }
}
