using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BootsTrap : MonoBehaviour
{
    private const string DateSynchronizationURL = "https://yandex.com/time/sync.json";

    public event Action<string> BootCompleted;

    private IEnumerator Start()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(DateSynchronizationURL))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(webRequest.error);
                    break;

                case UnityWebRequest.Result.Success:
                    BootCompleted?.Invoke(webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
