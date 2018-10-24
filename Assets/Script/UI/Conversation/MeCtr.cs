using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeCtr : ICtr {
    public Text text;

    public List<Animator> animators = new List<Animator>();
   // public NImage MePic;
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

        CanvasManager.HangupPhone += HideAll;
    }

    private void OnDisable()
    {
        CanvasManager.StartConversation -= ShowAll;
        CanvasManager.Failed -= HideAll;

        CanvasManager.FinishConversation -= HideAll;

        CanvasManager.HangupPhone -= HideAll;

    }

    public override void HideAll()
    {
        base.HideAll();

        foreach (var item in animators)
        {
            item.SetBool("Show", false);
        }
    }

    public override void ShowAll()
    {
        base.ShowAll();
    }

    public override void UpdateText(string str) {
        text.text = str;
    }

    public override void UpdatePic(int num) {


        foreach (var item in animators)
        {

            if (num == animators.IndexOf(item))
            {
                item.SetBool("Show", true);
            }
            else {
                item.SetBool("Show", false);
            }
           
        }

       // MePic.image.sprite = ValueSheet.meSprites[num];
    }
}
