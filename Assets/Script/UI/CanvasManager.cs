using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CanvasManager : MonoBehaviour {


    public FullScreenVideoCtr screenProtectVideoCtr;
    public MainUICtr mainUICtr;
    public InformationPadCtr informationPadCtr;

    public static CanvasManager instance;

    public static Action Call;//打电话
    public static Action HangupPhone;//挂断电话
    public static Action StartConversation;//开始对话
    public static Action Failed;//报警失败
    public static Action WrongNumWarning;//打错电话

    public static Action AnswerCorrect;//回答正确
    public static Action AnswerWrong;//回答错误

    // Use this for initialization
    void Start () {
   
	}

    public void initialization() {
        if (instance == null) {
            instance = this;
        }
        screenProtectVideoCtr.initialization();
        mainUICtr.initialization();
        PlayScreenProtect();


    }

    void RegisterEvent() {
        Call += StopScreenProtect;
        
        HangupPhone += PlayScreenProtect;
    }

    void DeRegisterEvent() {
        Call -= StopScreenProtect;

    }

    private void OnEnable()
    {
        RegisterEvent();
    }

    private void OnDisable()
    {
        DeRegisterEvent();
    }





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            call();
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            hangupPhone();
        } else if (Input.GetKeyDown(KeyCode.G)) {
            startConversation();
        }
    }

    public void PlayScreenProtect() {
        screenProtectVideoCtr.Play(ValueSheet.ScreenProtectPath, true, true);
    }

    public void StopScreenProtect() {
        screenProtectVideoCtr.Stop();
    }

    public static void hangupPhone() {
        HangupPhone?.Invoke();
    }

    public static void call() {
        Debug.Log("开始打电话");
        Call?.Invoke();
    }

    public static void startConversation()
    {
        Debug.Log("开始对话");
        StartConversation?.Invoke();
    }

    public static void failed()
    {
        Debug.Log("失败");
        Failed?.Invoke();
    }

    public static void wrongNumWarning()
    {
        Debug.Log("电话号码错误警告");
        WrongNumWarning?.Invoke();
    }

    public static void answerCorrect() {
        Debug.Log("回答正确");
        AnswerCorrect?.Invoke();
    }

    public static void answerWrong() {
        Debug.Log("回答错误");
        AnswerWrong?.Invoke();
    }
}
