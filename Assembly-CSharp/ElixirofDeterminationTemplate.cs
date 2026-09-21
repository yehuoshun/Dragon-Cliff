using System;
using System.Collections.Generic;

// Token: 0x020005DC RID: 1500
public class ElixirofDeterminationTemplate : ConsumableTemplateBase
{
	// Token: 0x06002990 RID: 10640 RVA: 0x0011BF9B File Offset: 0x0011A39B
	public ElixirofDeterminationTemplate()
	{
	}

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x06002991 RID: 10641 RVA: 0x0011BFA3 File Offset: 0x0011A3A3
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ElixirofDetermination;
		}
	}

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x06002992 RID: 10642 RVA: 0x0011BFAA File Offset: 0x0011A3AA
	public override int ItemTierNumber
	{
		get
		{
			return 20;
		}
	}

	// Token: 0x06002993 RID: 10643 RVA: 0x0011BFB0 File Offset: 0x0011A3B0
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeBoostData
			{
				IsStar = false,
				MultiplicationBoosts = new List<BoostSetting>(),
				AdditionBoosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.1,
						BoostAttribute = AttributeType.HitRateAdjustment
					}
				}
			}
		};
	}
}
