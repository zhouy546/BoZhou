﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongNumber : MonoBehaviour {

    public WrongNumberCtr wrongNumberCtr;

    public void HideMe() {
        wrongNumberCtr.HideAll();
        Submit.btn.interactable = true;
        TimeCountDown.instance.BreakCountDown();
        TimeCountDown.instance.startCoutDown();
    }
}
