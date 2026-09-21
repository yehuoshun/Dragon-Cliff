using System;
using System.Collections.Generic;

// Token: 0x0200098C RID: 2444
[Serializable]
public class FlyingBladeEffect : TownEffectBase
{
	// Token: 0x060042F3 RID: 17139 RVA: 0x001B5497 File Offset: 0x001B3897
	public FlyingBladeEffect(int lastingNumberOfDays, int startingOnGameDays, double chance, double damageRate) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Chance = chance;
		this.DamageRate = damageRate;
	}

	// Token: 0x17000D3E RID: 3390
	// (get) Token: 0x060042F4 RID: 17140 RVA: 0x001B54B5 File Offset: 0x001B38B5
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.FlyingBladeEffect;
		}
	}

	// Token: 0x060042F5 RID: 17141 RVA: 0x001B54B8 File Offset: 0x001B38B8
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FlyingBladeData
			{
				IsStar = false,
				Chance = this.Chance,
				DamageRate = this.DamageRate
			}
		};
	}

	// Token: 0x060042F6 RID: 17142 RVA: 0x001B54F8 File Offset: 0x001B38F8
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is FlyingBladeEffect;
	}

	// Token: 0x060042F7 RID: 17143 RVA: 0x001B5504 File Offset: 0x001B3904
	public override void Merge(TownEffectBase effect)
	{
		FlyingBladeEffect flyingBladeEffect = effect as FlyingBladeEffect;
		if (flyingBladeEffect.Chance > this.Chance)
		{
			this.Chance = flyingBladeEffect.Chance;
		}
		if (flyingBladeEffect.DamageRate > this.DamageRate)
		{
			this.DamageRate = flyingBladeEffect.DamageRate;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = flyingBladeEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x060042F8 RID: 17144 RVA: 0x001B55DC File Offset: 0x001B39DC
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{rate}", this.DamageRate.ToExpressionMultiply100());
		return localization;
	}

	// Token: 0x040032F3 RID: 13043
	public double Chance;

	// Token: 0x040032F4 RID: 13044
	public double DamageRate;
}
