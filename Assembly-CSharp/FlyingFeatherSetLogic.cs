using System;
using System.Collections.Generic;

// Token: 0x020006A0 RID: 1696
public class FlyingFeatherSetLogic : SetItemLogicBase
{
	// Token: 0x06002CFF RID: 11519 RVA: 0x0012742C File Offset: 0x0012582C
	public FlyingFeatherSetLogic()
	{
	}

	// Token: 0x170005A8 RID: 1448
	// (get) Token: 0x06002D00 RID: 11520 RVA: 0x0012743F File Offset: 0x0012583F
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002D01 RID: 11521 RVA: 0x00127448 File Offset: 0x00125848
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.Vitality,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = 0.3,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002D02 RID: 11522 RVA: 0x00127498 File Offset: 0x00125898
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D03 RID: 11523 RVA: 0x0012749F File Offset: 0x0012589F
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D04 RID: 11524 RVA: 0x001274A8 File Offset: 0x001258A8
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new HealOverTimeData
			{
				IsStar = false,
				ReductionRate = 0.6
			}
		};
	}

	// Token: 0x040026A1 RID: 9889
	private ResourceType _correspondingSetResourceType = ResourceType.FlyingFeather;
}
