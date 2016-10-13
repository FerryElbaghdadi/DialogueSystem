using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{


    //Floats

    [SerializeField]
    private float _camFollowSpeed = 0.25f;
    private float _cameraMagnitudeVel = 10;
    private float _camFollowVelocity;
    //Floats


    //GameObject
    private GameObject _cameraTarget;

    [SerializeField]
    private GameObject _cameraPlayer;

    [SerializeField]
    private GameObject _cameraChange;
    //GameObject

    //Vector3
    private Vector3 _offset;
    private Vector3 _cameraTargetPos;
    //Vector3



    void Start()
    {
        _cameraTargetPos = transform.position; // Locks it's own position.
        _cameraTarget = _cameraPlayer;
    }



    void FixedUpdate()
    {
        FollowCamera();


        /*
         * Why FixedUpdate?
         * FixedUpdate makes it run more smooth.
         */
    }

    void FollowCamera()
    {
        if (_cameraTarget != null)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = _cameraTarget.transform.position.z;

            Vector3 _cameraTargetDirection = (_cameraTarget.transform.position - posNoZ);

            _camFollowVelocity = _cameraTargetDirection.magnitude * _cameraMagnitudeVel;

            _cameraTargetPos = transform.position + (_cameraTargetDirection.normalized * _camFollowVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, _cameraTargetPos + _offset, _camFollowSpeed);
        }
    }

    public IEnumerator ChangeTarget(bool limited, float duration)
    {
        if (limited)
        {
            _cameraTarget = _cameraChange;
            yield return new WaitForSeconds(duration);
            _cameraTarget = _cameraPlayer;
        }

        else
            _cameraTarget = _cameraChange;
    }
}