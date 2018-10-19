using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CanvasManager : MonoBehaviour {


    public FullScreenVideoCtr screenProtectVideoCtr;
    public MainUICtr mainUICtr;

    public static CanvasManager instance;

    public static Action Call;
    public static Action HangupPhone;
    public static Action StartConversation;
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
        Call += LoadingCallingScene;
        Call += StopScreenProtect;
        
        HangupPhone += UNLoadingCallingScene;
        HangupPhone += PlayScreenProtect;


    }

    void DeRegisterEvent() {
        Call -= LoadingCallingScene;
        Call -= StopScreenProtect;
        HangupPhone -= UNLoadingCallingScene;
    }

    private void OnEnable()
    {
        RegisterEvent();
    }

    private void OnDisable()
    {
        DeRegisterEvent();
    }

    void LoadingCallingScene() {
        Debug.Log("Show Gui");
        mainUICtr.LoadingCallingScene();
    }

    void UNLoadingCallingScene() {
        Debug.Log("Hide Gui");
        mainUICtr.UnLoadingCallingScene();
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
        Call?.Invoke();
    }

    public static void startConversation()
    {
        StartConversation?.Invoke();
    }
}
