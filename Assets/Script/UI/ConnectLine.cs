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
        
        
    }

    public void OnDisable()
    {
        
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
