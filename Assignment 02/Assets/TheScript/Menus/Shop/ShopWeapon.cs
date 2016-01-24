using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopWeapon : MonoBehaviour {
	
	public Button button;
	public Image icon;
	public Text priceTag;
	public string name;
	public int price;
	public float damage;
	public float fireRate;
	public float clipSize;
	public bool purchased;
	public bool equiped;
}