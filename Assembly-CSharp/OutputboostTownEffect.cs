using System;
using System.Collections.Generic;

// Token: 0x02000990 RID: 2448
[Serializable]
public class OutputboostTownEffect : TownEffectBase
{
	// Token: 0x0600430A RID: 17162 RVA: 0x001B5916 File Offset: 0x001B3D16
	public OutputboostTownEffect(int lastingNumberOfDays, int startingOnGameDays, double value, ModificationType modificationType) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Value = value;
		this.ModificationType = modificationType;
	}

	// Token: 0x17000D42 RID: 3394
	// (get) Token: 0x0600430B RID: 17163 RVA: 0x001B5934 File Offset: 0x001B3D34
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.OutputBoost;
		}
	}

	// Token: 0x0600430C RID: 17164 RVA: 0x001B5938 File Offset: 0x001B3D38
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new OutputBoostOnStartData
			{
				IsStar = false,
				ModificationType = this.ModificationType,
				Value = this.Value
			}
		};
	}

	// Token: 0x0600430D RID: 17165 RVA: 0x001B5978 File Offset: 0x001B3D78
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		if (effect is OutputboostTownEffect)
		{
			OutputboostTownEffect outputboostTownEffect = effect as OutputboostTownEffect;
			if (outputboostTownEffect.ModificationType == this.ModificationType)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600430E RID: 17166 RVA: 0x001B59AC File Offset: 0x001B3DAC
	public override void Merge(TownEffectBase effect)
	{
		OutputboostTownEffect outputboostTownEffect = effect as OutputboostTownEffect;
		if (outputboostTownEffect.Value > this.Value)
		{
			this.Value = outputboostTownEffect.Value;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = outputboostTownEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x0600430F RID: 17167 RVA: 0x001B5A68 File Offset: 0x001B3E68
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{value}", (this.ModificationType != ModificationType.Multiplication) ? this.Value.ToExpression() : (this.Value.ToExpressionMultiply100() + "%"));
		return localization;
	}

	// Token: 0x040032F8 RID: 13048
	public double Value;

	// Token: 0x040032F9 RID: 13049
	public ModificationType ModificationType;
}
