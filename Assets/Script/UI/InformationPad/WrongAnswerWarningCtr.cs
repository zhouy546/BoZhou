using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerWarningCtr : ICtr {

    // Use this for initialization
    public override void initialization()
    {
        base.initialization();
        HideAll();
    }

    private void OnEnable()
    {
        CanvasManager.AnswerWrong += ShowAll;
    }

    private void OnDisable()
    {
        CanvasManager.AnswerWrong -= ShowAll;
    }

    public override void HideAll()
    {
        base.HideAll();
    }

    public override void ShowAll()
    {
        base.ShowAll();

    }
}
