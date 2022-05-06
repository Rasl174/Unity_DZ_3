using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _accelerate;

    private Animator _animation;

    private const string IsWalk = "IsWalk";
    private const string IsRunning = "IsRunning";

    private bool _lookRight = true;
    private float _playerWalkSpeed = 1.5f;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            if (_lookRight)
            {
                _lookRight = false;
                ChangeLook();
            }
            _animation.SetBool(IsWalk, true);
            _animation.SetBool(IsRunning, true);
            transform.Translate((_accelerate + _playerWalkSpeed) * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            if (_lookRight == false)
            {
                _lookRight = true;
                ChangeLook();
            }
            _animation.SetBool(IsWalk, true);
            _animation.SetBool(IsRunning, true);
            transform.Translate((_accelerate + _playerWalkSpeed) * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (_lookRight)
            {
                _lookRight = false;
                ChangeLook();
            }
            _animation.SetBool(IsRunning, false);
            _animation.SetBool(IsWalk, true);
            transform.Translate(_playerWalkSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_lookRight == false)
            {
                _lookRight = true;
                ChangeLook();
            }
            _animation.SetBool(IsRunning, false);
            _animation.SetBool(IsWalk, true);
            transform.Translate(_playerWalkSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            _animation.SetBool(IsWalk, false);
            _animation.SetBool(IsRunning, false);
        }
    }

    private void ChangeLook()
    {
        transform.Rotate(new Vector2(0, 180));
    }
}
