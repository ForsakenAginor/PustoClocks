using Newtonsoft.Json;
using System;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private BootsTrap _bootrap;
    [SerializeField] private TextClock _textClock;
    [SerializeField] private ClassicClock _clock;

    private DateTime _time;

    private void Awake()
    {
        _bootrap.BootCompleted += OnBootCompleted;
    }

    private void OnDestroy()
    {
        _bootrap.BootCompleted -= OnBootCompleted;        
    }

    private void OnBootCompleted(string result)
    {
        RequestResult data = JsonConvert.DeserializeObject<RequestResult>(result);
        _time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(data.Time);
        _time = _time.ToLocalTime();
        _textClock.Init(_time);
        _clock.Init(_time);
    }
}
