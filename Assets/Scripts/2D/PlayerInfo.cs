using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private float _speed;
    private float _jumpForce;
    private bool _isGrounded;
    private bool _isFlipped;
    private int _health;
    private bool _isAttacking;
    public float Speed
    {
        get { return _speed; }
        set {  _speed = value; }
    }
    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }
    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }
    public bool IsFlipped
    {
        get { return _isFlipped; }
        set { _isFlipped = value; }
    }
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    public bool IsAttacking
    {
        get { return _isAttacking; }
        set { _isAttacking = value; }
    }
}
