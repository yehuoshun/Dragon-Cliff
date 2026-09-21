using System;
using System.Collections.Generic;

// Token: 0x02000634 RID: 1588
public class FireyWavesFallenSoulTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B1E RID: 11038 RVA: 0x001201D3 File Offset: 0x0011E5D3
	public FireyWavesFallenSoulTemplate()
	{
	}

	// Token: 0x170004FD RID: 1277
	// (get) Token: 0x06002B1F RID: 11039 RVA: 0x001201EE File Offset: 0x0011E5EE
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004FE RID: 1278
	// (get) Token: 0x06002B20 RID: 11040 RVA: 0x001201F6 File Offset: 0x0011E5F6
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B21 RID: 11041 RVA: 0x00120200 File Offset: 0x0011E600
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeStealData
			{
				MaximumStolenValue = (double)(340 + (grade - QualityGrade.Normal) * 30),
				StealAttributeType = AttributeType.Intelligience,
				SteamPercentage = 0.3
			}
		};
	}

	// Token: 0x04002294 RID: 8852
	private ResourceType _itemType = ResourceType.FireyWavesFallenSoul;

	// Token: 0x04002295 RID: 8853
	private int _itemTierNumber = 23;
}
