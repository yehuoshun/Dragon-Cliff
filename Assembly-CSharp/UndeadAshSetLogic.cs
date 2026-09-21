using System;
using System.Collections.Generic;

// Token: 0x020006A7 RID: 1703
public class UndeadAshSetLogic : SetItemLogicBase
{
	// Token: 0x06002D29 RID: 11561 RVA: 0x00127948 File Offset: 0x00125D48
	public UndeadAshSetLogic()
	{
	}

	// Token: 0x170005AF RID: 1455
	// (get) Token: 0x06002D2A RID: 11562 RVA: 0x0012795B File Offset: 0x00125D5B
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002D2B RID: 11563 RVA: 0x00127964 File Offset: 0x00125D64
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.CritDamage,
				Value = 0.8,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002D2C RID: 11564 RVA: 0x001279B4 File Offset: 0x00125DB4
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D2D RID: 11565 RVA: 0x001279BB File Offset: 0x00125DBB
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D2E RID: 11566 RVA: 0x001279C4 File Offset: 0x00125DC4
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new UndeadAshData
			{
				DamageSoFar = 0.0,
				PerIncreaseRate = 0.4,
				PerLossRate = 0.1,
				PreviousLossLayers = 0
			}
		};
	}

	// Token: 0x040026A7 RID: 9895
	private ResourceType _correspondingSetResourceType = ResourceType.UndeadAsh;
}
