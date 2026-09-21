using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class BusinessManBase : ResidentBase
{
	// Token: 0x060025E5 RID: 9701 RVA: 0x00112037 File Offset: 0x00110437
	public BusinessManBase()
	{
	}

	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x060025E6 RID: 9702 RVA: 0x0011204E File Offset: 0x0011044E
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x060025E7 RID: 9703 RVA: 0x00112056 File Offset: 0x00110456
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x060025E8 RID: 9704 RVA: 0x00112060 File Offset: 0x00110460
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

	// Token: 0x060025E9 RID: 9705 RVA: 0x0011207C File Offset: 0x0011047C
	protected override void GenerateHappyEffect(Resident resident)
	{
		float num = UnityEngine.Random.Range(0.2f, 0.5f);
		GearPriceBoostEffect effect = new GearPriceBoostEffect(3, GameWorld.instance.PlayerProfile.GameDays, (double)num);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x060025EA RID: 9706 RVA: 0x001120C4 File Offset: 0x001104C4
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> result = new List<IResidentEffect>
		{
			ArmorSaleResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			WeaponSaleResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			RecruitmentResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient);
		}
		return result;
	}

	// Token: 0x040020A9 RID: 8361
	private ResidentType _residentType = ResidentType.BusinessMan;

	// Token: 0x040020AA RID: 8362
	private int _residentRankParameter = 10;
}
