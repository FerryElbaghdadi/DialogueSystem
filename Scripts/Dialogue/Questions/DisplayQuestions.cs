using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayQuestions : MonoBehaviour 
{


    [SerializeField]
    private StringCounter _stringCounterScript;

    [SerializeField]
    private TriggerQuestion _triggerQuestionScript;

    [SerializeField]
    private GameObject _questionPanelObject;

    [SerializeField]
    private QuestionStrings _questionStringsObject;

    [SerializeField]
    private Text[] questionText;

    private bool _turnDisplayOff;

    void Start()
    {
        _questionPanelObject.SetActive(false);

        _stringCounterScript.OnStringsEnd += DisplayPanel;
        _stringCounterScript.OnStringsEnd += DisplayQuestionText;

        _triggerQuestionScript.OnQuestionChosen += RemovePanel;
        _triggerQuestionScript.OnQuestionChosen += RemoveQuestionText;

        _triggerQuestionScript.OnQuestionChosen += TurnDisplayOff;
    }

    void DisplayPanel()
    {
        if (!_turnDisplayOff)
        _questionPanelObject.SetActive(true);
    }

    void RemovePanel()
    { 
       _questionPanelObject.SetActive(false);
    }
    
    void TurnDisplayOff()
    {
        _turnDisplayOff = true;
    }

    void DisplayQuestionText()
    {
        if (!_turnDisplayOff)
        {
            questionText[0].text = _questionStringsObject.GetQuestionStrings[0];
            questionText[1].text = _questionStringsObject.GetQuestionStrings[1];
        }
    }

    void RemoveQuestionText()
    {
        questionText[0].text = "";
        questionText[1].text = "";
    }

}
