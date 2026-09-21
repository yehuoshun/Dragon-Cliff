using System;
using System.Collections.Generic;

// Token: 0x0200098E RID: 2446
[Serializable]
public class GodsProtectionEffect : TownEffectBase
{
	// Token: 0x060042FE RID: 17150 RVA: 0x001B567E File Offset: 0x001B3A7E
	public GodsProtectionEffect(int lastingNumberOfDays, int startingOnGameDays, double recoveryRate) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.RecoveryRate = recoveryRate;
	}

	// Token: 0x17000D40 RID: 3392
	// (get) Token: 0x060042FF RID: 17151 RVA: 0x001B5694 File Offset: 0x001B3A94
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.DodgeProtectionEffect;
		}
	}

	// Token: 0x06004300 RID: 17152 RVA: 0x001B5698 File Offset: 0x001B3A98
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DodgeProtectionData
			{
				IsStar = false,
				RecoveryRate = this.RecoveryRate
			}
		};
	}

	// Token: 0x06004301 RID: 17153 RVA: 0x001B56CC File Offset: 0x001B3ACC
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is GodsProtectionEffect;
	}

	// Token: 0x06004302 RID: 17154 RVA: 0x001B56D8 File Offset: 0x001B3AD8
	public override void Merge(TownEffectBase effect)
	{
		GodsProtectionEffect godsProtectionEffect = effect as GodsProtectionEffect;
		if (godsProtectionEffect.RecoveryRate > this.RecoveryRate)
		{
			this.RecoveryRate = godsProtectionEffect.RecoveryRate;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = godsProtectionEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x06004303 RID: 17155 RVA: 0x001B5794 File Offset: 0x001B3B94
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{rate}", this.RecoveryRate.ToExpressionMultiply100());
		return localization;
	}

	// Token: 0x040032F6 RID: 13046
	public double RecoveryRate;
}
