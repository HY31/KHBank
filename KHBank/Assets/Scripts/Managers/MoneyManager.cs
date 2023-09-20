using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    UIController ui;

    [SerializeField] TMP_InputField inputTxt_Money;
        

    public int cashOnHand;
    public int balance;

    private void Awake()
    {
        instance = this;
    }

    public void DepositMoney()
    {
        if (cashOnHand > 0)
        {
            cashOnHand -= int.Parse(inputTxt_Money.text);
            balance += int.Parse(inputTxt_Money.text);
        }
        else
        {
            ui.Coution();
        }
    }
}
