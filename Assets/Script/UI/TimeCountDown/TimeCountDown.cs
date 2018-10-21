using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountDown : ICtr {
    public Text CountDonwText;
    public int CountDonwTime;
    public Image LoopRing;


    public override  void initialization() {
        base.initialization();
        HideAll();
    }

    public void OnEnable()
    {
        CanvasManager.StartConversation += ShowAll;
        CanvasManager.StartConversation += startCoutDown;

        CanvasManager.Failed += HideAll;

        CanvasManager.AnswerWrong += BreakCountDown;//回答错误暂停计时
    }

    public void OnDisable()
    {
        CanvasManager.StartConversation -= ShowAll;
        CanvasManager.StartConversation -= startCoutDown;

        CanvasManager.Failed -= HideAll;

        CanvasManager.AnswerWrong -= BreakCountDown;//
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BreakCountDown();

        }
        else if (Input.GetKeyDown(KeyCode.C)) {
            startCoutDown();
        }

    }

    public void BreakCountDown() {
        StopAllCoroutines();
        LeanTween.cancelAll();
    }

    public void startCoutDown() {
        StartCoroutine(StartCountDonwText(CountDonwTime,CanvasManager.Failed));
        StartCountDownUI();
    }


    private IEnumerator StartCountDonwText(int time,Action action= null) {
        UpdateText(time);
        yield return new WaitForSeconds(1);
        time--;
        if (time == 0) {
            UpdateText(time);
            Debug.Log("时间到");
            if (action != null) {
                action();
            }
            yield break;
        }
        StartCoroutine(StartCountDonwText(time, CanvasManager.Failed));
    }

    private void StartCountDownUI() {
        LoopRing.fillAmount = 1f;
        LeanTween.value(1, 0, (float)CountDonwTime).setOnUpdate(delegate (float val)
        {
            LoopRing.fillAmount = val;
        });
    }

    public void UpdateText(int time) {
        CountDonwText.text = time.ToString() + "秒";
    }


    public override void HideAll()
    {
        base.HideAll();

        LeanTween.value(1, 0, .5f).setOnUpdate(delegate (float val)
        {
            CountDonwText.color = new Color(1, 1, 1, val);
        });
    }

    public override void ShowAll()
    {
        base.ShowAll();

        LeanTween.value(0, 1, .5f).setOnUpdate(delegate (float val)
        {
            CountDonwText.color = new Color(1, 1, 1, val);
        });
    }


}
