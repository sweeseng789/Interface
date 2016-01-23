using UnityEngine;
using System.Collections;

public class StaticVarsNFuns : MonoBehaviour {

	public static float sound = 0;

	public static void GoToSettings (){
		Application.LoadLevel ("Settings");
	}
}
