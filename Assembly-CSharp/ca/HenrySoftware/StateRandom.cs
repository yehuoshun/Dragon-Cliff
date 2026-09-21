using System;
using UnityEngine;

namespace ca.HenrySoftware
{
	// Token: 0x020000B7 RID: 183
	public class StateRandom : StateMachineBehaviour
	{
		// Token: 0x060005E1 RID: 1505 RVA: 0x00060899 File Offset: 0x0005EC99
		public StateRandom()
		{
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000608A1 File Offset: 0x0005ECA1
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetFloat(StateRandom.AnimatorRandom, UnityEngine.Random.Range(0f, 1f));
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000608BD File Offset: 0x0005ECBD
		// Note: this type is marked as 'beforefieldinit'.
		static StateRandom()
		{
		}

		// Token: 0x040008DF RID: 2271
		private static int AnimatorRandom = Animator.StringToHash("Random");
	}
}
