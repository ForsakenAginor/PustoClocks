using DG.Tweening;
using System;
using UnityEngine;

public class ClassicClock : MonoBehaviour
{
    private const int SecondsInMinute = 60;
    private const int MinutesInHour = 60;
    private const int Circle = 360;
    private const int HoursClockSize = 12;

    [SerializeField] private Transform _secondsView;
    [SerializeField] private Transform _minutesView;
    [SerializeField] private Transform _hoursView;

    private Tween _secondsTween;
    private Tween _minutesTween;
    private Tween _hoursTween;

    public void Init(DateTime time)
    {
        _secondsTween.Kill();
        _minutesTween.Kill();
        _hoursTween.Kill();

        SetPositions(time);
        Launch();
    }

    private void SetPositions(DateTime time)
    {
        int multiplier = Circle / SecondsInMinute;
        float angle = -multiplier * time.Second;
        _secondsView.rotation = Quaternion.Euler(0, 0, angle);

        multiplier = Circle / MinutesInHour;
        angle = -multiplier * (time.Minute + ((float)time.Second / SecondsInMinute));
        _minutesView.rotation = Quaternion.Euler(0, 0, angle);

        multiplier = Circle / HoursClockSize;
        angle = -multiplier * ((time.Hour % HoursClockSize) + ((float)time.Minute / MinutesInHour));
        _hoursView.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Launch()
    {
        int infinitiveLoop = -1;
        Vector3 additiveValue = new Vector3(0, 0, -360);

        float duration = SecondsInMinute;
        _secondsTween = _secondsView.DORotate(_secondsView.rotation.eulerAngles + additiveValue,
                duration,
                RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(infinitiveLoop, LoopType.Incremental);

        duration *= MinutesInHour;
        _minutesTween = _minutesView.DORotate(_minutesView.rotation.eulerAngles + additiveValue,
                duration,
                RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(infinitiveLoop, LoopType.Incremental);

        duration *= HoursClockSize;
        _hoursTween = _hoursView.DORotate(_hoursView.rotation.eulerAngles + additiveValue,
                duration,
                RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(infinitiveLoop, LoopType.Incremental);
    }
}
