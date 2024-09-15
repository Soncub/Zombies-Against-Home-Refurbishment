using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class FloatingJoystick : MonoBehaviour
{

    public RectTransform RectTransform;
    public RectTransform Knob;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}