using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ini : MonoBehaviour {
    CanvasManager CanvasManager;

    ReadJson readJson;

    VoiceRec voiceRec;


    // Use this for initialization
    void Start () {

      StartCoroutine(  initialization());

    }


    private IEnumerator initialization()
    {
        //----------------------
        CanvasManager = FindObjectOfType<CanvasManager>();
        readJson = FindObjectOfType<ReadJson>();
        voiceRec = FindObjectOfType<VoiceRec>();
        //------------------------ini--------------

        yield return StartCoroutine(readJson.initialization());
        CanvasManager.initialization();
        voiceRec.initialization();

    }

}
