using System;
using UnityEngine;

namespace ca.HenrySoftware
{
	// Token: 0x020000B6 RID: 182
	public class StateFlip : StateMachineBehaviour
	{
		// Token: 0x060005DF RID: 1503 RVA: 0x00060852 File Offset: 0x0005EC52
		public StateFlip()
		{
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0006085A File Offset: 0x0005EC5A
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.gameObject.transform.localScale = new Vector3((UnityEngine.Random.value <= 0.5f) ? -1f : 1f, 1f, 1f);
		}
	}
}
