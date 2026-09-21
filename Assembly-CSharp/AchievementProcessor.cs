using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Steamworks;

// Token: 0x02000485 RID: 1157
public class AchievementProcessor : IFactionProcessor
{
	// Token: 0x060020D3 RID: 8403 RVA: 0x000E30FA File Offset: 0x000E14FA
	public AchievementProcessor()
	{
	}

	// Token: 0x17000226 RID: 550
	// (get) Token: 0x060020D4 RID: 8404 RVA: 0x000E3102 File Offset: 0x000E1502
	public GameFactionType CorrespondingGameFactionType
	{
		get
		{
			return GameFactionType.AchievementProcess;
		}
	}

	// Token: 0x060020D5 RID: 8405 RVA: 0x000E3108 File Offset: 0x000E1508
	public void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameSessionInitializationCompleted && SteamManager.Initialized)
		{
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_1, 1))
			{
				SteamUserStats.SetAchievement("a01");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_6, 1))
			{
				SteamUserStats.SetAchievement("a02");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_7, 1))
			{
				SteamUserStats.SetAchievement("a03");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_2_2_3, 1))
			{
				SteamUserStats.SetAchievement("a04");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_9, 1))
			{
				SteamUserStats.SetAchievement("a05");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main2_1, 1))
			{
				SteamUserStats.SetAchievement("a06");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main2_2, 1))
			{
				SteamUserStats.SetAchievement("a07");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main2_5, 1))
			{
				SteamUserStats.SetAchievement("a08");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main3_1, 1))
			{
				SteamUserStats.SetAchievement("a09");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main3_2, 1))
			{
				SteamUserStats.SetAchievement("a10");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main4_1, 1))
			{
				SteamUserStats.SetAchievement("a11");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main4_2, 1))
			{
				SteamUserStats.SetAchievement("a12");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_1, 1))
			{
				SteamUserStats.SetAchievement("a13");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_2, 1))
			{
				SteamUserStats.SetAchievement("a14");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_3, 1))
			{
				SteamUserStats.SetAchievement("a15");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Side_4_p2, 1))
			{
				SteamUserStats.SetAchievement("a17");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Side_4_p2, 2))
			{
				SteamUserStats.SetAchievement("b17");
			}
			if (GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.FarmingFarmingFarming, 1))
			{
				SteamUserStats.SetAchievement("a18");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Side_6, 1))
			{
				SteamUserStats.SetAchievement("a19");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Side_1_p4, 1))
			{
				SteamUserStats.SetAchievement("a20");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_1, 2))
			{
				SteamUserStats.SetAchievement("b01");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_6, 2))
			{
				SteamUserStats.SetAchievement("b02");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_7, 2))
			{
				SteamUserStats.SetAchievement("b03");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_9, 2))
			{
				SteamUserStats.SetAchievement("b05");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main2_1, 2))
			{
				SteamUserStats.SetAchievement("b06");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main2_2, 2))
			{
				SteamUserStats.SetAchievement("b07");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main2_5, 2))
			{
				SteamUserStats.SetAchievement("b08");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main3_1, 2))
			{
				SteamUserStats.SetAchievement("b09");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main3_2, 2))
			{
				SteamUserStats.SetAchievement("b10");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main4_1, 2))
			{
				SteamUserStats.SetAchievement("b11");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main4_2, 2))
			{
				SteamUserStats.SetAchievement("b12");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_1, 2))
			{
				SteamUserStats.SetAchievement("b13");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_2, 2))
			{
				SteamUserStats.SetAchievement("b14");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_3, 2))
			{
				SteamUserStats.SetAchievement("b15");
			}
			if (GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.FarmingFarmingFarming, 2))
			{
				SteamUserStats.SetAchievement("b18");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Side_6, 2))
			{
				SteamUserStats.SetAchievement("b19");
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Side_1_p4, 2))
			{
				SteamUserStats.SetAchievement("b20");
			}
			if (ResourceType.BunSisterInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad01");
			}
			if (ResourceType.ChubbyLadyInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad02");
			}
			if (ResourceType.ConjurerInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad03");
			}
			if (ResourceType.DuelistInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad04");
			}
			if (ResourceType.ElementalWizardInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad05");
			}
			if (ResourceType.FashionBoyInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad06");
			}
			if (ResourceType.FireAssassinInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad07");
			}
			if (ResourceType.FirePlayerInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad08");
			}
			if (ResourceType.FireSpiritInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad09");
			}
			if (ResourceType.GoldenShamanInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad10");
			}
			if (ResourceType.IronSoliderInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad11");
			}
			if (ResourceType.NightBladeInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad12");
			}
			if (ResourceType.PaladinInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad13");
			}
			if (ResourceType.RedHornInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad14");
			}
			if (ResourceType.SnowMaidenInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad15");
			}
			if (ResourceType.TacticianInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad16");
			}
			if (ResourceType.SoulThiefInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad17");
			}
			if (ResourceType.ToughWomanInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad18");
			}
			if (ResourceType.WarriorInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad19");
			}
			if (ResourceType.YoungWarlockInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("ad20");
			}
			if (ResourceType.CubeInvitation.HasObtained())
			{
				SteamUserStats.SetAchievement("CuteSquare");
			}
			int currentEndlessLevelFromBackup = GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup();
			if (currentEndlessLevelFromBackup >= 100)
			{
				SteamUserStats.SetAchievement("c01");
			}
			if (currentEndlessLevelFromBackup >= 200)
			{
				SteamUserStats.SetAchievement("c02");
			}
			if (currentEndlessLevelFromBackup >= 300)
			{
				SteamUserStats.SetAchievement("c03");
			}
			if (currentEndlessLevelFromBackup >= 400)
			{
				SteamUserStats.SetAchievement("c04");
			}
			if (currentEndlessLevelFromBackup >= 500)
			{
				SteamUserStats.SetAchievement("c05");
			}
			if (currentEndlessLevelFromBackup >= 600)
			{
				SteamUserStats.SetAchievement("c06");
			}
			if (currentEndlessLevelFromBackup >= 700)
			{
				SteamUserStats.SetAchievement("c07");
			}
			if (currentEndlessLevelFromBackup >= 800)
			{
				SteamUserStats.SetAchievement("c08");
			}
			if (currentEndlessLevelFromBackup >= 900)
			{
				SteamUserStats.SetAchievement("c09");
			}
			if (currentEndlessLevelFromBackup >= 1000)
			{
				SteamUserStats.SetAchievement("c10");
			}
			SteamUserStats.StoreStats();
		}
		if (evt == GameWorldEvent.AdventurerTypeUnloced && SteamManager.Initialized)
		{
			UnitClass unitClass = (UnitClass)data;
			if (unitClass == UnitClass.BunSister)
			{
				SteamUserStats.SetAchievement("ad01");
			}
			if (unitClass == UnitClass.ChubbyLady)
			{
				SteamUserStats.SetAchievement("ad02");
			}
			if (unitClass == UnitClass.Conjurer)
			{
				SteamUserStats.SetAchievement("ad03");
			}
			if (unitClass == UnitClass.Duelist)
			{
				SteamUserStats.SetAchievement("ad04");
			}
			if (unitClass == UnitClass.ElementalWizard)
			{
				SteamUserStats.SetAchievement("ad05");
			}
			if (unitClass == UnitClass.FashionBoy)
			{
				SteamUserStats.SetAchievement("ad06");
			}
			if (unitClass == UnitClass.FireAssassin)
			{
				SteamUserStats.SetAchievement("ad07");
			}
			if (unitClass == UnitClass.FirePlayer)
			{
				SteamUserStats.SetAchievement("ad08");
			}
			if (unitClass == UnitClass.FireCharger)
			{
				SteamUserStats.SetAchievement("ad09");
			}
			if (unitClass == UnitClass.GoldenShaman)
			{
				SteamUserStats.SetAchievement("ad10");
			}
			if (unitClass == UnitClass.IronSolider)
			{
				SteamUserStats.SetAchievement("ad11");
			}
			if (unitClass == UnitClass.NightBlade)
			{
				SteamUserStats.SetAchievement("ad12");
			}
			if (unitClass == UnitClass.Paladin)
			{
				SteamUserStats.SetAchievement("ad13");
			}
			if (unitClass == UnitClass.RedHorn)
			{
				SteamUserStats.SetAchievement("ad14");
			}
			if (unitClass == UnitClass.SnowMaiden)
			{
				SteamUserStats.SetAchievement("ad15");
			}
			if (unitClass == UnitClass.Tactician)
			{
				SteamUserStats.SetAchievement("ad16");
			}
			if (unitClass == UnitClass.SoulThief)
			{
				SteamUserStats.SetAchievement("ad17");
			}
			if (unitClass == UnitClass.ToughWoman)
			{
				SteamUserStats.SetAchievement("ad18");
			}
			if (unitClass == UnitClass.Warrior)
			{
				SteamUserStats.SetAchievement("ad19");
			}
			if (unitClass == UnitClass.YoungWarlock)
			{
				SteamUserStats.SetAchievement("ad20");
			}
			if (unitClass == UnitClass.Cube)
			{
				SteamUserStats.SetAchievement("CuteSquare");
			}
			SteamUserStats.StoreStats();
		}
		if (evt == GameWorldEvent.AdventureCompleted && data is Adventure)
		{
			Adventure adventure = data as Adventure;
			if (adventure.Survivied == Adventure.SurvivalStatus.Surviving && SteamManager.Initialized)
			{
				bool flag = false;
				if (adventure.AdventureType == AdventureType.ImperialMausoleum && adventure.LevelNumber >= 1)
				{
					flag = true;
					if (adventure.CorrespondingDifficultyMeasurement.StarRating == 1)
					{
						SteamUserStats.SetAchievement("a16");
					}
					if (adventure.CorrespondingDifficultyMeasurement.StarRating == 2)
					{
						SteamUserStats.SetAchievement("b16");
					}
				}
				if (adventure.CorrespondingDifficultyMeasurement.StarRating == -1)
				{
					if (adventure.LevelNumber == 100 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 100)
					{
						flag = true;
						SteamUserStats.SetAchievement("c01");
					}
					if (adventure.LevelNumber == 200 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 200)
					{
						flag = true;
						SteamUserStats.SetAchievement("c02");
					}
					if (adventure.LevelNumber == 300 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 300)
					{
						flag = true;
						SteamUserStats.SetAchievement("c03");
					}
					if (adventure.LevelNumber == 400 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 400)
					{
						flag = true;
						SteamUserStats.SetAchievement("c04");
					}
					if (adventure.LevelNumber == 500 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 500)
					{
						flag = true;
						SteamUserStats.SetAchievement("c05");
					}
					if (adventure.LevelNumber == 600 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 600)
					{
						flag = true;
						SteamUserStats.SetAchievement("c06");
					}
					if (adventure.LevelNumber == 700 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 700)
					{
						flag = true;
						SteamUserStats.SetAchievement("c07");
					}
					if (adventure.LevelNumber == 800 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 800)
					{
						flag = true;
						SteamUserStats.SetAchievement("c08");
					}
					if (adventure.LevelNumber == 900 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 900)
					{
						flag = true;
						SteamUserStats.SetAchievement("c09");
					}
					if (adventure.LevelNumber == 1000 && GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup() <= 1000)
					{
						flag = true;
						SteamUserStats.SetAchievement("c10");
					}
				}
				if (flag)
				{
					SteamUserStats.StoreStats();
				}
			}
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent && SteamManager.Initialized)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			bool flag2 = false;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_4_p2)
			{
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 1)
				{
					SteamUserStats.SetAchievement("a17");
				}
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 2)
				{
					SteamUserStats.SetAchievement("b17");
				}
				flag2 = true;
			}
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_2)
			{
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 1)
				{
					SteamUserStats.SetAchievement("a18");
				}
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 2)
				{
					SteamUserStats.SetAchievement("b18");
				}
				flag2 = true;
			}
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_6)
			{
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 1)
				{
					SteamUserStats.SetAchievement("a19");
				}
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 2)
				{
					SteamUserStats.SetAchievement("b19");
				}
				flag2 = true;
			}
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_1_p4)
			{
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 1)
				{
					SteamUserStats.SetAchievement("a20");
				}
				if (GameWorld.instance.PlayerProfile.GetStarRating() == 2)
				{
					SteamUserStats.SetAchievement("b20");
				}
				flag2 = true;
			}
			if (flag2)
			{
				SteamUserStats.StoreStats();
			}
		}
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x000E3F40 File Offset: 0x000E2340
	public IEnumerable ProcessBattleEvent(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitKilled && SteamManager.Initialized)
		{
			bool flag = false;
			DifficultyLevelMeasurement correspondingDifficultyMeasurement = evt.EventTriggeringUnit.CurrentAdventure.CorrespondingDifficultyMeasurement;
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.GreenOrc)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a01");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b01");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.PurpleOrc)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a02");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b02");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.LavaBeast)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a03");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b03");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DarkKnight)
			{
				flag = true;
				SteamUserStats.SetAchievement("a04");
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.BlacksmithBrother)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a05");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b05");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Pharmacist)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a06");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b06");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DemonSkull)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a07");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b07");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.CorruptedHorn)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a08");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b08");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.GreedyMouth)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a09");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b09");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Death)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a10");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b10");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DevilMan)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a11");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b11");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.BloodyEye)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a12");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b12");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Golem)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a13");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b13");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Hydra)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a14");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b14");
				}
			}
			if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DemonDragon)
			{
				flag = true;
				if (correspondingDifficultyMeasurement.StarRating == 1)
				{
					SteamUserStats.SetAchievement("a15");
				}
				if (correspondingDifficultyMeasurement.StarRating == 2)
				{
					SteamUserStats.SetAchievement("b15");
				}
			}
			if (flag)
			{
				SteamUserStats.StoreStats();
			}
		}
		yield break;
	}

	// Token: 0x060020D7 RID: 8407 RVA: 0x000E3F64 File Offset: 0x000E2364
	public List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitKilled
		};
	}

	// Token: 0x02000D2D RID: 3373
	[CompilerGenerated]
	private sealed class <ProcessBattleEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005651 RID: 22097 RVA: 0x000E3F80 File Offset: 0x000E2380
		[DebuggerHidden]
		public <ProcessBattleEvent>c__Iterator0()
		{
		}

		// Token: 0x06005652 RID: 22098 RVA: 0x000E3F88 File Offset: 0x000E2388
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evt.EventType == AdventureEventType.UnitKilled && SteamManager.Initialized)
				{
					bool flag2 = false;
					DifficultyLevelMeasurement correspondingDifficultyMeasurement = evt.EventTriggeringUnit.CurrentAdventure.CorrespondingDifficultyMeasurement;
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.GreenOrc)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a01");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b01");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.PurpleOrc)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a02");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b02");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.LavaBeast)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a03");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b03");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DarkKnight)
					{
						flag2 = true;
						SteamUserStats.SetAchievement("a04");
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.BlacksmithBrother)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a05");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b05");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Pharmacist)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a06");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b06");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DemonSkull)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a07");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b07");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.CorruptedHorn)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a08");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b08");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.GreedyMouth)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a09");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b09");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Death)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a10");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b10");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DevilMan)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a11");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b11");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.BloodyEye)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a12");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b12");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Golem)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a13");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b13");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.Hydra)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a14");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b14");
						}
					}
					if (evt.EventTriggeringUnit.GetUnitType() == UnitClass.DemonDragon)
					{
						flag2 = true;
						if (correspondingDifficultyMeasurement.StarRating == 1)
						{
							SteamUserStats.SetAchievement("a15");
						}
						if (correspondingDifficultyMeasurement.StarRating == 2)
						{
							SteamUserStats.SetAchievement("b15");
						}
					}
					if (flag2)
					{
						SteamUserStats.StoreStats();
					}
				}
			}
			return false;
		}

		// Token: 0x17001236 RID: 4662
		// (get) Token: 0x06005653 RID: 22099 RVA: 0x000E4420 File Offset: 0x000E2820
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001237 RID: 4663
		// (get) Token: 0x06005654 RID: 22100 RVA: 0x000E4428 File Offset: 0x000E2828
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005655 RID: 22101 RVA: 0x000E4430 File Offset: 0x000E2830
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005656 RID: 22102 RVA: 0x000E4432 File Offset: 0x000E2832
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005657 RID: 22103 RVA: 0x000E4439 File Offset: 0x000E2839
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005658 RID: 22104 RVA: 0x000E4444 File Offset: 0x000E2844
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AchievementProcessor.<ProcessBattleEvent>c__Iterator0 <ProcessBattleEvent>c__Iterator = new AchievementProcessor.<ProcessBattleEvent>c__Iterator0();
			<ProcessBattleEvent>c__Iterator.evt = evt;
			return <ProcessBattleEvent>c__Iterator;
		}

		// Token: 0x040044D1 RID: 17617
		internal BroadcastEvent evt;

		// Token: 0x040044D2 RID: 17618
		internal object $current;

		// Token: 0x040044D3 RID: 17619
		internal bool $disposing;

		// Token: 0x040044D4 RID: 17620
		internal int $PC;
	}
}
