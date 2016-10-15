using UnityEngine;
using System.Collections;

public class StringCounter : MonoBehaviour 
{
    
    /*
     * This script holds an integer that starts at 0, 
     * and counts up whenever a sentence ends.
     * this way, whenever we continue the dialogue,
     * the counter counts up, and we will know which sentence to display
     * in the array of strings (of text) that will be displayed.
     * 
     * RESPONSIBILITIES: 
     * 1. Count an integer up whenever a sentence ends.
     * 2. Reset the counter whenever the text ends. 
     */
    
    
    public delegate void QuestionEventHandler();
    public QuestionEventHandler OnStringsEnd;
    public QuestionEventHandler OnQuestionsEnd;

    [SerializeField] private AnimateText _animateTextScript;
    
    [SerializeField] private StringsHolder _stringsHolderScript;

    [SerializeField] private QuestionStrings _questionStringsScript;
    [SerializeField] private TriggerQuestion _triggerQuestionScript;

    [SerializeField] private int _stringCounter;
    [SerializeField] private int _questionCounter;

    public int GetStringCounter
    {
        get { return _stringCounter; }
    }

    public int GetQuestionCounter
    {
        get { return _questionCounter; }
    }

    void Start()
    {
        _animateTextScript.OnDoneAnimatingText += AddCount;
        
        // This function will only get called whenever the delegate in the AnimateText gets fired.
    }

    void AddCount()
    {
        /*
         * IF: Stands for whenever a sentence ends. The counter counts up.
         * ELSE: Stands for whenever the text ends. The counter resets, and a delegate gets fired.
         */
        
        if (_stringCounter < _stringsHolderScript.GetAllDialogueStrings.Length - 1)
        _stringCounter += 1;
        else
        {
            if (OnStringsEnd != null)
                OnStringsEnd();

            _stringCounter = 0;
        }

        if(_triggerQuestionScript.GetQuestionOne)
        {
            if (_questionCounter < _questionStringsScript.GetAnswerOneStrings.Length - 1)
                _questionCounter += 1;
            else
            {
                if (OnQuestionsEnd != null)
                    OnQuestionsEnd();

                _questionCounter = 0;
            }
        }

        else if (_triggerQuestionScript.GetQuestionTwo)
        {
            if (_questionCounter < _questionStringsScript.GetAnswerTwoStrings.Length - 1)
                _questionCounter += 1;
            else
            {
                if (OnQuestionsEnd != null)
                    OnQuestionsEnd();

                _questionCounter = 0;
            }
        }
        
    }
}
