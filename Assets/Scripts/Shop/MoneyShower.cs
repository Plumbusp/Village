using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    private Wallet _wallet;
    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.OnMoneyChange += UpdateMoney;
    }
    private void OnDestroy()
    {
        _wallet.OnMoneyChange -= UpdateMoney;
    }
    public void UpdateMoney(int moneyAmount)
    {
        _moneyText.text = moneyAmount.ToString();
    }
}
