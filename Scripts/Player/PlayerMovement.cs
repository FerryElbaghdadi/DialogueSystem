using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	
    //Float
    [SerializeField]
    private float _movementSpeed;

    public float MovementSpeed
    {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    private float _jumpSpeed;
    private float _amountJumps = 0;
	private float _horizontalMovement;

    //Float

    //Vector2
    private Vector2 _moveDirection;

	//Vector2

    //Bool
    [SerializeField]
    private bool _isGrounded;
    private bool _spacePressed;
    [SerializeField]
    private bool _canJump;
    [SerializeField]
    private bool _ableToJump;
    //Bool

    //RigidBody2D
    [SerializeField]
    private Rigidbody2D _playerRigidBody2D;
    //RigidBody2D



    void FixedUpdate()
    {
            RigidBodyMove();
            Jump();
    }

    void Update()
    {
        JumpBool();
    }

   

    void RigidBodyMove()
    {

		_horizontalMovement = 1f;
        float x = Input.GetAxis("Horizontal");

      _playerRigidBody2D.velocity = new Vector2(x * _movementSpeed, _playerRigidBody2D.velocity.y);

	}

	public void LeftMove()
	{
		_playerRigidBody2D.velocity = new Vector2 (-_horizontalMovement * _movementSpeed, _playerRigidBody2D.velocity.y);
	}

	public void RightMove()
	{
		_playerRigidBody2D.velocity = new Vector2 (_horizontalMovement * _movementSpeed, _playerRigidBody2D.velocity.y);
	}


    private void JumpBool()
    {
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && _ableToJump)
        {
            _canJump = true;
        }
    }

    private void Jump()
    {
        if (_canJump &&_ableToJump)
        {
            if (!_spacePressed && _amountJumps < 2)
            {
                _playerRigidBody2D.velocity = new Vector2(0, _jumpSpeed);

                _spacePressed = true;
                _isGrounded = false;

                _jumpSpeed -= 2f;
                _movementSpeed -= 2f;

                _amountJumps++;
            }
            else
            {
                _spacePressed = false;
                _canJump = false;
            }

        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            _amountJumps = 0f;
            _jumpSpeed = 8f;
       //     _movementSpeed = 2f;
        }
    }
}
