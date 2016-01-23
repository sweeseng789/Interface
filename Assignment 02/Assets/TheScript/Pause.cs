using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
    static public bool pauseEnabled = false;
    public GameObject alphaBackground;
    public GameObject pauseOptions;
    public GameObject[] Buttons = new GameObject[3];
    
    public void ClickedPaused()
    {
        pauseEnabled = !pauseEnabled;

        alphaBackground.SetActive(pauseEnabled);
        pauseOptions.SetActive(pauseEnabled);
        gameObject.SetActive(!pauseEnabled);
        for (int a = 0; a < Buttons.Length; ++a)
        {
            Buttons[a].SetActive(!pauseEnabled);
        }

        if (pauseEnabled)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void Start()
    {
        alphaBackground.SetActive(false);

        alphaBackground.transform.localScale = new Vector3(1, 1, alphaBackground.transform.localScale.z);

        //float width = alphaBackground.GetComponent<Texture2D>().width;
       // float height = alphaBackground.GetComponent<Texture2D>().height;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        alphaBackground.transform.localScale = new Vector3(worldScreenWidth / 1, worldScreenHeight / 1, 0);
    }

    public void clickedWeaponWheel(bool pauseGame)
    {
        pauseEnabled = pauseGame;

        alphaBackground.SetActive(pauseEnabled);

        for (int a = 0; a < Buttons.Length; ++a)
        {
            Buttons[a].SetActive(!pauseEnabled);
        }

        if (pauseEnabled)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }


    public bool getPauseEnabled()
    {
        return pauseEnabled;
    }
}
