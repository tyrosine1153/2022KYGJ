using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Chracter allowedCharacter;
    private CharacterController _characterController;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _characterController ??= other.GetComponent<CharacterController>();
            if (_characterController.CurrentCharacter != allowedCharacter)
            {
                _characterController.GetDamage();
            }
        }
    }
}
