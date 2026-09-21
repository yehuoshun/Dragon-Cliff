using System;
using System.Collections.Generic;

// Token: 0x020004F3 RID: 1267
[Serializable]
public class SaleArmorRequirementLogic : QuestRequirementBase
{
	// Token: 0x060025AA RID: 9642 RVA: 0x00111142 File Offset: 0x0010F542
	public SaleArmorRequirementLogic()
	{
	}

	// Token: 0x1700029A RID: 666
	// (get) Token: 0x060025AB RID: 9643 RVA: 0x0011114A File Offset: 0x0010F54A
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.ArmorSale;
		}
	}

	// Token: 0x060025AC RID: 9644 RVA: 0x0011114E File Offset: 0x0010F54E
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x060025AD RID: 9645 RVA: 0x00111156 File Offset: 0x0010F556
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060025AE RID: 9646 RVA: 0x00111160 File Offset: 0x0010F560
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ItemPutOnSale && data is List<ItemStatusUpdateEvent>)
		{
			List<ItemStatusUpdateEvent> list = data as List<ItemStatusUpdateEvent>;
			foreach (ItemStatusUpdateEvent itemStatusUpdateEvent in list)
			{
				if (itemStatusUpdateEvent.Item.Type.GetResourceCategory().IsArmor())
				{
					this.SaleSoFar++;
					if (this.SaleSoFar >= this.RequirementAmount)
					{
						this.fullFilled = true;
					}
				}
			}
		}
	}

	// Token: 0x0400206B RID: 8299
	public bool fullFilled;

	// Token: 0x0400206C RID: 8300
	public int RequirementAmount;

	// Token: 0x0400206D RID: 8301
	public int SaleSoFar;
}
