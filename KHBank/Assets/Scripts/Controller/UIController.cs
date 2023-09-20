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

    private void Start()  // ������Ʈ�� �ϸ� ������Ʈ���� ������ ���������� �ʾƼ� ���� ����� ���� �ʴ´�!
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
        cashOnHandTxt.text = "���� ����\n" + _moneyManager.cashOnHand.ToString("C"); // ToString("C")�� "C"�� ȭ�� ������ �޸��� �־���
        balance.text = "�ܰ�:" + _moneyManager.balance.ToString("C");
    }

}
