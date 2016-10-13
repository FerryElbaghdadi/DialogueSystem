using UnityEngine;
using System.Collections;

public class StringsHolder : MonoBehaviour
{

    [SerializeField]
    private string[] _dialogueStrings;

    public string[] GetAllDialogueStrings
    {
        get { return _dialogueStrings; }
    }
}
