using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000F0 RID: 240
	public class RaisingWall : MonoBehaviour
	{
		// Token: 0x060006B2 RID: 1714 RVA: 0x00068C04 File Offset: 0x00067004
		public RaisingWall()
		{
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00068C24 File Offset: 0x00067024
		private void Start()
		{
			if (this.Skill != null)
			{
				FX_SpawnDirection component = this.Skill.GetComponent<FX_SpawnDirection>();
				if (component)
				{
					this.Offset = (float)(-(float)((int)((float)component.Number / 2f)));
				}
			}
			this.Raising();
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00068C78 File Offset: 0x00067078
		private void Raising()
		{
			if (this.Skill != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Skill, base.transform.position + base.transform.forward * this.Distance + base.transform.right * this.Offset, this.Skill.transform.rotation);
				gameObject.transform.forward = base.transform.right;
			}
		}

		// Token: 0x040009B6 RID: 2486
		public GameObject Skill;

		// Token: 0x040009B7 RID: 2487
		public float Offset = -7f;

		// Token: 0x040009B8 RID: 2488
		public float Distance = 2f;
	}
}
