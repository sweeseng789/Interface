using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class WeaponItem {
	public Sprite icon;
	public string name;
	public int price;
	public float damage;
	public float fireRate;
	public float clipSize;
	public bool purchased;
	public Button.ButtonClickedEvent onClick;
}

public class ShopWeaponList : MonoBehaviour {
	public ShopHandler shopHandler;

	public GameObject sampleWeapon;
	public List<WeaponItem> weapItems;

	public Transform contentPanel;

	List<ShopWeapon> weapList = new List<ShopWeapon>();
	int IndexOfSelectedWeap = 0;

	// Use this for initialization
	void Start () {
		PopulateList ();
	}

	void PopulateList () {
		foreach (var weap in weapItems) {
			GameObject newButton = Instantiate (sampleWeapon) as GameObject;
			ShopWeapon button = newButton.GetComponent <ShopWeapon> ();
			button.priceTag.text = "$" + weap.price;
			button.name = weap.name;
			button.icon.sprite = weap.icon;
			button.price = weap.price;
			button.damage = weap.damage;
			button.fireRate = weap.fireRate;
			button.clipSize = weap.clipSize;
			button.purchased = weap.purchased;
			button.button.onClick = weap.onClick;
			newButton.transform.SetParent (contentPanel);
			newButton.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
			newButton.transform.localPosition = new Vector3(newButton.transform.localPosition.x, newButton.transform.localPosition.y, 0);
			weapList.Add(newButton.GetComponent <ShopWeapon> ());
			shopHandler.addWeapToList(newButton.GetComponent <ShopWeapon> ());
		}
		/*
		Color tempcol;
		tempcol = GOS [0].button.image.color;
		tempcol.a = 1;
		GOS [0].button.image.color = tempcol;
		*/
	}

	public void SetIndexOfSelectedWeap (int index) {
		IndexOfSelectedWeap = index;
	}

	public ShopWeapon getWeapWifIndex() {
		return weapList[IndexOfSelectedWeap];
	}

}
