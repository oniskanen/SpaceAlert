using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Steer2D;

public class Targeting : MonoBehaviour {
	public int team = 1;
	public int enemyTeam = 2;
	
	// Use this for initialization
	void Start () {
	
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

		GameObject target = GetClosest (enemies);
		gizmoLocation = target.transform.position;

		transform.GetComponent<Pursue> ().TargetAgent = target.GetComponent<SteeringAgent> ();
	}

	void OnDrawGizmos()
	{
		if (true)
		{
			Gizmos.color = this.team == 1 ? Color.red : Color.green;
			Gizmos.DrawWireSphere(gizmoLocation, 1);
		}
	}
	
}
