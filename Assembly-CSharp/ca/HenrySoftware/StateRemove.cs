using System;
using ca.HenrySoftware.Rage;
using UnityEngine;

namespace ca.HenrySoftware
{
	// Token: 0x020000B8 RID: 184
	public class StateRemove : StateMachineBehaviour
	{
		// Token: 0x060005E4 RID: 1508 RVA: 0x000608CE File Offset: 0x0005ECCE
		public StateRemove()
		{
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000608D8 File Offset: 0x0005ECD8
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Pool componentInParent = animator.gameObject.GetComponentInParent<Pool>();
			if (componentInParent != null)
			{
				animator.gameObject.SetActive(false);
				animator.runtimeAnimatorController = null;
				componentInParent.Exit(animator.gameObject);
			}
		}
	}
}
