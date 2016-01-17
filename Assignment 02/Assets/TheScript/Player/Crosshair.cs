using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    public VirtualJoystick joystick;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float inputX = joystick.Horizontal();
        float inputY = joystick.Vertical();

        Vector2 temp = new Vector2(inputX, inputY);

        if (temp.x < 0)
            temp.x = -temp.x;

        if (temp.y < 0)
            temp.y = -temp.y;

        if(temp.x >= 0.5 || temp.y >= 0.5)
        {
            Vector2 newPos = transform.parent.position;
            float posOffset = 100f;

            if(inputX > 0.5)
            {
                newPos.x += posOffset;
            }
            else if(inputX < -0.5)
            {
                newPos.x -= posOffset;
            }

            if(inputY > 0.5)
            {
                newPos.y += posOffset;
            }
            else if(inputY < -0.5)
            {
                newPos.y -= posOffset;
            }

            transform.position = newPos;
        }
    }
}
