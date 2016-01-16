using UnityEngine;

public class Movement : MonoBehaviour
{
    enum LASTMOVE
    {
        e_UP,
        e_DOWN,
        e_LEFT,
        e_RIGHT
    }


    Animator player;
    LASTMOVE lastMove;
    Rigidbody2D rb2d;
    float movementSpeed;
    public VirtualJoystick joystick;

    bool ableToMoveUp, ableToMoveDown, ableToMoveLeft, ableToMoveRight;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Animator>();
        movementSpeed = 0.0f;
        joystick = GameObject.Find("Joystick Background - Movement").GetComponent<VirtualJoystick>();
        lastMove = LASTMOVE.e_DOWN;
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        ableToMoveUp = ableToMoveDown = ableToMoveLeft = ableToMoveRight = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            float inputX = joystick.Horizontal();
            float inputY = joystick.Vertical();
            movementSpeed = 100.0f * Time.deltaTime;

            if (inputX != 0 && inputY != 0)
            {
                if (inputX > -0.5 && inputX <= 0.5)
                {
                    //Up Animation
                    if (inputY > 0.5 && inputY <= 1)
                    {
                        if (ableToMoveUp)
                        {
                            player.Play("Dean_Up");
                            rb2d.position = new Vector2(transform.position.x, transform.position.y + movementSpeed);
                            lastMove = LASTMOVE.e_UP;
                        }
                    }
                    //Down Animation
                    else if (inputY < -0.5 && inputY >= -1)
                    {
                        if (ableToMoveDown)
                        {
                            player.Play("Dean_Down");
                            rb2d.position = new Vector2(transform.position.x, transform.position.y - movementSpeed);
                            lastMove = LASTMOVE.e_DOWN;
                        }
                    }
                }
                else if (inputX <= -0.5 && inputX >= -1)
                {
                    //Left Animation
                    if (inputY < 0.5 && inputY >= -0.5)
                    {
                        if (ableToMoveLeft)
                        {
                            player.Play("Dean_Left");
                            transform.Translate(new Vector3(-movementSpeed, 0, 0));
                            lastMove = LASTMOVE.e_LEFT;
                        }
                    }
                }
                else
                {
                    //Right Animation
                    if (inputY < 0.5 & inputY >= -0.5)
                    {
                        if (ableToMoveRight)
                        {
                            player.Play("Dean_Right");
                            transform.Translate(new Vector3(movementSpeed, 0, 0));
                            lastMove = LASTMOVE.e_RIGHT;
                        }
                    }
                }
            }
            else
            {
                switch (lastMove)
                {
                    case (LASTMOVE.e_UP):
                        player.Play("Idle_Up");
                        break;

                    case (LASTMOVE.e_DOWN):
                        player.Play("Idle_Down");
                        break;

                    case (LASTMOVE.e_LEFT):
                        player.Play("Idle_Left");
                        break;

                    case (LASTMOVE.e_RIGHT):
                        player.Play("Idle_Right");
                        break;

                    default:
                        player.Play("Idle_Down");
                        break;

                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Physics2D.IgnoreLayerCollision(8, 10);

        Vector2 pos = new Vector2();
        pos.x = coll.transform.position.x - transform.position.x;
        pos.y = coll.transform.position.y - transform.position.y;
        pos.Normalize();

        Vector2 tempPos = pos;
        if (tempPos.x < 0)
        {
            tempPos.x = -tempPos.x;
        }
        if (tempPos.y < 0)
        {
            tempPos.y = -tempPos.y;
        }

        //Collision at X Axis
        if (tempPos.x > tempPos.y)
        {
            //Right
            if (pos.x < 0)
            {
                ableToMoveLeft = false;
            }
            //Left
            else
            {
                ableToMoveRight = false;
            }
        }
        //Collision at Y Axis
        else
        {
            //Bottom
            if (pos.y > 0)
            {
                ableToMoveUp = false;
            }
            //Top
            else
            {
                ableToMoveDown = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (!ableToMoveUp)
            ableToMoveUp = true;

        if (!ableToMoveDown)
            ableToMoveDown = true;

        if (!ableToMoveLeft)
            ableToMoveLeft = true;

        if (!ableToMoveRight)
            ableToMoveRight = true;
    }
}
