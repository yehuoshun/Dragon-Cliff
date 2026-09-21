using System;
using System.Collections.Generic;

// Token: 0x0200050C RID: 1292
public class RoninBase : ResidentBase
{
	// Token: 0x06002640 RID: 9792 RVA: 0x00112C8C File Offset: 0x0011108C
	public RoninBase()
	{
	}

	// Token: 0x170002D1 RID: 721
	// (get) Token: 0x06002641 RID: 9793 RVA: 0x00112CA2 File Offset: 0x001110A2
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06002642 RID: 9794 RVA: 0x00112CAA File Offset: 0x001110AA
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06002643 RID: 9795 RVA: 0x00112CB4 File Offset: 0x001110B4
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CollectionSkill,
				JourneyContributeType.TradeSkill
			};
		}
	}

	// Token: 0x06002644 RID: 9796 RVA: 0x00112CD6 File Offset: 0x001110D6
	public override int GetPresence()
	{
		return 10;
	}

	// Token: 0x06002645 RID: 9797 RVA: 0x00112CDC File Offset: 0x001110DC
	protected override void GenerateHappyEffect(Resident resident)
	{
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.2, AttributeType.Allresistances, ModificationType.Multiplication);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x06002646 RID: 9798 RVA: 0x00112D24 File Offset: 0x00111124
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement difficultyLevelMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			PracticeResidentEffect.CreateDifficultyRelatedEffect(difficultyLevelMeasurement, growthCoeffecient * 1.0)
		};
	}

	// Token: 0x040020C5 RID: 8389
	private ResidentType _residentType = ResidentType.Ronin;

	// Token: 0x040020C6 RID: 8390
	private int _residentRankParameter = 2;
}
