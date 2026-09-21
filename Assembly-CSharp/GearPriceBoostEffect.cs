using System;

// Token: 0x0200098D RID: 2445
[Serializable]
public class GearPriceBoostEffect : TownEffectBase
{
	// Token: 0x060042F9 RID: 17145 RVA: 0x001B5627 File Offset: 0x001B3A27
	public GearPriceBoostEffect(int lastingNumberOfDays, int startingOnGameDays, double rate) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Rate = rate;
	}

	// Token: 0x17000D3F RID: 3391
	// (get) Token: 0x060042FA RID: 17146 RVA: 0x001B563D File Offset: 0x001B3A3D
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.GearPriceBoost;
		}
	}

	// Token: 0x060042FB RID: 17147 RVA: 0x001B5640 File Offset: 0x001B3A40
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return false;
	}

	// Token: 0x060042FC RID: 17148 RVA: 0x001B5643 File Offset: 0x001B3A43
	public override void Merge(TownEffectBase effect)
	{
	}

	// Token: 0x060042FD RID: 17149 RVA: 0x001B5648 File Offset: 0x001B3A48
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return localization;
	}

	// Token: 0x040032F5 RID: 13045
	public double Rate;
}
