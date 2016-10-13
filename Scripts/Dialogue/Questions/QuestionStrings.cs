using UnityEngine;
using System.Collections;

public class QuestionStrings : MonoBehaviour 
{

    [SerializeField]
    private string[] _questionStrings;

    public string[] GetQuestionStrings
    {
        get { return _questionStrings; }
    }

    [SerializeField]
    private string[] _answerOneStrings;

    public string[] GetAnswerOneStrings
    {
        get { return _answerOneStrings; }
    }

    [SerializeField]
    private string[] _answerTwoStrings;

    public string[] GetAnswerTwoStrings
    {
        get { return _answerTwoStrings; }
    }
}
