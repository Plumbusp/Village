using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static event Action OnPlayerShopEnter;
    public static event Action OnPlayerShopExit;

    [SerializeField] private TMP_Text _EText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shop")
        {
            OnPlayerShopEnter?.Invoke();
            _EText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shop")
        {
            OnPlayerShopExit?.Invoke();
            _EText.gameObject.SetActive(false);
        }
    }
}
