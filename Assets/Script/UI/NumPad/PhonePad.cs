using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePad : MonoBehaviour {

    public List<ICtr> PhonePadCtr = new List<ICtr>();

    public void  initialization() {
        foreach (var item in PhonePadCtr)
        {
            item.initialization();
        }

        HidePhonePad();

    }

    public void ShowPhonePad() {
        foreach (var item in PhonePadCtr)
        {
            item.ShowAll();
        }
    }

    public void HidePhonePad() {
        foreach (var item in PhonePadCtr)
        {
            item.HideAll();
        }
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    HidePhonePad();
        //}
        //else if (Input.GetKeyDown(KeyCode.O))
        //{

        //    ShowPhonePad();
        //}
    }
}
