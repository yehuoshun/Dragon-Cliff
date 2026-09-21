using System;

// Token: 0x02000654 RID: 1620
public class IronWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B9A RID: 11162 RVA: 0x00120D5C File Offset: 0x0011F15C
	public IronWandTemplate()
	{
	}

	// Token: 0x1700053D RID: 1341
	// (get) Token: 0x06002B9B RID: 11163 RVA: 0x00120D64 File Offset: 0x0011F164
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.IronWand;
		}
	}

	// Token: 0x1700053E RID: 1342
	// (get) Token: 0x06002B9C RID: 11164 RVA: 0x00120D6B File Offset: 0x0011F16B
	public override int ItemTierNumber
	{
		get
		{
			return 6;
		}
	}
}
