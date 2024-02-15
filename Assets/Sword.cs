using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public event Action<Enemy> OnAttack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            OnAttack?.Invoke(enemy);
        }
    }
}
