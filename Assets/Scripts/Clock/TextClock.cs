﻿using System;
using TMPro;
using UnityEngine;

public class TextClock : MonoBehaviour, ITimeStopper
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

    public void Pause() => _isWorking = false;

    public void UnPause() => _isWorking = true;

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

        _secondsView.text = _seconds.ToString("00.");
        _minutesView.text = _minutes.ToString("00.");
        _hoursView.text = _hours.ToString("00.");
    }

    public void Init(DateTime time)
    {
        _seconds = time.Second;
        _minutes = time.Minute;
        _hours = time.Hour;
        _isWorking = true;
    }

    public bool TryGetTime(out DateTime time)
    {
        time = DateTime.MinValue;
        int hours, minutes, seconds;

        if (Int32.TryParse(_hoursView.text, out hours) == false)
            return false;

        if (Int32.TryParse(_minutesView.text, out minutes) == false)
            return false;

        if (Int32.TryParse(_secondsView.text, out seconds) == false)
            return false;

        time = new DateTime(1970, 1, 1, hours, minutes, seconds);
        return true;
    }
}
