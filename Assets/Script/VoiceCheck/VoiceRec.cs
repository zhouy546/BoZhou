using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRec : MonoBehaviour {

    public static VoiceRec instance;
    public string[] keyWords = new string[] { "确认", "开始", "返回", "暂停" };
    public ConfidenceLevel confidenLevel = ConfidenceLevel.Medium;
    PhraseRecognizer recognizer;
    public ConversationCtr conversationCtr;

    private int AnswerFailMaxTimes=4;
    private int CurrentAnswerFailaTimes = 0;


    public void initialization() {
        keyWords = ValueSheet.keySting.ToArray();
    }

    private void OnEnable()
    {
        
        CanvasManager.StartConversation += startListening;
        CanvasManager.FinishConversation += StopListiing;

        CanvasManager.AnswerWrong += StopListiing;
    }

    private void OnDisable()
    {
        CanvasManager.StartConversation -= startListening;
        CanvasManager.FinishConversation -= StopListiing;
        CanvasManager.AnswerWrong -= StopListiing;
    }


    public void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public  void startListening() {

        if (recognizer == null) {
            recognizer = new KeywordRecognizer(keyWords, confidenLevel);
            recognizer.OnPhraseRecognized += mainCheck;  // 注册事件           
            recognizer.Start();
            return;
        }



        if (!recognizer.IsRunning) {
            recognizer = new KeywordRecognizer(keyWords, confidenLevel);
            recognizer.OnPhraseRecognized += mainCheck;  // 注册事件           
            recognizer.Start();
        }

    }

    public void StopListiing() {
        recognizer.Stop();
        recognizer.Dispose();
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
            CurrentAnswerFailaTimes++;
            if (CurrentAnswerFailaTimes <= AnswerFailMaxTimes)
            {
                CanvasManager.answerWrong();
            }
            else {
                CurrentAnswerFailaTimes = 0;
                CanvasManager.failed();
            }
         
        }


    }


}
