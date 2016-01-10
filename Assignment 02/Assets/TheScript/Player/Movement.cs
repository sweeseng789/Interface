using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator player;
    int lastKey;
    float movementSpeed;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Animator>();
        lastKey = (int)(KeyCode.DownArrow);
        movementSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = 2.0f * Time.deltaTime;

        //Check whether the user is pressing any key
        if (Input.anyKey)
        {
            //Up Animation
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
                {
                    player.Play("Dean_Up");
                }
                transform.Translate(new Vector3(0, movementSpeed, 0));
                lastKey = (int)KeyCode.UpArrow;
            }
            //Down Animation
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
                {
                    player.Play("Dean_Down");
                }
                transform.Translate(new Vector3(0, -movementSpeed, 0));
                lastKey = (int)KeyCode.DownArrow;
            }

            //Left Animation
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player.Play("Dean_Left");
                transform.Translate(new Vector3(-movementSpeed, 0, 0));
                lastKey = (int)KeyCode.LeftArrow;
            }

            //Right Animation
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                player.Play("Dean_Right");
                transform.Translate(new Vector3(movementSpeed, 0, 0));
                lastKey = (int)KeyCode.RightArrow;
            }
        }
        else
        {
            if (lastKey == (int)KeyCode.UpArrow)
            {
                player.Play("Idle_Up");
            }
            else if (lastKey == (int)KeyCode.DownArrow)
            {
                player.Play("Idle_Down");
            }
            else if (lastKey == (int)KeyCode.LeftArrow)
            {
                player.Play("Idle_Left");
            }
            else
            {
                player.Play("Idle_Right");
            }
        }
    }
}
