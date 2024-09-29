using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SelectionEffect : MonoBehaviour
{
    private const string IsSelectedParameter = "_IsSelected";

    private Material _material;

    private void Start()
    {
        _material = GetComponent<Image>().material;
    }

    public void Play()
    {
        _material.SetInt(IsSelectedParameter, 1);
    }

    public void Stop()
    {
        _material.SetInt(IsSelectedParameter, 0);
    }
}
