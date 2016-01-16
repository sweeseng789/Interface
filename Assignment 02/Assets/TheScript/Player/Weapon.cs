using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotSpawn;
    public VirtualJoystick joystick;

    float firerate = 0.5f;
    float currentTiming = 0.0f;

    // Use this for initialization
    void Start ()
    {
        joystick = GameObject.Find("Joystick Background - Shooting").GetComponent<VirtualJoystick>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(currentTiming < firerate)
        {
            currentTiming += Time.deltaTime;
        }
        else
        {
            if (Time.timeScale != 0)
            {
                float inputX = joystick.Horizontal();
                float inputY = joystick.Vertical();

                float tempX = inputX, tempY = inputY;

                if (tempX < 0)
                    tempX = -tempX;
                if (tempY < 0)
                    tempY = -tempY;

                if (tempX > 0.5 || tempY > 0.5)
                {
                    Vector2 newVel = getVel(inputX, inputY);
                    GameObject newBullet = Instantiate(bullet) as GameObject;
                    newBullet.transform.position = shotSpawn.position;
                    Rigidbody2D rb2d = newBullet.GetComponent<Rigidbody2D>();
                    rb2d.velocity = newVel * 200;
                    currentTiming = 0.0f;
                }
            }
        }
    }

    Vector2 getVel(float inputX, float inputY)
    {
        Vector2 newVel = new Vector2();

        if (inputX > 0.5)
        {
            newVel.x = 1;
        }
        else if (inputX < -0.5)
        {
            newVel.x = -1;
        }
        else
        {
            newVel.x = 0;
        }

        if (inputY > 0.5)
        {
            newVel.y = 1;
        }
        else if (inputY < -0.5)
        {
            newVel.y = -1;
        }
        else
        {
            newVel.y = 0;
        }

        return newVel;
    }
}
