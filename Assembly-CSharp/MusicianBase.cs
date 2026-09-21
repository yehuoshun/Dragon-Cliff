using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class MusicianBase : ResidentBase
{
	// Token: 0x06002603 RID: 9731 RVA: 0x001124B7 File Offset: 0x001108B7
	public MusicianBase()
	{
	}

	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x06002604 RID: 9732 RVA: 0x001124CF File Offset: 0x001108CF
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x06002605 RID: 9733 RVA: 0x001124D7 File Offset: 0x001108D7
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x06002606 RID: 9734 RVA: 0x001124E0 File Offset: 0x001108E0
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CultureSkill
			};
		}
	}

	// Token: 0x06002607 RID: 9735 RVA: 0x001124FC File Offset: 0x001108FC
	protected override void GenerateHappyEffect(Resident resident)
	{
		float num = UnityEngine.Random.Range(0.3f, 0.8f);
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(3, GameWorld.instance.PlayerProfile.GameDays, (double)num, AttributeType.CritDamage, ModificationType.Addition);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x06002608 RID: 9736 RVA: 0x00112544 File Offset: 0x00110944
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> list = new List<IResidentEffect>
		{
			LuckResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			list.Add(MysticStoneResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.4));
		}
		return list;
	}

	// Token: 0x040020B3 RID: 8371
	private ResidentType _residentType = ResidentType.Musician;

	// Token: 0x040020B4 RID: 8372
	private int _residentRankParameter = 30;
}
