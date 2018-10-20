using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedCtr : ICtr {


    public override void initialization() {
        base.initialization();
        HideAll();
    }

    private void OnEnable()
    {
        CanvasManager.Failed += ShowAll;
        CanvasManager.HangupPhone += HideAll;    
    }

    private void OnDisable()
    {
        CanvasManager.HangupPhone -= HideAll;
        CanvasManager.Failed -= ShowAll;
    }

}
