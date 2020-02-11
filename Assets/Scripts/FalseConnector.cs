using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using Random = System.Random;

public class FalseConnector : MonoBehaviour
{
    public static FalseConnector Instance;
    private TcpClient tcpClient;
    public Boolean newMessageCome = false;
    private NetworkStream networkStream;
    private ReceivedMessage receivedMessage;

    public FalseConnector()
    {
        Instance = this;
    }

    public void StartConnect(string name)
    {
        tcpClient = new TcpClient();
        tcpClient.Connect(IPAddress.Parse("127.0.0.1"),27105);
        networkStream = tcpClient.GetStream();
        Debug.Log($"作为用户{name}加入了聊天室");
    }

    public void EndConnect()
    {
        Debug.Log("结束连接");
    }

    public void Send(string message)
    {
        while (!networkStream.CanWrite);
        Debug.Log("真的写了");
        byte[] data = Encoding.UTF8.GetBytes(message);
        networkStream.Write(data,0,data.Length);
        Debug.Log("向聊天室发送消息："+message);
    }

    private IAsyncResult iAsyncResult;
    private byte[] data;
    private Boolean nowReading = false;

    private void Update()
    {
        if (nowReading==false&&networkStream!=null)
        {
            data = new byte[1000];
            iAsyncResult = networkStream.BeginRead(data, 0, 1000, null, null);
            nowReading = true;
            Debug.Log("开始读取");
        }

        if (networkStream!=null&&iAsyncResult!=null&&iAsyncResult.IsCompleted)
        {
            string rowString = Encoding.UTF8.GetString(data, 0, 1000);
            string[] splitedString = rowString.Split('\x3');
            newMessageCome = true;
            receivedMessage = new ReceivedMessage(splitedString[0], splitedString[1]);
            networkStream.EndRead(iAsyncResult);
            nowReading = false;
            Debug.Log("读取器读到");
        }
    }
    public ReceivedMessage Receive()
    {
        newMessageCome = false;
        return receivedMessage;
        
    }

    struct ResultData//用来存放
    {
        public NetworkStream NetworkStream;
        public byte[] data;
    }
}

public class ReceivedMessage
{
    public string Name { get; set; }
    public string Message { get; set; }

    public ReceivedMessage(string name, string message)
    {
        Name = name;
        Message = message;
    }
}
