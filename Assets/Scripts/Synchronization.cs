using System;
using System.Collections;
using UnityEngine;

public class Synchronization : MonoBehaviour
{
    [SerializeField] private float _frequency;

    private WebRequestSender _sender = new WebRequestSender();

    public event Action<string> DataSynchronized;

    private void Start()
    {
        StartCoroutine(CreateSynchonizationSchedule());
    }

    private IEnumerator CreateSynchonizationSchedule()
    {
        WaitForSeconds delay = new WaitForSeconds(_frequency);
        bool isWorking = true;

        while (isWorking)
        {
            yield return delay;
            _sender.SendWebRequest(DataSynchronized);
        }
    }
}