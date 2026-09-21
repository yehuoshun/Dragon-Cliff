using System;
using System.Collections.Generic;

// Token: 0x0200062D RID: 1581
public class ChaserTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B01 RID: 11009 RVA: 0x0011FFA7 File Offset: 0x0011E3A7
	public ChaserTemplate()
	{
	}

	// Token: 0x170004EF RID: 1263
	// (get) Token: 0x06002B02 RID: 11010 RVA: 0x0011FFAF File Offset: 0x0011E3AF
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Chaser;
		}
	}

	// Token: 0x170004F0 RID: 1264
	// (get) Token: 0x06002B03 RID: 11011 RVA: 0x0011FFB6 File Offset: 0x0011E3B6
	public override int ItemTierNumber
	{
		get
		{
			return 9;
		}
	}

	// Token: 0x06002B04 RID: 11012 RVA: 0x0011FFBC File Offset: 0x0011E3BC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeStealData
			{
				StealAttributeType = AttributeType.Intelligience,
				MaximumStolenValue = (double)(90 + (grade - QualityGrade.Normal) * 15),
				SteamPercentage = 0.25
			}
		};
	}
}
