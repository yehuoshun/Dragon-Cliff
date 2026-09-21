using System;

// Token: 0x020005AF RID: 1455
public class ReachOfTerrorTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028F5 RID: 10485 RVA: 0x0011B42D File Offset: 0x0011982D
	public ReachOfTerrorTemplate()
	{
	}

	// Token: 0x170003F2 RID: 1010
	// (get) Token: 0x060028F6 RID: 10486 RVA: 0x0011B448 File Offset: 0x00119848
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x060028F7 RID: 10487 RVA: 0x0011B450 File Offset: 0x00119850
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0400221A RID: 8730
	private ResourceType _itemType = ResourceType.ReachOfTerror;

	// Token: 0x0400221B RID: 8731
	private int _itemTierNumber = 19;
}
