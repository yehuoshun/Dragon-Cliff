using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200037F RID: 895
public class ChestLayout : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x0600180E RID: 6158 RVA: 0x000B94A8 File Offset: 0x000B78A8
	public ChestLayout()
	{
	}

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x000B94BB File Offset: 0x000B78BB
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x000B94C3 File Offset: 0x000B78C3
	public bool isBoxColliderEnabled
	{
		[CompilerGenerated]
		get
		{
			return this.<isBoxColliderEnabled>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<isBoxColliderEnabled>k__BackingField = value;
		}
	}

	// Token: 0x06001811 RID: 6161 RVA: 0x000B94CC File Offset: 0x000B78CC
	public void PlayShakeClip()
	{
		this.PlaySoundClip(this.ShakeClip);
	}

	// Token: 0x06001812 RID: 6162 RVA: 0x000B94DA File Offset: 0x000B78DA
	public void PlayOpenClip()
	{
		this.PlaySoundClip(this.OpenClip);
	}

	// Token: 0x06001813 RID: 6163 RVA: 0x000B94E8 File Offset: 0x000B78E8
	public Chest GetChest()
	{
		return this._chest;
	}

	// Token: 0x06001814 RID: 6164 RVA: 0x000B94F0 File Offset: 0x000B78F0
	public void InitChest(ChestType chestType)
	{
		this.SetBasicSprites(FilePath.GetChestImagesByType(chestType));
	}

	// Token: 0x06001815 RID: 6165 RVA: 0x000B94FE File Offset: 0x000B78FE
	private void SetBasicSprites(ChestLayoutImages appearance)
	{
	}

	// Token: 0x06001816 RID: 6166 RVA: 0x000B9500 File Offset: 0x000B7900
	public void SetChest(Chest chest, Spawner Spwaner)
	{
		this._chest = chest;
		this._spwaner = Spwaner;
		this.RewardController.Init(chest);
	}

	// Token: 0x06001817 RID: 6167 RVA: 0x000B951C File Offset: 0x000B791C
	public void StartAnimation()
	{
		base.gameObject.GetComponent<ChestAnimation>().OpenChest();
	}

	// Token: 0x06001818 RID: 6168 RVA: 0x000B952E File Offset: 0x000B792E
	public void ShowReward()
	{
		this.RewardController.ShowReward();
		this.ChestAnimator.SetTrigger("Show");
	}

	// Token: 0x06001819 RID: 6169 RVA: 0x000B954B File Offset: 0x000B794B
	public void OpenChest()
	{
		this.ChestAnimator.SetTrigger("Open");
	}

	// Token: 0x0600181A RID: 6170 RVA: 0x000B955D File Offset: 0x000B795D
	public void PopReward()
	{
		this.RewardController.PopReward();
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x000B956A File Offset: 0x000B796A
	public void BrustRewards(bool isFadeing = false)
	{
		this.StartAnimation();
		this._rewards.Add(PopupRewardsController.CreateNewRewardPopup(base.transform, 0, this._chest, isFadeing));
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x000B9590 File Offset: 0x000B7990
	public void ResetRewardsPosition()
	{
		this._rewards.ForEach(delegate(PopingUpRewards r)
		{
			r.ResetPosition();
			GameObjectUtil.RecycleDestroy(r.gameObject);
			this.isBoxColliderEnabled = false;
		});
		this._rewards.Clear();
		this.ChestAnimator.SetTrigger("Reset");
		this.RewardController.Reset();
	}

	// Token: 0x0600181D RID: 6173 RVA: 0x000B95CF File Offset: 0x000B79CF
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left && this.isBoxColliderEnabled && !this._chest.IsSelected)
		{
			this.SelectChest();
		}
	}

	// Token: 0x0600181E RID: 6174 RVA: 0x000B95FD File Offset: 0x000B79FD
	public void SelectChest()
	{
		this._spwaner.SetClickedChest(this._chest);
		this.OpenChest();
		this._chest.Select();
	}

	// Token: 0x0600181F RID: 6175 RVA: 0x000B9621 File Offset: 0x000B7A21
	[CompilerGenerated]
	private void <ResetRewardsPosition>m__0(PopingUpRewards r)
	{
		r.ResetPosition();
		GameObjectUtil.RecycleDestroy(r.gameObject);
		this.isBoxColliderEnabled = false;
	}

	// Token: 0x040017DC RID: 6108
	public Animator ChestAnimator;

	// Token: 0x040017DD RID: 6109
	public AudioClip ShakeClip;

	// Token: 0x040017DE RID: 6110
	public AudioClip OpenClip;

	// Token: 0x040017DF RID: 6111
	public BattleChestRewardController RewardController;

	// Token: 0x040017E0 RID: 6112
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <isBoxColliderEnabled>k__BackingField;

	// Token: 0x040017E1 RID: 6113
	private readonly List<PopingUpRewards> _rewards = new List<PopingUpRewards>();

	// Token: 0x040017E2 RID: 6114
	private Chest _chest;

	// Token: 0x040017E3 RID: 6115
	private Spawner _spwaner;
}
