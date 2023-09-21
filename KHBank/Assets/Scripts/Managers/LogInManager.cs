using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour
{
    [SerializeField] InputField usernameInput;   // ����ڸ� �Է� �ʵ�
    [SerializeField] InputField passwordInput;   // ��й�ȣ �Է� �ʵ�

    bool IsConfirmed = false;


    public void RegisterUser()
    {
        string username = usernameInput.text;    // �Էµ� ����ڸ�
        string password = passwordInput.text;    // �Էµ� ��й�ȣ

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("����ڸ�� ��й�ȣ�� ������� �� �����ϴ�.");
            return;
        }

        // ����ڰ� �̹� �����ϴ��� Ȯ���մϴ�.
        if (PlayerPrefs.HasKey(username))
        {
            Debug.LogWarning("�̹� ����ڰ� �����մϴ�.");
            return;
        }

        // PlayerPrefs�� ����Ͽ� ����� �����͸� �����մϴ�.
        PlayerPrefs.SetString("ID", username);
        PlayerPrefs.SetString("Password", password);
        PlayerPrefs.Save();

        Debug.Log("����� ��� �Ϸ�: " + username);
    }

    public void LogInUser()
    {
        string id = PlayerPrefs.GetString("ID");
        string password = PlayerPrefs.GetString("Password");

        if (id == usernameInput.text && password == passwordInput.text)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.Log("���̵�� ��� Ȯ��");
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
