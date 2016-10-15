using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetText : MonoBehaviour 
{
    
    /*
     * RESPONSIBILITY: Replace the last string of the text with an empty string, whenever the text ends.
     */

    [SerializeField] private StringCounter _stringCounterScript;

    [SerializeField] private Text _dialogueText;

    void Start()
    {
        _stringCounterScript.OnQuestionsEnd += RemoveText;
    }

    void RemoveText()
    {
        _dialogueText.text = "";
    }
}
