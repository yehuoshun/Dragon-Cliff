using System;
using System.Collections.Generic;

// Token: 0x02000616 RID: 1558
public class FlyingBirdTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AA3 RID: 10915 RVA: 0x0011F89B File Offset: 0x0011DC9B
	public FlyingBirdTemplate()
	{
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06002AA4 RID: 10916 RVA: 0x0011F8A3 File Offset: 0x0011DCA3
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FlyingBird;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06002AA5 RID: 10917 RVA: 0x0011F8AA File Offset: 0x0011DCAA
	public override int ItemTierNumber
	{
		get
		{
			return 27;
		}
	}

	// Token: 0x06002AA6 RID: 10918 RVA: 0x0011F8B0 File Offset: 0x0011DCB0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Agility
		};
	}

	// Token: 0x06002AA7 RID: 10919 RVA: 0x0011F8CC File Offset: 0x0011DCCC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				CurrentGrowthValue = 0.0,
				ConditionValue = 100.0,
				GrowthAttributeType = AttributeType.Agility,
				MaxGrowthValue = (double)(400 + (grade - QualityGrade.Normal) * 50),
				GrowthRate = 2.0,
				Condition = GrowthConditionType.ReceiveHeal,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
