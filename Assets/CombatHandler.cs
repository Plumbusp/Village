using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    [SerializeField] private Sword sword;

    [Header("Variables")]
    [SerializeField] private int damage;

    [SerializeField] private float attackTime;

    [SerializeField] private float timeBetween;

    private bool isAttacking;

    private void Awake()
    {
        sword.OnAttack += Attack;
    }
    private void Attack(Enemy enemy)
    {
        if (isAttacking)
            return;
        StartCoroutine(AttackCoroutine(enemy));
        
    }
    IEnumerator AttackCoroutine(Enemy enemy)
    {
        isAttacking = true;
        Debug.Log("wait...");
        yield return new WaitForSeconds(attackTime);
        enemy.TakeDamage(damage);
        Debug.Log("Attack");
        yield return new WaitForSeconds(timeBetween);
        Debug.Log("Cool down!");
        isAttacking =false;
        Debug.Log("Ready again.");
    }
}
