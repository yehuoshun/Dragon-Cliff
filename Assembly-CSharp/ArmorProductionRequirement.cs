using System;
using System.Collections.Generic;

// Token: 0x020004E7 RID: 1255
[Serializable]
public class ArmorProductionRequirement : QuestRequirementBase
{
	// Token: 0x0600256B RID: 9579 RVA: 0x00110963 File Offset: 0x0010ED63
	public ArmorProductionRequirement()
	{
	}

	// Token: 0x1700028E RID: 654
	// (get) Token: 0x0600256C RID: 9580 RVA: 0x0011096B File Offset: 0x0010ED6B
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.ArmorProduction;
		}
	}

	// Token: 0x0600256D RID: 9581 RVA: 0x0011096F File Offset: 0x0010ED6F
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x0600256E RID: 9582 RVA: 0x00110977 File Offset: 0x0010ED77
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600256F RID: 9583 RVA: 0x00110980 File Offset: 0x0010ED80
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ItemProduced && data is Product)
		{
			Product product = data as Product;
			if (product.ProductType.GetResourceCategory().IsArmor())
			{
				this.ProducedAmountSoFar += product.RelatedItems.Count;
				if (this.ProducedAmountSoFar >= this.RequiredAmount)
				{
					this.fullFilled = true;
				}
			}
		}
	}

	// Token: 0x04002039 RID: 8249
	public int RequiredAmount;

	// Token: 0x0400203A RID: 8250
	public int ProducedAmountSoFar;

	// Token: 0x0400203B RID: 8251
	public bool fullFilled;
}
