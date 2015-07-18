using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Fighter : MonoBehaviour {

	public Transform planet;
	public float maxVelocity = 1f;
	public float maxThrust = 0.5f;
	public float maxAngularVelocity = 0.5f;
	public float maxAngularAcceleration = 1f;

	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {
		Rigidbody2D body = this.GetComponent<Rigidbody2D> ();
		float direction = this.transform.eulerAngles.z; 
//		Debug.Log ("Direction " + direction);

		Vector2 distance = this.planet.position - this.transform.position;
//		Debug.Log ("Distance " + distance);

		float targetDirection = Mathf.Rad2Deg * Mathf.Atan2 (distance.y, distance.x);
//		Debug.Log ("targetDirection " + targetDirection);

		float deltaDirection = Mathf.DeltaAngle( direction, targetDirection);
//		Debug.Log ("deltaDirection " + deltaDirection);

		Debug.Log (deltaDirection);



		if (Mathf.Abs(deltaDirection) > Mathf.Epsilon)
		{
			//HOTween.To(transform.eulerAngles, 1, "z", targetDirection);
			// aDebug.Log("Adding torque. Current angular velocity: " + body.angularVelocity);
			this.GetComponent<Rigidbody2D> ().AddTorque(maxAngularAcceleration*Mathf.Sign(deltaDirection), ForceMode2D.Force);
		}


		if (distance.magnitude > 2 && Mathf.Abs (deltaDirection) < 30) 
		{
			Debug.Log ("Accelerating. Current velocity: " + body.velocity);
			Vector2 unitVector = new Vector2 (Mathf.Cos(Mathf.Deg2Rad*direction),
			                                  Mathf.Sin (Mathf.Deg2Rad*direction));

			Vector2 force = unitVector * maxThrust;
			this.GetComponent<Rigidbody2D> ()
					.AddForce (force ,ForceMode2D.Force);
		}
	}
}
