using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;

using UnityEngine.UI;

public class ReadJson : MonoBehaviour {
    public static ReadJson instance;

    //public  Ntext ntext;

    private JsonData itemDate;

    private string jsonString;

    int id;
    string bigTitle;
    // Use this for initialization
    void Start () {
        if (instance == null)
        {

            instance = this;

        }

     StartCoroutine(readJson());

    }

    IEnumerator readJson() {
        string spath = Application.streamingAssetsPath + "/information.json";

        Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

       itemDate = JsonMapper.ToObject(jsonString.ToString());


        for (int i = 0; i < itemDate["information"].Count; i++)

        {

             id = int.Parse(itemDate["information"][i]["id"].ToString());//get id;

             bigTitle = itemDate["information"][i]["BigTitle"].ToString();//get bigtitle;

            Debug.Log(bigTitle);
        }

        //setupUI(bigTitle);

    }

    //void setupUI(string str) {
    //    ntext.SetText(str);
    //}
}
