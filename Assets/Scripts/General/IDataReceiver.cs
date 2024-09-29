using System;

public interface IDataReceiver
{
    public event Action<string> DataReceived;
}
