using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private int _attackDamage = 20;
    [SerializeField] private float _attackRate = 2f;
    private float _nextAttackTime = 0f;
    private Animator _anim;
    

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Time.time >= _nextAttackTime)
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
    }

    private void Attack()
    {
        
        _anim.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
