using UnityEngine;
using System.Collections;

public class PauseUpdate : MonoBehaviour
{
    public bool pauseGame;
    public Texture2D PauseText;
    public Texture2D background;
    public Texture2D[] Resume = new Texture2D[3];
    public Texture2D[] Settings = new Texture2D[3];
    public Texture2D[] Quit = new Texture2D[3];

    // Use this for initialization
    void Start ()
    {
        pauseGame = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pauseGame)
        {
            Time.timeScale = 0;

            foreach(var touch in Input.touches)
            {
                Vector2 touchPos = touch.position;
                touchPos.y = Screen.height - touch.position.y;

                if(new Rect(Screen.width / 2 - Resume[0].width - 150, 300, 768, 300).Contains(touchPos))
                {
                    pauseGame = false;
                }
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void pauseUpdate()
    {
        if (pauseGame)
        {
            pauseGame = false;
        }
        else
        {
            pauseGame = true;
        }
    }

    void OnGUI()
    {
        if(pauseGame)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

            GUI.DrawTexture(new Rect(Screen.width / 2 - PauseText.width, 0, 512, 200), PauseText);

            GUI.DrawTexture(new Rect(Screen.width / 2 - Resume[0].width - 150, 300, 768, 300), Resume[0]);

            GUI.DrawTexture(new Rect(Screen.width / 2 - Resume[0].width - 150, 700, 768, 300), Settings[0]);

            GUI.DrawTexture(new Rect(Screen.width / 2 - Resume[0].width - 150, 1100, 768, 300), Quit[0]);
        }
    }
}
