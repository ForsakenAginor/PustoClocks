using Newtonsoft.Json;
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

    private void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RequestResult result = JsonConvert.DeserializeObject<RequestResult>(_result);
            DateTime time =
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(result.Time);
            Debug.Log(time.Date);
            Debug.Log(time.ToLongTimeString());
            time = time.ToLocalTime();
            Debug.Log(time.ToLongTimeString());
        }*/
    }
}
