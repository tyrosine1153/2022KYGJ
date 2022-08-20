using UnityEngine;

public class IceField : MonoBehaviour
{
    private Vector2 _cachedVelocity;
    private Rigidbody2D _playerRigidbody;
    private CharacterController _characterController;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerRigidbody ??= other.gameObject.GetComponent<Rigidbody2D>();
            _cachedVelocity = _playerRigidbody.velocity;
            _characterController ??= other.gameObject.GetComponent<CharacterController>();
            _characterController.canMove = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("IceField");
            _playerRigidbody ??= other.gameObject.GetComponent<Rigidbody2D>();
            _playerRigidbody.velocity = _cachedVelocity;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerRigidbody ??= other.gameObject.GetComponent<Rigidbody2D>();
            _playerRigidbody.velocity = Vector2.zero;
            _characterController ??= other.gameObject.GetComponent<CharacterController>();
            _characterController.canMove = false;
        }
    }
}
