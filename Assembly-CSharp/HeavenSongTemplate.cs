using System;
using System.Collections.Generic;

// Token: 0x02000638 RID: 1592
public class HeavenSongTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B2F RID: 11055 RVA: 0x001203F5 File Offset: 0x0011E7F5
	public HeavenSongTemplate()
	{
	}

	// Token: 0x17000505 RID: 1285
	// (get) Token: 0x06002B30 RID: 11056 RVA: 0x001203FD File Offset: 0x0011E7FD
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HeavenSong;
		}
	}

	// Token: 0x17000506 RID: 1286
	// (get) Token: 0x06002B31 RID: 11057 RVA: 0x00120404 File Offset: 0x0011E804
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x06002B32 RID: 11058 RVA: 0x00120408 File Offset: 0x0011E808
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				ConditionValue = 400.0,
				GrowthAttributeType = AttributeType.Resilience,
				MaxGrowthValue = (double)(500 + (grade - QualityGrade.Normal) * 100),
				GrowthRate = 5.0,
				CurrentGrowthValue = 0.0,
				Condition = GrowthConditionType.ReceiveDamage,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
