﻿using UnityEngine;
using System.Collections;

public class CameraDepthFix : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{
		Camera.main.transparencySortMode = TransparencySortMode.Orthographic;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
