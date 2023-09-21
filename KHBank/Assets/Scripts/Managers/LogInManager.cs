using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour
{
    [SerializeField] InputField usernameInput;   // 사용자명 입력 필드
    [SerializeField] InputField passwordInput;   // 비밀번호 입력 필드

    bool IsConfirmed = false;


    public void RegisterUser()
    {
        string username = usernameInput.text;    // 입력된 사용자명
        string password = passwordInput.text;    // 입력된 비밀번호

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("사용자명과 비밀번호는 비어있을 수 없습니다.");
            return;
        }

        // 사용자가 이미 존재하는지 확인합니다.
        if (PlayerPrefs.HasKey(username))
        {
            Debug.LogWarning("이미 사용자가 존재합니다.");
            return;
        }

        // PlayerPrefs를 사용하여 사용자 데이터를 저장합니다.
        PlayerPrefs.SetString("ID", username);
        PlayerPrefs.SetString("Password", password);
        PlayerPrefs.Save();

        Debug.Log("사용자 등록 완료: " + username);
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
            Debug.Log("아이디와 비번 확인");
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
