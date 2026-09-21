using System;
using System.Collections.Generic;

// Token: 0x0200065D RID: 1629
public class HeavenTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BB6 RID: 11190 RVA: 0x00120E89 File Offset: 0x0011F289
	public HeavenTemplate()
	{
	}

	// Token: 0x1700054F RID: 1359
	// (get) Token: 0x06002BB7 RID: 11191 RVA: 0x00120E91 File Offset: 0x0011F291
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Heaven;
		}
	}

	// Token: 0x17000550 RID: 1360
	// (get) Token: 0x06002BB8 RID: 11192 RVA: 0x00120E98 File Offset: 0x0011F298
	public override int ItemTierNumber
	{
		get
		{
			return 16;
		}
	}

	// Token: 0x06002BB9 RID: 11193 RVA: 0x00120E9C File Offset: 0x0011F29C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TauntRecoveryData
			{
				RecoveryRate = 0.02 + (double)(grade - QualityGrade.Normal) * 0.05
			}
		};
	}
}
