using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200039C RID: 924
public class PopingUpRewards : MonoBehaviour
{
	// Token: 0x060018B0 RID: 6320 RVA: 0x000BEDB5 File Offset: 0x000BD1B5
	public PopingUpRewards()
	{
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x000BEDBD File Offset: 0x000BD1BD
	private void Awake()
	{
		this.animator = base.GetComponentInChildren<Animator>();
		this._rewardImage = this.animator.GetComponentInChildren<Image>();
	}

	// Token: 0x060018B2 RID: 6322 RVA: 0x000BEDDC File Offset: 0x000BD1DC
	public void SetupImage(Chest chest, bool isFading)
	{
		this._rewardImage.sprite = FilePath.GetRewardInChestImage(chest.Grade);
		this.animator.SetBool((!isFading) ? "NormalPop" : "FadePop", true);
	}

	// Token: 0x060018B3 RID: 6323 RVA: 0x000BEE15 File Offset: 0x000BD215
	public void ResetPosition()
	{
		this.animator.SetBool("NormalPop", false);
		this.animator.SetBool("FadePop", false);
		this.animator.SetTrigger("Reset");
	}

	// Token: 0x0400188B RID: 6283
	private Animator animator;

	// Token: 0x0400188C RID: 6284
	private Image _rewardImage;
}
