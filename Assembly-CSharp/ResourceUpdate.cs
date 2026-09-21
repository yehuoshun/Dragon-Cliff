using System;
using System.Collections.Generic;

// Token: 0x02000686 RID: 1670
[Serializable]
public class ResourceUpdate
{
	// Token: 0x06002C90 RID: 11408 RVA: 0x00123CD6 File Offset: 0x001220D6
	public ResourceUpdate()
	{
	}

	// Token: 0x06002C91 RID: 11409 RVA: 0x00123CE0 File Offset: 0x001220E0
	public static ResourceUpdate CreateMoneyUpdate(double amount)
	{
		return new ResourceUpdate
		{
			ResourceType = ResourceType.Money,
			RelatedItems = new List<Item>(),
			ChangeAmount = amount
		};
	}

	// Token: 0x04002679 RID: 9849
	public ResourceType ResourceType;

	// Token: 0x0400267A RID: 9850
	public double ChangeAmount;

	// Token: 0x0400267B RID: 9851
	public List<Item> RelatedItems;
}
