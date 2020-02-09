using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DatabaseHelper.SignUp("nopwd",""));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
