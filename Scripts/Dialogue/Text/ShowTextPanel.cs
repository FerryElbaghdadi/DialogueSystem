using UnityEngine;
using System.Collections;

public class ShowTextPanel : MonoBehaviour 
{
    
    /*
     * RESPONSIBILITIES:
     * 1. Display the text panel whenever text starts running.
     * 2. Remove the text panel whenever the text ends.
     */

    [SerializeField] private AnimateText _animateTextScript;
    [SerializeField] private StringCounter _stringCounterScript;

    [SerializeField] private GameObject _textPanel;

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
