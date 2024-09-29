using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _hours;
    [SerializeField] private TMP_InputField _minutes;
    [SerializeField] private TMP_InputField _seconds;
    [SerializeField] private Button _button;
    [SerializeField] private UIElement _inputPanel;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _inputPanel.Enable();
    }

    public bool TryGetTime(out DateTime time)
    {
        time = DateTime.MinValue;
        int hours, minutes, seconds;

        if(Int32.TryParse(_hours.text, out hours) == false)
            return false;

        if(Int32.TryParse(_minutes.text, out minutes) == false)
            return false;

        if (Int32.TryParse(_seconds.text, out seconds) == false)
            return false;

        time = new DateTime(1970, 1, 1, hours, minutes, seconds);
        _inputPanel.Disable();
        return true;
    }
}
