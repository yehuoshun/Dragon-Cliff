using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200099F RID: 2463
[Serializable]
public abstract class TownEventProcessorBase
{
	// Token: 0x0600437C RID: 17276 RVA: 0x001B62AC File Offset: 0x001B46AC
	protected TownEventProcessorBase()
	{
	}

	// Token: 0x17000D7A RID: 3450
	// (get) Token: 0x0600437D RID: 17277
	public abstract TownEventType Type { get; }

	// Token: 0x17000D7B RID: 3451
	// (get) Token: 0x0600437E RID: 17278
	public abstract List<ResourceType> ResourceConsumptionTypes { get; }

	// Token: 0x17000D7C RID: 3452
	// (get) Token: 0x0600437F RID: 17279
	public abstract int DaysRequired { get; }

	// Token: 0x17000D7D RID: 3453
	// (get) Token: 0x06004380 RID: 17280
	public abstract int ActivePointsFrom { get; }

	// Token: 0x17000D7E RID: 3454
	// (get) Token: 0x06004381 RID: 17281
	public abstract int ActivePointsToExclusive { get; }

	// Token: 0x17000D7F RID: 3455
	// (get) Token: 0x06004382 RID: 17282
	public abstract int RequiredDifficultyValue { get; }

	// Token: 0x17000D80 RID: 3456
	// (get) Token: 0x06004383 RID: 17283
	public abstract int RequiredPolicyPoint { get; }

	// Token: 0x06004384 RID: 17284 RVA: 0x001B62B4 File Offset: 0x001B46B4
	public void SetActive()
	{
		if (!this.IsActive && GameWorld.instance.PlayerProfile.AvaliablePolicyPoints() >= this.RequiredPolicyPoint)
		{
			this.IsActive = true;
			this.CurrentAtDays = 0;
			this.DayCounter = string.Empty;
			this.ProcessingEventDifficultyValue = GameWorld.instance.PlayerProfile.GetStandardizedDiffcultyValueForTownEventSystem();
			this.HappinessSpreadRecords = new Dictionary<string, int>();
		}
	}

	// Token: 0x06004385 RID: 17285 RVA: 0x001B6320 File Offset: 0x001B4720
	public Description GetDescription()
	{
		TownEventLocalizaiton townEvent = LocalizationSession.instance.LocalizationManager.GetTownEvent(this.Type);
		return new Description
		{
			Details1 = townEvent.Description,
			Title = townEvent.Name,
			Details2 = string.Empty
		};
	}

