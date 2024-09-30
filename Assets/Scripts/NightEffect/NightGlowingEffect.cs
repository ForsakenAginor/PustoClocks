using UnityEngine;
using UnityEngine.UI;

public class NightGlowingEffect : MonoBehaviour
{
    private const string GlowingParameter = "_IsGlowing";

    [SerializeField] private Image _clock;
    [SerializeField] private Image _hour;
    [SerializeField] private Image _minute;
    [SerializeField] private Image _second;

    [SerializeField] private Toggle _switcher;

    private Material _clockMaterial;
    private Material _hourMaterial;
    private Material _minuteMaterial;
    private Material _secondMaterial;

    private bool _startedValue;

    private void Start()
    {
        _startedValue = _switcher.isOn;
        _clockMaterial = _clock.material;
        _hourMaterial = _hour.material;
        _minuteMaterial = _minute.material;
        _secondMaterial = _second.material;
        _switcher.onValueChanged.AddListener(OnSwitcherClicked);
    }

    private void OnDisable()
    {
        OnSwitcherClicked(_startedValue);
        _switcher.onValueChanged.RemoveListener(OnSwitcherClicked);        
    }

    private void OnSwitcherClicked(bool value)
    {
        if (value)
        {
            _clockMaterial.SetInt(GlowingParameter, 0);
            _hourMaterial.SetInt(GlowingParameter, 0);
            _minuteMaterial.SetInt(GlowingParameter, 0);
            _secondMaterial.SetInt(GlowingParameter, 0);
        }
        else
        {
            _clockMaterial.SetInt(GlowingParameter, 1);
            _hourMaterial.SetInt(GlowingParameter, 1);
            _minuteMaterial.SetInt(GlowingParameter, 1);
            _secondMaterial.SetInt(GlowingParameter, 1);
        }
    }
}
