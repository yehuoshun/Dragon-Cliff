using System;
using System.Collections.Generic;

// Token: 0x02000626 RID: 1574
public class StarChaserTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002AE4 RID: 10980 RVA: 0x0011FD73 File Offset: 0x0011E173
	public StarChaserTemplate()
	{
	}

	// Token: 0x170004E1 RID: 1249
	// (get) Token: 0x06002AE5 RID: 10981 RVA: 0x0011FD7B File Offset: 0x0011E17B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.StarChaser;
		}
	}

	// Token: 0x170004E2 RID: 1250
	// (get) Token: 0x06002AE6 RID: 10982 RVA: 0x0011FD82 File Offset: 0x0011E182
	public override int ItemTierNumber
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x06002AE7 RID: 10983 RVA: 0x0011FD88 File Offset: 0x0011E188
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealDivineDamageEffectivenessChangeRate
		};
	}

	// Token: 0x06002AE8 RID: 10984 RVA: 0x0011FDA8 File Offset: 0x0011E1A8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				Chance = 0.3,
				DamageType = OutputType.Physical,
				DamagePercentage = 0.8 + (double)(grade - QualityGrade.Normal) * 0.1
			}
		};
	}
}
