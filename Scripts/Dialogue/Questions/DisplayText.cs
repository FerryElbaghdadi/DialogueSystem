using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayText : MonoBehaviour 
{

    [SerializeField] private AnimateText _animateText;
    [SerializeField] private Text _textToDisplayOn;

    void Start()
    {
        _animateText.OnAnimatingText += SetText;
    }

    void SetText()
    {
        _textToDisplayOn.text = _animateText.GetAnimatedString;
    }
}
