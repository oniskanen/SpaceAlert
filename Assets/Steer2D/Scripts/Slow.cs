using System;
using UnityEngine;
using System.Collections.Generic;

namespace Steer2D
{
    public class Slow : SteeringBehaviour
    {
        public override Vector2 GetVelocity()
        {
			return this.GetComponent<SteeringAgent> ().CurrentVelocity;
		}
    }
}
