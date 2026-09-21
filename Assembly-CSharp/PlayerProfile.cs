using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Token: 0x020004C5 RID: 1221
[Serializable]
public class PlayerProfile
{
	// Token: 0x060023F2 RID: 9202 RVA: 0x00105DCE File Offset: 0x001041CE
	public PlayerProfile()
	{
	}

	// Token: 0x060023F3 RID: 9203 RVA: 0x00105DD6 File Offset: 0x001041D6
	public bool IsEffectUnlocked(SpecialEffectType type)
	{
		if (this.EffectUnlocked == null)
		{
			this.EffectUnlocked = new Dictionary<SpecialEffectType, bool>();
		}
		return this.EffectUnlocked.ContainsKey(type) && this.EffectUnlocked[type];
	}

	// Token: 0x060023F4 RID: 9204 RVA: 0x00105E0E File Offset: 0x0010420E
	public void UnlockEffect(SpecialEffectType type)
	{
		if (!this.IsEffectUnlocked(type))
		{
			if (this.EffectUnlocked.ContainsKey(type))
			{
				this.EffectUnlocked[type] = true;
			}
			else
			{
				this.EffectUnlocked.Add(type, true);
			}
		}
	}

	// Token: 0x060023F5 RID: 9205 RVA: 0x00105E4C File Offset: 0x0010424C
	public void StartScrollGenerationScope()
	{
		if (this.ScrollGenerationSeed == null)
		{
			this.ScrollGenerationSeed = new int?(UnityEngine.Random.Range(0, int.MaxValue));
		}
		UnityEngine.Random.InitState(this.ScrollGenerationSeed.Value);
	}

	// Token: 0x060023F6 RID: 9206 RVA: 0x00105E84 File Offset: 0x00104284
	public void RotateScrollGenerationSeed()
	{
		UnityEngine.Random.InitState(this.ScrollGenerationSeed.Value);
		this.ScrollGenerationSeed = new int?(UnityEngine.Random.Range(0, int.MaxValue));
	}

	// Token: 0x060023F7 RID: 9207 RVA: 0x00105EAC File Offset: 0x001042AC
	public void RunPredictable(string key, Action run)
	{
		if (!this.AdditionalData.ContainsInt(key))
		{
			this.AdditionalData.AddOrUpdateData(key, UnityEngine.Random.Range(0, int.MaxValue));
		}
		UnityEngine.Random.InitState(this.AdditionalData.GetInt(key));
		run();
		UnityEngine.Random.InitState(this.AdditionalData.GetInt(key));
		this.AdditionalData.AddOrUpdateData(key, UnityEngine.Random.Range(0, int.MaxValue));
	}

	// Token: 0x060023F8 RID: 9208 RVA: 0x00105F20 File Offset: 0x00104320
	public Dictionary<ResourceType, int> GetGenerationSeeds()
	{
		if (this.GenerationSeeds == null)
		{
			this.GenerationSeeds = new Dictionary<ResourceType, int>();
		}
		return this.GenerationSeeds;
	}

	// Token: 0x060023F9 RID: 9209 RVA: 0x00105F40 File Offset: 0x00104340
	public int GetGenerationSeedValue(ResourceType type)
	{
		Dictionary<ResourceType, int> generationSeeds = this.GetGenerationSeeds();
		if (generationSeeds.ContainsKey(type))
		{
			return generationSeeds[type];
		}
		generationSeeds.Add(type, UnityEngine.Random.Range(0, int.MaxValue));
		return generationSeeds[type];
	}

	// Token: 0x060023FA RID: 9210 RVA: 0x00105F81 File Offset: 0x00104381
	public void StartGenerationSeedScope(ResourceType type)
	{
		UnityEngine.Random.InitState(this.GetGenerationSeedValue(type));
	}

	// Token: 0x060023FB RID: 9211 RVA: 0x00105F90 File Offset: 0x00104390
	public void RotateSeed(ResourceType type)
	{
		int generationSeedValue = this.GetGenerationSeedValue(type);
		UnityEngine.Random.InitState(generationSeedValue);
		int value = UnityEngine.Random.Range(0, int.MaxValue);
		this.GetGenerationSeeds()[type] = value;
	}

	// Token: 0x060023FC RID: 9212 RVA: 0x00105FC4 File Offset: 0x001043C4
	public List<TownEffectBase> GetTownEffects()
	{
		if (this.TownEffects == null)
		{
			this.TownEffects = new List<TownEffectBase>();
		}
		return this.TownEffects;
	}

