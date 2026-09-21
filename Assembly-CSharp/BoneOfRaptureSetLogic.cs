using System;
using System.Collections.Generic;

// Token: 0x02000699 RID: 1689
public class BoneOfRaptureSetLogic : SetItemLogicBase
{
	// Token: 0x06002CD5 RID: 11477 RVA: 0x00126D67 File Offset: 0x00125167
	public BoneOfRaptureSetLogic()
	{
	}

	// Token: 0x170005A1 RID: 1441
	// (get) Token: 0x06002CD6 RID: 11478 RVA: 0x00126D7A File Offset: 0x0012517A
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002CD7 RID: 11479 RVA: 0x00126D84 File Offset: 0x00125184
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.Agility,
				Value = 0.3,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002CD8 RID: 11480 RVA: 0x00126DD4 File Offset: 0x001251D4
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.Vitality,
				ModificationType = ModificationType.Multiplication,
				Value = 0.5,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.SetBonus
			}
		};
	}

	// Token: 0x06002CD9 RID: 11481 RVA: 0x00126E24 File Offset: 0x00125224
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002CDA RID: 11482 RVA: 0x00126E2B File Offset: 0x0012522B
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0400269D RID: 9885
	private ResourceType _correspondingSetResourceType = ResourceType.BoneOfRapture;
}
