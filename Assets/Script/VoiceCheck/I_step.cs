using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class I_step : MonoBehaviour {
    //public Text text;

    public string currentText;

    public string DisplayText;

    public List<Answer> AnswerList = new List<Answer>();

    public List<string> Asks = new List<string>();

    public int currentSetp; 

    public int MaxSetp;

    public virtual bool ListeningStr(string str) {

        return false;

    }

    public virtual void IncreaseStep() {
        currentSetp++;
    }


    [System.Serializable]
    public class Answer
    {
       public string[] answer = new string[] { };
        public float[] answerValue = new float[] { };

        public Answer() {

        }

        public Answer(string[] strs) {
            answer = strs;
        }

        public Answer(string[] strs,float[] vals)
        {
            answer = strs;
            answerValue = vals;

        }
    }
}
