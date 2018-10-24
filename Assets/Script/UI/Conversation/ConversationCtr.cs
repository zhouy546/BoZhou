using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class ConversationCtr : I_step {
    public static ConversationCtr instance;
    public List<ICtr> ctrs = new List<ICtr>();
    // Use this for initialization
    public void initialization() {
        if (instance == null) {
            instance = this;
        }

        foreach (var item in ctrs)
        {
            item.initialization();

            item.UpdateText("");
        }

        Asks = ValueSheet.FireManString;
        MaxSetp = ValueSheet.FireManString.Count - 1;
        AnswerList = ValueSheet.MeAnswer;
    }

    private void OnEnable()
    {
        CanvasManager.StartConversation += UpdateFireManText;
        CanvasManager.StartConversation += UpdateMeText;
        CanvasManager.AnswerCorrect += IncreaseStep;
        CanvasManager.AnswerCorrect += UpdateFireManText;
        CanvasManager.AnswerCorrect += UpdateMeText;


        CanvasManager.HangupPhone += ResetAll;
        CanvasManager.HangupPhone += ResetText;

        CanvasManager.Failed += ResetAll;
        CanvasManager.FinishConversation += ResetText;
    }

    public void OnDisable()
    {
        CanvasManager.StartConversation -= UpdateFireManText;
        CanvasManager.StartConversation-= UpdateMeText;
        CanvasManager.AnswerCorrect -= IncreaseStep;
        CanvasManager.AnswerCorrect -= UpdateFireManText;
        CanvasManager.AnswerCorrect -= UpdateMeText;

        CanvasManager.HangupPhone -= ResetAll;
        CanvasManager.HangupPhone -= ResetText;

        CanvasManager.Failed -= ResetAll;
        CanvasManager.FinishConversation -= ResetText;
    }


    private void ResetAll() {
        ResetText();
        currentSetp = 0;
    }

    public override bool ListeningStr(string str)//回答长度
    {
        switch (currentSetp)
        {

            case 0:
                return GroupCheck(str, 0);
            case 1:
                return GroupCheck(str, 1);
            case 2:
                return GroupCheck(str, 2);

            case 3:
                return GroupCheck(str, 3);
            case 4:
                return GroupCheck(str, 4);

        }

        return false;
    }

    /// <summary>
    /// 从语言出填入关键字
    /// </summary>
    /// <param name="str">识别文字</param>
    /// <param name="i">到第几个</param>
    /// <returns></returns>
    public bool GroupCheck(string str, int i)
    {
        // UpdateText(str);
        List<bool> b = new List<bool>();
        int trueNum = 0;
        for (int j = 0; j < AnswerList[i].answer.Length; j++)
        {
            b.Add(check(str, AnswerList[i].answer[j]));
        }

        foreach (bool item in b)
        {
            if (item)
            {
                trueNum++;
            }
        }


        float val = (float)trueNum / (float)b.Count;

        Debug.Log(val);
        if (val >= ValueSheet.successRate)
        {
            // UpdateText(Asks[currentSetp]);
            //判断真确
            return true;
        }
        else
        {
            //判断错误
            // UpdateText(Asks[currentSetp-1]);
            return false;
        }
    }

    public bool check(string str, string strCheck)
    {

        if (str.Contains(strCheck))
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    public override void IncreaseStep()
    {
        base.IncreaseStep();

        if (currentSetp == MaxSetp+1) {
            Debug.Log("完成对话");
            CanvasManager.finishConversation();

            //出发事件
            //其他脚本订阅
            // 关闭监听，
            //显示报警成功UI； 
            //关闭计时
            //重置步长

        }     
    }


    public void ResetText() {
        ctrs[0].UpdateText("");
        ctrs[1].UpdateText("");
    }


    public void UpdateFireManText() {
        if (currentSetp < Asks.Count) {//最后一个回答真确时会超出ARRAY长度所以要检查
            ctrs[0].UpdateText(Asks[currentSetp]);
        }

    }

    public void UpdateMeText() {
        if (currentSetp < Asks.Count) {
            ctrs[1].UpdateText(AnswerList[currentSetp].answer[0]);//第0个是标准答案
            UpdateMePic();
        }

    }

    public void UpdateMePic()
    {
        if (currentSetp > 1)
        {
            ctrs[1].UpdatePic(currentSetp-2);
        }


    }
}
