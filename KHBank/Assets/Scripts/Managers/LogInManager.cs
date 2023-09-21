using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour
{
    [SerializeField] TMP_InputField signUpIDInput;   // 사용자명 입력 필드
    [SerializeField] TMP_InputField signUpPasswordInput;   // 비밀번호 입력 필드

    [SerializeField] TMP_InputField logInIDInput;   // 사용자명 입력 필드
    [SerializeField] TMP_InputField logInPasswordInput;   // 비밀번호 입력 필드

    [SerializeField] TMP_Text CoutionTxt;

    [SerializeField] StartSceneUIController startSceneUIController;

    public bool IsConfirmed = false;


    public void RegisterUser()
    {
        string username = signUpIDInput.text;    // 입력된 사용자명
        string password = signUpPasswordInput.text;    // 입력된 비밀번호

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            CoutionTxt.text = "주의\nID와 비밀번호를\n입력해주세요.";
            startSceneUIController.OpenCautionWindow();
            return;
        }

        // 유저 중복 여부
        if (PlayerPrefs.GetString("ID") == username)
        {
            CoutionTxt.text = "주의\n\n중복된 ID입니다.";
            startSceneUIController.OpenCautionWindow();
            return;
        }

        // PlayerPrefs를 사용하여 유저 데이터 저장
        PlayerPrefs.SetString("ID", username);
        PlayerPrefs.SetString("Password", password);
        PlayerPrefs.Save();

        CoutionTxt.text = "회원가입 완료!\nKH은행에 오신 걸\n환영합니다!";
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
            CoutionTxt.text = "주의\nID와 비밀번호를\n확인해주세요.";
            startSceneUIController.OpenCautionWindow();
            return;
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
