using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedCtr : ICtr {

    public override void initialization() {
        base.initialization();
        HideAll();
    }

    private void OnEnable()
    {
        CanvasManager.Failed += ShowAll;
        CanvasManager.HangupPhone += HideAll;    
    }

    private void OnDisable()
    {
        CanvasManager.HangupPhone -= HideAll;
        CanvasManager.Failed -= ShowAll;
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


    private IEnumerator show()
    {
        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", true);
            item.image.raycastTarget = true;
        }
        Submit.btn.interactable = false;

        yield return new WaitForSeconds(3f);

        HideAll();
        CanvasManager.hangupPhone();
        Submit.btn.interactable = true;
    }
}
