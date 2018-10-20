using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationPadCtr : ICtr {
    public List<ICtr> ctrs = new List<ICtr>();
	// Use this for initialization
	public override void initialization() {
        foreach (var item in ctrs)
        {
            item.initialization();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
