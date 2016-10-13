using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetText : MonoBehaviour {

    [SerializeField]
    private StringCounter _stringCounterScript;

    [SerializeField]
    private Text _dialogueText;

    void Start()
    {
        _stringCounterScript.OnQuestionsEnd += RemoveText;
    }

    void RemoveText()
    {
        _dialogueText.text = "";
    }
}
