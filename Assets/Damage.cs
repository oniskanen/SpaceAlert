using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	public int team = 0;
	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Targeting t = other.GetComponent<Targeting> ();
		if (t != null && t.team != this.team) {
			other.SendMessage ("ApplyDamage", 1f);
			Destroy(this.gameObject);
			Instantiate(explosion, transform.position, Quaternion.identity);
		}
	}
}
