using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {
	public int updatesLeft = 1000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		updatesLeft--;
		if (updatesLeft < 0)
			Destroy (this);
	}
}
