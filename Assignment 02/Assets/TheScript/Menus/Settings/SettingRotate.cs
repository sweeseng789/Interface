using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SettingRotate : MonoBehaviour {
	public CanvasGroup canvas;

	Vector3 clickPos;
	bool isDrag = false;
	
	public Button AudioButton, ControlsButton, LanguageButton, CreditsButton;
	Button currentButton;
	public Text CurrentButtonText;
	List<Button> buttons = new List<Button>();

	float draglen, accel;
	Vector3 RotateAxis, rotateAroundPos;

	// Use this for initialization
	void Start () {
		RotateAxis = Vector3.zero;
		RotateAxis.Set(0, 1, -0.2f);
		RotateAxis.Normalize();
				
		rotateAroundPos = canvas.transform.position;
		RectTransform rekt; 
		rekt = canvas.GetComponent<RectTransform>();
		Vector3 v3 = rekt.lossyScale;
		rotateAroundPos.z+= v3.z * 2300;

		var q = ControlsButton.transform.rotation;
		ControlsButton.transform.RotateAround (rotateAroundPos, RotateAxis, 350);
		ControlsButton.transform.rotation = q;
			
		LanguageButton.transform.RotateAround (rotateAroundPos, RotateAxis, 340);
		LanguageButton.transform.rotation = q;
			
		CreditsButton.transform.RotateAround (rotateAroundPos, RotateAxis, 330);
		CreditsButton.transform.rotation = q;

		buttons.Add (AudioButton);
		buttons.Add (ControlsButton);
		buttons.Add (LanguageButton);
		buttons.Add (CreditsButton);

		changeAlpha ();
	}

	//Update is called once per frame
	void Update () {
		if (isDrag || accel != 0) {
			rotateMenu();
			changeText();
			changeAlpha ();
			renderOrder();
		}

		if (currentButton) {
			float angle = Vector3.Angle ((currentButton.transform.position - canvas.transform.position).normalized, new Vector3 (0, 0, -1));                           
			if (angle > 90.003) {
				var q = currentButton.transform.rotation;
				currentButton.transform.RotateAround (rotateAroundPos, RotateAxis, 0.01f);
				float angle2 = Vector3.Angle ((currentButton.transform.position - canvas.transform.position).normalized, new Vector3 (0, 0, -1));
				if (angle2 > angle) {
					accel = -(angle - 89.7f) * 0.2f;
				} else {
					accel = (angle - 89.7f) * 0.2f;
				}
				currentButton.transform.RotateAround (rotateAroundPos, RotateAxis, -0.01f);
				currentButton.transform.rotation = q;
			} else {
				currentButton = null;
			}
		}
	}

	void rotateMenu (){
		if (isDrag && currentButton == null) {
			draglen = (clickPos.x/Screen.width - Input.mousePosition.x/Screen.width) * 1900 * Time.deltaTime;
			accel += (clickPos.x - Input.mousePosition.x) * Time.deltaTime;
			clickPos = Input.mousePosition;

			if (accel < 0) {
				if (accel < -0.5f)
					accel = -0.5f;
				accel += Time.deltaTime * 10;
				if (accel > 0)
					accel = -0.01f;
			} else {
				if (accel > 0.5f)
					accel = 0.5f;
				accel -= Time.deltaTime * 10;
				if (accel < 0)
					accel = 0.01f;
			}

			var q = AudioButton.transform.rotation;
			for (int i = 0; i < buttons.Count; i++) {
				buttons [i].transform.RotateAround (rotateAroundPos, RotateAxis, draglen);
				buttons [i].transform.rotation = q;
			}
		} else {
			var q = AudioButton.transform.rotation;
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
		if (AudioButton.transform.position.z - canvas.transform.position.z < 1) {
			CurrentButtonText.text = "Audio";
		}
		else if (ControlsButton.transform.position.z - canvas.transform.position.z < 1) {
			CurrentButtonText.text = "Controls";
		}
		else if (LanguageButton.transform.position.z - canvas.transform.position.z < 1) {
			CurrentButtonText.text = "Language";
		}
		else if (CreditsButton.transform.position.z - canvas.transform.position.z < 1) {
			CurrentButtonText.text = "Credits";
		}
		else
			CurrentButtonText.text = "";
	}

	void changeAlpha (){
		foreach (Button button in buttons) {
			float angle = Vector3.Angle ((button.transform.position - canvas.transform.position).normalized, new Vector3 (0, 0, -1));
			Color color = button.image.color;
			color.a = (104/(angle-85)) * 0.05f;
			button.image.color = color;
		}
	}

	public void buttonOnClick (Button GO){
		if(!isDrag)
			currentButton = GO;
	}

	void renderOrder () {
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
