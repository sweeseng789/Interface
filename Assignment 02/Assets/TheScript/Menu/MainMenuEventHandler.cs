using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuEventHandler : MonoBehaviour {
	public GameObject canvas;

    Vector3 clickPos;
	bool isClick = false, isDrag = false;

	public GameObject PlayButton, ShopButton, ScoreButton, SettingButton, QuitButton;
	public Text ButtonText;

	float accel;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		getInput ();

		if (isDrag || accel > 0) {
			rotateMenu();
			changeText();
		}
	}

    void getInput() {
		if (Input.GetMouseButtonDown (0) && isClick == false) {
			isClick = true;
			clickPos = Input.mousePosition;
		} 
		else if (Input.GetMouseButtonUp (0)) {
			isClick = false;
			isDrag = false;
		}
		if (isClick && (Input.mousePosition - clickPos).magnitude > 1) {
			isDrag = true;
		}
    }

	void rotateMenu (){
		float draglen = clickPos.x - Input.mousePosition.x;
		accel += draglen * Time.deltaTime * 10;
		clickPos = Input.mousePosition;
		
		Vector3 axis = Vector3.zero;
		axis.Set(0, 1, -0.2f);
		axis.Normalize();
		
		Vector3 pos = canvas.transform.position;
		pos.z+=50;
		
		var q = PlayButton.transform.rotation;
		PlayButton.transform.RotateAround(pos, axis, accel);
		PlayButton.transform.rotation = q;
		
		ShopButton.transform.RotateAround(pos, axis, accel);
		ShopButton.transform.rotation = q;
		
		ScoreButton.transform.RotateAround(pos, axis, accel);
		ScoreButton.transform.rotation = q;
		
		SettingButton.transform.RotateAround(pos, axis, accel);
		SettingButton.transform.rotation = q;
		
		QuitButton.transform.RotateAround(pos, axis, accel);
		QuitButton.transform.rotation = q;

		accel -= 100 * Time.deltaTime;
		if (accel < 0)
			accel = 0;

		//debug += draglen;
		print(PlayButton.transform.position.z);
	}

	void changeText (){
		if (PlayButton.transform.position.z - canvas.transform.position.z < 8) {
			ButtonText.text = "Play";
		}
		else if (ShopButton.transform.position.z - canvas.transform.position.z < 8) {
			ButtonText.text = "Shop";
		}
		else if (ScoreButton.transform.position.z - canvas.transform.position.z < 8) {
			ButtonText.text = "Highscore";
		}
		else if (SettingButton.transform.position.z - canvas.transform.position.z < 8) {
			ButtonText.text = "Settings";
		}
		else if (QuitButton.transform.position.z - canvas.transform.position.z < 8) {
			ButtonText.text = "Quit";
		}
		else
			ButtonText.text = "";
	}
}
