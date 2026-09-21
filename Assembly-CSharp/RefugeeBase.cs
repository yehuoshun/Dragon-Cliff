using System;
using System.Collections.Generic;

// Token: 0x02000508 RID: 1288
public class RefugeeBase : ResidentBase
{
	// Token: 0x06002622 RID: 9762 RVA: 0x001129AF File Offset: 0x00110DAF
	public RefugeeBase()
	{
	}

	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x06002623 RID: 9763 RVA: 0x001129C5 File Offset: 0x00110DC5
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x06002624 RID: 9764 RVA: 0x001129CD File Offset: 0x00110DCD
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x06002625 RID: 9765 RVA: 0x001129D8 File Offset: 0x00110DD8
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.CollectionSkill
			};
		}
	}

	// Token: 0x06002626 RID: 9766 RVA: 0x001129F4 File Offset: 0x00110DF4
	protected override void GenerateHappyEffect(Resident resident)
	{
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.15, AttributeType.Agility, ModificationType.Multiplication);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x06002627 RID: 9767 RVA: 0x00112A38 File Offset: 0x00110E38
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			WeaponSaleResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 1.0)
		};
	}

	// Token: 0x040020BE RID: 8382
	private ResidentType _residentType = ResidentType.Refugee;

	// Token: 0x040020BF RID: 8383
	private int _residentRankParameter = 5;
}
