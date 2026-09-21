using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B5B RID: 2907
	public class ObjectSpin : MonoBehaviour
	{
		// Token: 0x06004D23 RID: 19747 RVA: 0x001F4BF9 File Offset: 0x001F2FF9
		public ObjectSpin()
		{
		}

		// Token: 0x06004D24 RID: 19748 RVA: 0x001F4C14 File Offset: 0x001F3014
		private void Awake()
		{
			this.m_transform = base.transform;
			this.m_initial_Rotation = this.m_transform.rotation.eulerAngles;
			this.m_initial_Position = this.m_transform.position;
			Light component = base.GetComponent<Light>();
			this.m_lightColor = ((!(component != null)) ? Color.black : component.color);
		}

		// Token: 0x06004D25 RID: 19749 RVA: 0x001F4C88 File Offset: 0x001F3088
		private void Update()
		{
			if (this.Motion == ObjectSpin.MotionType.Rotation)
			{
				this.m_transform.Rotate(0f, this.SpinSpeed * Time.deltaTime, 0f);
			}
			else if (this.Motion == ObjectSpin.MotionType.BackAndForth)
			{
				this.m_time += this.SpinSpeed * Time.deltaTime;
				this.m_transform.rotation = Quaternion.Euler(this.m_initial_Rotation.x, Mathf.Sin(this.m_time) * (float)this.RotationRange + this.m_initial_Rotation.y, this.m_initial_Rotation.z);
			}
			else
			{
				this.m_time += this.SpinSpeed * Time.deltaTime;
				float x = 15f * Mathf.Cos(this.m_time * 0.95f);
				float z = 10f;
				float y = 0f;
				this.m_transform.position = this.m_initial_Position + new Vector3(x, y, z);
				this.m_prevPOS = this.m_transform.position;
				this.frames++;
			}
		}

		// Token: 0x04003B85 RID: 15237
		public float SpinSpeed = 5f;

		// Token: 0x04003B86 RID: 15238
		public int RotationRange = 15;

		// Token: 0x04003B87 RID: 15239
		private Transform m_transform;

		// Token: 0x04003B88 RID: 15240
		private float m_time;

		// Token: 0x04003B89 RID: 15241
		private Vector3 m_prevPOS;

		// Token: 0x04003B8A RID: 15242
		private Vector3 m_initial_Rotation;

		// Token: 0x04003B8B RID: 15243
		private Vector3 m_initial_Position;

		// Token: 0x04003B8C RID: 15244
		private Color32 m_lightColor;

		// Token: 0x04003B8D RID: 15245
		private int frames;

		// Token: 0x04003B8E RID: 15246
		public ObjectSpin.MotionType Motion;

		// Token: 0x02000B5C RID: 2908
		public enum MotionType
		{
			// Token: 0x04003B90 RID: 15248
			Rotation,
			// Token: 0x04003B91 RID: 15249
			BackAndForth,
			// Token: 0x04003B92 RID: 15250
			Translation
		}
	}
}
