using UnityEngine;
using System.Collections;

public class WeaponWheel : MonoBehaviour
{
    public VirtualJoystick joystick;
    //public GameObject[] weaponWheelObj = new GameObject[4];
    public Texture2D[] textures = new Texture2D[6];
    //Default
    //Top
    //Bottom
    //Left
    //Right

    public Texture2D[] weaponIcons = new Texture2D[4];

    public Texture2D defaultIcon;

    public Pause pause;

    bool viewingWeaponWheel = false;

    int lastChoice;

    int touchID = -1;

    void OnGUI()
    {
        // if!Pause.pauseEnabled)

        if (!joystick.usingJoystick)
        {
            if (viewingWeaponWheel)
            {
                RenderWeaponWheel_Screen();
            }
            else
            {
                RenderWeaponWheel_Icon();
            }
        }
    }

    void RenderWeaponWheel_Icon()
    {
        //GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), defaultIcon);

        //if (new Rect(Screen.width - 490, Screen.height - 630, 250, 110).Contains(mousePos))
        //{
        //    viewingWeaponWheel = true;
        //    pause.clickedWeaponWheel(true);
        //}
        if (touchID == -1)
        {
            GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), defaultIcon);

            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    //if (new Rect(Screen.width - 490, Screen.height - 630, 250, 110).Contains(touch.position))
                    //{

                    //    viewingWeaponWheel = true;
                    //    pause.clickedWeaponWheel(true);
                    //    touchID = touch.fingerId;
                    //}
                    if (touch.phase == TouchPhase.Began)
                    {
                        Vector2 touchPos = touch.position;
                        touchPos.y = Screen.height - touch.position.y;

                        if (new Rect(Screen.width - 490, Screen.height - 630, 250, 110).Contains(touchPos))
                        {
                            viewingWeaponWheel = true;
                            pause.clickedWeaponWheel(true);
                            touchID = touch.fingerId;
                        }
                    }
                }
            }
        }
    }

    void RenderWeaponWheel_Screen()
    {
        if(touchID != -1)
        {
            Touch touch = Input.GetTouch(touchID);
            Vector2 fingerPos = touch.position;
            fingerPos.y = Screen.height - touch.position.y;

            if(touch.phase != TouchPhase.Ended)
            {
                Texture2D textureToShow = textures[0];
                GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[0]);

                if (new Rect(Screen.width - 485, Screen.height - 630, 240, 180).Contains(fingerPos))
                {
                    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[1]);
                    textureToShow = textures[1];
                    lastChoice = 1;
                }
                else if (new Rect(Screen.width - 485, Screen.height - 460, 240, 180).Contains(fingerPos))
                {
                    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[2]);
                    textureToShow = textures[2];
                    lastChoice = 2;
                }
                else if (new Rect(Screen.width - 545, Screen.height - 580, 180, 250).Contains(fingerPos))
                {
                    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[3]);
                    textureToShow = textures[3];
                    lastChoice = 3;
                }
                else if (new Rect(Screen.width - 370, Screen.height - 580, 180, 250).Contains(fingerPos))
                {
                    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[4]);
                    textureToShow = textures[4];
                    lastChoice = 4;
                }


                GUI.BeginGroup(new Rect(Screen.width / 2 - 512, Screen.height / 2 - 512, 1024, 1024), textureToShow);

                //Top
                GUI.DrawTexture(new Rect(300, 10, weaponIcons[0].width * 3, weaponIcons[0].height * 3), weaponIcons[0]);

                //bottom
                GUI.DrawTexture(new Rect(280, 900, weaponIcons[3].width * 2, weaponIcons[3].height * 2), weaponIcons[3]);

                //Left
                GUI.DrawTexture(new Rect(100, 250, weaponIcons[1].width, weaponIcons[1].height), weaponIcons[1]);

                //Right
                GUI.DrawTexture(new Rect(830, 300, weaponIcons[2].width * 1.5f, weaponIcons[2].height * 1.5f), weaponIcons[2]);

                GUI.EndGroup();
            }
            else
            {
                if (lastChoice == 1)
                {
                    Debug.Log("Pistol");
                    Weapon.setToPistol();
                }
                else if (lastChoice == 2)
                {
                    Debug.Log("Melee");
                    Weapon.setToMelee();
                }
                else if (lastChoice == 3)
                {
                    Debug.Log("Sniper");
                    Weapon.setToSniper();
                }
                else
                {
                    Debug.Log("SMG");
                    Weapon.setToSMG();
                }

                pause.clickedWeaponWheel(false);

                viewingWeaponWheel = false;

                touchID = -1;
            }
        }
        //Vector2 mousePos = Input.mousePosition;
        //mousePos.y = Screen.height - Input.mousePosition.y;

        //Texture2D textureToShow = textures[0];

        //GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[0]);

        //if (new Rect(Screen.width - 485, Screen.height - 630, 240, 180).Contains(mousePos))
        //{
        //    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[1]);
        //    textureToShow = textures[1];
        //    lastChoice = 1;
        //}
        //else if (new Rect(Screen.width - 485, Screen.height - 460, 240, 180).Contains(mousePos))
        //{
        //    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[2]);
        //    textureToShow = textures[2];
        //    lastChoice = 2;
        //}
        //else if (new Rect(Screen.width - 545, Screen.height - 580, 180, 250).Contains(mousePos))
        //{
        //    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[3]);
        //    textureToShow = textures[3];
        //    lastChoice = 3;
        //}
        //else if (new Rect(Screen.width - 370, Screen.height - 580, 180, 250).Contains(mousePos))
        //{
        //    GUI.DrawTexture(new Rect(Screen.width - 540, Screen.height - 630, 350, 350), textures[4]);
        //    textureToShow = textures[4];
        //    lastChoice = 4;
        //}
        //else
        //{

        //    if (lastChoice == 1)
        //    {
        //        Debug.Log("Pistol");
        //        Weapon.setToPistol();
        //    }
        //    else if (lastChoice == 2)
        //    {
        //        Debug.Log("Melee");
        //        Weapon.setToMelee();
        //    }
        //    else if (lastChoice == 3)
        //    {
        //        Debug.Log("Sniper");
        //        Weapon.setToSniper();
        //    }
        //    else
        //    {
        //        Debug.Log("SMG");
        //        Weapon.setToSMG();
        //    }

        //    pause.clickedWeaponWheel(false);

        //    viewingWeaponWheel = false;
        //}
    }
}