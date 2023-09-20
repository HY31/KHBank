using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    MoneyManager _moneyManager;
    [SerializeField] GameObject depositWindow;
    [SerializeField] TMP_Text balance;
    [SerializeField] TMP_Text cashOnHandTxt;

    private void Start()  // 업데이트로 하면 업데이트끼리 순서가 정해져있지 않아서 값이 제대로 들어가지 않는다!
    {
        _moneyManager = MoneyManager.instance;
    }
    private void Update()
    {
        UpdateCashOnHandTxt();
    }
    public void OpenDepositWindow()
    {
        depositWindow.SetActive(true);
    }

    public void CloseDepositWindow()
    {
        depositWindow.SetActive(false);
    }

    void UpdateCashOnHandTxt()
    {
        cashOnHandTxt.text = "보유 현금\n" + _moneyManager.cashOnHand.ToString("C"); // ToString("C")의 "C"는 화폐 단위와 콤마를 넣어줌
        balance.text = "잔고:" + _moneyManager.balance.ToString("C");
    }

}
