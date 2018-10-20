using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUICtr : MonoBehaviour {
    public PhonePad PhonePad;
    public TimeCountDown timeCountDown;
    public InformationPadCtr informationPadCtr;
	// Use this for initialization
	public void initialization() {
        PhonePad.initialization();
        timeCountDown.initialization();
        informationPadCtr.initialization();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        


    }

    private void OnDisable()
    {


    }
}
