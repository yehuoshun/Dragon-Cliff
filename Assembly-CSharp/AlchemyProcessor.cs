using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000998 RID: 2456
[Serializable]
public class AlchemyProcessor : TownEventProcessorBase
{
	// Token: 0x06004339 RID: 17209 RVA: 0x001B6DB2 File Offset: 0x001B51B2
	public AlchemyProcessor()
	{
	}

	// Token: 0x17000D49 RID: 3401
	// (get) Token: 0x0600433A RID: 17210 RVA: 0x001B6DBA File Offset: 0x001B51BA
	public override TownEventType Type
	{
		get
		{
			return TownEventType.Alchemy;
		}
	}

	// Token: 0x17000D4A RID: 3402
	// (get) Token: 0x0600433B RID: 17211 RVA: 0x001B6DC0 File Offset: 0x001B51C0
	public override List<ResourceType> ResourceConsumptionTypes
	{
		get
		{
			return new List<ResourceType>
			{
				ResourceType.Money
			};
		}
	}

	// Token: 0x17000D4B RID: 3403
	// (get) Token: 0x0600433C RID: 17212 RVA: 0x001B6DDF File Offset: 0x001B51DF
	public override int DaysRequired
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x17000D4C RID: 3404
	// (get) Token: 0x0600433D RID: 17213 RVA: 0x001B6DE3 File Offset: 0x001B51E3
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D4D RID: 3405
	// (get) Token: 0x0600433E RID: 17214 RVA: 0x001B6DE6 File Offset: 0x001B51E6
	public override int ActivePointsToExclusive
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x17000D4E RID: 3406
	// (get) Token: 0x0600433F RID: 17215 RVA: 0x001B6DE9 File Offset: 0x001B51E9
	public override int RequiredDifficultyValue
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x17000D4F RID: 3407
	// (get) Token: 0x06004340 RID: 17216 RVA: 0x001B6DED File Offset: 0x001B51ED
	public override int RequiredPolicyPoint
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x06004341 RID: 17217 RVA: 0x001B6DF4 File Offset: 0x001B51F4
	public override void TownEventCompleted()
	{
		int num = UnityEngine.Random.Range(1, 4);
		List<ResourceType> list = new List<ResourceType>();
		List<ResourceType> list2 = new List<ResourceType>
		{
			ResourceType.ElixirofFlyingShadow,
			ResourceType.ElixirofAggression,
			ResourceType.ElixirofDetermination
		};
		for (int i = 0; i < num; i++)
		{
			list.Add(list2[UnityEngine.Random.Range(0, list2.Count)]);
		}
		List<ResourceUpdate> list3 = (from p in list
		select new ResourceUpdate
		{
			ResourceType = p,
			ChangeAmount = 1.0,
			RelatedItems = new List<Item>()
		}).ToList<ResourceUpdate>();
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.TownEventResourceContributed, list3);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(list3);
		double eventResultValue = base.GetEventResultValue(50.0, 2000.0);
		OutputboostTownEffect effect = new OutputboostTownEffect(20, GameWorld.instance.PlayerProfile.GameDays, eventResultValue, ModificationType.Addition);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, this);
	}

	// Token: 0x06004342 RID: 17218 RVA: 0x001B6EFC File Offset: 0x001B52FC
	[CompilerGenerated]
	private static ResourceUpdate <TownEventCompleted>m__0(ResourceType p)
	{
		return new ResourceUpdate
		{
			ResourceType = p,
			ChangeAmount = 1.0,
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x04003316 RID: 13078
	[CompilerGenerated]
	private static Func<ResourceType, ResourceUpdate> <>f__am$cache0;
}
