using System;

// Token: 0x0200061E RID: 1566
public class SleekKnifeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AC4 RID: 10948 RVA: 0x0011FAFB File Offset: 0x0011DEFB
	public SleekKnifeTemplate()
	{
	}

	// Token: 0x170004D1 RID: 1233
	// (get) Token: 0x06002AC5 RID: 10949 RVA: 0x0011FB03 File Offset: 0x0011DF03
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SleekKnife;
		}
	}

	// Token: 0x170004D2 RID: 1234
	// (get) Token: 0x06002AC6 RID: 10950 RVA: 0x0011FB0A File Offset: 0x0011DF0A
	public override int ItemTierNumber
	{
		get
		{
			return 1;
		}
	}
}
