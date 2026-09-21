using System;
using System.Collections.Generic;

// Token: 0x020006A1 RID: 1697
public class GodsMoralSetLogic : SetItemLogicBase
{
	// Token: 0x06002D05 RID: 11525 RVA: 0x001274DF File Offset: 0x001258DF
	public GodsMoralSetLogic()
	{
	}

	// Token: 0x170005A9 RID: 1449
	// (get) Token: 0x06002D06 RID: 11526 RVA: 0x001274F2 File Offset: 0x001258F2
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002D07 RID: 11527 RVA: 0x001274FC File Offset: 0x001258FC
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.Agility,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = 0.3,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002D08 RID: 11528 RVA: 0x0012754C File Offset: 0x0012594C
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D09 RID: 11529 RVA: 0x00127553 File Offset: 0x00125953
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D0A RID: 11530 RVA: 0x0012755C File Offset: 0x0012595C
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AgilityIdleBoostData
			{
				IsStar = false,
				BoostRate = 0.8,
				CoolingDownSeconds = 1,
				Counter = 0
			}
		};
	}

	// Token: 0x040026A2 RID: 9890
	private ResourceType _correspondingSetResourceType = ResourceType.GodsMoral;
}
