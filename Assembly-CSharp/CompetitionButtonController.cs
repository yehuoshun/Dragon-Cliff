using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000382 RID: 898
public class CompetitionButtonController : MonoBehaviour
{
	// Token: 0x0600182E RID: 6190 RVA: 0x000B9717 File Offset: 0x000B7B17
	public CompetitionButtonController()
	{
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x000B971F File Offset: 0x000B7B1F
	private void Start()
	{
		this._animator = base.GetComponent<Animator>();
		this.CompetitionEnded();
		base.GetComponentInChildren<Button>().onClick.AddListener(new UnityAction(this.CompetitionClick));
	}

	// Token: 0x06001830 RID: 6192 RVA: 0x000B974F File Offset: 0x000B7B4F
	public void CompetitionClick()
	{
	}

	// Token: 0x06001831 RID: 6193 RVA: 0x000B9751 File Offset: 0x000B7B51
	public void CompetitionStarted()
	{
		this._animator.SetBool("isFlashing", true);
	}

	// Token: 0x06001832 RID: 6194 RVA: 0x000B9764 File Offset: 0x000B7B64
	public void CompetitionEnded()
	{
		this._animator.SetBool("isFlashing", false);
	}

	// Token: 0x040017EB RID: 6123
	private Animator _animator;
}
