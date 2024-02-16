using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Sword : MonoBehaviour
{
    public event Action<Enemy> OnEnemyEnterZone;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ActivateSword()
    {
        gameObject.SetActive(true);
    }
    public void DeactivateSword()
    {
        gameObject?.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.Instance.IsAttacking)
            return;

        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            OnEnemyEnterZone?.Invoke(enemy);
        }
    }
}
