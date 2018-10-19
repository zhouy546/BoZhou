using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeleteBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void Delete(Text textGui) {
        if (textGui.text != "") {
            List<char> chars = new List<char>();
            chars = textGui.text.ToCharArray().ToList();
            chars.Remove(chars.Last());

            textGui.text = new string(chars.ToArray());
        }
    }

    public void TurnOffInteractable() {

    }

    public void TurnOnInteractable() {

    }
}
