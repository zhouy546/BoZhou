using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScene : ICtr {

    public Animator ChuJinAnimator;
    public Text text;
	public override void initialization() {
        base.initialization();

        HideAll();
	}

    private void OnEnable()
    {
        CanvasManager.HangupPhone += HideAll;
        CanvasManager.FinishConversation += ShowAll;
        CanvasManager.Call += HideAll;
    }

    private void OnDisable()
    {
        CanvasManager.HangupPhone -= HideAll;
        CanvasManager.FinishConversation -= ShowAll;
        CanvasManager.Call -= HideAll;
    }

    public override void HideAll()
    {
        base.HideAll();
        StopAnimation();

        LeanTween.value(1f, 0f, .2f).setOnUpdate(delegate (float val)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, val);
        });
    }

    public override void ShowAll()
    {
        base.ShowAll();
        PlayAnimation();

        LeanTween.value(0f, 1f, 1f).setOnUpdate(delegate (float val)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, val);
        });

        SoundManager.instance.PlayFireManVoiceOver(SoundManager.instance.audioClips.Length-1);
    }

    public void PlayAnimation() {
        ChuJinAnimator.SetBool("Show", true);
    }

    public void StopAnimation() {
        ChuJinAnimator.SetBool("Show", false);
    }
}
