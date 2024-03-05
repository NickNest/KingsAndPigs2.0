using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 3f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private int _maxJumpValue = 2;

    private int  _jumpCount = 0;
    private float _checkRadius = 0.5f;
    private bool _isOnGround; 
    private Vector2 _moveVector;
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _bc2d;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _bc2d = GetComponent<BoxCollider2D>();
    }    
    void Update()
    {
        Run();
        Jump();
        Flip();
        CheckingGround();
    }

    private void Run()
    {
        _moveVector.x = Input.GetAxisRaw("Horizontal");
        _anim.SetFloat("isMoving", Mathf.Abs(_moveVector.x));
        _rb.velocity = new Vector2(_moveVector.x * _playerSpeed, _rb.velocity.y);
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (_isOnGround || (++_jumpCount < _maxJumpValue)))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);            
        }
        if (_isOnGround)
        {
            _jumpCount = 0;
        }

    }
    private void Flip()
    {
        if(_moveVector.x > 0)
        {
            _spriteRenderer.flipX = false;
            _bc2d.offset = new Vector2(0.13f,0);
        }        
        else if(_moveVector.x < 0)
        {
            _spriteRenderer.flipX = true; 
            _bc2d.offset = new Vector2(-0.13f,0);
        }        
                    
    }
    private void CheckingGround()
    {
        _isOnGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
        _anim.SetBool("isOnGround", _isOnGround);
    }
}
