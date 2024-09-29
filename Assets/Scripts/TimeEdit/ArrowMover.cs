using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowMover : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform _hourArrow;

    private RectTransform _arrow;
    private Vector3 _position;

    public void OnDrag(PointerEventData eventData)
    {
        float startRotation = _arrow.rotation.eulerAngles.z;
        startRotation = startRotation <= 180 ? startRotation : (startRotation - 360);
        Vector3 position = new Vector3(eventData.position.x, eventData.position.y, 0) - _position;
        float angle = Mathf.Atan(position.x / position.y) * Mathf.Rad2Deg;

        if (position.y >= 0)
        {            
            _arrow.rotation *= Quaternion.Euler(0, 0, (-angle - startRotation));
            _hourArrow.rotation *= Quaternion.Euler(0, 0, (-angle - startRotation) / 12);            
        }
        else if (position.y < 0 && position.x < 0)
        {
            startRotation = startRotation < 0 ? startRotation + 360 : startRotation;
            float delta = 180 - angle - startRotation;
            _arrow.rotation *= Quaternion.Euler(0, 0, delta);
            _hourArrow.rotation *= Quaternion.Euler(0, 0, (delta) / 12);
        }
        else
        {
            startRotation = startRotation > 0 ? startRotation - 360 : startRotation;
            float delta = (-180 - angle - startRotation);
            _arrow.rotation *= Quaternion.Euler(0, 0, delta);
            _hourArrow.rotation *= Quaternion.Euler(0, 0, (delta) / 12);
        }
    }

    private void Start()
    {
        _arrow = GetComponent<RectTransform>();
        _position = _arrow.position;
        enabled = false;
    }
}
