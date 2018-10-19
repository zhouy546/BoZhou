using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUICtr : MonoBehaviour {
    public PhonePad PhonePad;
	// Use this for initialization
	public void initialization() {
        PhonePad.initialization();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadingCallingScene() {
        PhonePad.ShowPhonePad();
    }

    public void UnLoadingCallingScene() {
        PhonePad.HidePhonePad();
    }
}
