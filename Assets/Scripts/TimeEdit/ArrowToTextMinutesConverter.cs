using TMPro;
using UnityEngine;

public class ArrowToTextMinutesConverter : MonoBehaviour
{
    private const int Circle = 360;

    [SerializeField] private Transform _arrow;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _multiplier;

    private void Update()
    {
        int rotation = (int)Mathf.Abs(Circle - _arrow.rotation.eulerAngles.z) / _multiplier;
        _text.text = rotation.ToString("00.");
    }
}