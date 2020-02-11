using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ChatTextManager : MonoBehaviour
{
    [SerializeField] private Text textBox;
    private FalseConnector connector;
    public static ChatTextManager Instance;
    private ReceivedMessage lastRe;
    public ChatTextManager()
    {
        Instance = this;
    }

    void Start()
    {
        connector = FalseConnector.Instance;
    }

    
    void Update()
    {
        if (connector.newMessageCome)
        {
            ReceivedMessage re = connector.Receive();
            if (re.Name!=ButtonManager.instance.userName)//如果接收到的消息不是本人发出的，将用户名显示为蓝色
            {
                textBox.text +=
                    $"\n<color=#53bdb6FF><size=15>{re.Name}</size></color>\t\t<color=#727272FF><size=13>{DateTime.Now.ToString()}</size></color>";
                textBox.text += "\n" + re.Message;
            }
            else//如果接收到的信息是本人发生的
            {
                textBox.text += $"\n<color=#fcff39FF><size=15>{ButtonManager.instance.userName}</size></color>\t\t<color=#727272FF><size=13>{DateTime.Now.ToString()}</size></color>";
                textBox.text += "\n"+re.Message;
            }

            //下面删除上方多余的字符
            if (textBox.text.Length >= 4000)
            {
                textBox.text = textBox.text.Remove(0,textBox.text.IndexOf('\n',500));
            }
        }
    }

}
