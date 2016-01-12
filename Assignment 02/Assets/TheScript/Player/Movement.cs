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
    float movementSpeed;
    public VirtualJoystick joystick;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Animator>();
        movementSpeed = 0.0f;
        joystick = GameObject.Find("Joystick Background").GetComponent<VirtualJoystick>();
        lastMove = LASTMOVE.e_DOWN;
    }

    // Update is called once per frame
    void Update()
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
                    player.Play("Dean_Up");
                    transform.Translate(new Vector3(0, movementSpeed, 0));
                    lastMove = LASTMOVE.e_UP;
                }
                //Down Animation
                else if (inputY < -0.5 && inputY >= -1)
                {
                    player.Play("Dean_Down");
                    transform.Translate(new Vector3(0, -movementSpeed, 0));
                    lastMove = LASTMOVE.e_DOWN;
                }
            }
            else if (inputX <= -0.5 && inputX >= -1)
            {
                //Left Animation
                if(inputY < 0.5 && inputY >= -0.5)
                {
                    player.Play("Dean_Left");
                    transform.Translate(new Vector3(-movementSpeed, 0, 0));
                    lastMove = LASTMOVE.e_LEFT;
                }
            }
            else
            {
                //Right Animation
                if (inputY < 0.5 & inputY >= -0.5)
                {
                    player.Play("Dean_Right");
                    transform.Translate(new Vector3(movementSpeed, 0, 0));
                    lastMove = LASTMOVE.e_RIGHT;
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
