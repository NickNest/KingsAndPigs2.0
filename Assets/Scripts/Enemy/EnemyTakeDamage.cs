using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
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