	// Token: 0x060023FD RID: 9213 RVA: 0x00105FE4 File Offset: 0x001043E4
	public List<TownEventProcessorBase> GetTownEventProcessors()
	{
		if (this.TownEventProcessors == null || this.TownEventProcessors.Count == 0)
		{
			this.TownEventProcessors = new List<TownEventProcessorBase>
			{
				new TeaPartyProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				},
				new BanquetProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				},
				new DrummingProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				},
				new MeditationProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				},
				new PoetryPartyProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				},
				new TradeProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				},
				new AlchemyProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				},
				new ArmoryResearchProcessor
				{
					IsActive = false,
					CurrentAtDays = 0,
					DayCounter = string.Empty
				}
			};
		}
		return this.TownEventProcessors;
	}

	// Token: 0x060023FE RID: 9214 RVA: 0x00106168 File Offset: 0x00104568
	public void RemoveTownEffect(TownEffectBase effect)
	{
		TownEffectBase townEffectBase = this.GetTownEffects().FirstOrDefault((TownEffectBase e) => e == effect);
		if (townEffectBase != null)
		{
			this.GetTownEffects().Remove(townEffectBase);
			this.ReceiveEvent(GameWorldEvent.TownEffectRemoved, townEffectBase);
		}
	}

	// Token: 0x060023FF RID: 9215 RVA: 0x001061B8 File Offset: 0x001045B8
	public void AddTownEffect(TownEffectBase effect, object trigger)
	{
		if (this.GetTownEffects().Any((TownEffectBase ef) => ef.CanbeMergedWith(effect)))
		{
			TownEffectBase townEffectBase = this.GetTownEffects().First((TownEffectBase ef) => ef.CanbeMergedWith(effect));
			townEffectBase.Merge(effect);
		}
		else
		{
			this.GetTownEffects().Add(effect);
			this.ReceiveEvent(GameWorldEvent.TownEffectAdded, new TownEffectAddedEvent
			{
				Effect = effect,
				Trigger = trigger
			});
		}
		this.ReceiveEvent(GameWorldEvent.TownEffectGenerated, new TownEffectAddedEvent
		{
			Effect = effect,
			Trigger = trigger
		});
	}

	// Token: 0x06002400 RID: 9216 RVA: 0x0010626C File Offset: 0x0010466C
	public DifficultyLevelMeasurement GetEndlessDungeonDf()
	{
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(this.GetEndlessDungeonValue(), -1);
	}

	// Token: 0x06002401 RID: 9217 RVA: 0x0010627A File Offset: 0x0010467A
	public double GetEndlessDungeonValue()
	{
		if (this.EndlessDungeonDifficultyValue == null)
		{
			this.EndlessDungeonDifficultyValue = new double?(0.0);
		}
		return this.EndlessDungeonDifficultyValue.Value;
	}

	// Token: 0x06002402 RID: 9218 RVA: 0x001062AB File Offset: 0x001046AB
	public void RunWhile(string tag, Action run)
	{
		if (!this.AdditionalData.ContainsBool(tag) || !this.AdditionalData.GetBool(tag))
		{
			run();
			this.AdditionalData.AddOrUpdateData(tag, true);
		}
	}

	// Token: 0x06002403 RID: 9219 RVA: 0x001062E4 File Offset: 0x001046E4
	public List<int> GetEnabledStars()
	{
		List<int> list = new List<int>
		{
			1
		};
		if (this.QuestIsCompleted(QuestIdentifier.Side_5, 1))
		{
			list.Add(2);
		}
		return list;
	}

	// Token: 0x06002404 RID: 9220 RVA: 0x00106318 File Offset: 0x00104718
	public int GetMaximumItemTierObtainable()
	{
		List<DifficultyLevelMeasurement> list = new List<DifficultyLevelMeasurement>();
		list.Add(this.GetDifficultyLevelMeasurement_OneStar());
		if (this.GetProgress(new int?(2)).MaxAchievedDifficultyValue > 0.0)
		{
			list.Add(DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(this.GetProgress(new int?(2)).MaxAchievedDifficultyValue, 2));
		}
		if (this.EndlessDungeonDifficultyValue > 0.0)
		{
			list.Add(this.GetEndlessDungeonDf());
		}
		return (from df in list
		select df.GetCorrespondingItemTierLevel(ResourceType.HiddenWood) into a
		orderby a descending
		select a).First<int>();
	}

	// Token: 0x06002405 RID: 9221 RVA: 0x001063F8 File Offset: 0x001047F8
	public double GetStandardizedDiffcultyValueForTownEventSystem()
	{
		double maxAchievedDifficultyValue = this.GetProgress(new int?(1)).MaxAchievedDifficultyValue;
		double num = (this.GetProgress(new int?(2)).MaxAchievedDifficultyValue <= 0.0) ? 0.0 : (this.GetProgress(new int?(2)).MaxAchievedDifficultyValue + 150.0);
		double num2 = (maxAchievedDifficultyValue < num) ? num : maxAchievedDifficultyValue;
		if (num2 > 250.0)
		{
			num2 = 250.0;
		}
		return num2;
	}

	// Token: 0x06002406 RID: 9222 RVA: 0x0010648C File Offset: 0x0010488C
	public int AvaliablePolicyPoints()
	{
		return 100 - (from p in this.GetTownEventProcessors()
		where p.IsActive
		select p).Sum((TownEventProcessorBase p) => p.RequiredPolicyPoint);
	}

	// Token: 0x06002407 RID: 9223 RVA: 0x001064E6 File Offset: 0x001048E6
	public void SetStarRating(int star)
	{
		this.StarRating = new int?(star);
	}

	// Token: 0x06002408 RID: 9224 RVA: 0x001064F4 File Offset: 0x001048F4
	public PlayerProgress GetProgress(int? starrating = null)
	{
		if (starrating != null)
		{
			return this.Progresses[starrating.Value];
		}
		return this.Progresses[this.GetStarRating()];
	}

	// Token: 0x06002409 RID: 9225 RVA: 0x00106526 File Offset: 0x00104926
	public bool EndlessDungeonIsEnabled()
	{
		return this.GetProgress(new int?(2)).Reputation >= 10000.0;
	}

	// Token: 0x0600240A RID: 9226 RVA: 0x00106547 File Offset: 0x00104947
	public bool AdvancedTeamEnabled()
	{
		return true;
	}

	// Token: 0x17000272 RID: 626
	// (get) Token: 0x0600240B RID: 9227 RVA: 0x0010654A File Offset: 0x0010494A
	public double DayRate
	{
		get
		{
			return 0.016666666666666666;
		}
	}

	// Token: 0x0600240C RID: 9228 RVA: 0x00106555 File Offset: 0x00104955
	public bool HasSpecialAdventureOpen()
	{
		return this.GetSpecialAdventureTypes().Any<AdventureType>();
	}

	// Token: 0x0600240D RID: 9229 RVA: 0x00106562 File Offset: 0x00104962
	public UnitClass GetRandomAdventurer()
	{
		return this.AdventurerProfiles[UnityEngine.Random.Range(0, this.AdventurerProfiles.Count)].UnitClass;
	}

	// Token: 0x0600240E RID: 9230 RVA: 0x00106588 File Offset: 0x00104988
	public List<AdventureType> GetSpecialAdventureTypes()
	{
		List<AdventureType> list = new List<AdventureType>();
		list.AddRange(from r in this.GetQuestRequirements<HundredBattleRequirementLogic>(true)
		where !r.fullfilled
		select r.DungeonType);
		list.AddRange(from r in this.GetQuestRequirements<CustomizedDungeonThroughRequirementLogic>(true)
		where !r.fullfilled && r.IsTwistedTimeDungeon
		select r.DungeonType);
		return list;
	}

	// Token: 0x0600240F RID: 9231 RVA: 0x00106640 File Offset: 0x00104A40
	public void ClearUpData()
	{
		int i;
		this.Items = (from i in this.Items
		where i != null
		select i).ToList<Item>();
		this.SaveFileName = this.SaveFileName.Replace(".sav", ".dragon");
		if (this.CurrentJourneys == null)
		{
			this.CurrentJourneys = new List<TripRecord>();
		}
		if (this.CurrentVehicles == null)
		{
			this.CurrentVehicles = new List<Vehicle>();
		}
		this.CurrentJourneys.RemoveAll((TripRecord j) => j.Claimed && j.Completed);
		if (this.StarRating == null)
		{
			this.StarRating = new int?(1);
		}
		if (this.TownEffects != null)
		{
			IEnumerable<ArmoryMasteryEffect> toremove = from e in this.TownEffects.OfType<ArmoryMasteryEffect>()
			where e.NumberOfTriggersLeft > 2000
			select e;
			this.TownEffects.RemoveAll((TownEffectBase t) => toremove.Any((ArmoryMasteryEffect a) => a == t));
		}
		if (this.Progresses == null || !this.Progresses.Any<KeyValuePair<int, PlayerProgress>>())
		{
			this.Progresses = new Dictionary<int, PlayerProgress>
			{
				{
					1,
					new PlayerProgress
					{
						QuestCompletionRecords = this.QuestCompletionRecords,
						QuestChainCompletionRecords = this.QuestChainCompletionRecords,
						Reputation = this.Reputation,
						Quests = this.Quests,
						DungeonRecords = this.DungeonRecords,
						QuestIssuedRecords = this.QuestIssuedRecords,
						DialogSpokenRecords = this.DialogSpokenRecords,
						StoryTriggerDates = this.StoryTriggerDates,
						StoryTriggeredRecords = this.StoryTriggeredRecords,
						MaxAchievedDifficultyValue = this.Reputation / 100.0
					}
				},
				{
					2,
					PlayerProgress.Init()
				},
				{
					3,
					PlayerProgress.Init()
				},
				{
					4,
					PlayerProgress.Init()
				},
				{
					5,
					PlayerProgress.Init()
				},
				{
					6,
					PlayerProgress.Init()
				},
				{
					7,
					PlayerProgress.Init()
				},
				{
					8,
					PlayerProgress.Init()
				},
				{
					9,
					PlayerProgress.Init()
				},
				{
					10,
					PlayerProgress.Init()
				}
			};
		}
		for (i = 1; i <= 10; i++)
		{
			if (!this.Progresses.ContainsKey(i))
			{
				this.Progresses.Add(i, PlayerProgress.Init());
			}
		}
		foreach (KeyValuePair<int, PlayerProgress> keyValuePair in this.Progresses)
		{
			if (keyValuePair.Value != null)
			{
				if (keyValuePair.Value.DungeonRecords.All((DungeonRecord d) => d.AdventureType != AdventureType.NorthernTerritory))
				{
					keyValuePair.Value.DungeonRecords.Add(DungeonRecord.InitLockedRecord(AdventureType.NorthernTerritory));
				}
				keyValuePair.Value.Quests.RemoveAll((Quest q) => q == null);
			}
		}
		foreach (Resident resident in this.Residents)
		{
			if (resident.JourneyContributionModifiers == null)
			{
				resident.JourneyContributionModifiers = resident.Type.GetResidentBase().GenerateJourneyContributions(this.GetDifficultyLevelMeasurement_OneStar(), resident.Grade);
			}
		}
		if (this.Candidates != null)
		{
			foreach (ResidentCandidate residentCandidate in this.Candidates)
			{
				if (residentCandidate.Candidate.JourneyContributionModifiers == null)
				{
					residentCandidate.Candidate.JourneyContributionModifiers = residentCandidate.Candidate.Type.GetResidentBase().GenerateJourneyContributions(this.GetDifficultyLevelMeasurement_OneStar(), residentCandidate.Candidate.Grade);
				}
			}
		}
		if (this.Resources != null)
		{
			this.ResourcesAt = ((this.ResourcesAt != null && this.ResourcesAt.Any<KeyValuePair<ResourceType, ResourceProfileAntiCheat>>()) ? this.ResourcesAt : new Dictionary<ResourceType, ResourceProfileAntiCheat>());
			foreach (ResourceProfile resourceProfile in this.Resources)
			{
				if (this.ResourcesAt.ContainsKey(resourceProfile.ResourceType))
				{
					this.ResourcesAt[resourceProfile.ResourceType] = new ResourceProfileAntiCheat
					{
						ResourceType = resourceProfile.ResourceType,
						Amount = resourceProfile.Amount * PlayerProfile.CurrentKey
					};
				}
				else
				{
					this.ResourcesAt.Add(resourceProfile.ResourceType, new ResourceProfileAntiCheat
					{
						ResourceType = resourceProfile.ResourceType,
						Amount = resourceProfile.Amount * PlayerProfile.CurrentKey
					});
				}
			}
		}
		if (this.AchievedDifficultyValue == null)
		{
			this.AchievedDifficultyValue = new double?(this.GetProgress(null).Reputation / 100.0);
		}
		if (this.AchievedDifficultyValue < this.GetProgress(null).Reputation / 100.0)
		{
			this.AchievedDifficultyValue = new double?(this.GetProgress(null).Reputation / 100.0);
		}
		foreach (AdventurerProfile adventurerProfile in this.AdventurerProfiles)
		{
			if (adventurerProfile.TalentVersionDetails != PlayerProfile.TalentVersionDetails)
			{
				if (adventurerProfile.Talents == null)
				{
					adventurerProfile.Talents = new List<IAdventurerTalent>();
				}
				foreach (IAdventurerTalent talent in adventurerProfile.Talents)
				{
					talent.Reset(adventurerProfile);
				}
				adventurerProfile.Talents = (adventurerProfile.UnitClass.GetConfiguration() as AdventurerUnitConfigurationBase).GenerateTalents();
				adventurerProfile.TalentPoints = adventurerProfile.GetLevel() / 5;
				if (adventurerProfile.TalentPoints > 17)
				{
					adventurerProfile.TalentPoints = 17;
				}
				adventurerProfile.TalentVersionDetails = PlayerProfile.TalentVersionDetails;
			}
		}
		if (this.NumberOfResidentSlots > PlayerProfile.MaxResidentSlot)
		{
			this.NumberOfResidentSlots = PlayerProfile.MaxResidentSlot;
			this.Residents = ((this.Residents == null) ? new List<Resident>() : this.Residents.Take(PlayerProfile.MaxResidentSlot).ToList<Resident>());
		}
		RecruitmentFacility recruitmentFacility = (from b in this.Buildings
		select b.Value into b
		where b != null && b is RecruitmentFacility
		select b).FirstOrDefault<IBuildingProfile>() as RecruitmentFacility;
		if (recruitmentFacility != null)
		{
			foreach (AdventurerCandidate adventurerCandidate in recruitmentFacility.Candidates)
			{
				AdventurerProfile profile = adventurerCandidate.Profile;
				if (profile.Talents == null)
				{
					profile.Talents = new List<IAdventurerTalent>();
				}
				if (profile.TalentVersionDetails != PlayerProfile.TalentVersionDetails)
				{
					foreach (IAdventurerTalent talent2 in profile.Talents)
					{
						talent2.Reset(profile);
					}
					profile.Talents = (profile.UnitClass.GetConfiguration() as AdventurerUnitConfigurationBase).GenerateTalents();
					profile.TalentPoints = profile.GetLevel() / 5;
					if (profile.TalentPoints > 17)
					{
						profile.TalentPoints = 17;
					}
					profile.TalentVersionDetails = PlayerProfile.TalentVersionDetails;
				}
			}
		}
		if (this.TownEffects != null)
		{
			this.TownEffects = (from ef in this.TownEffects
			where ef != null
			select ef).ToList<TownEffectBase>();
		}
		if (this.EndlessRecord == null)
		{
			this.EndlessRecord = DungeonRecord.InitLockedRecord(AdventureType.Endless_Entry);
		}
		if (!this.AdditionalData.ContainsString(Adventure.EndlessAdventureLevelKey))
		{
			this.AdditionalData.AddOrUpdateData(Adventure.EndlessAdventureLevelKey, Adventure.EndlessAdventurePartial + this.EndlessDungeonDifficultyValue.GetValueOrDefault());
		}
	}

	// Token: 0x06002410 RID: 9232 RVA: 0x00106FDC File Offset: 0x001053DC
	public List<ResourceProfileAntiCheat> GetConsumables()
	{
		return (from k in this.ResourcesAt.Keys
		where k.GetResourceCategory() == ResourceCategory.Consumable
		select k into r
		select this.ResourcesAt[r]).ToList<ResourceProfileAntiCheat>();
	}

	// Token: 0x06002411 RID: 9233 RVA: 0x0010702C File Offset: 0x0010542C
	public int GetCurrentEndlessLevelFromBackup()
	{
		string @string = GameWorld.instance.PlayerProfile.AdditionalData.GetString(Adventure.EndlessAdventureLevelKey);
		return Convert.ToInt32(@string.Replace(Adventure.EndlessAdventurePartial, string.Empty));
	}

	// Token: 0x06002412 RID: 9234 RVA: 0x0010706A File Offset: 0x0010546A
	public int GetStarRating()
	{
		if (this.StarRating == null)
		{
			this.StarRating = new int?(1);
		}
		return this.StarRating.Value;
	}

	// Token: 0x06002413 RID: 9235 RVA: 0x00107093 File Offset: 0x00105493
	public bool ExplorationEnabled()
	{
		return ResourceType.PortBlueprint.HasObtained();
	}

	// Token: 0x06002414 RID: 9236 RVA: 0x001070A0 File Offset: 0x001054A0
	public List<VehicleGeneratorBase> GetProduceableVehicles()
	{
		List<VehicleType> list = new List<VehicleType>();
		if (this.AchievedDifficultyValue >= 100.0)
		{
			list.Add(VehicleType.ExplorationBoatLevelOne);
		}
		if (this.AchievedDifficultyValue >= 130.0)
		{
			list.Add(VehicleType.ExplorationBoatLevelTwo);
		}
		if (this.AchievedDifficultyValue >= 160.0)
		{
			list.Add(VehicleType.ExplorationBoatLevelThree);
		}
		IEnumerable<VehicleType> source = list;
		if (PlayerProfile.<>f__mg$cache0 == null)
		{
			PlayerProfile.<>f__mg$cache0 = new Func<VehicleType, VehicleGeneratorBase>(TravellerExtensions.GetGenerator);
		}
		return source.Select(PlayerProfile.<>f__mg$cache0).ToList<VehicleGeneratorBase>();
	}

	// Token: 0x06002415 RID: 9237 RVA: 0x00107180 File Offset: 0x00105580
	public int GetMaxNumberOfVehclesCanHold()
	{
		return 3;
	}

	// Token: 0x06002416 RID: 9238 RVA: 0x00107183 File Offset: 0x00105583
	public int GetMaxNumberOfTripsPossible()
	{
		return 3;
	}

	// Token: 0x06002417 RID: 9239 RVA: 0x00107186 File Offset: 0x00105586
	public int NumberOfExtraTripsCanbeStarted()
	{
		return this.GetMaxNumberOfTripsPossible() - this.CurrentJourneys.Count((TripRecord t) => !t.Completed || !t.Claimed);
	}

	// Token: 0x06002418 RID: 9240 RVA: 0x001071B7 File Offset: 0x001055B7
	public void AddTrip(TripRecord trip)
	{
		this.CurrentJourneys.Add(trip);
		this.ReceiveEvent(GameWorldEvent.NewJourneyStarted, trip);
	}

	// Token: 0x06002419 RID: 9241 RVA: 0x001071D0 File Offset: 0x001055D0
	public List<ITraveller> GetCurrentTravellers()
	{
		List<ITraveller> travellers = new List<ITraveller>();
		this.CurrentJourneys.ForEach(delegate(TripRecord c)
		{
			travellers.AddRange(c.Travellers);
		});
		return travellers;
	}

	// Token: 0x0600241A RID: 9242 RVA: 0x0010720C File Offset: 0x0010560C
	public void RemoveFiredTraveller(ITraveller traveller)
	{
		foreach (Vehicle vehicle in this.CurrentVehicles)
		{
			vehicle.Travellers.Remove(traveller);
		}
	}

	// Token: 0x0600241B RID: 9243 RVA: 0x00107270 File Offset: 0x00105670
	public void StartTrip(Vehicle boat, DestinationType destination)
	{
		if (this.NumberOfExtraTripsCanbeStarted() > 0 && boat.IsAvaliable(new DestinationType?(destination)) && this.CurrentVehicles.Any((Vehicle v) => v == boat))
		{
			TripRecord trip = TripRecord.Initialize(boat, destination);
			this.AddTrip(trip);
		}
	}

	// Token: 0x0600241C RID: 9244 RVA: 0x001072DC File Offset: 0x001056DC
	public void RemoveVehcle(Vehicle toRemove)
	{
		if (this.CurrentVehicles.Any((Vehicle v) => v == toRemove))
		{
			this.CurrentVehicles.Remove(toRemove);
		}
	}

	// Token: 0x0600241D RID: 9245 RVA: 0x00107324 File Offset: 0x00105724
	public int NumberOfExtraVehclesCanHold()
	{
		return this.GetMaxNumberOfVehclesCanHold() - this.CurrentVehicles.Count;
	}

	// Token: 0x0600241E RID: 9246 RVA: 0x00107338 File Offset: 0x00105738
	public void AddVehicle(Vehicle toadd)
	{
		if (this.NumberOfExtraVehclesCanHold() > 0)
		{
			this.CurrentVehicles.Add(toadd);
			this.ReceiveEvent(GameWorldEvent.BoatAdded, toadd);
		}
	}

	// Token: 0x0600241F RID: 9247 RVA: 0x0010735C File Offset: 0x0010575C
	public bool CanCreateVehicle(VehicleType type)
	{
		return this.NumberOfExtraVehclesCanHold() > 0 && this.GetProduceableVehicles().Any((VehicleGeneratorBase v) => v.VehicleType == type) && type.GetGenerator().ProductionRequirements.MetRequirements();
	}

	// Token: 0x06002420 RID: 9248 RVA: 0x001073B8 File Offset: 0x001057B8
	public Vehicle CreateVehicle(VehicleType type)
	{
		if (this.CanCreateVehicle(type))
		{
			this.BatchResourceUpdate((from r in type.GetGenerator().ProductionRequirements
			select new ResourceUpdate
			{
				ResourceType = r.ResourceType,
				ChangeAmount = (double)(-(double)r.AmountRequired),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>());
			Vehicle vehicle = type.GetGenerator().Create();
			this.AddVehicle(vehicle);
			return vehicle;
		}
		return null;
	}

	// Token: 0x06002421 RID: 9249 RVA: 0x00107420 File Offset: 0x00105820
	public List<DestinationType> GetPossibleDestinations()
	{
		return new List<DestinationType>
		{
			DestinationType.NorthernSea,
			DestinationType.YellowSea,
			DestinationType.RedRiver
		};
	}

	// Token: 0x06002422 RID: 9250 RVA: 0x0010744C File Offset: 0x0010584C
	public List<ITraveller> GetAllAvaliableTravellers()
	{
		List<ITraveller> list = new List<ITraveller>();
		list.AddRange((from ad in this.AdventurerProfiles
		where !ad.IsInBattle() && !ad.IsInTravel()
		select ad).OfType<ITraveller>());
		list.AddRange((from r in this.Residents
		where !r.IsInTravel()
		select r).OfType<ITraveller>());
		return list;
	}

	// Token: 0x06002423 RID: 9251 RVA: 0x001074C6 File Offset: 0x001058C6
	public void SetDungeonRecordLevel(AdventureType type, int level)
	{
		this.GetDungeonRecord(type).CurrentSelectedLevel = level;
	}

	// Token: 0x06002424 RID: 9252 RVA: 0x001074D8 File Offset: 0x001058D8
	public DungeonRecord GetDungeonRecord(AdventureType type)
	{
		if (type >= AdventureType.Endless_N1)
		{
			return this.EndlessRecord;
		}
		return this.GetProgress(null).DungeonRecords.FirstOrDefault((DungeonRecord d) => d.AdventureType == type);
	}

	// Token: 0x06002425 RID: 9253 RVA: 0x0010752C File Offset: 0x0010592C
	public void EnableDungeonRecord(AdventureType type)
	{
		DungeonRecord dungeonRecord = this.GetDungeonRecord(type);
		if (dungeonRecord != null && !dungeonRecord.IsEnabledRecord())
		{
			dungeonRecord.IsEnabled = true;
			this.ReceiveEvent(GameWorldEvent.DungeonNewTypeUnlocked, dungeonRecord);
		}
	}

	// Token: 0x06002426 RID: 9254 RVA: 0x00107562 File Offset: 0x00105962
	public int GetMaxNumberOfSideQuests()
	{
		return this.MaxNumberOfSideQuests;
	}

	// Token: 0x06002427 RID: 9255 RVA: 0x0010756A File Offset: 0x0010596A
	public void StartGenerateSideQuests()
	{
		this.MaxNumberOfSideQuests = 3;
		this.ReceiveEvent(GameWorldEvent.InitialRandomSideQuestsPreIssue, this);
	}

	// Token: 0x06002428 RID: 9256 RVA: 0x0010757C File Offset: 0x0010597C
	public ProductionBuildingProfile GetWeaponShop()
	{
		return (from b in this.Buildings
		select b.Value).FirstOrDefault((IBuildingProfile b) => b is ProductionBuildingProfile && b.BuildingType == BuildingType.WeaponShop) as ProductionBuildingProfile;
	}

	// Token: 0x06002429 RID: 9257 RVA: 0x001075D8 File Offset: 0x001059D8
	public ProductionBuildingProfile GetArmorShop()
	{
		return (from b in this.Buildings
		select b.Value).FirstOrDefault((IBuildingProfile b) => b is ProductionBuildingProfile && b.BuildingType == BuildingType.ArmorShop) as ProductionBuildingProfile;
	}

	// Token: 0x0600242A RID: 9258 RVA: 0x00107634 File Offset: 0x00105A34
	public IEnumerable<T> GetResidentEffects<T>() where T : IResidentEffect
	{
		return this.Residents.SelectMany((Resident r) => r.Effects).OfType<T>();
	}

	// Token: 0x0600242B RID: 9259 RVA: 0x00107654 File Offset: 0x00105A54
	public void UpdateDungeonRecord(AdventureType adventureType, int completedLevelNumber, string identityCode, bool goForwardLevel)
	{
		QuestRequirementBase adventureCodedRequirement = this.GetAdventureCodedRequirement(identityCode);
		if (adventureCodedRequirement == null || (!(adventureCodedRequirement is HundredBattleRequirementLogic) && adventureCodedRequirement is CustomizedDungeonThroughRequirementLogic && !(adventureCodedRequirement as CustomizedDungeonThroughRequirementLogic).IsTwistedTimeDungeon))
		{
			DungeonRecord dungeonRecord = this.GetDungeonRecord(adventureType);
			if (dungeonRecord != null)
			{
				int num = completedLevelNumber + 1;
				int maxAchieveableLevel = dungeonRecord.AdventureType.GetMaxAchieveableLevel();
				int currentAchievedLevel = dungeonRecord.GetCurrentAchievedLevel();
				bool flag = false;
				if (completedLevelNumber > currentAchievedLevel)
				{
					this.ReceiveEvent(GameWorldEvent.DungeonNewLevelUnlocked, dungeonRecord);
					flag = true;
				}
				if (num > currentAchievedLevel && num <= maxAchieveableLevel)
				{
					dungeonRecord.SetCurrentAchievedLevel(completedLevelNumber);
					this.ReceiveEvent(GameWorldEvent.DungeonNewLevelUnlocked, dungeonRecord);
				}
				if (num > dungeonRecord.GetCurrentAchievedLevel() && flag && num <= maxAchieveableLevel && goForwardLevel)
				{
					dungeonRecord.CurrentSelectedLevel = num;
				}
			}
		}
	}

	// Token: 0x0600242C RID: 9260 RVA: 0x0010771C File Offset: 0x00105B1C
	public QuestRequirementBase GetAdventureCodedRequirement(string identityCode)
	{
		QuestRequirementBase questRequirementBase = this.GetQuestRequirements<HundredBattleRequirementLogic>(false).FirstOrDefault((HundredBattleRequirementLogic c) => c.IdentityCode == identityCode);
		CustomizedDungeonThroughRequirementLogic customizedDungeonThroughRequirementLogic = this.GetQuestRequirements<CustomizedDungeonThroughRequirementLogic>(false).FirstOrDefault((CustomizedDungeonThroughRequirementLogic c) => c.Configuration.CustomizedIdentityCode == identityCode);
		return questRequirementBase ?? customizedDungeonThroughRequirementLogic;
	}

	// Token: 0x0600242D RID: 9261 RVA: 0x00107774 File Offset: 0x00105B74
	public bool QuestChainCompleted(QuestChainIdentifier chain, int starrating)
	{
		if (this.GetProgress(new int?(starrating)).QuestChainCompletionRecords == null)
		{
			this.GetProgress(new int?(starrating)).QuestChainCompletionRecords = new Dictionary<QuestChainIdentifier, bool>();
		}
		return this.GetProgress(new int?(starrating)).QuestChainCompletionRecords.ContainsKey(chain) && this.GetProgress(new int?(starrating)).QuestChainCompletionRecords[chain];
	}

	// Token: 0x0600242E RID: 9262 RVA: 0x001077E4 File Offset: 0x00105BE4
	public void SetChainCompletionStatus(QuestChainIdentifier chain, bool completionStatus)
	{
		if (this.GetProgress(null).QuestChainCompletionRecords == null)
		{
			this.GetProgress(null).QuestChainCompletionRecords = new Dictionary<QuestChainIdentifier, bool>();
		}
		if (this.GetProgress(null).QuestChainCompletionRecords.ContainsKey(chain))
		{
			this.GetProgress(null).QuestChainCompletionRecords[chain] = completionStatus;
		}
		else
		{
			this.GetProgress(null).QuestChainCompletionRecords.Add(chain, completionStatus);
		}
	}

	// Token: 0x0600242F RID: 9263 RVA: 0x00107880 File Offset: 0x00105C80
	public void SelectDungeonLevel(int nLevel, AdventureType type)
	{
		DungeonRecord dungeonRecord = this.GetDungeonRecord(type);
		if (nLevel <= dungeonRecord.GetCurrentAchievedLevel())
		{
			dungeonRecord.CurrentSelectedLevel = nLevel;
		}
	}

	// Token: 0x06002430 RID: 9264 RVA: 0x001078A8 File Offset: 0x00105CA8
	public bool CanAfford(double amount)
	{
		return this.GetMoney() - amount >= 0.0;
	}

	// Token: 0x06002431 RID: 9265 RVA: 0x001078C0 File Offset: 0x00105CC0
	public int GetMaxNumberOfResidents()
	{
		if (this.NumberOfResidentSlots <= PlayerProfile.MaxResidentSlot)
		{
			return this.NumberOfResidentSlots;
		}
		return PlayerProfile.MaxResidentSlot;
	}

	// Token: 0x06002432 RID: 9266 RVA: 0x001078DE File Offset: 0x00105CDE
	public int GetMaxNumberOfAdventurers()
	{
		if (TestingProcessor.InTesting)
		{
			return 10000;
		}
		return 200;
	}

	// Token: 0x06002433 RID: 9267 RVA: 0x001078F8 File Offset: 0x00105CF8
	public List<T> GetQuestRequirements<T>(bool activeOnly) where T : QuestRequirementBase
	{
		return (from q in this.GetProgress(null).Quests
		where !activeOnly || (!q.Completed && !q.Cancelled)
		select q).SelectMany((Quest q) => q.QuestRequirements).OfType<T>().ToList<T>();
	}

	// Token: 0x06002434 RID: 9268 RVA: 0x00107954 File Offset: 0x00105D54
	public bool QuestIsActive(QuestIdentifier questIdentifier)
	{
		return this.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == questIdentifier && !q.Cancelled && !q.Completed && !q.HasExpired());
	}

	// Token: 0x06002435 RID: 9269 RVA: 0x00107993 File Offset: 0x00105D93
	public double GetResourceQuantity(ResourceType type)
	{
		if (this.ResourcesAt.ContainsKey(type))
		{
			return this.ResourcesAt[type].GetValue();
		}
		return 0.0;
	}

	// Token: 0x06002436 RID: 9270 RVA: 0x001079C8 File Offset: 0x00105DC8
	public void SpendMoney(double amount)
	{
		if (amount != 0.0)
		{
			double money = this.GetMoney();
			this.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.Money,
					ChangeAmount = -amount,
					RelatedItems = new List<Item>()
				}
			});
			double money2 = this.GetMoney();
			this.ReceiveEvent(GameWorldEvent.MoneySpent, new MoneySpentEvent
			{
				OriginalAmount = money,
				ResultedAmount = money2,
				SpentAmount = amount
			});
		}
	}

	// Token: 0x06002437 RID: 9271 RVA: 0x00107A54 File Offset: 0x00105E54
	public void ChangeWeather(Weather nWeather)
	{
		Weather currentWeather = this.CurrentWeather;
		this.CurrentWeather = nWeather;
		WeatherUpdateEvent data = new WeatherUpdateEvent
		{
			PreviousWeather = currentWeather,
			NewWeather = nWeather
		};
		this.ReceiveEvent(GameWorldEvent.WeatherChanged, data);
	}

	// Token: 0x06002438 RID: 9272 RVA: 0x00107A90 File Offset: 0x00105E90
	public void ChangeSeason(Season nSeason)
	{
		Season currentSeason = this.CurrentSeason;
		this.CurrentSeason = nSeason;
		SeasonUpdateEvent data = new SeasonUpdateEvent
		{
			CurrentSeason = nSeason,
			PreviouSeason = currentSeason
		};
		this.ReceiveEvent(GameWorldEvent.SeasonChanged, data);
	}

	// Token: 0x06002439 RID: 9273 RVA: 0x00107ACA File Offset: 0x00105ECA
	public void ChangeItemOrderType(ItemOrderType type)
	{
		this.ItemOrderType = type;
	}

	// Token: 0x0600243A RID: 9274 RVA: 0x00107AD3 File Offset: 0x00105ED3
	public void ChangeAdventurerOrderType(AdventurerOrderType type)
	{
		this.AdventurerOrderType = type;
	}

	// Token: 0x0600243B RID: 9275 RVA: 0x00107ADC File Offset: 0x00105EDC
	public void AddAdventurer(AdventurerProfile newAdventurer)
	{
		this.AdventurerProfiles.Add(newAdventurer);
		this.ReceiveEvent(GameWorldEvent.AdventurerListUpdated, new AdventurerListUpdatedEvent
		{
			AdventurerListUpdateType = AdventurerListUpdateType.Addition,
			ChangedProfiles = new List<AdventurerProfile>
			{
				newAdventurer
			},
			RelatedResourceUpdates = new List<ResourceUpdate>()
		});
	}

	// Token: 0x0600243C RID: 9276 RVA: 0x00107B2C File Offset: 0x00105F2C
	public bool RecipeHasAccaquired(ResourceType type)
	{
		Recipe recipe = BuildingExtensions.Recipes.FirstOrDefault((Recipe r) => r.ProductType == type);
		return recipe != null && this.HasResource(recipe.RecipeName);
	}

	// Token: 0x0600243D RID: 9277 RVA: 0x00107B74 File Offset: 0x00105F74
	public void Build(BuildingType type, TownSlot slot)
	{
		if (this.Buildings[slot] != null)
		{
			throw new Exception("Existing building at slot!");
		}
		IBuildingProfile buildingProfile = type.Create();
		this.Buildings[slot] = buildingProfile;
		this.ReceiveEvent(GameWorldEvent.BuildingConstructed, new BuildingBuiltEvent
		{
			TownSlot = slot,
			Building = buildingProfile
		});
	}

	// Token: 0x0600243E RID: 9278 RVA: 0x00107BD0 File Offset: 0x00105FD0
	public void Demolish(TownSlot slot)
	{
		if (this.Buildings[slot] == null || (this.Buildings[slot].BuildingType != BuildingType.WeaponShop && this.Buildings[slot].BuildingType != BuildingType.ArmorShop && this.Buildings[slot].BuildingType != BuildingType.CityTown && this.Buildings[slot].BuildingType != BuildingType.RecruitmentFacility))
		{
			this.Buildings[slot] = null;
			this.ReceiveEvent(GameWorldEvent.BuildingDemolished, slot);
		}
	}

	// Token: 0x0600243F RID: 9279 RVA: 0x00107C6A File Offset: 0x0010606A
	public double GetMoney()
	{
		return this.GetResourceQuantity(ResourceType.Money);
	}

	// Token: 0x06002440 RID: 9280 RVA: 0x00107C78 File Offset: 0x00106078
	public TownBoostValue GetPracticePointsGainRatio()
	{
		double num = 1.0 + this.GetResidentEffects<PracticeResidentEffect>().Sum((PracticeResidentEffect r) => r.CurrentRate);
		double num2 = PlayerProfile.MaxPracticePointsBoost + 1.0;
		double exceededValue = 0.0;
		if (num > num2)
		{
			exceededValue = num - num2;
			num = num2;
		}
		return new TownBoostValue
		{
			FinalValue = num,
			ExceededValue = exceededValue
		};
	}

	// Token: 0x06002441 RID: 9281 RVA: 0x00107CF4 File Offset: 0x001060F4
	public double GetAdventurerSpawnBoost()
	{
		return this.GetTownEffects().OfType<RecruitmentQualityBoostEffect>().Sum((RecruitmentQualityBoostEffect b) => b.BoostRate);
	}

	// Token: 0x06002442 RID: 9282 RVA: 0x00107D24 File Offset: 0x00106124
	public TownBoostValue GetWeaponPriceRatio()
	{
		double num = GameWorld.instance.PlayerProfile.Residents.SelectMany((Resident r) => r.Effects).OfType<WeaponSaleResidentEffect>().Sum((WeaponSaleResidentEffect w) => w.CurrentRate);
		double exceededValue = 0.0;
		if (num >= PlayerProfile.MaxReisdentPriceBoost)
		{
			exceededValue = num - PlayerProfile.MaxReisdentPriceBoost;
			num = PlayerProfile.MaxReisdentPriceBoost;
		}
		num += this.GetTownEffects().OfType<GearPriceBoostEffect>().Sum((GearPriceBoostEffect g) => g.Rate);
		return new TownBoostValue
		{
			FinalValue = num,
			ExceededValue = exceededValue
		};
	}

	// Token: 0x06002443 RID: 9283 RVA: 0x00107DF4 File Offset: 0x001061F4
	public TownBoostValue GetArmorPriceRatio()
	{
		double num = GameWorld.instance.PlayerProfile.Residents.SelectMany((Resident r) => r.Effects).OfType<ArmorSaleResidentEffect>().Sum((ArmorSaleResidentEffect w) => w.CurrentRate);
		double exceededValue = 0.0;
		if (num > PlayerProfile.MaxReisdentPriceBoost)
		{
			exceededValue = num - PlayerProfile.MaxReisdentPriceBoost;
			num = PlayerProfile.MaxReisdentPriceBoost;
		}
		num += this.GetTownEffects().OfType<GearPriceBoostEffect>().Sum((GearPriceBoostEffect g) => g.Rate);
		return new TownBoostValue
		{
			FinalValue = num,
			ExceededValue = exceededValue
		};
	}

	// Token: 0x06002444 RID: 9284 RVA: 0x00107EC4 File Offset: 0x001062C4
	public PlayerTownStatsSummary CalculateTownStats()
	{
		TownBoostValue additionalProductionRate = BuildingExtensions.GetAdditionalProductionRate();
		TownBoostValue itemQualityBoostRate = this.GetItemQualityBoostRate();
		TownBoostValue totalChestBoost = this.GetTotalChestBoost();
		TownBoostValue practicePointsGainRatio = this.GetPracticePointsGainRatio();
		TownBoostValue armorPriceRatio = this.GetArmorPriceRatio();
		TownBoostValue weaponPriceRatio = this.GetWeaponPriceRatio();
		return new PlayerTownStatsSummary
		{
			TotalProductionIncreaseRate = additionalProductionRate.FinalValue - 1.0,
			TotalProductionIncreaseRateExceeded = additionalProductionRate.ExceededValue,
			TotalItemDropBoostRate = itemQualityBoostRate.FinalValue,
			TotalItemDropBoostRateExceeded = itemQualityBoostRate.ExceededValue,
			TotalChestBoostRate = totalChestBoost.FinalValue - 1.0,
			TotalChestBoostRateExceeded = totalChestBoost.ExceededValue,
			TotalPracticePointsBoost = practicePointsGainRatio.FinalValue - 1.0,
			TotalPracticePointsBoostExceeded = practicePointsGainRatio.ExceededValue,
			ArmorPriceBoost = armorPriceRatio.FinalValue,
			ArmorPriceBoostExceeded = armorPriceRatio.ExceededValue,
			WeaponPriceBoost = weaponPriceRatio.FinalValue,
			WeaponPriceBoostExceeded = weaponPriceRatio.ExceededValue
		};
	}

	// Token: 0x06002445 RID: 9285 RVA: 0x00107FC3 File Offset: 0x001063C3
	public PlayerTownStatsSummary GetTownStats()
	{
		if (this.TownStatsSummary == null)
		{
			this.TownStatsSummary = this.CalculateTownStats();
		}
		return this.TownStatsSummary;
	}

	// Token: 0x06002446 RID: 9286 RVA: 0x00107FE4 File Offset: 0x001063E4
	private TownBoostValue GetTotalChestBoost()
	{
		double num = 1.0 + Chest.GetChestLuckBooster();
		double num2 = 1.0 + GameWorld.instance.PlayerProfile.GetResidentEffects<DivineHeartResidentEffect>().Sum((DivineHeartResidentEffect d) => d.CurrentRate);
		double num3 = PlayerProfile.MaxDivineHeartBoost + 1.0;
		double exceededValue = 0.0;
		if (num2 >= num3)
		{
			exceededValue = num2 - num3;
			num2 = num3;
		}
		return new TownBoostValue
		{
			FinalValue = num * num2,
			ExceededValue = exceededValue
		};
	}

	// Token: 0x06002447 RID: 9287 RVA: 0x00108080 File Offset: 0x00106480
	private void ChangeResource(ResourceType type, double change, List<Item> relatedItems)
	{
		if (relatedItems.Any((Item i) => i == null))
		{
			SteamExceptionHandle.Handle(new Exception("Null item!! " + type.ToString()), 0u);
		}
		else
		{
			ResourceCategory resourceCategory = type.GetResourceCategory();
			bool flag = resourceCategory == ResourceCategory.ProductionRecipe && !this.HasResource(type);
			bool flag2 = resourceCategory == ResourceCategory.AdventurerInvitation && !this.HasResource(type);
			bool flag3 = resourceCategory == ResourceCategory.BuildingPermit && !this.HasResource(type);
			bool flag4 = resourceCategory == ResourceCategory.SkillBooks && !this.HasResource(type);
			if (resourceCategory.IsUniqueResource() && change > 0.0)
			{
				if (this.ResourcesAt.ContainsKey(type))
				{
					this.ResourcesAt[type].Amount = 1.0 * PlayerProfile.CurrentKey;
				}
				else
				{
					this.ResourcesAt.Add(type, new ResourceProfileAntiCheat
					{
						ResourceType = type,
						Amount = 1.0 * PlayerProfile.CurrentKey
					});
				}
			}
			else if ((type.IsItem() && this.GetResourceQuantity(type) < PlayerProfile.MaxPossibleResources_Item) || (!type.IsItem() && this.GetResourceQuantity(type) < PlayerProfile.MaxPossibleResources_NonItem) || change < 0.0)
			{
				if (this.ResourcesAt.ContainsKey(type))
				{
					this.ResourcesAt[type].ChangeValue(change);
					if (this.ResourcesAt[type].GetValue() < 0.0)
					{
						this.ResourcesAt[type].SetValue(0.0);
					}
				}
				else
				{
					this.ResourcesAt.Add(type, new ResourceProfileAntiCheat
					{
						ResourceType = type,
						Amount = change * PlayerProfile.CurrentKey
					});
				}
				if (relatedItems.Count > 0)
				{
					if (change >= 0.0)
					{
						relatedItems.ForEach(delegate(Item i)
						{
							i.ItemStatus = ItemStatus.Reserved;
						});
						this.Items.AddRange(relatedItems);
					}
					else
					{
						relatedItems.ForEach(delegate(Item i)
						{
							i.ItemStatus = ItemStatus.Removed;
						});
						this.Items.RemoveAll((Item i) => i.ItemStatus == ItemStatus.Removed);
					}
				}
			}
			this.ReceiveEvent(GameWorldEvent.ResourceUpdated, new ResourceUpdateEvent
			{
				ResourceType = type,
				RelatedItems = relatedItems,
				Change = change,
				ResultedAmount = this.ResourcesAt[type].GetValue(),
				OriginalAmount = this.ResourcesAt[type].GetValue() - change
			});
			if (flag4)
			{
				SkillType skill = SkillExtensions.SkillBookDictionary[type];
				if (this.AcquiredPassives.All((SkillType s) => s != skill))
				{
					this.AcquiredPassives.Add(skill);
				}
				this.ReceiveEvent(GameWorldEvent.NewSkillUnlocked, skill);
			}
			if (flag)
			{
				ResourceType productType = BuildingExtensions.Recipes.First((Recipe r) => r.RecipeName == type).ProductType;
				this.ReceiveEvent(GameWorldEvent.NewReceipeLearned, productType);
			}
			if (flag2)
			{
				UnitClass invitationRelatedUnitClass = type.GetInvitationRelatedUnitClass();
				this.ReceiveEvent(GameWorldEvent.AdventurerTypeUnloced, invitationRelatedUnitClass);
			}
			if (flag3)
			{
				BuildingType permittedBuildingType = BuildingExtensions.GetPermittedBuildingType(type);
				this.ReceiveEvent(GameWorldEvent.BuildingTypeUnlocked, permittedBuildingType);
			}
		}
	}

	// Token: 0x06002448 RID: 9288 RVA: 0x0010850A File Offset: 0x0010690A
	public bool HasResource(ResourceType type)
	{
		return this.ResourcesAt.ContainsKey(type) && this.ResourcesAt[type].GetValue() > 0.0;
	}

	// Token: 0x06002449 RID: 9289 RVA: 0x00108544 File Offset: 0x00106944
	public int GetAdventureSelectedLevel(AdventureType type)
	{
		if (type == AdventureType.Endless_Entry)
		{
			return this.EndlessRecord.CurrentSelectedLevel;
		}
		if (this.GetProgress(null).DungeonRecords.Any((DungeonRecord a) => a.AdventureType == type))
		{
			return this.GetProgress(null).DungeonRecords.First((DungeonRecord a) => a.AdventureType == type).CurrentSelectedLevel;
		}
		throw new NotSupportedException();
	}

	// Token: 0x0600244A RID: 9290 RVA: 0x001085D4 File Offset: 0x001069D4
	public double GetResourceAmount_AvaliableForProduction(ResourceType type)
	{
		if (!this.ResourcesAt.ContainsKey(type))
		{
			return 0.0;
		}
		if (type.IsItem())
		{
			return (double)this.Items.Count((Item i) => i.Type == type && i.ItemStatus == ItemStatus.StockForProduction);
		}
		return this.ResourcesAt[type].GetValue();
	}

	// Token: 0x0600244B RID: 9291 RVA: 0x00108654 File Offset: 0x00106A54
	public List<Item> GetProductionResourceItems(int amount, ResourceType type)
	{
		if (!type.IsItem())
		{
			throw new Exception("Invalid resource");
		}
		if (this.Items.Count((Item i) => i.Type == type && i.ItemStatus == ItemStatus.StockForProduction) < amount)
		{
			throw new Exception("Insufficient amount of items.");
		}
		return (from i in this.Items
		where i.Type == type && i.ItemStatus == ItemStatus.StockForProduction
		select i).Take(amount).ToList<Item>();
	}

	// Token: 0x0600244C RID: 9292 RVA: 0x001086D4 File Offset: 0x00106AD4
	public void BatchResourceUpdate(List<ResourceUpdate> changes)
	{
		List<ResourceUpdate> list = (from c in changes
		group c by c.ResourceType).Select(delegate(IGrouping<ResourceType, ResourceUpdate> g)
		{
			ResourceUpdate resourceUpdate2 = new ResourceUpdate();
			resourceUpdate2.ResourceType = g.Key;
			resourceUpdate2.ChangeAmount = g.Sum((ResourceUpdate r) => r.ChangeAmount);
			resourceUpdate2.RelatedItems = g.SelectMany((ResourceUpdate r) => r.RelatedItems).ToList<Item>();
			return resourceUpdate2;
		}).ToList<ResourceUpdate>();
		foreach (ResourceUpdate resourceUpdate in list)
		{
			this.ChangeResource(resourceUpdate.ResourceType, resourceUpdate.ChangeAmount, resourceUpdate.RelatedItems);
		}
		if (this.IsInventoryFull())
		{
			this.ReceiveEvent(GameWorldEvent.InventoryIsFull, null);
		}
	}

	// Token: 0x0600244D RID: 9293 RVA: 0x0010879C File Offset: 0x00106B9C
	public void AddQuest(Quest quest)
	{
		this.GetProgress(null).Quests.Add(quest);
		if (this.GetProgress(null).QuestIssuedRecords.ContainsKey(quest.QuestIdentifier))
		{
			Dictionary<QuestIdentifier, int> questIssuedRecords;
			QuestIdentifier questIdentifier;
			(questIssuedRecords = this.GetProgress(null).QuestIssuedRecords)[questIdentifier = quest.QuestIdentifier] = questIssuedRecords[questIdentifier] + 1;
		}
		else
		{
			this.GetProgress(null).QuestIssuedRecords.Add(quest.QuestIdentifier, 1);
		}
		this.ReceiveEvent(GameWorldEvent.NewQuestReceived, quest);
		this.ReceiveEvent(GameWorldEvent.TownAutoDialogTriggers, null);
	}

	// Token: 0x0600244E RID: 9294 RVA: 0x0010884A File Offset: 0x00106C4A
	public void UpdateStarItemUnlocked()
	{
		this.AdditionalData.AddOrUpdateData("StarItemGenerated", true);
	}

	// Token: 0x0600244F RID: 9295 RVA: 0x00108860 File Offset: 0x00106C60
	public void CompleteQuest(Quest quest)
	{
		if (!quest.Rewarded)
		{
			quest.Rewarded = true;
			this.GetProgress(null).Quests.Remove(quest);
			foreach (QuestRewardBase questRewardBase in quest.Rewards)
			{
				questRewardBase.Reward(quest);
			}
			QuestCompletedEvent questCompletedEvent = new QuestCompletedEvent
			{
				Quest = quest,
				AdditionalContribution = new List<ResourceUpdate>()
			};
			if (this.GetProgress(null).QuestCompletionRecords == null)
			{
				this.GetProgress(null).QuestCompletionRecords = new Dictionary<QuestIdentifier, int>();
			}
			if (this.GetProgress(null).QuestCompletionRecords.ContainsKey(quest.QuestIdentifier))
			{
				Dictionary<QuestIdentifier, int> questCompletionRecords;
				QuestIdentifier questIdentifier;
				(questCompletionRecords = this.GetProgress(null).QuestCompletionRecords)[questIdentifier = quest.QuestIdentifier] = questCompletionRecords[questIdentifier] + 1;
			}
			else
			{
				this.GetProgress(null).QuestCompletionRecords.Add(quest.QuestIdentifier, 1);
			}
			string key = string.Concat(new object[]
			{
				quest.QuestIdentifier.ToString(),
				"-",
				this.GetStarRating(),
				"-CompletionDate"
			});
			if (!this.AdditionalData.ContainsInt(key))
			{
				this.AdditionalData.AddOrUpdateData(string.Concat(new object[]
				{
					quest.QuestIdentifier.ToString(),
					"-",
					this.GetStarRating(),
					"-FirstCompletionDate"
				}), this.GameDays);
			}
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.QuestCompleted, questCompletedEvent);
			if (questCompletedEvent.AdditionalContribution.Any<ResourceUpdate>())
			{
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentContributed, new ResidentResourceContributeEvent
				{
					Contributor = null,
					ResourceUpdates = questCompletedEvent.AdditionalContribution
				});
			}
			this.BatchResourceUpdate(questCompletedEvent.AdditionalContribution);
		}
	}

	// Token: 0x06002450 RID: 9296 RVA: 0x00108AB0 File Offset: 0x00106EB0
	public bool QuestIsCompleted(QuestIdentifier quest, int starrating)
	{
		if (this.GetProgress(new int?(starrating)).QuestCompletionRecords == null)
		{
			this.GetProgress(new int?(starrating)).QuestCompletionRecords = new Dictionary<QuestIdentifier, int>();
		}
		return this.GetProgress(new int?(starrating)).QuestCompletionRecords.ContainsKey(quest) && this.GetProgress(new int?(starrating)).QuestCompletionRecords[quest] > 0;
	}

	// Token: 0x06002451 RID: 9297 RVA: 0x00108B24 File Offset: 0x00106F24
	public bool BuildingHasBeenBuilt(BuildingType type)
	{
		return this.Buildings.Any((KeyValuePair<TownSlot, IBuildingProfile> b) => b.Value != null && b.Value.BuildingType == type);
	}

	// Token: 0x06002452 RID: 9298 RVA: 0x00108B58 File Offset: 0x00106F58
	public List<BuildingType> GetAvaliableBuildingTypes()
	{
		List<BuildingType> list = new List<BuildingType>();
		if (this.HasResource(ResourceType.WeaponShopPermit) && !this.BuildingHasBeenBuilt(BuildingType.WeaponShop))
		{
			list.Add(BuildingType.WeaponShop);
		}
		if (this.HasResource(ResourceType.ArmorShopPermit) && !this.BuildingHasBeenBuilt(BuildingType.ArmorShop))
		{
			list.Add(BuildingType.ArmorShop);
		}
		if (this.HasResource(ResourceType.ShopPermit) && !this.BuildingHasBeenBuilt(BuildingType.Shop))
		{
			list.Add(BuildingType.Shop);
		}
		if (this.HasResource(ResourceType.RecruitmentFacilityPermit) && !this.BuildingHasBeenBuilt(BuildingType.RecruitmentFacility))
		{
			list.Add(BuildingType.RecruitmentFacility);
		}
		if (this.HasResource(ResourceType.ShrinePermit) && !this.BuildingHasBeenBuilt(BuildingType.Shrine))
		{
			list.Add(BuildingType.Shrine);
		}
		if (this.HasResource(ResourceType.SchoolPermit) && !this.BuildingHasBeenBuilt(BuildingType.School))
		{
			list.Add(BuildingType.School);
		}
		if (this.HasResource(ResourceType.CasinoPermit) && !this.BuildingHasBeenBuilt(BuildingType.Casino))
		{
			list.Add(BuildingType.Casino);
		}
		if (this.HasResource(ResourceType.PracticePermit) && !this.BuildingHasBeenBuilt(BuildingType.BarrackYard))
		{
			list.Add(BuildingType.BarrackYard);
		}
		if (this.HasResource(ResourceType.ForgingFacilityPermit) && !this.BuildingHasBeenBuilt(BuildingType.ForgingFacility))
		{
			list.Add(BuildingType.ForgingFacility);
		}
		return list;
	}

	// Token: 0x06002453 RID: 9299 RVA: 0x00108CAB File Offset: 0x001070AB
	public int GetBuildingPrice(BuildingType type)
	{
		return 0;
	}

	// Token: 0x06002454 RID: 9300 RVA: 0x00108CB0 File Offset: 0x001070B0
	public void Process()
	{
		foreach (CoreProcessorBase coreProcessorBase in PlayerProfile.CoreProcessors)
		{
			coreProcessorBase.Process();
		}
		foreach (TripRecord tripRecord in (from j in this.CurrentJourneys
		select j).ToList<TripRecord>())
		{
			tripRecord.ProcessRecord();
		}
	}

	// Token: 0x06002455 RID: 9301 RVA: 0x00108D7C File Offset: 0x0010717C
	public void AddNewResidentFromStoredCandidate(ResidentCandidate candidate)
	{
		if (this.Residents.Count + 1 <= this.GetMaxNumberOfResidents() && this.StoredCandidates.Any((ResidentCandidate cd) => cd == candidate))
		{
			this.Residents.Add(candidate.Candidate);
			this.TownStatsSummary = this.CalculateTownStats();
			this.ReceiveEvent(GameWorldEvent.ResidentAdded, new List<ResidentCandidate>
			{
				candidate
			});
			this.RemoveStoredCandidate(candidate.Candidate.Id);
		}
	}

	// Token: 0x06002456 RID: 9302 RVA: 0x00108E20 File Offset: 0x00107220
	public void AddNewResidents(ResidentCandidate candidate)
	{
		if (this.Residents.Count + 1 <= this.GetMaxNumberOfResidents() && this.Candidates.Any((ResidentCandidate cd) => cd == candidate))
		{
			this.Residents.Add(candidate.Candidate);
			this.TownStatsSummary = this.CalculateTownStats();
			this.ReceiveEvent(GameWorldEvent.ResidentAdded, new List<ResidentCandidate>
			{
				candidate
			});
			this.ResetCandidates();
		}
	}

	// Token: 0x06002457 RID: 9303 RVA: 0x00108EB4 File Offset: 0x001072B4
	public void ResetCandidates()
	{
		List<ResidentCandidate> data = (from c in this.Candidates
		select c).ToList<ResidentCandidate>();
		this.Candidates = new List<ResidentCandidate>();
		this.ReceiveEvent(GameWorldEvent.ResidentCandidateRemoved, data);
	}

	// Token: 0x06002458 RID: 9304 RVA: 0x00108F03 File Offset: 0x00107303
	public void AddNewResidentCandidates(List<ResidentCandidate> candidates)
	{
		this.Candidates = new List<ResidentCandidate>();
		this.Candidates.AddRange(candidates);
		this.ReceiveEvent(GameWorldEvent.ResidentCandidateAdded, candidates);
	}

	// Token: 0x06002459 RID: 9305 RVA: 0x00108F28 File Offset: 0x00107328
	public void RemoveResident(string residentId)
	{
		if (this.Residents.Any((Resident v) => v.Id == residentId))
		{
			Resident resident = this.Residents.FirstOrDefault((Resident v) => v.Id == residentId);
			this.Residents.Remove(resident);
			this.TownStatsSummary = this.CalculateTownStats();
			this.ReceiveEvent(GameWorldEvent.ResidentExpelled, resident);
		}
	}

	// Token: 0x0600245A RID: 9306 RVA: 0x00108F98 File Offset: 0x00107398
	public void ChangeReputation(double amount)
	{
		if (amount != 0.0)
		{
			TownTitleType title = this.GetTitle();
			if (amount > 0.0)
			{
				double reputation = this.GetProgress(null).Reputation;
				this.GetProgress(null).Reputation += amount;
				this.ReceiveEvent(GameWorldEvent.ReputationIncreased, new ReputationChangedEvent
				{
					Original = reputation,
					Resulted = this.GetProgress(null).Reputation,
					Amount = amount
				});
			}
			else
			{
				double reputation2 = this.GetProgress(null).Reputation;
				this.GetProgress(null).Reputation += amount;
				this.ReceiveEvent(GameWorldEvent.ReputationDecreased, new ReputationChangedEvent
				{
					Original = reputation2,
					Resulted = this.GetProgress(null).Reputation,
					Amount = amount
				});
			}
			TownTitleType title2 = this.GetTitle();
			if (title != title2)
			{
				this.ReceiveEvent(GameWorldEvent.TownTitleUpdated, new TownTitleChangedEvent
				{
					OriginalTitle = title,
					UpdatedTitle = title2
				});
			}
		}
	}

	// Token: 0x0600245B RID: 9307 RVA: 0x001090D4 File Offset: 0x001074D4
	public DifficultyLevelMeasurement GetDifficultyLevelMeasurement_CurrentRating()
	{
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(this.GetProgress(null).MaxAchievedDifficultyValue, this.GetStarRating());
	}

	// Token: 0x0600245C RID: 9308 RVA: 0x00109100 File Offset: 0x00107500
	public DifficultyLevelMeasurement GetDifficultyLevelMeasurement_OneStar()
	{
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(this.GetDifficultyValue(), 1);
	}

	// Token: 0x0600245D RID: 9309 RVA: 0x0010910E File Offset: 0x0010750E
	public double GetDifficultyValue()
	{
		return this.AchievedDifficultyValue.GetValueOrDefault();
	}

	// Token: 0x0600245E RID: 9310 RVA: 0x0010911C File Offset: 0x0010751C
	public DifficultyLevelMeasurement GetProductionDifficultyLevelMeasurement()
	{
		if (this.EndlessDungeonIsEnabled() && this.GetEndlessDungeonValue() > 0.0)
		{
			return this.GetEndlessDungeonDf();
		}
		IOrderedEnumerable<DifficultyLevelMeasurement> source = from p in this.Progresses
		select DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(p.Value.MaxAchievedDifficultyValue, p.Key) into m
		where m.DifficultyValue > 0.0
		orderby m.StarRating descending
		select m;
		DifficultyLevelMeasurement difficultyLevelMeasurement = source.FirstOrDefault<DifficultyLevelMeasurement>();
		if (difficultyLevelMeasurement == null)
		{
			return this.GetDifficultyLevelMeasurement_OneStar();
		}
		return difficultyLevelMeasurement;
	}

	// Token: 0x0600245F RID: 9311 RVA: 0x001091D1 File Offset: 0x001075D1
	public bool IsInventoryFull()
	{
		return this.Items.Count > PlayerProfile.InventoryCapacity;
	}

	// Token: 0x06002460 RID: 9312 RVA: 0x001091E8 File Offset: 0x001075E8
	public void ReceiveEvent(GameWorldEvent evt, object data)
	{
		try
		{
			this.OnGameWorldEventTriggered(evt, data);
			foreach (IBuildingProfile buildingProfile in this.Buildings.Values)
			{
				if (buildingProfile != null)
				{
					buildingProfile.ProcessEvent(evt, data);
				}
			}
			foreach (Quest quest in (from q in this.GetProgress(null).Quests
			where !q.Completed
			select q).ToList<Quest>())
			{
				quest.ProcessEvent(evt, data);
			}
			foreach (IFactionProcessor factionProcessor in FactionExtensions.FactionProcessors.Values)
			{
				factionProcessor.ProcessGameEvent(evt, data);
			}
			foreach (Resident resident in this.Residents)
			{
				foreach (IResidentEffect residentEffect in resident.Effects)
				{
					residentEffect.ProcessEvent(residentEffect, resident, evt, data);
				}
			}
		}
		catch (Exception exception)
		{
			SteamExceptionHandle.Handle(exception, 0u);
		}
	}

	// Token: 0x06002461 RID: 9313 RVA: 0x00109430 File Offset: 0x00107830
	public static PlayerProfile InitPlayer(string fileName)
	{
		PlayerProfile playerProfile = new PlayerProfile
		{
			ResourcesAt = new Dictionary<ResourceType, ResourceProfileAntiCheat>
			{
				{
					ResourceType.DrunkReaderInvitation,
					new ResourceProfileAntiCheat
					{
						ResourceType = ResourceType.DrunkReaderInvitation,
						Amount = 1.0 * PlayerProfile.CurrentKey
					}
				},
				{
					ResourceType.StreetManInvitation,
					new ResourceProfileAntiCheat
					{
						ResourceType = ResourceType.StreetManInvitation,
						Amount = 1.0 * PlayerProfile.CurrentKey
					}
				},
				{
					ResourceType.KillerInvitation,
					new ResourceProfileAntiCheat
					{
						ResourceType = ResourceType.KillerInvitation,
						Amount = 1.0 * PlayerProfile.CurrentKey
					}
				},
				{
					ResourceType.MissionaryInvitation,
					new ResourceProfileAntiCheat
					{
						ResourceType = ResourceType.MissionaryInvitation,
						Amount = 1.0 * PlayerProfile.CurrentKey
					}
				}
			},
			Items = new List<Item>(),
			UnlockedResourceRecipes = new List<ResourceType>(),
			Buildings = new Dictionary<TownSlot, IBuildingProfile>
			{
				{
					TownSlot.One,
					BuildingExtensions.CreateCityTown()
				},
				{
					TownSlot.Two,
					BuildingExtensions.CreateArmoryBuilding()
				},
				{
					TownSlot.Three,
					BuildingExtensions.CreateWeaponBuilding()
				},
				{
					TownSlot.Four,
					null
				},
				{
					TownSlot.Five,
					null
				},
				{
					TownSlot.Six,
					null
				},
				{
					TownSlot.Seven,
					null
				},
				{
					TownSlot.Eight,
					null
				}
			},
			AdventurerProfiles = new List<AdventurerProfile>
			{
				UnitClass.StreetMan.GenerateAdventurerProfileWithDefinedQuality(0.19f),
				UnitClass.DrunkReader.GenerateAdventurerProfileWithDefinedQuality(0.19f),
				UnitClass.Killer.GenerateAdventurerProfileWithDefinedQuality(0.19f)
			},
			GameDaysFractional = 0.0,
			GameDays = 0,
			MaxNumberOfSideQuests = 0,
			GameStarted = false,
			Candidates = new List<ResidentCandidate>(),
			ChosenBattleAdventurers = new List<AdventurerProfile>(),
			BattleTeams = new List<BattleTeam>
			{
				new BattleTeam(),
				new BattleTeam(),
				new BattleTeam()
			},
			StoredCandidates = new List<ResidentCandidate>(),
			Residents = new List<Resident>(),
			AdditionalData = new AdditionalData(),
			TimeScaleSetting = 1f,
			ItemOrderType = ItemOrderType.OrderByTime,
			SelectedSellItemLevel = 1,
			SelectedBreakItemLevel = 1,
			AdventurerOrderType = AdventurerOrderType.OrderByLevel,
			CurrentWeather = Weather.Sunny,
			CurrentSeason = Season.Spring,
			MainVolume = 0.5f,
			MusicVolume = 0.5f,
			EffectVolume = 0.5f,
			SideQuestsIssueDayCounter = null,
			ResidentsCreated = new Dictionary<ResidentType, int>(),
			SaveFileName = fileName,
			NumberOfResidentSlots = 5,
			NumberOfRefreshAdventurers = 2,
			SkillLevels = new Dictionary<SkillType, int>(),
			AcquiredPassives = new List<SkillType>(),
			CurrentJourneys = new List<TripRecord>(),
			CurrentVehicles = new List<Vehicle>(),
			StarRating = new int?(1),
			AchievedDifficultyValue = new double?(0.0),
			Resources = new List<ResourceProfile>(),
			Progresses = new Dictionary<int, PlayerProgress>
			{
				{
					1,
					PlayerProgress.Init()
				},
				{
					2,
					PlayerProgress.Init()
				},
				{
					3,
					PlayerProgress.Init()
				},
				{
					4,
					PlayerProgress.Init()
				}
			},
			EndlessDungeonDifficultyValue = new double?(0.0),
			EndlessRecord = DungeonRecord.InitLockedRecord(AdventureType.Endless_Entry)
		};
		playerProfile.AdditionalData.AddOrUpdateData(Adventure.EndlessAdventureLevelKey, Adventure.EndlessAdventurePartial + playerProfile.EndlessDungeonDifficultyValue.GetValueOrDefault());
		return playerProfile;
	}

	// Token: 0x06002462 RID: 9314 RVA: 0x001097EE File Offset: 0x00107BEE
	public void ResetProgress()
	{
		this.Progresses[this.GetStarRating()] = PlayerProgress.Init();
	}

	// Token: 0x06002463 RID: 9315 RVA: 0x00109806 File Offset: 0x00107C06
	public int GetNumberOfRefreshAdventurers()
	{
		return this.NumberOfRefreshAdventurers;
	}

	// Token: 0x06002464 RID: 9316 RVA: 0x00109810 File Offset: 0x00107C10
	public double GetResidentSlotUnlockCost()
	{
		if (this.NumberOfResidentSlots <= 10)
		{
			return 2000.0;
		}
		if (this.NumberOfResidentSlots <= 15)
		{
			return 10000.0;
		}
		if (this.NumberOfResidentSlots <= 21)
		{
			return 20000.0;
		}
		if (this.NumberOfResidentSlots < 25)
		{
			return 200000.0;
		}
		if (this.NumberOfResidentSlots <= 30)
		{
			return 500000.0;
		}
		return 2147483647.0;
	}

	// Token: 0x06002465 RID: 9317 RVA: 0x00109899 File Offset: 0x00107C99
	public bool CanUnlockResidentSlot()
	{
		return this.NumberOfResidentSlots < PlayerProfile.MaxResidentSlot && this.CanAfford(this.GetResidentSlotUnlockCost());
	}

	// Token: 0x06002466 RID: 9318 RVA: 0x001098BA File Offset: 0x00107CBA
	public void UnlockResidentSlot()
	{
		if (this.CanUnlockResidentSlot())
		{
			this.SpendMoney(this.GetResidentSlotUnlockCost());
			this.NumberOfResidentSlots++;
		}
	}

	// Token: 0x06002467 RID: 9319 RVA: 0x001098E4 File Offset: 0x00107CE4
	public void RandomTownTalk(DialogIdentifier dialog)
	{
		if (this.AdventurerProfiles.Any<AdventurerProfile>())
		{
			int index = UnityEngine.Random.Range(0, this.AdventurerProfiles.Count);
			AdventurerProfile adventurerProfile = this.AdventurerProfiles[index];
			adventurerProfile.UnitClass.Speaks(dialog);
		}
	}

	// Token: 0x06002468 RID: 9320 RVA: 0x0010992C File Offset: 0x00107D2C
	public void RecordDialog(DialogIdentifier dialogIdentifier)
	{
		if (this.GetProgress(null).DialogSpokenRecords.ContainsKey(dialogIdentifier))
		{
			Dictionary<DialogIdentifier, int> dialogSpokenRecords;
			(dialogSpokenRecords = this.GetProgress(null).DialogSpokenRecords)[dialogIdentifier] = dialogSpokenRecords[dialogIdentifier] + 1;
		}
		else
		{
			this.GetProgress(null).DialogSpokenRecords.Add(dialogIdentifier, 1);
		}
	}

	// Token: 0x06002469 RID: 9321 RVA: 0x001099A0 File Offset: 0x00107DA0
	public void RecordStory(StoryIdentifier storyIdentifier)
	{
		if (this.GetProgress(null).StoryTriggeredRecords.ContainsKey(storyIdentifier))
		{
			Dictionary<StoryIdentifier, int> storyTriggeredRecords;
			(storyTriggeredRecords = this.GetProgress(null).StoryTriggeredRecords)[storyIdentifier] = storyTriggeredRecords[storyIdentifier] + 1;
		}
		else
		{
			this.GetProgress(null).StoryTriggeredRecords.Add(storyIdentifier, 1);
		}
		if (this.GetProgress(null).StoryTriggerDates.ContainsKey(storyIdentifier))
		{
			this.GetProgress(null).StoryTriggerDates[storyIdentifier].Add(this.GameDays);
		}
		else
		{
			this.GetProgress(null).StoryTriggerDates.Add(storyIdentifier, new List<int>
			{
				this.GameDays
			});
		}
	}

	// Token: 0x0600246A RID: 9322 RVA: 0x00109A89 File Offset: 0x00107E89
	public void ResetSave()
	{
		GameLoader.ResetAllSaves();
	}

	// Token: 0x0600246B RID: 9323 RVA: 0x00109A90 File Offset: 0x00107E90
	private TownBoostValue GetItemQualityBoostRate()
	{
		double num = this.GetResidentEffects<LuckResidentEffect>().Sum((LuckResidentEffect r) => r.CurrentRate);
		double exceededValue = 0.0;
		if (num > PlayerProfile.MaxItemQualityBoostRate)
		{
			exceededValue = num - PlayerProfile.MaxItemQualityBoostRate;
			num = PlayerProfile.MaxItemQualityBoostRate;
		}
		return new TownBoostValue
		{
			FinalValue = num,
			ExceededValue = exceededValue
		};
	}

	// Token: 0x0600246C RID: 9324 RVA: 0x00109B00 File Offset: 0x00107F00
	public void ReleaseAdventurer(AdventurerProfile profile)
	{
		if (this.AdventurerProfiles.Count > 1)
		{
			AdventurerProfile adventurerProfile = this.AdventurerProfiles.FirstOrDefault((AdventurerProfile p) => p.Id == profile.Id);
			if (adventurerProfile != null)
			{
				List<Item> equipments = adventurerProfile.GetEquipments();
				foreach (Item equipment in equipments.ToList<Item>())
				{
					adventurerProfile.Disrobe(equipment, false);
				}
				this.AdventurerProfiles.Remove(adventurerProfile);
				double changeAmount = (double)adventurerProfile.Experience * PlayerProfile.ReleaseAdventurerGainPointsRatio;
				List<ResourceUpdate> list = new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.PracticePoints,
						ChangeAmount = changeAmount,
						RelatedItems = new List<Item>()
					}
				};
				this.BatchResourceUpdate(list);
				GameWorldEvent evt = GameWorldEvent.AdventurerListUpdated;
				AdventurerListUpdatedEvent adventurerListUpdatedEvent = new AdventurerListUpdatedEvent();
				adventurerListUpdatedEvent.AdventurerListUpdateType = AdventurerListUpdateType.Release;
				adventurerListUpdatedEvent.ChangedProfiles = new List<AdventurerProfile>
				{
					adventurerProfile
				};
				adventurerListUpdatedEvent.RelatedResourceUpdates = (from u in list
				select new ResourceUpdate
				{
					ResourceType = u.ResourceType,
					ChangeAmount = u.ChangeAmount,
					RelatedItems = u.RelatedItems
				}).ToList<ResourceUpdate>();
				this.ReceiveEvent(evt, adventurerListUpdatedEvent);
			}
		}
	}

	// Token: 0x0600246D RID: 9325 RVA: 0x00109C64 File Offset: 0x00108064
	public void Save()
	{
		string text = SystemProcessor.ApplicationPath + this.SaveFileName;
		string text2 = SystemProcessor.ApplicationPath + this.SaveFileName + "temp";
		if (File.Exists(text2))
		{
			File.Delete(text2);
		}
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = File.Create(text2);
		this.Resources = new List<ResourceProfile>();
		foreach (KeyValuePair<ResourceType, ResourceProfileAntiCheat> keyValuePair in this.ResourcesAt)
		{
			this.Resources.Add(new ResourceProfile
			{
				ResourceType = keyValuePair.Key,
				Amount = keyValuePair.Value.Amount / PlayerProfile.CurrentKey
			});
		}
		binaryFormatter.Serialize(fileStream, this);
		fileStream.Close();
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		File.Move(text2, text);
	}

	// Token: 0x0600246E RID: 9326 RVA: 0x00109D74 File Offset: 0x00108174
	public void Backup()
	{
		string key = "backupsave";
		int num = 0;
		if (this.AdditionalData.ContainsInt(key))
		{
			num = this.AdditionalData.GetInt(key);
		}
		num++;
		if (num > 10)
		{
			num = 1;
		}
		string path = string.Concat(new object[]
		{
			SystemProcessor.ApplicationPath,
			this.SaveFileName,
			"_bak_timely",
			num
		});
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		try
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = File.Create(path);
			this.Resources = new List<ResourceProfile>();
			foreach (KeyValuePair<ResourceType, ResourceProfileAntiCheat> keyValuePair in this.ResourcesAt)
			{
				this.Resources.Add(new ResourceProfile
				{
					ResourceType = keyValuePair.Key,
					Amount = keyValuePair.Value.Amount / PlayerProfile.CurrentKey
				});
			}
			binaryFormatter.Serialize(fileStream, this);
			fileStream.Close();
			this.AdditionalData.AddOrUpdateData(key, num);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x0600246F RID: 9327 RVA: 0x00109ED4 File Offset: 0x001082D4
	public void ItemPutOnSale(List<Item> items)
	{
		List<ItemStatusUpdateEvent> list = new List<ItemStatusUpdateEvent>();
		List<ResourceUpdate> list2 = new List<ResourceUpdate>();
		foreach (Item item in items)
		{
			if (item.ItemStatus != ItemStatus.Equipped)
			{
				ItemStatus itemStatus = item.ItemStatus;
				item.ItemStatus = ItemStatus.ForSale;
				ItemStatus itemStatus2 = item.ItemStatus;
				list.Add(new ItemStatusUpdateEvent
				{
					Item = item,
					CurrentStatus = itemStatus2,
					PreviousStatus = itemStatus
				});
				list2.Add(new ResourceUpdate
				{
					ResourceType = item.Type,
					ChangeAmount = -1.0,
					RelatedItems = new List<Item>
					{
						item
					}
				});
				list2.Add(new ResourceUpdate
				{
					ResourceType = ResourceType.Money,
					ChangeAmount = item.GetPrice(),
					RelatedItems = new List<Item>()
				});
			}
		}
		this.ReceiveEvent(GameWorldEvent.ItemPutOnSale, list);
		this.BatchResourceUpdate(list2);
	}

	// Token: 0x06002470 RID: 9328 RVA: 0x0010A00C File Offset: 0x0010840C
	public void ItemReserve(Item item)
	{
		ItemStatus itemStatus = item.ItemStatus;
		item.ItemStatus = ItemStatus.Reserved;
		ItemStatus itemStatus2 = item.ItemStatus;
		ItemStatusUpdateEvent data = new ItemStatusUpdateEvent
		{
			Item = item,
			CurrentStatus = itemStatus2,
			PreviousStatus = itemStatus
		};
		this.ReceiveEvent(GameWorldEvent.ItemReserved, data);
	}

	// Token: 0x06002471 RID: 9329 RVA: 0x0010A054 File Offset: 0x00108454
	public List<BattleTeam> GetBattleTeams()
	{
		if (this.BattleTeams == null)
		{
			this.BattleTeams = new List<BattleTeam>
			{
				new BattleTeam(),
				new BattleTeam(),
				new BattleTeam()
			};
		}
		using (List<BattleTeam>.Enumerator enumerator = this.BattleTeams.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BattleTeam battleTeam = enumerator.Current;
				PlayerProfile $this = this;
				if (battleTeam.Adventurers == null)
				{
					battleTeam.Adventurers = new List<AdventurerProfile>();
				}
				if (battleTeam.Rules == null)
				{
					battleTeam.Rules = new List<StrategyRule>();
				}
				battleTeam.Adventurers = (from a in battleTeam.Adventurers
				where $this.AdventurerProfiles.Contains(a)
				select a).ToList<AdventurerProfile>();
				battleTeam.Rules = (from r in battleTeam.Rules
				where battleTeam.Adventurers.Any((AdventurerProfile a) => a.Id == r.AdventurerId)
				select r).ToList<StrategyRule>();
			}
		}
		return this.BattleTeams;
	}

	// Token: 0x06002472 RID: 9330 RVA: 0x0010A194 File Offset: 0x00108594
	public void SelectBattleTeam(int index)
	{
		if (this.BattleTeams != null && this.BattleTeams.Count > index)
		{
			for (int i = 0; i < this.BattleTeams.Count; i++)
			{
				this.BattleTeams[i].IsSelected = (i == index);
			}
		}
	}

	// Token: 0x06002473 RID: 9331 RVA: 0x0010A1F0 File Offset: 0x001085F0
	public BattleTeam GetSelectedBattleTeam()
	{
		PlayerProfile.<GetSelectedBattleTeam>c__AnonStorey19 <GetSelectedBattleTeam>c__AnonStorey = new PlayerProfile.<GetSelectedBattleTeam>c__AnonStorey19();
		<GetSelectedBattleTeam>c__AnonStorey.$this = this;
		<GetSelectedBattleTeam>c__AnonStorey.selectedTeam = this.BattleTeams.FirstOrDefault((BattleTeam t) => t.IsSelected);
		if (<GetSelectedBattleTeam>c__AnonStorey.selectedTeam != null)
		{
			if (<GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Adventurers == null)
			{
				<GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Adventurers = new List<AdventurerProfile>();
			}
			if (<GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Rules == null)
			{
				<GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Rules = new List<StrategyRule>();
			}
			<GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Adventurers = (from a in <GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Adventurers
			where <GetSelectedBattleTeam>c__AnonStorey.$this.AdventurerProfiles.Contains(a)
			select a).ToList<AdventurerProfile>();
			<GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Rules = (from r in <GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Rules
			where <GetSelectedBattleTeam>c__AnonStorey.selectedTeam.Adventurers.Any((AdventurerProfile a) => a.Id == r.AdventurerId)
			select r).ToList<StrategyRule>();
			return <GetSelectedBattleTeam>c__AnonStorey.selectedTeam;
		}
		BattleTeam firstTeam = this.BattleTeams[0];
		firstTeam.Adventurers = (from a in firstTeam.Adventurers
		where <GetSelectedBattleTeam>c__AnonStorey.$this.AdventurerProfiles.Contains(a)
		select a).ToList<AdventurerProfile>();
		firstTeam.Rules = (from r in firstTeam.Rules
		where firstTeam.Adventurers.Any((AdventurerProfile a) => a.Id == r.AdventurerId)
		select r).ToList<StrategyRule>();
		return firstTeam;
	}

	// Token: 0x06002474 RID: 9332 RVA: 0x0010A35F File Offset: 0x0010875F
	public int GetIndexOfSelectedBattleTeam()
	{
		return this.BattleTeams.IndexOf(this.GetSelectedBattleTeam());
	}

	// Token: 0x06002475 RID: 9333 RVA: 0x0010A374 File Offset: 0x00108774
	public void StoreCandidate(List<ResidentCandidate> candidates)
	{
		QualityGrade maxGrade = candidates.Max((ResidentCandidate c) => c.Candidate.Grade);
		ResidentCandidate item = candidates.FirstOrDefault((ResidentCandidate c) => c.Candidate.Grade == maxGrade);
		if (this.StoredCandidates.Count >= 10)
		{
			this.StoredCandidates.RemoveAt(0);
		}
		this.StoredCandidates.Add(item);
		this.ResetCandidates();
	}

	// Token: 0x06002476 RID: 9334 RVA: 0x0010A3F4 File Offset: 0x001087F4
	public void RemoveStoredCandidate(string id)
	{
		ResidentCandidate residentCandidate = this.StoredCandidates.FirstOrDefault((ResidentCandidate c) => c.Candidate.Id == id);
		if (residentCandidate != null)
		{
			this.StoredCandidates.Remove(residentCandidate);
		}
	}

	// Token: 0x06002477 RID: 9335 RVA: 0x0010A439 File Offset: 0x00108839
	public bool AdventurerTypeObtained(UnitClass @class)
	{
		return this.HasResource(@class.GetConfiguration().CorrespondingInvitationType);
	}

	// Token: 0x06002478 RID: 9336 RVA: 0x0010A44C File Offset: 0x0010884C
	protected void OnGameWorldEventTriggered(GameWorldEvent arg1, object arg2)
	{
		Action<GameWorldEvent, object> gameWorldEventTriggered = this.GameWorldEventTriggered;
		if (gameWorldEventTriggered != null)
		{
			gameWorldEventTriggered(arg1, arg2);
		}
	}

	// Token: 0x06002479 RID: 9337 RVA: 0x0010A470 File Offset: 0x00108870
	// Note: this type is marked as 'beforefieldinit'.
	static PlayerProfile()
	{
	}

	// Token: 0x0600247A RID: 9338 RVA: 0x0010A5A8 File Offset: 0x001089A8
	[CompilerGenerated]
	private static int <GetMaximumItemTierObtainable>m__0(DifficultyLevelMeasurement df)
	{
		return df.GetCorrespondingItemTierLevel(ResourceType.HiddenWood);
	}

	// Token: 0x0600247B RID: 9339 RVA: 0x0010A5B5 File Offset: 0x001089B5
	[CompilerGenerated]
	private static int <GetMaximumItemTierObtainable>m__1(int a)
	{
		return a;
	}

	// Token: 0x0600247C RID: 9340 RVA: 0x0010A5B8 File Offset: 0x001089B8
	[CompilerGenerated]
	private static bool <AvaliablePolicyPoints>m__2(TownEventProcessorBase p)
	{
		return p.IsActive;
	}

	// Token: 0x0600247D RID: 9341 RVA: 0x0010A5C0 File Offset: 0x001089C0
	[CompilerGenerated]
	private static int <AvaliablePolicyPoints>m__3(TownEventProcessorBase p)
	{
		return p.RequiredPolicyPoint;
	}

	// Token: 0x0600247E RID: 9342 RVA: 0x0010A5C8 File Offset: 0x001089C8
	[CompilerGenerated]
	private static bool <GetSpecialAdventureTypes>m__4(HundredBattleRequirementLogic r)
	{
		return !r.fullfilled;
	}

	// Token: 0x0600247F RID: 9343 RVA: 0x0010A5D3 File Offset: 0x001089D3
	[CompilerGenerated]
	private static AdventureType <GetSpecialAdventureTypes>m__5(HundredBattleRequirementLogic r)
	{
		return r.DungeonType;
	}

	// Token: 0x06002480 RID: 9344 RVA: 0x0010A5DB File Offset: 0x001089DB
	[CompilerGenerated]
	private static bool <GetSpecialAdventureTypes>m__6(CustomizedDungeonThroughRequirementLogic r)
	{
		return !r.fullfilled && r.IsTwistedTimeDungeon;
	}

	// Token: 0x06002481 RID: 9345 RVA: 0x0010A5F1 File Offset: 0x001089F1
	[CompilerGenerated]
	private static AdventureType <GetSpecialAdventureTypes>m__7(CustomizedDungeonThroughRequirementLogic r)
	{
		return r.DungeonType;
	}

	// Token: 0x06002482 RID: 9346 RVA: 0x0010A5F9 File Offset: 0x001089F9
	[CompilerGenerated]
	private static bool <ClearUpData>m__8(Item i)
	{
		return i != null;
	}

	// Token: 0x06002483 RID: 9347 RVA: 0x0010A602 File Offset: 0x00108A02
	[CompilerGenerated]
	private static bool <ClearUpData>m__9(TripRecord j)
	{
		return j.Claimed && j.Completed;
	}

	// Token: 0x06002484 RID: 9348 RVA: 0x0010A618 File Offset: 0x00108A18
	[CompilerGenerated]
	private static bool <ClearUpData>m__A(ArmoryMasteryEffect e)
	{
		return e.NumberOfTriggersLeft > 2000;
	}

	// Token: 0x06002485 RID: 9349 RVA: 0x0010A627 File Offset: 0x00108A27
	[CompilerGenerated]
	private static bool <ClearUpData>m__B(DungeonRecord d)
	{
		return d.AdventureType != AdventureType.NorthernTerritory;
	}

	// Token: 0x06002486 RID: 9350 RVA: 0x0010A636 File Offset: 0x00108A36
	[CompilerGenerated]
	private static bool <ClearUpData>m__C(Quest q)
	{
		return q == null;
	}

	// Token: 0x06002487 RID: 9351 RVA: 0x0010A63C File Offset: 0x00108A3C
	[CompilerGenerated]
	private static IBuildingProfile <ClearUpData>m__D(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06002488 RID: 9352 RVA: 0x0010A645 File Offset: 0x00108A45
	[CompilerGenerated]
	private static bool <ClearUpData>m__E(IBuildingProfile b)
	{
		return b != null && b is RecruitmentFacility;
	}

	// Token: 0x06002489 RID: 9353 RVA: 0x0010A659 File Offset: 0x00108A59
	[CompilerGenerated]
	private static bool <ClearUpData>m__F(TownEffectBase ef)
	{
		return ef != null;
	}

	// Token: 0x0600248A RID: 9354 RVA: 0x0010A662 File Offset: 0x00108A62
	[CompilerGenerated]
	private static bool <GetConsumables>m__10(ResourceType k)
	{
		return k.GetResourceCategory() == ResourceCategory.Consumable;
	}

	// Token: 0x0600248B RID: 9355 RVA: 0x0010A66E File Offset: 0x00108A6E
	[CompilerGenerated]
	private ResourceProfileAntiCheat <GetConsumables>m__11(ResourceType r)
	{
		return this.ResourcesAt[r];
	}

	// Token: 0x0600248C RID: 9356 RVA: 0x0010A67C File Offset: 0x00108A7C
	[CompilerGenerated]
	private static bool <NumberOfExtraTripsCanbeStarted>m__12(TripRecord t)
	{
		return !t.Completed || !t.Claimed;
	}

	// Token: 0x0600248D RID: 9357 RVA: 0x0010A698 File Offset: 0x00108A98
	[CompilerGenerated]
	private static ResourceUpdate <CreateVehicle>m__13(ResourceConsumptionRequirement r)
	{
		return new ResourceUpdate
		{
			ResourceType = r.ResourceType,
			ChangeAmount = (double)(-(double)r.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x0600248E RID: 9358 RVA: 0x0010A6D1 File Offset: 0x00108AD1
	[CompilerGenerated]
	private static bool <GetAllAvaliableTravellers>m__14(AdventurerProfile ad)
	{
		return !ad.IsInBattle() && !ad.IsInTravel();
	}

	// Token: 0x0600248F RID: 9359 RVA: 0x0010A6EA File Offset: 0x00108AEA
	[CompilerGenerated]
	private static bool <GetAllAvaliableTravellers>m__15(Resident r)
	{
		return !r.IsInTravel();
	}

	// Token: 0x06002490 RID: 9360 RVA: 0x0010A6F5 File Offset: 0x00108AF5
	[CompilerGenerated]
	private static IBuildingProfile <GetWeaponShop>m__16(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06002491 RID: 9361 RVA: 0x0010A6FE File Offset: 0x00108AFE
	[CompilerGenerated]
	private static bool <GetWeaponShop>m__17(IBuildingProfile b)
	{
		return b is ProductionBuildingProfile && b.BuildingType == BuildingType.WeaponShop;
	}

	// Token: 0x06002492 RID: 9362 RVA: 0x0010A717 File Offset: 0x00108B17
	[CompilerGenerated]
	private static IBuildingProfile <GetArmorShop>m__18(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06002493 RID: 9363 RVA: 0x0010A720 File Offset: 0x00108B20
	[CompilerGenerated]
	private static bool <GetArmorShop>m__19(IBuildingProfile b)
	{
		return b is ProductionBuildingProfile && b.BuildingType == BuildingType.ArmorShop;
	}

	// Token: 0x06002494 RID: 9364 RVA: 0x0010A739 File Offset: 0x00108B39
	[CompilerGenerated]
	private static IEnumerable<IResidentEffect> <GetResidentEffects<T>(Resident r) where T : IResidentEffect
	{
		return r.Effects;
	}

	// Token: 0x06002495 RID: 9365 RVA: 0x0010A741 File Offset: 0x00108B41
	[CompilerGenerated]
	private static IEnumerable<QuestRequirementBase> <GetQuestRequirements<T>(Quest q) where T : QuestRequirementBase
	{
		return q.QuestRequirements;
	}

	// Token: 0x06002496 RID: 9366 RVA: 0x0010A749 File Offset: 0x00108B49
	[CompilerGenerated]
	private static double <GetPracticePointsGainRatio>m__1C(PracticeResidentEffect r)
	{
		return r.CurrentRate;
	}

	// Token: 0x06002497 RID: 9367 RVA: 0x0010A751 File Offset: 0x00108B51
	[CompilerGenerated]
	private static double <GetAdventurerSpawnBoost>m__1D(RecruitmentQualityBoostEffect b)
	{
		return b.BoostRate;
	}

	// Token: 0x06002498 RID: 9368 RVA: 0x0010A759 File Offset: 0x00108B59
	[CompilerGenerated]
	private static IEnumerable<IResidentEffect> <GetWeaponPriceRatio>m__1E(Resident r)
	{
		return r.Effects;
	}

	// Token: 0x06002499 RID: 9369 RVA: 0x0010A761 File Offset: 0x00108B61
	[CompilerGenerated]
	private static double <GetWeaponPriceRatio>m__1F(WeaponSaleResidentEffect w)
	{
		return w.CurrentRate;
	}

	// Token: 0x0600249A RID: 9370 RVA: 0x0010A769 File Offset: 0x00108B69
	[CompilerGenerated]
	private static double <GetWeaponPriceRatio>m__20(GearPriceBoostEffect g)
	{
		return g.Rate;
	}

	// Token: 0x0600249B RID: 9371 RVA: 0x0010A771 File Offset: 0x00108B71
	[CompilerGenerated]
	private static IEnumerable<IResidentEffect> <GetArmorPriceRatio>m__21(Resident r)
	{
		return r.Effects;
	}

	// Token: 0x0600249C RID: 9372 RVA: 0x0010A779 File Offset: 0x00108B79
	[CompilerGenerated]
	private static double <GetArmorPriceRatio>m__22(ArmorSaleResidentEffect w)
	{
		return w.CurrentRate;
	}

	// Token: 0x0600249D RID: 9373 RVA: 0x0010A781 File Offset: 0x00108B81
	[CompilerGenerated]
	private static double <GetArmorPriceRatio>m__23(GearPriceBoostEffect g)
	{
		return g.Rate;
	}

	// Token: 0x0600249E RID: 9374 RVA: 0x0010A789 File Offset: 0x00108B89
	[CompilerGenerated]
	private static double <GetTotalChestBoost>m__24(DivineHeartResidentEffect d)
	{
		return d.CurrentRate;
	}

	// Token: 0x0600249F RID: 9375 RVA: 0x0010A791 File Offset: 0x00108B91
	[CompilerGenerated]
	private static bool <ChangeResource>m__25(Item i)
	{
		return i == null;
	}

	// Token: 0x060024A0 RID: 9376 RVA: 0x0010A797 File Offset: 0x00108B97
	[CompilerGenerated]
	private static void <ChangeResource>m__26(Item i)
	{
		i.ItemStatus = ItemStatus.Reserved;
	}

	// Token: 0x060024A1 RID: 9377 RVA: 0x0010A7A0 File Offset: 0x00108BA0
	[CompilerGenerated]
	private static void <ChangeResource>m__27(Item i)
	{
		i.ItemStatus = ItemStatus.Removed;
	}

	// Token: 0x060024A2 RID: 9378 RVA: 0x0010A7A9 File Offset: 0x00108BA9
	[CompilerGenerated]
	private static bool <ChangeResource>m__28(Item i)
	{
		return i.ItemStatus == ItemStatus.Removed;
	}

	// Token: 0x060024A3 RID: 9379 RVA: 0x0010A7B4 File Offset: 0x00108BB4
	[CompilerGenerated]
	private static ResourceType <BatchResourceUpdate>m__29(ResourceUpdate c)
	{
		return c.ResourceType;
	}

	// Token: 0x060024A4 RID: 9380 RVA: 0x0010A7BC File Offset: 0x00108BBC
	[CompilerGenerated]
	private static ResourceUpdate <BatchResourceUpdate>m__2A(IGrouping<ResourceType, ResourceUpdate> g)
	{
		ResourceUpdate resourceUpdate = new ResourceUpdate();
		resourceUpdate.ResourceType = g.Key;
		resourceUpdate.ChangeAmount = g.Sum((ResourceUpdate r) => r.ChangeAmount);
		resourceUpdate.RelatedItems = g.SelectMany((ResourceUpdate r) => r.RelatedItems).ToList<Item>();
		return resourceUpdate;
	}

	// Token: 0x060024A5 RID: 9381 RVA: 0x0010A833 File Offset: 0x00108C33
	[CompilerGenerated]
	private static TripRecord <Process>m__2B(TripRecord j)
	{
		return j;
	}

	// Token: 0x060024A6 RID: 9382 RVA: 0x0010A836 File Offset: 0x00108C36
	[CompilerGenerated]
	private static ResidentCandidate <ResetCandidates>m__2C(ResidentCandidate c)
	{
		return c;
	}

	// Token: 0x060024A7 RID: 9383 RVA: 0x0010A839 File Offset: 0x00108C39
	[CompilerGenerated]
	private static DifficultyLevelMeasurement <GetProductionDifficultyLevelMeasurement>m__2D(KeyValuePair<int, PlayerProgress> p)
	{
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(p.Value.MaxAchievedDifficultyValue, p.Key);
	}

	// Token: 0x060024A8 RID: 9384 RVA: 0x0010A853 File Offset: 0x00108C53
	[CompilerGenerated]
	private static bool <GetProductionDifficultyLevelMeasurement>m__2E(DifficultyLevelMeasurement m)
	{
		return m.DifficultyValue > 0.0;
	}

	// Token: 0x060024A9 RID: 9385 RVA: 0x0010A866 File Offset: 0x00108C66
	[CompilerGenerated]
	private static int <GetProductionDifficultyLevelMeasurement>m__2F(DifficultyLevelMeasurement m)
	{
		return m.StarRating;
	}

	// Token: 0x060024AA RID: 9386 RVA: 0x0010A86E File Offset: 0x00108C6E
	[CompilerGenerated]
	private static bool <ReceiveEvent>m__30(Quest q)
	{
		return !q.Completed;
	}

	// Token: 0x060024AB RID: 9387 RVA: 0x0010A879 File Offset: 0x00108C79
	[CompilerGenerated]
	private static double <GetItemQualityBoostRate>m__31(LuckResidentEffect r)
	{
		return r.CurrentRate;
	}

	// Token: 0x060024AC RID: 9388 RVA: 0x0010A884 File Offset: 0x00108C84
	[CompilerGenerated]
	private static ResourceUpdate <ReleaseAdventurer>m__32(ResourceUpdate u)
	{
		return new ResourceUpdate
		{
			ResourceType = u.ResourceType,
			ChangeAmount = u.ChangeAmount,
			RelatedItems = u.RelatedItems
		};
	}

	// Token: 0x060024AD RID: 9389 RVA: 0x0010A8BC File Offset: 0x00108CBC
	[CompilerGenerated]
	private static bool <GetSelectedBattleTeam>m__33(BattleTeam t)
	{
		return t.IsSelected;
	}

	// Token: 0x060024AE RID: 9390 RVA: 0x0010A8C4 File Offset: 0x00108CC4
	[CompilerGenerated]
	private static QualityGrade <StoreCandidate>m__34(ResidentCandidate c)
	{
		return c.Candidate.Grade;
	}

	// Token: 0x060024AF RID: 9391 RVA: 0x0010A8D1 File Offset: 0x00108CD1
	[CompilerGenerated]
	private static double <BatchResourceUpdate>m__35(ResourceUpdate r)
	{
		return r.ChangeAmount;
	}

	// Token: 0x060024B0 RID: 9392 RVA: 0x0010A8D9 File Offset: 0x00108CD9
	[CompilerGenerated]
	private static IEnumerable<Item> <BatchResourceUpdate>m__36(ResourceUpdate r)
	{
		return r.RelatedItems;
	}

	// Token: 0x04001F13 RID: 7955
	public static readonly List<CoreProcessorBase> CoreProcessors = GameConfigurations.GetImplementationsOfAbstractClass<CoreProcessorBase>();

	// Token: 0x04001F14 RID: 7956
	public static double CurrentKey = 17.0;

	// Token: 0x04001F15 RID: 7957
	[NonSerialized]
	public Action<GameWorldEvent, object> GameWorldEventTriggered;

	// Token: 0x04001F16 RID: 7958
	public static readonly double MaxPossibleResources_NonItem = 1000000000000.0;

	// Token: 0x04001F17 RID: 7959
	public static readonly double MaxPossibleResources_Item = 40000.0;

	// Token: 0x04001F18 RID: 7960
	public static readonly float ProcessSpeed = 1f;

	// Token: 0x04001F19 RID: 7961
	public static readonly double TurnSpeedbase = 1.0;

	// Token: 0x04001F1A RID: 7962
	public static readonly double TurnSpeedGauge = 5.0;

	// Token: 0x04001F1B RID: 7963
	public static readonly double SaleUpgradePriceChangeRatePerLevel = 0.3;

	// Token: 0x04001F1C RID: 7964
	public static readonly int OccupancyChangeRatePerLevel = 5;

	// Token: 0x04001F1D RID: 7965
	public static readonly int InitRecruitmentPrice = 500;

	// Token: 0x04001F1E RID: 7966
	public static readonly int RecruitmentUpgradeRate = 1;

	// Token: 0x04001F1F RID: 7967
	public static readonly int InventoryCapacity = 40000;

	// Token: 0x04001F20 RID: 7968
	public static readonly double GaugePerPlay = 5.0;

	// Token: 0x04001F21 RID: 7969
	public static readonly double GaugePerWin = 5.0;

	// Token: 0x04001F22 RID: 7970
	public static readonly int GaugeResetGapDays = 5;

	// Token: 0x04001F23 RID: 7971
	public static readonly int ShopRefreshDays = 20;

	// Token: 0x04001F24 RID: 7972
	public static readonly int RecruitmentRefreshDays = 20;

	// Token: 0x04001F25 RID: 7973
	public static readonly int MaxResidentSlot = 30;

	// Token: 0x04001F26 RID: 7974
	public static readonly double ReleaseAdventurerGainPointsRatio = 0.7;

	// Token: 0x04001F27 RID: 7975
	public static readonly double MaxReisdentPriceBoost = 20.0;

	// Token: 0x04001F28 RID: 7976
	public static readonly double MaxProductionRate = 50.0;

	// Token: 0x04001F29 RID: 7977
	public static readonly double MaxItemQualityBoostRate = 30.0;

	// Token: 0x04001F2A RID: 7978
	public static readonly double MaxChestBoost = 10.0;

	// Token: 0x04001F2B RID: 7979
	public static readonly double MaxDivineHeartBoost = 10.0;

	// Token: 0x04001F2C RID: 7980
	public static readonly double MaxPracticePointsBoost = 30.0;

	// Token: 0x04001F2D RID: 7981
	public static readonly string TalentVersionDetails = "initial:27/04/2018-v1";

	// Token: 0x04001F2E RID: 7982
	public Dictionary<ResourceType, int> GenerationSeeds;

	// Token: 0x04001F2F RID: 7983
	[NonSerialized]
	public PlayerTownStatsSummary TownStatsSummary;

	// Token: 0x04001F30 RID: 7984
	public string SaveFileName;

	// Token: 0x04001F31 RID: 7985
	public int GameDays;

	// Token: 0x04001F32 RID: 7986
	public double GameDaysFractional;

	// Token: 0x04001F33 RID: 7987
	public bool GameStarted;

	// Token: 0x04001F34 RID: 7988
	[NonSerialized]
	public Dictionary<ResourceType, ResourceProfileAntiCheat> ResourcesAt;

	// Token: 0x04001F35 RID: 7989
	public List<ResourceProfile> Resources;

	// Token: 0x04001F36 RID: 7990
	public List<Item> Items;

	// Token: 0x04001F37 RID: 7991
	public ItemOrderType ItemOrderType;

	// Token: 0x04001F38 RID: 7992
	public int SelectedSellItemLevel;

	// Token: 0x04001F39 RID: 7993
	public int SelectedBreakItemLevel;

	// Token: 0x04001F3A RID: 7994
	public AdventurerOrderType AdventurerOrderType;

	// Token: 0x04001F3B RID: 7995
	public List<ResourceType> UnlockedResourceRecipes;

	// Token: 0x04001F3C RID: 7996
	public float TimeScaleSetting;

	// Token: 0x04001F3D RID: 7997
	public List<AdventurerProfile> AdventurerProfiles;

	// Token: 0x04001F3E RID: 7998
	public Dictionary<TownSlot, IBuildingProfile> Buildings;

	// Token: 0x04001F3F RID: 7999
	public List<Resident> Residents;

	// Token: 0x04001F40 RID: 8000
	public List<ResidentCandidate> Candidates;

	// Token: 0x04001F41 RID: 8001
	public List<AdventurerProfile> ChosenBattleAdventurers;

	// Token: 0x04001F42 RID: 8002
	public List<BattleTeam> BattleTeams;

	// Token: 0x04001F43 RID: 8003
	public List<ResidentCandidate> StoredCandidates;

	// Token: 0x04001F44 RID: 8004
	public ConsumableItem ConsumableItem;

	// Token: 0x04001F45 RID: 8005
	public int MaxNumberOfSideQuests;

	// Token: 0x04001F46 RID: 8006
	public AdditionalData AdditionalData;

	// Token: 0x04001F47 RID: 8007
	public Weather CurrentWeather;

	// Token: 0x04001F48 RID: 8008
	public Season CurrentSeason;

	// Token: 0x04001F49 RID: 8009
	public Dictionary<int, PlayerProgress> Progresses;

	// Token: 0x04001F4A RID: 8010
	public Dictionary<QuestIdentifier, int> QuestIssuedRecords;

	// Token: 0x04001F4B RID: 8011
	public Dictionary<StoryIdentifier, List<int>> StoryTriggerDates;

	// Token: 0x04001F4C RID: 8012
	public Dictionary<QuestIdentifier, int> QuestCompletionRecords;

	// Token: 0x04001F4D RID: 8013
	public Dictionary<DialogIdentifier, int> DialogSpokenRecords;

	// Token: 0x04001F4E RID: 8014
	public Dictionary<StoryIdentifier, int> StoryTriggeredRecords;

	// Token: 0x04001F4F RID: 8015
	public Dictionary<QuestChainIdentifier, bool> QuestChainCompletionRecords;

	// Token: 0x04001F50 RID: 8016
	public List<Quest> Quests;

	// Token: 0x04001F51 RID: 8017
	public List<DungeonRecord> DungeonRecords;

	// Token: 0x04001F52 RID: 8018
	public double Reputation;

	// Token: 0x04001F53 RID: 8019
	public Dictionary<ResidentType, int> ResidentsCreated;

	// Token: 0x04001F54 RID: 8020
	public int? SideQuestsIssueDayCounter;

	// Token: 0x04001F55 RID: 8021
	public float MainVolume;

	// Token: 0x04001F56 RID: 8022
	public float MusicVolume;

	// Token: 0x04001F57 RID: 8023
	public float EffectVolume;

	// Token: 0x04001F58 RID: 8024
	public int NumberOfResidentSlots;

	// Token: 0x04001F59 RID: 8025
	public int NumberOfRefreshAdventurers;

	// Token: 0x04001F5A RID: 8026
	public Dictionary<SkillType, int> SkillLevels;

	// Token: 0x04001F5B RID: 8027
	public List<SkillType> AcquiredPassives;

	// Token: 0x04001F5C RID: 8028
	public double? AchievedDifficultyValue;

	// Token: 0x04001F5D RID: 8029
	public int? StarRating;

	// Token: 0x04001F5E RID: 8030
	public List<Vehicle> CurrentVehicles;

	// Token: 0x04001F5F RID: 8031
	public List<TripRecord> CurrentJourneys;

	// Token: 0x04001F60 RID: 8032
	public double? EndlessDungeonDifficultyValue;

	// Token: 0x04001F61 RID: 8033
	public DungeonRecord EndlessRecord;

	// Token: 0x04001F62 RID: 8034
	public List<TownEventProcessorBase> TownEventProcessors;

	// Token: 0x04001F63 RID: 8035
	public List<TownEffectBase> TownEffects;

	// Token: 0x04001F64 RID: 8036
	public int? ScrollGenerationSeed;

	// Token: 0x04001F65 RID: 8037
	public Dictionary<SpecialEffectType, bool> EffectUnlocked;

	// Token: 0x04001F66 RID: 8038
	[CompilerGenerated]
	private static Func<DifficultyLevelMeasurement, int> <>f__am$cache0;

	// Token: 0x04001F67 RID: 8039
	[CompilerGenerated]
	private static Func<int, int> <>f__am$cache1;

	// Token: 0x04001F68 RID: 8040
	[CompilerGenerated]
	private static Func<TownEventProcessorBase, bool> <>f__am$cache2;

	// Token: 0x04001F69 RID: 8041
	[CompilerGenerated]
	private static Func<TownEventProcessorBase, int> <>f__am$cache3;

	// Token: 0x04001F6A RID: 8042
	[CompilerGenerated]
	private static Func<HundredBattleRequirementLogic, bool> <>f__am$cache4;

	// Token: 0x04001F6B RID: 8043
	[CompilerGenerated]
	private static Func<HundredBattleRequirementLogic, AdventureType> <>f__am$cache5;

	// Token: 0x04001F6C RID: 8044
	[CompilerGenerated]
	private static Func<CustomizedDungeonThroughRequirementLogic, bool> <>f__am$cache6;

	// Token: 0x04001F6D RID: 8045
	[CompilerGenerated]
	private static Func<CustomizedDungeonThroughRequirementLogic, AdventureType> <>f__am$cache7;

	// Token: 0x04001F6E RID: 8046
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache8;

	// Token: 0x04001F6F RID: 8047
	[CompilerGenerated]
	private static Predicate<TripRecord> <>f__am$cache9;

	// Token: 0x04001F70 RID: 8048
	[CompilerGenerated]
	private static Func<ArmoryMasteryEffect, bool> <>f__am$cacheA;

	// Token: 0x04001F71 RID: 8049
	[CompilerGenerated]
	private static Func<DungeonRecord, bool> <>f__am$cacheB;

	// Token: 0x04001F72 RID: 8050
	[CompilerGenerated]
	private static Predicate<Quest> <>f__am$cacheC;

	// Token: 0x04001F73 RID: 8051
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cacheD;

	// Token: 0x04001F74 RID: 8052
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cacheE;

	// Token: 0x04001F75 RID: 8053
	[CompilerGenerated]
	private static Func<TownEffectBase, bool> <>f__am$cacheF;

	// Token: 0x04001F76 RID: 8054
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache10;

	// Token: 0x04001F77 RID: 8055
	[CompilerGenerated]
	private static Func<VehicleType, VehicleGeneratorBase> <>f__mg$cache0;

	// Token: 0x04001F78 RID: 8056
	[CompilerGenerated]
	private static Func<TripRecord, bool> <>f__am$cache11;

	// Token: 0x04001F79 RID: 8057
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cache12;

	// Token: 0x04001F7A RID: 8058
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache13;

	// Token: 0x04001F7B RID: 8059
	[CompilerGenerated]
	private static Func<Resident, bool> <>f__am$cache14;

	// Token: 0x04001F7C RID: 8060
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache15;

	// Token: 0x04001F7D RID: 8061
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache16;

	// Token: 0x04001F7E RID: 8062
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache17;

	// Token: 0x04001F7F RID: 8063
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache18;

	// Token: 0x04001F80 RID: 8064
	[CompilerGenerated]
	private static Func<PracticeResidentEffect, double> <>f__am$cache19;

	// Token: 0x04001F81 RID: 8065
	[CompilerGenerated]
	private static Func<RecruitmentQualityBoostEffect, double> <>f__am$cache1A;

	// Token: 0x04001F82 RID: 8066
	[CompilerGenerated]
	private static Func<Resident, IEnumerable<IResidentEffect>> <>f__am$cache1B;

	// Token: 0x04001F83 RID: 8067
	[CompilerGenerated]
	private static Func<WeaponSaleResidentEffect, double> <>f__am$cache1C;

	// Token: 0x04001F84 RID: 8068
	[CompilerGenerated]
	private static Func<GearPriceBoostEffect, double> <>f__am$cache1D;

	// Token: 0x04001F85 RID: 8069
	[CompilerGenerated]
	private static Func<Resident, IEnumerable<IResidentEffect>> <>f__am$cache1E;

	// Token: 0x04001F86 RID: 8070
	[CompilerGenerated]
	private static Func<ArmorSaleResidentEffect, double> <>f__am$cache1F;

	// Token: 0x04001F87 RID: 8071
	[CompilerGenerated]
	private static Func<GearPriceBoostEffect, double> <>f__am$cache20;

	// Token: 0x04001F88 RID: 8072
	[CompilerGenerated]
	private static Func<DivineHeartResidentEffect, double> <>f__am$cache21;

	// Token: 0x04001F89 RID: 8073
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache22;

	// Token: 0x04001F8A RID: 8074
	[CompilerGenerated]
	private static Action<Item> <>f__am$cache23;

	// Token: 0x04001F8B RID: 8075
	[CompilerGenerated]
	private static Action<Item> <>f__am$cache24;

	// Token: 0x04001F8C RID: 8076
	[CompilerGenerated]
	private static Predicate<Item> <>f__am$cache25;

	// Token: 0x04001F8D RID: 8077
	[CompilerGenerated]
	private static Func<ResourceUpdate, ResourceType> <>f__am$cache26;

	// Token: 0x04001F8E RID: 8078
	[CompilerGenerated]
	private static Func<IGrouping<ResourceType, ResourceUpdate>, ResourceUpdate> <>f__am$cache27;

	// Token: 0x04001F8F RID: 8079
	[CompilerGenerated]
	private static Func<TripRecord, TripRecord> <>f__am$cache28;

	// Token: 0x04001F90 RID: 8080
	[CompilerGenerated]
	private static Func<ResidentCandidate, ResidentCandidate> <>f__am$cache29;

	// Token: 0x04001F91 RID: 8081
	[CompilerGenerated]
	private static Func<KeyValuePair<int, PlayerProgress>, DifficultyLevelMeasurement> <>f__am$cache2A;

	// Token: 0x04001F92 RID: 8082
	[CompilerGenerated]
	private static Func<DifficultyLevelMeasurement, bool> <>f__am$cache2B;

	// Token: 0x04001F93 RID: 8083
	[CompilerGenerated]
	private static Func<DifficultyLevelMeasurement, int> <>f__am$cache2C;

	// Token: 0x04001F94 RID: 8084
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache2D;

	// Token: 0x04001F95 RID: 8085
	[CompilerGenerated]
	private static Func<LuckResidentEffect, double> <>f__am$cache2E;

	// Token: 0x04001F96 RID: 8086
	[CompilerGenerated]
	private static Func<ResourceUpdate, ResourceUpdate> <>f__am$cache2F;

	// Token: 0x04001F97 RID: 8087
	[CompilerGenerated]
	private static Func<BattleTeam, bool> <>f__am$cache30;

	// Token: 0x04001F98 RID: 8088
	[CompilerGenerated]
	private static Func<ResidentCandidate, QualityGrade> <>f__am$cache31;

	// Token: 0x04001F99 RID: 8089
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache32;

	// Token: 0x04001F9A RID: 8090
	[CompilerGenerated]
	private static Func<ResourceUpdate, IEnumerable<Item>> <>f__am$cache33;

	// Token: 0x02000D8F RID: 3471
	[CompilerGenerated]
	private sealed class <RemoveTownEffect>c__AnonStorey0
	{
		// Token: 0x06005823 RID: 22563 RVA: 0x0010A8E1 File Offset: 0x00108CE1
		public <RemoveTownEffect>c__AnonStorey0()
		{
		}

		// Token: 0x06005824 RID: 22564 RVA: 0x0010A8E9 File Offset: 0x00108CE9
		internal bool <>m__0(TownEffectBase e)
		{
			return e == this.effect;
		}

		// Token: 0x0400482F RID: 18479
		internal TownEffectBase effect;
	}

	// Token: 0x02000D90 RID: 3472
	[CompilerGenerated]
	private sealed class <AddTownEffect>c__AnonStorey1
	{
		// Token: 0x06005825 RID: 22565 RVA: 0x0010A8F4 File Offset: 0x00108CF4
		public <AddTownEffect>c__AnonStorey1()
		{
		}

		// Token: 0x06005826 RID: 22566 RVA: 0x0010A8FC File Offset: 0x00108CFC
		internal bool <>m__0(TownEffectBase ef)
		{
			return ef.CanbeMergedWith(this.effect);
		}

		// Token: 0x06005827 RID: 22567 RVA: 0x0010A90A File Offset: 0x00108D0A
		internal bool <>m__1(TownEffectBase ef)
		{
			return ef.CanbeMergedWith(this.effect);
		}

		// Token: 0x04004830 RID: 18480
		internal TownEffectBase effect;
	}

	// Token: 0x02000D91 RID: 3473
	[CompilerGenerated]
	private sealed class <ClearUpData>c__AnonStorey2
	{
		// Token: 0x06005828 RID: 22568 RVA: 0x0010A918 File Offset: 0x00108D18
		public <ClearUpData>c__AnonStorey2()
		{
		}

		// Token: 0x06005829 RID: 22569 RVA: 0x0010A920 File Offset: 0x00108D20
		internal bool <>m__0(TownEffectBase t)
		{
			return this.toremove.Any((ArmoryMasteryEffect a) => a == t);
		}

		// Token: 0x04004831 RID: 18481
		internal IEnumerable<ArmoryMasteryEffect> toremove;

		// Token: 0x02000DAA RID: 3498
		private sealed class <ClearUpData>c__AnonStorey3
		{
			// Token: 0x06005861 RID: 22625 RVA: 0x0010A958 File Offset: 0x00108D58
			public <ClearUpData>c__AnonStorey3()
			{
			}

			// Token: 0x06005862 RID: 22626 RVA: 0x0010A960 File Offset: 0x00108D60
			internal bool <>m__0(ArmoryMasteryEffect a)
			{
				return a == this.t;
			}

			// Token: 0x0400484D RID: 18509
			internal TownEffectBase t;

			// Token: 0x0400484E RID: 18510
			internal PlayerProfile.<ClearUpData>c__AnonStorey2 <>f__ref$2;
		}
	}

	// Token: 0x02000D92 RID: 3474
	[CompilerGenerated]
	private sealed class <GetCurrentTravellers>c__AnonStorey4
	{
		// Token: 0x0600582A RID: 22570 RVA: 0x0010A96B File Offset: 0x00108D6B
		public <GetCurrentTravellers>c__AnonStorey4()
		{
		}

		// Token: 0x0600582B RID: 22571 RVA: 0x0010A973 File Offset: 0x00108D73
		internal void <>m__0(TripRecord c)
		{
			this.travellers.AddRange(c.Travellers);
		}

		// Token: 0x04004832 RID: 18482
		internal List<ITraveller> travellers;
	}

	// Token: 0x02000D93 RID: 3475
	[CompilerGenerated]
	private sealed class <StartTrip>c__AnonStorey5
	{
		// Token: 0x0600582C RID: 22572 RVA: 0x0010A986 File Offset: 0x00108D86
		public <StartTrip>c__AnonStorey5()
		{
		}

		// Token: 0x0600582D RID: 22573 RVA: 0x0010A98E File Offset: 0x00108D8E
		internal bool <>m__0(Vehicle v)
		{
			return v == this.boat;
		}

		// Token: 0x04004833 RID: 18483
		internal Vehicle boat;
	}

	// Token: 0x02000D94 RID: 3476
	[CompilerGenerated]
	private sealed class <RemoveVehcle>c__AnonStorey6
	{
		// Token: 0x0600582E RID: 22574 RVA: 0x0010A999 File Offset: 0x00108D99
		public <RemoveVehcle>c__AnonStorey6()
		{
		}

		// Token: 0x0600582F RID: 22575 RVA: 0x0010A9A1 File Offset: 0x00108DA1
		internal bool <>m__0(Vehicle v)
		{
			return v == this.toRemove;
		}

		// Token: 0x04004834 RID: 18484
		internal Vehicle toRemove;
	}

	// Token: 0x02000D95 RID: 3477
	[CompilerGenerated]
	private sealed class <CanCreateVehicle>c__AnonStorey7
	{
		// Token: 0x06005830 RID: 22576 RVA: 0x0010A9AC File Offset: 0x00108DAC
		public <CanCreateVehicle>c__AnonStorey7()
		{
		}

		// Token: 0x06005831 RID: 22577 RVA: 0x0010A9B4 File Offset: 0x00108DB4
		internal bool <>m__0(VehicleGeneratorBase v)
		{
			return v.VehicleType == this.type;
		}

		// Token: 0x04004835 RID: 18485
		internal VehicleType type;
	}

	// Token: 0x02000D96 RID: 3478
	[CompilerGenerated]
	private sealed class <GetDungeonRecord>c__AnonStorey8
	{
		// Token: 0x06005832 RID: 22578 RVA: 0x0010A9C4 File Offset: 0x00108DC4
		public <GetDungeonRecord>c__AnonStorey8()
		{
		}

		// Token: 0x06005833 RID: 22579 RVA: 0x0010A9CC File Offset: 0x00108DCC
		internal bool <>m__0(DungeonRecord d)
		{
			return d.AdventureType == this.type;
		}

		// Token: 0x04004836 RID: 18486
		internal AdventureType type;
	}

	// Token: 0x02000D97 RID: 3479
	[CompilerGenerated]
	private sealed class <GetAdventureCodedRequirement>c__AnonStorey9
	{
		// Token: 0x06005834 RID: 22580 RVA: 0x0010A9DC File Offset: 0x00108DDC
		public <GetAdventureCodedRequirement>c__AnonStorey9()
		{
		}

		// Token: 0x06005835 RID: 22581 RVA: 0x0010A9E4 File Offset: 0x00108DE4
		internal bool <>m__0(HundredBattleRequirementLogic c)
		{
			return c.IdentityCode == this.identityCode;
		}

		// Token: 0x06005836 RID: 22582 RVA: 0x0010A9F7 File Offset: 0x00108DF7
		internal bool <>m__1(CustomizedDungeonThroughRequirementLogic c)
		{
			return c.Configuration.CustomizedIdentityCode == this.identityCode;
		}

		// Token: 0x04004837 RID: 18487
		internal string identityCode;
	}

	// Token: 0x02000D98 RID: 3480
	[CompilerGenerated]
	private sealed class <GetQuestRequirements>c__AnonStoreyA<T> where T : QuestRequirementBase
	{
		// Token: 0x06005837 RID: 22583 RVA: 0x0010AA0F File Offset: 0x00108E0F
		public <GetQuestRequirements>c__AnonStoreyA()
		{
		}

		// Token: 0x06005838 RID: 22584 RVA: 0x0010AA17 File Offset: 0x00108E17
		internal bool <>m__0(Quest q)
		{
			return !this.activeOnly || (!q.Completed && !q.Cancelled);
		}

		// Token: 0x04004838 RID: 18488
		internal bool activeOnly;
	}

	// Token: 0x02000D99 RID: 3481
	[CompilerGenerated]
	private sealed class <QuestIsActive>c__AnonStoreyB
	{
		// Token: 0x06005839 RID: 22585 RVA: 0x0010AA3E File Offset: 0x00108E3E
		public <QuestIsActive>c__AnonStoreyB()
		{
		}

		// Token: 0x0600583A RID: 22586 RVA: 0x0010AA46 File Offset: 0x00108E46
		internal bool <>m__0(Quest q)
		{
			return q.QuestIdentifier == this.questIdentifier && !q.Cancelled && !q.Completed && !q.HasExpired();
		}

		// Token: 0x04004839 RID: 18489
		internal QuestIdentifier questIdentifier;
	}

	// Token: 0x02000D9A RID: 3482
	[CompilerGenerated]
	private sealed class <RecipeHasAccaquired>c__AnonStoreyC
	{
		// Token: 0x0600583B RID: 22587 RVA: 0x0010AA7B File Offset: 0x00108E7B
		public <RecipeHasAccaquired>c__AnonStoreyC()
		{
		}

		// Token: 0x0600583C RID: 22588 RVA: 0x0010AA83 File Offset: 0x00108E83
		internal bool <>m__0(Recipe r)
		{
			return r.ProductType == this.type;
		}

		// Token: 0x0400483A RID: 18490
		internal ResourceType type;
	}

	// Token: 0x02000D9B RID: 3483
	[CompilerGenerated]
	private sealed class <ChangeResource>c__AnonStoreyE
	{
		// Token: 0x0600583D RID: 22589 RVA: 0x0010AA93 File Offset: 0x00108E93
		public <ChangeResource>c__AnonStoreyE()
		{
		}

		// Token: 0x0600583E RID: 22590 RVA: 0x0010AA9B File Offset: 0x00108E9B
		internal bool <>m__0(Recipe r)
		{
			return r.RecipeName == this.type;
		}

		// Token: 0x0400483B RID: 18491
		internal ResourceType type;
	}

	// Token: 0x02000D9C RID: 3484
	[CompilerGenerated]
	private sealed class <ChangeResource>c__AnonStoreyD
	{
		// Token: 0x0600583F RID: 22591 RVA: 0x0010AAAB File Offset: 0x00108EAB
		public <ChangeResource>c__AnonStoreyD()
		{
		}

		// Token: 0x06005840 RID: 22592 RVA: 0x0010AAB3 File Offset: 0x00108EB3
		internal bool <>m__0(SkillType s)
		{
			return s != this.skill;
		}

		// Token: 0x0400483C RID: 18492
		internal SkillType skill;
	}

	// Token: 0x02000D9D RID: 3485
	[CompilerGenerated]
	private sealed class <GetAdventureSelectedLevel>c__AnonStoreyF
	{
		// Token: 0x06005841 RID: 22593 RVA: 0x0010AAC1 File Offset: 0x00108EC1
		public <GetAdventureSelectedLevel>c__AnonStoreyF()
		{
		}

		// Token: 0x06005842 RID: 22594 RVA: 0x0010AAC9 File Offset: 0x00108EC9
		internal bool <>m__0(DungeonRecord a)
		{
			return a.AdventureType == this.type;
		}

		// Token: 0x06005843 RID: 22595 RVA: 0x0010AAD9 File Offset: 0x00108ED9
		internal bool <>m__1(DungeonRecord a)
		{
			return a.AdventureType == this.type;
		}

		// Token: 0x0400483D RID: 18493
		internal AdventureType type;
	}

	// Token: 0x02000D9E RID: 3486
	[CompilerGenerated]
	private sealed class <GetResourceAmount_AvaliableForProduction>c__AnonStorey10
	{
		// Token: 0x06005844 RID: 22596 RVA: 0x0010AAE9 File Offset: 0x00108EE9
		public <GetResourceAmount_AvaliableForProduction>c__AnonStorey10()
		{
		}

		// Token: 0x06005845 RID: 22597 RVA: 0x0010AAF1 File Offset: 0x00108EF1
		internal bool <>m__0(Item i)
		{
			return i.Type == this.type && i.ItemStatus == ItemStatus.StockForProduction;
		}

		// Token: 0x0400483E RID: 18494
		internal ResourceType type;
	}

	// Token: 0x02000D9F RID: 3487
	[CompilerGenerated]
	private sealed class <GetProductionResourceItems>c__AnonStorey11
	{
		// Token: 0x06005846 RID: 22598 RVA: 0x0010AB10 File Offset: 0x00108F10
		public <GetProductionResourceItems>c__AnonStorey11()
		{
		}

		// Token: 0x06005847 RID: 22599 RVA: 0x0010AB18 File Offset: 0x00108F18
		internal bool <>m__0(Item i)
		{
			return i.Type == this.type && i.ItemStatus == ItemStatus.StockForProduction;
		}

		// Token: 0x06005848 RID: 22600 RVA: 0x0010AB37 File Offset: 0x00108F37
		internal bool <>m__1(Item i)
		{
			return i.Type == this.type && i.ItemStatus == ItemStatus.StockForProduction;
		}

		// Token: 0x0400483F RID: 18495
		internal ResourceType type;
	}

	// Token: 0x02000DA0 RID: 3488
	[CompilerGenerated]
	private sealed class <BuildingHasBeenBuilt>c__AnonStorey12
	{
		// Token: 0x06005849 RID: 22601 RVA: 0x0010AB56 File Offset: 0x00108F56
		public <BuildingHasBeenBuilt>c__AnonStorey12()
		{
		}

		// Token: 0x0600584A RID: 22602 RVA: 0x0010AB5E File Offset: 0x00108F5E
		internal bool <>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
		{
			return b.Value != null && b.Value.BuildingType == this.type;
		}

		// Token: 0x04004840 RID: 18496
		internal BuildingType type;
	}

	// Token: 0x02000DA1 RID: 3489
	[CompilerGenerated]
	private sealed class <AddNewResidentFromStoredCandidate>c__AnonStorey13
	{
		// Token: 0x0600584B RID: 22603 RVA: 0x0010AB83 File Offset: 0x00108F83
		public <AddNewResidentFromStoredCandidate>c__AnonStorey13()
		{
		}

		// Token: 0x0600584C RID: 22604 RVA: 0x0010AB8B File Offset: 0x00108F8B
		internal bool <>m__0(ResidentCandidate cd)
		{
			return cd == this.candidate;
		}

		// Token: 0x04004841 RID: 18497
		internal ResidentCandidate candidate;
	}

	// Token: 0x02000DA2 RID: 3490
	[CompilerGenerated]
	private sealed class <AddNewResidents>c__AnonStorey14
	{
		// Token: 0x0600584D RID: 22605 RVA: 0x0010AB96 File Offset: 0x00108F96
		public <AddNewResidents>c__AnonStorey14()
		{
		}

		// Token: 0x0600584E RID: 22606 RVA: 0x0010AB9E File Offset: 0x00108F9E
		internal bool <>m__0(ResidentCandidate cd)
		{
			return cd == this.candidate;
		}

		// Token: 0x04004842 RID: 18498
		internal ResidentCandidate candidate;
	}

	// Token: 0x02000DA3 RID: 3491
	[CompilerGenerated]
	private sealed class <RemoveResident>c__AnonStorey15
	{
		// Token: 0x0600584F RID: 22607 RVA: 0x0010ABA9 File Offset: 0x00108FA9
		public <RemoveResident>c__AnonStorey15()
		{
		}

		// Token: 0x06005850 RID: 22608 RVA: 0x0010ABB1 File Offset: 0x00108FB1
		internal bool <>m__0(Resident v)
		{
			return v.Id == this.residentId;
		}

		// Token: 0x06005851 RID: 22609 RVA: 0x0010ABC4 File Offset: 0x00108FC4
		internal bool <>m__1(Resident v)
		{
			return v.Id == this.residentId;
		}

		// Token: 0x04004843 RID: 18499
		internal string residentId;
	}

	// Token: 0x02000DA4 RID: 3492
	[CompilerGenerated]
	private sealed class <ReleaseAdventurer>c__AnonStorey16
	{
		// Token: 0x06005852 RID: 22610 RVA: 0x0010ABD7 File Offset: 0x00108FD7
		public <ReleaseAdventurer>c__AnonStorey16()
		{
		}

		// Token: 0x06005853 RID: 22611 RVA: 0x0010ABDF File Offset: 0x00108FDF
		internal bool <>m__0(AdventurerProfile p)
		{
			return p.Id == this.profile.Id;
		}

		// Token: 0x04004844 RID: 18500
		internal AdventurerProfile profile;
	}

	// Token: 0x02000DA5 RID: 3493
	[CompilerGenerated]
	private sealed class <GetBattleTeams>c__AnonStorey17
	{
		// Token: 0x06005854 RID: 22612 RVA: 0x0010ABF7 File Offset: 0x00108FF7
		public <GetBattleTeams>c__AnonStorey17()
		{
		}

		// Token: 0x06005855 RID: 22613 RVA: 0x0010ABFF File Offset: 0x00108FFF
		internal bool <>m__0(AdventurerProfile a)
		{
			return this.$this.AdventurerProfiles.Contains(a);
		}

		// Token: 0x06005856 RID: 22614 RVA: 0x0010AC14 File Offset: 0x00109014
		internal bool <>m__1(StrategyRule r)
		{
			return this.battleTeam.Adventurers.Any((AdventurerProfile a) => a.Id == r.AdventurerId);
		}

		// Token: 0x04004845 RID: 18501
		internal BattleTeam battleTeam;

		// Token: 0x04004846 RID: 18502
		internal PlayerProfile $this;

		// Token: 0x02000DAB RID: 3499
		private sealed class <GetBattleTeams>c__AnonStorey18
		{
			// Token: 0x06005863 RID: 22627 RVA: 0x0010AC51 File Offset: 0x00109051
			public <GetBattleTeams>c__AnonStorey18()
			{
			}

			// Token: 0x06005864 RID: 22628 RVA: 0x0010AC59 File Offset: 0x00109059
			internal bool <>m__0(AdventurerProfile a)
			{
				return a.Id == this.r.AdventurerId;
			}

			// Token: 0x0400484F RID: 18511
			internal StrategyRule r;

			// Token: 0x04004850 RID: 18512
			internal PlayerProfile.<GetBattleTeams>c__AnonStorey17 <>f__ref$23;
		}
	}

	// Token: 0x02000DA6 RID: 3494
	[CompilerGenerated]
	private sealed class <GetSelectedBattleTeam>c__AnonStorey19
	{
		// Token: 0x06005857 RID: 22615 RVA: 0x0010AC71 File Offset: 0x00109071
		public <GetSelectedBattleTeam>c__AnonStorey19()
		{
		}

		// Token: 0x06005858 RID: 22616 RVA: 0x0010AC79 File Offset: 0x00109079
		internal bool <>m__0(AdventurerProfile a)
		{
			return this.$this.AdventurerProfiles.Contains(a);
		}

		// Token: 0x06005859 RID: 22617 RVA: 0x0010AC8C File Offset: 0x0010908C
		internal bool <>m__1(StrategyRule r)
		{
			return this.selectedTeam.Adventurers.Any((AdventurerProfile a) => a.Id == r.AdventurerId);
		}

		// Token: 0x04004847 RID: 18503
		internal BattleTeam selectedTeam;

		// Token: 0x04004848 RID: 18504
		internal PlayerProfile $this;

		// Token: 0x02000DAC RID: 3500
		private sealed class <GetSelectedBattleTeam>c__AnonStorey1A
		{
			// Token: 0x06005865 RID: 22629 RVA: 0x0010ACC9 File Offset: 0x001090C9
			public <GetSelectedBattleTeam>c__AnonStorey1A()
			{
			}

			// Token: 0x06005866 RID: 22630 RVA: 0x0010ACD1 File Offset: 0x001090D1
			internal bool <>m__0(AdventurerProfile a)
			{
				return a.Id == this.r.AdventurerId;
			}

			// Token: 0x04004851 RID: 18513
			internal StrategyRule r;

			// Token: 0x04004852 RID: 18514
			internal PlayerProfile.<GetSelectedBattleTeam>c__AnonStorey19 <>f__ref$25;
		}
	}

	// Token: 0x02000DA7 RID: 3495
	[CompilerGenerated]
	private sealed class <GetSelectedBattleTeam>c__AnonStorey1B
	{
		// Token: 0x0600585A RID: 22618 RVA: 0x0010ACE9 File Offset: 0x001090E9
		public <GetSelectedBattleTeam>c__AnonStorey1B()
		{
		}

		// Token: 0x0600585B RID: 22619 RVA: 0x0010ACF1 File Offset: 0x001090F1
		internal bool <>m__0(AdventurerProfile a)
		{
			return this.<>f__ref$25.$this.AdventurerProfiles.Contains(a);
		}

		// Token: 0x0600585C RID: 22620 RVA: 0x0010AD0C File Offset: 0x0010910C
		internal bool <>m__1(StrategyRule r)
		{
			return this.firstTeam.Adventurers.Any((AdventurerProfile a) => a.Id == r.AdventurerId);
		}

		// Token: 0x04004849 RID: 18505
		internal BattleTeam firstTeam;

		// Token: 0x0400484A RID: 18506
		internal PlayerProfile.<GetSelectedBattleTeam>c__AnonStorey19 <>f__ref$25;

		// Token: 0x02000DAD RID: 3501
		private sealed class <GetSelectedBattleTeam>c__AnonStorey1C
		{
			// Token: 0x06005867 RID: 22631 RVA: 0x0010AD49 File Offset: 0x00109149
			public <GetSelectedBattleTeam>c__AnonStorey1C()
			{
			}

			// Token: 0x06005868 RID: 22632 RVA: 0x0010AD51 File Offset: 0x00109151
			internal bool <>m__0(AdventurerProfile a)
			{
				return a.Id == this.r.AdventurerId;
			}

			// Token: 0x04004853 RID: 18515
			internal StrategyRule r;

			// Token: 0x04004854 RID: 18516
			internal PlayerProfile.<GetSelectedBattleTeam>c__AnonStorey1B <>f__ref$27;
		}
	}

	// Token: 0x02000DA8 RID: 3496
	[CompilerGenerated]
	private sealed class <StoreCandidate>c__AnonStorey1D
	{
		// Token: 0x0600585D RID: 22621 RVA: 0x0010AD69 File Offset: 0x00109169
		public <StoreCandidate>c__AnonStorey1D()
		{
		}

		// Token: 0x0600585E RID: 22622 RVA: 0x0010AD71 File Offset: 0x00109171
		internal bool <>m__0(ResidentCandidate c)
		{
			return c.Candidate.Grade == this.maxGrade;
		}

		// Token: 0x0400484B RID: 18507
		internal QualityGrade maxGrade;
	}

	// Token: 0x02000DA9 RID: 3497
	[CompilerGenerated]
	private sealed class <RemoveStoredCandidate>c__AnonStorey1E
	{
		// Token: 0x0600585F RID: 22623 RVA: 0x0010AD86 File Offset: 0x00109186
		public <RemoveStoredCandidate>c__AnonStorey1E()
		{
		}

		// Token: 0x06005860 RID: 22624 RVA: 0x0010AD8E File Offset: 0x0010918E
		internal bool <>m__0(ResidentCandidate c)
		{
			return c.Candidate.Id == this.id;
		}

		// Token: 0x0400484C RID: 18508
		internal string id;
	}
}
