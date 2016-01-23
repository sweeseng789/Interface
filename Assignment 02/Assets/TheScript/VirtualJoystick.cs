using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image background;
    private Image JoystickImage;
    private Vector3 inputVector;
    public bool usingJoystick { get; set; }

    private void Start()
    {
        background = GetComponent<Image>();
        JoystickImage = transform.GetChild(0).GetComponent<Image>();
    }


    public virtual void OnDrag(PointerEventData data)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform, data.position, data.pressEventCamera, out pos))
        {
            pos.x = (pos.x / background.rectTransform.sizeDelta.x);
            pos.y = (pos.y / background.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //Move Joystick Image
            JoystickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (background.rectTransform.sizeDelta.x / 3), inputVector.z * (background.rectTransform.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData data)
    {
        usingJoystick = true;
        OnDrag(data);
    }

    public virtual void OnPointerUp(PointerEventData data)
    {
        usingJoystick = false;
        inputVector = Vector3.zero;
        JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            return inputVector.x;
        }

        return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.z != 0)
        {
            return inputVector.z;
        }

        return Input.GetAxis("Vertical");
    }
}
