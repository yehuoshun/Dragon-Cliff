using System;
using System.Collections.Generic;

// Token: 0x0200098F RID: 2447
[Serializable]
public class LuckyChestEffect : TownEffectBase
{
	// Token: 0x06004304 RID: 17156 RVA: 0x001B57CA File Offset: 0x001B3BCA
	public LuckyChestEffect(int lastingNumberOfDays, int startingOnGameDays, double rate) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Rate = rate;
	}

	// Token: 0x17000D41 RID: 3393
	// (get) Token: 0x06004305 RID: 17157 RVA: 0x001B57E0 File Offset: 0x001B3BE0
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.LuckyChestEffect;
		}
	}

	// Token: 0x06004306 RID: 17158 RVA: 0x001B57E4 File Offset: 0x001B3BE4
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GodBlessedData
			{
				IsStar = false,
				Chance = this.Rate
			}
		};
	}

	// Token: 0x06004307 RID: 17159 RVA: 0x001B5818 File Offset: 0x001B3C18
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is LuckyChestEffect;
	}

	// Token: 0x06004308 RID: 17160 RVA: 0x001B5824 File Offset: 0x001B3C24
	public override void Merge(TownEffectBase effect)
	{
		LuckyChestEffect luckyChestEffect = effect as LuckyChestEffect;
		if (luckyChestEffect.Rate > this.Rate)
		{
			this.Rate = luckyChestEffect.Rate;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = luckyChestEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x06004309 RID: 17161 RVA: 0x001B58E0 File Offset: 0x001B3CE0
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return localization;
	}

	// Token: 0x040032F7 RID: 13047
	public double Rate;
}
