using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum LASTMOVE
{
    s_UP,
    s_DOWN,
    s_LEFT,
    s_RIGHT
}

public class Player : MonoBehaviour
{
    public VirtualJoystick movementJoystick;
    public VirtualJoystick shootingJoystick;
    public GameObject bulletPrefab;
    public SpriteRenderer crosshair;
    public Text healthText;
    public Text scoreText;

    Animator anim;
    LASTMOVE lastmove = LASTMOVE.s_DOWN;
    Rigidbody2D rb2d;

    float velocity = 0.5f;
    float currentTiming = 0.0f;
    float shootingRate = 0.5f;
    bool pushedBack = false;

    //Health
    int playerHealth = 100;

    //Score
    public static int score = 0;

    void Start()
    {
        //Instance the first object to prevent error - Bug
        GameObject test = Instantiate(bulletPrefab) as GameObject;
        test.transform.position = transform.position;

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        crosshair.transform.position = new Vector2(0, -15);
    }

    void Update()
    {
        scoreText.text = "";
        int diff = 10 - score.ToString().Length;
        for(int a = 0; a < diff; ++a)
        {
            scoreText.text += "0";
        }
        scoreText.text += score.ToString();

        if (!Pause.pauseEnabled)
        {
            //Update Movement
            if (movementJoystick.Horizontal() != 0 && movementJoystick.Vertical() != 0)
            {
                movementUpdate();
            }
            else
            {
                AnimationIdleUpdate();
            }

            //Update Velocity
            velocityUpdate();

            //Update Health
            UpdateHealth();

            //Update Shooting
            if (shootingJoystick.Horizontal() != 0 && shootingJoystick.Vertical() != 0)
            {
                //GameObject newBullet = Instantiate(bulletPrefab) as GameObject;
                if (currentTiming < shootingRate)
                {
                    currentTiming += Time.deltaTime;
                }
                else
                {
                    Weapon.ammoCount -= 1;
                    shootingUpdate();
                    currentTiming = 0.0f;
                }
            }
        }
    }


    //======== ANIAMTION UPDATE FUNCTIONS ========//
    void AnimationIdleUpdate()
    {
        switch (lastmove)
        {
            case (LASTMOVE.s_UP):
                anim.Play("Idle_Up");
                break;

            case (LASTMOVE.s_DOWN):
                anim.Play("Idle_Down");
                break;

            case (LASTMOVE.s_LEFT):
                anim.Play("Idle_Left");
                break;

            case (LASTMOVE.s_RIGHT):
                anim.Play("Idle_Right");
                break;

            default:
                break;
        }
    }
    void movementUpdate()
    {
        Vector2 currentDir = new Vector2(0 - movementJoystick.Horizontal(), 0 - movementJoystick.Vertical());
        currentDir.Normalize();

        Vector2 temp = currentDir;
        if (temp.x < 0)
            temp.x = -temp.x;
        if (temp.y < 0)
            temp.y = -temp.y;

        if (!pushedBack)
        {
            if (temp.x >= temp.y)
            {
                //Left
                if (currentDir.x > 0)
                {
                    anim.Play("Dean_Left");
                    lastmove = LASTMOVE.s_LEFT;
                    rb2d.position = new Vector2(transform.position.x - velocity, transform.position.y);
                }
                else //Right
                {
                    anim.Play("Dean_Right");
                    lastmove = LASTMOVE.s_RIGHT;
                    rb2d.position = new Vector2(transform.position.x + velocity, transform.position.y);
                }
            }
            else
            {
                //Up
                if (currentDir.y < 0)
                {
                    anim.Play("Dean_Up");
                    lastmove = LASTMOVE.s_UP;
                    rb2d.position = new Vector2(transform.position.x, transform.position.y + velocity);
                }
                else//Down
                {
                    anim.Play("Dean_Down");
                    lastmove = LASTMOVE.s_DOWN;
                    rb2d.position = new Vector2(transform.position.x, transform.position.y - velocity);
                }
            }
        }
    }

    //======== WEAPON UPDATE FUNCTIONS ========//
    void shootingUpdate()
    {
        GameObject newBullet = Instantiate(bulletPrefab) as GameObject;
        newBullet.transform.position = gameObject.transform.position;

        Vector2 currentDir = new Vector2(shootingJoystick.Horizontal(), shootingJoystick.Vertical());
        currentDir.Normalize();
        newBullet.GetComponent<Rigidbody2D>().velocity = currentDir * 100;

        Vector3 crosshairOffset = gameObject.transform.position;
        crosshairOffset.x += currentDir.x * 15;
        crosshairOffset.y += currentDir.y * 15;
        crosshair.transform.position = new Vector3(crosshairOffset.x, crosshairOffset.y, crosshair.gameObject.transform.position.z);
    }

    //======== VELOCITY UPDATE FUNCTIONS ========//
    void velocityUpdate()
    {
        if (pushedBack)
        {
            rb2d.velocity *= 0.97f;
            if (rb2d.velocity.x > -1.5 && rb2d.velocity.x < 1.5 &&
                rb2d.velocity.y > -1.5 && rb2d.velocity.y < 1.5)
            {
                pushedBack = false;
                rb2d.velocity = new Vector2(0, 0);
            }
        }

    }

    //======== HEALTH UPDATE FUNCTIONS ========//
    void UpdateHealth()
    {
        healthText.text = playerHealth.ToString() + "%";
    }

    //======== COLLISION ========//
    void OnCollisionEnter2D(Collision2D col)
    {
        Physics2D.IgnoreLayerCollision(8, 9);

        switch(col.gameObject.layer)
        {
            case (11):
                {
                    Vector2 newVel = new Vector2();
                    if (lastmove == LASTMOVE.s_UP)
                        newVel.y = -50;
                    else if (lastmove == LASTMOVE.s_DOWN)
                        newVel.y = 50;
                    else if (lastmove == LASTMOVE.s_LEFT)
                        newVel.x = 50;
                    else
                        newVel.x = -50;

                    rb2d.velocity = newVel;
                    pushedBack = true;
                    playerHealth -= 100;
                }
                break;

            default:
                break;
        }
    }
}
