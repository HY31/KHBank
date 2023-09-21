using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneUIController : MonoBehaviour
{
    // UI 컨트롤러를 씬마다 만드는 건 별로인 것 같은데 어떻게 해야될 지 모르겠어서 그냥 써버렸습니다..

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
