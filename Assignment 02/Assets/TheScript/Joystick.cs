using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Joystick : MonoBehaviour
{
    public Text printout;
    public Image joyFG;
    public Image joyBG;

	// Use this for initialization
	void Start () {
        printout.text = "started";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Dragging()
    {
        printout.text = "dragging" + Input.mousePosition.x + ", " + Input.mousePosition.y;
        joyFG.rectTransform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
    }

    public void ReturnJoyFG()
    {
        joyFG.rectTransform.position = new Vector3(joyBG.rectTransform.position.x + 48, joyBG.rectTransform.position.y + 48, 1.0f);
    }
}
