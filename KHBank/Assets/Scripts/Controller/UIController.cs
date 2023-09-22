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

    private void Start()  // Awake�� �ϸ� Awake���� ������ ���������� �ʾƼ� ���� ����� ���� �ʴ´�!
    {
        _moneyManager = MoneyManager.instance;
        string playerName = PlayerPrefs.GetString("ID");
        welcome.text = playerName + " �� � ���ʽÿ�.";
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
        cashOnHandTxt.text = "���� ����\n" + _moneyManager.cashOnHand.ToString("C"); // ToString("C")�� "C"�� ȭ�� ������ �޸��� �־���
        balance.text = "�ܰ�:" + _moneyManager.balance.ToString("C");
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
