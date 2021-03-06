﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDController : MonoBehaviour {

	public Text GoldText;
	float GoldNum = 0;
	public Text KeyText;
	int NumKeys = 0;
	Image health;
	Canvas MainHud;

	public Collectible[] CollectList;

	// Use this for initialization
	void Start () {
		GoldText.text = "0 Gold";
		KeyText.text = "0 Keys";
	}
	
	public void AddGold(float gold){
		GoldNum += gold;
		GoldText.text = GoldNum + " Gold";
	}
	public void RemoveGold(float gold){
		if(GoldNum - gold > 0){
			GoldNum -= gold;
			GoldText.text = GoldNum + " Gold";
		}else{
			Debug.Log("Not Enough gold");
		}
	}

	public void AddKey(){
		NumKeys += 1;
		KeyText.text = NumKeys + " Keys";
	}
	public void RemoveKey(){
		if(NumKeys - 1 > 0){
			NumKeys -= 1;
			KeyText.text = NumKeys + " Keys";
		}else{
			Debug.Log("No Keys!");
		}
	}

}
