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
	}




    public override bool ListeningStr(string str)
    {
        switch (currentSetp)
        {

            case 0:
                return GroupCheck(str, 0);
            case 1:
                return GroupCheck(str, 1);
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
            IncreaseStep();
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

    }

    private void Update()
    {

    }
}
