using UnityEngine;
using System.Collections.Generic;

namespace Steer2D
{
    public class PatrolRing : SteeringBehaviour 
    {
        public Vector2 TargetPoint = Vector2.zero;
        public float OuterRadius = 3f;
        public float InnerRadius = 2f;
		public float CollisionRadius = 1.8f;

        public bool DrawGizmos = false;

        public override Vector2 GetVelocity()
        {
            float distance = Vector3.Distance(transform.position, (Vector3)TargetPoint);
            Vector2 desiredVelocity = (TargetPoint - (Vector2)transform.position).normalized;

            if (distance < InnerRadius) {
				Vector2 normal = (Vector2)transform.position - TargetPoint;
				desiredVelocity = normal / (normal.magnitude - CollisionRadius);
			} else if (distance < OuterRadius)
				desiredVelocity = Vector2.zero;
            else
                desiredVelocity = desiredVelocity * agent.MaxVelocity;

            return desiredVelocity - agent.CurrentVelocity;
        }

        void OnDrawGizmos()
        {
            if (DrawGizmos)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere((Vector3)TargetPoint, OuterRadius);

                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere((Vector3)TargetPoint, InnerRadius);
            }
        }
    }
}