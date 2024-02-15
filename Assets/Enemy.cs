using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemyRenderer;
    [SerializeField] private Sprite _defeatedSprite;
    [SerializeField] private AudioClip _defeatedMusic;
    [SerializeField] private AudioSource _enemyAudioSource;
    [SerializeField] private int _health;

    private bool _isRed;
    private bool _isDefeated;
    public void TakeDamage(int amount)
    {
        if (_health < 0)
            return;
        _health -= amount;
        PaintRed();
        if(_health < 0)
        {
            _enemyRenderer.sprite = _defeatedSprite;
            _enemyAudioSource.clip = _defeatedMusic;
            _enemyAudioSource.Play();
            _isDefeated = true;
        }
    }
    private void PaintRed()
    {
        if (_isRed || _isDefeated)
            return;
        StartCoroutine(BeingRed());
    }
    IEnumerator BeingRed()
    {
        _isRed = true;
        Color initColor = _enemyRenderer.color;
        _enemyRenderer.color = Color.red;
        yield return new WaitForSeconds(1);
        _enemyRenderer.color = initColor;
        _isRed = false;
    }
}
