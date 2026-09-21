using System;
using System.Collections.Generic;

// Token: 0x0200050B RID: 1291
public class RetiredGovernerBase : ResidentBase
{
	// Token: 0x0600263A RID: 9786 RVA: 0x00112B98 File Offset: 0x00110F98
	public RetiredGovernerBase()
	{
	}

	// Token: 0x170002CE RID: 718
	// (get) Token: 0x0600263B RID: 9787 RVA: 0x00112BB0 File Offset: 0x00110FB0
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002CF RID: 719
	// (get) Token: 0x0600263C RID: 9788 RVA: 0x00112BB8 File Offset: 0x00110FB8
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x0600263D RID: 9789 RVA: 0x00112BC0 File Offset: 0x00110FC0
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CollectionSkill,
				JourneyContributeType.ResearchSkill
			};
		}
	}

	// Token: 0x0600263E RID: 9790 RVA: 0x00112BE4 File Offset: 0x00110FE4
	protected override void GenerateHappyEffect(Resident resident)
	{
		SpiritualHeartTownEffect effect = new SpiritualHeartTownEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.3, 0.5, 3);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x0600263F RID: 9791 RVA: 0x00112C30 File Offset: 0x00111030
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> list = new List<IResidentEffect>
		{
			WeaponSaleResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			ArmorSaleResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			list.Add(WealthResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient));
		}
		return list;
	}

	// Token: 0x040020C3 RID: 8387
	private ResidentType _residentType = ResidentType.RetiredGoverner;

	// Token: 0x040020C4 RID: 8388
	private int _residentRankParameter = 38;
}
