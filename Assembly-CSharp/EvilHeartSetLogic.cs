using System;
using System.Collections.Generic;

// Token: 0x0200069D RID: 1693
public class EvilHeartSetLogic : SetItemLogicBase
{
	// Token: 0x06002CED RID: 11501 RVA: 0x00127093 File Offset: 0x00125493
	public EvilHeartSetLogic()
	{
	}

	// Token: 0x170005A5 RID: 1445
	// (get) Token: 0x06002CEE RID: 11502 RVA: 0x0012709B File Offset: 0x0012549B
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return ResourceType.EvilHeart;
		}
	}

	// Token: 0x06002CEF RID: 11503 RVA: 0x001270A4 File Offset: 0x001254A4
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.EffectMastery,
				ModificationType = ModificationType.Addition,
				Value = 1.0,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.SetBonus
			}
		};
	}

	// Token: 0x06002CF0 RID: 11504 RVA: 0x001270F8 File Offset: 0x001254F8
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002CF1 RID: 11505 RVA: 0x001270FF File Offset: 0x001254FF
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002CF2 RID: 11506 RVA: 0x00127108 File Offset: 0x00125508
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new EvilHeartData
			{
				IsStar = false,
				MasteryRate = 1.0,
				HitRate = 0.02
			}
		};
	}
}
