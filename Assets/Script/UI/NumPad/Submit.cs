using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Submit : MonoBehaviour {
    public Text text;

    public void Check() {
        if (text.text == "119")
        {
            Debug.Log(" 开始连线");

            StartCoroutine(Connecting());

        }
        else {
            Debug.Log("出现提示");
        }
    }

    public IEnumerator Connecting() {
        Debug.Log("开始动画");
        yield return new WaitForSeconds(3);
        CanvasManager.startConversation();
    }
}
