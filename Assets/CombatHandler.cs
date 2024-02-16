using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatHandler : MonoBehaviour
{
    [SerializeField] private Sword sword;

    [Header("Variables")]
    [SerializeField] private int damage;

    [SerializeField] private float windUp;

    [SerializeField] private float attackTime;

    [SerializeField] private float timeBetween;
    private InputActions _playerInputActions;

    private bool _isAttackState = false;

    private void Awake()
    {
        _playerInputActions = new InputActions();
        if (!_playerInputActions.Player.enabled)
            _playerInputActions.Player.Enable();

        _playerInputActions.Player.Attack.performed += Attack;

        sword.OnEnemyEnterZone += OnAttackEnemy;

        sword.DeactivateSword();
        sword.gameObject.SetActive(false);
    }
    private void Attack(InputAction.CallbackContext callbackContext)
    {
        if (_isAttackState)
            return;
        _isAttackState = true;
        StartCoroutine(AttackCoroutine());
    }
    IEnumerator AttackCoroutine()
    {
        sword.ActivateSword();
        Debug.Log("wait...");
        yield return new WaitForSeconds(windUp);
        Debug.Log("Attack");
        GameManager.Instance.IsAttacking = true;
        yield return new WaitForSeconds(attackTime);
        GameManager.Instance.IsAttacking = false;
        Debug.Log("Cool down!");
        yield return new WaitForSeconds(timeBetween);
        Debug.Log("Ready again.");
        sword.DeactivateSword();
        _isAttackState = false;
    }

    private void OnAttackEnemy(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }
}
