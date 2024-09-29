using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldHandler : MonoBehaviour
{
    [SerializeField] private int _maximum = 59;

    private TMP_InputField _inputField;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    private void Start()
    {
        _inputField.onValueChanged.AddListener(CheckInput);
    }

    private void OnDestroy()
    {
        _inputField.onValueChanged.RemoveListener(CheckInput);
    }

    private void CheckInput(string inputData)
    {
        if(inputData == null)
            throw new ArgumentNullException(nameof(inputData));

        if(Int32.TryParse(inputData, out int value) == false)
            throw new ArgumentException(nameof(inputData));

        value = Mathf.Clamp(value, 0, _maximum);
        _inputField.text = value.ToString();
    }
}
