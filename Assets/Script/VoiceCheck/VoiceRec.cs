using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRec : MonoBehaviour {

    public static VoiceRec instance;
    public string[] keyWords = new string[] { "确认", "开始", "返回", "暂停" };
    // Use this for initialization
    public ConfidenceLevel confidenLevel = ConfidenceLevel.Medium;
    PhraseRecognizer recognizer;
    public ConversationCtr conversationCtr;
    private void OnEnable()
    {
        CanvasManager.StartConversation += startListening;
        CanvasManager.AnswerWrong += StopListiing;
    }

    private void OnDisable()
    {
        CanvasManager.StartConversation -= startListening;
        CanvasManager.AnswerWrong -= StopListiing;
    }


    public void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public  void startListening() {

        if (!recognizer.IsRunning) {
            recognizer = new KeywordRecognizer(keyWords, confidenLevel);
            recognizer.OnPhraseRecognized += mainCheck;  // 注册事件
            

            recognizer.Start();
        }

    }

    public void StopListiing() {
        recognizer.Stop();
    }

    public void mainCheck(PhraseRecognizedEventArgs args)
    {
        string str = args.text;
        Debug.Log(str.ToString());

        if (conversationCtr.ListeningStr(str))
        {//如果正确更新
            CanvasManager.answerCorrect();
        }
        else
        {//没能更新
            CanvasManager.answerWrong();
        }


    }


}
