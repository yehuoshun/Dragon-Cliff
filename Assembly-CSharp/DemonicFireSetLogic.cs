using System;
using System.Collections.Generic;

// Token: 0x0200069B RID: 1691
public class DemonicFireSetLogic : SetItemLogicBase
{
	// Token: 0x06002CE1 RID: 11489 RVA: 0x00126EDF File Offset: 0x001252DF
	public DemonicFireSetLogic()
	{
	}

	// Token: 0x170005A3 RID: 1443
	// (get) Token: 0x06002CE2 RID: 11490 RVA: 0x00126EF2 File Offset: 0x001252F2
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002CE3 RID: 11491 RVA: 0x00126EFC File Offset: 0x001252FC
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealFireDamageEffectivenessChangeRate,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = 0.5,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002CE4 RID: 11492 RVA: 0x00126F50 File Offset: 0x00125350
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002CE5 RID: 11493 RVA: 0x00126F57 File Offset: 0x00125357
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002CE6 RID: 11494 RVA: 0x00126F60 File Offset: 0x00125360
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DemonicFireData(),
			new FieryTaleEffectData
			{
				IsStarEf = new bool?(false),
				FiresPerHit = 1,
				StartFires = 1
			}
		};
	}

	// Token: 0x0400269E RID: 9886
	private ResourceType _correspondingSetResourceType = ResourceType.DemonicFire;
}
