using UnityEngine;
using System.Collections;

public class ShowTextPanel : MonoBehaviour 
{

    [SerializeField]
    private AnimateText _animateTextScript;

    [SerializeField]
    private StringCounter _stringCounterScript;

    [SerializeField]
    private GameObject _textPanel;

    void Start()
    {
        RemoveTextPanel();

        _animateTextScript.OnAnimatingText += AddTextPanel;
        _stringCounterScript.OnQuestionsEnd += RemoveTextPanel;
    }

    void AddTextPanel()
    {
        _textPanel.SetActive(true);
    }

    void RemoveTextPanel()
    {
        _textPanel.SetActive(false);
    }
}
