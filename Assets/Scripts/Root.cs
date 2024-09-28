using System;
using Newtonsoft.Json;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private BootsTrap _bootrap;
    [SerializeField] private Synchronization _synchronization;
    [SerializeField] private TextClock _textClock;
    [SerializeField] private ClassicClock _clock;

    private DateTime _time;

    private void Awake()
    {
        _bootrap.BootCompleted += OnDataReceived;
        _synchronization.DataSynchronized += OnDataReceived;
    }

    private void OnDestroy()
    {
        _bootrap.BootCompleted -= OnDataReceived;        
        _synchronization.DataSynchronized -= OnDataReceived;
    }

    private void OnDataReceived(string result)
    {
        RequestResult data = JsonConvert.DeserializeObject<RequestResult>(result);
        _time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(data.Time);
        _time = _time.ToLocalTime();
        _textClock.Init(_time);
        _clock.Init(_time);
    }
}
