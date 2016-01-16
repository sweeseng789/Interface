using UnityEngine;
using System.Collections;

public class WeaponWheel : MonoBehaviour
{
    public VirtualJoystick joystick;
    public Texture2D defaultWeapon;
    public Texture2D[] texture = new Texture2D[7]; //Current, Blank, Top, Right, Bottom, Left, Black Alpha background
    public Texture2D[] weapons = new Texture2D[4]; //Pistol, Sniper, SMG, Melee

    private bool viewingWeaponWheel = false;


	// Update is called once per frame
	void Update ()
    {
    }

    void OnGUI()
    {
        //Comment to debug
        GUI.backgroundColor = Color.clear;
        GUI.depth = -100;

        if (!joystick.usingJoystick)
        {
            if (new Rect(Screen.width - 300, Screen.height - 295, 200, 70).Contains(Event.current.mousePosition))
            {
                viewingWeaponWheel = true;
            }

            if(viewingWeaponWheel)
            {
                //Render Alpha Background
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture[6]);

                //Render weapon wheel in middle of screen
                RenderWeaponWheel_Screen();

                //Render Buttons on shoot joystick
                RenderWeaponWheel_Joystick();
            }
            else
            {
                GUI.DrawTexture(new Rect(Screen.width - 330, Screen.height - 295, 256, 256), defaultWeapon);
            }
        }
    }

    void RenderWeaponWheel_Joystick()
    {
        GUI.DrawTexture(new Rect(Screen.width - 330, Screen.height - 295, 256, 256), texture[0]);

        if (new Rect(Screen.width - 300, Screen.height - 295, 200, 70).Contains(Event.current.mousePosition))//Top
        {
            texture[0] = texture[2];
        }
        else if (new Rect(Screen.width - 290, Screen.height - 110, 180, 70).Contains(Event.current.mousePosition)) //Bottom
        {
            texture[0] = texture[4];
        }
        else if (new Rect(Screen.width - 330, Screen.height - 260, 70, 180).Contains(Event.current.mousePosition)) //Left
        {
            texture[0] = texture[5];
        }
        else if (new Rect(Screen.width - 140, Screen.height - 260, 70, 180).Contains(Event.current.mousePosition)) //Right
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
        GUI.BeginGroup(new Rect(Screen.width / 2 - 256, Screen.height / 2 - 256, 512, 512), texture[0]);

        //Top
        GUI.DrawTexture(new Rect(180, 10, 150, 100), weapons[0]);

        //Bottom
        GUI.DrawTexture(new Rect(150, 425, weapons[3].width - 30, weapons[3].height + 10), weapons[3]);

        //Left
        GUI.DrawTexture(new Rect(40, 130, weapons[1].width - 50, weapons[1].height - 250), weapons[1]);

        //Right
        GUI.DrawTexture(new Rect(400, 130, weapons[2].width - 20, weapons[2].height - 20), weapons[2]);

        GUI.EndGroup();
    }
}
