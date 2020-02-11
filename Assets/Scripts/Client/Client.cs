using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using UnityEngine;
using System.Text;

/// <summary>
/// 客户端类，用于管理客户端相关。
/// </summary>
public class Client : IDisposable
{
    public bool IsConnected { get => ClientSocket.Connected; }
    private int Port { get; } = 10086;
    private byte[] Data { get; set; }
    private Socket ClientSocket { get; set; }
    private string IP { get; } = "212.64.93.68";
    //private string IP { get; } = "127.0.0.1";

    private event Action<string> onReceived;

    /// <summary>
    /// Client构造函数。
    /// </summary>
    /// <param name="dataMaxLength">可选值，表示缓冲区大小。</param>
    public Client(int dataMaxLength = 1024)
    {
        Data = new byte[dataMaxLength];
        ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    /// <summary>
    /// 连接服务器。
    /// </summary>
    public void StartConnect()
    {
        IPAddress ip = IPAddress.Parse(IP);
        try
        {
            ClientSocket.Connect(new IPEndPoint(ip, 10086));
            Debug.Log("连接成功!");
        }
        catch (Exception e)
        {
            Debug.Log("连接失败!");
            Debug.LogError(e.Message);
        }
    }

    /// <summary>
    /// 向服务器发送信息。此为同步方法，需要用协程或是多线程处理。
    /// </summary>
    /// <param name="message">信息</param>
    public void Send(string message)
    {
        if (!IsConnected)
            throw new Exception("没有连接，发送消息失败，请检查网络!");

        try
        {
            ClientSocket.Send(Encoding.UTF8.GetBytes(message));
            Debug.Log($"发送{message}成功!");
        }
        catch (Exception e)
        {
            Debug.Log("发送信息失败!");
            Debug.Log(e.Message);
        }  
    }

    /// <summary>
    /// 从服务器获取信息。此为同步方法，需要用协程或是多线程处理。
    /// </summary>
    /// <returns>返回<c>string</c>类型，是获取的原始信息。</returns>
    public void StartReceive(Action<string> action)
    {
        if (!IsConnected)
            throw new Exception("没有连接，接受消息失败，请检查网络!");

        onReceived += action;
        Thread thread = new Thread(OnReceive);
        thread.Start();
    }

    private void OnReceive()
    {
        while (IsConnected)
        {
            try
            {
                int length = ClientSocket.Receive(Data);
                string message = Encoding.UTF8.GetString(Data, 0, length);
                onReceived(message);
            }
            catch (Exception e)
            {
                Debug.Log("发送信息失败!");
                Debug.Log(e.Message);
                ClientSocket.Shutdown(SocketShutdown.Receive);
            }
        }
    }


    /// <summary>
    /// 关闭客户端。
    /// </summary>
    public void EndConnect()
    {
        Dispose();
    }

    /// <summary>
    /// 关闭客户端。
    /// </summary>
    public void Dispose()
    {
        ClientSocket.Dispose();
    }
}
