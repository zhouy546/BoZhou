﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongNumberCtr : ICtr {

	// Use this for initialization
	public override void initialization() {
        base.initialization();
        HideAll();
        Debug.Log("Hide warning");
	}

    private void OnEnable()
    {
        CanvasManager.WrongNumWarning += ShowAll;
    }

    private void OnDisable()
    {
        CanvasManager.WrongNumWarning -= ShowAll;
    }

    public override void HideAll()
    {
        base.HideAll();
    }

    public override void ShowAll()
    {
        base.ShowAll();
        Submit.btn.interactable = false;

    }
}
