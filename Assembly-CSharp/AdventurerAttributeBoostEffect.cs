using System;
using System.Collections.Generic;

// Token: 0x0200098A RID: 2442
[Serializable]
public class AdventurerAttributeBoostEffect : TownEffectBase
{
	// Token: 0x060042E7 RID: 17127 RVA: 0x001B5159 File Offset: 0x001B3559
	public AdventurerAttributeBoostEffect(int lastingNumberOfDays, int startingOnGameDays, double value, AttributeType attributeType, ModificationType modificationType) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Value = value;
		this.AttributeType = attributeType;
		this.ModificationType = modificationType;
	}

	// Token: 0x17000D3C RID: 3388
	// (get) Token: 0x060042E8 RID: 17128 RVA: 0x001B517F File Offset: 0x001B357F
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.AdventurerAttributeBoost;
		}
	}

	// Token: 0x060042E9 RID: 17129 RVA: 0x001B5184 File Offset: 0x001B3584
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{type}", this.AttributeType.GetDescription().Title).Replace("{value}", (this.ModificationType != ModificationType.Multiplication) ? ((!this.AttributeType.IsPercentageValue()) ? this.Value.ToExpression() : (this.Value.ToExpressionMultiply100() + "%")) : (this.Value.ToExpressionMultiply100() + "%"));
		return localization;
	}

	// Token: 0x060042EA RID: 17130 RVA: 0x001B5224 File Offset: 0x001B3624
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeBoostData
			{
				IsStar = false,
				MultiplicationBoosts = ((this.ModificationType != ModificationType.Multiplication) ? new List<BoostSetting>() : new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = this.Value,
						BoostAttribute = this.AttributeType
					}
				}),
				AdditionBoosts = ((this.ModificationType != ModificationType.Addition) ? new List<BoostSetting>() : new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = this.Value,
						BoostAttribute = this.AttributeType
					}
				})
			}
		};
	}

	// Token: 0x060042EB RID: 17131 RVA: 0x001B52DC File Offset: 0x001B36DC
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		if (effect is AdventurerAttributeBoostEffect)
		{
			AdventurerAttributeBoostEffect adventurerAttributeBoostEffect = effect as AdventurerAttributeBoostEffect;
			if (adventurerAttributeBoostEffect.AttributeType == this.AttributeType && adventurerAttributeBoostEffect.ModificationType == this.ModificationType)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060042EC RID: 17132 RVA: 0x001B5320 File Offset: 0x001B3720
	public override void Merge(TownEffectBase effect)
	{
		AdventurerAttributeBoostEffect adventurerAttributeBoostEffect = effect as AdventurerAttributeBoostEffect;
		if (adventurerAttributeBoostEffect.Value > this.Value)
		{
			this.Value = adventurerAttributeBoostEffect.Value;
		}
		if (adventurerAttributeBoostEffect.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = effect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
		}
	}

	// Token: 0x040032EE RID: 13038
	public double Value;

	// Token: 0x040032EF RID: 13039
	public AttributeType AttributeType;

	// Token: 0x040032F0 RID: 13040
	public ModificationType ModificationType;
}
