using System;

// Token: 0x0200059C RID: 1436
public class CursedVestOfTheForestTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028B4 RID: 10420 RVA: 0x0011B05D File Offset: 0x0011945D
	public CursedVestOfTheForestTemplate()
	{
	}

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x060028B5 RID: 10421 RVA: 0x0011B077 File Offset: 0x00119477
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x060028B6 RID: 10422 RVA: 0x0011B07F File Offset: 0x0011947F
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x04002208 RID: 8712
	private ResourceType _itemType = ResourceType.CursedVestOfTheForest;

	// Token: 0x04002209 RID: 8713
	private int _itemTierNumber = 5;
}
