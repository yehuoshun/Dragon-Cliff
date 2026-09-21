using System;
using System.Collections.Generic;

// Token: 0x0200050F RID: 1295
public class SwordManBase : ResidentBase
{
	// Token: 0x06002653 RID: 9811 RVA: 0x00112F0F File Offset: 0x0011130F
	public SwordManBase()
	{
	}

	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06002654 RID: 9812 RVA: 0x00112F27 File Offset: 0x00111327
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06002655 RID: 9813 RVA: 0x00112F2F File Offset: 0x0011132F
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06002656 RID: 9814 RVA: 0x00112F38 File Offset: 0x00111338
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

	// Token: 0x06002657 RID: 9815 RVA: 0x00112F54 File Offset: 0x00111354
	protected override void GenerateHappyEffect(Resident resident)
	{
		FlyingBladeEffect effect = new FlyingBladeEffect(base.GetStandardizedEffectLastingDays(), GameWorld.instance.PlayerProfile.GameDays, 0.15, 2.0);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, resident);
	}

	// Token: 0x06002658 RID: 9816 RVA: 0x00112FA0 File Offset: 0x001113A0
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			PracticeResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5),
			ProductionResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient * 0.5)
		};
	}

	// Token: 0x040020CB RID: 8395
	private ResidentType _residentType = ResidentType.Swordman;

	// Token: 0x040020CC RID: 8396
	private int _residentRankParameter = 13;
}
