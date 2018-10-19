using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NumBtn : MonoBehaviour {
    public char num;
    public Text text;

    public void AddText() {

       char[] CHAR = text.text.ToCharArray();
        List<char> CR = new List<char>();

        CR.AddRange(CHAR.ToList());
        CR.Add(num);

        text.text = new string(CR.ToArray());
    }
	

}
