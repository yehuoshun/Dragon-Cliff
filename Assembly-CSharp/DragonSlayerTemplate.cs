using System;
using System.Collections.Generic;

// Token: 0x020005FB RID: 1531
public class DragonSlayerTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A24 RID: 10788 RVA: 0x0011ECD4 File Offset: 0x0011D0D4
	public DragonSlayerTemplate()
	{
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06002A25 RID: 10789 RVA: 0x0011ECDC File Offset: 0x0011D0DC
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DragonSlayer;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06002A26 RID: 10790 RVA: 0x0011ECE3 File Offset: 0x0011D0E3
	public override int ItemTierNumber
	{
		get
		{
			return 34;
		}
	}

	// Token: 0x06002A27 RID: 10791 RVA: 0x0011ECE8 File Offset: 0x0011D0E8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealShadowDamageEffectivenessChangeRate
		};
	}

	// Token: 0x06002A28 RID: 10792 RVA: 0x0011ED08 File Offset: 0x0011D108
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeDestroyData
			{
				Chance = 0.22 + (double)(grade - QualityGrade.Normal) * 0.02,
				ReplaceAttribute = AttributeType.PhysicalResistance,
				ReplacementValue = 0.0
			}
		};
	}
}
