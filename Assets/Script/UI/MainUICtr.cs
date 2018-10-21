using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUICtr : MonoBehaviour {
    public PhonePad PhonePad;
    public TimeCountDown timeCountDown;
    public InformationPadCtr informationPadCtr;
    public ConversationCtr conversationCtr;
	// Use this for initialization
	public void initialization() {
        PhonePad.initialization();
        timeCountDown.initialization();
        informationPadCtr.initialization();
        conversationCtr.initialization();
    }
	
    private void OnEnable()
    {
        


    }

    private void OnDisable()
    {


    }
}
