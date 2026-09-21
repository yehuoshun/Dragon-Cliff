using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class TravellerBase : ResidentBase
{
	// Token: 0x06002659 RID: 9817 RVA: 0x00112FE2 File Offset: 0x001113E2
	public TravellerBase()
	{
	}

	// Token: 0x170002DD RID: 733
	// (get) Token: 0x0600265A RID: 9818 RVA: 0x00112FEA File Offset: 0x001113EA
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002DE RID: 734
	// (get) Token: 0x0600265B RID: 9819 RVA: 0x00112FF2 File Offset: 0x001113F2
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002DF RID: 735
	// (get) Token: 0x0600265C RID: 9820 RVA: 0x00112FFC File Offset: 0x001113FC
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.TradeSkill
			};
		}
	}

	// Token: 0x0600265D RID: 9821 RVA: 0x00113018 File Offset: 0x00111418
	protected override void GenerateHappyEffect(Resident resident)
	{
		int num = UnityEngine.Random.Range(30, 120);
		List<ResourceType> list = (from r in GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating().GetRawResources()
		where r.GetResourceCategory() == ResourceCategory.Ore
		select r).ToList<ResourceType>();
		if (list.Any<ResourceType>())
		{
			ResourceType resourceType = list[UnityEngine.Random.Range(0, list.Count)];
			List<ResourceUpdate> list2 = new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = resourceType,
					ChangeAmount = (double)num,
					RelatedItems = new List<Item>()
				}
			};
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentContributed, new ResidentResourceContributeEvent
			{
				Contributor = resident,
				ResourceUpdates = list2
			});
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(list2);
		}
	}

	// Token: 0x0600265E RID: 9822 RVA: 0x001130FC File Offset: 0x001114FC
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement difficultyLevelMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			ProductionResidentEffect.CreateDifficultyRelatedEffect(difficultyLevelMeasurement, growthCoeffecient * 1.0)
		};
	}

	// Token: 0x0600265F RID: 9823 RVA: 0x00113127 File Offset: 0x00111527
	[CompilerGenerated]
	private static bool <GenerateHappyEffect>m__0(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Ore;
	}

	// Token: 0x040020CD RID: 8397
	private ResidentType _residentType;

	// Token: 0x040020CE RID: 8398
	private int _residentRankParameter;

	// Token: 0x040020CF RID: 8399
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache0;
}
