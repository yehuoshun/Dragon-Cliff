using System;
using System.Collections.Generic;

// Token: 0x02000662 RID: 1634
public class RoyalLongSwordTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BC9 RID: 11209 RVA: 0x00120F89 File Offset: 0x0011F389
	public RoyalLongSwordTemplate()
	{
	}

	// Token: 0x17000559 RID: 1369
	// (get) Token: 0x06002BCA RID: 11210 RVA: 0x00120FA4 File Offset: 0x0011F3A4
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700055A RID: 1370
	// (get) Token: 0x06002BCB RID: 11211 RVA: 0x00120FAC File Offset: 0x0011F3AC
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002BCC RID: 11212 RVA: 0x00120FB4 File Offset: 0x0011F3B4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeStealData
			{
				SteamPercentage = 0.2,
				StealAttributeType = AttributeType.Strength,
				MaximumStolenValue = (double)(350 + (grade - QualityGrade.Normal) * 30)
			}
		};
	}

	// Token: 0x040022AE RID: 8878
	private ResourceType _itemType = ResourceType.RoyalLongSword;

	// Token: 0x040022AF RID: 8879
	private int _itemTierNumber = 24;
}
