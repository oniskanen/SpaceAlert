using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using System.Collections.Generic;
using System.Linq;

public class CameraController : MonoBehaviour {
	public Camera cam;
	private bool isMoving = false;

	// Use this for initialization
	void Start () {
		if (cam == null)
			cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
			return;

		if (Input.GetKey (KeyCode.I))
			MoveCamera (cam.ScreenToWorldPoint(new Vector2 (cam.pixelWidth/2, 3 * cam.pixelHeight / 2)));
		if (Input.GetKey (KeyCode.J))
			MoveCamera (cam.ScreenToWorldPoint(new Vector2 (-cam.pixelWidth/2, cam.pixelHeight/2)));
		if (Input.GetKey (KeyCode.K))
			MoveCamera (cam.ScreenToWorldPoint(new Vector2 (cam.pixelWidth/2, -cam.pixelHeight/2)));
		if (Input.GetKey (KeyCode.L))
			MoveCamera (cam.ScreenToWorldPoint(new Vector2 (3*cam.pixelWidth/2, cam.pixelHeight/2)));
	}

	void setNotMoving()
	{
		isMoving = false;
	}
	void MoveCamera(Vector2 newPosition) {
		if (Mathf.Approximately(newPosition.x, 0))
		    newPosition.x = 0;

	    if (Mathf.Approximately(newPosition.y, 0))
		    newPosition.y = 0;

		isMoving = true;
		TweenParms p = new TweenParms();
		p.Prop ("position", new Vector3 (newPosition.x, newPosition.y, this.transform.position.z));
		Debug.Log ("newpos: " + new Vector3 (newPosition.x, newPosition.y, this.transform.position.z));
		p.OnComplete (setNotMoving);
		HOTween.To (this.transform, 1, p);
	}
}
