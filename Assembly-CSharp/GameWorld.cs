using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x020004C0 RID: 1216
public class GameWorld : MonoBehaviour
{
	// Token: 0x060023DD RID: 9181 RVA: 0x00103275 File Offset: 0x00101675
	public GameWorld()
	{
	}

	// Token: 0x060023DE RID: 9182 RVA: 0x0010327D File Offset: 0x0010167D
	public Adventure GetCurrentAdventure()
	{
		return this.CurrentAdventure;
	}

	// Token: 0x060023DF RID: 9183 RVA: 0x00103285 File Offset: 0x00101685
	public bool AdventureInProgress()
	{
		return this.CurrentAdventure != null && this._currentAdventureInProgress;
	}

	// Token: 0x060023E0 RID: 9184 RVA: 0x0010329C File Offset: 0x0010169C
	public List<ISpecialEffectDataLoad> ShowAdventureDungeonEffects(List<string> selectedAdventuerers, AdventureType type, List<ResourceType> consumables)
	{
		AdventureStartParameter startAdventureParamter = new AdventureStartParameter(type, selectedAdventuerers, consumables);
		List<AdventureResolverBase> source = (from r in LevelConfigurationExtension.LevelResolvers
		where r.CanBeResolved(startAdventureParamter)
		select r).ToList<AdventureResolverBase>();
		if (source.Any<AdventureResolverBase>())
		{
			return source.First<AdventureResolverBase>().GetDungeonSpecialEffects(startAdventureParamter);
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060023E1 RID: 9185 RVA: 0x001032FC File Offset: 0x001016FC
	public void StartAdventure(List<string> selectedAdventuerers, AdventureType type, List<ResourceType> consumables, bool goForwardLevel, List<StrategyRule> autoStrategyRules = null)
	{
		if (this.AdventureInProgress())
		{
			this.CurrentAdventure.CurrentEncounter = null;
			this._currentAdventureInProgress = false;
		}
		List<ISpecialEffectDataLoad> source = this.ShowAdventureDungeonEffects(selectedAdventuerers, type, consumables);
		RestrictedAccessData restrictedAccessData = source.OfType<RestrictedAccessData>().FirstOrDefault<RestrictedAccessData>();
		if (restrictedAccessData != null)
		{
			selectedAdventuerers = selectedAdventuerers.Take(restrictedAccessData.NumberOfAllowed).ToList<string>();
		}
		AdventureStartParameter startAdventureParamter = new AdventureStartParameter(type, selectedAdventuerers, consumables);
		List<AdventureResolverBase> source2 = (from r in LevelConfigurationExtension.LevelResolvers
		where r.CanBeResolved(startAdventureParamter)
		select r).ToList<AdventureResolverBase>();
		if (source2.Any<AdventureResolverBase>())
		{
			this.CurrentAdventure = source2.First<AdventureResolverBase>().Resolve(startAdventureParamter);
			this.CurrentAdventure.AutoTacticRules = autoStrategyRules;
			this.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureInitialising, new AdventureInitialisingEvent
			{
				GameWorld = this,
				Adventure = this.CurrentAdventure
			});
			if (TestingProcessor.InTesting)
			{
			}
			this.CurrentAdventure.PlayerEffects.AddRange(TeamSetBase.GetAdventureTeamBonus((from ad in this.CurrentAdventure.Adventurers
			select ad.AdventurerProfile).ToList<AdventurerProfile>()));
			this.CurrentAdventure.GoForwardLevel = goForwardLevel;
			return;
		}
		throw new Exception("There is no avaliable resolver!");
	}

	// Token: 0x060023E2 RID: 9186 RVA: 0x00103450 File Offset: 0x00101850
	public IEnumerable BroadCastAdventureEvent(BroadcastEvent evt)
	{
		Adventure adventure = this.CurrentAdventure;
		if (adventure.FactionProcessorsDictionary.ContainsKey(evt.EventType))
		{
			foreach (IFactionProcessor factionProcessor in adventure.FactionProcessorsDictionary[evt.EventType])
			{
				IEnumerator enumerator2 = factionProcessor.ProcessBattleEvent(evt).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _ = enumerator2.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		if (adventure.QuestRequirementsDictionary.ContainsKey(evt.EventType))
		{
			foreach (QuestRequirementBase questRequirementBase in adventure.QuestRequirementsDictionary[evt.EventType])
			{
				IEnumerator enumerator4 = questRequirementBase.ProcessAdventureEvent(evt).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _2 = enumerator4.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		if (evt.EventType == AdventureEventType.AdventureInitialized || evt.EventType == AdventureEventType.AdventurersWalking)
		{
			if (evt.EventType == AdventureEventType.AdventureInitialized)
			{
				IEnumerator enumerator5 = adventure.OnAdventureInitialized(adventure).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _3 = enumerator5.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			if (evt.EventType == AdventureEventType.AdventurersWalking)
			{
				IEnumerator enumerator6 = adventure.OnAdventuresWalking(evt.AdditionalData as List<AdventurerBattleUnit>).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _4 = enumerator6.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		else
		{
			if (adventure.PlayerEffectsDictionary.ContainsKey(evt.EventType))
			{
				foreach (ISpecialEffectDataLoad effectProcessor in adventure.PlayerEffectsDictionary[evt.EventType])
				{
					if (effectProcessor.GetSpecialEffectType().HasProcessor())
					{
						IEnumerator enumerator8 = effectProcessor.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectProcess(effectProcessor, evt).GetEnumerator();
						try
						{
							while (enumerator8.MoveNext())
							{
								object _5 = enumerator8.Current;
								yield return _5;
							}
						}
						finally
						{
							IDisposable disposable5;
							if ((disposable5 = (enumerator8 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
				}
			}
			if (adventure.DungeonEffectsDictionary.ContainsKey(evt.EventType))
			{
				foreach (ISpecialEffectDataLoad effectProcessor2 in adventure.DungeonEffectsDictionary[evt.EventType])
				{
					if (effectProcessor2.GetSpecialEffectType().HasProcessor())
					{
						IEnumerator enumerator10 = effectProcessor2.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectProcess(effectProcessor2, evt).GetEnumerator();
						try
						{
							while (enumerator10.MoveNext())
							{
								object _6 = enumerator10.Current;
								yield return _6;
							}
						}
						finally
						{
							IDisposable disposable6;
							if ((disposable6 = (enumerator10 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
				}
			}
			if (adventure.CurrentEncounter != null)
			{
				foreach (IBattleUnit currentEncounterPlayerUnit in adventure.CurrentEncounter.PlayerUnits)
				{
					AdventureEvent adventureEvent = new AdventureEvent(evt.EventTriggeringUnit, currentEncounterPlayerUnit, evt.EventType, evt.AdditionalData);
					IEnumerator enumerator12 = GameWorld.BattleUnitProcessAdventureEvent(adventureEvent).GetEnumerator();
					try
					{
						while (enumerator12.MoveNext())
						{
							object _7 = enumerator12.Current;
							yield return _7;
						}
					}
					finally
					{
						IDisposable disposable7;
						if ((disposable7 = (enumerator12 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				foreach (IBattleUnit currentEncounterEnemyUnit in adventure.CurrentEncounter.EnemyUnits)
				{
					AdventureEvent adventureEvent2 = new AdventureEvent(evt.EventTriggeringUnit, currentEncounterEnemyUnit, evt.EventType, evt.AdditionalData);
					IEnumerator enumerator14 = GameWorld.BattleUnitProcessAdventureEvent(adventureEvent2).GetEnumerator();
					try
					{
						while (enumerator14.MoveNext())
						{
							object _8 = enumerator14.Current;
							yield return _8;
						}
					}
					finally
					{
						IDisposable disposable8;
						if ((disposable8 = (enumerator14 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
				}
			}
			else
			{
				foreach (AdventurerBattleUnit adventurerBattleUnit in adventure.Adventurers)
				{
					AdventureEvent adventureEvent3 = new AdventureEvent(evt.EventTriggeringUnit, adventurerBattleUnit, evt.EventType, evt.AdditionalData);
					IEnumerator enumerator16 = GameWorld.BattleUnitProcessAdventureEvent(adventureEvent3).GetEnumerator();
					try
					{
						while (enumerator16.MoveNext())
						{
							object _9 = enumerator16.Current;
							yield return _9;
						}
					}
					finally
					{
						IDisposable disposable9;
						if ((disposable9 = (enumerator16 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
			}
		}
		this._evtCounter--;
		yield break;
	}

	// Token: 0x060023E3 RID: 9187 RVA: 0x0010347C File Offset: 0x0010187C
	private static IEnumerable BattleUnitProcessAdventureEvent(AdventureEvent evt)
	{
		if (evt.EventTriggerUnit == evt.EventListener)
		{
			IEnumerator enumerator = evt.EventListener.SelfEventCallback(evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			foreach (BattleEffectBase battleEffect in evt.EventListener.BattleEffects.ToList<BattleEffectBase>())
			{
				IEnumerator enumerator3 = battleEffect.CollectTurnEvent(evt.EventType).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		Adventure adventure = evt.EventListener.CurrentAdventure;
		if (adventure.BattleUnitSpecialEffectsDictionary.ContainsKey(evt.EventListener.GetId()))
		{
			Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> adventureEffects = adventure.BattleUnitSpecialEffectsDictionary[evt.EventListener.GetId()];
			if (adventureEffects.ContainsKey(evt.EventType))
			{
				foreach (ISpecialEffectDataLoad eventListenerSpecialEffect in adventureEffects[evt.EventType])
				{
					if (eventListenerSpecialEffect.GetSpecialEffectType().HasProcessor())
					{
						if (evt.EventListener.IsAliveInBattle())
						{
							IEnumerator enumerator5 = eventListenerSpecialEffect.GetSpecialEffectType().GetSpecialProcessor().AsActiveUnitProcess(eventListenerSpecialEffect, evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
							try
							{
								while (enumerator5.MoveNext())
								{
									object _3 = enumerator5.Current;
									yield return _3;
								}
							}
							finally
							{
								IDisposable disposable3;
								if ((disposable3 = (enumerator5 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						else
						{
							IEnumerator enumerator6 = eventListenerSpecialEffect.GetSpecialEffectType().GetSpecialProcessor().AsInactiveUnitProcess(eventListenerSpecialEffect, evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
							try
							{
								while (enumerator6.MoveNext())
								{
									object _4 = enumerator6.Current;
									yield return _4;
								}
							}
							finally
							{
								IDisposable disposable4;
								if ((disposable4 = (enumerator6 as IDisposable)) != null)
								{
									disposable4.Dispose();
								}
							}
						}
					}
				}
			}
		}
		if (adventure.BattleEffectsDictionary.ContainsKey(evt.EventListener.GetId()))
		{
			Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> adventurerEffects = adventure.BattleEffectsDictionary[evt.EventListener.GetId()];
			if (adventurerEffects.ContainsKey(evt.EventType))
			{
				List<BattleEffectBase> effects = (from f in adventurerEffects[evt.EventType]
				select f.Value).ToList<BattleEffectBase>();
				foreach (BattleEffectBase battleEffect2 in effects)
				{
					IEnumerator enumerator8 = battleEffect2.Process(evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
					try
					{
						while (enumerator8.MoveNext())
						{
							object _5 = enumerator8.Current;
							yield return _5;
						}
					}
					finally
					{
						IDisposable disposable5;
						if ((disposable5 = (enumerator8 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
			}
		}
		if (adventure.AttributeProcessDictionary.ContainsKey(evt.EventType))
		{
			foreach (AttributeProcessBase processor in adventure.AttributeProcessDictionary[evt.EventType])
			{
				if (evt.EventListener.IsAliveInBattle())
				{
					IEnumerator enumerator10 = processor.ActiveListenerProcess(evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
					try
					{
						while (enumerator10.MoveNext())
						{
							object _6 = enumerator10.Current;
							yield return _6;
						}
					}
					finally
					{
						IDisposable disposable6;
						if ((disposable6 = (enumerator10 as IDisposable)) != null)
						{
							disposable6.Dispose();
						}
					}
				}
				else
				{
					IEnumerator enumerator11 = processor.InactiveListenerProcess(evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
					try
					{
						while (enumerator11.MoveNext())
						{
							object _7 = enumerator11.Current;
							yield return _7;
						}
					}
					finally
					{
						IDisposable disposable7;
						if ((disposable7 = (enumerator11 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
			}
		}
		if (evt.EventTriggerUnit == evt.EventListener && (evt.EventType == AdventureEventType.UnitEntersTurn || evt.EventType == AdventureEventType.UnitCompletesTurn))
		{
			foreach (BattleEffectBase expiredEffect in SkillUtilities.GetExpiredEffects(evt.EventTriggerUnit.BattleEffects))
			{
				IEnumerator enumerator13 = evt.EventTriggerUnit.LooseSkillEffect(expiredEffect, EffectWearsOffType.Expiration).GetEnumerator();
				try
				{
					while (enumerator13.MoveNext())
					{
						object _8 = enumerator13.Current;
						yield return _8;
					}
				}
				finally
				{
					IDisposable disposable8;
					if ((disposable8 = (enumerator13 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
			}
		}
		if (adventure.SkillsDictionary.ContainsKey(evt.EventListener.GetId()))
		{
			Dictionary<AdventureEventType, List<AdventureUnitSkill>> unitSkills = adventure.SkillsDictionary[evt.EventListener.GetId()];
			if (unitSkills.ContainsKey(evt.EventType))
			{
				foreach (AdventureUnitSkill adventureUnitSkill in unitSkills[evt.EventType])
				{
					SkillLogicBase logic = adventureUnitSkill.GetSkillLogic();
					IEnumerator enumerator15 = logic.ProcessEvent(adventureUnitSkill, evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
					try
					{
						while (enumerator15.MoveNext())
						{
							object _9 = enumerator15.Current;
							yield return _9;
						}
					}
					finally
					{
						IDisposable disposable9;
						if ((disposable9 = (enumerator15 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060023E4 RID: 9188 RVA: 0x0010349F File Offset: 0x0010189F
	private void Awake()
	{
		if (GameWorld.instance == null)
		{
			this.PlayerProfile = null;
			GameWorld.instance = this;
		}
		else if (GameWorld.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060023E5 RID: 9189 RVA: 0x001034DE File Offset: 0x001018DE
	private void Start()
	{
		SpeedHackDetector.StartDetection(new UnityAction(this.OnSpeedHackDetected));
	}

	// Token: 0x060023E6 RID: 9190 RVA: 0x001034F1 File Offset: 0x001018F1
	private void OnSpeedHackDetected()
	{
		Application.Quit();
	}

	// Token: 0x060023E7 RID: 9191 RVA: 0x001034F8 File Offset: 0x001018F8
	private void Update()
	{
		try
		{
			if (!this.HasWorkload())
			{
				this.PlayerProfile.Process();
			}
			if (this._asyncWorkload != null && !this.HasWorkload())
			{
				base.StartCoroutine(this.ProcessWorkload());
			}
			if (this.CurrentAdventure != null && !this._currentAdventureInProgress)
			{
				base.StartCoroutine(this.RunAdventure());
				if (this.CurrentAdventure.CurrentEncounter != null)
				{
					base.StartCoroutine(this.CurrentAdventure.CurrentEncounter.PerUpdateProcess(Time.deltaTime).GetEnumerator());
				}
			}
			if (this.CurrentAdventure != null)
			{
				if (this.CurrentAdventure.CurrentEncounter != null)
				{
					base.StartCoroutine(this.CurrentAdventure.CurrentEncounter.PerUpdateProcess(Time.deltaTime).GetEnumerator());
				}
				if (this.CurrentAdventure.TimeLeft() != null && this.CurrentAdventure.Survivied == Adventure.SurvivalStatus.Surviving && !this.CurrentAdventure.Encounters.Last<IEncounter>().IsCompleted && this.CurrentAdventure.InBattle && this.CurrentAdventure.TimeLeft() <= 0.0)
				{
					this.CurrentAdventure.Survivied = Adventure.SurvivalStatus.Lost;
				}
				if (this.CurrentAdventure.CurrentEncounter != null && this.CurrentAdventure.CurrentEncounter is BattleEncounter)
				{
					BattleEncounter battleEncounter = this.CurrentAdventure.CurrentEncounter as BattleEncounter;
					if (battleEncounter.EncounterTimer == 0.0)
					{
						battleEncounter.EncounterTimer += (double)Time.deltaTime;
						base.StartCoroutine(battleEncounter.TryAutoRun().GetEnumerator());
					}
					else
					{
						int num = (int)battleEncounter.EncounterTimer;
						battleEncounter.EncounterTimer += (double)Time.deltaTime;
						int num2 = (int)battleEncounter.EncounterTimer;
						if (num2 > num)
						{
							base.StartCoroutine(battleEncounter.TryAutoRun().GetEnumerator());
						}
					}
				}
			}
		}
		catch (Exception exception)
		{
			SteamExceptionHandle.Handle(exception, 0u);
		}
	}

	// Token: 0x060023E8 RID: 9192 RVA: 0x00103744 File Offset: 0x00101B44
	public void RunCoroutine(IEnumerator run)
	{
		base.StartCoroutine(run);
	}

	// Token: 0x060023E9 RID: 9193 RVA: 0x0010374E File Offset: 0x00101B4E
	public bool HasWorkload()
	{
		return this._workloadInProgress;
	}

	// Token: 0x060023EA RID: 9194 RVA: 0x00103758 File Offset: 0x00101B58
	private IEnumerator ProcessWorkload()
	{
		this._workloadInProgress = true;
		IEnumerator enumerator = this._asyncWorkload.Run().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object _ = enumerator.Current;
				yield return _;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		this._asyncWorkload = null;
		this._workloadInProgress = false;
		yield break;
	}

	// Token: 0x060023EB RID: 9195 RVA: 0x00103774 File Offset: 0x00101B74
	private IEnumerator RunAdventure()
	{
		try
		{
			if (this.CurrentAdventure == null)
			{
				yield break;
			}
			this._currentAdventureInProgress = true;
			this.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureInitialized, this.CurrentAdventure);
		}
		catch (Exception exception)
		{
			SteamExceptionHandle.Handle(exception, 0u);
		}
		IEnumerator emrt = this.CurrentAdventure.Run().GetEnumerator();
		bool more = true;
		while (more)
		{
			bool hasError = false;
			while (this.HasWorkload())
			{
				yield return null;
			}
			try
			{
				more = emrt.MoveNext();
			}
			catch (Exception exception2)
			{
				hasError = true;
				more = false;
				SteamExceptionHandle.Handle(exception2, 0u);
			}
			if (!hasError)
			{
				yield return emrt.Current;
			}
		}
		this.CurrentAdventure = null;
		this._currentAdventureInProgress = false;
		yield break;
	}

	// Token: 0x060023EC RID: 9196 RVA: 0x0010378F File Offset: 0x00101B8F
	// Note: this type is marked as 'beforefieldinit'.
	static GameWorld()
	{
	}

	// Token: 0x060023ED RID: 9197 RVA: 0x00103791 File Offset: 0x00101B91
	[CompilerGenerated]
	private static AdventurerProfile <StartAdventure>m__0(AdventurerBattleUnit ad)
	{
		return ad.AdventurerProfile;
	}

	// Token: 0x04001F01 RID: 7937
	public static GameWorld instance;

	// Token: 0x04001F02 RID: 7938
	public PlayerProfile PlayerProfile;

	// Token: 0x04001F03 RID: 7939
	private Adventure CurrentAdventure;

	// Token: 0x04001F04 RID: 7940
	private bool _currentAdventureInProgress;

	// Token: 0x04001F05 RID: 7941
	private IGameWorldWorkload _asyncWorkload;

	// Token: 0x04001F06 RID: 7942
	private bool _workloadInProgress;

	// Token: 0x04001F07 RID: 7943
	private int _evtCounter;

	// Token: 0x04001F08 RID: 7944
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, AdventurerProfile> <>f__am$cache0;

	// Token: 0x02000D89 RID: 3465
	[CompilerGenerated]
	private sealed class <ShowAdventureDungeonEffects>c__AnonStorey4
	{
		// Token: 0x06005802 RID: 22530 RVA: 0x00103799 File Offset: 0x00101B99
		public <ShowAdventureDungeonEffects>c__AnonStorey4()
		{
		}

		// Token: 0x06005803 RID: 22531 RVA: 0x001037A1 File Offset: 0x00101BA1
		internal bool <>m__0(AdventureResolverBase r)
		{
			return r.CanBeResolved(this.startAdventureParamter);
		}

		// Token: 0x040047BB RID: 18363
		internal AdventureStartParameter startAdventureParamter;
	}

	// Token: 0x02000D8A RID: 3466
	[CompilerGenerated]
	private sealed class <StartAdventure>c__AnonStorey5
	{
		// Token: 0x06005804 RID: 22532 RVA: 0x001037AF File Offset: 0x00101BAF
		public <StartAdventure>c__AnonStorey5()
		{
		}

		// Token: 0x06005805 RID: 22533 RVA: 0x001037B7 File Offset: 0x00101BB7
		internal bool <>m__0(AdventureResolverBase r)
		{
			return r.CanBeResolved(this.startAdventureParamter);
		}

		// Token: 0x040047BC RID: 18364
		internal AdventureStartParameter startAdventureParamter;
	}

	// Token: 0x02000D8B RID: 3467
	[CompilerGenerated]
	private sealed class <BroadCastAdventureEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005806 RID: 22534 RVA: 0x001037C5 File Offset: 0x00101BC5
		[DebuggerHidden]
		public <BroadCastAdventureEvent>c__Iterator0()
		{
		}

		// Token: 0x06005807 RID: 22535 RVA: 0x001037D0 File Offset: 0x00101BD0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				adventure = this.CurrentAdventure;
				if (!adventure.FactionProcessorsDictionary.ContainsKey(evt.EventType))
				{
					goto IL_18B;
				}
				enumerator = adventure.FactionProcessorsDictionary[evt.EventType].GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_5:
				try
				{
					switch (num)
					{
					case 2u:
						Block_31:
						try
						{
							switch (num)
							{
							}
							if (enumerator4.MoveNext())
							{
								_2 = enumerator4.Current;
								this.$current = _2;
								if (!this.$disposing)
								{
									this.$PC = 2;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable2 = (enumerator4 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator3.MoveNext())
					{
						questRequirementBase = enumerator3.Current;
						enumerator4 = questRequirementBase.ProcessAdventureEvent(evt).GetEnumerator();
						num = 4294967293u;
						goto Block_31;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				goto IL_2C2;
			case 3u:
				Block_8:
				try
				{
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						_3 = enumerator5.Current;
						this.$current = _3;
						if (!this.$disposing)
						{
							this.$PC = 3;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable3 = (enumerator5 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				goto IL_394;
			case 4u:
				Block_10:
				try
				{
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						_4 = enumerator6.Current;
						this.$current = _4;
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable4 = (enumerator6 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				goto IL_450;
			case 5u:
				Block_12:
				try
				{
					switch (num)
					{
					case 5u:
						Block_55:
						try
						{
							switch (num)
							{
							}
							if (enumerator8.MoveNext())
							{
								_5 = enumerator8.Current;
								this.$current = _5;
								if (!this.$disposing)
								{
									this.$PC = 5;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable5 = (enumerator8 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						break;
					}
					while (enumerator7.MoveNext())
					{
						effectProcessor = enumerator7.Current;
						if (effectProcessor.GetSpecialEffectType().HasProcessor())
						{
							enumerator8 = effectProcessor.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectProcess(effectProcessor, evt).GetEnumerator();
							num = 4294967293u;
							goto Block_55;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator7).Dispose();
					}
				}
				goto IL_5B1;
			case 6u:
				Block_14:
				try
				{
					switch (num)
					{
					case 6u:
						Block_67:
						try
						{
							switch (num)
							{
							}
							if (enumerator10.MoveNext())
							{
								_6 = enumerator10.Current;
								this.$current = _6;
								if (!this.$disposing)
								{
									this.$PC = 6;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable6 = (enumerator10 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
						break;
					}
					while (enumerator9.MoveNext())
					{
						effectProcessor2 = enumerator9.Current;
						if (effectProcessor2.GetSpecialEffectType().HasProcessor())
						{
							enumerator10 = effectProcessor2.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectProcess(effectProcessor2, evt).GetEnumerator();
							num = 4294967293u;
							goto Block_67;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator9).Dispose();
					}
				}
				goto IL_70D;
			case 7u:
				Block_16:
				try
				{
					switch (num)
					{
					case 7u:
						Block_78:
						try
						{
							switch (num)
							{
							}
							if (enumerator12.MoveNext())
							{
								_7 = enumerator12.Current;
								this.$current = _7;
								if (!this.$disposing)
								{
									this.$PC = 7;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable7 = (enumerator12 as IDisposable)) != null)
								{
									disposable7.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator11.MoveNext())
					{
						currentEncounterPlayerUnit = enumerator11.Current;
						adventureEvent = new AdventureEvent(evt.EventTriggeringUnit, currentEncounterPlayerUnit, evt.EventType, evt.AdditionalData);
						enumerator12 = GameWorld.BattleUnitProcessAdventureEvent(adventureEvent).GetEnumerator();
						num = 4294967293u;
						goto Block_78;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator11).Dispose();
					}
				}
				enumerator13 = adventure.CurrentEncounter.EnemyUnits.GetEnumerator();
				num = 4294967293u;
				goto Block_17;
			case 8u:
				goto IL_873;
			case 9u:
				Block_18:
				try
				{
					switch (num)
					{
					case 9u:
						Block_100:
						try
						{
							switch (num)
							{
							}
							if (enumerator16.MoveNext())
							{
								_9 = enumerator16.Current;
								this.$current = _9;
								if (!this.$disposing)
								{
									this.$PC = 9;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable9 = (enumerator16 as IDisposable)) != null)
								{
									disposable9.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator15.MoveNext())
					{
						adventurerBattleUnit = enumerator15.Current;
						adventureEvent3 = new AdventureEvent(evt.EventTriggeringUnit, adventurerBattleUnit, evt.EventType, evt.AdditionalData);
						enumerator16 = GameWorld.BattleUnitProcessAdventureEvent(adventureEvent3).GetEnumerator();
						num = 4294967293u;
						goto Block_100;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator15).Dispose();
					}
				}
				goto IL_AC8;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_20:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
							this.$current = _;
							if (!this.$disposing)
							{
								this.$PC = 1;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					factionProcessor = enumerator.Current;
					enumerator2 = factionProcessor.ProcessBattleEvent(evt).GetEnumerator();
					num = 4294967293u;
					goto Block_20;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_18B:
			if (adventure.QuestRequirementsDictionary.ContainsKey(evt.EventType))
			{
				enumerator3 = adventure.QuestRequirementsDictionary[evt.EventType].GetEnumerator();
				num = 4294967293u;
				goto Block_5;
			}
			IL_2C2:
			if (evt.EventType == AdventureEventType.AdventureInitialized || evt.EventType == AdventureEventType.AdventurersWalking)
			{
				if (evt.EventType == AdventureEventType.AdventureInitialized)
				{
					enumerator5 = adventure.OnAdventureInitialized(adventure).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			else
			{
				if (adventure.PlayerEffectsDictionary.ContainsKey(evt.EventType))
				{
					enumerator7 = adventure.PlayerEffectsDictionary[evt.EventType].GetEnumerator();
					num = 4294967293u;
					goto Block_12;
				}
				goto IL_5B1;
			}
			IL_394:
			if (evt.EventType == AdventureEventType.AdventurersWalking)
			{
				enumerator6 = adventure.OnAdventuresWalking(evt.AdditionalData as List<AdventurerBattleUnit>).GetEnumerator();
				num = 4294967293u;
				goto Block_10;
			}
			IL_450:
			goto IL_AC8;
			IL_5B1:
			if (adventure.DungeonEffectsDictionary.ContainsKey(evt.EventType))
			{
				enumerator9 = adventure.DungeonEffectsDictionary[evt.EventType].GetEnumerator();
				num = 4294967293u;
				goto Block_14;
			}
			IL_70D:
			if (adventure.CurrentEncounter != null)
			{
				enumerator11 = adventure.CurrentEncounter.PlayerUnits.GetEnumerator();
				num = 4294967293u;
				goto Block_16;
			}
			enumerator15 = adventure.Adventurers.GetEnumerator();
			num = 4294967293u;
			goto Block_18;
			Block_17:
			try
			{
				IL_873:
				switch (num)
				{
				case 8u:
					Block_89:
					try
					{
						switch (num)
						{
						}
						if (enumerator14.MoveNext())
						{
							_8 = enumerator14.Current;
							this.$current = _8;
							if (!this.$disposing)
							{
								this.$PC = 8;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable8 = (enumerator14 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator13.MoveNext())
				{
					currentEncounterEnemyUnit = enumerator13.Current;
					adventureEvent2 = new AdventureEvent(evt.EventTriggeringUnit, currentEncounterEnemyUnit, evt.EventType, evt.AdditionalData);
					enumerator14 = GameWorld.BattleUnitProcessAdventureEvent(adventureEvent2).GetEnumerator();
					num = 4294967293u;
					goto Block_89;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator13).Dispose();
				}
			}
			IL_AC8:
			this._evtCounter--;
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001276 RID: 4726
		// (get) Token: 0x06005808 RID: 22536 RVA: 0x00104448 File Offset: 0x00102848
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001277 RID: 4727
		// (get) Token: 0x06005809 RID: 22537 RVA: 0x00104450 File Offset: 0x00102850
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600580A RID: 22538 RVA: 0x00104458 File Offset: 0x00102858
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable5 = (enumerator8 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator7).Dispose();
				}
				break;
			case 6u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable6 = (enumerator10 as IDisposable)) != null)
						{
							disposable6.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator9).Dispose();
				}
				break;
			case 7u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable7 = (enumerator12 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator11).Dispose();
				}
				break;
			case 8u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable8 = (enumerator14 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator13).Dispose();
				}
				break;
			case 9u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable9 = (enumerator16 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator15).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600580B RID: 22539 RVA: 0x001047B4 File Offset: 0x00102BB4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600580C RID: 22540 RVA: 0x001047BB File Offset: 0x00102BBB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600580D RID: 22541 RVA: 0x001047C4 File Offset: 0x00102BC4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GameWorld.<BroadCastAdventureEvent>c__Iterator0 <BroadCastAdventureEvent>c__Iterator = new GameWorld.<BroadCastAdventureEvent>c__Iterator0();
			<BroadCastAdventureEvent>c__Iterator.$this = this;
			<BroadCastAdventureEvent>c__Iterator.evt = evt;
			return <BroadCastAdventureEvent>c__Iterator;
		}

		// Token: 0x040047BD RID: 18365
		internal Adventure <adventure>__0;

		// Token: 0x040047BE RID: 18366
		internal BroadcastEvent evt;

		// Token: 0x040047BF RID: 18367
		internal List<IFactionProcessor>.Enumerator $locvar0;

		// Token: 0x040047C0 RID: 18368
		internal IFactionProcessor <factionProcessor>__1;

		// Token: 0x040047C1 RID: 18369
		internal IEnumerator $locvar1;

		// Token: 0x040047C2 RID: 18370
		internal object <_>__2;

		// Token: 0x040047C3 RID: 18371
		internal IDisposable $locvar2;

		// Token: 0x040047C4 RID: 18372
		internal List<QuestRequirementBase>.Enumerator $locvar3;

		// Token: 0x040047C5 RID: 18373
		internal QuestRequirementBase <questRequirementBase>__3;

		// Token: 0x040047C6 RID: 18374
		internal IEnumerator $locvar4;

		// Token: 0x040047C7 RID: 18375
		internal object <_>__4;

		// Token: 0x040047C8 RID: 18376
		internal IDisposable $locvar5;

		// Token: 0x040047C9 RID: 18377
		internal IEnumerator $locvar6;

		// Token: 0x040047CA RID: 18378
		internal object <_>__5;

		// Token: 0x040047CB RID: 18379
		internal IDisposable $locvar7;

		// Token: 0x040047CC RID: 18380
		internal IEnumerator $locvar8;

		// Token: 0x040047CD RID: 18381
		internal object <_>__6;

		// Token: 0x040047CE RID: 18382
		internal IDisposable $locvar9;

		// Token: 0x040047CF RID: 18383
		internal List<ISpecialEffectDataLoad>.Enumerator $locvarA;

		// Token: 0x040047D0 RID: 18384
		internal ISpecialEffectDataLoad <effectProcessor>__7;

		// Token: 0x040047D1 RID: 18385
		internal IEnumerator $locvarB;

		// Token: 0x040047D2 RID: 18386
		internal object <_>__8;

		// Token: 0x040047D3 RID: 18387
		internal IDisposable $locvarC;

		// Token: 0x040047D4 RID: 18388
		internal List<ISpecialEffectDataLoad>.Enumerator $locvarD;

		// Token: 0x040047D5 RID: 18389
		internal ISpecialEffectDataLoad <effectProcessor>__9;

		// Token: 0x040047D6 RID: 18390
		internal IEnumerator $locvarE;

		// Token: 0x040047D7 RID: 18391
		internal object <_>__10;

		// Token: 0x040047D8 RID: 18392
		internal IDisposable $locvarF;

		// Token: 0x040047D9 RID: 18393
		internal List<IBattleUnit>.Enumerator $locvar10;

		// Token: 0x040047DA RID: 18394
		internal IBattleUnit <currentEncounterPlayerUnit>__11;

		// Token: 0x040047DB RID: 18395
		internal AdventureEvent <adventureEvent>__12;

		// Token: 0x040047DC RID: 18396
		internal IEnumerator $locvar11;

		// Token: 0x040047DD RID: 18397
		internal object <_>__13;

		// Token: 0x040047DE RID: 18398
		internal IDisposable $locvar12;

		// Token: 0x040047DF RID: 18399
		internal List<IBattleUnit>.Enumerator $locvar13;

		// Token: 0x040047E0 RID: 18400
		internal IBattleUnit <currentEncounterEnemyUnit>__14;

		// Token: 0x040047E1 RID: 18401
		internal AdventureEvent <adventureEvent>__15;

		// Token: 0x040047E2 RID: 18402
		internal IEnumerator $locvar14;

		// Token: 0x040047E3 RID: 18403
		internal object <_>__16;

		// Token: 0x040047E4 RID: 18404
		internal IDisposable $locvar15;

		// Token: 0x040047E5 RID: 18405
		internal List<AdventurerBattleUnit>.Enumerator $locvar16;

		// Token: 0x040047E6 RID: 18406
		internal AdventurerBattleUnit <adventurerBattleUnit>__17;

		// Token: 0x040047E7 RID: 18407
		internal AdventureEvent <adventureEvent>__18;

		// Token: 0x040047E8 RID: 18408
		internal IEnumerator $locvar17;

		// Token: 0x040047E9 RID: 18409
		internal object <_>__19;

		// Token: 0x040047EA RID: 18410
		internal IDisposable $locvar18;

		// Token: 0x040047EB RID: 18411
		internal GameWorld $this;

		// Token: 0x040047EC RID: 18412
		internal object $current;

		// Token: 0x040047ED RID: 18413
		internal bool $disposing;

		// Token: 0x040047EE RID: 18414
		internal int $PC;
	}

	// Token: 0x02000D8C RID: 3468
	[CompilerGenerated]
	private sealed class <BattleUnitProcessAdventureEvent>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600580E RID: 22542 RVA: 0x00104804 File Offset: 0x00102C04
		[DebuggerHidden]
		public <BattleUnitProcessAdventureEvent>c__Iterator1()
		{
		}

		// Token: 0x0600580F RID: 22543 RVA: 0x0010480C File Offset: 0x00102C0C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventTriggerUnit != evt.EventListener)
				{
					goto IL_235;
				}
				enumerator = evt.EventListener.SelfEventCallback(evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_142;
			case 3u:
			case 4u:
				Block_7:
				try
				{
					switch (num)
					{
					case 3u:
						Block_40:
						try
						{
							switch (num)
							{
							}
							if (enumerator5.MoveNext())
							{
								_3 = enumerator5.Current;
								this.$current = _3;
								if (!this.$disposing)
								{
									this.$PC = 3;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable3 = (enumerator5 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						break;
					case 4u:
						Block_41:
						try
						{
							switch (num)
							{
							}
							if (enumerator6.MoveNext())
							{
								_4 = enumerator6.Current;
								this.$current = _4;
								if (!this.$disposing)
								{
									this.$PC = 4;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable4 = (enumerator6 as IDisposable)) != null)
								{
									disposable4.Dispose();
								}
							}
						}
						break;
					}
					while (enumerator4.MoveNext())
					{
						eventListenerSpecialEffect = enumerator4.Current;
						if (eventListenerSpecialEffect.GetSpecialEffectType().HasProcessor())
						{
							if (evt.EventListener.IsAliveInBattle())
							{
								enumerator5 = eventListenerSpecialEffect.GetSpecialEffectType().GetSpecialProcessor().AsActiveUnitProcess(eventListenerSpecialEffect, evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
								num = 4294967293u;
								goto Block_40;
							}
							enumerator6 = eventListenerSpecialEffect.GetSpecialEffectType().GetSpecialProcessor().AsInactiveUnitProcess(eventListenerSpecialEffect, evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
							num = 4294967293u;
							goto Block_41;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator4).Dispose();
					}
				}
				goto IL_503;
			case 5u:
				Block_11:
				try
				{
					switch (num)
					{
					case 5u:
						Block_58:
						try
						{
							switch (num)
							{
							}
							if (enumerator8.MoveNext())
							{
								_5 = enumerator8.Current;
								this.$current = _5;
								if (!this.$disposing)
								{
									this.$PC = 5;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable5 = (enumerator8 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator7.MoveNext())
					{
						battleEffect2 = enumerator7.Current;
						enumerator8 = battleEffect2.Process(evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
						num = 4294967293u;
						goto Block_58;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator7).Dispose();
					}
				}
				goto IL_6D4;
			case 6u:
			case 7u:
				Block_13:
				try
				{
					switch (num)
					{
					case 6u:
						Block_70:
						try
						{
							switch (num)
							{
							}
							if (enumerator10.MoveNext())
							{
								_6 = enumerator10.Current;
								this.$current = _6;
								if (!this.$disposing)
								{
									this.$PC = 6;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable6 = (enumerator10 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
						break;
					case 7u:
						Block_71:
						try
						{
							switch (num)
							{
							}
							if (enumerator11.MoveNext())
							{
								_7 = enumerator11.Current;
								this.$current = _7;
								if (!this.$disposing)
								{
									this.$PC = 7;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable7 = (enumerator11 as IDisposable)) != null)
								{
									disposable7.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator9.MoveNext())
					{
						processor = enumerator9.Current;
						if (evt.EventListener.IsAliveInBattle())
						{
							enumerator10 = processor.ActiveListenerProcess(evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
							num = 4294967293u;
							goto Block_70;
						}
						enumerator11 = processor.InactiveListenerProcess(evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
						num = 4294967293u;
						goto Block_71;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator9).Dispose();
					}
				}
				goto IL_916;
			case 8u:
				Block_16:
				try
				{
					switch (num)
					{
					case 8u:
						Block_88:
						try
						{
							switch (num)
							{
							}
							if (enumerator13.MoveNext())
							{
								_8 = enumerator13.Current;
								this.$current = _8;
								if (!this.$disposing)
								{
									this.$PC = 8;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable8 = (enumerator13 as IDisposable)) != null)
								{
									disposable8.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator12.MoveNext())
					{
						expiredEffect = enumerator12.Current;
						enumerator13 = evt.EventTriggerUnit.LooseSkillEffect(expiredEffect, EffectWearsOffType.Expiration).GetEnumerator();
						num = 4294967293u;
						goto Block_88;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator12).Dispose();
					}
				}
				goto IL_A6B;
			case 9u:
				Block_19:
				try
				{
					switch (num)
					{
					case 9u:
						Block_99:
						try
						{
							switch (num)
							{
							}
							if (enumerator15.MoveNext())
							{
								_9 = enumerator15.Current;
								this.$current = _9;
								if (!this.$disposing)
								{
									this.$PC = 9;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable9 = (enumerator15 as IDisposable)) != null)
								{
									disposable9.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator14.MoveNext())
					{
						adventureUnitSkill = enumerator14.Current;
						logic = adventureUnitSkill.GetSkillLogic();
						enumerator15 = logic.ProcessEvent(adventureUnitSkill, evt.EventTriggerUnit, evt.EventListener, evt.EventType, evt.AdditionalData).GetEnumerator();
						num = 4294967293u;
						goto Block_99;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator14).Dispose();
					}
				}
				goto IL_C23;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			enumerator2 = evt.EventListener.BattleEffects.ToList<BattleEffectBase>().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_142:
				switch (num)
				{
				case 2u:
					Block_27:
					try
					{
						switch (num)
						{
						}
						if (enumerator3.MoveNext())
						{
							_2 = enumerator3.Current;
							this.$current = _2;
							if (!this.$disposing)
							{
								this.$PC = 2;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator2.MoveNext())
				{
					battleEffect = enumerator2.Current;
					enumerator3 = battleEffect.CollectTurnEvent(evt.EventType).GetEnumerator();
					num = 4294967293u;
					goto Block_27;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_235:
			adventure = evt.EventListener.CurrentAdventure;
			if (adventure.BattleUnitSpecialEffectsDictionary.ContainsKey(evt.EventListener.GetId()))
			{
				adventureEffects = adventure.BattleUnitSpecialEffectsDictionary[evt.EventListener.GetId()];
				if (adventureEffects.ContainsKey(evt.EventType))
				{
					enumerator4 = adventureEffects[evt.EventType].GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			IL_503:
			if (adventure.BattleEffectsDictionary.ContainsKey(evt.EventListener.GetId()))
			{
				adventurerEffects = adventure.BattleEffectsDictionary[evt.EventListener.GetId()];
				if (adventurerEffects.ContainsKey(evt.EventType))
				{
					effects = (from f in adventurerEffects[evt.EventType]
					select f.Value).ToList<BattleEffectBase>();
					enumerator7 = effects.GetEnumerator();
					num = 4294967293u;
					goto Block_11;
				}
			}
			IL_6D4:
			if (adventure.AttributeProcessDictionary.ContainsKey(evt.EventType))
			{
				enumerator9 = adventure.AttributeProcessDictionary[evt.EventType].GetEnumerator();
				num = 4294967293u;
				goto Block_13;
			}
			IL_916:
			if (evt.EventTriggerUnit == evt.EventListener && (evt.EventType == AdventureEventType.UnitEntersTurn || evt.EventType == AdventureEventType.UnitCompletesTurn))
			{
				enumerator12 = SkillUtilities.GetExpiredEffects(evt.EventTriggerUnit.BattleEffects).GetEnumerator();
				num = 4294967293u;
				goto Block_16;
			}
			IL_A6B:
			if (adventure.SkillsDictionary.ContainsKey(evt.EventListener.GetId()))
			{
				unitSkills = adventure.SkillsDictionary[evt.EventListener.GetId()];
				if (unitSkills.ContainsKey(evt.EventType))
				{
					enumerator14 = unitSkills[evt.EventType].GetEnumerator();
					num = 4294967293u;
					goto Block_19;
				}
			}
			IL_C23:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001278 RID: 4728
		// (get) Token: 0x06005810 RID: 22544 RVA: 0x001055B4 File Offset: 0x001039B4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001279 RID: 4729
		// (get) Token: 0x06005811 RID: 22545 RVA: 0x001055BC File Offset: 0x001039BC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005812 RID: 22546 RVA: 0x001055C4 File Offset: 0x001039C4
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			case 3u:
			case 4u:
				try
				{
					switch (num)
					{
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					case 4u:
						try
						{
						}
						finally
						{
							if ((disposable4 = (enumerator6 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			case 5u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable5 = (enumerator8 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator7).Dispose();
				}
				break;
			case 6u:
			case 7u:
				try
				{
					switch (num)
					{
					case 6u:
						try
						{
						}
						finally
						{
							if ((disposable6 = (enumerator10 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
						break;
					case 7u:
						try
						{
						}
						finally
						{
							if ((disposable7 = (enumerator11 as IDisposable)) != null)
							{
								disposable7.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator9).Dispose();
				}
				break;
			case 8u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable8 = (enumerator13 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator12).Dispose();
				}
				break;
			case 9u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable9 = (enumerator15 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator14).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005813 RID: 22547 RVA: 0x00105928 File Offset: 0x00103D28
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005814 RID: 22548 RVA: 0x0010592F File Offset: 0x00103D2F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005815 RID: 22549 RVA: 0x00105938 File Offset: 0x00103D38
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GameWorld.<BattleUnitProcessAdventureEvent>c__Iterator1 <BattleUnitProcessAdventureEvent>c__Iterator = new GameWorld.<BattleUnitProcessAdventureEvent>c__Iterator1();
			<BattleUnitProcessAdventureEvent>c__Iterator.evt = evt;
			return <BattleUnitProcessAdventureEvent>c__Iterator;
		}

		// Token: 0x06005816 RID: 22550 RVA: 0x0010596C File Offset: 0x00103D6C
		private static BattleEffectBase <>m__0(KeyValuePair<string, BattleEffectBase> f)
		{
			return f.Value;
		}

		// Token: 0x040047EF RID: 18415
		internal AdventureEvent evt;

		// Token: 0x040047F0 RID: 18416
		internal IEnumerator $locvar0;

		// Token: 0x040047F1 RID: 18417
		internal object <_>__1;

		// Token: 0x040047F2 RID: 18418
		internal IDisposable $locvar1;

		// Token: 0x040047F3 RID: 18419
		internal List<BattleEffectBase>.Enumerator $locvar2;

		// Token: 0x040047F4 RID: 18420
		internal BattleEffectBase <battleEffect>__2;

		// Token: 0x040047F5 RID: 18421
		internal IEnumerator $locvar3;

		// Token: 0x040047F6 RID: 18422
		internal object <_>__3;

		// Token: 0x040047F7 RID: 18423
		internal IDisposable $locvar4;

		// Token: 0x040047F8 RID: 18424
		internal Adventure <adventure>__0;

		// Token: 0x040047F9 RID: 18425
		internal Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> <adventureEffects>__4;

		// Token: 0x040047FA RID: 18426
		internal List<ISpecialEffectDataLoad>.Enumerator $locvar5;

		// Token: 0x040047FB RID: 18427
		internal ISpecialEffectDataLoad <eventListenerSpecialEffect>__5;

		// Token: 0x040047FC RID: 18428
		internal IEnumerator $locvar6;

		// Token: 0x040047FD RID: 18429
		internal object <_>__6;

		// Token: 0x040047FE RID: 18430
		internal IDisposable $locvar7;

		// Token: 0x040047FF RID: 18431
		internal IEnumerator $locvar8;

		// Token: 0x04004800 RID: 18432
		internal object <_>__7;

		// Token: 0x04004801 RID: 18433
		internal IDisposable $locvar9;

		// Token: 0x04004802 RID: 18434
		internal Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> <adventurerEffects>__8;

		// Token: 0x04004803 RID: 18435
		internal List<BattleEffectBase> <effects>__9;

		// Token: 0x04004804 RID: 18436
		internal List<BattleEffectBase>.Enumerator $locvarA;

		// Token: 0x04004805 RID: 18437
		internal BattleEffectBase <battleEffect>__10;

		// Token: 0x04004806 RID: 18438
		internal IEnumerator $locvarB;

		// Token: 0x04004807 RID: 18439
		internal object <_>__11;

		// Token: 0x04004808 RID: 18440
		internal IDisposable $locvarC;

		// Token: 0x04004809 RID: 18441
		internal List<AttributeProcessBase>.Enumerator $locvarD;

		// Token: 0x0400480A RID: 18442
		internal AttributeProcessBase <processor>__12;

		// Token: 0x0400480B RID: 18443
		internal IEnumerator $locvarE;

		// Token: 0x0400480C RID: 18444
		internal object <_>__13;

		// Token: 0x0400480D RID: 18445
		internal IDisposable $locvarF;

		// Token: 0x0400480E RID: 18446
		internal IEnumerator $locvar10;

		// Token: 0x0400480F RID: 18447
		internal object <_>__14;

		// Token: 0x04004810 RID: 18448
		internal IDisposable $locvar11;

		// Token: 0x04004811 RID: 18449
		internal List<BattleEffectBase>.Enumerator $locvar12;

		// Token: 0x04004812 RID: 18450
		internal BattleEffectBase <expiredEffect>__15;

		// Token: 0x04004813 RID: 18451
		internal IEnumerator $locvar13;

		// Token: 0x04004814 RID: 18452
		internal object <_>__16;

		// Token: 0x04004815 RID: 18453
		internal IDisposable $locvar14;

		// Token: 0x04004816 RID: 18454
		internal Dictionary<AdventureEventType, List<AdventureUnitSkill>> <unitSkills>__17;

		// Token: 0x04004817 RID: 18455
		internal List<AdventureUnitSkill>.Enumerator $locvar15;

		// Token: 0x04004818 RID: 18456
		internal AdventureUnitSkill <adventureUnitSkill>__18;

		// Token: 0x04004819 RID: 18457
		internal SkillLogicBase <logic>__19;

		// Token: 0x0400481A RID: 18458
		internal IEnumerator $locvar16;

		// Token: 0x0400481B RID: 18459
		internal object <_>__20;

		// Token: 0x0400481C RID: 18460
		internal IDisposable $locvar17;

		// Token: 0x0400481D RID: 18461
		internal object $current;

		// Token: 0x0400481E RID: 18462
		internal bool $disposing;

		// Token: 0x0400481F RID: 18463
		internal int $PC;

		// Token: 0x04004820 RID: 18464
		private static Func<KeyValuePair<string, BattleEffectBase>, BattleEffectBase> <>f__am$cache0;
	}

	// Token: 0x02000D8D RID: 3469
	[CompilerGenerated]
	private sealed class <ProcessWorkload>c__Iterator2 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005817 RID: 22551 RVA: 0x00105975 File Offset: 0x00103D75
		[DebuggerHidden]
		public <ProcessWorkload>c__Iterator2()
		{
		}

		// Token: 0x06005818 RID: 22552 RVA: 0x00105980 File Offset: 0x00103D80
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this._workloadInProgress = true;
				enumerator = this._asyncWorkload.Run().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			this._asyncWorkload = null;
			this._workloadInProgress = false;
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700127A RID: 4730
		// (get) Token: 0x06005819 RID: 22553 RVA: 0x00105A90 File Offset: 0x00103E90
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700127B RID: 4731
		// (get) Token: 0x0600581A RID: 22554 RVA: 0x00105A98 File Offset: 0x00103E98
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600581B RID: 22555 RVA: 0x00105AA0 File Offset: 0x00103EA0
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600581C RID: 22556 RVA: 0x00105B10 File Offset: 0x00103F10
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004821 RID: 18465
		internal IEnumerator $locvar0;

		// Token: 0x04004822 RID: 18466
		internal object <_>__1;

		// Token: 0x04004823 RID: 18467
		internal IDisposable $locvar1;

		// Token: 0x04004824 RID: 18468
		internal GameWorld $this;

		// Token: 0x04004825 RID: 18469
		internal object $current;

		// Token: 0x04004826 RID: 18470
		internal bool $disposing;

		// Token: 0x04004827 RID: 18471
		internal int $PC;
	}

	// Token: 0x02000D8E RID: 3470
	[CompilerGenerated]
	private sealed class <RunAdventure>c__Iterator3 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600581D RID: 22557 RVA: 0x00105B17 File Offset: 0x00103F17
		[DebuggerHidden]
		public <RunAdventure>c__Iterator3()
		{
		}

		// Token: 0x0600581E RID: 22558 RVA: 0x00105B20 File Offset: 0x00103F20
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				try
				{
					if (this.CurrentAdventure == null)
					{
						return false;
					}
					this._currentAdventureInProgress = true;
					this.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureInitialized, this.CurrentAdventure);
				}
				catch (Exception exception)
				{
					SteamExceptionHandle.Handle(exception, 0u);
				}
				emrt = this.CurrentAdventure.Run().GetEnumerator();
				more = true;
				goto IL_134;
			case 1u:
				break;
			case 2u:
				goto IL_134;
			default:
				return false;
			}
			IL_C3:
			if (!base.HasWorkload())
			{
				try
				{
					more = emrt.MoveNext();
				}
				catch (Exception exception2)
				{
					hasError = true;
					more = false;
					SteamExceptionHandle.Handle(exception2, 0u);
				}
				if (hasError)
				{
					goto IL_134;
				}
				this.$current = emrt.Current;
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
			}
			else
			{
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
			}
			return true;
			IL_134:
			if (more)
			{
				hasError = false;
				goto IL_C3;
			}
			this.CurrentAdventure = null;
			this._currentAdventureInProgress = false;
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700127C RID: 4732
		// (get) Token: 0x0600581F RID: 22559 RVA: 0x00105CAC File Offset: 0x001040AC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700127D RID: 4733
		// (get) Token: 0x06005820 RID: 22560 RVA: 0x00105CB4 File Offset: 0x001040B4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005821 RID: 22561 RVA: 0x00105CBC File Offset: 0x001040BC
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005822 RID: 22562 RVA: 0x00105CCC File Offset: 0x001040CC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004828 RID: 18472
		internal IEnumerator <emrt>__0;

		// Token: 0x04004829 RID: 18473
		internal bool <more>__1;

		// Token: 0x0400482A RID: 18474
		internal bool <hasError>__2;

		// Token: 0x0400482B RID: 18475
		internal GameWorld $this;

		// Token: 0x0400482C RID: 18476
		internal object $current;

		// Token: 0x0400482D RID: 18477
		internal bool $disposing;

		// Token: 0x0400482E RID: 18478
		internal int $PC;
	}
}
