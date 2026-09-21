using System;
using System.Collections.Generic;

// Token: 0x020004F4 RID: 1268
[Serializable]
public class SaleWeaponRequirementLogic : QuestRequirementBase
{
	// Token: 0x060025AF RID: 9647 RVA: 0x0011120C File Offset: 0x0010F60C
	public SaleWeaponRequirementLogic()
	{
	}

	// Token: 0x1700029B RID: 667
	// (get) Token: 0x060025B0 RID: 9648 RVA: 0x00111214 File Offset: 0x0010F614
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.WeaponSale;
		}
	}

	// Token: 0x060025B1 RID: 9649 RVA: 0x00111217 File Offset: 0x0010F617
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x060025B2 RID: 9650 RVA: 0x0011121F File Offset: 0x0010F61F
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060025B3 RID: 9651 RVA: 0x00111228 File Offset: 0x0010F628
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ItemPutOnSale && data is List<ItemStatusUpdateEvent>)
		{
			List<ItemStatusUpdateEvent> list = data as List<ItemStatusUpdateEvent>;
			foreach (ItemStatusUpdateEvent itemStatusUpdateEvent in list)
			{
				if (itemStatusUpdateEvent.Item.Type.GetResourceCategory().IsWeapon())
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

	// Token: 0x0400206E RID: 8302
	public bool fullFilled;

	// Token: 0x0400206F RID: 8303
	public int RequirementAmount;

	// Token: 0x04002070 RID: 8304
	public int SaleSoFar;
}
