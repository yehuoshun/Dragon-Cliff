using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class RoyalNobleBase : ResidentBase
{
	// Token: 0x06002647 RID: 9799 RVA: 0x00112D4F File Offset: 0x0011114F
	public RoyalNobleBase()
	{
	}

	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06002648 RID: 9800 RVA: 0x00112D66 File Offset: 0x00111166
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06002649 RID: 9801 RVA: 0x00112D6E File Offset: 0x0011116E
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x0600264A RID: 9802 RVA: 0x00112D78 File Offset: 0x00111178
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

	// Token: 0x0600264B RID: 9803 RVA: 0x00112D9C File Offset: 0x0011119C
	protected override void GenerateHappyEffect(Resident resident)
	{
		float num = UnityEngine.Random.Range(0.2f, 0.5f);
		RecruitmentQualityBoostEffect effect = new RecruitmentQualityBoostEffect(new int?(60), GameWorld.instance.PlayerProfile.GameDays, (double)num, 1);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x0600264C RID: 9804 RVA: 0x00112DEC File Offset: 0x001111EC
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			ProductionResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			LuckResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
	}

	// Token: 0x040020C7 RID: 8391
	private ResidentType _residentType = ResidentType.RoyalNoble;

	// Token: 0x040020C8 RID: 8392
	private int _residentRankParameter = 34;
}
