using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failed : MonoBehaviour {

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void returnBack() {
        CanvasManager.hangupPhone();
        Submit.btn.interactable = false;
    }
}
