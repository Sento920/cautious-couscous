using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDController : MonoBehaviour {

	Tuple<Text,float> Gold;


	Image health;
	Canvas MainHud;

	// Use this for initialization
	void Start () {
		Gold.getOne().text = "0 gold";
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

	public void AddGold(float gold){
		Gold.setTwo(gold + Gold.getTwo());
	}
	public void RemoveGold(float gold){
		if(Gold.getTwo() - gold > 0){
			Gold.setTwo(Gold.getTwo() - gold);
		}else{
			Debug.Log("Not Enough gold");
		}
	}
}
