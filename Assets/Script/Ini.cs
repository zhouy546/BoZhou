using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ini : MonoBehaviour {
    CanvasManager CanvasManager;


    // Use this for initialization
    void Start () {

        initialization();

    }


    private void initialization()
    {
        //----------------------
        CanvasManager = FindObjectOfType<CanvasManager>();

        //------------------------ini--------------
        CanvasManager.initialization();

    }

}
