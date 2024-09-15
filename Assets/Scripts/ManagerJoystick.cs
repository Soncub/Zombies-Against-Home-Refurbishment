using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerJoystick : MonoBehaviour, IDragHandler
{
    private Image imgJoystickBg;
    private Image imgJoystick;
    private Vector2 posInput;
    void Start()
    {
        imgJoystickBg = GetComponent<Image>();
        imgJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
           imgJoystickBg.rectTransform,
           eventData.position,
           eventData.pressEventCamera,
           out posInput))
        {
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());
        }
    }
}
