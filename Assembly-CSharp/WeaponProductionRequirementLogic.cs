using System;
using System.Collections.Generic;

// Token: 0x020004F7 RID: 1271
[Serializable]
public class WeaponProductionRequirementLogic : QuestRequirementBase
{
	// Token: 0x060025C0 RID: 9664 RVA: 0x0011148F File Offset: 0x0010F88F
	public WeaponProductionRequirementLogic()
	{
	}

	// Token: 0x1700029E RID: 670
	// (get) Token: 0x060025C1 RID: 9665 RVA: 0x00111497 File Offset: 0x0010F897
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.WeaponProduction;
		}
	}

	// Token: 0x060025C2 RID: 9666 RVA: 0x0011149A File Offset: 0x0010F89A
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x060025C3 RID: 9667 RVA: 0x001114A2 File Offset: 0x0010F8A2
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060025C4 RID: 9668 RVA: 0x001114AC File Offset: 0x0010F8AC
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ItemProduced && data is Product)
		{
			Product product = data as Product;
			if (product.ProductType.GetResourceCategory().IsWeapon())
			{
				this.ProducedAmountSoFar += product.RelatedItems.Count;
				if (this.ProducedAmountSoFar >= this.RequiredAmount)
				{
					this.fullFilled = true;
				}
			}
		}
	}

	// Token: 0x0400207B RID: 8315
	public int RequiredAmount;

	// Token: 0x0400207C RID: 8316
	public int ProducedAmountSoFar;

	// Token: 0x0400207D RID: 8317
	public bool fullFilled;
}
