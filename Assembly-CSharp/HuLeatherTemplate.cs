using System;

// Token: 0x02000582 RID: 1410
public class HuLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600285B RID: 10331 RVA: 0x0011AB49 File Offset: 0x00118F49
	public HuLeatherTemplate()
	{
	}

	// Token: 0x17000398 RID: 920
	// (get) Token: 0x0600285C RID: 10332 RVA: 0x0011AB51 File Offset: 0x00118F51
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HuLeather;
		}
	}

	// Token: 0x17000399 RID: 921
	// (get) Token: 0x0600285D RID: 10333 RVA: 0x0011AB58 File Offset: 0x00118F58
	public override int ItemTierNumber
	{
		get
		{
			return 3;
		}
	}
}
