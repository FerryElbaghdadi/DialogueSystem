using UnityEngine;
using System.Collections;

public class StringsHolder : MonoBehaviour
{

    /*
     * RESPONSIBILITY: Hold all the dialogue strings in an array.
     */
    
    [SerializeField]
    private string[] _dialogueStrings;

    public string[] GetAllDialogueStrings
    {
        get { return _dialogueStrings; }
    }
}
