using System;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{
    [SerializeField] private BootsTrap _bootrap;
    [SerializeField] private Synchronization _synchronization;
    [SerializeField] private TextClock _textClock;
    [SerializeField] private ClassicClock _clock;

    [Header("TimeEditing")]
    [SerializeField] private Button _editButton;
    [SerializeField] private UIElement _timeEditLogic;
    [SerializeField] private ArrowMover _arrowMover;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Button _inputButton;
    [SerializeField] private Button _applyButton;
    [SerializeField] private SelectionEffect _selectionEffect;

    private DateTime _time;
    private bool _isWaitingInput;

    private void Awake()
    {
        _editButton.interactable = false;
        _timeEditLogic.Disable();
        _inputButton.interactable = false;
        _applyButton.interactable = false;

        _bootrap.DataReceived += OnDataReceived;
        _synchronization.DataReceived += OnDataReceived;
        _editButton.onClick.AddListener(OnEditButtonClick);
        _inputButton.onClick.AddListener(OnInputButtonClick);
        _applyButton.onClick.AddListener(OnApplyButtonClick);
    }

    private void OnDestroy()
    {
        _bootrap.DataReceived -= OnDataReceived;
        _synchronization.DataReceived -= OnDataReceived;
        _editButton.onClick.RemoveListener(OnEditButtonClick);
        _inputButton.onClick.RemoveListener(OnInputButtonClick);
        _applyButton.onClick.RemoveListener(OnApplyButtonClick);
    }

    private void OnApplyButtonClick()
    {
        if (_isWaitingInput)
        {
            if (_inputManager.TryGetTime(out _time))
            {
                _applyButton.interactable = false;
                _editButton.interactable = true;
                _inputButton.interactable = false;
                _isWaitingInput = false;
                _textClock.Init(_time);
                _clock.Init(_time);
                _synchronization.UnPause();
                _selectionEffect.Stop();
            }
        }
        else
        {
            if (_textClock.TryGetTime(out _time))
            {
                _applyButton.interactable = false;
                _editButton.interactable = true;
                _inputButton.interactable = false;
                _arrowMover.enabled = false;
                _timeEditLogic.Disable();
                _textClock.Init(_time);
                _clock.Init(_time);
                _synchronization.UnPause();
                _selectionEffect.Stop();
            }
        }
    }

    private void OnInputButtonClick()
    {
        _inputButton.interactable = false;
        _timeEditLogic.Disable();
        _arrowMover.enabled = false;
        _isWaitingInput = true;
        _selectionEffect.Stop();
    }

    private void OnEditButtonClick()
    {
        _editButton.interactable = false;
        _textClock.Pause();
        _clock.Pause();
        _synchronization.Pause();
        _timeEditLogic.Enable();
        _arrowMover.enabled = true;
        _inputButton.interactable = true;
        _applyButton.interactable = true;
        _selectionEffect.Play();
    }

    private void OnDataReceived(string result)
    {
        _editButton.interactable = true;
        RequestResult data = JsonConvert.DeserializeObject<RequestResult>(result);
        _time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(data.Time);
        _time = _time.ToLocalTime();
        _textClock.Init(_time);
        _clock.Init(_time);
    }
}