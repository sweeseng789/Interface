using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrintToScreen : MonoBehaviour
{
    public GameObject test1;
    public Text printout;

	// Use this for initialization
	void Start ()
    {
        printout.text = "Started";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Clicked()
    {
        printout.text = "Clicked";
    }
}
