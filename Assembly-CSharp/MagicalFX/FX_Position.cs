using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E7 RID: 231
	public class FX_Position : MonoBehaviour
	{
		// Token: 0x06000698 RID: 1688 RVA: 0x00068419 File Offset: 0x00066819
		public FX_Position()
		{
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0006843B File Offset: 0x0006683B
		private void Start()
		{
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0006843D File Offset: 0x0006683D
		private void Awake()
		{
			if (this.Normal)
			{
				this.PlaceNormal(base.transform.position);
			}
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0006845C File Offset: 0x0006685C
		public void PlaceNormal(Vector3 position)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(position, -Vector3.up * 100f, out raycastHit))
			{
				base.transform.position = raycastHit.point + this.Offset;
				base.transform.forward = raycastHit.normal;
			}
			else
			{
				base.transform.position = position + this.Offset;
			}
		}

		// Token: 0x0400098D RID: 2445
		public Vector3 Offset = new Vector3(0f, 0.001f, 0f);

		// Token: 0x0400098E RID: 2446
		public bool Normal;

		// Token: 0x0400098F RID: 2447
		public SpawnMode Mode;
	}
}
