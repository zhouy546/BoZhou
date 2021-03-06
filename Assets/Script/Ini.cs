﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ini : MonoBehaviour {
    CanvasManager CanvasManager;

    ReadJson readJson;

    VoiceRec voiceRec;

    SoundManager soundManager;


    // Use this for initialization
    void Start () {

      StartCoroutine(  initialization());

    }


    private IEnumerator initialization()
    {
        Screen.SetResolution(768, 1024, true);
        //----------------------
        CanvasManager = FindObjectOfType<CanvasManager>();
        readJson = FindObjectOfType<ReadJson>();
        voiceRec = FindObjectOfType<VoiceRec>();
        soundManager = FindObjectOfType<SoundManager>();

        //------------------------ini--------------
        //yield return StartCoroutine(ReadMePic());
       yield return StartCoroutine(readJson.initialization());
        CanvasManager.initialization();
        voiceRec.initialization();
        soundManager.initialization();

    }

    //IEnumerator ReadMePic()
    //{

    //        List<Sprite> sp = new List<Sprite>();
    //    string path = "/ConversationPic/Me/";
    //        // Debug.Log(path);
    //        yield return GetSpriteListFromStreamAsset(path, "jpg", sp);

    //    ValueSheet.meSprites = sp;
    //}


    IEnumerator GetSpriteListFromStreamAsset(string path, string suffix, List<Sprite> sprites)
    {
        List<Texture> texturesList = new List<Texture>();
        string streamingPath = Application.streamingAssetsPath + path;
        DirectoryInfo dir = new DirectoryInfo(streamingPath);

        GetAllFiles(dir, path, suffix);

        foreach (string de in jpgName)
        {
            WWW www = new WWW(Application.streamingAssetsPath + path + de);
            yield return www;
            if (www != null)
            {
                Texture texture = www.texture;
                texture.name = de;
                texturesList.Add(texture);
            }
            if (www.isDone)
            {
                www.Dispose();
            }
        }

        foreach (var texture in texturesList)
        {
            Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            sprite.name = texture.name;
            sprites.Add(sprite);
        }

        jpgName.Clear();
    }

    List<string> jpgName = new List<string>();

    public void GetAllFiles(DirectoryInfo dir, string Filepath, string suffix)
    {
        FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();   //初始化一个FileSystemInfo类型的实例
        foreach (FileSystemInfo i in fileinfo)              //循环遍历fileinfo下的所有内容
        {
            if (i is DirectoryInfo)             //当在DirectoryInfo中存在i时
            {
                GetAllFiles((DirectoryInfo)i, Filepath, suffix);  //获取i下的所有文件
            }
            else
            {
                string str = i.FullName;        //记录i的绝对路径
                string path = Application.streamingAssetsPath + Filepath;
                string strType = str.Substring(path.Length);

                if (strType.Substring(strType.Length - 3).ToLower() == suffix)
                {
                    if (jpgName.Contains(strType))
                    {
                    }
                    else
                    {
                        jpgName.Add(strType);
                    }
                }
            }
        }
    }
}
