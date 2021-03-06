using UnityEngine;
using System.Collections;

public class TriggerText : MonoBehaviour 
{
    
    /*
     * RESPONSIBILITIES:
     * 1. Make a boolean turn true whenever the player gets in range of the NPC.
     * 2. Whenever you press 'Space' in range of the NPC, the dialogue starts playing.
     */

    [SerializeField] private StringCounter _stringCounterScript;
    [SerializeField] private AnimateText _animateText;
    [SerializeField] private StringsHolder _stringsHolder;
    [SerializeField] private QuestionStrings _questionStrings;

    [SerializeField] private float _textDelay;
    [SerializeField] private float _timeBetweenText;

    private bool _textReady;
    private bool _textRunning;

    private bool _runOnce;

    private bool _turnTextOff;


    void Start()
    {
        _animateText.OnAnimatingText += SetRunningBool;
        _animateText.OnDoneAnimatingText += SetRunningBoolFalse;

        _stringCounterScript.OnStringsEnd += SetTextOff;
        
        // These functions will only get called whenever the delegates in the scripts get fired.
    }

    void SetRunningBool()
    {
        _textRunning = true;
    }

    void SetRunningBoolFalse()
    {
        _textRunning = false;
    }

    void SetTextOff()
    {
        _turnTextOff = true;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _textReady = true;

        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _textReady = false;

        }
    }
    void Update()
    {
        CheckIfTxtReady();
    }

    void CheckIfTxtReady()
{
    if (_textReady)
    {
        StartText();
    }
}

    void StartText()
    {
        if (!_textRunning && !_turnTextOff)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                StartCoroutine(_animateText.TextAnimator(_stringsHolder.GetAllDialogueStrings[_stringCounterScript.GetStringCounter], _timeBetweenText, _textDelay));
        }    
    }
}

