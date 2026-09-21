using System;
using System.Collections.Generic;

// Token: 0x02000653 RID: 1619
public class InsignificantThingTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B95 RID: 11157 RVA: 0x00120C8B File Offset: 0x0011F08B
	public InsignificantThingTemplate()
	{
	}

	// Token: 0x1700053B RID: 1339
	// (get) Token: 0x06002B96 RID: 11158 RVA: 0x00120C93 File Offset: 0x0011F093
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.InsignificantThing;
		}
	}

	// Token: 0x1700053C RID: 1340
	// (get) Token: 0x06002B97 RID: 11159 RVA: 0x00120C9A File Offset: 0x0011F09A
	public override int ItemTierNumber
	{
		get
		{
			return 32;
		}
	}

	// Token: 0x06002B98 RID: 11160 RVA: 0x00120CA0 File Offset: 0x0011F0A0
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PossessionData
			{
				Chance = 0.3,
				Boosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = (double)(400 + (grade - QualityGrade.Normal) * 100),
						BoostAttribute = AttributeType.Intelligience
					},
					new BoostSetting
					{
						BoostValue = (double)(300 + (grade - QualityGrade.Normal) * 50),
						BoostAttribute = AttributeType.Agility
					}
				},
				PossessionEffectSourceIdentityCode = base.GetType().FullName,
				TriggerEventType = AdventureEventType.UnitReadyInBattle,
				LastingTurns = 5
			}
		};
	}

	// Token: 0x06002B99 RID: 11161 RVA: 0x00120D55 File Offset: 0x0011F155
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
