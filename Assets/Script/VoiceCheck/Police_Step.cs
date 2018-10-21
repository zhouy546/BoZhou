using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Police_Step : I_step {

	// Use this for initialization
	void Start () {
        //UpdateText("");
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



    public bool GroupCheck(string str,int i) {
       // UpdateText(str);
        List<bool> b = new List<bool>();
        int trueNum = 0;
        for (int j = 0; j < AnswerList[i].answer.Length; j++)
        {
           b.Add( check(str, AnswerList[i].answer[j]));
        }

        foreach (bool item in b)
        {
            if (item) {
                trueNum++;
            }
        }


        float val = (float)trueNum / (float)b.Count;

        Debug.Log(val);
        if (val >= ValueSheet.successRate)
        {
           // UpdateText(Asks[currentSetp]);
            IncreaseStep();
        
            return true;
        }
        else {
           // UpdateText(Asks[currentSetp-1]);
            return false;
        }     
    }


    public bool check(string str,string strCheck) {

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
        //if (Input.GetKeyDown(KeyCode.A))
        //{
          
        //    UpdateText("创捷传媒", ListeningStr("创捷传媒"));

        //}
        //else if(Input.GetKeyDown(KeyCode.Q)) {

        //    UpdateText("110救命", ListeningStr("110救命"));
        //}
    }


 

    //private void UpdateText(string str,bool b) {
    //    if (b)
    //    {
    //        currentText = str;
    //        DisplayText += currentText + "\n" + Asks[currentSetp] + "\n";

    //        text.text = DisplayText;
    //    }
    //    else {
    //        currentText = str;
    //        DisplayText += currentText + "\n" + "请说出正确信息" + "\n";

    //        text.text = DisplayText;
    //    }
    //}

    //private void UpdateText(string str)
    //{
       
    //        currentText = str;
    //        DisplayText += currentText + Asks[currentSetp] + "\n";

    //        text.text = DisplayText;

    //}


}
