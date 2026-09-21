using System;
using System.Collections.Generic;

// Token: 0x020006A2 RID: 1698
public class MonksEyesSetLogic : SetItemLogicBase
{
	// Token: 0x06002D0B RID: 11531 RVA: 0x001275A1 File Offset: 0x001259A1
	public MonksEyesSetLogic()
	{
	}

	// Token: 0x170005AA RID: 1450
	// (get) Token: 0x06002D0C RID: 11532 RVA: 0x001275B4 File Offset: 0x001259B4
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002D0D RID: 11533 RVA: 0x001275BC File Offset: 0x001259BC
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.Allresistances,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = 0.4,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002D0E RID: 11534 RVA: 0x00127610 File Offset: 0x00125A10
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.DodgeRateAdjustment,
				ModificationType = ModificationType.Addition,
				Value = 0.1,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.SetBonus
			}
		};
	}

	// Token: 0x06002D0F RID: 11535 RVA: 0x00127664 File Offset: 0x00125A64
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D10 RID: 11536 RVA: 0x0012766C File Offset: 0x00125A6C
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new MonksEyesData
			{
				MaxLoss = 0.35
			}
		};
	}

	// Token: 0x040026A3 RID: 9891
	private ResourceType _correspondingSetResourceType = ResourceType.MonksEyes;
}
