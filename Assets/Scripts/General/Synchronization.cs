using System;
using System.Collections;
using UnityEngine;

public class Synchronization : MonoBehaviour, ITimeStopper, IDataReceiver
{
    [SerializeField] private float _frequency;

    private WebRequestSender _sender = new WebRequestSender();
    private Coroutine _coroutine;

    public event Action<string> DataReceived;

    public void Pause() => StopCoroutine(_coroutine);

    public void UnPause() => _coroutine = StartCoroutine(CreateSynchonizationSchedule());

    private void Start()
    {
        _coroutine = StartCoroutine(CreateSynchonizationSchedule());
    }

    private IEnumerator CreateSynchonizationSchedule()
    {
        WaitForSeconds delay = new WaitForSeconds(_frequency);
        bool isWorking = true;

        while (isWorking)
        {
            yield return delay;
            yield return _sender.SendWebRequest(DataReceived);
        }
    }
}