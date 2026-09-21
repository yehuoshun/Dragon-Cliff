using System;
using System.Collections.Generic;

// Token: 0x02000507 RID: 1287
public class PrayerBase : ResidentBase
{
	// Token: 0x0600261C RID: 9756 RVA: 0x001128C7 File Offset: 0x00110CC7
	public PrayerBase()
	{
	}

	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x0600261D RID: 9757 RVA: 0x001128DF File Offset: 0x00110CDF
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x0600261E RID: 9758 RVA: 0x001128E7 File Offset: 0x00110CE7
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x0600261F RID: 9759 RVA: 0x001128F0 File Offset: 0x00110CF0
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.TradeSkill,
				JourneyContributeType.CultureSkill
			};
		}
	}

	// Token: 0x06002620 RID: 9760 RVA: 0x00112914 File Offset: 0x00110D14
	protected override void GenerateHappyEffect(Resident resident)
	{
		WarmFlowTownEffect effect = new WarmFlowTownEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 3, 3, 0.03);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x06002621 RID: 9761 RVA: 0x00112958 File Offset: 0x00110D58
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> result = new List<IResidentEffect>
		{
			ProductionResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			RecruitmentResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient);
		}
		return result;
	}

	// Token: 0x040020BC RID: 8380
	private ResidentType _residentType = ResidentType.Prayer;

	// Token: 0x040020BD RID: 8381
	private int _residentRankParameter = 32;
}
