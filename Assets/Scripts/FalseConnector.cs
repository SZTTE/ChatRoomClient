using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FalseConnector : MonoBehaviour
{
    public Boolean isOpen = true;
    private Client client;
    private Boolean haveGotMessage = false;
    private string messageRead;
    public Boolean newMessageCome = false;
    private ReceivedMessage re = new ReceivedMessage("", "");
    public static FalseConnector Instance;

    public FalseConnector()
    {
        Instance = this;
    }

    public void StartConnect(string name)
    {
        Debug.Log($"作为用户{name}加入了聊天室");
        client = new Client();
        client.StartConnect();
        client.StartReceive(GiveMeMessage);
    }

    public void EndConnect()
    {
        Debug.Log("结束连接");
        isOpen = false;
    }

    public void Send(string message)
    {
        Debug.Log("向聊天室发送消息："+message);
        client.Send(message);
    }

    private void Update()
    {
        if (haveGotMessage)
        {
            haveGotMessage = false;
            newMessageCome = true;

            string[] strs = messageRead.Split('\a');
            re.Name = strs[0];
            re.Message = strs[1];
        }
    }

    public ReceivedMessage Receive()
    {
        newMessageCome = false;
        return re; 
    }

    private void GiveMeMessage(string msg)
    {
        messageRead = msg;
        haveGotMessage = true;
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
