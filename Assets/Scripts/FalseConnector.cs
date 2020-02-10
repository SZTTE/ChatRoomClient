using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FalseConnector : MonoBehaviour
{
    public Boolean isOpen = true;
    public void StartConnect(string name)
    {
        Debug.Log($"作为用户{name}加入了聊天室");
    }

    public void EndConnect()
    {
        Debug.Log("结束连接");
        isOpen = false;
    }

    public void Send(string message)
    {
        Debug.Log("向聊天室发送消息："+message);
    }

    public ReceivedMessage Receive()
    {
        ReceivedMessage re = new ReceivedMessage("aabc","hi, 今天不仅天气不错，  还很  \n甚至我还换了行"+UnityEngine.Random.Range(1,100));
        return re;
    }
}

public class ReceivedMessage
{
    public string Name { get; }
    public string Message { get; }

    public ReceivedMessage(string name, string message)
    {
        Name = name;
        Message = message;
    }
}
