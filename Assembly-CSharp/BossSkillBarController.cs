using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000156 RID: 342
public class BossSkillBarController : MonoBehaviour
{
	// Token: 0x06000942 RID: 2370 RVA: 0x0007A4C0 File Offset: 0x000788C0
	public BossSkillBarController()
	{
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x0007A4C8 File Offset: 0x000788C8
	private void Update()
	{
		if (this._effectTrigger)
		{
			if (this._effect is InversedMandateData)
			{
				InversedMandateData inversedMandateData = this._effect as InversedMandateData;
				this.UpdateChargeBar(inversedMandateData.Charged);
			}
			if (this._effect is DemonSkullData)
			{
				DemonSkullData demonSkullData = this._effect as DemonSkullData;
				this.UpdateChargeBar(demonSkullData.SoulCharged);
			}
		}
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x0007A530 File Offset: 0x00078930
	public void Init(ISpecialEffectDataLoad effect)
	{
		this._effect = effect;
		this.EffectNameText.text = effect.GetDescription().Title;
		this.Fill.fillAmount = 0f;
		this._effectTrigger = true;
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x0007A566 File Offset: 0x00078966
	public void UpdateChargeBar(double charge)
	{
		this.Fill.fillAmount = (float)charge / 1f;
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x0007A57B File Offset: 0x0007897B
	public void Hide()
	{
		this._effectTrigger = false;
		this._effect = null;
		this.Fill.fillAmount = 0f;
	}

	// Token: 0x04000BF6 RID: 3062
	public TextMeshProUGUI EffectNameText;

	// Token: 0x04000BF7 RID: 3063
	public Image Fill;

	// Token: 0x04000BF8 RID: 3064
	private ISpecialEffectDataLoad _effect;

	// Token: 0x04000BF9 RID: 3065
	private bool _effectTrigger;
}
