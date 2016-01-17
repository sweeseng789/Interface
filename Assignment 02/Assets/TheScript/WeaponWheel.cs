using UnityEngine;
using System.Collections;

public class WeaponWheel : MonoBehaviour
{
    public VirtualJoystick joystick;
    public Texture2D defaultWeapon;
    public Texture2D[] texture = new Texture2D[7]; //Current, Blank, Top, Right, Bottom, Left, Black Alpha background
    public Texture2D[] weapons = new Texture2D[4]; //Pistol, Sniper, SMG, Melee

    public bool viewingWeaponWheel = false;


	// Update is called once per frame
	void Update ()
    {
    }

    void OnGUI()
    {
        //Comment to debug
        //GUI.backgroundColor = Color.clear;

        if (!joystick.usingJoystick)
        {
            if (Input.touchCount > 0)
            {
                for (int a = 0; a < Input.touchCount; ++a)
                {

                    Touch touch = Input.GetTouch(a);
                    Vector3 TouchPos = touch.position;

                    TouchPos.y = Screen.height - touch.position.y;

                    if(new Rect(Screen.width - 640, Screen.height - 790, 530, 230).Contains(TouchPos))
                    {
                        viewingWeaponWheel = true;   
                    }

                    if(viewingWeaponWheel)
                    {
                        Time.timeScale = 0;

                        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture[6]);

                        RenderWeaponWheel_Screen();

                        RenderWeaponWheel_Joystick(TouchPos);
                    }
                    else
                    {
                        GUI.DrawTexture(new Rect(Screen.width - 760, Screen.height - 785, 768, 768), defaultWeapon);
                    }
                }
            }
            else
            {
                GUI.DrawTexture(new Rect(Screen.width - 760, Screen.height - 785, 768, 768), defaultWeapon);
            }
        }
    }

    void RenderWeaponWheel_Joystick(Vector3 TouchPos)
    {
        GUI.DrawTexture(new Rect(Screen.width - 760, Screen.height - 785, 768, 768), texture[0]);

        if (new Rect(Screen.width - 640, Screen.height - 790, 530, 230).Contains(TouchPos)) //Top
        {
            texture[0] = texture[2];
        }
        else if (new Rect(Screen.width - 640, Screen.height - 240, 530, 230).Contains(TouchPos)) //Bottom
        {
            texture[0] = texture[4];
        }
        else if (new Rect(Screen.width - 770, Screen.height - 670, 230, 535).Contains(TouchPos)) //Left
        {
            texture[0] = texture[5];
        }
        else if (new Rect(Screen.width - 210, Screen.height - 665, 230, 535).Contains(TouchPos)) //Right
        {
            texture[0] = texture[3];
        }
        else
        {
            texture[0] = texture[1];
            viewingWeaponWheel = false;
        }
    }

    void RenderWeaponWheel_Screen()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 512, Screen.height / 2 - 512, 1024, 1024), texture[0]);

        //Top
        GUI.DrawTexture(new Rect(300, 10, weapons[0].width * 3, weapons[0].height * 3), weapons[0]);

        //bottom
        GUI.DrawTexture(new Rect(280, 900, weapons[3].width * 2, weapons[3].height * 2), weapons[3]);

        //Left
        GUI.DrawTexture(new Rect(100, 250, weapons[1].width, weapons[1].height), weapons[1]);

        //Right
        GUI.DrawTexture(new Rect(830, 300, weapons[2].width * 1.5f, weapons[2].height * 1.5f), weapons[2]);

        GUI.EndGroup();
    }
}
