using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassicClock : MonoBehaviour
{
    private const int SecondsInMinute = 60;
    private const int MinutesInHour = 60;
    private const int HoursInDay = 24;
    private const int Circle = 360;
    private const int HoursClockSize = 12;

    [SerializeField] private Transform _secondsView;
    [SerializeField] private Transform _minutesView;
    [SerializeField] private Transform _hoursView;

    private bool _isWorking;

    private void Update()
    {
        if (_isWorking == false)
            return;
    }

    public void Init(DateTime time)
    {
        _isWorking = true;
        int multiplier = Circle / SecondsInMinute;
        float angle = -multiplier * time.Second;
        _secondsView.rotation = Quaternion.Euler(0, 0, angle);

        multiplier = Circle / MinutesInHour;
        angle = -multiplier * (time.Minute + ((float)time.Second / SecondsInMinute));
        _minutesView.rotation = Quaternion.Euler(0, 0, angle);

        multiplier = Circle / HoursClockSize;
        angle = -multiplier * ((time.Hour % HoursClockSize) +((float)time.Minute / MinutesInHour));
        _hoursView.rotation = Quaternion.Euler(0, 0, angle);
    }
}
