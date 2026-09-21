using System;
using System.Collections.Generic;

// Token: 0x0200050E RID: 1294
public class ScholarBase : ResidentBase
{
	// Token: 0x0600264D RID: 9805 RVA: 0x00112E2E File Offset: 0x0011122E
	public ScholarBase()
	{
	}

	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x0600264E RID: 9806 RVA: 0x00112E45 File Offset: 0x00111245
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x0600264F RID: 9807 RVA: 0x00112E4D File Offset: 0x0011124D
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06002650 RID: 9808 RVA: 0x00112E58 File Offset: 0x00111258
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

	// Token: 0x06002651 RID: 9809 RVA: 0x00112E74 File Offset: 0x00111274
	protected override void GenerateHappyEffect(Resident resident)
	{
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.15, AttributeType.Strength, ModificationType.Multiplication);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x06002652 RID: 9810 RVA: 0x00112EB8 File Offset: 0x001112B8
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> result = new List<IResidentEffect>
		{
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			ProductionResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			RecruitmentResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient);
		}
		return result;
	}

	// Token: 0x040020C9 RID: 8393
	private ResidentType _residentType = ResidentType.Scholar;

	// Token: 0x040020CA RID: 8394
	private int _residentRankParameter = 19;
}
