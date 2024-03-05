using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    
    [SerializeField] private GameObject _runPointA, _runPointB;
    private Rigidbody2D _rigidBody2D;
    private int _currentHealth;
    private Animator _animator;
    private Transform _currentPoint;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _currentHealth = _maxHealth;
    }
    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _animator.SetTrigger("Hurt");
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        _animator.SetBool("IsDead", true);
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
