using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayQuestions : MonoBehaviour 
{

    /*
    * This is the DisplayQuestions script.
    *
    * RESPONSIBILITY: Display the question panel/text when needed.
    */

    [SerializeField] private StringCounter _stringCounterScript;
    [SerializeField] private TriggerQuestion _triggerQuestionScript;
    [SerializeField] private QuestionStrings _questionStringsScript;
    
    // Grabs the needed scripts to achieve this.
    
    [SerializeField] private GameObject _questionPanelObject;
    
    // The background panel we will use for our text.

    [SerializeField] private Text[] questionText;

    // The text object we will be using four our strings.
    
    private bool _turnDisplayOff;
    
    // This boolean will decide whether the questions will be displayed, or not.

    void Start()
    {
        _questionPanelObject.SetActive(false);

        _stringCounterScript.OnStringsEnd += DisplayPanel;
        _stringCounterScript.OnStringsEnd += DisplayQuestionText;

        _triggerQuestionScript.OnQuestionChosen += RemovePanel;
        _triggerQuestionScript.OnQuestionChosen += RemoveQuestionText;

        _triggerQuestionScript.OnQuestionChosen += TurnDisplayOff;
        
        /*
        * These are delegates.
        * All these functions will only be called whenever the delegate takes place.
        */
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
        
        // Empties the text.
    }

}
