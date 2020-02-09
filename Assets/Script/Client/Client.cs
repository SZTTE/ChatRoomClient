using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System;
using UnityEngine;

/// <summary>
/// 客户端类，用于管理客户端相关。
/// </summary>
public class Client : IDisposable
{
    private int Port { get; } = 10086;
    private byte[] Data { get; set; }
    private Socket ClientSocket { get; set; }
    private string IP { get; } = "127.0.0.1";

    /// <summary>
    /// Client构造函数。
    /// </summary>
    /// <param name="dataMaxLength">可选值，表示缓冲区大小。</param>
    public Client(int dataMaxLength = 1024)
    {

    }

    /// <summary>
    /// 连接服务器。
    /// </summary>
    public void Connect()
    {

    }

    /// <summary>
    /// 向服务器发送信息。此为同步方法，需要用协程或是多线程处理。
    /// </summary>
    /// <param name="message">信息</param>
    public void Send(string message)
    {

    }

    /// <summary>
    /// 从服务器获取信息。此为同步方法，需要用协程或是多线程处理。
    /// </summary>
    /// <returns>返回<c>string</c>类型，是获取的原始信息。</returns>
    public string Receive()
    {
        return null;
    }

    /// <summary>
    /// 关闭客户端。
    /// </summary>
    public void Close()
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
