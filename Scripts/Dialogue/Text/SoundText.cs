using UnityEngine;
using System.Collections;

public class SoundText : MonoBehaviour 
{
    /*
     * RESPONSIBILITY: Play an audio source whenver a delegate gets fired.
     */

    [SerializeField] private AnimateText _animateText;
    [SerializeField] private AudioSource _textSound;
    [SerializeField] private bool _playSoundWhilePlaying;

    void Start()
    {
        _animateText.OnAnimatingText += PlayTextSound;
    }

    void PlayTextSound()
    {
        if (_playSoundWhilePlaying)
            _textSound.Play();
    }
}
