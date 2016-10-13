using UnityEngine;
using System.Collections;

public class SoundText : MonoBehaviour {

    [SerializeField]
    private AudioSource _textSound;

    [SerializeField]
    private AnimateText _animateText;

    [SerializeField]
    private bool _playSoundWhilePlaying;

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
