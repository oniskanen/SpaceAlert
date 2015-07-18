using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Test : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HOTween.To (transform, 4, "position", new Vector3 (0, 0, 0)); 
	}
}
