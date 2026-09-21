using System;
using UnityEngine;

namespace CodeStage.AntiCheat.Examples
{
	// Token: 0x02000002 RID: 2
	[AddComponentMenu("")]
	public class ActRotatorExample : MonoBehaviour
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000450
		public ActRotatorExample()
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002063 File Offset: 0x00000463
		private void Update()
		{
			base.transform.Rotate(0f, this.speed * Time.deltaTime, 0f);
		}

		// Token: 0x04000001 RID: 1
		[Range(1f, 100f)]
		public float speed = 5f;
	}
}
