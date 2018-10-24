using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoConnectingCtr : ICtr {
    public GameObject circle;
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        HideAll();

	}



    public void OnEnable()
    {
        CanvasManager.Call += ShowAll;
        CanvasManager.StartConversation += HideAll;

        CanvasManager.HangupPhone += HideAll;
    }

    public void OnDisable()
    {
        CanvasManager.Call -= ShowAll;
        CanvasManager.StartConversation -= HideAll;

        CanvasManager.HangupPhone -= HideAll;
    }

    public override void HideAll()
    {

        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", false);
            item.image.raycastTarget = false;
        }

    }

    public override void ShowAll()
    {
        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", true);
            item.image.raycastTarget = true;
        }
    }
}
