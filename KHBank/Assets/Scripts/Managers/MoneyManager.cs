using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField] UIController ui;

    [SerializeField] TMP_InputField depositMoneyTxt;
    [SerializeField] TMP_InputField withdrawMoneyTxt;


    public int cashOnHand;
    public int balance;

    private void Awake()
    {
        instance = this;
    }

    public void DepositMoney()
    {
        int inputMoney = int.Parse(depositMoneyTxt.text);
        if (cashOnHand - inputMoney >= 0)
        {
            cashOnHand -= inputMoney;
            balance += inputMoney;
        }
        else
        {
            ui.Coution();
        }
    }

    public void WithdrawMoney()
    {
        int outputMoney = int.Parse(withdrawMoneyTxt.text);
        if (balance - outputMoney >= 0)
        {
            balance -= outputMoney;
            cashOnHand += outputMoney;
        }
        else
        {
            ui.Coution();
        }
    }
}
