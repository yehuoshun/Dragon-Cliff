using System;
using System.Collections.Generic;

// Token: 0x020005D1 RID: 1489
public class ResentmentTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600296A RID: 10602 RVA: 0x0011BB6B File Offset: 0x00119F6B
	public ResentmentTemplate()
	{
	}

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x0600296B RID: 10603 RVA: 0x0011BB85 File Offset: 0x00119F85
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x0600296C RID: 10604 RVA: 0x0011BB8D File Offset: 0x00119F8D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600296D RID: 10605 RVA: 0x0011BB98 File Offset: 0x00119F98
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PossessionData
			{
				TriggerEventType = AdventureEventType.UnitReadyInBattle,
				LastingTurns = 5,
				PossessionEffectSourceIdentityCode = base.GetType().FullName,
				Chance = 0.3,
				Boosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = (double)(22 + (grade - QualityGrade.Normal) * 2),
						BoostAttribute = AttributeType.Intelligience
					},
					new BoostSetting
					{
						BoostValue = (double)(22 + (grade - QualityGrade.Normal) * 2),
						BoostAttribute = AttributeType.PhysicalResistance
					}
				}
			}
		};
	}

	// Token: 0x04002232 RID: 8754
	private ResourceType _itemType = ResourceType.Resentment;

	// Token: 0x04002233 RID: 8755
	private int _itemTierNumber = 4;
}
