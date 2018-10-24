using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLine : ICtr {
    
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        HideAll();

    }

    public void OnEnable()
    {
        CanvasManager.Failed += HideAll;
        CanvasManager.FinishConversation += HideAll;

        CanvasManager.HangupPhone += HideAll;
    }

    public void OnDisable()
    {
        CanvasManager.Failed -= HideAll;
        CanvasManager.FinishConversation -= HideAll;

        CanvasManager.HangupPhone -= HideAll;
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
