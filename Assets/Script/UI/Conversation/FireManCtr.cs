using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireManCtr : ICtr {
  
    public Text text;
    public Animator animator;
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

        CanvasManager.FinishConversation += HideAll;

        CanvasManager.HangupPhone += HideAll;
    }

    private void OnDisable()
    {
        CanvasManager.StartConversation -= ShowAll;
        CanvasManager.Failed -= HideAll;
        CanvasManager.AnswerCorrect -= correctGoNext;

        CanvasManager.FinishConversation -= HideAll;

        CanvasManager.HangupPhone -= HideAll;

    }

    void correctGoNext() {
        UpdateText(ConversationCtr.instance.Asks[ConversationCtr.instance.currentSetp]);
        GoNextAnimation();
    }

    public override void UpdateText(string str) {
        text.text = str;
    }

    public override void HideAll()
    {
        base.HideAll();
        animator.SetBool("Play", false);
    }


    void GoNextAnimation() {
      StartCoroutine(nextAnim());
    }

    IEnumerator nextAnim() {
        StartAnimation();

        yield return new WaitForSeconds(4);

        StopAnimation();
    }

    public void StopAnimation() {
        animator.SetBool("Play", false);
    }

    public void StartAnimation() {
        animator.SetBool("Play", true);
    }

    public override void ShowAll()
    {
        base.ShowAll();
        GoNextAnimation();
    }

}
