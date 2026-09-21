using System;
using System.Collections.Generic;

// Token: 0x02000501 RID: 1281
public class KnightBase : ResidentBase
{
	// Token: 0x060025F7 RID: 9719 RVA: 0x001122C5 File Offset: 0x001106C5
	public KnightBase()
	{
	}

	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x060025F8 RID: 9720 RVA: 0x001122DD File Offset: 0x001106DD
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x060025F9 RID: 9721 RVA: 0x001122E5 File Offset: 0x001106E5
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x060025FA RID: 9722 RVA: 0x001122F0 File Offset: 0x001106F0
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CultureSkill,
				JourneyContributeType.TradeSkill
			};
		}
	}

	// Token: 0x060025FB RID: 9723 RVA: 0x00112314 File Offset: 0x00110714
	protected override void GenerateHappyEffect(Resident resident)
	{
		GodsProtectionEffect effect = new GodsProtectionEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.08);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x060025FC RID: 9724 RVA: 0x00112358 File Offset: 0x00110758
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		List<IResidentEffect> list = new List<IResidentEffect>
		{
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient)
		};
		if (growthCoeffecient >= ResidentBase.EpicResidentCoefficient)
		{
			list.Add(DivineHeartResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5));
		}
		return list;
	}

	// Token: 0x040020AF RID: 8367
	private ResidentType _residentType = ResidentType.Knight;

	// Token: 0x040020B0 RID: 8368
	private int _residentRankParameter = 16;
}
