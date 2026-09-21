using System;
using System.Collections.Generic;

// Token: 0x020005C6 RID: 1478
public class IncarnationTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002944 RID: 10564 RVA: 0x0011B92E File Offset: 0x00119D2E
	public IncarnationTemplate()
	{
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x06002945 RID: 10565 RVA: 0x0011B936 File Offset: 0x00119D36
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Incarnation;
		}
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x06002946 RID: 10566 RVA: 0x0011B93D File Offset: 0x00119D3D
	public override int ItemTierNumber
	{
		get
		{
			return 28;
		}
	}

	// Token: 0x06002947 RID: 10567 RVA: 0x0011B944 File Offset: 0x00119D44
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SufferlessData
			{
				RecoveryRate = 0.03 + (double)(grade - QualityGrade.Normal) * 0.01,
				NumberOfMaxTriggersPerBattle = 1,
				ImmuneTurns = 1
			}
		};
	}
}
