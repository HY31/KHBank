using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    MoneyManager _moneyManager;
    [SerializeField] GameObject depositWindow;
    [SerializeField] GameObject withdrawWindow;
    [SerializeField] GameObject coutionWindow;

    [SerializeField] TMP_Text balance;
    [SerializeField] TMP_Text cashOnHandTxt;
    [SerializeField] TMP_Text welcome;

    [SerializeField] TMP_Text time;

    private void Start()  // Awake로 하면 Awake끼리 순서가 정해져있지 않아서 값이 제대로 들어가지 않는다!
    {
        _moneyManager = MoneyManager.instance;
        string playerName = PlayerPrefs.GetString("ID");
        welcome.text = playerName + " 님 어서 오십시오.";
    }
    private void Update()
    {
        UpdateCashOnHandTxt();
        time.text = DateTime.Now.ToString("yyyy-M-dd | tt HH:mm");
    }
    public void OpenDepositWindow()
    {
        depositWindow.SetActive(true);
    }
    public void CloseDepositWindow()
    {
        depositWindow.SetActive(false);
    }

    public void OpenWithdrawWindow()
    {
        withdrawWindow.SetActive(true);
    }
    public void CloseWithdrawWindow()
    {
        withdrawWindow.SetActive(false);
    }


    void UpdateCashOnHandTxt()
    {
        cashOnHandTxt.text = "보유 현금\n" + _moneyManager.cashOnHand.ToString("C"); // ToString("C")의 "C"는 화폐 단위와 콤마를 넣어줌
        balance.text = "잔고:" + _moneyManager.balance.ToString("C");
    }

    public void Coution()
    {
        coutionWindow.SetActive(true);
    }

    public void CloseCoution()
    {
        coutionWindow.SetActive(false);
    }
}
