using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerInfo
{
    private float _horizontal;
    private bool _isFalling;
    private bool _isJumped;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    void Start()
    {
        Speed = 5;
        JumpForce = 7;
        IsGrounded = true;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isFalling = false;
        _isJumped = false;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        IsAttacking = false;
    }

    void Update()
    {
        if (!_gameManager.IsGameOver)
        {
            Move();
            Jump();
            PlayFallAndJumpAnimation();
            if (Input.GetMouseButtonDown(0) && !IsAttacking)
            {
                Attack();
            }
        }
    }

    private void PlayFallAndJumpAnimation()
    {
        if (_rb.velocity.y > 0 && !_isJumped)
        {
            _isJumped = true;
            _isFalling = false;
        }
        else if (_rb.velocity.y < 0 && !_isFalling)
        {
            _isJumped = false;
            _isFalling = true;
        }
        if (IsGrounded)
        {
            _isFalling = false;
            _isJumped = false;
        }
        PlayFallAnimation();
        PlayJumpAnimation();
    }

    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * Speed * _horizontal);
        FLipSprite();
        PlayMovementAnimation();
    }

    private void FLipSprite()
    {
        if (_horizontal > 0)
        {
            IsFlipped = false;
        }
        if (_horizontal < 0)
        {
            IsFlipped = true;
        }
        _spriteRenderer.flipX = IsFlipped;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _isJumped = true;
            PlayJumpAnimation();
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            IsGrounded = true;
        }
    }
    private void PlayMovementAnimation()
    {
        if (!_isJumped)
        {
            if (_horizontal > 0 || _horizontal < 0)
            {
                _animator.SetBool("isRunning", true);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }
    }
    public bool Attack()
    {
        IsAttacking = true;
        PlayAttackAnimation();
        StartCoroutine(AttackCD());
        return IsAttacking;
    }
    private void PlayJumpAnimation() => _animator.SetBool("isJump", _isJumped);
    private void PlayFallAnimation() => _animator.SetBool("isFalling", _isFalling);
    public void PlayDeathAnimation() 
    { 
        _animator.SetBool("isDead", true);
        _gameManager.IsGameOver = true;
    }
    private void PlayAttackAnimation() => _animator.SetTrigger("isAttack");
    public IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(1);
        IsAttacking = false;
    }
}
