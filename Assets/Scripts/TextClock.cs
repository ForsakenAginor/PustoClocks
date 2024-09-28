using System;
using TMPro;
using UnityEngine;

public class TextClock : MonoBehaviour
{
    private const int SecondsInMinute = 60;
    private const int MinutesInHour = 60;
    private const int HoursInDay = 24;

    [SerializeField] private TextMeshProUGUI _secondsView;
    [SerializeField] private TextMeshProUGUI _minutesView;
    [SerializeField] private TextMeshProUGUI _hoursView;

    private bool _isWorking;
    private float _seconds;
    private float _minutes;
    private float _hours;

    private void Update()
    {
        if (_isWorking == false)
            return;

        _seconds += Time.deltaTime;

        if (_seconds >= SecondsInMinute)
        {
            _minutes++;
            _seconds %= SecondsInMinute;
        }

        if (_minutes >= MinutesInHour)
        {
            _hours++;
            _minutes %= MinutesInHour;
        }

        if (_hours >= HoursInDay)
            _hours %= HoursInDay;

        _secondsView.text = _seconds.ToString("0.");
        _minutesView.text = _minutes.ToString("0.");
        _hoursView.text = _hours.ToString("0.");
    }

    public void Init(DateTime time)
    {
        _seconds = time.Second;
        _minutes = time.Minute;
        _hours = time.Hour;
        _isWorking = true;
    }
}
