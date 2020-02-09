using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 信息处理的静态类。
/// </summary>
public static class Message
{
    /// <summary>
    /// 信息的分隔符。
    /// </summary>
    public static char SplitChar { get; } = '\a';

    /// <summary>
    /// 信息的终止符。
    /// </summary>
    public static char EndChar { get; } = '\x03';

    /// <summary>
    /// 创建用于发送的信息。
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="message">消息</param>
    /// <returns>返回<c>string</c>类型,是组合后的信息内容。</returns>
    public static string GetMessage(string userName, string message)
    {
        return null;
    }

    /// <summary>
    /// 分割获取的信息。
    /// </summary>
    /// <param name="message">信息</param>
    /// <returns>返回<c>string[]</c>类型,为分割后的信息。</returns>
    public static string[] SplitMessage(string message)
    {
        return null;
    }
}
