using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopHandler : MonoBehaviour {
	List<ShopWeapon> WeapList = new List<ShopWeapon>();
	ShopWeapon currentWeapon;
	int currentWeaponIndex;

	public List<GameObject> weaponGroups = new List<GameObject>();

	public Text weapName;
	public Slider damageSlider, firerateSlider, clipsizeSlider;
	float tempDamage, tempFirerate, tempClipsize;
	bool runUpdateSlider = false;

	public Text money;
	int realMoney = 4200;

	public Button MultipurposeButton;

	public PopUpScript buyPopUp;

	public PopUpScript equipPopUp;
	public List<Button> weapWheelButtons;
	public List<ShopWeapon> weapWheel;
	public List<Image> weapWheelImg;

	bool equipable = false, unequipable = false;

	public GameObject WWStatsPanel;
	public Text WWWeapName;
	public Slider WWDamageSlider, WWFirerateSlider, WWClipsizeSlider;

	// Use this for initialization
	void Start () {
		for (int i = 1; i < weaponGroups.Count; ++i) {
			weaponGroups[i].SetActive(false);
		}
		money.text = "$" + realMoney.ToString();

		MultipurposeButton.image.enabled = false;

		unShowEquipStats ();
	}
	
	// Update is called once per frame
	void Update () {
		if (runUpdateSlider) {
			updateSlider();
		}
	}

	public void addWeapToList(ShopWeapon weab) {
		WeapList.Add(weab);
		Color tempcol;
		tempcol = weab.button.image.color;
		tempcol.a = 0.4f;
		weab.button.image.color = tempcol;
	}

	public void changeWeapGroup (int index) {
		for (int i = 0; i < weaponGroups.Count; ++i) {
			if(index == i) 
				weaponGroups[i].SetActive(true);
			else
				weaponGroups[i].SetActive(false);
		}
	}

	public void selectWeap (ShopWeaponList page) {
		Color tempcol;
		for (int i = 0; i < WeapList.Count; ++i) {
			if(page.getWeapWifIndex() == WeapList[i]) {
				currentWeapon = page.getWeapWifIndex();
				currentWeaponIndex = i;
				tempcol = WeapList[i].button.image.color;
				tempcol.a = 1;
				WeapList[i].button.image.color = tempcol;

				MultipurposeButton.image.enabled = true;

				runUpdateSlider = false;
				updateSlider();

				updateInfo ();
			} else {
				tempcol = WeapList[i].button.image.color;
				tempcol.a = 0.4f;
				WeapList[i].button.image.color = tempcol;
			}
		}
	}

	public void onMultiButtClick () {
		if (!currentWeapon.purchased && realMoney > currentWeapon.price) {
			buyPopUp.launch("Buy " + currentWeapon.name + " for " + "$" + currentWeapon.price + "?");
		} else if (currentWeapon.purchased && !currentWeapon.equiped) {
			equipPopUp.launch("Equip Mode");
			equipable = true;
		} else if (currentWeapon.purchased && currentWeapon.equiped) {
			unequipWeap();
		}
	}

	public void onBuyPopUpClick () {
		if (!currentWeapon.purchased && realMoney > currentWeapon.price) {
			currentWeapon.purchased = true;
			realMoney -= currentWeapon.price;
			money.text = "$" + realMoney.ToString();
			updateInfo ();
			buyPopUp.end();
		}
	}

	public void goBackFromEquip () {
		equipable = false;
		equipPopUp.end();
	}

	public void equipWeap (int slot) {
		if (equipable) {
			weapWheel [slot].equiped = false;
			weapWheel [slot] = currentWeapon;
			weapWheelImg [slot].sprite = currentWeapon.button.image.sprite;
			weapWheelImg [slot].color = new Color(1,1,1,1);
			currentWeapon.equiped = true;
			updateInfo ();
			equipable = false;
			goBackFromEquip ();
		}
	}

	public void unequipWeap () {
		for (int i = 0; i < weapWheel.Count; ++i) {
			if(currentWeapon == weapWheel[i]) {
				currentWeapon.equiped = false;
				weapWheel[i] = new ShopWeapon();
				weapWheelImg [i].sprite = new Sprite();
				weapWheelImg [i].color = new Color(1,1,1,0);
				updateInfo ();
			}
		}
	}

	public void showEquipStats (int slot) {
		WWStatsPanel.SetActive(true);
		WWWeapName.text = weapWheel [slot].name;
		WWDamageSlider.value = weapWheel [slot].damage;
		WWFirerateSlider.value = weapWheel [slot].fireRate;
		WWClipsizeSlider.value = weapWheel [slot].clipSize;

		Color c;
		for (int i = 0; i < weapWheelButtons.Count; i++) {
			if(slot == i) {
				c = weapWheelButtons[i].image.color;
				c.a = 1;
				weapWheelButtons[i].image.color = c;
			}
		}
	}

	public void unShowEquipStats () {
		WWStatsPanel.SetActive (false);
		Color c;
		for (int i = 0; i < weapWheelButtons.Count; i++) {
			c = weapWheelButtons[i].image.color;
			c.a = 0.6f;
			weapWheelButtons[i].image.color = c;
		}
	}

	void updateInfo () {
		weapName.text = currentWeapon.name;

		if (!currentWeapon.purchased && realMoney >= currentWeapon.price) {
			MultipurposeButton.GetComponentInChildren<Text>().text = "Buy";
		} else if (!currentWeapon.purchased && realMoney < currentWeapon.price) {
			MultipurposeButton.GetComponentInChildren<Text>().text = "Not Enough $$";
		} else if (currentWeapon.purchased && !currentWeapon.equiped) {
			MultipurposeButton.GetComponentInChildren<Text>().text = "Equip";
			currentWeapon.priceTag.text = "Purchased";
		} else if (currentWeapon.purchased && currentWeapon.equiped) {
			MultipurposeButton.GetComponentInChildren<Text>().text = "Unequip";
			currentWeapon.priceTag.text = "Equiped";
		}

		money.text = "$" + realMoney.ToString();
	}

	void updateSlider () {
		if (!runUpdateSlider) {
			tempDamage = damageSlider.value;
			tempFirerate = firerateSlider.value;
			tempClipsize = clipsizeSlider.value;
			runUpdateSlider = true;
		} else {
			if(damageSlider.value < currentWeapon.damage) {
				damageSlider.value += (currentWeapon.damage - tempDamage)*Time.deltaTime*1.5f;
				if(damageSlider.value > currentWeapon.damage)
					damageSlider.value = currentWeapon.damage;
			} else if(damageSlider.value > currentWeapon.damage) {
				damageSlider.value += (currentWeapon.damage - tempDamage)*Time.deltaTime*1.5f;
				if(damageSlider.value < currentWeapon.damage)
					damageSlider.value = currentWeapon.damage;
			}

			if(firerateSlider.value < currentWeapon.fireRate) {
				firerateSlider.value += (currentWeapon.fireRate - tempFirerate)*Time.deltaTime*1.5f;
				if(firerateSlider.value > currentWeapon.fireRate)
					firerateSlider.value = currentWeapon.fireRate;
			} else if(firerateSlider.value > currentWeapon.fireRate) {
				firerateSlider.value += (currentWeapon.fireRate - tempFirerate)*Time.deltaTime*1.5f;
				if(firerateSlider.value < currentWeapon.fireRate)
					firerateSlider.value = currentWeapon.fireRate;
			}

			if(clipsizeSlider.value < currentWeapon.clipSize) {
				clipsizeSlider.value += (currentWeapon.clipSize - tempClipsize)*Time.deltaTime*1.5f;
				if(clipsizeSlider.value > currentWeapon.clipSize)
					clipsizeSlider.value = currentWeapon.clipSize;
			} else if(clipsizeSlider.value > currentWeapon.clipSize) {
				clipsizeSlider.value += (currentWeapon.clipSize - tempClipsize)*Time.deltaTime*1.5f;
				if(clipsizeSlider.value < currentWeapon.clipSize)
					clipsizeSlider.value = currentWeapon.clipSize;
			}

			if (damageSlider.value == currentWeapon.damage && firerateSlider.value == currentWeapon.fireRate && clipsizeSlider.value == currentWeapon.clipSize) {
				runUpdateSlider = false;
			}
		}
	}
}
