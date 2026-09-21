using System;

// Token: 0x020005A3 RID: 1443
public class EnergyOfProtectionTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028CE RID: 10446 RVA: 0x0011B20F File Offset: 0x0011960F
	public EnergyOfProtectionTemplate()
	{
	}

	// Token: 0x170003DA RID: 986
	// (get) Token: 0x060028CF RID: 10447 RVA: 0x0011B22A File Offset: 0x0011962A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003DB RID: 987
	// (get) Token: 0x060028D0 RID: 10448 RVA: 0x0011B232 File Offset: 0x00119632
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0400220E RID: 8718
	private ResourceType _itemType = ResourceType.EnergyOfProtection;

	// Token: 0x0400220F RID: 8719
	private int _itemTierNumber = 9;
}
