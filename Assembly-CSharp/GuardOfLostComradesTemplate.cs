using System;

// Token: 0x020005C4 RID: 1476
public class GuardOfLostComradesTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600293D RID: 10557 RVA: 0x0011B84E File Offset: 0x00119C4E
	public GuardOfLostComradesTemplate()
	{
	}

	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x0600293E RID: 10558 RVA: 0x0011B868 File Offset: 0x00119C68
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x0600293F RID: 10559 RVA: 0x0011B870 File Offset: 0x00119C70
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x04002226 RID: 8742
	private ResourceType _itemType = ResourceType.GuardOfLostComrades;

	// Token: 0x04002227 RID: 8743
	private int _itemTierNumber = 4;
}
