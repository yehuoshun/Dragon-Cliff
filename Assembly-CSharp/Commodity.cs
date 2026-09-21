using System;
using System.Collections.Generic;

// Token: 0x0200052C RID: 1324
[Serializable]
public class Commodity
{
	// Token: 0x060026D1 RID: 9937 RVA: 0x00116472 File Offset: 0x00114872
	public Commodity()
	{
	}

	// Token: 0x04002147 RID: 8519
	public List<Item> Items;

	// Token: 0x04002148 RID: 8520
	public int Amount;

	// Token: 0x04002149 RID: 8521
	public ResourceType ResourceType;

	// Token: 0x0400214A RID: 8522
	public double PricePerItem;

	// Token: 0x0400214B RID: 8523
	public double? AshPerItem;

	// Token: 0x0400214C RID: 8524
	public int NumberOfDaysTillExpiration;
}
