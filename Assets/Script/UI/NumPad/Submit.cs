using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Submit : MonoBehaviour {

    public int TryNum = 2;
    public Text text;


    private void OnEnable()
    {
        CanvasManager.Failed += fail;
        CanvasManager.WrongNumWarning += warning;
        CanvasManager.Failed += restValue;

    }

    private void OnDisable()
    {
        CanvasManager.Failed -= fail;
        CanvasManager.WrongNumWarning -= warning;
        CanvasManager.Failed -= restValue;
    }

    void fail()
    {


        Debug.Log("报警失败");


    }

    void warning() {
        Debug.Log("出现提示");
    }


    public void Check() {
        if (text.text == "119")
        {
            Debug.Log(" 开始连线");

            StartCoroutine(Connecting());

        }
        else {
            TryNum--;
            if (TryNum > 0)
            {
                CanvasManager.wrongNumWarning();
            }
            else {

                CanvasManager.failed();
              
            }

        }
    }

    public IEnumerator Connecting() {
        Debug.Log("开始动画");
        yield return new WaitForSeconds(3);
        CanvasManager.startConversation();
    }

    public void restValue() {
        TryNum = 2;
    }

}
