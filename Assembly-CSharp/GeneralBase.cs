using System;
using System.Collections.Generic;

// Token: 0x020004FF RID: 1279
public class GeneralBase : ResidentBase
{
	// Token: 0x060025EB RID: 9707 RVA: 0x0011211B File Offset: 0x0011051B
	public GeneralBase()
	{
	}

	// Token: 0x170002AA RID: 682
	// (get) Token: 0x060025EC RID: 9708 RVA: 0x00112133 File Offset: 0x00110533
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002AB RID: 683
	// (get) Token: 0x060025ED RID: 9709 RVA: 0x0011213B File Offset: 0x0011053B
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x060025EE RID: 9710 RVA: 0x00112144 File Offset: 0x00110544
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

	// Token: 0x060025EF RID: 9711 RVA: 0x00112160 File Offset: 0x00110560
	protected override void GenerateHappyEffect(Resident resident)
	{
		TigerRoarTownEffect effect = new TigerRoarTownEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.1, 0.1, 3);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x060025F0 RID: 9712 RVA: 0x001121AC File Offset: 0x001105AC
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> list = new List<IResidentEffect>
		{
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			list.Add(DeterminationResidentEffect.CreateDifficultyRelatedEffect());
		}
		return list;
	}

	// Token: 0x040020AB RID: 8363
	private ResidentType _residentType = ResidentType.General;

	// Token: 0x040020AC RID: 8364
	private int _residentRankParameter = 40;
}
