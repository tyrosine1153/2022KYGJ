using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private BoxCollider2D childCollider;
    private CharacterController _characterController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _characterController ??= other.GetComponent<CharacterController>();
            if (_characterController.CurrentCharacter != Chracter.CowardlyLion)
            {
                _characterController.KnockBack();
            }

            childCollider.isTrigger = _characterController.CurrentCharacter == Chracter.CowardlyLion;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _characterController ??= other.gameObject.GetComponent<CharacterController>();
            if (_characterController.CurrentCharacter != Chracter.CowardlyLion)
            {
                _characterController.KnockBack(3f);
                Debug.Log("Knockback");
            }
        }
    }
}