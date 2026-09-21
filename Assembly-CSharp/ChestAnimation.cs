using System;
using UnityEngine;

// Token: 0x0200037D RID: 893
public class ChestAnimation : MonoBehaviour
{
	// Token: 0x06001809 RID: 6153 RVA: 0x000B946C File Offset: 0x000B786C
	public ChestAnimation()
	{
	}

	// Token: 0x0600180A RID: 6154 RVA: 0x000B9474 File Offset: 0x000B7874
	private void Awake()
	{
		this._animator = base.GetComponent<Animator>();
	}

	// Token: 0x0600180B RID: 6155 RVA: 0x000B9482 File Offset: 0x000B7882
	public void OpenChest()
	{
		this._animator.SetTrigger("Open");
	}

	// Token: 0x0600180C RID: 6156 RVA: 0x000B9494 File Offset: 0x000B7894
	private void OnDisable()
	{
	}

	// Token: 0x0600180D RID: 6157 RVA: 0x000B9496 File Offset: 0x000B7896
	public void ResetChest()
	{
		this._animator.SetTrigger("Reset");
	}

	// Token: 0x040017D2 RID: 6098
	private Animator _animator;
}
