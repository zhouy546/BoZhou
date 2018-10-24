using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICtr : MonoBehaviour {
    public List<NImage> AllNimages = new List<NImage>();
    private float Show_HideTime=1f;


    public virtual void initialization()
    {
        NImage[] tempImages = GetComponentsInChildren<NImage>();
        AllNimages.AddRange(tempImages);

        foreach (var item in AllNimages)
        {
            item.initialization();
        }

    }

    public virtual void ShowAll()
    {
        foreach (var item in AllNimages)
        {
            item.ShowAll(Show_HideTime);
            item.image.raycastTarget = true;
        }

    }

    public virtual void HideAll()
    {
        foreach (var item in AllNimages)
        {
            item.HideAll(Show_HideTime);
            item.image.raycastTarget = false;

        }

    }

    public virtual void UpdateText(string str) {

    }


    public virtual void UpdatePic(int num) {

    }

}
