using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireManCtr : ICtr {
  
    public Text text;
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        HideAll();
	}

    private void OnEnable()
    {
        CanvasManager.StartConversation += ShowAll;
        CanvasManager.Failed += HideAll;

        CanvasManager.AnswerCorrect += correctGoNext;
    }

    private void OnDisable()
    {
        CanvasManager.StartConversation -= ShowAll;
        CanvasManager.Failed += HideAll;
        CanvasManager.AnswerCorrect -= correctGoNext;

    }

    void correctGoNext() {
        UpdateText(ConversationCtr.instance.Asks[ConversationCtr.instance.currentSetp]);
    }

    public override void UpdateText(string str) {
        text.text = str;
    }
}
