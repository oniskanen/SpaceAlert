using UnityEngine;
using System.Collections;

public class MoveInput : MonoBehaviour {
	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
		if (hit != null && hit.collider != null) {
			Instantiate(explosion, new Vector2(pos.x, pos.y), Quaternion.identity);
		}
	}
}
