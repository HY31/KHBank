using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneUIController : MonoBehaviour
{
    // UI ��Ʈ�ѷ��� ������ ����� �� ������ �� ������ ��� �ؾߵ� �� �𸣰ھ �׳� ����Ƚ��ϴ�..

    [SerializeField] GameObject signUpWindow;
    [SerializeField] GameObject coutionWindow;

    public void OpenSignUpWindow()
    {
        signUpWindow.SetActive(true);
    }
    public void CloseSignUpWindow()
    {
        signUpWindow.SetActive(false);
    }

    public void OpenCautionWindow()
    {
        coutionWindow.SetActive(true);
    }

    public void CloseCautionWindow()
    {
        coutionWindow.SetActive(false);
    }
}
