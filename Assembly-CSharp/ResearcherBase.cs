using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000509 RID: 1289
public class ResearcherBase : ResidentBase
{
	// Token: 0x06002628 RID: 9768 RVA: 0x00112A63 File Offset: 0x00110E63
	public ResearcherBase()
	{
	}

	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06002629 RID: 9769 RVA: 0x00112A7B File Offset: 0x00110E7B
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x0600262A RID: 9770 RVA: 0x00112A83 File Offset: 0x00110E83
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002CA RID: 714
	// (get) Token: 0x0600262B RID: 9771 RVA: 0x00112A8C File Offset: 0x00110E8C
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.ResearchSkill
			};
		}
	}

	// Token: 0x0600262C RID: 9772 RVA: 0x00112AA8 File Offset: 0x00110EA8
	protected override void GenerateHappyEffect(Resident resident)
	{
		int num = (int)(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating().GetDefaultDropParameter(ResourceType.PracticePoints, 1).InclusiveVolumFrom * (double)UnityEngine.Random.Range(0.5f, 1f));
		List<ResourceUpdate> list = new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.PracticePoints,
				ChangeAmount = (double)num,
				RelatedItems = new List<Item>()
			}
		};
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentContributed, new ResidentResourceContributeEvent
		{
			ResourceUpdates = list,
			Contributor = resident
		});
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(list);
	}

	// Token: 0x0600262D RID: 9773 RVA: 0x00112B54 File Offset: 0x00110F54
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			ProductionResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
	}

	// Token: 0x040020C0 RID: 8384
	private ResidentType _residentType = ResidentType.Researcher;

	// Token: 0x040020C1 RID: 8385
	private int _residentRankParameter = 36;
}
