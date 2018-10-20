using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPSectionCtr : ICtr {
    public Text text;


    public override void initialization() {
        base.initialization();
        
    }


    private void OnEnable()
    {
        CanvasManager.Failed += ClearText;
        CanvasManager.WrongNumWarning += ClearText;
    }


    private void OnDisable()
    {
        CanvasManager.Failed -= ClearText;
        CanvasManager.WrongNumWarning -= ClearText;
    }

    private void ClearText() {
        text.text = "";
    }

    public override void ShowAll()
    {
        foreach (var item in AllNimages)
        {
            item.ShowAll();
        }

        LeanTween.value(0, 1, .5f).setOnUpdate(delegate (float val)
        {
            text.color = new Color(1, 1, 1, val);
        });

    }

    public override void HideAll()
    {
        foreach (var item in AllNimages)
        {
            item.HideAll();
        }
        LeanTween.value(1, 0, .5f).setOnUpdate(delegate (float val)
        {
            text.color = new Color(1, 1, 1, val);
        });
    }


}
