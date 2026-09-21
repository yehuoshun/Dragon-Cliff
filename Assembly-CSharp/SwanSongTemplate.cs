using System;
using System.Collections.Generic;

// Token: 0x02000627 RID: 1575
public class SwanSongTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002AE9 RID: 10985 RVA: 0x0011FDFF File Offset: 0x0011E1FF
	public SwanSongTemplate()
	{
	}

	// Token: 0x170004E3 RID: 1251
	// (get) Token: 0x06002AEA RID: 10986 RVA: 0x0011FE1A File Offset: 0x0011E21A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004E4 RID: 1252
	// (get) Token: 0x06002AEB RID: 10987 RVA: 0x0011FE22 File Offset: 0x0011E222
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002AEC RID: 10988 RVA: 0x0011FE2C File Offset: 0x0011E22C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				Chance = 0.3,
				DamageType = OutputType.Divine,
				DamagePercentage = 0.8 + (double)(grade - QualityGrade.Normal) * 0.1
			}
		};
	}

	// Token: 0x0400228D RID: 8845
	private ResourceType _itemType = ResourceType.SwanSong;

	// Token: 0x0400228E RID: 8846
	private int _itemTierNumber = 20;
}
