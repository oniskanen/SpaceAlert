using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int team = 0;
	public int enemyTeam = 0;
	public GameObject startingPlanet;
	public Rigidbody2D fighter;
	public int startingMoney = 1000;
	public int moneyPerUpdate = 1;
	private int money;
	public int fighterPrice = 100;

	// Use this for initialization
	void Start () {
		if (team == 0 || startingPlanet == null || fighter == null || enemyTeam == 0)
			throw new UnityException ("Can't start without initializing player!");

		money = startingMoney;

	}

	void FixedUpdate () {
		money += moneyPerUpdate;

		if (money > fighterPrice)
			BuyFighter ();
	}

	void BuyFighter ()
	{
		money -= fighterPrice;

		float randomDist = Random.Range (2, 3);
		float randomDir = Random.Range (0, 360);
		float randomAngle = Random.Range (0, 360);
		Vector2 direction = new Vector2 (Mathf.Cos (randomDir), Mathf.Sin (randomDir));
		Vector2 startingPoint = (Vector2)startingPlanet.transform.position + direction * randomDist;
		Rigidbody2D f = (Rigidbody2D)Instantiate (fighter, startingPoint, Quaternion.Euler (new Vector3 (0, 0, randomAngle)));
		f.GetComponent<Targeting> ().team = this.team;
		f.GetComponent<Targeting> ().enemyTeam = this.enemyTeam;
		f.transform.parent = transform;
	}
}
