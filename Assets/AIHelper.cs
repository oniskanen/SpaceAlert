using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class AIHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public IList<GameObject> GetShips(int team)
	{
		GameObject teamObj = GameObject.Find ("P" + team);
		List<GameObject> objects = new List<GameObject> ();
		foreach(Transform t in teamObj.transform)
		{
			objects.Add(t.gameObject);
		}

		return objects;
	}
}
