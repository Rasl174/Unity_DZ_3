using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _accelerate;

    private const string IsWalk = "IsWalk";
    private const string IsRunning = "IsRunning";

    private Animator _animation;
    private bool _lookRight = true;
    private float _playerWalkSpeed = 1.5f;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            if(_lookRight)
            {
                ChangeLook(ref _lookRight);
            }
            _animation.SetBool(IsWalk, true);
            transform.Translate(_playerWalkSpeed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animation.SetBool(IsRunning, true);
                transform.Translate((_accelerate + _playerWalkSpeed) * Time.deltaTime, 0, 0);
            }
            else
            {
                _animation.SetBool(IsRunning, false);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if(_lookRight == false)
            {
                ChangeLook(ref _lookRight);
            }
            _animation.SetBool(IsWalk, true);
            transform.Translate(_playerWalkSpeed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animation.SetBool(IsRunning, true);
                transform.Translate((_accelerate + _playerWalkSpeed) * Time.deltaTime, 0, 0);
            }
            else
            {
                _animation.SetBool(IsRunning, false);
            }
        }
        else
        {
            _animation.SetBool(IsWalk, false);
            _animation.SetBool(IsRunning, false);
        }
    }

    private void ChangeLook(ref bool lookRight)
    {
        transform.Rotate(new Vector2(0, 180));
        if (lookRight)
        {
            lookRight = false;
        }
        else
        {
            lookRight = true;
        }
    }
}
