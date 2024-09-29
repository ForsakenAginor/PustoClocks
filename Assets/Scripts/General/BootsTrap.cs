using System;
using UnityEngine;

public class BootsTrap : MonoBehaviour, IDataReceiver
{
    public event Action<string> DataReceived;

    private void Start()
    {
        WebRequestSender webRequestSender = new WebRequestSender();
        StartCoroutine(webRequestSender.SendWebRequest(DataReceived));
    }
}
