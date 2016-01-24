using UnityEngine;
using System.Collections;

public class StaticVarsNFuns : MonoBehaviour {

	public static bool invertControls = false;
	public static bool autoAim = false;
	public static float opacity = 0.5f;

	static string prevLevel;


	public void GoToGameplay (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Gameplay");
	}
	
	public static void SGoToGameplay (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Gameplay");
	}

	public void GoToHighscore (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Highscore");
	}
	
	public static void SGoToHighscore (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Highscore");
	}

	public void GoToMainMenu (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("MainMenu");
	}
	
	public static void SGoToMainMenu (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("MainMenu");
	}

	public void GoToModeSelect (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("ModeSelect");
	}
	
	public static void SGoToModeSelect (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("ModeSelect");
	}

	public void GoToSettings (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Settings");
	}
	
	public static void SGoToSettings (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Settings");
	}

	public void GoToShop (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Shop");
	}
	
	public static void SGoToShop (){
		prevLevel = Application.loadedLevelName;
		Application.LoadLevel ("Shop");
	}

	public void GoBack (){
		Application.LoadLevel (prevLevel);
	}

	public void quitGame () {
		Application.Quit();
	}
}