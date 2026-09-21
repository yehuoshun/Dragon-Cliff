using System;
using System.Collections.Generic;

// Token: 0x02000623 RID: 1571
public class DragonSpearTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002AD7 RID: 10967 RVA: 0x0011FC17 File Offset: 0x0011E017
	public DragonSpearTemplate()
	{
	}

	// Token: 0x170004DB RID: 1243
	// (get) Token: 0x06002AD8 RID: 10968 RVA: 0x0011FC1F File Offset: 0x0011E01F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DragonSpear;
		}
	}

	// Token: 0x170004DC RID: 1244
	// (get) Token: 0x06002AD9 RID: 10969 RVA: 0x0011FC26 File Offset: 0x0011E026
	public override int ItemTierNumber
	{
		get
		{
			return 27;
		}
	}

	// Token: 0x06002ADA RID: 10970 RVA: 0x0011FC2C File Offset: 0x0011E02C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate
		};
	}

	// Token: 0x06002ADB RID: 10971 RVA: 0x0011FC4C File Offset: 0x0011E04C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				Chance = 0.3,
				DamageType = OutputType.Fire,
				DamagePercentage = 0.8 + (double)(grade - QualityGrade.Normal) * 0.1
			}
		};
	}
}
