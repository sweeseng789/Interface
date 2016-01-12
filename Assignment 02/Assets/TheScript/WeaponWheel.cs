using UnityEngine;
using System.Collections;

public class WeaponWheel : MonoBehaviour
{
    public Texture2D[] texture = new Texture2D[7]; //Current, Blank, Top, Right, Bottom, Left, Black Alpha background
    public string[] weapons = new string[4];

	// Update is called once per frame
	void Update ()
    {
    }

    void OnGUI()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Comment to debug
            GUI.backgroundColor = Color.clear;

            //Render Alpha Background
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture[6]);

            GUI.BeginGroup(new Rect(Screen.width / 2 - 256, Screen.height / 2 - 256, 512, 512), texture[0]);

            RenderWeaponWheel();

            //Hover effect
            WeaponWheel_Hover();

            GUI.EndGroup();
        }
    }

    void RenderWeaponWheel()
    {

        if (GUI.Button(new Rect(83, 0, 346, 143), ""))
        {
            print("Top Weapon");
        }

        if (GUI.Button(new Rect(83, 366, 346, 143), ""))
        {
            print("Bottom Weapon");
        }

        if (GUI.Button(new Rect(368, 80, 143, 346), ""))
        {
            print("Right Weapon");
        }

        if (GUI.Button(new Rect(0, 80, 143, 346), ""))
        {
            print("Left Weapon");
        }
    }

    void WeaponWheel_Hover()
    {
        if (new Rect(83, 0, 346, 143).Contains(Event.current.mousePosition))
        {
            texture[0] = texture[2];
        }
        else if (new Rect(83, 366, 346, 143).Contains(Event.current.mousePosition))
        {
            texture[0] = texture[4];
        }
        else if (new Rect(368, 80, 143, 346).Contains(Event.current.mousePosition))
        {
            texture[0] = texture[3];
        }
        else if (new Rect(0, 80, 143, 346).Contains(Event.current.mousePosition))
        {
            texture[0] = texture[5];
        }
        else
        {
            texture[0] = texture[1];
        }
    }
}
