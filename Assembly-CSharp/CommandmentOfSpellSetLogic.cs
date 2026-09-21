using System;
using System.Collections.Generic;

// Token: 0x0200069A RID: 1690
public class CommandmentOfSpellSetLogic : SetItemLogicBase
{
	// Token: 0x06002CDB RID: 11483 RVA: 0x00126E32 File Offset: 0x00125232
	public CommandmentOfSpellSetLogic()
	{
	}

	// Token: 0x170005A2 RID: 1442
	// (get) Token: 0x06002CDC RID: 11484 RVA: 0x00126E3A File Offset: 0x0012523A
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return ResourceType.CommandmentOfSpell;
		}
	}

	// Token: 0x06002CDD RID: 11485 RVA: 0x00126E44 File Offset: 0x00125244
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

	// Token: 0x06002CDE RID: 11486 RVA: 0x00126E98 File Offset: 0x00125298
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002CDF RID: 11487 RVA: 0x00126E9F File Offset: 0x0012529F
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002CE0 RID: 11488 RVA: 0x00126EA8 File Offset: 0x001252A8
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new CommandmentOfSpellData
			{
				IsStar = false,
				Rate = 0.12
			}
		};
	}
}
