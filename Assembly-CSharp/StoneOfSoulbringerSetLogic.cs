using System;
using System.Collections.Generic;

// Token: 0x020006A6 RID: 1702
public class StoneOfSoulbringerSetLogic : SetItemLogicBase
{
	// Token: 0x06002D23 RID: 11555 RVA: 0x0012789F File Offset: 0x00125C9F
	public StoneOfSoulbringerSetLogic()
	{
	}

	// Token: 0x170005AE RID: 1454
	// (get) Token: 0x06002D24 RID: 11556 RVA: 0x001278B2 File Offset: 0x00125CB2
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002D25 RID: 11557 RVA: 0x001278BC File Offset: 0x00125CBC
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.CritRate,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = 0.3,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002D26 RID: 11558 RVA: 0x0012790C File Offset: 0x00125D0C
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D27 RID: 11559 RVA: 0x00127913 File Offset: 0x00125D13
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D28 RID: 11560 RVA: 0x0012791C File Offset: 0x00125D1C
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StoneOfSoulbringerData
			{
				LastingSeconds = 1f
			}
		};
	}

	// Token: 0x040026A6 RID: 9894
	private ResourceType _correspondingSetResourceType = ResourceType.StoneOfSoulbringer;
}
