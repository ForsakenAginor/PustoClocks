using System;
using UnityEngine;

public class BootsTrap : MonoBehaviour
{
    public event Action<string> BootCompleted;

    private void Start()
    {
        WebRequestSender webRequestSender = new WebRequestSender();
        StartCoroutine(webRequestSender.SendWebRequest(BootCompleted));
    }
}
