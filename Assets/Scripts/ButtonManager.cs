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
    public String userName = "unnamed";
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
        if (DatabaseHelper.SignUp(nameBox.text, passwordBox.text)) //如果注册失败，即数据库有此账号
        {//注册成功的情况
            instructionText.text = $"~注册了名为{nameBox.text}的新账号！";
            userName = nameBox.text;
            yield return new WaitForSeconds(2f);
            signInterface.SetActive(false);
            Connector.StartConnect(userName);
        }
        else
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
        Connector.Send(mainInputField.text);
        ChatTextManager.Instance.AddMyMessage(mainInputField.text);
        mainInputField.text = "";
    }
}
