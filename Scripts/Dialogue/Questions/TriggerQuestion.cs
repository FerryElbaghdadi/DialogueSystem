using UnityEngine;
using System.Collections;

public class TriggerQuestion : MonoBehaviour 
{

    /*
     * RESPONSIBILITIES:
     * 1. Make a boolean turn true whenever the player gets in range of the NPC.
     * 2. Whenever you press 'Space' in range of the NPC, the dialogue starts playing.
     */
    
    public delegate void QuestionEventHandler();
    public QuestionEventHandler OnQuestionChosen;

    [SerializeField] private StringCounter _stringCounterScript;
    [SerializeField] private QuestionStrings _questionStringsScript;
    [SerializeField] private QuestionSelector _questionSelectorScript;

    [SerializeField] private AnimateText _animateTextScript;

    [SerializeField] private float _textDelay;
    [SerializeField] private float _timeBetweenText;

    private bool _inRange;
    private bool _questionRunning;
    private bool _canChooseQuestions;

    private bool _questionOne;
    private bool _questionTwo;

    public bool GetChooseQuestions
    {
        get { return _canChooseQuestions; }
    }

    public bool GetQuestionOne
    {
        get { return _questionOne; }
    }

    public bool GetQuestionTwo
    {
        get { return _questionTwo; }
    }


    void Start()
    {
        _stringCounterScript.OnStringsEnd += TurnQuestionOn;

        _animateTextScript.OnAnimatingText += SetRunningBool;
        _animateTextScript.OnDoneAnimatingText += SetRunningBoolFalse;
        
         // These functions will only get called whenever the delegates in these scripts gets fired.
    }



    void SetRunningBool()
    {
        _questionRunning = true;
    }

    void SetRunningBoolFalse()
    {
        _questionRunning = false;
    }

    void TurnQuestionOn()
    {
        _canChooseQuestions = true;
    }


    void Update()
    {
        CheckIfReady();
    }

    void CheckIfReady()
    {
        if (_canChooseQuestions && _inRange)
            StartQuestion();
    }


    void StartQuestion()
    {
        if (!_questionRunning)
        {
            if (_questionSelectorScript.GetQuestionInt == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !_questionTwo)
                {
                    _questionOne = true;

                    ChoseQuestionOne();

                    if (OnQuestionChosen != null)
                        OnQuestionChosen();
                }
              
            }

            else if (_questionSelectorScript.GetQuestionInt == 1)
            {
                
                if (Input.GetKeyDown(KeyCode.Space) && !_questionOne)
                {

                    _questionTwo = true;


                    ChoseQuestionTwo();

                    if (OnQuestionChosen != null)
                        OnQuestionChosen();
                }
            
            }
                
        }
    }

    void ChoseQuestionOne()
    {
        StartCoroutine(_animateTextScript.TextAnimator(_questionStringsScript.GetAnswerOneStrings[_stringCounterScript.GetQuestionCounter], _timeBetweenText, _textDelay));
    }

    void ChoseQuestionTwo()
    {
        StartCoroutine(_animateTextScript.TextAnimator(_questionStringsScript.GetAnswerTwoStrings[_stringCounterScript.GetQuestionCounter], _timeBetweenText, _textDelay));
    }


    /*
     * These OnTrigger2D Methods are to ensure that the text only runs
     * Whenever the player is in range of the NPC they're talking to.
     */

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _inRange = true;

        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _inRange = false;

        }
    }
}
