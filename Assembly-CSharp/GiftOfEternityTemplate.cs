using System;
using System.Collections.Generic;

// Token: 0x020005C2 RID: 1474
public class GiftOfEternityTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002936 RID: 10550 RVA: 0x0011B7BF File Offset: 0x00119BBF
	public GiftOfEternityTemplate()
	{
	}

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x06002937 RID: 10551 RVA: 0x0011B7DA File Offset: 0x00119BDA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x06002938 RID: 10552 RVA: 0x0011B7E2 File Offset: 0x00119BE2
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002939 RID: 10553 RVA: 0x0011B7EC File Offset: 0x00119BEC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SufferlessData
			{
				RecoveryRate = 0.01 + (double)(grade - QualityGrade.Normal) * 0.01,
				NumberOfMaxTriggersPerBattle = 1,
				ImmuneTurns = 1
			}
		};
	}

	// Token: 0x04002224 RID: 8740
	private ResourceType _itemType = ResourceType.GiftOfEternity;

	// Token: 0x04002225 RID: 8741
	private int _itemTierNumber = 15;
}
