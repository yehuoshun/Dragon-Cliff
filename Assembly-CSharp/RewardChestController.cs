using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020003A6 RID: 934
public class RewardChestController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060018E9 RID: 6377 RVA: 0x000BFA0B File Offset: 0x000BDE0B
	public RewardChestController()
	{
	}

	// Token: 0x17000145 RID: 325
	// (get) Token: 0x060018EA RID: 6378 RVA: 0x000BFA13 File Offset: 0x000BDE13
	// (set) Token: 0x060018EB RID: 6379 RVA: 0x000BFA1B File Offset: 0x000BDE1B
	public bool IsBoxColliderEnabled
	{
		[CompilerGenerated]
		get
		{
			return this.<IsBoxColliderEnabled>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsBoxColliderEnabled>k__BackingField = value;
		}
	}

	// Token: 0x060018EC RID: 6380 RVA: 0x000BFA24 File Offset: 0x000BDE24
	public void Init(Chest chest)
	{
		this._chest = chest;
		this.RewardController.Init(chest);
	}

	// Token: 0x060018ED RID: 6381 RVA: 0x000BFA39 File Offset: 0x000BDE39
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left && this.IsBoxColliderEnabled && !this._chest.IsSelected)
		{
			this.ChestAnimator.SetTrigger("Open");
		}
	}

	// Token: 0x060018EE RID: 6382 RVA: 0x000BFA71 File Offset: 0x000BDE71
	public void ShowRewards()
	{
		this.ChestAnimator.SetTrigger("Show");
	}

	// Token: 0x060018EF RID: 6383 RVA: 0x000BFA83 File Offset: 0x000BDE83
	public void PopReward()
	{
		this.RewardController.PopReward();
	}

	// Token: 0x040018B7 RID: 6327
	public Animator ChestAnimator;

	// Token: 0x040018B8 RID: 6328
	public BattleChestRewardController RewardController;

	// Token: 0x040018B9 RID: 6329
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsBoxColliderEnabled>k__BackingField;

	// Token: 0x040018BA RID: 6330
	private Chest _chest;
}
