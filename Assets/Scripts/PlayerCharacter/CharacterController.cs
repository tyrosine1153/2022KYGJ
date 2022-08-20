using System.Collections;
using UnityEngine;

public enum Chracter
{
    Dorothy,
    Scarecrow,
    TinMan,
    CowardlyLion
}

public class CharacterController : MonoBehaviour
{
    public int hp = 4;
    public float moveSpeed = 1f;
    public float jumpPower = 5.0f;
    public bool isOnIce;

    [SerializeField] private Animator[] characterAnimators;
    private Animator _currentCharacterAnimator;
    private Chracter _currentCharacter;

    public Chracter CurrentCharacter
    {
        get => _currentCharacter;
        set
        {
            _currentCharacter = value;

            _currentCharacterAnimator = characterAnimators[(int)_currentCharacter];
            foreach (var animator in characterAnimators)
            {
                animator.gameObject.SetActive(false);
            }

            _currentCharacterAnimator.gameObject.SetActive(true);
        }
    }

    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private bool _canJump;
    private bool _isStoryMode = true;
    private static readonly int StoryMode = Animator.StringToHash("StoryMode");

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isStoryMode) return;

        if (!isOnIce)
        {
            _rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _rigidBody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _rigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentCharacter = Chracter.Dorothy;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentCharacter = Chracter.Scarecrow;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentCharacter = Chracter.TinMan;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentCharacter = Chracter.CowardlyLion;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !_canJump)
        {
            _rigidBody.velocity = Vector2.zero;
            _canJump = true;
        }
    }

    public void SetStoryMode(bool isOn)
    {
        _animator.SetBool(StoryMode, isOn);
        _isStoryMode = isOn;
    }

    [ContextMenu("Set Character 2 Dorothy")]
    public void SetCharacter2Dorothy()
    {
        CurrentCharacter = Chracter.Dorothy;
    }

    [ContextMenu("Set Character 2 Scarecrow")]
    public void SetCharacter2Scarecrow()
    {
        CurrentCharacter = Chracter.Scarecrow;
    }

    [ContextMenu("Set Character 2 TinMan")]
    public void SetCharacter2TinMan()
    {
        CurrentCharacter = Chracter.TinMan;
    }

    [ContextMenu("Set Character 2 CowardlyLion")]
    public void SetCharacter2CowardlyLion()
    {
        CurrentCharacter = Chracter.CowardlyLion;
    }

    [ContextMenu("Set StoryMode On")]
    public void SetStoryModeOn()
    {
        SetStoryMode(true);
    }

    [ContextMenu("Set StoryMode Off")]
    public void SetStoryModeOff()
    {
        SetStoryMode(false);
    }

    public void GetDamage()
    {
        if(_isDamageIgnoreMode) return;
        
        hp--;
        KnockBack();
        StartCoroutine(IgnoreDamage());
        
        if (hp <= 0)
        {
            Die();
        }
    }

    private bool _isDamageIgnoreMode = false;
    private readonly WaitForSeconds _damageIgnoreTime = new WaitForSeconds(2f);
    private IEnumerator IgnoreDamage()
    {
        _isDamageIgnoreMode = true;
        
        // Blink Animation
        yield return _damageIgnoreTime;
        _isDamageIgnoreMode = false;
    }

    public void KnockBack()
    {
        _rigidBody.AddForce(_rigidBody.velocity.normalized * -1.5f, ForceMode2D.Impulse);
    }

    private void Die()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Box") || hit.gameObject.CompareTag("Mirror"))
        {
            const float force = 5;
            var rigid = hit.collider.GetComponent<Rigidbody2D>();
            if (rigid != null)
            {
                Vector2 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();

                rigid.AddForce(forceDirection * force, ForceMode2D.Impulse);
            }
        }
    }
}

