using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour {
    public SuccessCtr successCtr;

    public void HideMe()
    {
        successCtr.HideAll();
        CanvasManager.instance.PlayScreenProtect();
    }
}
