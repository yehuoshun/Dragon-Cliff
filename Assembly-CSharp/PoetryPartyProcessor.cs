using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200099D RID: 2461
[Serializable]
public class PoetryPartyProcessor : TownEventProcessorBase
{
	// Token: 0x06004367 RID: 17255 RVA: 0x001B71FF File Offset: 0x001B55FF
	public PoetryPartyProcessor()
	{
	}

	// Token: 0x17000D6C RID: 3436
	// (get) Token: 0x06004368 RID: 17256 RVA: 0x001B7207 File Offset: 0x001B5607
	public override TownEventType Type
	{
		get
		{
			return TownEventType.PoetryParty;
		}
	}

	// Token: 0x17000D6D RID: 3437
	// (get) Token: 0x06004369 RID: 17257 RVA: 0x001B720C File Offset: 0x001B560C
	public override List<ResourceType> ResourceConsumptionTypes
	{
		get
		{
			return new List<ResourceType>
			{
				ResourceType.Money
			};
		}
	}

	// Token: 0x17000D6E RID: 3438
	// (get) Token: 0x0600436A RID: 17258 RVA: 0x001B722B File Offset: 0x001B562B
	public override int DaysRequired
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x17000D6F RID: 3439
	// (get) Token: 0x0600436B RID: 17259 RVA: 0x001B722F File Offset: 0x001B562F
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D70 RID: 3440
	// (get) Token: 0x0600436C RID: 17260 RVA: 0x001B7232 File Offset: 0x001B5632
	public override int ActivePointsToExclusive
	{
		get
		{
			return 6;
		}
	}

	// Token: 0x17000D71 RID: 3441
	// (get) Token: 0x0600436D RID: 17261 RVA: 0x001B7235 File Offset: 0x001B5635
	public override int RequiredDifficultyValue
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x17000D72 RID: 3442
	// (get) Token: 0x0600436E RID: 17262 RVA: 0x001B7239 File Offset: 0x001B5639
	public override int RequiredPolicyPoint
	{
		get
		{
			return 40;
		}
	}

	// Token: 0x0600436F RID: 17263 RVA: 0x001B7240 File Offset: 0x001B5640
	public override void TownEventCompleted()
	{
		List<RecruitmentCandidatePresence> allAdventurerPresences = base.GetAllAdventurerPresences();
		double boostRate = base.GetEventResultValue(0.1, 0.8) + GameWorld.instance.PlayerProfile.GetAdventurerSpawnBoost();
		foreach (RecruitmentQualityBoostEffect recruitmentQualityBoostEffect in GameWorld.instance.PlayerProfile.GetTownEffects().OfType<RecruitmentQualityBoostEffect>().ToList<RecruitmentQualityBoostEffect>())
		{
			recruitmentQualityBoostEffect.RemoveTrigger(2);
		}
		QualityGrade grade = ItemExtensions.DefaultAdventurerSpawnDistribution().BoostDrop(boostRate).GetGrade();
		float quality = UnitExtensions.GenerateGradeQualitySettingValueForAdventurer(grade, (!GameWorld.instance.PlayerProfile.GetEnabledStars().Any((int s) => s == 2)) ? 0.0 : 0.6);
		List<AdventurerCandidate> candidates = new List<AdventurerCandidate>
		{
			new AdventurerCandidate
			{
				Profile = allAdventurerPresences.WeightedRandomSelect<RecruitmentCandidatePresence>().UnitClass.GenerateAdventurerProfileWithDefinedQuality(quality),
				DaysTillExpiration = RecruitmentFacility.AdventurerCandidateExpiration
			},
			new AdventurerCandidate
			{
				Profile = allAdventurerPresences.WeightedRandomSelect<RecruitmentCandidatePresence>().UnitClass.GenerateAdventurerProfileWithDefinedQuality(quality),
				DaysTillExpiration = RecruitmentFacility.AdventurerCandidateExpiration
			}
		};
		RecruitmentFacility recruitmentFacility = (from b in GameWorld.instance.PlayerProfile.Buildings
		select b.Value into b
		where b != null && b.BuildingType == BuildingType.RecruitmentFacility
		select b).FirstOrDefault<IBuildingProfile>() as RecruitmentFacility;
		if (recruitmentFacility != null)
		{
			recruitmentFacility.AddCandidates(candidates);
		}
	}

	// Token: 0x06004370 RID: 17264 RVA: 0x001B742C File Offset: 0x001B582C
	[CompilerGenerated]
	private static bool <TownEventCompleted>m__0(int s)
	{
		return s == 2;
	}

	// Token: 0x06004371 RID: 17265 RVA: 0x001B7432 File Offset: 0x001B5832
	[CompilerGenerated]
	private static IBuildingProfile <TownEventCompleted>m__1(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06004372 RID: 17266 RVA: 0x001B743B File Offset: 0x001B583B
	[CompilerGenerated]
	private static bool <TownEventCompleted>m__2(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.RecruitmentFacility;
	}

	// Token: 0x04003317 RID: 13079
	[CompilerGenerated]
	private static Func<int, bool> <>f__am$cache0;

	// Token: 0x04003318 RID: 13080
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache1;

	// Token: 0x04003319 RID: 13081
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache2;
}
