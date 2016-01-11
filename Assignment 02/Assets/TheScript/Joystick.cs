using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    //   public Text printout;
    //   public Image joyFG;
    //   public Image joyBG;

    //   private SSDLC DLC; //For common functions
    //   private bool joystickDrag;
    //   private Vector3 buttonPos;
    //   private Vector3 mousePos;
    //   private Vector3 topLeft;
    //   private Vector3 bottomRight;

    //// Use this for initialization
    //void Start ()
    //   {
    //       //printout.text = "started";
    //       joyFG = GameObject.Find("Joystick Button").GetComponent<Image>();
    //       joyBG = GameObject.Find("Joystick Background").GetComponent<Image>();
    //       printout = GameObject.Find("Text").GetComponent<Text>();
    //       DLC = GameObject.Find("SSDLC").GetComponent<SSDLC>();

    //       joystickDrag = false;
    //       buttonPos = new Vector3();
    //       mousePos = new Vector3();
    //       topLeft = new Vector3();
    //       bottomRight = new Vector3();
    //}

    //// Update is called once per frame
    //void Update ()
    //   {
    //       //buttonPos = Camera.main.WorldToViewportPoint(joyFG.transform.position);
    //       //mousePos = Camera.main.WorldToViewportPoint(Input.mousePosition);

    //       //Vector3 buttonScale = Camera.main.WorldToViewportPoint(joyFG.transform.localScale);

    //       //topLeft.x = buttonPos.x + buttonScale.x;
    //       //topLeft.y = buttonPos.y + buttonScale.y;

    //       //bottomRight.x = buttonPos.x - buttonScale.x;
    //       //bottomRight.y = buttonPos.y - buttonScale.y;
    //   }

    //   public void Dragging()
    //   {
    //       //printout.text = "dragging" + Input.mousePosition.x + ", " + Input.mousePosition.y;
    //      // joyFG.rectTransform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
    //       //if (DLC.intersect2D(topLeft, bottomRight, mousePos))
    //       //{
    //       //    Debug.Log("True");
    //       //}
    //       //else
    //       //{
    //       //    Debug.Log("False");
    //       //}
    //   }

    //   public void ReturnJoyFG()
    //   {
    //       joyFG.rectTransform.position = new Vector3(joyBG.rectTransform.position.x + 48, joyBG.rectTransform.position.y + 48, 1.0f);
    //   }
    private Image background;
    private Image JoystickImage;
    private Vector3 inputVector;

    private void Start()
    {
        JoystickImage = GameObject.Find("Joystick Button").GetComponent<Image>();
        background = GameObject.Find("Joystick Background").GetComponent<Image>();
        //printout = GameObject.Find("Text").GetComponent<Text>();
    }


    public virtual void OnDrag(PointerEventData data)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform, data.position, data.pressEventCamera, out pos))
        {
            pos.x = (pos.x / background.rectTransform.sizeDelta.x);
            pos.y = (pos.y / background.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 + 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //Move Joystick Image
            JoystickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (background.rectTransform.sizeDelta.x / 2), inputVector.z * (background.rectTransform.sizeDelta.y / 2));
        }

    }

    public virtual void OnPointerDown(PointerEventData data)
    {
        OnDrag(data);
    }

    public virtual void OnPointerUp(PointerEventData data)
    {

    }
}
