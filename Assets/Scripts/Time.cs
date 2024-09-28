public class Time
{
    private int _seconds;
    private int _minutes;
    private int _hours;

    public Time(int seconds, int minutes, int hours)
    {
        _seconds = seconds;
        _minutes = minutes;
        _hours = hours;
    }

    public int Seconds => _seconds;

    public int Minutes => _minutes;

    public int Hours => _hours;
}

