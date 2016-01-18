using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    public bool pauseGame;

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
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void pauseUpdate()
    {
        if (pauseGame)
            pauseGame = false;
        else
            pauseGame = true;
    }
}
