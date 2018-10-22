using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessCtr : ICtr {
    public Button btn;
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        HideAll();
    }

    private void OnEnable()
    {
        CanvasManager.FinishConversation += ShowAll;
    }

    private void OnDisable()
    {
        CanvasManager.FinishConversation -= ShowAll;
    }

    public override void HideAll()
    {
        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", false);
            item.image.raycastTarget = false;
        }
        btn.interactable = false;
    }

    public override void ShowAll()
    {
        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", true);
            item.image.raycastTarget = true;
        }
        btn.interactable = true;
    }
}
