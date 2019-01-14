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
    public IEnumerator initialization() {
        if (instance == null)
        {

            instance = this;

        }

     yield return StartCoroutine(readJson());

    }

    IEnumerator readJson() {
        string spath = Application.streamingAssetsPath + "/information.json";

      //  Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

       itemDate = JsonMapper.ToObject(jsonString.ToString());


        getstringArray(ValueSheet.FireManString, "FireManString");

        getstringArray(ValueSheet.keySting, "KeyWords");

       

        ValueSheet.success = itemDate["config"]["Success"].ToString();

        GetAnswerList();
        //setupUI(bigTitle);

    }


    public void GetAnswerList() {
        
        for (int i = 0; i < itemDate["config"]["MeString"].Count; i++)
        {

            List<string> ans = new List<string>();
            for (int j = 0; j < itemDate["config"]["MeString"][i.ToString()].Count; j++)
            {
                ans.Add(itemDate["config"]["MeString"][i.ToString()][j].ToString());
            }

            List<float> val = new List<float>();
            for (int j = 0; j < itemDate["config"]["Value"][i.ToString()].Count; j++)
            {
                val.Add(float.Parse(itemDate["config"]["Value"][i.ToString()][j].ToString()));
            }

            ValueSheet.MeAnswer.Add(new I_step.Answer(ans.ToArray(), val.ToArray()));
        }

    }

    public void getstringArray(List<string> strings,string tag) {
        for (int i = 0; i < itemDate["config"][tag].Count; i++)
        {
            //Debug.Log(itemDate["config"][tag][i].ToString());
            strings.Add(itemDate["config"][tag][i].ToString());
        }
    }




}
