﻿using UnityEngine;
using System.Collections.Generic;

public class RangedUpgrade : MonoBehaviour {
	
	public List<Sprite> sprites;
	protected int s_counter = 0;
	
	
	// Happens when clicked
	void OnMouseDown(){
		Debug.Log ("clicked RangedUpgrade");
		ChangeSprite ();
		if (this.s_counter < 4)
			this.s_counter += 1;
	}
	
	void ChangeSprite(){
		SpriteRenderer srenderer = GetComponent<SpriteRenderer> ();
		srenderer.sprite = sprites [this.s_counter];
	}
}