using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLine : ICtr {
    public Animator animator;
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
        CanvasManager.StartConversation += HideAll;
    }

    public void OnDisable()
    {
        CanvasManager.Failed -= HideAll;
        CanvasManager.FinishConversation -= HideAll;

        CanvasManager.HangupPhone -= HideAll;
        CanvasManager.StartConversation -= HideAll;
    }

    public override void HideAll()
    {
        animator.SetBool("Show", false);
    }

    public override void ShowAll()
    {
        animator.SetBool("Show", true);
    }
}
