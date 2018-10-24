using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongNumberCtr : ICtr {
    //public Button btn;
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
        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", false);
            item.image.raycastTarget = false;
        }
        Submit.btn.interactable = true;
        //  btn.interactable = false;
    }

    public override void ShowAll()
    {
        StartCoroutine(show());

      //  btn.interactable = true;
    }

    private IEnumerator show() {
        foreach (var item in AllNimages)
        {
            item.GetComponent<Animator>().SetBool("Show", true);
            item.image.raycastTarget = true;
        }
        Submit.btn.interactable = false;

        yield return new WaitForSeconds(2f);

        HideAll();
    }
}
