using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004EE RID: 1262
[Serializable]
public class ObtainResourceRequirementLogic : QuestRequirementBase
{
	// Token: 0x0600258F RID: 9615 RVA: 0x00110EE4 File Offset: 0x0010F2E4
	public ObtainResourceRequirementLogic()
	{
	}

	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06002590 RID: 9616 RVA: 0x00110EEC File Offset: 0x0010F2EC
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.ObtainResource;
		}
	}

	// Token: 0x06002591 RID: 9617 RVA: 0x00110EEF File Offset: 0x0010F2EF
	public override bool Fullfilled(Quest quest)
	{
		return this.ObtainedRelevantResource.Sum((ResourceUpdate r) => r.ChangeAmount) >= (double)this.RequiredAmount;
	}

	// Token: 0x06002592 RID: 9618 RVA: 0x00110F25 File Offset: 0x0010F325
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002593 RID: 9619 RVA: 0x00110F2C File Offset: 0x0010F32C
	public ResourceType GetQuestDesiredResourceType()
	{
		return this.ResourceType;
	}

	// Token: 0x06002594 RID: 9620 RVA: 0x00110F34 File Offset: 0x0010F334
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ResourceUpdated)
		{
			ResourceUpdateEvent resourceUpdateEvent = data as ResourceUpdateEvent;
			if (resourceUpdateEvent.Change > 0.0 && resourceUpdateEvent.ResourceType == this.ResourceType)
			{
				this.ObtainedRelevantResource.Add(new ResourceUpdate
				{
					ResourceType = resourceUpdateEvent.ResourceType,
					RelatedItems = resourceUpdateEvent.RelatedItems,
					ChangeAmount = resourceUpdateEvent.Change
				});
			}
		}
	}

	// Token: 0x06002595 RID: 9621 RVA: 0x00110FAB File Offset: 0x0010F3AB
	[CompilerGenerated]
	private static double <Fullfilled>m__0(ResourceUpdate r)
	{
		return r.ChangeAmount;
	}

	// Token: 0x0400205A RID: 8282
	public int RequiredAmount;

	// Token: 0x0400205B RID: 8283
	public ResourceType ResourceType;

	// Token: 0x0400205C RID: 8284
	public List<ResourceUpdate> ObtainedRelevantResource;

	// Token: 0x0400205D RID: 8285
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache0;
}
