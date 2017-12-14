using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDController : MonoBehaviour {

	Text Gold;

	Image health;
	Canvas MainHud;

	// Use this for initialization
	void Start () {
		Gold.text = "0 gold";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetUpHealthBar(){
		Texture2D bar = new Texture2D(1,1);
		bar.SetPixel(0,0,Color.red);
		health.sprite = Sprite.Create(bar, new Rect(), Vector2.zero);
		health.rectTransform.position.Set((float)(MainHud.pixelRect.xMax *.85)/MainHud.pixelRect.xMax,
											(float)(MainHud.pixelRect.yMax *.85)/MainHud.pixelRect.yMax ,1f);
	}
}
