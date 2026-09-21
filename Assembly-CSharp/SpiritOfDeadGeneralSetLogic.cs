using System;
using System.Collections.Generic;

// Token: 0x020006A4 RID: 1700
public class SpiritOfDeadGeneralSetLogic : SetItemLogicBase
{
	// Token: 0x06002D17 RID: 11543 RVA: 0x00127737 File Offset: 0x00125B37
	public SpiritOfDeadGeneralSetLogic()
	{
	}

	// Token: 0x170005AC RID: 1452
	// (get) Token: 0x06002D18 RID: 11544 RVA: 0x0012774A File Offset: 0x00125B4A
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002D19 RID: 11545 RVA: 0x00127754 File Offset: 0x00125B54
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.Strength,
				Value = 0.25,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002D1A RID: 11546 RVA: 0x001277A4 File Offset: 0x00125BA4
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D1B RID: 11547 RVA: 0x001277AB File Offset: 0x00125BAB
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D1C RID: 11548 RVA: 0x001277B4 File Offset: 0x00125BB4
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ResistanceKillBoostData
			{
				IsStar = false,
				BoostRate = 0.2,
				MaxRate = 1.0
			}
		};
	}

	// Token: 0x040026A5 RID: 9893
	private ResourceType _correspondingSetResourceType = ResourceType.SpiritOfDeadGeneral;
}
