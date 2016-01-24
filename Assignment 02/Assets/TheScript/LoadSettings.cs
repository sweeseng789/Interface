using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadSettings : MonoBehaviour {
	public GameObject MovementStick, ShootingStick;
	Vector3 MSPos, SSpos;

	// Use this for initialization
	void Start () {
		MSPos = MovementStick.transform.position;
		SSpos = ShootingStick.transform.position;

		if (StaticVarsNFuns.invertControls) {
			ShootingStick.transform.position = MSPos;
			MovementStick.transform.position = SSpos;
		}

		if (StaticVarsNFuns.autoAim) {
			ShootingStick.GetComponent<Image> ().enabled = false;
		}

		MovementStick.GetComponentsInChildren<Image> () [0].color = new Color (1, 1, 1, StaticVarsNFuns.opacity);
		MovementStick.GetComponentsInChildren<Image> () [1].color = new Color (1, 1, 1, StaticVarsNFuns.opacity);
		ShootingStick.GetComponentsInChildren<Image> () [0].color = new Color (1, 1, 1, StaticVarsNFuns.opacity);
		ShootingStick.GetComponentsInChildren<Image> () [1].color = new Color (1, 1, 1, StaticVarsNFuns.opacity);
	}
}
