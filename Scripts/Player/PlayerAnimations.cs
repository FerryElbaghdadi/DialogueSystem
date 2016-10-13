using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

    [SerializeField]
    private Animator _playerAnimator;

    [SerializeField]
    private float xInput;


    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        if (xInput != 0)
        {
            _playerAnimator.SetBool("Walking", true);
            _playerAnimator.SetBool("Idle", false);
        }
        else
        {
            _playerAnimator.SetBool("Idle", true);
            _playerAnimator.SetBool("Walking", false);
        }
            
    }
}
