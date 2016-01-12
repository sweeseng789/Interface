using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuEventHandler : MonoBehaviour {
	public GameObject canvas;

    Vector3 clickPos;
	bool isClick = false, isDrag = false;

	public GameObject PlayButton, ShopButton, ScoreButton, SettingButton, QuitButton;
	public Text ButtonText;

	float draglen, accel;
	Vector3 RotateAxis, rotateAroundPos;

	// Use this for initialization
	void Start () {
		RotateAxis = Vector3.zero;
		RotateAxis.Set(0, 1, -0.2f);
		RotateAxis.Normalize();
	}

	// Update is called once per frame
	void Update () {
		getInput ();

		if (isDrag || accel != 0) {
			rotateMenu();
			changeText();
		}
	}

    void getInput() {
		if (Input.GetMouseButtonDown (0) && isClick == false) {
			isClick = true;
			clickPos = Input.mousePosition;
		} 
		else if (!Input.GetMouseButton(0)) {
			isClick = false;
			isDrag = false;
		}
		if (isClick && (Input.mousePosition - clickPos).magnitude > 1) {
			isDrag = true;
		}
    }

	void rotateMenu (){
		rotateAroundPos = canvas.transform.position;
		rotateAroundPos.z+=50;

		if (Input.GetMouseButton (0)) {
			draglen = (clickPos.x - Input.mousePosition.x) * Time.deltaTime * 20;
			accel += (clickPos.x - Input.mousePosition.x) * Time.deltaTime;
			clickPos = Input.mousePosition;

			if (accel < 0) {
				if (accel < -3)
					accel = -3;
				accel += Time.deltaTime * 10;
				if (accel > 0)
					accel = 0;
			}
			else {
				if (accel > 3)
					accel = 3;
				accel -= Time.deltaTime * 10;
				if (accel < 0)
					accel = 0;
			}

			var q = PlayButton.transform.rotation;
			PlayButton.transform.RotateAround (rotateAroundPos, RotateAxis, draglen);
			PlayButton.transform.rotation = q;
		
			ShopButton.transform.RotateAround (rotateAroundPos, RotateAxis, draglen);
			ShopButton.transform.rotation = q;
		
			ScoreButton.transform.RotateAround (rotateAroundPos, RotateAxis, draglen);
			ScoreButton.transform.rotation = q;
		
			SettingButton.transform.RotateAround (rotateAroundPos, RotateAxis, draglen);
			SettingButton.transform.rotation = q;
		
			QuitButton.transform.RotateAround (rotateAroundPos, RotateAxis, draglen);
			QuitButton.transform.rotation = q;
		}
		else {
			if (accel < 0) {
				accel += Time.deltaTime;
				if (accel > 0)
					accel = 0;
			}
			else {
				accel -= Time.deltaTime;
				if (accel < 0)
					accel = 0;
			}

			var q = PlayButton.transform.rotation;
			PlayButton.transform.RotateAround (rotateAroundPos, RotateAxis, accel);
			PlayButton.transform.rotation = q;
			
			ShopButton.transform.RotateAround (rotateAroundPos, RotateAxis, accel);
			ShopButton.transform.rotation = q;
			
			ScoreButton.transform.RotateAround (rotateAroundPos, RotateAxis, accel);
			ScoreButton.transform.rotation = q;
			
			SettingButton.transform.RotateAround (rotateAroundPos, RotateAxis, accel);
			SettingButton.transform.rotation = q;
			
			QuitButton.transform.RotateAround (rotateAroundPos, RotateAxis, accel);
			QuitButton.transform.rotation = q;
		}

		//debug += draglen;
		print(accel);
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
