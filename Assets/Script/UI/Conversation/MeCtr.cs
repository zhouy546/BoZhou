using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeCtr : ICtr {
    public Text text;
	// Use this for initialization
    public	override void initialization() {
        base.initialization();
        HideAll();
	}

    private void OnEnable()
    {
        CanvasManager.StartConversation += ShowAll;
        CanvasManager.Failed += HideAll;

        CanvasManager.FinishConversation += HideAll;
    }

    private void OnDisable()
    {
        CanvasManager.StartConversation -= ShowAll;
        CanvasManager.Failed -= HideAll;

        CanvasManager.FinishConversation -= HideAll;

    }

    public override void HideAll()
    {
        base.HideAll();
    }

    public override void ShowAll()
    {
        base.ShowAll();
    }

    public override void UpdateText(string str) {
        text.text = str;
    }
}
