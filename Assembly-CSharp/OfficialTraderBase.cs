using System;
using System.Collections.Generic;

// Token: 0x02000505 RID: 1285
public class OfficialTraderBase : ResidentBase
{
	// Token: 0x0600260F RID: 9743 RVA: 0x00112695 File Offset: 0x00110A95
	public OfficialTraderBase()
	{
	}

	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06002610 RID: 9744 RVA: 0x001126AD File Offset: 0x00110AAD
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06002611 RID: 9745 RVA: 0x001126B5 File Offset: 0x00110AB5
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06002612 RID: 9746 RVA: 0x001126C0 File Offset: 0x00110AC0
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.ResearchSkill,
				JourneyContributeType.CultureSkill
			};
		}
	}

	// Token: 0x06002613 RID: 9747 RVA: 0x001126E4 File Offset: 0x00110AE4
	protected override void GenerateHappyEffect(Resident resident)
	{
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.15, AttributeType.Intelligience, ModificationType.Multiplication);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x06002614 RID: 9748 RVA: 0x00112728 File Offset: 0x00110B28
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			WeaponSaleResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			ArmorSaleResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
	}

	// Token: 0x040020B7 RID: 8375
	private ResidentType _residentType = ResidentType.OfficialTrader;

	// Token: 0x040020B8 RID: 8376
	private int _residentRankParameter = 22;
}
