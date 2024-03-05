using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speedOfEnemy = 2f;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _groundDetection;
    private bool _movingRight = true;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Start()
    {        
        _spriteRenderer = GetComponent<SpriteRenderer>();      
        _animator = GetComponent<Animator>();  
    }  
    void Update()
    {
        transform.Translate(Vector2.right * _speedOfEnemy * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, _distance);
        if(groundInfo.collider == false)
        {
            if(_movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _spriteRenderer.flipX = true;
                _animator.SetBool("IsRunning", true);
                _movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _spriteRenderer.flipX = true;
                _animator.SetBool("IsRunning", true);
                _movingRight = true;
            }
        }
    }
}
