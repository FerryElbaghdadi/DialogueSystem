using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionSelector : MonoBehaviour {

    [SerializeField]
    private StringCounter _stringCounterScript;

    [SerializeField]
    private Text[] _questionTexts;

    [SerializeField]
    private Color _questionNeutralColor;
    [SerializeField]
    private Color _questionHoverColor;

    [SerializeField]
    private int _questionInt = 0;

    public int GetQuestionInt
    {
        get { return _questionInt; }
    }

    private bool _canSelect;

    private bool _runOnce;

    void Start()
    {
        _stringCounterScript.OnStringsEnd += TurnSelectorOn;
    }

    void Update()
    {
        

        if (_canSelect)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                _questionInt = 1;
                AssignColor();
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                _questionInt = 0;
                AssignColor();
            }
        }
    }

    void TurnSelectorOn()
    {
        _canSelect = true;
        AssignColor();
    }

    void AssignColor()
    {
        if (_questionInt == 0)
        {
            _questionTexts[0].color = _questionHoverColor;
            _questionTexts[1].color = _questionNeutralColor;
        }
        else if (_questionInt == 1)
        {
            _questionTexts[1].color = _questionHoverColor;
            _questionTexts[0].color = _questionNeutralColor;
        }
    }
}
