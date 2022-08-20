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
    public bool canMove = true;

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
    private bool _canJump = true;
    private bool _isStoryMode = true;
    
    private bool _isDamageIgnoreMode;
    private static readonly int StoryMode = Animator.StringToHash("StoryMode");
    private readonly WaitForSeconds _damageIgnoreTime = new (2f);
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Dead = Animator.StringToHash("Dead");

    private static readonly Quaternion DefaultRotation = Quaternion.Euler(0, 0, 0);
    private static readonly Quaternion FlipRotation = Quaternion.Euler(0, 180, 0);

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        canMove = true;
        CurrentCharacter = Chracter.Dorothy;
    }

    private void Update()
    {
        if (!_isStoryMode) return;

        var horizontal = Input.GetAxis("Horizontal");
        if (canMove)
        {
            _rigidBody.velocity = new Vector2(horizontal * moveSpeed, _rigidBody.velocity.y);
        }
        _currentCharacterAnimator.SetBool(IsWalking, Mathf.Abs(horizontal) > 0.2f);
        _currentCharacterAnimator.transform.localRotation = horizontal < 0 ? DefaultRotation : FlipRotation;

        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _rigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _currentCharacterAnimator.SetTrigger(Jump);
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
    private IEnumerator IgnoreDamage()
    {
        _isDamageIgnoreMode = true;
        
        // Blink Animation
        yield return _damageIgnoreTime;
        _isDamageIgnoreMode = false;
    }

    public void KnockBack(float power = 1.5f)
    {
        StartCoroutine(CoKnockBack(power));
    }
    
    private IEnumerator CoKnockBack(float power)
    {
        canMove = false;
        _rigidBody.velocity = _rigidBody.velocity.normalized * -1.5f * power;
        yield return new WaitForSeconds(0.3f);
        canMove = true;
    }

    private void Die()
    {
        _currentCharacterAnimator.SetTrigger(Dead);
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

    #region Context Menu

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

    [ContextMenu("Set Die")]
    public void SetDie()
    {
        Die();
    }

    #endregion
}

