using UnityEngine;
using System.Collections;

public class QuestionStrings : MonoBehaviour 
{
    
    /*
    * RESPONSIBILITY: Hold all the strings that we will use for the questions section.
    */

    [SerializeField] private string[] _questionStrings;

    public string[] GetQuestionStrings
    {
        get { return _questionStrings; }
    }

    [SerializeField] private string[] _answerOneStrings;

    public string[] GetAnswerOneStrings
    {
        get { return _answerOneStrings; }
    }

    [SerializeField] private string[] _answerTwoStrings;

    public string[] GetAnswerTwoStrings
    {
        get { return _answerTwoStrings; }
    }
}
