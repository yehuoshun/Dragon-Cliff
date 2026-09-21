using System;
using System.Collections.Generic;

// Token: 0x0200060D RID: 1549
public class DevilMastersBladeTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A7F RID: 10879 RVA: 0x0011F597 File Offset: 0x0011D997
	public DevilMastersBladeTemplate()
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06002A80 RID: 10880 RVA: 0x0011F59F File Offset: 0x0011D99F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DevilMastersBlade;
		}
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06002A81 RID: 10881 RVA: 0x0011F5A6 File Offset: 0x0011D9A6
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x06002A82 RID: 10882 RVA: 0x0011F5AC File Offset: 0x0011D9AC
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPoisonDamageEffectivenessChangeRate,
			AttributeType.EffectMastery
		};
	}

	// Token: 0x06002A83 RID: 10883 RVA: 0x0011F5D8 File Offset: 0x0011D9D8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeStealData
			{
				SteamPercentage = 0.3,
				StealAttributeType = AttributeType.PoisonResistance,
				MaximumStolenValue = 1000.0
			}
		};
	}
}
