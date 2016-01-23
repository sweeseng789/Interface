using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager_Score : MonoBehaviour
{
    public GameObject[] winLoseText = new GameObject[2];
    public Text enemyKilledCount;
    public Text goldEarned;

    string Win = "";
    int enemyKilled = 0;
	// Use this for initialization
	void Start ()
    {
        Win = PlayerPrefs.GetString("Win");
        if (Win == "true")
        {
            winLoseText[0].SetActive(true);
            winLoseText[1].SetActive(false);
        }
        else
        {
            winLoseText[0].SetActive(false);
            winLoseText[1].SetActive(true);
        }

        enemyKilled = PlayerPrefs.GetInt("EnemyKilled");
        enemyKilledCount.text = enemyKilled.ToString();


        goldEarned.text = "";
        goldEarned.text += "EARN: $";
        goldEarned.text += (enemyKilled * 10).ToString();
	}

    public void RestartGame()
    {
        Application.LoadLevel("Gameplay");
    }

    public void ReturnToMenu()
    {
        //Load Main Menu Code Here
    }
}
