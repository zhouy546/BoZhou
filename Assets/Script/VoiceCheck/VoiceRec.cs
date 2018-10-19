using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRec : MonoBehaviour {
    public string[] keyWords = new string[] { "确认", "开始", "返回", "暂停" };
    // Use this for initialization
    public ConfidenceLevel confidenLevel = ConfidenceLevel.Medium;
    PhraseRecognizer recognizer;

    // Use this for initialization
    void Start () {
        recognizer = new KeywordRecognizer(keyWords, confidenLevel);
        recognizer.OnPhraseRecognized += Display;  // 注册事件
        recognizer.Start();
    }

    public void Display(PhraseRecognizedEventArgs args)
    {
        string str = args.text;
        Debug.Log(str.ToString());
    }

}
