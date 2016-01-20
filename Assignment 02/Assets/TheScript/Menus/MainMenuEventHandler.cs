using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuEventHandler : MonoBehaviour {
	enum states {
		animation,
		interective
	};
	states state;

	float animationspeed = 0;

	public CanvasGroup canvas;
	
	public GameObject wings;
	public Image BlackAlphaLayer;
	Color alphaVar;

	Vector3 clickPos;
	bool isClick = false, isDrag = false;
	
	public Button PlayButton, ShopButton, ScoreButton, SettingButton, QuitButton;
	Button currentButton;
	public Text CurrentButtonText;
	List<Button> buttons = new List<Button>();

	float draglen, accel;
	Vector3 RotateAxis, rotateAroundPos;

	// Use this for initialization
	void Start () {
		state = states.animation;

		canvas.alpha = 0;

		alphaVar = BlackAlphaLayer.color;
		alphaVar.a = 0;

		RotateAxis = Vector3.zero;
		RotateAxis.Set(0, 1, -0.2f);
		RotateAxis.Normalize();
				
		rotateAroundPos = canvas.transform.position;
		RectTransform rekt; 
		rekt = canvas.GetComponent<RectTransform>();
		Vector3 v3 = rekt.lossyScale;
		rotateAroundPos.z+= v3.z * 346.410083f;

		var q = PlayButton.transform.rotation;
		ShopButton.transform.RotateAround (rotateAroundPos, RotateAxis, 72);
		ShopButton.transform.rotation = q;
				
		ScoreButton.transform.RotateAround (rotateAroundPos, RotateAxis, 144);
		ScoreButton.transform.rotation = q;
				
		SettingButton.transform.RotateAround (rotateAroundPos, RotateAxis, 288);
		SettingButton.transform.rotation = q;
				
		QuitButton.transform.RotateAround (rotateAroundPos, RotateAxis, 216);
		QuitButton.transform.rotation = q;

		buttons.Add (PlayButton);
		buttons.Add (ShopButton);
		buttons.Add (ScoreButton);
		buttons.Add (SettingButton);
		buttons.Add (QuitButton);

		changeAlpha ();
	}

	// Update is called once per frame
	void Update () {
		switch (state) {
		case states.animation:
			animationspeed += Time.deltaTime;
			canvas.alpha += animationspeed * Time.deltaTime;

			wings.transform.Translate (0, animationspeed * Time.deltaTime * 30, 0);

			alphaVar.a += animationspeed * Time.deltaTime * 0.4f;
			BlackAlphaLayer.color = alphaVar;
			if (canvas.alpha == 1) {
				alphaVar.a = 0.4f;
				BlackAlphaLayer.color = alphaVar;
				state = states.interective;
			}
			break;

		case states.interective:
			//getInput ();

			if (isDrag || accel != 0) {
				rotateMenu();
				changeText();
				changeAlpha ();
				renderOrder();
			}

			if (currentButton) {
				float angle = Vector3.Angle ((currentButton.transform.position - canvas.transform.position).normalized, new Vector3 (0, 0, -1));                           
				if (angle > 90.02) {
					var q = currentButton.transform.rotation;
					currentButton.transform.RotateAround (rotateAroundPos, RotateAxis, 0.01f);
					float angle2 = Vector3.Angle ((currentButton.transform.position - canvas.transform.position).normalized, new Vector3 (0, 0, -1));
					if (angle2 > angle) {
						accel = -(angle - 89.5f) * 0.3f;
					} else {
						accel = (angle - 89.5f) * 0.3f;
					}
					currentButton.transform.RotateAround (rotateAroundPos, RotateAxis, -0.01f);
					currentButton.transform.rotation = q;
				} else {
					if(currentButton == SettingButton)
					{
						StaticVarsNFuns.GoToSettings();
					}
					currentButton = null;
				}
			}
			break;
		}
	}
	

	void getInput() {
		//if (Input.GetMouseButtonDown (0) && isClick == false && Input.mousePosition.y < Screen.height/1.8f) {
		if (Input.GetMouseButtonDown (0) && isClick == false && Input.mousePosition.y < Screen.height/1.8f) {
				isClick = true;
				clickPos = Input.mousePosition;
			} else if (Input.GetTouch (0).phase == TouchPhase.Ended) {//(!Input.GetMouseButton(0)) {
				isClick = false;
				isDrag = false;
			} else if (Input.GetTouch (0).phase == TouchPhase.Moved) { //(isClick && (Input.mousePosition - clickPos).magnitude > 1) {
				isDrag = true;
			}
	}

	void rotateMenu (){
		if (isDrag && currentButton == null) {
			draglen = (clickPos.x/Screen.width - Input.mousePosition.x/Screen.width) * 10000 * Time.deltaTime;
			accel += (clickPos.x - Input.mousePosition.x) * Time.deltaTime;
			clickPos = Input.mousePosition;

			if (accel < 0) {
				if (accel < -3)
					accel = -3;
				accel += Time.deltaTime * 10;
				if (accel > 0)
					accel = -0.01f;
			} else {
				if (accel > 3)
					accel = 3;
				accel -= Time.deltaTime * 10;
				if (accel < 0)
					accel = 0.01f;
			}

			var q = PlayButton.transform.rotation;
			for (int i = 0; i < buttons.Count; i++) {
				buttons [i].transform.RotateAround (rotateAroundPos, RotateAxis, draglen);
				buttons [i].transform.rotation = q;
			}
		} else {
			var q = PlayButton.transform.rotation;
			foreach (Button button in buttons) {
				button.transform.RotateAround (rotateAroundPos, RotateAxis, accel);
				button.transform.rotation = q;
			}

			if (accel < 0) {
				accel += Time.deltaTime;
				if (accel > 0)
					accel = 0;
			} else {
				accel -= Time.deltaTime;
				if (accel < 0)
					accel = 0;
			}
		}
				
		if (accel == 0) {
			float dist = 1000;
			Button tempbutt = null;
			for (int i = 0; i < buttons.Count; i++) {
				if (buttons [i].transform.position.z < dist) {
					dist = buttons [i].transform.position.z;
					tempbutt = buttons [i];
				}
			}
			if (tempbutt.transform.position.z - canvas.transform.position.z > 0) {
				currentButton = tempbutt;
			}
		}
	}

	void changeText (){
		if (PlayButton.transform.position.z - canvas.transform.position.z < 8) {
			CurrentButtonText.text = "Play";
		}
		else if (ShopButton.transform.position.z - canvas.transform.position.z < 8) {
			CurrentButtonText.text = "Shop";
		}
		else if (ScoreButton.transform.position.z - canvas.transform.position.z < 8) {
			CurrentButtonText.text = "Highscore";
		}
		else if (SettingButton.transform.position.z - canvas.transform.position.z < 8) {
			CurrentButtonText.text = "Settings";
		}
		else if (QuitButton.transform.position.z - canvas.transform.position.z < 8) {
			CurrentButtonText.text = "Quit";
		}
		else
			CurrentButtonText.text = "";
	}

	void changeAlpha (){
		foreach (Button button in buttons) {
			float angle = Vector3.Angle ((button.transform.position - canvas.transform.position).normalized, new Vector3 (0, 0, -1));
			Color color = button.image.color;
			color.a = (180/(angle-65)) * 0.15f;
			button.image.color = color;
		}
	}

	public void buttonOnClick (Button GO){
		if(!isDrag)
			currentButton = GO;
	}

	void renderOrder ()
	{
		for (int i = 0; i < buttons.Count; i++) {
			int slot = buttons.Count - 1;
			for (int j = 0; j < buttons.Count; j++) {
				if(!buttons[i].Equals(buttons[j])) {
					if(buttons[i].transform.position.z > buttons[j].transform.position.z) {
						slot-=1;
					}
				}
			}
			buttons[i].transform.SetSiblingIndex(slot);
		}
	}

	public void onCLick() {
		isClick = true;
	}

	public void onDown() {
		clickPos = Input.mousePosition;
	}

	public void onDrag() {
		isDrag = true;
	}

	public void onUp() {
		isDrag = false;
	}
}
