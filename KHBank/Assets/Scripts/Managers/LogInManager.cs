using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour
{
    [SerializeField] TMP_InputField signUpIDInput;   // 회원가입 ID 입력 필드
    [SerializeField] TMP_InputField signUpPasswordInput;   // 회원가입 비밀번호 입력 필드
    [SerializeField] TMP_InputField confirmPassword;  // 회원가입 시 비밀번호 확인

    [SerializeField] TMP_InputField logInIDInput;   // 로그인할 때 ID 입력 필드
    [SerializeField] TMP_InputField logInPasswordInput;   // 로그인할 때 비밀번호 입력 필드
    

    [SerializeField] TMP_Text CoutionTxt; // 주의 문구를 계속 바꾸기 위해

    [SerializeField] StartSceneUIController startSceneUIController;

    public bool IsConfirmed = false;  // 비밀번호 확인 했는지 여부


    public void RegisterUser()
    {
        string username = signUpIDInput.text;    // 입력된 사용자명
        string password = signUpPasswordInput.text;    // 입력된 비밀번호

        // TODO - 아무것도 입력 안한 상태로 로그인이 됨
        
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

        if(!IsConfirmed)
        {
            CoutionTxt.text = "주의\n비밀번호를\n확인해주십시오.";
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

        if (string.IsNullOrEmpty(logInIDInput.text) || string.IsNullOrEmpty(logInPasswordInput.text))
        {
            CoutionTxt.text = "주의\nID와 비밀번호를\n입력해주세요.";
            startSceneUIController.OpenCautionWindow();
            return;
        }

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

    public void CheckInputPassword()
    {
        if(signUpPasswordInput.text == confirmPassword.text)
        {
            IsConfirmed = true;
            CoutionTxt.text = "\n비밀번호가\n일치합니다.";
            startSceneUIController.OpenCautionWindow();
            return;
        }
        else
        {
            CoutionTxt.text = "\n비밀번호가\n일치하지 않습니다.";
            startSceneUIController.OpenCautionWindow();
            return;
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
