using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _accelerate;
    [SerializeField] private float _jumpForce;

    private Animator _animation;
    private Rigidbody2D _playerRigidbody;

    private bool _onGround;
    private bool _lookRight = true;
    private float _playerWalkSpeed = 1.5f;

    private void Start()
    {
        _animation = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            _onGround = true;
        }
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            _onGround = false;
        }
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
            _animation.SetBool("IsWalk", true);
            _animation.SetBool("IsRunning", true);
            transform.Translate((_accelerate + _playerWalkSpeed) * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            if (_lookRight == false)
            {
                _lookRight = true;
                ChangeLook();
            }
            _animation.SetBool("IsWalk", true);
            _animation.SetBool("IsRunning", true);
            transform.Translate((_accelerate + _playerWalkSpeed) * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (_lookRight)
            {
                _lookRight = false;
                ChangeLook();
            }
            _animation.SetBool("IsRunning", false);
            _animation.SetBool("IsWalk", true);
            transform.Translate(_playerWalkSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_lookRight == false)
            {
                _lookRight = true;
                ChangeLook();
            }
            _animation.SetBool("IsRunning", false);
            _animation.SetBool("IsWalk", true);
            transform.Translate(_playerWalkSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            _animation.SetBool("IsWalk", false);
            _animation.SetBool("IsRunning", false);
        }
        if (Input.GetKey(KeyCode.Space) && _onGround)
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void ChangeLook()
    {
        transform.Rotate(new Vector2(0, 180));
    }
}
