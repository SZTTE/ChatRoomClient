using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    public InputField input;
    public Button button;

    private Client client;
    private string message = "";
    private bool IsReceived = false;
    void Start()
    {
        client = new Client();
        client.StartConnect();

        client.StartReceive(GetMessage);
        button.onClick.AddListener(() => Press());
    }

    private void Update()
    {
        if (IsReceived)
        {
            IsReceived = false;
            text.text += message;
            message = "";
        }
    }

    void Press()
    {
        if (input.text != null)
        {
            client.Send(input.text);
            input.text = "";
        }
    }

    void GetMessage(string me)
    {
        message = me + "\n";
        IsReceived = true;
    }
}
