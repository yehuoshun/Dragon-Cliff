using System;
using System.Collections.Generic;

// Token: 0x020005DB RID: 1499
public class ElixirofAggressionTemplate : ConsumableTemplateBase
{
	// Token: 0x0600298C RID: 10636 RVA: 0x0011BED8 File Offset: 0x0011A2D8
	public ElixirofAggressionTemplate()
	{
	}

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x0600298D RID: 10637 RVA: 0x0011BEE0 File Offset: 0x0011A2E0
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ElixirofAggression;
		}
	}

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x0600298E RID: 10638 RVA: 0x0011BEE7 File Offset: 0x0011A2E7
	public override int ItemTierNumber
	{
		get
		{
			return 20;
		}
	}

	// Token: 0x0600298F RID: 10639 RVA: 0x0011BEEC File Offset: 0x0011A2EC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeBoostData
			{
				IsStar = false,
				MultiplicationBoosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.1,
						BoostAttribute = AttributeType.Agility
					}
				},
				AdditionBoosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.3,
						BoostAttribute = AttributeType.CritRate
					},
					new BoostSetting
					{
						BoostValue = 0.15,
						BoostAttribute = AttributeType.TurnStartHeal
					}
				}
			}
		};
	}
}
