using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 账号类，包含账号信息，以及一些对账号的操作。
/// </summary>
public class Account
{
    /// <summary>
    /// 用户账号。
    /// </summary>
    public string UserAccount { get; private set; }
    /// <summary>
    /// 用户密码。
    /// </summary>
    public string UserPassword { get; private set; }

    /// <summary>
    /// Account构造函数。
    /// </summary>
    /// <param name="userAccount">用户账号</param>
    /// <param name="userPassword">用户密码</param>
    public Account(string userAccount, string userPassword)
    {
        UserAccount = userAccount;
        UserPassword = userPassword;
    }

    /// <summary>
    /// 向数据库创建一个新账号。
    /// </summary>
    /// <param name="account">目标账号</param>
    /// <returns>
    /// <para>返回<c>bool</c>类型。</para>
    /// <para>若为True,表示创建成功。</para>
    /// <para>若为False,表示创建失败。</para>
    /// </returns>
    public static bool CreateNewAccount(Account account)
    {
        return false;
    }

    /// <summary>
    /// 登录账号。
    /// </summary>
    /// <param name="account">目标账号</param>
    /// <returns>
    /// <para>返回<c>bool</c>类型。</para>
    /// <para>若为True,表示登录成功。</para>
    /// <para>若为False,表示登录失败。</para>
    /// </returns>
    public static bool LogIn(Account account)
    {
        return false;
    }

    /// <summary>
    /// 从数据库里删除一个账号。
    /// </summary>
    /// <param name="account">目标账号</param>
    /// <returns>
    /// <para>返回<c>bool</c>类型。</para>
    /// <para>若为True,表示删除成功。</para>
    /// <para>若为False,表示删除失败。</para>
    /// </returns>
    public static bool DeleteAccount(Account account)
    {
        return false;
    }
}
