using System;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x02000394 RID: 916
	public class VortexParticleAffector : ParticleAffector
	{
		// Token: 0x06001883 RID: 6275 RVA: 0x000BD2C0 File Offset: 0x000BB6C0
		public VortexParticleAffector()
		{
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x000BD2D3 File Offset: 0x000BB6D3
		protected override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x000BD2DB File Offset: 0x000BB6DB
		protected override void Start()
		{
			base.Start();
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x000BD2E3 File Offset: 0x000BB6E3
		protected override void Update()
		{
			base.Update();
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x000BD2EB File Offset: 0x000BB6EB
		protected override void LateUpdate()
		{
			base.LateUpdate();
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x000BD2F3 File Offset: 0x000BB6F3
		private void UpdateAxisOfRotation()
		{
			this.axisOfRotation = Quaternion.Euler(this.axisOfRotationOffset) * base.transform.up;
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x000BD316 File Offset: 0x000BB716
		protected override void PerParticleSystemSetup()
		{
			this.UpdateAxisOfRotation();
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x000BD31E File Offset: 0x000BB71E
		protected override Vector3 GetForce()
		{
			return Vector3.Normalize(Vector3.Cross(this.axisOfRotation, this.parameters.scaledDirectionToAffectorCenter));
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x000BD33C File Offset: 0x000BB73C
		protected override void OnDrawGizmosSelected()
		{
			if (base.enabled)
			{
				base.OnDrawGizmosSelected();
				Gizmos.color = Color.red;
				Vector3 a;
				if (Application.isPlaying && base.enabled)
				{
					this.UpdateAxisOfRotation();
					a = this.axisOfRotation;
				}
				else
				{
					a = Quaternion.Euler(this.axisOfRotationOffset) * base.transform.up;
				}
				Gizmos.DrawLine(base.transform.position + this.offset, base.transform.position + this.offset + a * base.scaledRadius);
			}
		}

		// Token: 0x04001855 RID: 6229
		private Vector3 axisOfRotation;

		// Token: 0x04001856 RID: 6230
		[Header("Affector Controls")]
		public Vector3 axisOfRotationOffset = Vector3.zero;
	}
}
