using System;
using System.Collections.Generic;

// Token: 0x02000993 RID: 2451
[Serializable]
public class StopperTownEffect : TownEffectBase
{
	// Token: 0x0600431C RID: 17180 RVA: 0x001B5D46 File Offset: 0x001B4146
	public StopperTownEffect(int lastingNumberOfDays, int startingOnGameDays, double chance, int lastingSeconds) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Chance = chance;
		this.LastingSeconds = lastingSeconds;
	}

	// Token: 0x17000D45 RID: 3397
	// (get) Token: 0x0600431D RID: 17181 RVA: 0x001B5D64 File Offset: 0x001B4164
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.StopperEffect;
		}
	}

	// Token: 0x0600431E RID: 17182 RVA: 0x001B5D68 File Offset: 0x001B4168
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StopperEffectData
			{
				IsStar = false,
				Chance = this.Chance,
				LastingSeconds = this.LastingSeconds
			}
		};
	}

	// Token: 0x0600431F RID: 17183 RVA: 0x001B5DA8 File Offset: 0x001B41A8
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is StopperTownEffect;
	}

	// Token: 0x06004320 RID: 17184 RVA: 0x001B5DB4 File Offset: 0x001B41B4
	public override void Merge(TownEffectBase effect)
	{
		StopperTownEffect stopperTownEffect = effect as StopperTownEffect;
		if (stopperTownEffect.Chance > this.Chance)
		{
			this.Chance = stopperTownEffect.Chance;
		}
		if (stopperTownEffect.LastingSeconds > this.LastingSeconds)
		{
			this.LastingSeconds = stopperTownEffect.LastingSeconds;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = stopperTownEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x06004321 RID: 17185 RVA: 0x001B5E8C File Offset: 0x001B428C
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.ToString());
		return localization;
	}

	// Token: 0x040032FF RID: 13055
	public double Chance;

	// Token: 0x04003300 RID: 13056
	public int LastingSeconds;
}
