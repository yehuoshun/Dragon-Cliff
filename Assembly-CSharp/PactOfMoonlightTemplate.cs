using System;

// Token: 0x020005CD RID: 1485
public class PactOfMoonlightTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600295B RID: 10587 RVA: 0x0011BA20 File Offset: 0x00119E20
	public PactOfMoonlightTemplate()
	{
	}

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x0600295C RID: 10588 RVA: 0x0011BA3B File Offset: 0x00119E3B
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x0600295D RID: 10589 RVA: 0x0011BA43 File Offset: 0x00119E43
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0400222A RID: 8746
	private ResourceType _itemType = ResourceType.PactOfMoonlight;

	// Token: 0x0400222B RID: 8747
	private int _itemTierNumber = 24;
}
