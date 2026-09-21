using System;
using System.Collections.Generic;

// Token: 0x02000500 RID: 1280
public class GrandMasterBase : ResidentBase
{
	// Token: 0x060025F1 RID: 9713 RVA: 0x001121E5 File Offset: 0x001105E5
	public GrandMasterBase()
	{
	}

	// Token: 0x170002AD RID: 685
	// (get) Token: 0x060025F2 RID: 9714 RVA: 0x001121FD File Offset: 0x001105FD
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002AE RID: 686
	// (get) Token: 0x060025F3 RID: 9715 RVA: 0x00112205 File Offset: 0x00110605
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002AF RID: 687
	// (get) Token: 0x060025F4 RID: 9716 RVA: 0x00112210 File Offset: 0x00110610
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CultureSkill,
				JourneyContributeType.TradeSkill,
				JourneyContributeType.ResearchSkill
			};
		}
	}

	// Token: 0x060025F5 RID: 9717 RVA: 0x0011223C File Offset: 0x0011063C
	protected override void GenerateHappyEffect(Resident resident)
	{
		StopperTownEffect effect = new StopperTownEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.3, 2);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x060025F6 RID: 9718 RVA: 0x00112280 File Offset: 0x00110680
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> list = new List<IResidentEffect>
		{
			LuckResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			list.Add(DivineHeartResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5));
		}
		return list;
	}

	// Token: 0x040020AD RID: 8365
	private ResidentType _residentType = ResidentType.GrandMaster;

	// Token: 0x040020AE RID: 8366
	private int _residentRankParameter = 42;
}
