using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum WEPAONCHOICE
{
    s_MELEE,
    s_PISTOL,
    s_SMG,
    s_SNIPER,
}

public class Weapon : MonoBehaviour
{
    public static WEPAONCHOICE choice = WEPAONCHOICE.s_PISTOL;
    public static int ammoCount = 15;

    public GameObject pistol;
    public GameObject melee;
    public GameObject SMG;
    public GameObject sniper;

    public Text AmmoCountText;

    public static void setToPistol()
    {
        choice = WEPAONCHOICE.s_PISTOL;
    }

    public static void setToMelee()
    {
        choice = WEPAONCHOICE.s_MELEE;
    }

    public static void setToSMG()
    {
        choice = WEPAONCHOICE.s_SMG;
    }

    public static void setToSniper()
    {
        choice = WEPAONCHOICE.s_SNIPER;
    }

    void Update()
    {
        if (ammoCount < 1)
            ammoCount = 15;

        AmmoCountText.text = ammoCount.ToString();

        if(choice == WEPAONCHOICE.s_PISTOL)
        {
            pistol.SetActive(true);
            melee.SetActive(false);
            SMG.SetActive(false);
            sniper.SetActive(false);
            AmmoCountText.enabled = true;
        }
        else if (choice == WEPAONCHOICE.s_MELEE)
        {
            pistol.SetActive(false);
            melee.SetActive(true);
            SMG.SetActive(false);
            sniper.SetActive(false);
            AmmoCountText.enabled = false;
        }
        else if (choice == WEPAONCHOICE.s_SMG)
        {
            pistol.SetActive(false);
            melee.SetActive(false);
            SMG.SetActive(true);
            sniper.SetActive(false);
            AmmoCountText.enabled = true;
        }
        else
        {
            pistol.SetActive(false);
            melee.SetActive(false);
            SMG.SetActive(false);
            sniper.SetActive(true);
            AmmoCountText.enabled = true;
        }
    }
}
