using System;
using System.Collections.Generic;

// Token: 0x02000677 RID: 1655
public class SwordOfMoonTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C18 RID: 11288 RVA: 0x001215DE File Offset: 0x0011F9DE
	public SwordOfMoonTemplate()
	{
	}

	// Token: 0x17000583 RID: 1411
	// (get) Token: 0x06002C19 RID: 11289 RVA: 0x001215E6 File Offset: 0x0011F9E6
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SwordOfMoon;
		}
	}

	// Token: 0x17000584 RID: 1412
	// (get) Token: 0x06002C1A RID: 11290 RVA: 0x001215ED File Offset: 0x0011F9ED
	public override int ItemTierNumber
	{
		get
		{
			return 11;
		}
	}

	// Token: 0x06002C1B RID: 11291 RVA: 0x001215F4 File Offset: 0x0011F9F4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeStealData
			{
				MaximumStolenValue = (double)(120 + (grade - QualityGrade.Normal) * 20),
				SteamPercentage = 0.25,
				StealAttributeType = AttributeType.PhysicalResistance
			}
		};
	}
}
