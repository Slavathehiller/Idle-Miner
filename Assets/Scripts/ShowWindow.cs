using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWindow : MonoBehaviour
{
    public Text Message;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ShowMessage(string message)
    {
        Message.text = message;
        this.gameObject.SetActive(true);
    }

    public void CloseMessage()
    {
        this.gameObject.SetActive(false);
    }
}
