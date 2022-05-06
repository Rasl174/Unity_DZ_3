using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _playerRigidbody;

    private bool _onGround;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            _onGround = true;
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
        if (Input.GetKey(KeyCode.Space) && _onGround)
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
