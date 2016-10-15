using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayText : MonoBehaviour 
{
    
    /*
    * This is the DisplayText script.
    * RESPONSIBILITY: Display the text that gets written in AnimateText() to a text object.
    */

    [SerializeField] private AnimateText _animateText;
    [SerializeField] private Text _textToDisplayOn;

    void Start()
    {
        _animateText.OnAnimatingText += SetText;
        
        // Everytime this delegate gets fired, the SetText function gets called.
        // In this case, it gets called with each character.
    }

    void SetText()
    {
        _textToDisplayOn.text = _animateText.GetAnimatedString;
    }
}
