using TMPro;
using UnityEngine;

public class ArrowToTextHoursConverter : MonoBehaviour
{
    private const int Circle = 360;
    private const int Divisor = 30;
    private const int FirstCircle = 11;
    private const int SecondCircle = 23;

    [SerializeField] private Transform _arrow;
    [SerializeField] private TextMeshProUGUI _text;

    private int _previoutValue;
    private int _additiveValue;

    private void Update()
    {
        int rotation = (int)Mathf.Abs(Circle - _arrow.rotation.eulerAngles.z) / Divisor;
        int result;

        if (_previoutValue == FirstCircle && rotation == 0)        
            _additiveValue = Circle / Divisor;        
        else if(_previoutValue == SecondCircle && rotation == 0)        
            _additiveValue = 0;        
        else if(_previoutValue == (Circle / Divisor) &&  rotation == FirstCircle)        
            _additiveValue = 0;        
        else if(_previoutValue == 0 && rotation == FirstCircle)        
            _additiveValue = Circle / Divisor;

        result = rotation + _additiveValue;
        _text.text = result.ToString("0.");
        _previoutValue = result;
    }
}
