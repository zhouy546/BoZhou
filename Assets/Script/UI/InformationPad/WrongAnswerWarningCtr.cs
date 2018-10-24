using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongAnswerWarningCtr : ICtr {



    // Use thi s for initialization
    public override void initialization()
    {
        base.initialization();
        HideAll();
    }

    private void OnEnable()
    {
        CanvasManager.AnswerWrong += ShowAll;

    }

    private void OnDisable()
    {
        CanvasManager.AnswerWrong -= ShowAll;
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
        StartCoroutine(show());
    }

    public IEnumerator show() {
        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", true);
            item.image.raycastTarget = true;
        }

        yield return new WaitForSeconds(2f);

        HideAll();

        TimeCountDown.instance.startCoutDown();//返回后重新计时；

        VoiceRec.instance.startListening();//重新开始监听

    }
}
