using UnityEngine;
using System.Collections;

public class StringCounter : MonoBehaviour 
{
    public delegate void QuestionEventHandler();
    public QuestionEventHandler OnStringsEnd;
    public QuestionEventHandler OnQuestionsEnd;

    [SerializeField] private AnimateText _animateText;

    [SerializeField] private StringsHolder _stringsHolder;

    [SerializeField] private QuestionStrings _questionStrings;
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
        _animateText.OnDoneAnimatingText += AddCount;
    }

    void AddCount()
    {
        if (_stringCounter < _stringsHolder.GetAllDialogueStrings.Length - 1)
        _stringCounter += 1;
        else
        {
            if (OnStringsEnd != null)
                OnStringsEnd();

            _stringCounter = 0;
        }

        if(_triggerQuestionScript.GetQuestionOne)
        {
            if (_questionCounter < _questionStrings.GetAnswerOneStrings.Length - 1)
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
            if (_questionCounter < _questionStrings.GetAnswerTwoStrings.Length - 1)
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
