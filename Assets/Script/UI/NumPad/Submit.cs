using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Submit : MonoBehaviour {
    public ConnectLine connectLine;
    public int TryNum = 2;
    public Text text;
    public static Button btn;

    private void OnEnable()
    {
        btn = this.GetComponent<Button>();
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
        Submit.btn.interactable = false;
        TimeCountDown.instance.BreakCountDown();
        connectLine.ShowAll();
        SoundManager.instance.playConnecting();
        yield return new WaitForSeconds(6);
        SoundManager.instance.StopBGM();
        CanvasManager.startConversation();
    }

    public void restValue() {
        TryNum = 2;
    }

}
