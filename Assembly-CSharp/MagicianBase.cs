using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class MagicianBase : ResidentBase
{
	// Token: 0x060025FD RID: 9725 RVA: 0x0011239D File Offset: 0x0011079D
	public MagicianBase()
	{
	}

	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x060025FE RID: 9726 RVA: 0x001123B4 File Offset: 0x001107B4
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x060025FF RID: 9727 RVA: 0x001123BC File Offset: 0x001107BC
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x06002600 RID: 9728 RVA: 0x001123C4 File Offset: 0x001107C4
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CultureSkill,
				JourneyContributeType.ResearchSkill
			};
		}
	}

	// Token: 0x06002601 RID: 9729 RVA: 0x001123E8 File Offset: 0x001107E8
	protected override void GenerateHappyEffect(Resident resident)
	{
		int num = UnityEngine.Random.Range(2, 8);
		if (GameWorld.instance.PlayerProfile.Residents.Any<Resident>())
		{
			Resident resident2 = GameWorld.instance.PlayerProfile.Residents[UnityEngine.Random.Range(0, GameWorld.instance.PlayerProfile.Residents.Count)];
			resident2.AddHappinessValue((double)num);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentBoostedAnotherResidentHappiness, new ResidentBoostedAnotherResidentHappinessEvent
			{
				Value = (double)num,
				From = resident,
				To = resident2
			});
		}
	}

	// Token: 0x06002602 RID: 9730 RVA: 0x0011247C File Offset: 0x0011087C
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> list = new List<IResidentEffect>
		{
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			list.Add(WealthResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient));
		}
		return list;
	}

	// Token: 0x040020B1 RID: 8369
	private ResidentType _residentType = ResidentType.Magician;

	// Token: 0x040020B2 RID: 8370
	private int _residentRankParameter = 28;
}
