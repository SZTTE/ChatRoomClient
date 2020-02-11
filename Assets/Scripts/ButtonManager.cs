using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager:MonoBehaviour
{
    [SerializeField] private InputField nameBox;
    [SerializeField] private InputField passwordBox;
    [SerializeField] private Text instructionText;
    [SerializeField] private GameObject signInterface;
    [SerializeField] private InputField mainInputField;
    public string userName = "unnamed";
    public static ButtonManager instance;
    private FalseConnector Connector;
    public ButtonManager()
    {
        instance = this;
        Connector = FalseConnector.Instance;
    }

    public void AccountButton()
    {
        StartCoroutine(AccountButtonCor());
    }

    public IEnumerator AccountButtonCor()
    {
        if (DatabaseHelper.SignUp(nameBox.text, passwordBox.text)) 
        {//注册成功的情况
            instructionText.text = $"~注册了名为{nameBox.text}的新账号！";
            userName = nameBox.text;
            yield return new WaitForSeconds(2f);
            signInterface.SetActive(false);
            Connector.StartConnect(userName);
        }
        else//如果注册失败，即数据库有此账号，就改为登录
        {
            if (DatabaseHelper.CheckAccount(nameBox.text, passwordBox.text))
            {//登陆成功的情况
                instructionText.text = $"~作为{nameBox.text}进入聊天室！";
                userName = nameBox.text;
                yield return new WaitForSeconds(2f);
                signInterface.SetActive(false);
                Connector.StartConnect(userName);
            }
            else
            {//密码错误的情况
                instructionText.text = $"#存在名为{nameBox.text}的账户，可是密码不匹配";
            }
        }
        
        yield break;
    }

    public void SendButton()
    {
        if (mainInputField.text == "")
            return;

        Connector.Send(userName+"\x3"+mainInputField.text);
        mainInputField.text = "";
    }

    public void OnInput()
    {
        if (!(mainInputField.text == "") && mainInputField.text[mainInputField.text.Length - 1] == '\n')
        {
            if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))  //按下enter时，如果没有同时按下control，才发送
            {
                mainInputField.text = mainInputField.text.Remove(mainInputField.text.Length - 1);
                SendButton();
            }
        }
    }
}
