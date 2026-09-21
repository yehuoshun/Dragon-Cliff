using System;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x0200038C RID: 908
	public class AttractionParticleAffector : ParticleAffector
	{
		// Token: 0x0600184F RID: 6223 RVA: 0x000BA980 File Offset: 0x000B8D80
		public AttractionParticleAffector()
		{
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x000BA99E File Offset: 0x000B8D9E
		protected override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x000BA9A6 File Offset: 0x000B8DA6
		protected override void Start()
		{
			base.Start();
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x000BA9AE File Offset: 0x000B8DAE
		protected override void Update()
		{
			base.Update();
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x000BA9B8 File Offset: 0x000B8DB8
		protected override void LateUpdate()
		{
			float x = base.transform.lossyScale.x;
			this.arrivalRadiusSqr = this.arrivalRadius * this.arrivalRadius * x;
			this.arrivedRadiusSqr = this.arrivedRadius * this.arrivedRadius * x;
			base.LateUpdate();
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x000BAA0C File Offset: 0x000B8E0C
		protected override Vector3 GetForce()
		{
			Vector3 result;
			if (this.parameters.distanceToAffectorCenterSqr < this.arrivedRadiusSqr)
			{
				result.x = 0f;
				result.y = 0f;
				result.z = 0f;
			}
			else if (this.parameters.distanceToAffectorCenterSqr < this.arrivalRadiusSqr)
			{
				float d = 1f - this.parameters.distanceToAffectorCenterSqr / this.arrivalRadiusSqr;
				result = Vector3.Normalize(this.parameters.scaledDirectionToAffectorCenter) * d;
			}
			else
			{
				result = Vector3.Normalize(this.parameters.scaledDirectionToAffectorCenter);
			}
			return result;
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x000BAAB8 File Offset: 0x000B8EB8
		protected override void OnDrawGizmosSelected()
		{
			if (base.enabled)
			{
				base.OnDrawGizmosSelected();
				float x = base.transform.lossyScale.x;
				float radius = this.arrivalRadius * x;
				float radius2 = this.arrivedRadius * x;
				Vector3 center = base.transform.position + this.offset;
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireSphere(center, radius);
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(center, radius2);
			}
		}

		// Token: 0x04001807 RID: 6151
		[Header("Affector Controls")]
		public float arrivalRadius = 1f;

		// Token: 0x04001808 RID: 6152
		public float arrivedRadius = 0.5f;

		// Token: 0x04001809 RID: 6153
		private float arrivalRadiusSqr;

		// Token: 0x0400180A RID: 6154
		private float arrivedRadiusSqr;
	}
}
