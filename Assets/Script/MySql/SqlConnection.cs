using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MySql.Data.MySqlClient;

/// <summary>
/// 数据库相关内容。
/// </summary>
public class SqlConnection : IDisposable
{
    private MySqlConnection MySqlConnection { get; set; }

    /// <summary>
    /// 新建一个与数据库的连接器。
    /// </summary>
    /// <param name="ip">目标产ip地址。</param>
    /// <param name="dataBase">数据库名。</param>
    /// <param name="uid">可选值，用户名，默认为root。</param>
    /// <param name="pwd">可选值，密码，默认为空。</param>
    /// <param name="port">可选值，端口，默认为3306。</param>
    public SqlConnection(string ip, string dataBase, string uid = "root", string pwd = "", int port = 3306)
    {

    }

    /// <summary>
    /// 连接数据库。
    /// </summary>
    public void Open()
    {

    }

    /// <summary>
    /// 断开连接。
    /// </summary>
    public void Close()
    {
        Dispose();
    }

    /// <summary>
    /// 断开连接。
    /// </summary>
    public void Dispose()
    {
        MySqlConnection.Dispose();
    }

    /// <summary>
    /// 输入一个不涉及查询的Sql命令。
    /// </summary>
    /// <param name="commandStr">命令</param>
    public void InputNoDataCommand(string commandStr)
    {
        using (MySqlCommand command = new MySqlCommand(commandStr, MySqlConnection))
            ExecuteNoDataCommand(command);
    }

    /// <summary>
    /// 输入一个涉及查询的Sql命令。
    /// </summary>
    /// <param name="commandStr">命令</param>
    /// <returns>返回<c>MySqlDataReader</c>类型。</returns>
    public MySqlDataReader InputDataCommand(string commandStr)
    {
        using (MySqlCommand command = new MySqlCommand(commandStr, MySqlConnection))
            return ExecuteDataCommand(command);
    }

    private static void ExecuteNoDataCommand(MySqlCommand command)
    {

    }

    private static MySqlDataReader ExecuteDataCommand(MySqlCommand command)
    {
        return null;
    }
}
