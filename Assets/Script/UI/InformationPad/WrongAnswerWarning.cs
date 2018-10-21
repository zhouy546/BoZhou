using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerWarning : ICtr {
    public WrongAnswerWarningCtr wrongAnswerWarningCtr;

    public TimeCountDown timeCountDown;
    public void HideMe() {
        wrongAnswerWarningCtr.HideAll();
        timeCountDown.startCoutDown();//返回后重新计时；

        VoiceRec.instance.startListening();//重新开始监听
    }
}
