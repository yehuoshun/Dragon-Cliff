using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000F2 RID: 242
	public class FX_ElectroLine : MonoBehaviour
	{
		// Token: 0x060006BF RID: 1727 RVA: 0x0006927C File Offset: 0x0006767C
		public FX_ElectroLine()
		{
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000692D0 File Offset: 0x000676D0
		private void Start()
		{
			if (this.StartObject)
			{
				this.StartPosition = this.StartObject.transform.position;
			}
			if (this.EndObject)
			{
				this.EndPosition = this.EndObject.transform.position;
			}
			if (this.RayCast)
			{
				this.StartPosition = base.transform.position;
				Ray ray = new Ray(base.transform.position, base.transform.forward);
				RaycastHit raycastHit;
				if (Physics.Raycast(ray, out raycastHit, this.Length))
				{
					this.EndPosition = raycastHit.point;
					this.vertexCount = (int)(raycastHit.distance / this.DistancePerSegment);
				}
			}
			else
			{
				this.vertexCount = (int)(Vector3.Distance(this.StartPosition, this.EndPosition) / this.DistancePerSegment);
			}
			if (this.LineRender == null)
			{
				this.LineRender = base.GetComponent<LineRenderer>();
				this.LineRender.SetVertexCount(this.vertexCount);
				this.vertexTemps = new Vector3[this.vertexCount];
				this.vertexTempsTarget = new Vector3[this.vertexCount];
				this.vertexTempsCurrent = new Vector3[this.vertexCount];
				for (int i = 0; i < this.vertexCount; i++)
				{
					this.vertexTemps[i] = this.StartPosition + base.transform.forward * this.DistancePerSegment * (float)i;
					if (i == 0 && this.StartObject)
					{
						this.vertexTemps[i] = this.StartPosition;
					}
					if (i == this.vertexCount - 1 && this.EndObject)
					{
						this.vertexTemps[i] = this.EndPosition;
					}
					this.vertexTempsTarget[i] = this.vertexTemps[i];
					this.vertexTempsCurrent[i] = this.vertexTemps[i];
					this.LineRender.SetPosition(i, this.vertexTemps[i]);
					if (!this.EndObject && i == this.vertexCount - 1)
					{
						this.EndPosition = this.vertexTemps[i];
					}
				}
			}
			if (this.FXStart != null)
			{
				Quaternion rotation = base.transform.rotation;
				if (!this.FixRotation)
				{
					rotation = this.FXStart.transform.rotation;
				}
				this.fxStart = UnityEngine.Object.Instantiate<GameObject>(this.FXStart, this.StartPosition, rotation);
				if (this.Normal)
				{
					this.fxStart.transform.forward = base.transform.forward;
				}
				if (this.ParentFXstart)
				{
					this.fxStart.transform.SetParent(base.transform, false);
				}
			}
			if (this.FXEnd != null)
			{
				Quaternion rotation2 = base.transform.rotation;
				if (!this.FixRotation)
				{
					rotation2 = this.FXEnd.transform.rotation;
				}
				this.fxEnd = UnityEngine.Object.Instantiate<GameObject>(this.FXEnd, this.EndPosition, rotation2);
				if (this.Normal)
				{
					this.fxEnd.transform.forward = base.transform.forward;
				}
				if (this.ParentFXend)
				{
					this.fxEnd.transform.SetParent(base.transform, false);
				}
			}
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0006969C File Offset: 0x00067A9C
		private void UpdatePosition()
		{
			base.transform.forward = (this.EndPosition - this.StartPosition).normalized;
			for (int i = 0; i < this.vertexCount; i++)
			{
				this.vertexTemps[i] = this.StartPosition + base.transform.forward * this.DistancePerSegment * (float)i;
			}
			if (this.fxStart)
			{
				this.fxStart.transform.position = this.StartPosition;
			}
			if (this.fxEnd)
			{
				this.fxEnd.transform.position = this.EndPosition;
			}
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0006976C File Offset: 0x00067B6C
		private void Update()
		{
			if (this.StartObject)
			{
				this.StartPosition = this.StartObject.transform.position;
			}
			if (this.EndObject)
			{
				this.EndPosition = this.EndObject.transform.position;
			}
			if (this.KeepConnect)
			{
				this.UpdatePosition();
			}
			if (this.LineRender == null)
			{
				return;
			}
			if (Time.time > this.noiseIntervalTemp + this.NoiseInterval)
			{
				this.noiseIntervalTemp = Time.time;
				if (this.Noise > 0f)
				{
					for (int i = 0; i < this.vertexCount; i++)
					{
						Vector3 b = new Vector3((float)UnityEngine.Random.Range(-100, 100) * this.Noise * base.transform.up.x, (float)UnityEngine.Random.Range(-100, 100) * this.Noise * base.transform.up.y, (float)UnityEngine.Random.Range(-100, 100) * this.Noise * base.transform.up.z);
						Vector3 b2 = new Vector3((float)UnityEngine.Random.Range(-100, 100) * this.Noise * base.transform.right.x, (float)UnityEngine.Random.Range(-100, 100) * this.Noise * base.transform.right.y, (float)UnityEngine.Random.Range(-100, 100) * this.Noise * base.transform.right.z);
						this.vertexTempsTarget[i] = this.vertexTemps[i] + b2 + b;
						if (!this.Blending)
						{
							this.LineRender.SetPosition(i, this.vertexTemps[i] + b2 + b);
						}
					}
				}
			}
			if (this.Blending)
			{
				for (int j = 0; j < this.vertexCount; j++)
				{
					if (j != 0 && j != this.vertexCount - 1)
					{
						this.vertexTempsCurrent[j] = Vector3.Lerp(this.vertexTempsCurrent[j], this.vertexTempsTarget[j], 0.5f);
						this.LineRender.SetPosition(j, this.vertexTempsCurrent[j]);
					}
				}
			}
		}

		// Token: 0x040009C1 RID: 2497
		public LineRenderer LineRender;

		// Token: 0x040009C2 RID: 2498
		public bool RayCast;

		// Token: 0x040009C3 RID: 2499
		public float Length = 300f;

		// Token: 0x040009C4 RID: 2500
		public Transform StartObject;

		// Token: 0x040009C5 RID: 2501
		public Transform EndObject;

		// Token: 0x040009C6 RID: 2502
		public Vector3 EndPosition;

		// Token: 0x040009C7 RID: 2503
		public Vector3 StartPosition;

		// Token: 0x040009C8 RID: 2504
		public float DistancePerSegment = 0.5f;

		// Token: 0x040009C9 RID: 2505
		public float Noise = 0.5f;

		// Token: 0x040009CA RID: 2506
		public float NoiseInterval = 0.05f;

		// Token: 0x040009CB RID: 2507
		public bool Blending = true;

		// Token: 0x040009CC RID: 2508
		private Vector3[] vertexTemps;

		// Token: 0x040009CD RID: 2509
		private Vector3[] vertexTempsTarget;

		// Token: 0x040009CE RID: 2510
		private Vector3[] vertexTempsCurrent;

		// Token: 0x040009CF RID: 2511
		private int vertexCount;

		// Token: 0x040009D0 RID: 2512
		private float noiseIntervalTemp;

		// Token: 0x040009D1 RID: 2513
		public bool FixRotation;

		// Token: 0x040009D2 RID: 2514
		public bool Normal;

		// Token: 0x040009D3 RID: 2515
		public bool ParentFXstart = true;

		// Token: 0x040009D4 RID: 2516
		public bool ParentFXend = true;

		// Token: 0x040009D5 RID: 2517
		public GameObject FXStart;

		// Token: 0x040009D6 RID: 2518
		public GameObject FXEnd;

		// Token: 0x040009D7 RID: 2519
		private GameObject fxStart;

		// Token: 0x040009D8 RID: 2520
		private GameObject fxEnd;

		// Token: 0x040009D9 RID: 2521
		public bool KeepConnect;
	}
}
