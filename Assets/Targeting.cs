using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Steer2D;
using System.Linq;

public class Targeting : MonoBehaviour {
	public int team = 1;
	public int enemyTeam = 2;
	public Rigidbody2D laser;
	public int life = 10;
	public float pursuitFadeOffRange = 2;
	public float pursuitWeight = 4;

	private int framesToNextShot = 0;
	public int shotInterval = 10;
	public bool DrawGizmos = true;
	private bool hasTarget = false;

	// Use this for initialization
	void Start () {
		if (team == 1) {
			GetComponent<SpriteRenderer>().color = Color.red;
		}
		else
			GetComponent<SpriteRenderer>().color = Color.green;

	}

	private Vector2 gizmoLocation;

	GameObject GetClosest (IList<GameObject> enemies)
	{
		GameObject closest = null;
		foreach (GameObject obj in enemies) {
			if (closest == null || (transform.position - closest.transform.position).magnitude > (transform.position - obj.transform.position).magnitude)
			{
				closest = obj;
			}
		}

		return closest;
	}
	
	// Update is called once per frame
	void Update () {
		AIHelper helper = GameObject.Find ("AIHelper").GetComponent<AIHelper>();
		IList<GameObject> enemies = helper.GetShips (enemyTeam);
		if (!enemies.Any ())
		{
			hasTarget = false;
			return;
		}

		GameObject target = GetClosest (enemies);

		Pursue pursueBehaviour = transform.GetComponent<Pursue> ();
		float distanceToTarget = (target.transform.position - transform.position).magnitude;
		if (distanceToTarget > pursuitFadeOffRange)
			pursueBehaviour.Weight = pursuitWeight * (pursuitFadeOffRange/(distanceToTarget*distanceToTarget));
		else
			pursueBehaviour.Weight = pursuitWeight;

		if (pursuitWeight > 0.1) 
		{
			hasTarget = true;
			gizmoLocation = target.transform.position;
		} 
		else
			hasTarget = false;

		pursueBehaviour.TargetAgent = target.GetComponent<SteeringAgent> ();
		// Shoot ();
	}

	public void SetMoveTarget(GameObject planet)
	{
		PatrolRing patrol = GetComponent<PatrolRing> ();
		patrol.TargetPoint = planet.transform.position;
		patrol.CollisionRadius = planet.GetComponent<CircleCollider2D> ().radius;
		patrol.InnerRadius = patrol.CollisionRadius + 0.2f;
		patrol.OuterRadius = patrol.InnerRadius + 0.5f;
	}

	void FixedUpdate()
	{
		if (framesToNextShot > 0)
			framesToNextShot--;
	}

	void OnDrawGizmos()
	{
		if (DrawGizmos && hasTarget)
		{
			Gizmos.color = this.team == 1 ? Color.red : Color.green;
			Gizmos.DrawWireSphere(gizmoLocation, 0.1f);
		}
	}

	private void Shoot ()
	{
		if (framesToNextShot == 0)
			framesToNextShot = shotInterval;
		else
			return;

		Rigidbody2D l = (Rigidbody2D)Instantiate (laser, transform.position +(transform.right * 0.1f), transform.rotation);
		l.velocity = 10 * transform.right;
		l.GetComponent<Damage> ().team = this.team;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Targeting t = other.transform.GetComponent<Targeting> ();
		if (t != null && t.team == this.enemyTeam) {
			Shoot ();
		}
	}

	void ApplyDamage(int amount)
	{
		this.life -= amount;
		Debug.Log ("Life left: " + this.life);
		if (this.life <= 0) {
			Destroy(this.gameObject);
			Debug.Log ("Destroyed!");
		}
	}
}
