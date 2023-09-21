using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour
{
    [SerializeField] TMP_InputField signUpIDInput;   // ȸ������ ID �Է� �ʵ�
    [SerializeField] TMP_InputField signUpPasswordInput;   // ȸ������ ��й�ȣ �Է� �ʵ�
    [SerializeField] TMP_InputField confirmPassword;  // ȸ������ �� ��й�ȣ Ȯ��

    [SerializeField] TMP_InputField logInIDInput;   // �α����� �� ID �Է� �ʵ�
    [SerializeField] TMP_InputField logInPasswordInput;   // �α����� �� ��й�ȣ �Է� �ʵ�
    

    [SerializeField] TMP_Text CoutionTxt; // ���� ������ ��� �ٲٱ� ����

    [SerializeField] StartSceneUIController startSceneUIController;

    public bool IsConfirmed = false;  // ��й�ȣ Ȯ�� �ߴ��� ����


    public void RegisterUser()
    {
        string username = signUpIDInput.text;    // �Էµ� ����ڸ�
        string password = signUpPasswordInput.text;    // �Էµ� ��й�ȣ

        // TODO - �ƹ��͵� �Է� ���� ���·� �α����� ��
        
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

        if(!IsConfirmed)
        {
            CoutionTxt.text = "����\n��й�ȣ��\nȮ�����ֽʽÿ�.";
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

        if (string.IsNullOrEmpty(logInIDInput.text) || string.IsNullOrEmpty(logInPasswordInput.text))
        {
            CoutionTxt.text = "����\nID�� ��й�ȣ��\n�Է����ּ���.";
            startSceneUIController.OpenCautionWindow();
            return;
        }

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

    public void CheckInputPassword()
    {
        if(signUpPasswordInput.text == confirmPassword.text)
        {
            IsConfirmed = true;
            CoutionTxt.text = "\n��й�ȣ��\n��ġ�մϴ�.";
            startSceneUIController.OpenCautionWindow();
            return;
        }
        else
        {
            CoutionTxt.text = "\n��й�ȣ��\n��ġ���� �ʽ��ϴ�.";
            startSceneUIController.OpenCautionWindow();
            return;
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
