using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class MysteriousRoyalMember : ResidentBase
{
	// Token: 0x06002609 RID: 9737 RVA: 0x00112589 File Offset: 0x00110989
	public MysteriousRoyalMember()
	{
	}

	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x0600260A RID: 9738 RVA: 0x001125A1 File Offset: 0x001109A1
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002BA RID: 698
	// (get) Token: 0x0600260B RID: 9739 RVA: 0x001125A9 File Offset: 0x001109A9
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002BB RID: 699
	// (get) Token: 0x0600260C RID: 9740 RVA: 0x001125B4 File Offset: 0x001109B4
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			List<JourneyContributeType> list = new List<JourneyContributeType>
			{
				JourneyContributeType.CultureSkill,
				JourneyContributeType.CollectionSkill,
				JourneyContributeType.TradeSkill,
				JourneyContributeType.ResearchSkill
			};
			return new List<JourneyContributeType>
			{
				list[UnityEngine.Random.Range(0, list.Count)]
			};
		}
	}

	// Token: 0x0600260D RID: 9741 RVA: 0x00112604 File Offset: 0x00110A04
	protected override void GenerateHappyEffect(Resident resident)
	{
		LuckyChestEffect effect = new LuckyChestEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.8);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x0600260E RID: 9742 RVA: 0x00112648 File Offset: 0x00110A48
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> result = new List<IResidentEffect>
		{
			ProductionResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			RecruitmentResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient);
		}
		return result;
	}

	// Token: 0x040020B5 RID: 8373
	private ResidentType _residentType = ResidentType.MysteriousRoyalMember;

	// Token: 0x040020B6 RID: 8374
	private int _residentRankParameter = 50;
}
