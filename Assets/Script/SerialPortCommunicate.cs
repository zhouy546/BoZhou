using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.ComponentModel;
using UnityEngine.UI;

public class SerialPortCommunicate : MonoBehaviour {
    //定义基本信息
    public string portName = "COM2";
    public int baudRate = 9600;
    public Parity parity = Parity.None;
    public int dataBits = 8;
    public StopBits stopBits = StopBits.One;

    int[] data = new int[6];//用于存储6位数据
    SerialPort sp = null;
    Thread dataReceiveThread;
    //发送
    string message = "";

    Thread CheckThread;

    public string Status = "";
    //byte[] message=new byte[8];
    void Start()
    {
        OpenPort();
        dataReceiveThread = new Thread(new ThreadStart(DataReceiveFunction));
        dataReceiveThread.Start();

        CheckThread = new Thread(new ThreadStart(write));
        CheckThread.Start();

        StartCoroutine(check());
    }

    void Update()
    {

    }

    bool switcher = false;
    IEnumerator check() {

        if (Status == "挂断" && switcher == false)
        {

            switcher = true;
            CanvasManager.hangupPhone();
        }
        else if (Status == "接通" && switcher == true)
        {
            switcher = false;
            CanvasManager.call();
        }

        yield return new WaitForSeconds(.2f);
        StartCoroutine(check());
    }


    void write() {

        while (true)
        {
            if (sp != null && sp.IsOpen)
            {
                Write();

            }

            Thread.Sleep(10);
        }

    }

    public void Write() {
        Byte[] TxData = { 1, 2 };
        sp.Write(TxData, 0, 2);
    }

    public void OpenPort()
    {
        sp = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
        sp.ReadTimeout = 400;
        try
        {
            sp.Open();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void ClosePort()
    {
        try
        {
            sp.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void WriteData(string dataStr)
    {
        if (sp.IsOpen)
        {
            sp.Write(dataStr);
        }

    }


    void OnApplicationQuit()
    {
        ClosePort();
    }


    void DataReceiveFunction()
    {
        byte[] buffer = new byte[128];
        int bytes = 0;
        //定义协议
        int flag0 = 0xFF;
        int flag1 = 0xAA;
        int index = 0;//用于记录此时的数据次序
        while (true)
        {
            if (sp != null && sp.IsOpen)
            {
                try
                {
                    bytes = sp.Read(buffer, 0, buffer.Length);
                    for (int i = 0; i < bytes; i++)
                    {

                        if (buffer[i] == flag0 || buffer[i] == flag1)
                        {
                            index = 0;//次序归0 
                            continue;
                        }
                        else
                        {
                            if (index >= data.Length) index = data.Length - 1;//理论上不应该会进入此判断，但是由于传输的误码，导致数据的丢失，使得标志位与数据个数出错
                            data[index] = buffer[i];//将数据存入data中
                            index++;
                        }

                    }

                    //通电，挂断电话

                    Status = "挂断";

                }
                catch (Exception ex)
                {
                    if (ex.GetType() != typeof(ThreadAbortException))
                    {
                        Debug.Log(ex.Message+"拿起电话");


                        Status = "接通";
                    }
                }
            }
            Thread.Sleep(10);
        }
    }




}
