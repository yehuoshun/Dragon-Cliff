using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class PeasantBase : ResidentBase
{
	// Token: 0x06002615 RID: 9749 RVA: 0x0011276A File Offset: 0x00110B6A
	public PeasantBase()
	{
	}

	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06002616 RID: 9750 RVA: 0x00112780 File Offset: 0x00110B80
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x06002617 RID: 9751 RVA: 0x00112788 File Offset: 0x00110B88
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06002618 RID: 9752 RVA: 0x00112790 File Offset: 0x00110B90
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CollectionSkill
			};
		}
	}

	// Token: 0x06002619 RID: 9753 RVA: 0x001127AC File Offset: 0x00110BAC
	protected override void GenerateHappyEffect(Resident resident)
	{
		int num = UnityEngine.Random.Range(30, 120);
		List<ResourceType> list = (from r in GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating().GetRawResources()
		where r.GetResourceCategory() == ResourceCategory.Timber
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

	// Token: 0x0600261A RID: 9754 RVA: 0x00112890 File Offset: 0x00110C90
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement measurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			ArmorSaleResidentEffect.CreateDifficultyRelatedEffect(measurement, growthCoeffecient * 1.0)
		};
	}

	// Token: 0x0600261B RID: 9755 RVA: 0x001128BB File Offset: 0x00110CBB
	[CompilerGenerated]
	private static bool <GenerateHappyEffect>m__0(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Timber;
	}

	// Token: 0x040020B9 RID: 8377
	private ResidentType _residentType = ResidentType.Peasant;

	// Token: 0x040020BA RID: 8378
	private int _residentRankParameter = 1;

	// Token: 0x040020BB RID: 8379
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache0;
}
