using System;
using System.Collections.Generic;

// Token: 0x0200069E RID: 1694
public class EyeOfPrecisionSetLogic : SetItemLogicBase
{
	// Token: 0x06002CF3 RID: 11507 RVA: 0x0012714E File Offset: 0x0012554E
	public EyeOfPrecisionSetLogic()
	{
	}

	// Token: 0x170005A6 RID: 1446
	// (get) Token: 0x06002CF4 RID: 11508 RVA: 0x00127156 File Offset: 0x00125556
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return ResourceType.EyeOfPrecision;
		}
	}

	// Token: 0x06002CF5 RID: 11509 RVA: 0x00127160 File Offset: 0x00125560
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.HitRateAdjustment,
				ModificationType = ModificationType.Addition,
				Value = 0.1,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.SetBonus
			}
		};
	}

	// Token: 0x06002CF6 RID: 11510 RVA: 0x001271B4 File Offset: 0x001255B4
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002CF7 RID: 11511 RVA: 0x001271BB File Offset: 0x001255BB
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002CF8 RID: 11512 RVA: 0x001271C4 File Offset: 0x001255C4
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new EyeOfPrecisionEffectData
			{
				IsStar = false,
				Rate = 0.1
			}
		};
	}
}
