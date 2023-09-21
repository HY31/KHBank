using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour
{
    [SerializeField] TMP_InputField signUpIDInput;   // ����ڸ� �Է� �ʵ�
    [SerializeField] TMP_InputField signUpPasswordInput;   // ��й�ȣ �Է� �ʵ�

    [SerializeField] TMP_InputField logInIDInput;   // ����ڸ� �Է� �ʵ�
    [SerializeField] TMP_InputField logInPasswordInput;   // ��й�ȣ �Է� �ʵ�

    [SerializeField] TMP_Text CoutionTxt;

    [SerializeField] StartSceneUIController startSceneUIController;

    public bool IsConfirmed = false;


    public void RegisterUser()
    {
        string username = signUpIDInput.text;    // �Էµ� ����ڸ�
        string password = signUpPasswordInput.text;    // �Էµ� ��й�ȣ

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            CoutionTxt.text = "����\nID�� ��й�ȣ��\n�Է����ּ���.";
            startSceneUIController.OpenCautionWindow();
            return;
        }

        // ���� �ߺ� ����
        if (PlayerPrefs.GetString("ID") == username)
        {
            CoutionTxt.text = "����\n\n�ߺ��� ID�Դϴ�.";
            startSceneUIController.OpenCautionWindow();
            return;
        }

        // PlayerPrefs�� ����Ͽ� ���� ������ ����
        PlayerPrefs.SetString("ID", username);
        PlayerPrefs.SetString("Password", password);
        PlayerPrefs.Save();

        CoutionTxt.text = "ȸ������ �Ϸ�!\nKH���࿡ ���� ��\nȯ���մϴ�!";
        startSceneUIController.OpenCautionWindow();
        startSceneUIController.CloseSignUpWindow();
    }

    public void LogInUser()
    {
        string id = PlayerPrefs.GetString("ID");
        string password = PlayerPrefs.GetString("Password");

        if (id == logInIDInput.text && password == logInPasswordInput.text)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            CoutionTxt.text = "����\nID�� ��й�ȣ��\nȮ�����ּ���.";
            startSceneUIController.OpenCautionWindow();
            return;
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
