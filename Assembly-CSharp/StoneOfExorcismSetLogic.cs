using System;
using System.Collections.Generic;

// Token: 0x020006A5 RID: 1701
public class StoneOfExorcismSetLogic : SetItemLogicBase
{
	// Token: 0x06002D1D RID: 11549 RVA: 0x001277FA File Offset: 0x00125BFA
	public StoneOfExorcismSetLogic()
	{
	}

	// Token: 0x170005AD RID: 1453
	// (get) Token: 0x06002D1E RID: 11550 RVA: 0x00127802 File Offset: 0x00125C02
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return ResourceType.StoneOfExorcism;
		}
	}

	// Token: 0x06002D1F RID: 11551 RVA: 0x0012780C File Offset: 0x00125C0C
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.DodgeRateAdjustment,
				ModificationType = ModificationType.Addition,
				Value = 0.15,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.SetBonus
			}
		};
	}

	// Token: 0x06002D20 RID: 11552 RVA: 0x00127860 File Offset: 0x00125C60
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D21 RID: 11553 RVA: 0x00127867 File Offset: 0x00125C67
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D22 RID: 11554 RVA: 0x00127870 File Offset: 0x00125C70
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DispelOnHealData
			{
				IsStar = false,
				NumberOfDispels = 2
			}
		};
	}
}
