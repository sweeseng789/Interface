using UnityEngine;
using System.Collections;

public class Unrender : MonoBehaviour
{
    public PauseUpdate pauseButton;
    public GameObject[] thisObj = new GameObject[5];

    // Use this for initialization
    void Start()
    {
        //thisObj = new GameObject[count];
    }

    // Update is called once per frame
    void Update()
    {
        for(int a = 0; a < thisObj.Length; ++a)
        {
            if(pauseButton.pauseGame)
            {
                thisObj[a].SetActive(false);
            }
            else
            {
                thisObj[a].SetActive(true);
            }
        }
    }
}