	// Token: 0x06004386 RID: 17286 RVA: 0x001B6370 File Offset: 0x001B4770
	private double GetEventQualityBaseValue()
	{
		if (this.ProcessingEventDifficultyValue <= 50.0)
		{
			return 0.0;
		}
		double num = (this.ProcessingEventDifficultyValue - 50.0) / 200.0;
		if (num > 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	// Token: 0x06004387 RID: 17287 RVA: 0x001B63D0 File Offset: 0x001B47D0
	private double GetEventHappinessBaseValue()
	{
		if (this.ProcessingEventDifficultyValue <= 30.0)
		{
			return 400.0;
		}
		if (this.ProcessingEventDifficultyValue <= 50.0)
		{
			return 600.0;
		}
		if (this.ProcessingEventDifficultyValue <= 70.0)
		{
			return 900.0;
		}
		if (this.ProcessingEventDifficultyValue <= 80.0)
		{
			return 1100.0;
		}
		if (this.ProcessingEventDifficultyValue <= 100.0)
		{
			return 1300.0;
		}
		if (this.ProcessingEventDifficultyValue <= 120.0)
		{
			return 1600.0;
		}
		if (this.ProcessingEventDifficultyValue <= 140.0)
		{
			return 1800.0;
		}
		if (this.ProcessingEventDifficultyValue <= 160.0)
		{
			return 2100.0;
		}
		if (this.ProcessingEventDifficultyValue <= 180.0)
		{
			return 2300.0;
		}
		return 2500.0;
	}

	// Token: 0x06004388 RID: 17288 RVA: 0x001B64F4 File Offset: 0x001B48F4
	protected double GetEventHappinessRatio()
	{
		double num = Convert.ToDouble(this.HappinessSpreadRecords.Sum((KeyValuePair<string, int> r) => r.Value));
		double num2 = num / this.GetEventHappinessBaseValue();
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		return num2;
	}

	// Token: 0x06004389 RID: 17289 RVA: 0x001B6554 File Offset: 0x001B4954
	protected List<RecruitmentCandidatePresence> GetAllAdventurerPresences()
	{
		return (from u in UnitExtensions.UnitConfigurations
		select u.Value.RecruitmentPresence into p
		where GameWorld.instance.PlayerProfile.AdventurerTypeObtained(p.UnitClass)
		select p).ToList<RecruitmentCandidatePresence>();
	}

	// Token: 0x0600438A RID: 17290 RVA: 0x001B65B0 File Offset: 0x001B49B0
	protected double GetEventResultValue(double valueFrom, double valueTo)
	{
		return (valueTo - valueFrom) * this.GetEventQualityBaseValue() * (0.4 + this.GetEventHappinessRatio() * 0.6) + valueFrom;
	}

	// Token: 0x0600438B RID: 17291 RVA: 0x001B65E6 File Offset: 0x001B49E6
	public void SetInactive()
	{
		this.CurrentAtDays = 0;
		this.DayCounter = string.Empty;
		this.ProcessingEventDifficultyValue = 0.0;
		this.IsActive = false;
		this.HappinessSpreadRecords = new Dictionary<string, int>();
	}

	// Token: 0x0600438C RID: 17292 RVA: 0x001B661B File Offset: 0x001B4A1B
	public bool IsUnlocked()
	{
		return GameWorld.instance.PlayerProfile.GetStandardizedDiffcultyValueForTownEventSystem() >= (double)this.RequiredDifficultyValue;
	}

	// Token: 0x0600438D RID: 17293 RVA: 0x001B6638 File Offset: 0x001B4A38
	public double GetProgress()
	{
		return Convert.ToDouble(this.CurrentAtDays) / Convert.ToDouble(this.DaysRequired);
	}

	// Token: 0x0600438E RID: 17294 RVA: 0x001B6654 File Offset: 0x001B4A54
	private int GetRequirementResourceValueBase(double dfvalue)
	{
		if (dfvalue <= 40.0)
		{
			return 500;
		}
		if (dfvalue <= 50.0)
		{
			return 700;
		}
		if (dfvalue <= 60.0)
		{
			return 1000;
		}
		if (dfvalue <= 70.0)
		{
			return 1300;
		}
		if (dfvalue <= 80.0)
		{
			return 1600;
		}
		if (dfvalue <= 100.0)
		{
			return 1900;
		}
		if (dfvalue <= 110.0)
		{
			return 2200;
		}
		if (dfvalue <= 120.0)
		{
			return 2500;
		}
		if (dfvalue <= 150.0)
		{
			return 2800;
		}
		if (dfvalue <= 160.0)
		{
			return 3100;
		}
		if (dfvalue <= 170.0)
		{
			return 3400;
		}
		if (dfvalue <= 180.0)
		{
			return 3700;
		}
		if (dfvalue <= 190.0)
		{
			return 4500;
		}
		if (dfvalue <= 200.0)
		{
			return 5100;
		}
		if (dfvalue <= 210.0)
		{
			return 5800;
		}
		if (dfvalue <= 220.0)
		{
			return 6500;
		}
		if (dfvalue <= 230.0)
		{
			return 7500;
		}
		if (dfvalue <= 240.0)
		{
			return 8500;
		}
		return 10000;
	}

	// Token: 0x0600438F RID: 17295 RVA: 0x001B67E0 File Offset: 0x001B4BE0
	public List<ResourceConsumptionRequirement> GetResourceConsumptionPerDay()
	{
		List<ResourceType> resourceConsumptionTypes = this.ResourceConsumptionTypes;
		List<ResourceConsumptionRequirement> list = new List<ResourceConsumptionRequirement>();
		double standardizedDiffcultyValueForTownEventSystem = GameWorld.instance.PlayerProfile.GetStandardizedDiffcultyValueForTownEventSystem();
		foreach (ResourceType resourceType in resourceConsumptionTypes)
		{
			if (resourceType == ResourceType.Money || resourceType == ResourceType.PracticePoints)
			{
				list.Add(new ResourceConsumptionRequirement
				{
					ResourceType = resourceType,
					AmountRequired = this.GetRequirementResourceValueBase(standardizedDiffcultyValueForTownEventSystem)
				});
			}
		}
		return list;
	}

	// Token: 0x06004390 RID: 17296 RVA: 0x001B688C File Offset: 0x001B4C8C
	public void AddProcessDays(int numberOfDays)
	{
		if (this.DayCounter == null)
		{
			this.DayCounter = string.Empty;
			for (int i = 0; i < this.CurrentAtDays; i++)
			{
				this.DayCounter += "-";
			}
		}
		if (this.CurrentAtDays != this.DayCounter.Length)
		{
			this.CurrentAtDays = 0;
			this.DayCounter = string.Empty;
			Application.Quit();
		}
		this.CurrentAtDays += numberOfDays;
		for (int j = 0; j < numberOfDays; j++)
		{
			this.DayCounter += "-";
		}
		if (this.CurrentAtDays >= this.DaysRequired)
		{
			this.CurrentAtDays = 0;
			this.DayCounter = string.Empty;
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.TownEventCompleted, this);
			this.TownEventCompleted();
			this.HappinessSpreadRecords = new Dictionary<string, int>();
		}
	}

	// Token: 0x06004391 RID: 17297 RVA: 0x001B6988 File Offset: 0x001B4D88
	public void DailyProcess()
	{
		if (this.IsUnlocked() && this.IsActive)
		{
			List<ResourceConsumptionRequirement> resourceConsumptionPerDay = this.GetResourceConsumptionPerDay();
			if (resourceConsumptionPerDay.MetRequirements())
			{
				resourceConsumptionPerDay.Consume();
				this.AddProcessDays(1);
				foreach (Resident resident in GameWorld.instance.PlayerProfile.Residents)
				{
					int num = UnityEngine.Random.Range(this.ActivePointsFrom, this.ActivePointsToExclusive);
					bool flag = resident.AddHappiness((double)num, this.Type);
					if (flag)
					{
						if (this.HappinessSpreadRecords.ContainsKey(resident.Id))
						{
							Dictionary<string, int> happinessSpreadRecords;
							string id;
							(happinessSpreadRecords = this.HappinessSpreadRecords)[id = resident.Id] = happinessSpreadRecords[id] + num;
						}
						else
						{
							this.HappinessSpreadRecords.Add(resident.Id, num);
						}
					}
				}
			}
		}
		else
		{
			foreach (Resident resident2 in GameWorld.instance.PlayerProfile.Residents)
			{
				ResidentHappinessRecord correspondingHappinessRecordOrNull = resident2.GetCorrespondingHappinessRecordOrNull(this.Type);
				if (correspondingHappinessRecordOrNull != null)
				{
					correspondingHappinessRecordOrNull.DailyCoolDownWhileERventInactive();
				}
			}
		}
	}

	// Token: 0x06004392 RID: 17298 RVA: 0x001B6B04 File Offset: 0x001B4F04
	protected void GenerateOrientedAdventurers(List<UnitClassStyle> styles)
	{
		List<RecruitmentCandidatePresence> allAdventurerPresences = this.GetAllAdventurerPresences();
		List<RecruitmentCandidatePresence> list = (from p in allAdventurerPresences
		where styles.Any((UnitClassStyle st) => p.UnitClass.GetConfiguration().CorrespondingClassStyle == st)
		select p).ToList<RecruitmentCandidatePresence>();
		RecruitmentCandidatePresence recruitmentCandidatePresence = allAdventurerPresences.WeightedRandomSelect<RecruitmentCandidatePresence>();
		if (list.Any<RecruitmentCandidatePresence>())
		{
			recruitmentCandidatePresence = list.WeightedRandomSelect<RecruitmentCandidatePresence>();
		}
		double boostRate = this.GetEventResultValue(0.1, 0.8) + GameWorld.instance.PlayerProfile.GetAdventurerSpawnBoost();
		foreach (RecruitmentQualityBoostEffect recruitmentQualityBoostEffect in GameWorld.instance.PlayerProfile.GetTownEffects().OfType<RecruitmentQualityBoostEffect>().ToList<RecruitmentQualityBoostEffect>())
		{
			recruitmentQualityBoostEffect.RemoveTrigger(1);
		}
		QualityGrade grade = ItemExtensions.DefaultAdventurerSpawnDistribution().BoostDrop(boostRate).GetGrade();
		float quality = UnitExtensions.GenerateGradeQualitySettingValueForAdventurer(grade, (!GameWorld.instance.PlayerProfile.GetEnabledStars().Any((int s) => s == 2)) ? 0.0 : 0.6);
		AdventurerProfile profile = recruitmentCandidatePresence.UnitClass.GenerateAdventurerProfileWithDefinedQuality(quality);
		List<AdventurerCandidate> candidates = new List<AdventurerCandidate>
		{
			new AdventurerCandidate
			{
				Profile = profile,
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

	// Token: 0x06004393 RID: 17299
	public abstract void TownEventCompleted();

	// Token: 0x06004394 RID: 17300 RVA: 0x001B6CFC File Offset: 0x001B50FC
	[CompilerGenerated]
	private static int <GetEventHappinessRatio>m__0(KeyValuePair<string, int> r)
	{
		return r.Value;
	}

	// Token: 0x06004395 RID: 17301 RVA: 0x001B6D05 File Offset: 0x001B5105
	[CompilerGenerated]
	private static RecruitmentCandidatePresence <GetAllAdventurerPresences>m__1(KeyValuePair<UnitClass, UnitConfigurationBase> u)
	{
		return u.Value.RecruitmentPresence;
	}

	// Token: 0x06004396 RID: 17302 RVA: 0x001B6D13 File Offset: 0x001B5113
	[CompilerGenerated]
	private static bool <GetAllAdventurerPresences>m__2(RecruitmentCandidatePresence p)
	{
		return GameWorld.instance.PlayerProfile.AdventurerTypeObtained(p.UnitClass);
	}

	// Token: 0x06004397 RID: 17303 RVA: 0x001B6D2A File Offset: 0x001B512A
	[CompilerGenerated]
	private static bool <GenerateOrientedAdventurers>m__3(int s)
	{
		return s == 2;
	}

	// Token: 0x06004398 RID: 17304 RVA: 0x001B6D30 File Offset: 0x001B5130
	[CompilerGenerated]
	private static IBuildingProfile <GenerateOrientedAdventurers>m__4(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06004399 RID: 17305 RVA: 0x001B6D39 File Offset: 0x001B5139
	[CompilerGenerated]
	private static bool <GenerateOrientedAdventurers>m__5(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.RecruitmentFacility;
	}

	// Token: 0x0400331A RID: 13082
	public string DayCounter;

	// Token: 0x0400331B RID: 13083
	public bool IsActive;

	// Token: 0x0400331C RID: 13084
	public int CurrentAtDays;

	// Token: 0x0400331D RID: 13085
	public double ProcessingEventDifficultyValue;

	// Token: 0x0400331E RID: 13086
	public Dictionary<string, int> HappinessSpreadRecords;

	// Token: 0x0400331F RID: 13087
	[CompilerGenerated]
	private static Func<KeyValuePair<string, int>, int> <>f__am$cache0;

	// Token: 0x04003320 RID: 13088
	[CompilerGenerated]
	private static Func<KeyValuePair<UnitClass, UnitConfigurationBase>, RecruitmentCandidatePresence> <>f__am$cache1;

	// Token: 0x04003321 RID: 13089
	[CompilerGenerated]
	private static Func<RecruitmentCandidatePresence, bool> <>f__am$cache2;

	// Token: 0x04003322 RID: 13090
	[CompilerGenerated]
	private static Func<int, bool> <>f__am$cache3;

	// Token: 0x04003323 RID: 13091
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache4;

	// Token: 0x04003324 RID: 13092
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache5;

	// Token: 0x02001004 RID: 4100
	[CompilerGenerated]
	private sealed class <GenerateOrientedAdventurers>c__AnonStorey0
	{
		// Token: 0x060067C8 RID: 26568 RVA: 0x001B6D4D File Offset: 0x001B514D
		public <GenerateOrientedAdventurers>c__AnonStorey0()
		{
		}

		// Token: 0x060067C9 RID: 26569 RVA: 0x001B6D58 File Offset: 0x001B5158
		internal bool <>m__0(RecruitmentCandidatePresence p)
		{
			return this.styles.Any((UnitClassStyle st) => p.UnitClass.GetConfiguration().CorrespondingClassStyle == st);
		}

		// Token: 0x040061CD RID: 25037
		internal List<UnitClassStyle> styles;

		// Token: 0x02001005 RID: 4101
		private sealed class <GenerateOrientedAdventurers>c__AnonStorey1
		{
			// Token: 0x060067CA RID: 26570 RVA: 0x001B6D90 File Offset: 0x001B5190
			public <GenerateOrientedAdventurers>c__AnonStorey1()
			{
			}

			// Token: 0x060067CB RID: 26571 RVA: 0x001B6D98 File Offset: 0x001B5198
			internal bool <>m__0(UnitClassStyle st)
			{
				return this.p.UnitClass.GetConfiguration().CorrespondingClassStyle == st;
			}

			// Token: 0x040061CE RID: 25038
			internal RecruitmentCandidatePresence p;

			// Token: 0x040061CF RID: 25039
			internal TownEventProcessorBase.<GenerateOrientedAdventurers>c__AnonStorey0 <>f__ref$0;
		}
	}
}
