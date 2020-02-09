using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public static class DatabaseHelper
{
    private static MySqlConnection mysqlConnection =
        new MySqlConnection(
            "Database=test;Data Source=212.64.93.68;User Id=root;Password=2468fb419532a568;charset=utf8");
    private static MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM ChatroomAccount",mysqlConnection);

    /// <summary>
    /// 检查输入的账户是否与数据库中的某个账户吻合
    /// </summary>
    /// <param name="name">待检测的账户名</param>
    /// <param name="password">待检测的密码</param>
    /// <returns>如果吻合就返回真</returns>
    public static Boolean CheckAccount(string name, string password)
    {
        mysqlConnection.Open();
        sqlCommand.CommandText = "SELECT * FROM ChatRoomAccount WHERE name='" + name + "';";
        MySqlDataReader reader = sqlCommand.ExecuteReader();
        if(reader.Read()==false)
            return false;//如果没取到内容，就说明服务器里没有这个帐号了
        if (reader.GetString("password") == password)
        {
            mysqlConnection.Close();
            return true;//取到了内容并且密码正确
        }
        else
        {
            mysqlConnection.Close();
            return false;//取到了内容但是密码错误
        }
        
    }

    /// <summary>
    /// 注册账户
    /// </summary>
    /// <param name="name">待注册的用户名</param>
    /// <param name="password">待注册的密码</param>
    /// <returns>如果账号已经存在就返回假</returns>
    public static Boolean SignUp(string name, string password)
    {
        mysqlConnection.Open();
        sqlCommand.CommandText = "SELECT * FROM ChatRoomAccount WHERE name='" + name + "';";
        MySqlDataReader reader = sqlCommand.ExecuteReader();
        if(reader.Read())
            return false;//如果获取到内容，就说明账号已经存在
        reader.Close();
        sqlCommand.CommandText = "INSERT INTO ChatRoomAccount VALUES ('" + name + "','" + password + "');";
        sqlCommand.ExecuteNonQuery();
        return true;
    }
}
