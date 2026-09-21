using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class BattleEncounter : IEncounter
{
	// Token: 0x06001DE7 RID: 7655 RVA: 0x000CD1AC File Offset: 0x000CB5AC
	public BattleEncounter(List<IBattleUnit> playerUnits, List<IBattleUnit> enemyUnits, Adventure adventure)
	{
		this._playerUnits = new List<IBattleUnit>();
		this._playerUnits.AddRange(playerUnits);
		this._enemyUnits = enemyUnits;
		this.IsCompleted = false;
		this.TurnCounter = new Dictionary<IBattleUnit, double>();
		this.CurrentAdventure = adventure;
		this._drops = new List<ResourceUpdate>();
		this.PlayerGauge = 0.0;
		this.EnemyGauge = 0.0;
		this.Log = new BattleLog
		{
			Logs = new Queue<string>()
		};
		this.TacticInProgress = false;
		this._doTurnInProgress = false;
		this._expiraConfusionInProgress = false;
		this._inversedMandateInProcess = false;
		this._numberOfUnfinishedEncounterPerSecProcess = 0;
		this._numberOfUnfinishedBattleEffectPerSecProcess = new Dictionary<BattleEffectBase, int>();
		this._numberOfUnfinishedSkillPerSecProcess = new Dictionary<AdventureUnitSkill, int>();
	}

	// Token: 0x14000009 RID: 9
	// (add) Token: 0x06001DE8 RID: 7656 RVA: 0x000CD2A0 File Offset: 0x000CB6A0
	// (remove) Token: 0x06001DE9 RID: 7657 RVA: 0x000CD2D8 File Offset: 0x000CB6D8
	public event Action<List<IBattleUnit>> PlayerWon
	{
		add
		{
			Action<List<IBattleUnit>> action = this.PlayerWon;
			Action<List<IBattleUnit>> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<List<IBattleUnit>>>(ref this.PlayerWon, (Action<List<IBattleUnit>>)Delegate.Combine(action2, value), action);
			}
			while (action != action2);
		}
		remove
		{
			Action<List<IBattleUnit>> action = this.PlayerWon;
			Action<List<IBattleUnit>> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<List<IBattleUnit>>>(ref this.PlayerWon, (Action<List<IBattleUnit>>)Delegate.Remove(action2, value), action);
			}
			while (action != action2);
		}
	}

	// Token: 0x1400000A RID: 10
	// (add) Token: 0x06001DEA RID: 7658 RVA: 0x000CD310 File Offset: 0x000CB710
	// (remove) Token: 0x06001DEB RID: 7659 RVA: 0x000CD348 File Offset: 0x000CB748
	public event Action<List<IBattleUnit>> PlayerLost
	{
		add
		{
			Action<List<IBattleUnit>> action = this.PlayerLost;
			Action<List<IBattleUnit>> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<List<IBattleUnit>>>(ref this.PlayerLost, (Action<List<IBattleUnit>>)Delegate.Combine(action2, value), action);
			}
			while (action != action2);
		}
		remove
		{
			Action<List<IBattleUnit>> action = this.PlayerLost;
			Action<List<IBattleUnit>> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<List<IBattleUnit>>>(ref this.PlayerLost, (Action<List<IBattleUnit>>)Delegate.Remove(action2, value), action);
			}
			while (action != action2);
		}
	}

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x06001DEC RID: 7660 RVA: 0x000CD37E File Offset: 0x000CB77E
	// (set) Token: 0x06001DED RID: 7661 RVA: 0x000CD386 File Offset: 0x000CB786
	public bool TacticInProgress
	{
		[CompilerGenerated]
		get
		{
			return this.<TacticInProgress>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TacticInProgress>k__BackingField = value;
		}
	}

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x06001DEE RID: 7662 RVA: 0x000CD38F File Offset: 0x000CB78F
	// (set) Token: 0x06001DEF RID: 7663 RVA: 0x000CD397 File Offset: 0x000CB797
	public BattleLog Log
	{
		[CompilerGenerated]
		get
		{
			return this.<Log>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Log>k__BackingField = value;
		}
	}

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x06001DF0 RID: 7664 RVA: 0x000CD3A0 File Offset: 0x000CB7A0
	// (set) Token: 0x06001DF1 RID: 7665 RVA: 0x000CD3A8 File Offset: 0x000CB7A8
	public double PlayerGauge
	{
		[CompilerGenerated]
		get
		{
			return this.<PlayerGauge>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<PlayerGauge>k__BackingField = value;
		}
	}

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x06001DF2 RID: 7666 RVA: 0x000CD3B1 File Offset: 0x000CB7B1
	// (set) Token: 0x06001DF3 RID: 7667 RVA: 0x000CD3B9 File Offset: 0x000CB7B9
	public double EnemyGauge
	{
		[CompilerGenerated]
		get
		{
			return this.<EnemyGauge>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<EnemyGauge>k__BackingField = value;
		}
	}

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x06001DF4 RID: 7668 RVA: 0x000CD3C2 File Offset: 0x000CB7C2
	// (set) Token: 0x06001DF5 RID: 7669 RVA: 0x000CD3CA File Offset: 0x000CB7CA
	public Dictionary<IBattleUnit, double> TurnCounter
	{
		[CompilerGenerated]
		get
		{
			return this.<TurnCounter>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<TurnCounter>k__BackingField = value;
		}
	}

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x06001DF6 RID: 7670 RVA: 0x000CD3D3 File Offset: 0x000CB7D3
	public List<IBattleUnit> PlayerUnits
	{
		get
		{
			return (from u in this._playerUnits
			select u).ToList<IBattleUnit>();
		}
	}

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x06001DF7 RID: 7671 RVA: 0x000CD402 File Offset: 0x000CB802
	public List<IBattleUnit> EnemyUnits
	{
		get
		{
			return (from u in this._enemyUnits
			select u).ToList<IBattleUnit>();
		}
	}

	// Token: 0x06001DF8 RID: 7672 RVA: 0x000CD431 File Offset: 0x000CB831
	public double GetGauge(IBattleUnit unit)
	{
		if (unit.IsPlayer)
		{
			return this.PlayerGauge;
		}
		return this.EnemyGauge;
	}

	// Token: 0x06001DF9 RID: 7673 RVA: 0x000CD44C File Offset: 0x000CB84C
	public IEnumerable RemovePet(PetBattleUnit unit)
	{
		if (unit.IsPlayer)
		{
			IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.PetRemoving, null)).GetEnumerator();
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
			IEnumerator enumerator2 = unit.LeavesEncounter().GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
			this.TurnCounter.Remove(unit);
			this._playerUnits.Remove(unit);
		}
		else
		{
			IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.PetRemoving, null)).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _3 = enumerator3.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
			IEnumerator enumerator4 = unit.LeavesEncounter().GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _4 = enumerator4.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator4 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
			this.TurnCounter.Remove(unit);
			this._enemyUnits.Remove(unit);
		}
		yield break;
	}

	// Token: 0x06001DFA RID: 7674 RVA: 0x000CD478 File Offset: 0x000CB878
	public IEnumerable AddPet(PetBattleUnit unit)
	{
		if (unit.IsPlayer)
		{
			PetBattleUnit existingPet = this.PlayerUnits.OfType<PetBattleUnit>().FirstOrDefault<PetBattleUnit>();
			if (existingPet != null)
			{
				IEnumerator enumerator = this.RemovePet(existingPet).GetEnumerator();
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
			}
			this.TurnCounter.Add(unit, 0.0);
			this._playerUnits.Add(unit);
			Adventure adventure = unit.CurrentAdventure;
			if (adventure != null)
			{
				if (!adventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure.BattleEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>());
				}
				if (!adventure.BattleUnitSpecialEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure.BattleUnitSpecialEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>());
				}
				Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> dictionary = adventure.BattleUnitSpecialEffectsDictionary[unit.GetId()];
				foreach (ISpecialEffectDataLoad specialEffectDataLoad in unit.SpecialEffects)
				{
					if (specialEffectDataLoad.GetSpecialEffectType().HasProcessor())
					{
						SpecialEffectProcessBase specialProcessor = specialEffectDataLoad.GetSpecialEffectType().GetSpecialProcessor();
						foreach (AdventureEventType key in specialProcessor.CorrespondingEvents.Distinct<AdventureEventType>())
						{
							if (dictionary.ContainsKey(key))
							{
								dictionary[key].Add(specialEffectDataLoad);
							}
							else
							{
								dictionary.Add(key, new List<ISpecialEffectDataLoad>
								{
									specialEffectDataLoad
								});
							}
						}
					}
				}
				if (!adventure.SkillsDictionary.ContainsKey(unit.GetId()))
				{
					adventure.SkillsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<AdventureUnitSkill>>());
				}
				Dictionary<AdventureEventType, List<AdventureUnitSkill>> dictionary2 = adventure.SkillsDictionary[unit.GetId()];
				foreach (AdventureUnitSkill adventureUnitSkill in unit.Skills)
				{
					foreach (AdventureEventType key2 in adventureUnitSkill.GetSkillLogic().CorrespondingEvents().Distinct<AdventureEventType>())
					{
						if (dictionary2.ContainsKey(key2))
						{
							dictionary2[key2].Add(adventureUnitSkill);
						}
						else
						{
							dictionary2.Add(key2, new List<AdventureUnitSkill>
							{
								adventureUnitSkill
							});
						}
					}
				}
			}
			IEnumerator enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit.OwnerUnit, AdventureEventType.PetSummoned, unit)).GetEnumerator();
			try
			{
				while (enumerator6.MoveNext())
				{
					object _2 = enumerator6.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator6 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		else
		{
			PetBattleUnit existingPet2 = this.EnemyUnits.OfType<PetBattleUnit>().FirstOrDefault<PetBattleUnit>();
			if (existingPet2 != null)
			{
				IEnumerator enumerator7 = this.RemovePet(existingPet2).GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						object _3 = enumerator7.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator7 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			this.TurnCounter.Add(unit, 0.0);
			this._enemyUnits.Add(unit);
			Adventure adventure2 = unit.CurrentAdventure;
			if (adventure2 != null)
			{
				if (!adventure2.BattleEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure2.BattleEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>());
				}
				if (!adventure2.BattleUnitSpecialEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure2.BattleUnitSpecialEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>());
				}
				Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> dictionary3 = adventure2.BattleUnitSpecialEffectsDictionary[unit.GetId()];
				foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in unit.SpecialEffects)
				{
					if (specialEffectDataLoad2.GetSpecialEffectType().HasProcessor())
					{
						SpecialEffectProcessBase specialProcessor2 = specialEffectDataLoad2.GetSpecialEffectType().GetSpecialProcessor();
						foreach (AdventureEventType key3 in specialProcessor2.CorrespondingEvents.Distinct<AdventureEventType>())
						{
							if (dictionary3.ContainsKey(key3))
							{
								dictionary3[key3].Add(specialEffectDataLoad2);
							}
							else
							{
								dictionary3.Add(key3, new List<ISpecialEffectDataLoad>
								{
									specialEffectDataLoad2
								});
							}
						}
					}
				}
				if (!adventure2.SkillsDictionary.ContainsKey(unit.GetId()))
				{
					adventure2.SkillsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<AdventureUnitSkill>>());
				}
				Dictionary<AdventureEventType, List<AdventureUnitSkill>> dictionary4 = adventure2.SkillsDictionary[unit.GetId()];
				foreach (AdventureUnitSkill adventureUnitSkill2 in unit.Skills)
				{
					foreach (AdventureEventType key4 in adventureUnitSkill2.GetSkillLogic().CorrespondingEvents().Distinct<AdventureEventType>())
					{
						if (dictionary4.ContainsKey(key4))
						{
							dictionary4[key4].Add(adventureUnitSkill2);
						}
						else
						{
							dictionary4.Add(key4, new List<AdventureUnitSkill>
							{
								adventureUnitSkill2
							});
						}
					}
				}
			}
			IEnumerator enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit.OwnerUnit, AdventureEventType.PetSummoned, unit)).GetEnumerator();
			try
			{
				while (enumerator12.MoveNext())
				{
					object _4 = enumerator12.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator12 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06001DFB RID: 7675 RVA: 0x000CD4A4 File Offset: 0x000CB8A4
	public IEnumerable TryAutoRun()
	{
		if (this.HasAutoSet && !this.CurrentAdventure.AutoTacticPause && this.HasInitialized)
		{
			if (this.AutoIndex >= this.AutoRules.Count)
			{
				this.AutoIndex = 0;
			}
			if (this.AutoIndex < this.AutoRules.Count)
			{
				StrategyRuleRuntime rule = this.AutoRules[this.AutoIndex];
				ActiveSkillLogicBase skill = rule.Skill.GetSkillLogic() as ActiveSkillLogicBase;
				if (rule.Skill.SourceUnit.IsAliveInBattle())
				{
					if (skill.IsAutoCastable(rule.Skill))
					{
						IEnumerator enumerator = skill.AutoCast(rule.CandidateOrderringMetric, rule.OrderingType, rule.Skill).GetEnumerator();
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
						this.AutoIndex++;
					}
				}
				else
				{
					this.AutoIndex++;
				}
			}
		}
		yield break;
	}

	// Token: 0x06001DFC RID: 7676 RVA: 0x000CD4C8 File Offset: 0x000CB8C8
	public IEnumerable Run()
	{
		this._doTurnInProgress = false;
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(this.PlayerUnits.FirstOrDefault<IBattleUnit>(), AdventureEventType.BattleEncounterStarts, this)).GetEnumerator();
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
		this.AutoRules = new List<StrategyRuleRuntime>();
		if (this.CurrentAdventure.AutoTacticRules != null && this.CurrentAdventure.AutoTacticRules.Any<StrategyRule>())
		{
			using (List<StrategyRule>.Enumerator enumerator2 = this.CurrentAdventure.AutoTacticRules.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					StrategyRule currentAdventureAutoTacticRule = enumerator2.Current;
					IBattleUnit battleUnit3 = this.PlayerUnits.FirstOrDefault((IBattleUnit u) => u.GetId() == currentAdventureAutoTacticRule.AdventurerId);
					if (battleUnit3 != null && battleUnit3 is AdventurerBattleUnit)
					{
						this.AutoRules.Add(StrategyRuleRuntime.CreateRuntimeRule(battleUnit3 as AdventurerBattleUnit, currentAdventureAutoTacticRule));
					}
				}
			}
		}
		this.HasAutoSet = this.AutoRules.Any<StrategyRuleRuntime>();
		if (!this.IsWinningConditionMet())
		{
			Dictionary<IBattleUnit, double> turnCounter = this.TurnCounter;
			foreach (IBattleUnit key in this.PlayerUnits)
			{
				turnCounter.Add(key, 0.0);
			}
			foreach (IBattleUnit key2 in this.EnemyUnits)
			{
				turnCounter.Add(key2, 0.0);
			}
			double timer = 0.0;
			foreach (IBattleUnit playerUnit in this.PlayerUnits)
			{
				IEnumerator enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(playerUnit, AdventureEventType.UnitReadyInBattle, this)).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _2 = enumerator6.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator6 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			foreach (IBattleUnit battleUnit in this.EnemyUnits)
			{
				IEnumerator enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(battleUnit, AdventureEventType.UnitReadyInBattle, this)).GetEnumerator();
				try
				{
					while (enumerator8.MoveNext())
					{
						object _3 = enumerator8.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator8 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			this.HasInitialized = true;
			foreach (IBattleUnit playerUnit2 in this.PlayerUnits)
			{
				IEnumerator enumerator10 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(playerUnit2, AdventureEventType.TurnSetupCompleted, this)).GetEnumerator();
				try
				{
					while (enumerator10.MoveNext())
					{
						object _4 = enumerator10.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator10 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			foreach (IBattleUnit battleUnit2 in this.EnemyUnits)
			{
				IEnumerator enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(battleUnit2, AdventureEventType.TurnSetupCompleted, this)).GetEnumerator();
				try
				{
					while (enumerator12.MoveNext())
					{
						object _5 = enumerator12.Current;
						yield return _5;
					}
				}
				finally
				{
					IDisposable disposable5;
					if ((disposable5 = (enumerator12 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			IEnumerator enumerator13 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(this.PlayerUnits.FirstOrDefault<IBattleUnit>(), AdventureEventType.EncounterSetupCompleted, this)).GetEnumerator();
			try
			{
				while (enumerator13.MoveNext())
				{
					object _6 = enumerator13.Current;
					yield return _6;
				}
			}
			finally
			{
				IDisposable disposable6;
				if ((disposable6 = (enumerator13 as IDisposable)) != null)
				{
					disposable6.Dispose();
				}
			}
			if (this.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating != -1 || this.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 700.0)
			{
				this.CurrentAdventure.ActionCountSoFar = new double?(0.0);
				this.CurrentAdventure.ActionCountPossible = new double?(Adventure.CalculateMaxActionCounts(260.0, this.CurrentAdventure.Adventurers));
			}
			if (this.CurrentAdventure.RunePower != null)
			{
				IEnumerator enumerator14 = this.CurrentAdventure.RunePower.TryRun().GetEnumerator();
				try
				{
					while (enumerator14.MoveNext())
					{
						object _7 = enumerator14.Current;
						yield return _7;
					}
				}
				finally
				{
					IDisposable disposable7;
					if ((disposable7 = (enumerator14 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
			}
			InversedMandateEffectProcess iversedmandateProcess = (!SpecialEffectType.InversedMandate.HasProcessor()) ? null : (SpecialEffectType.InversedMandate.GetSpecialProcessor() as InversedMandateEffectProcess);
			while (!this.IsWinningConditionMet())
			{
				List<IBattleUnit> units = new List<IBattleUnit>();
				units.AddRange(this.PlayerUnits);
				units.AddRange(this.EnemyUnits);
				if (!this._doTurnInProgress && !this.TacticInProgress && (this.CurrentAdventure.RunePower == null || !this.CurrentAdventure.RunePower._processInTurn))
				{
					IBattleUnit firstUnit = (from u in units
					where this.TurnCounter.ContainsKey(u) && this.TurnCounter[u] >= PlayerProfile.TurnSpeedGauge && u.IsTurnRelevant() && u.CanAct()
					orderby u.GetSpeed(AttributeRetrievalLevel.Skill) descending
					select u).FirstOrDefault<IBattleUnit>();
					if (firstUnit != null && this.TurnCounter.ContainsKey(firstUnit) && this.TurnCounter[firstUnit] >= PlayerProfile.TurnSpeedGauge)
					{
						this._doTurnInProgress = true;
						IEnumerator enumerator15 = this.DoTurnLogic(firstUnit, turnCounter).GetEnumerator();
						try
						{
							while (enumerator15.MoveNext())
							{
								object _8 = enumerator15.Current;
								yield return _8;
							}
						}
						finally
						{
							IDisposable disposable8;
							if ((disposable8 = (enumerator15 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
					}
					int prvTime = (int)timer;
					timer += (double)Time.deltaTime;
					int crtTime = (int)timer;
					if (crtTime > prvTime)
					{
						this._numberOfUnfinishedEncounterPerSecProcess++;
						IEnumerator enumerator16 = this.EncounterPerSecondProcess(timer).GetEnumerator();
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
					Dictionary<IBattleUnit, List<BattleEffectBase>> dots = new Dictionary<IBattleUnit, List<BattleEffectBase>>();
					foreach (IBattleUnit unit in turnCounter.Keys.ToList<IBattleUnit>())
					{
						List<LockTimeEffect> timeLockEffects = unit.BattleEffects.OfType<LockTimeEffect>().ToList<LockTimeEffect>();
						List<LockTimeEffect> activeConfusions = (from ef in timeLockEffects
						where ef.MaxNumberOfLastingSeconds > ef.Timer
						select ef).ToList<LockTimeEffect>();
						if (activeConfusions.Any<LockTimeEffect>())
						{
							foreach (LockTimeEffect lockTimeEffect in activeConfusions)
							{
								lockTimeEffect.Timer += Time.deltaTime * Time.timeScale;
							}
						}
						else if (unit.IsTurnRelevant() && turnCounter.ContainsKey(unit))
						{
							double speedBase = 20.0;
							if (this.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == -1 && this.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 2000.0)
							{
								speedBase = 30.0;
							}
							Dictionary<IBattleUnit, double> dictionary;
							IBattleUnit key3;
							(dictionary = turnCounter)[key3 = unit] = dictionary[key3] + PlayerProfile.TurnSpeedbase * (double)Time.deltaTime * (1.0 + unit.GetSpeed(AttributeRetrievalLevel.Skill) / speedBase);
							List<InversedMandateData> inversedMandateEffect = unit.SpecialEffects.OfType<InversedMandateData>().ToList<InversedMandateData>();
							if (inversedMandateEffect.Any<InversedMandateData>() && iversedmandateProcess != null && !this._inversedMandateInProcess)
							{
								this._inversedMandateInProcess = true;
								IEnumerator enumerator19 = this.InversedMandateProcess(unit, inversedMandateEffect, iversedmandateProcess).GetEnumerator();
								try
								{
									while (enumerator19.MoveNext())
									{
										object _10 = enumerator19.Current;
										yield return _10;
									}
								}
								finally
								{
									IDisposable disposable10;
									if ((disposable10 = (enumerator19 as IDisposable)) != null)
									{
										disposable10.Dispose();
									}
								}
							}
						}
						List<BattleEffectBase> effects = (from b in unit.BattleEffects
						select b).ToList<BattleEffectBase>();
						foreach (BattleEffectBase effect in effects)
						{
							int prsbTm = (int)effect.Timer;
							effect.Timer += Time.deltaTime;
							int crtbTm = (int)effect.Timer;
							if (crtbTm > prsbTm)
							{
								if (this._numberOfUnfinishedBattleEffectPerSecProcess.ContainsKey(effect))
								{
									Dictionary<BattleEffectBase, int> numberOfUnfinishedBattleEffectPerSecProcess;
									BattleEffectBase key4;
									(numberOfUnfinishedBattleEffectPerSecProcess = this._numberOfUnfinishedBattleEffectPerSecProcess)[key4 = effect] = numberOfUnfinishedBattleEffectPerSecProcess[key4] + 1;
								}
								else
								{
									this._numberOfUnfinishedBattleEffectPerSecProcess.Add(effect, 1);
								}
								if (effect is DamageOverTimeEffect || effect is LifeExtractionEffect || effect is ShieldBurnEffect)
								{
									if (dots.ContainsKey(unit))
									{
										dots[unit].Add(effect);
									}
									else
									{
										dots.Add(unit, new List<BattleEffectBase>
										{
											effect
										});
									}
								}
								else
								{
									IEnumerator enumerator21 = this.BattleEffectPerSecondProcess(unit, effect).GetEnumerator();
									try
									{
										while (enumerator21.MoveNext())
										{
											object _11 = enumerator21.Current;
											yield return _11;
										}
									}
									finally
									{
										IDisposable disposable11;
										if ((disposable11 = (enumerator21 as IDisposable)) != null)
										{
											disposable11.Dispose();
										}
									}
								}
							}
						}
						List<AdventureUnitSkill> skills = (from s in unit.Skills
						select s).ToList<AdventureUnitSkill>();
						foreach (AdventureUnitSkill skill in skills)
						{
							int prsStim = (int)skill.Timer;
							skill.Timer += Time.deltaTime;
							int crtStime = (int)skill.Timer;
							if (crtStime > prsStim)
							{
								if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
								{
									Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
									AdventureUnitSkill key5;
									(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[key5 = skill] = numberOfUnfinishedSkillPerSecProcess[key5] + 1;
								}
								else
								{
									this._numberOfUnfinishedSkillPerSecProcess.Add(skill, 1);
								}
								IEnumerator enumerator23 = this.SkillPerSecondProcess(unit, skill).GetEnumerator();
								try
								{
									while (enumerator23.MoveNext())
									{
										object _12 = enumerator23.Current;
										yield return _12;
									}
								}
								finally
								{
									IDisposable disposable12;
									if ((disposable12 = (enumerator23 as IDisposable)) != null)
									{
										disposable12.Dispose();
									}
								}
							}
							if (skill.RemainingCoolingDownSeconds != null && skill.RemainingCoolingDownSeconds.Value > 0f)
							{
								AdventureUnitSkill adventureUnitSkill = skill;
								float? remainingCoolingDownSeconds = adventureUnitSkill.RemainingCoolingDownSeconds;
								adventureUnitSkill.RemainingCoolingDownSeconds = ((remainingCoolingDownSeconds == null) ? null : new float?(remainingCoolingDownSeconds.GetValueOrDefault() - Time.deltaTime));
								if (skill.RemainingCoolingDownSeconds <= 0f)
								{
									skill.RemainingCoolingDownSeconds = new float?(0f);
									if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
									{
										Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
										AdventureUnitSkill key6;
										(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[key6 = skill] = numberOfUnfinishedSkillPerSecProcess[key6] + 1;
									}
									else
									{
										this._numberOfUnfinishedSkillPerSecProcess.Add(skill, 1);
									}
									IEnumerator enumerator24 = this.SkillCoolingDownLogic(skill).GetEnumerator();
									try
									{
										while (enumerator24.MoveNext())
										{
											object _13 = enumerator24.Current;
											yield return _13;
										}
									}
									finally
									{
										IDisposable disposable13;
										if ((disposable13 = (enumerator24 as IDisposable)) != null)
										{
											disposable13.Dispose();
										}
									}
								}
							}
						}
						if (!this._expiraConfusionInProgress)
						{
							this._expiraConfusionInProgress = true;
							IEnumerator enumerator25 = this.ConfusionExpiration(timeLockEffects, unit).GetEnumerator();
							try
							{
								while (enumerator25.MoveNext())
								{
									object _14 = enumerator25.Current;
									yield return _14;
								}
							}
							finally
							{
								IDisposable disposable14;
								if ((disposable14 = (enumerator25 as IDisposable)) != null)
								{
									disposable14.Dispose();
								}
							}
						}
					}
					IEnumerator enumerator26 = this.DamageOverTimePerSecondProcess(dots).GetEnumerator();
					try
					{
						while (enumerator26.MoveNext())
						{
							object _15 = enumerator26.Current;
							yield return _15;
						}
					}
					finally
					{
						IDisposable disposable15;
						if ((disposable15 = (enumerator26 as IDisposable)) != null)
						{
							disposable15.Dispose();
						}
					}
				}
				yield return null;
			}
		}
		for (;;)
		{
			if (!this._doTurnInProgress && !this._expiraConfusionInProgress && !this.TacticInProgress && this._numberOfUnfinishedEncounterPerSecProcess <= 0)
			{
				if (!this._numberOfUnfinishedBattleEffectPerSecProcess.Values.Any((int v) => v > 0))
				{
					if (!this._numberOfUnfinishedSkillPerSecProcess.Values.Any((int v) => v > 0))
					{
						break;
					}
				}
			}
			yield return null;
		}
		this._numberOfUnfinishedBattleEffectPerSecProcess.Clear();
		this.IsCompleted = true;
		foreach (IBattleUnit battleUnit4 in this.PlayerUnits)
		{
			foreach (AdventureUnitSkill adventureUnitSkill2 in battleUnit4.Skills)
			{
				adventureUnitSkill2.PassiveHasBeenRecentlyApplied = false;
			}
		}
		foreach (IBattleUnit battleUnit5 in this.EnemyUnits)
		{
			foreach (AdventureUnitSkill adventureUnitSkill3 in battleUnit5.Skills)
			{
				adventureUnitSkill3.PassiveHasBeenRecentlyApplied = false;
			}
		}
		if (this.IsPlayerWon())
		{
			this.OnPlayerWon(this.PlayerUnits);
		}
		else if (this.IsPlayerLost())
		{
			this.OnPlayerLost(this.PlayerUnits);
		}
		yield break;
	}

	// Token: 0x06001DFD RID: 7677 RVA: 0x000CD4EC File Offset: 0x000CB8EC
	private IEnumerable SkillPerSecondProcess(IBattleUnit unit, AdventureUnitSkill skill)
	{
		if (unit.IsAliveInBattle())
		{
			IEnumerator enumerator = skill.GetSkillLogic().PerSecondLogic_ActiveUnit(skill, unit).GetEnumerator();
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
		}
		else
		{
			IEnumerator enumerator2 = skill.GetSkillLogic().PerSecondLogic_InactiveUnit(skill, unit).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
		{
			Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
			(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[skill] = numberOfUnfinishedSkillPerSecProcess[skill] - 1;
		}
		else
		{
			UnityEngine.Debug.LogError("Invalid skill per sec workload!");
		}
		yield break;
	}

	// Token: 0x06001DFE RID: 7678 RVA: 0x000CD520 File Offset: 0x000CB920
	private IEnumerable SkillCoolingDownLogic(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.ActiveBattleSkillCompletesCoolingDowns, skill)).GetEnumerator();
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
		if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
		{
			Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
			(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[skill] = numberOfUnfinishedSkillPerSecProcess[skill] - 1;
		}
		else
		{
			UnityEngine.Debug.LogError("Invalid skill cooling down workload!");
		}
		yield break;
	}

	// Token: 0x06001DFF RID: 7679 RVA: 0x000CD54C File Offset: 0x000CB94C
	private IEnumerable DamageOverTimePerSecondProcess(Dictionary<IBattleUnit, List<BattleEffectBase>> dots)
	{
		if (dots.Any<KeyValuePair<IBattleUnit, List<BattleEffectBase>>>())
		{
			IEnumerator enumerator = DamageOverTimeEffect.PerSecondLogic_ActiveUnit_Batch(dots).GetEnumerator();
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
			foreach (KeyValuePair<IBattleUnit, List<BattleEffectBase>> keyValuePair in dots)
			{
				foreach (BattleEffectBase battleEffectBase in keyValuePair.Value)
				{
					if (this._numberOfUnfinishedBattleEffectPerSecProcess.ContainsKey(battleEffectBase))
					{
						Dictionary<BattleEffectBase, int> numberOfUnfinishedBattleEffectPerSecProcess;
						BattleEffectBase key;
						(numberOfUnfinishedBattleEffectPerSecProcess = this._numberOfUnfinishedBattleEffectPerSecProcess)[key = battleEffectBase] = numberOfUnfinishedBattleEffectPerSecProcess[key] - 1;
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06001E00 RID: 7680 RVA: 0x000CD578 File Offset: 0x000CB978
	private IEnumerable BattleEffectPerSecondProcess(IBattleUnit unit, BattleEffectBase effect)
	{
		if (unit.IsAliveInBattle())
		{
			IEnumerator enumerator = effect.PerSecondLogic_ActiveUnit(unit).GetEnumerator();
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
		}
		else
		{
			IEnumerator enumerator2 = effect.PerSecondLogic_InactiveUnit(unit).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		if (effect.MaxNumberOfLastingSeconds != null)
		{
			float? maxNumberOfLastingSeconds = effect.MaxNumberOfLastingSeconds;
			if (effect.Timer >= maxNumberOfLastingSeconds)
			{
				IEnumerator enumerator3 = unit.LooseSkillEffect(effect, EffectWearsOffType.Expiration).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _3 = enumerator3.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		if (this._numberOfUnfinishedBattleEffectPerSecProcess.ContainsKey(effect))
		{
			Dictionary<BattleEffectBase, int> numberOfUnfinishedBattleEffectPerSecProcess;
			(numberOfUnfinishedBattleEffectPerSecProcess = this._numberOfUnfinishedBattleEffectPerSecProcess)[effect] = numberOfUnfinishedBattleEffectPerSecProcess[effect] - 1;
		}
		else
		{
			UnityEngine.Debug.LogError("Invalid effect per second workload!");
		}
		yield break;
	}

	// Token: 0x06001E01 RID: 7681 RVA: 0x000CD5AC File Offset: 0x000CB9AC
	private IEnumerable EncounterPerSecondProcess(double timer)
	{
		IEnumerable<IBattleUnit> playerUnits = this.PlayerUnits;
		if (BattleEncounter.<>f__mg$cache0 == null)
		{
			BattleEncounter.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
		}
		foreach (IBattleUnit un in playerUnits.Where(BattleEncounter.<>f__mg$cache0).ToList<IBattleUnit>())
		{
			IEnumerator enumerator2 = un.SelfEventCallback(un, AdventureEventType.AttributeCheckup, null).GetEnumerator();
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
		foreach (ISpecialEffectDataLoad dungeonEffects in this.CurrentAdventure.DungeonEffects)
		{
			if (dungeonEffects.GetSpecialEffectType().HasProcessor())
			{
				IEnumerator enumerator4 = dungeonEffects.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectPerSecondProcess(dungeonEffects, this).GetEnumerator();
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
		foreach (ISpecialEffectDataLoad playereffect in this.CurrentAdventure.PlayerEffects)
		{
			if (playereffect.GetSpecialEffectType().HasProcessor())
			{
				IEnumerator enumerator6 = playereffect.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectPerSecondProcess(playereffect, this).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _3 = enumerator6.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator6 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		foreach (IBattleUnit unit in this.PlayerUnits)
		{
			if (unit.IsAliveInBattle())
			{
				foreach (ISpecialEffectDataLoad playerunitSpecialEffect in unit.SpecialEffects)
				{
					if (playerunitSpecialEffect.GetSpecialEffectType().HasProcessor())
					{
						IEnumerator enumerator9 = playerunitSpecialEffect.GetSpecialEffectType().GetSpecialProcessor().AsActiveUnitPerSecondProcess(playerunitSpecialEffect, unit).GetEnumerator();
						try
						{
							while (enumerator9.MoveNext())
							{
								object _4 = enumerator9.Current;
								yield return _4;
							}
						}
						finally
						{
							IDisposable disposable4;
							if ((disposable4 = (enumerator9 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
				}
			}
			else
			{
				foreach (ISpecialEffectDataLoad playerunitSpecialEffect2 in unit.SpecialEffects)
				{
					if (playerunitSpecialEffect2.GetSpecialEffectType().HasProcessor())
					{
						IEnumerator enumerator11 = playerunitSpecialEffect2.GetSpecialEffectType().GetSpecialProcessor().AsInactiveUnitPerSecondProcess(playerunitSpecialEffect2, unit).GetEnumerator();
						try
						{
							while (enumerator11.MoveNext())
							{
								object _5 = enumerator11.Current;
								yield return _5;
							}
						}
						finally
						{
							IDisposable disposable5;
							if ((disposable5 = (enumerator11 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
				}
			}
		}
		foreach (IBattleUnit unit2 in this.EnemyUnits)
		{
			if (unit2.IsAliveInBattle())
			{
				foreach (ISpecialEffectDataLoad playerunitSpecialEffect3 in unit2.SpecialEffects)
				{
					if (playerunitSpecialEffect3.GetSpecialEffectType().HasProcessor())
					{
						IEnumerator enumerator14 = playerunitSpecialEffect3.GetSpecialEffectType().GetSpecialProcessor().AsActiveUnitPerSecondProcess(playerunitSpecialEffect3, unit2).GetEnumerator();
						try
						{
							while (enumerator14.MoveNext())
							{
								object _6 = enumerator14.Current;
								yield return _6;
							}
						}
						finally
						{
							IDisposable disposable6;
							if ((disposable6 = (enumerator14 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
				}
			}
			else
			{
				foreach (ISpecialEffectDataLoad playerunitSpecialEffect4 in unit2.SpecialEffects)
				{
					if (playerunitSpecialEffect4.GetSpecialEffectType().HasProcessor())
					{
						IEnumerator enumerator16 = playerunitSpecialEffect4.GetSpecialEffectType().GetSpecialProcessor().AsInactiveUnitPerSecondProcess(playerunitSpecialEffect4, unit2).GetEnumerator();
						try
						{
							while (enumerator16.MoveNext())
							{
								object _7 = enumerator16.Current;
								yield return _7;
							}
						}
						finally
						{
							IDisposable disposable7;
							if ((disposable7 = (enumerator16 as IDisposable)) != null)
							{
								disposable7.Dispose();
							}
						}
					}
				}
			}
		}
		this._numberOfUnfinishedEncounterPerSecProcess--;
		yield break;
	}

	// Token: 0x06001E02 RID: 7682 RVA: 0x000CD5D0 File Offset: 0x000CB9D0
	private IEnumerable InversedMandateProcess(IBattleUnit unit, List<InversedMandateData> inversedMandateEffect, InversedMandateEffectProcess iversedmandateProcess)
	{
		double turnProgressChangedPercentage = PlayerProfile.TurnSpeedbase * (double)Time.deltaTime * (1.0 + unit.GetSpeed(AttributeRetrievalLevel.Skill) / 20.0) / PlayerProfile.TurnSpeedGauge;
		foreach (InversedMandateData inversedMandateData in inversedMandateEffect)
		{
			IEnumerator enumerator2 = iversedmandateProcess.TurnChangeProcess(turnProgressChangedPercentage, inversedMandateData, unit, unit).GetEnumerator();
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
		this._inversedMandateInProcess = false;
		yield break;
	}

	// Token: 0x06001E03 RID: 7683 RVA: 0x000CD608 File Offset: 0x000CBA08
	private IEnumerable ConfusionExpiration(List<LockTimeEffect> timeLockEffects, IBattleUnit unit)
	{
		List<LockTimeEffect> expiredConfusions = (from ef in timeLockEffects
		where ef.MaxNumberOfLastingSeconds <= ef.Timer
		select ef).ToList<LockTimeEffect>();
		foreach (LockTimeEffect expiredConfusion in expiredConfusions)
		{
			IEnumerator enumerator2 = unit.LooseSkillEffect(expiredConfusion, EffectWearsOffType.Expiration).GetEnumerator();
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
		this._expiraConfusionInProgress = false;
		yield break;
	}

	// Token: 0x06001E04 RID: 7684 RVA: 0x000CD63C File Offset: 0x000CBA3C
	private IEnumerable DoTurnLogic(IBattleUnit unit, Dictionary<IBattleUnit, double> turnCounter)
	{
		turnCounter[unit] = 0.0;
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPriorTurnStart, null)).GetEnumerator();
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
		if (!unit.IsPlayer)
		{
			IBattleUnit nightBlade = this.PlayerUnits.FirstOrDefault((IBattleUnit u) => u.GetUnitType() == UnitClass.NightBlade);
			if (nightBlade != null)
			{
				NightBladeEnhancementData exclusive = nightBlade.SpecialEffects.OfType<NightBladeEnhancementData>().FirstOrDefault<NightBladeEnhancementData>();
				if (exclusive != null)
				{
					ReleaseableDamage releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
					{
						new BattleDamage(unit, new SpecialEffectTriggerSource(nightBlade, exclusive.GetSpecialEffectType()), new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(nightBlade, unit, OutputType.Physical, exclusive.DamageRate)
							}, unit, nightBlade, true, false)
						})
					}, nightBlade);
					IEnumerator enumerator2 = releaseableDamage.Release().GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _2 = enumerator2.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		if (!this.IsWinningConditionMet() && unit.Status == BattleUnitStatus.Active)
		{
			IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitRegularTurnStarts, null)).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _3 = enumerator3.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
			IEnumerator enumerator4 = unit.DoTurn().GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _4 = enumerator4.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator4 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
			IEnumerator enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitRegularTurnEnds, null)).GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object _5 = enumerator5.Current;
					yield return _5;
				}
			}
			finally
			{
				IDisposable disposable5;
				if ((disposable5 = (enumerator5 as IDisposable)) != null)
				{
					disposable5.Dispose();
				}
			}
		}
		this._doTurnInProgress = false;
		yield break;
	}

	// Token: 0x06001E05 RID: 7685 RVA: 0x000CD670 File Offset: 0x000CBA70
	public double GetMaxPlayerGauge()
	{
		double num = 100.0 - this.PlayerUnits.SelectMany((IBattleUnit p) => p.SpecialEffects).OfType<RageOccupyData>().Sum((RageOccupyData c) => c.Volum);
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	// Token: 0x06001E06 RID: 7686 RVA: 0x000CD6F1 File Offset: 0x000CBAF1
	public double GetMaxEnemyGauge()
	{
		return 100.0;
	}

	// Token: 0x06001E07 RID: 7687 RVA: 0x000CD6FC File Offset: 0x000CBAFC
	public IEnumerable UpdatePlayerGauge(double updateValue, IBattleEffectSource changeSource)
	{
		if (updateValue != 0.0)
		{
			double original = this.PlayerGauge;
			this.PlayerGauge += updateValue;
			if (this.PlayerGauge < 0.0)
			{
				this.PlayerGauge = 0.0;
			}
			if (this.PlayerGauge > this.GetMaxPlayerGauge())
			{
				this.PlayerGauge = this.GetMaxPlayerGauge();
			}
			if (original != this.PlayerGauge)
			{
				IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterPlayerGaugeUpdated, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					ChangeSource = changeSource,
					CurrentValue = this.PlayerGauge
				})).GetEnumerator();
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
			}
			if (original != this.GetMaxPlayerGauge() && this.PlayerGauge == this.GetMaxPlayerGauge())
			{
				IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterPlayerGaugeFullyCharged, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = this.PlayerGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			if (original == this.GetMaxPlayerGauge() && this.PlayerGauge != this.GetMaxPlayerGauge())
			{
				IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterPlayerGaugeReleased, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = this.PlayerGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _3 = enumerator3.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06001E08 RID: 7688 RVA: 0x000CD730 File Offset: 0x000CBB30
	public IEnumerable UpdateEnemyGauge(double updateValue, IBattleEffectSource changeSource)
	{
		if (updateValue != 0.0)
		{
			double original = this.EnemyGauge;
			this.EnemyGauge += updateValue;
			if (this.EnemyGauge < 0.0)
			{
				this.EnemyGauge = 0.0;
			}
			if (this.EnemyGauge > this.GetMaxEnemyGauge())
			{
				this.EnemyGauge = this.GetMaxEnemyGauge();
			}
			if (original != this.EnemyGauge)
			{
				IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterEnemyGaugeUpdated, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					ChangeSource = changeSource,
					CurrentValue = this.EnemyGauge
				})).GetEnumerator();
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
			}
			if (original != this.GetMaxEnemyGauge() && this.EnemyGauge == this.GetMaxEnemyGauge())
			{
				IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterEnemyGaugeFullyCharged, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = this.EnemyGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			if (original == this.GetMaxEnemyGauge() && this.EnemyGauge != this.GetMaxEnemyGauge())
			{
				IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterEnemyGaugeReleased, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = this.EnemyGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _3 = enumerator3.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06001E09 RID: 7689 RVA: 0x000CD761 File Offset: 0x000CBB61
	public bool IsPlayerWon()
	{
		return this.EnemyUnits.All((IBattleUnit u) => u.Status != BattleUnitStatus.Active);
	}

	// Token: 0x06001E0A RID: 7690 RVA: 0x000CD78C File Offset: 0x000CBB8C
	public bool IsPlayerLost()
	{
		return this.PlayerUnits.OfType<AdventurerBattleUnit>().All((AdventurerBattleUnit u) => u.Status == BattleUnitStatus.Dead) || this.PlayerUnits.First<IBattleUnit>().CurrentAdventure.Survivied == Adventure.SurvivalStatus.Lost || this.PlayerUnits.First<IBattleUnit>().CurrentAdventure.Survivied == Adventure.SurvivalStatus.Retreated;
	}

	// Token: 0x06001E0B RID: 7691 RVA: 0x000CD804 File Offset: 0x000CBC04
	public bool IsWinningConditionMet()
	{
		return this.IsPlayerWon() || this.IsPlayerLost();
	}

	// Token: 0x06001E0C RID: 7692 RVA: 0x000CD81A File Offset: 0x000CBC1A
	public List<IBattleUnit> GetOpponents(IBattleUnit unit)
	{
		if (unit.IsPlayer)
		{
			return this.EnemyUnits;
		}
		return this.PlayerUnits;
	}

	// Token: 0x06001E0D RID: 7693 RVA: 0x000CD834 File Offset: 0x000CBC34
	public List<IBattleUnit> GetAllFriendlyUnits(IBattleUnit unit)
	{
		if (unit.IsPlayer)
		{
			return this.PlayerUnits;
		}
		return this.EnemyUnits;
	}

	// Token: 0x06001E0E RID: 7694 RVA: 0x000CD850 File Offset: 0x000CBC50
	protected virtual void OnPlayerWon(List<IBattleUnit> obj)
	{
		Action<List<IBattleUnit>> playerWon = this.PlayerWon;
		if (playerWon != null)
		{
			playerWon(obj);
		}
	}

	// Token: 0x06001E0F RID: 7695 RVA: 0x000CD874 File Offset: 0x000CBC74
	protected virtual void OnPlayerLost(List<IBattleUnit> obj)
	{
		Action<List<IBattleUnit>> playerLost = this.PlayerLost;
		if (playerLost != null)
		{
			playerLost(obj);
		}
	}

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x06001E10 RID: 7696 RVA: 0x000CD895 File Offset: 0x000CBC95
	// (set) Token: 0x06001E11 RID: 7697 RVA: 0x000CD89D File Offset: 0x000CBC9D
	public bool IsCompleted
	{
		[CompilerGenerated]
		get
		{
			return this.<IsCompleted>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsCompleted>k__BackingField = value;
		}
	}

	// Token: 0x06001E12 RID: 7698 RVA: 0x000CD8A8 File Offset: 0x000CBCA8
	public IEnumerable CalculateDeadUnitRewards(IBattleUnit unit)
	{
		Adventure adventure = unit.CurrentAdventure;
		if (adventure.CorrespondingDifficultyMeasurement.StarRating != -1)
		{
			List<DropTypePresence> deathUnitDroptypePresences = new List<DropTypePresence>
			{
				new DropTypePresence
				{
					DropType = DropType.RawResources,
					Presence = 100
				}
			};
			DropConfiguration deadUnitDropConfiguration = new DropConfiguration(new List<ResourceType>(), new List<DropType>(), deathUnitDroptypePresences, new Dictionary<DropType, double>
			{
				{
					DropType.Gem,
					1.0
				}
			}, adventure.CorrespondingDifficultyMeasurement.GetDefaultItemGenerationDistribution(ResourceSourceType.DungeonDrop));
			if (unit is EnemyBattleUnit)
			{
				EnemyBattleUnit monster = unit as EnemyBattleUnit;
				DropTable baseDungeonTable = this.CurrentAdventure.CorrespondingDifficultyMeasurement.GetStandardDropableCompleteTable();
				List<double> hitsForUnit = adventure.CorrespondingDifficultyMeasurement.GetUnitDeathHits(monster);
				DropTable droptableForUnit = new DropTable(new List<DropTableParameter>());
				if (unit.IsBoss())
				{
					if (unit.CurrentEncounter.PlayerUnits.Any((IBattleUnit p) => p.SpecialEffects.OfType<BossMaterialDropData>().Any<BossMaterialDropData>()))
					{
						hitsForUnit.Add(1.0);
					}
				}
				droptableForUnit.CombineWith(baseDungeonTable);
				List<ResourceUpdate> drops = droptableForUnit.GetDrops_LuckRelevance(hitsForUnit, deadUnitDropConfiguration, adventure.CorrespondingDifficultyMeasurement);
				foreach (ResourceUpdate resourceUpdate in drops)
				{
					if (resourceUpdate.ResourceType.GetResourceCategory() == ResourceCategory.Ore)
					{
						double num = this.CurrentAdventure.Adventurers.Sum((AdventurerBattleUnit u) => u.GetAttributeValue_Final(AttributeType.Mining, AttributeRetrievalLevel.Skill)) + 1.0;
						if (num < 1.0)
						{
							num = 1.0;
						}
						int num2 = (int)Math.Round(resourceUpdate.ChangeAmount * num);
						resourceUpdate.ChangeAmount = (double)num2;
					}
					if (resourceUpdate.ResourceType.GetResourceCategory() == ResourceCategory.Hides)
					{
						double num3 = this.CurrentAdventure.Adventurers.Sum((AdventurerBattleUnit u) => u.GetAttributeValue_Final(AttributeType.Hunting, AttributeRetrievalLevel.Skill)) + 1.0;
						if (num3 < 1.0)
						{
							num3 = 1.0;
						}
						int num4 = (int)Math.Round(resourceUpdate.ChangeAmount * num3);
						resourceUpdate.ChangeAmount = (double)num4;
					}
				}
				MonsterUnitConfigurationBase monsterConfig = unit.GetUnitType().GetConfiguration() as MonsterUnitConfigurationBase;
				if (monsterConfig != null)
				{
					drops.AddRange(monsterConfig.GenerateGuarranteedDrops(adventure));
				}
				IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleUnitPreDrops, drops)).GetEnumerator();
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
				IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.EnemyUnitDropsLoot, drops)).GetEnumerator();
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
				this._drops.AddRange(drops);
			}
		}
		if (adventure.CorrespondingDifficultyMeasurement.StarRating == -1 && unit is EnemyBattleUnit)
		{
			EnemyBattleUnit monster2 = unit as EnemyBattleUnit;
			if (monster2.SlotSelection == AdventureEncounterSlotType.Boss)
			{
				List<ResourceUpdate> drops2 = new List<ResourceUpdate>();
				if ((double)UnityEngine.Random.value <= adventure.CorrespondingDifficultyMeasurement.GetAmuletChance())
				{
					drops2.AddRange(adventure.CorrespondingDifficultyMeasurement.GetAmuletDrop());
				}
				if ((double)UnityEngine.Random.value <= 0.12)
				{
					drops2.AddRange(this.CurrentAdventure.CorrespondingDifficultyMeasurement.GenerateRandomDevice());
				}
				if (drops2.Any<ResourceUpdate>())
				{
					IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleUnitPreDrops, drops2)).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _3 = enumerator4.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
					IEnumerator enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.EnemyUnitDropsLoot, drops2)).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _4 = enumerator5.Current;
							yield return _4;
						}
					}
					finally
					{
						IDisposable disposable4;
						if ((disposable4 = (enumerator5 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
					this._drops.AddRange(drops2);
				}
			}
		}
		yield break;
	}

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x06001E13 RID: 7699 RVA: 0x000CD8D2 File Offset: 0x000CBCD2
	// (set) Token: 0x06001E14 RID: 7700 RVA: 0x000CD8DA File Offset: 0x000CBCDA
	public Adventure CurrentAdventure
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentAdventure>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CurrentAdventure>k__BackingField = value;
		}
	}

	// Token: 0x06001E15 RID: 7701 RVA: 0x000CD8E4 File Offset: 0x000CBCE4
	public IEnumerable PerUpdateProcess(float deltaTime)
	{
		yield break;
	}

	// Token: 0x06001E16 RID: 7702 RVA: 0x000CD900 File Offset: 0x000CBD00
	public List<ResourceUpdate> GetCompletionRewards()
	{
		return this._drops;
	}

	// Token: 0x06001E17 RID: 7703 RVA: 0x000CD908 File Offset: 0x000CBD08
	[CompilerGenerated]
	private static IBattleUnit <get_PlayerUnits>m__0(IBattleUnit u)
	{
		return u;
	}

	// Token: 0x06001E18 RID: 7704 RVA: 0x000CD90B File Offset: 0x000CBD0B
	[CompilerGenerated]
	private static IBattleUnit <get_EnemyUnits>m__1(IBattleUnit u)
	{
		return u;
	}

	// Token: 0x06001E19 RID: 7705 RVA: 0x000CD90E File Offset: 0x000CBD0E
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetMaxPlayerGauge>m__2(IBattleUnit p)
	{
		return p.SpecialEffects;
	}

	// Token: 0x06001E1A RID: 7706 RVA: 0x000CD916 File Offset: 0x000CBD16
	[CompilerGenerated]
	private static double <GetMaxPlayerGauge>m__3(RageOccupyData c)
	{
		return c.Volum;
	}

	// Token: 0x06001E1B RID: 7707 RVA: 0x000CD91E File Offset: 0x000CBD1E
	[CompilerGenerated]
	private static bool <IsPlayerWon>m__4(IBattleUnit u)
	{
		return u.Status != BattleUnitStatus.Active;
	}

	// Token: 0x06001E1C RID: 7708 RVA: 0x000CD92C File Offset: 0x000CBD2C
	[CompilerGenerated]
	private static bool <IsPlayerLost>m__5(AdventurerBattleUnit u)
	{
		return u.Status == BattleUnitStatus.Dead;
	}

	// Token: 0x04001BB8 RID: 7096
	public string Id = Guid.NewGuid().ToString();

	// Token: 0x04001BB9 RID: 7097
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<List<IBattleUnit>> PlayerWon;

	// Token: 0x04001BBA RID: 7098
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<List<IBattleUnit>> PlayerLost;

	// Token: 0x04001BBB RID: 7099
	private bool _doTurnInProgress;

	// Token: 0x04001BBC RID: 7100
	private bool _expiraConfusionInProgress;

	// Token: 0x04001BBD RID: 7101
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <TacticInProgress>k__BackingField;

	// Token: 0x04001BBE RID: 7102
	private bool _inversedMandateInProcess;

	// Token: 0x04001BBF RID: 7103
	private int _numberOfUnfinishedEncounterPerSecProcess;

	// Token: 0x04001BC0 RID: 7104
	private Dictionary<BattleEffectBase, int> _numberOfUnfinishedBattleEffectPerSecProcess;

	// Token: 0x04001BC1 RID: 7105
	private Dictionary<AdventureUnitSkill, int> _numberOfUnfinishedSkillPerSecProcess;

	// Token: 0x04001BC2 RID: 7106
	public double EncounterTimer;

	// Token: 0x04001BC3 RID: 7107
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleLog <Log>k__BackingField;

	// Token: 0x04001BC4 RID: 7108
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <PlayerGauge>k__BackingField;

	// Token: 0x04001BC5 RID: 7109
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <EnemyGauge>k__BackingField;

	// Token: 0x04001BC6 RID: 7110
	public List<string> AdditionalBookKeeping = new List<string>();

	// Token: 0x04001BC7 RID: 7111
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<IBattleUnit, double> <TurnCounter>k__BackingField;

	// Token: 0x04001BC8 RID: 7112
	private List<IBattleUnit> _playerUnits;

	// Token: 0x04001BC9 RID: 7113
	private List<IBattleUnit> _enemyUnits;

	// Token: 0x04001BCA RID: 7114
	private List<ResourceUpdate> _drops;

	// Token: 0x04001BCB RID: 7115
	private List<StrategyRuleRuntime> AutoRules = new List<StrategyRuleRuntime>();

	// Token: 0x04001BCC RID: 7116
	private bool HasAutoSet;

	// Token: 0x04001BCD RID: 7117
	private int AutoIndex;

	// Token: 0x04001BCE RID: 7118
	public bool HasInitialized;

	// Token: 0x04001BCF RID: 7119
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsCompleted>k__BackingField;

	// Token: 0x04001BD0 RID: 7120
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Adventure <CurrentAdventure>k__BackingField;

	// Token: 0x04001BD1 RID: 7121
	[CompilerGenerated]
	private static Func<IBattleUnit, IBattleUnit> <>f__am$cache0;

	// Token: 0x04001BD2 RID: 7122
	[CompilerGenerated]
	private static Func<IBattleUnit, IBattleUnit> <>f__am$cache1;

	// Token: 0x04001BD3 RID: 7123
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x04001BD4 RID: 7124
	[CompilerGenerated]
	private static Func<IBattleUnit, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache2;

	// Token: 0x04001BD5 RID: 7125
	[CompilerGenerated]
	private static Func<RageOccupyData, double> <>f__am$cache3;

	// Token: 0x04001BD6 RID: 7126
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache4;

	// Token: 0x04001BD7 RID: 7127
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, bool> <>f__am$cache5;

	// Token: 0x02000CDB RID: 3291
	[CompilerGenerated]
	private sealed class <RemovePet>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054F5 RID: 21749 RVA: 0x000CD937 File Offset: 0x000CBD37
		[DebuggerHidden]
		public <RemovePet>c__Iterator0()
		{
		}

		// Token: 0x060054F6 RID: 21750 RVA: 0x000CD940 File Offset: 0x000CBD40
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!unit.IsPlayer)
				{
					enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.PetRemoving, null)).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.PetRemoving, null)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_100;
			case 3u:
				goto IL_1DB;
			case 4u:
				goto IL_276;
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
			enumerator2 = unit.LeavesEncounter().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_100:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			base.TurnCounter.Remove(unit);
			this._playerUnits.Remove(unit);
			goto IL_326;
			Block_5:
			try
			{
				IL_1DB:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			enumerator4 = unit.LeavesEncounter().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_276:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			base.TurnCounter.Remove(unit);
			this._enemyUnits.Remove(unit);
			IL_326:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001206 RID: 4614
		// (get) Token: 0x060054F7 RID: 21751 RVA: 0x000CDCB4 File Offset: 0x000CC0B4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001207 RID: 4615
		// (get) Token: 0x060054F8 RID: 21752 RVA: 0x000CDCBC File Offset: 0x000CC0BC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054F9 RID: 21753 RVA: 0x000CDCC4 File Offset: 0x000CC0C4
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060054FA RID: 21754 RVA: 0x000CDDF0 File Offset: 0x000CC1F0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054FB RID: 21755 RVA: 0x000CDDF7 File Offset: 0x000CC1F7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054FC RID: 21756 RVA: 0x000CDE00 File Offset: 0x000CC200
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<RemovePet>c__Iterator0 <RemovePet>c__Iterator = new BattleEncounter.<RemovePet>c__Iterator0();
			<RemovePet>c__Iterator.$this = this;
			<RemovePet>c__Iterator.unit = unit;
			return <RemovePet>c__Iterator;
		}

		// Token: 0x040042C1 RID: 17089
		internal PetBattleUnit unit;

		// Token: 0x040042C2 RID: 17090
		internal IEnumerator $locvar0;

		// Token: 0x040042C3 RID: 17091
		internal object <_>__1;

		// Token: 0x040042C4 RID: 17092
		internal IDisposable $locvar1;

		// Token: 0x040042C5 RID: 17093
		internal IEnumerator $locvar2;

		// Token: 0x040042C6 RID: 17094
		internal object <_>__2;

		// Token: 0x040042C7 RID: 17095
		internal IDisposable $locvar3;

		// Token: 0x040042C8 RID: 17096
		internal IEnumerator $locvar4;

		// Token: 0x040042C9 RID: 17097
		internal object <_>__3;

		// Token: 0x040042CA RID: 17098
		internal IDisposable $locvar5;

		// Token: 0x040042CB RID: 17099
		internal IEnumerator $locvar6;

		// Token: 0x040042CC RID: 17100
		internal object <_>__4;

		// Token: 0x040042CD RID: 17101
		internal IDisposable $locvar7;

		// Token: 0x040042CE RID: 17102
		internal BattleEncounter $this;

		// Token: 0x040042CF RID: 17103
		internal object $current;

		// Token: 0x040042D0 RID: 17104
		internal bool $disposing;

		// Token: 0x040042D1 RID: 17105
		internal int $PC;
	}

	// Token: 0x02000CDC RID: 3292
	[CompilerGenerated]
	private sealed class <AddPet>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054FD RID: 21757 RVA: 0x000CDE40 File Offset: 0x000CC240
		[DebuggerHidden]
		public <AddPet>c__Iterator1()
		{
		}

		// Token: 0x060054FE RID: 21758 RVA: 0x000CDE48 File Offset: 0x000CC248
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (unit.IsPlayer)
				{
					existingPet = base.PlayerUnits.OfType<PetBattleUnit>().FirstOrDefault<PetBattleUnit>();
					if (existingPet == null)
					{
						goto IL_106;
					}
					enumerator = base.RemovePet(existingPet).GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					existingPet2 = base.EnemyUnits.OfType<PetBattleUnit>().FirstOrDefault<PetBattleUnit>();
					if (existingPet2 != null)
					{
						enumerator7 = base.RemovePet(existingPet2).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
					goto IL_56B;
				}
				break;
			case 1u:
				break;
			case 2u:
				Block_11:
				try
				{
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						_2 = enumerator6.Current;
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
						if ((disposable2 = (enumerator6 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				goto IL_908;
			case 3u:
				goto IL_4E9;
			case 4u:
				Block_20:
				try
				{
					switch (num)
					{
					}
					if (enumerator12.MoveNext())
					{
						_4 = enumerator12.Current;
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
						if ((disposable4 = (enumerator12 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				goto IL_908;
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
			IL_106:
			base.TurnCounter.Add(unit, 0.0);
			this._playerUnits.Add(unit);
			adventure = unit.CurrentAdventure;
			if (adventure != null)
			{
				if (!adventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure.BattleEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>());
				}
				if (!adventure.BattleUnitSpecialEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure.BattleUnitSpecialEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>());
				}
				Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> dictionary = adventure.BattleUnitSpecialEffectsDictionary[unit.GetId()];
				foreach (ISpecialEffectDataLoad specialEffectDataLoad in unit.SpecialEffects)
				{
					if (specialEffectDataLoad.GetSpecialEffectType().HasProcessor())
					{
						SpecialEffectProcessBase specialProcessor = specialEffectDataLoad.GetSpecialEffectType().GetSpecialProcessor();
						foreach (AdventureEventType key in specialProcessor.CorrespondingEvents.Distinct<AdventureEventType>())
						{
							if (dictionary.ContainsKey(key))
							{
								dictionary[key].Add(specialEffectDataLoad);
							}
							else
							{
								dictionary.Add(key, new List<ISpecialEffectDataLoad>
								{
									specialEffectDataLoad
								});
							}
						}
					}
				}
				if (!adventure.SkillsDictionary.ContainsKey(unit.GetId()))
				{
					adventure.SkillsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<AdventureUnitSkill>>());
				}
				Dictionary<AdventureEventType, List<AdventureUnitSkill>> dictionary2 = adventure.SkillsDictionary[unit.GetId()];
				foreach (AdventureUnitSkill adventureUnitSkill in unit.Skills)
				{
					foreach (AdventureEventType key2 in adventureUnitSkill.GetSkillLogic().CorrespondingEvents().Distinct<AdventureEventType>())
					{
						if (dictionary2.ContainsKey(key2))
						{
							dictionary2[key2].Add(adventureUnitSkill);
						}
						else
						{
							dictionary2.Add(key2, new List<AdventureUnitSkill>
							{
								adventureUnitSkill
							});
						}
					}
				}
			}
			enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit.OwnerUnit, AdventureEventType.PetSummoned, unit)).GetEnumerator();
			num = 4294967293u;
			goto Block_11;
			Block_13:
			try
			{
				IL_4E9:
				switch (num)
				{
				}
				if (enumerator7.MoveNext())
				{
					_3 = enumerator7.Current;
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
					if ((disposable3 = (enumerator7 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_56B:
			base.TurnCounter.Add(unit, 0.0);
			this._enemyUnits.Add(unit);
			adventure2 = unit.CurrentAdventure;
			if (adventure2 != null)
			{
				if (!adventure2.BattleEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure2.BattleEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>());
				}
				if (!adventure2.BattleUnitSpecialEffectsDictionary.ContainsKey(unit.GetId()))
				{
					adventure2.BattleUnitSpecialEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>());
				}
				Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> dictionary3 = adventure2.BattleUnitSpecialEffectsDictionary[unit.GetId()];
				foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in unit.SpecialEffects)
				{
					if (specialEffectDataLoad2.GetSpecialEffectType().HasProcessor())
					{
						SpecialEffectProcessBase specialProcessor2 = specialEffectDataLoad2.GetSpecialEffectType().GetSpecialProcessor();
						foreach (AdventureEventType key3 in specialProcessor2.CorrespondingEvents.Distinct<AdventureEventType>())
						{
							if (dictionary3.ContainsKey(key3))
							{
								dictionary3[key3].Add(specialEffectDataLoad2);
							}
							else
							{
								dictionary3.Add(key3, new List<ISpecialEffectDataLoad>
								{
									specialEffectDataLoad2
								});
							}
						}
					}
				}
				if (!adventure2.SkillsDictionary.ContainsKey(unit.GetId()))
				{
					adventure2.SkillsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, List<AdventureUnitSkill>>());
				}
				Dictionary<AdventureEventType, List<AdventureUnitSkill>> dictionary4 = adventure2.SkillsDictionary[unit.GetId()];
				foreach (AdventureUnitSkill adventureUnitSkill2 in unit.Skills)
				{
					foreach (AdventureEventType key4 in adventureUnitSkill2.GetSkillLogic().CorrespondingEvents().Distinct<AdventureEventType>())
					{
						if (dictionary4.ContainsKey(key4))
						{
							dictionary4[key4].Add(adventureUnitSkill2);
						}
						else
						{
							dictionary4.Add(key4, new List<AdventureUnitSkill>
							{
								adventureUnitSkill2
							});
						}
					}
				}
			}
			enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit.OwnerUnit, AdventureEventType.PetSummoned, unit)).GetEnumerator();
			num = 4294967293u;
			goto Block_20;
			IL_908:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001208 RID: 4616
		// (get) Token: 0x060054FF RID: 21759 RVA: 0x000CE7FC File Offset: 0x000CCBFC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001209 RID: 4617
		// (get) Token: 0x06005500 RID: 21760 RVA: 0x000CE804 File Offset: 0x000CCC04
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005501 RID: 21761 RVA: 0x000CE80C File Offset: 0x000CCC0C
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
				}
				finally
				{
					if ((disposable2 = (enumerator6 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator7 as IDisposable)) != null)
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
					if ((disposable4 = (enumerator12 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005502 RID: 21762 RVA: 0x000CE938 File Offset: 0x000CCD38
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005503 RID: 21763 RVA: 0x000CE93F File Offset: 0x000CCD3F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005504 RID: 21764 RVA: 0x000CE948 File Offset: 0x000CCD48
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<AddPet>c__Iterator1 <AddPet>c__Iterator = new BattleEncounter.<AddPet>c__Iterator1();
			<AddPet>c__Iterator.$this = this;
			<AddPet>c__Iterator.unit = unit;
			return <AddPet>c__Iterator;
		}

		// Token: 0x040042D2 RID: 17106
		internal PetBattleUnit unit;

		// Token: 0x040042D3 RID: 17107
		internal PetBattleUnit <existingPet>__1;

		// Token: 0x040042D4 RID: 17108
		internal IEnumerator $locvar0;

		// Token: 0x040042D5 RID: 17109
		internal object <_>__2;

		// Token: 0x040042D6 RID: 17110
		internal IDisposable $locvar1;

		// Token: 0x040042D7 RID: 17111
		internal Adventure <adventure>__1;

		// Token: 0x040042D8 RID: 17112
		internal IEnumerator $locvar6;

		// Token: 0x040042D9 RID: 17113
		internal object <_>__3;

		// Token: 0x040042DA RID: 17114
		internal IDisposable $locvar7;

		// Token: 0x040042DB RID: 17115
		internal PetBattleUnit <existingPet>__4;

		// Token: 0x040042DC RID: 17116
		internal IEnumerator $locvar8;

		// Token: 0x040042DD RID: 17117
		internal object <_>__5;

		// Token: 0x040042DE RID: 17118
		internal IDisposable $locvar9;

		// Token: 0x040042DF RID: 17119
		internal Adventure <adventure>__4;

		// Token: 0x040042E0 RID: 17120
		internal IEnumerator $locvarE;

		// Token: 0x040042E1 RID: 17121
		internal object <_>__6;

		// Token: 0x040042E2 RID: 17122
		internal IDisposable $locvarF;

		// Token: 0x040042E3 RID: 17123
		internal BattleEncounter $this;

		// Token: 0x040042E4 RID: 17124
		internal object $current;

		// Token: 0x040042E5 RID: 17125
		internal bool $disposing;

		// Token: 0x040042E6 RID: 17126
		internal int $PC;
	}

	// Token: 0x02000CDD RID: 3293
	[CompilerGenerated]
	private sealed class <TryAutoRun>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005505 RID: 21765 RVA: 0x000CE988 File Offset: 0x000CCD88
		[DebuggerHidden]
		public <TryAutoRun>c__Iterator2()
		{
		}

		// Token: 0x06005506 RID: 21766 RVA: 0x000CE990 File Offset: 0x000CCD90
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!this.HasAutoSet || base.CurrentAdventure.AutoTacticPause || !this.HasInitialized)
				{
					goto IL_1FC;
				}
				if (this.AutoIndex >= this.AutoRules.Count)
				{
					this.AutoIndex = 0;
				}
				if (this.AutoIndex >= this.AutoRules.Count)
				{
					goto IL_1FC;
				}
				rule = this.AutoRules[this.AutoIndex];
				skill = (rule.Skill.GetSkillLogic() as ActiveSkillLogicBase);
				if (!rule.Skill.SourceUnit.IsAliveInBattle())
				{
					this.AutoIndex++;
					goto IL_1FC;
				}
				if (!skill.IsAutoCastable(rule.Skill))
				{
					goto IL_1E4;
				}
				enumerator = skill.AutoCast(rule.CandidateOrderringMetric, rule.OrderingType, rule.Skill).GetEnumerator();
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
			this.AutoIndex++;
			IL_1E4:
			IL_1FC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700120A RID: 4618
		// (get) Token: 0x06005507 RID: 21767 RVA: 0x000CEBB4 File Offset: 0x000CCFB4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700120B RID: 4619
		// (get) Token: 0x06005508 RID: 21768 RVA: 0x000CEBBC File Offset: 0x000CCFBC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005509 RID: 21769 RVA: 0x000CEBC4 File Offset: 0x000CCFC4
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

		// Token: 0x0600550A RID: 21770 RVA: 0x000CEC34 File Offset: 0x000CD034
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600550B RID: 21771 RVA: 0x000CEC3B File Offset: 0x000CD03B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600550C RID: 21772 RVA: 0x000CEC44 File Offset: 0x000CD044
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<TryAutoRun>c__Iterator2 <TryAutoRun>c__Iterator = new BattleEncounter.<TryAutoRun>c__Iterator2();
			<TryAutoRun>c__Iterator.$this = this;
			return <TryAutoRun>c__Iterator;
		}

		// Token: 0x040042E7 RID: 17127
		internal StrategyRuleRuntime <rule>__1;

		// Token: 0x040042E8 RID: 17128
		internal ActiveSkillLogicBase <skill>__1;

		// Token: 0x040042E9 RID: 17129
		internal IEnumerator $locvar0;

		// Token: 0x040042EA RID: 17130
		internal object <_>__2;

		// Token: 0x040042EB RID: 17131
		internal IDisposable $locvar1;

		// Token: 0x040042EC RID: 17132
		internal BattleEncounter $this;

		// Token: 0x040042ED RID: 17133
		internal object $current;

		// Token: 0x040042EE RID: 17134
		internal bool $disposing;

		// Token: 0x040042EF RID: 17135
		internal int $PC;
	}

	// Token: 0x02000CDE RID: 3294
	[CompilerGenerated]
	private sealed class <Run>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600550D RID: 21773 RVA: 0x000CEC78 File Offset: 0x000CD078
		[DebuggerHidden]
		public <Run>c__Iterator3()
		{
		}

		// Token: 0x0600550E RID: 21774 RVA: 0x000CEC80 File Offset: 0x000CD080
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this._doTurnInProgress = false;
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(base.PlayerUnits.FirstOrDefault<IBattleUnit>(), AdventureEventType.BattleEncounterStarts, this)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_33F;
			case 3u:
				goto IL_452;
			case 4u:
				goto IL_571;
			case 5u:
				goto IL_684;
			case 6u:
				goto IL_7B3;
			case 7u:
				goto IL_8FC;
			case 8u:
				goto IL_AE8;
			case 9u:
				Block_27:
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
				goto IL_C5E;
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
				Block_28:
				try
				{
					switch (num)
					{
					case 10u:
						Block_140:
						try
						{
							switch (num)
							{
							}
							if (enumerator19.MoveNext())
							{
								_10 = enumerator19.Current;
								this.$current = _10;
								if (!this.$disposing)
								{
									this.$PC = 10;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable10 = (enumerator19 as IDisposable)) != null)
								{
									disposable10.Dispose();
								}
							}
						}
						break;
					case 11u:
						Block_142:
						try
						{
							switch (num)
							{
							case 11u:
								Block_163:
								try
								{
									switch (num)
									{
									}
									if (enumerator21.MoveNext())
									{
										_11 = enumerator21.Current;
										this.$current = _11;
										if (!this.$disposing)
										{
											this.$PC = 11;
										}
										flag = true;
										return true;
									}
								}
								finally
								{
									if (!flag)
									{
										if ((disposable11 = (enumerator21 as IDisposable)) != null)
										{
											disposable11.Dispose();
										}
									}
								}
								break;
							}
							while (enumerator20.MoveNext())
							{
								effect = enumerator20.Current;
								prsbTm = (int)effect.Timer;
								effect.Timer += Time.deltaTime;
								crtbTm = (int)effect.Timer;
								if (crtbTm > prsbTm)
								{
									if (this._numberOfUnfinishedBattleEffectPerSecProcess.ContainsKey(effect))
									{
										Dictionary<BattleEffectBase, int> numberOfUnfinishedBattleEffectPerSecProcess;
										BattleEffectBase key;
										(numberOfUnfinishedBattleEffectPerSecProcess = this._numberOfUnfinishedBattleEffectPerSecProcess)[key = effect] = numberOfUnfinishedBattleEffectPerSecProcess[key] + 1;
									}
									else
									{
										this._numberOfUnfinishedBattleEffectPerSecProcess.Add(effect, 1);
									}
									if (!(effect is DamageOverTimeEffect) && !(effect is LifeExtractionEffect) && !(effect is ShieldBurnEffect))
									{
										enumerator21 = base.BattleEffectPerSecondProcess(unit, effect).GetEnumerator();
										num = 4294967293u;
										goto Block_163;
									}
									if (dots.ContainsKey(unit))
									{
										dots[unit].Add(effect);
									}
									else
									{
										dots.Add(unit, new List<BattleEffectBase>
										{
											effect
										});
									}
								}
							}
						}
						finally
						{
							if (!flag)
							{
								((IDisposable)enumerator20).Dispose();
							}
						}
						skills = (from s in unit.Skills
						select s).ToList<AdventureUnitSkill>();
						enumerator22 = skills.GetEnumerator();
						num = 4294967293u;
						goto Block_144;
					case 12u:
					case 13u:
						goto IL_120A;
					case 14u:
						goto IL_15A4;
					default:
						goto IL_1628;
					}
					IL_F3E:
					effects = (from b in unit.BattleEffects
					select b).ToList<BattleEffectBase>();
					enumerator20 = effects.GetEnumerator();
					num = 4294967293u;
					goto Block_142;
					Block_144:
					try
					{
						IL_120A:
						switch (num)
						{
						case 12u:
							Block_176:
							try
							{
								switch (num)
								{
								}
								if (enumerator23.MoveNext())
								{
									_12 = enumerator23.Current;
									this.$current = _12;
									if (!this.$disposing)
									{
										this.$PC = 12;
									}
									flag = true;
									return true;
								}
							}
							finally
							{
								if (!flag)
								{
									if ((disposable12 = (enumerator23 as IDisposable)) != null)
									{
										disposable12.Dispose();
									}
								}
							}
							break;
						case 13u:
							Block_183:
							try
							{
								switch (num)
								{
								}
								if (enumerator24.MoveNext())
								{
									_13 = enumerator24.Current;
									this.$current = _13;
									if (!this.$disposing)
									{
										this.$PC = 13;
									}
									flag = true;
									return true;
								}
							}
							finally
							{
								if (!flag)
								{
									if ((disposable13 = (enumerator24 as IDisposable)) != null)
									{
										disposable13.Dispose();
									}
								}
							}
							goto IL_1538;
						default:
							goto IL_1538;
						}
						IL_1384:
						if (skill.RemainingCoolingDownSeconds != null && skill.RemainingCoolingDownSeconds.Value > 0f)
						{
							AdventureUnitSkill adventureUnitSkill = skill;
							float? remainingCoolingDownSeconds = adventureUnitSkill.RemainingCoolingDownSeconds;
							adventureUnitSkill.RemainingCoolingDownSeconds = ((remainingCoolingDownSeconds == null) ? null : new float?(remainingCoolingDownSeconds.GetValueOrDefault() - Time.deltaTime));
							if (skill.RemainingCoolingDownSeconds <= 0f)
							{
								skill.RemainingCoolingDownSeconds = new float?(0f);
								if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
								{
									Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
									AdventureUnitSkill key2;
									(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[key2 = skill] = numberOfUnfinishedSkillPerSecProcess[key2] + 1;
								}
								else
								{
									this._numberOfUnfinishedSkillPerSecProcess.Add(skill, 1);
								}
								enumerator24 = base.SkillCoolingDownLogic(skill).GetEnumerator();
								num = 4294967293u;
								goto Block_183;
							}
						}
						IL_1538:
						if (enumerator22.MoveNext())
						{
							skill = enumerator22.Current;
							prsStim = (int)skill.Timer;
							skill.Timer += Time.deltaTime;
							crtStime = (int)skill.Timer;
							if (crtStime > prsStim)
							{
								if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
								{
									Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
									AdventureUnitSkill key3;
									(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[key3 = skill] = numberOfUnfinishedSkillPerSecProcess[key3] + 1;
								}
								else
								{
									this._numberOfUnfinishedSkillPerSecProcess.Add(skill, 1);
								}
								enumerator23 = base.SkillPerSecondProcess(unit, skill).GetEnumerator();
								num = 4294967293u;
								goto Block_176;
							}
							goto IL_1384;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator22).Dispose();
						}
					}
					if (this._expiraConfusionInProgress)
					{
						goto IL_1628;
					}
					this._expiraConfusionInProgress = true;
					enumerator25 = base.ConfusionExpiration(timeLockEffects, unit).GetEnumerator();
					num = 4294967293u;
					try
					{
						IL_15A4:
						switch (num)
						{
						}
						if (enumerator25.MoveNext())
						{
							_14 = enumerator25.Current;
							this.$current = _14;
							if (!this.$disposing)
							{
								this.$PC = 14;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable14 = (enumerator25 as IDisposable)) != null)
							{
								disposable14.Dispose();
							}
						}
					}
					IL_1628:
					if (enumerator17.MoveNext())
					{
						unit = enumerator17.Current;
						timeLockEffects = unit.BattleEffects.OfType<LockTimeEffect>().ToList<LockTimeEffect>();
						activeConfusions = (from ef in timeLockEffects
						where ef.MaxNumberOfLastingSeconds > ef.Timer
						select ef).ToList<LockTimeEffect>();
						if (activeConfusions.Any<LockTimeEffect>())
						{
							foreach (LockTimeEffect lockTimeEffect in activeConfusions)
							{
								lockTimeEffect.Timer += Time.deltaTime * Time.timeScale;
							}
							goto IL_F3E;
						}
						if (!unit.IsTurnRelevant() || !turnCounter.ContainsKey(unit))
						{
							goto IL_F3E;
						}
						speedBase = 20.0;
						if (base.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == -1 && base.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 2000.0)
						{
							speedBase = 30.0;
						}
						Dictionary<IBattleUnit, double> dictionary;
						IBattleUnit key4;
						(dictionary = turnCounter)[key4 = unit] = dictionary[key4] + PlayerProfile.TurnSpeedbase * (double)Time.deltaTime * (1.0 + unit.GetSpeed(AttributeRetrievalLevel.Skill) / speedBase);
						inversedMandateEffect = unit.SpecialEffects.OfType<InversedMandateData>().ToList<InversedMandateData>();
						if (inversedMandateEffect.Any<InversedMandateData>() && iversedmandateProcess != null && !this._inversedMandateInProcess)
						{
							this._inversedMandateInProcess = true;
							enumerator19 = base.InversedMandateProcess(unit, inversedMandateEffect, iversedmandateProcess).GetEnumerator();
							num = 4294967293u;
							goto Block_140;
						}
						goto IL_F3E;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator17).Dispose();
					}
				}
				enumerator26 = base.DamageOverTimePerSecondProcess(dots).GetEnumerator();
				num = 4294967293u;
				goto Block_29;
			case 15u:
				goto IL_1672;
			case 16u:
				IL_1712:
				if (base.IsWinningConditionMet())
				{
					goto IL_1722;
				}
				units = new List<IBattleUnit>();
				units.AddRange(base.PlayerUnits);
				units.AddRange(base.EnemyUnits);
				if (this._doTurnInProgress || base.TacticInProgress || (base.CurrentAdventure.RunePower != null && base.CurrentAdventure.RunePower._processInTurn))
				{
					goto IL_16F6;
				}
				firstUnit = (from u in units
				where base.TurnCounter.ContainsKey(u) && base.TurnCounter[u] >= PlayerProfile.TurnSpeedGauge && u.IsTurnRelevant() && u.CanAct()
				orderby u.GetSpeed(AttributeRetrievalLevel.Skill) descending
				select u).FirstOrDefault<IBattleUnit>();
				if (firstUnit != null && base.TurnCounter.ContainsKey(firstUnit) && base.TurnCounter[firstUnit] >= PlayerProfile.TurnSpeedGauge)
				{
					this._doTurnInProgress = true;
					enumerator15 = base.DoTurnLogic(firstUnit, turnCounter).GetEnumerator();
					num = 4294967293u;
					goto Block_25;
				}
				goto IL_B6A;
			case 17u:
				IL_1743:
				if (!this._doTurnInProgress && !this._expiraConfusionInProgress && !base.TacticInProgress && this._numberOfUnfinishedEncounterPerSecProcess <= 0)
				{
					if (!this._numberOfUnfinishedBattleEffectPerSecProcess.Values.Any((int v) => v > 0))
					{
						if (!this._numberOfUnfinishedSkillPerSecProcess.Values.Any((int v) => v > 0))
						{
							this._numberOfUnfinishedBattleEffectPerSecProcess.Clear();
							base.IsCompleted = true;
							enumerator27 = base.PlayerUnits.GetEnumerator();
							try
							{
								while (enumerator27.MoveNext())
								{
									IBattleUnit battleUnit3 = enumerator27.Current;
									foreach (AdventureUnitSkill adventureUnitSkill2 in battleUnit3.Skills)
									{
										adventureUnitSkill2.PassiveHasBeenRecentlyApplied = false;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator27).Dispose();
							}
							enumerator29 = base.EnemyUnits.GetEnumerator();
							try
							{
								while (enumerator29.MoveNext())
								{
									IBattleUnit battleUnit4 = enumerator29.Current;
									foreach (AdventureUnitSkill adventureUnitSkill3 in battleUnit4.Skills)
									{
										adventureUnitSkill3.PassiveHasBeenRecentlyApplied = false;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator29).Dispose();
							}
							if (base.IsPlayerWon())
							{
								this.OnPlayerWon(base.PlayerUnits);
							}
							else if (base.IsPlayerLost())
							{
								this.OnPlayerLost(base.PlayerUnits);
							}
							this.$PC = -1;
							return false;
						}
					}
				}
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 17;
				}
				return true;
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
			this.AutoRules = new List<StrategyRuleRuntime>();
			if (base.CurrentAdventure.AutoTacticRules != null && base.CurrentAdventure.AutoTacticRules.Any<StrategyRule>())
			{
				using (List<StrategyRule>.Enumerator enumerator33 = base.CurrentAdventure.AutoTacticRules.GetEnumerator())
				{
					while (enumerator33.MoveNext())
					{
						StrategyRule currentAdventureAutoTacticRule = enumerator33.Current;
						IBattleUnit battleUnit5 = base.PlayerUnits.FirstOrDefault((IBattleUnit u) => u.GetId() == currentAdventureAutoTacticRule.AdventurerId);
						if (battleUnit5 != null && battleUnit5 is AdventurerBattleUnit)
						{
							this.AutoRules.Add(StrategyRuleRuntime.CreateRuntimeRule(battleUnit5 as AdventurerBattleUnit, currentAdventureAutoTacticRule));
						}
					}
				}
			}
			this.HasAutoSet = this.AutoRules.Any<StrategyRuleRuntime>();
			if (base.IsWinningConditionMet())
			{
				goto IL_1722;
			}
			turnCounter = base.TurnCounter;
			enumerator3 = base.PlayerUnits.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					IBattleUnit key5 = enumerator3.Current;
					turnCounter.Add(key5, 0.0);
				}
			}
			finally
			{
				((IDisposable)enumerator3).Dispose();
			}
			enumerator4 = base.EnemyUnits.GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					IBattleUnit key6 = enumerator4.Current;
					turnCounter.Add(key6, 0.0);
				}
			}
			finally
			{
				((IDisposable)enumerator4).Dispose();
			}
			timer = 0.0;
			enumerator5 = base.PlayerUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_33F:
				switch (num)
				{
				case 2u:
					Block_62:
					try
					{
						switch (num)
						{
						}
						if (enumerator6.MoveNext())
						{
							_2 = enumerator6.Current;
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
							if ((disposable2 = (enumerator6 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator5.MoveNext())
				{
					playerUnit = enumerator5.Current;
					enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(playerUnit, AdventureEventType.UnitReadyInBattle, this)).GetEnumerator();
					num = 4294967293u;
					goto Block_62;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			enumerator7 = base.EnemyUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_452:
				switch (num)
				{
				case 3u:
					Block_73:
					try
					{
						switch (num)
						{
						}
						if (enumerator8.MoveNext())
						{
							_3 = enumerator8.Current;
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
							if ((disposable3 = (enumerator8 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator7.MoveNext())
				{
					battleUnit = enumerator7.Current;
					enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(battleUnit, AdventureEventType.UnitReadyInBattle, this)).GetEnumerator();
					num = 4294967293u;
					goto Block_73;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator7).Dispose();
				}
			}
			this.HasInitialized = true;
			enumerator9 = base.PlayerUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_571:
				switch (num)
				{
				case 4u:
					Block_84:
					try
					{
						switch (num)
						{
						}
						if (enumerator10.MoveNext())
						{
							_4 = enumerator10.Current;
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
							if ((disposable4 = (enumerator10 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator9.MoveNext())
				{
					playerUnit2 = enumerator9.Current;
					enumerator10 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(playerUnit2, AdventureEventType.TurnSetupCompleted, this)).GetEnumerator();
					num = 4294967293u;
					goto Block_84;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator9).Dispose();
				}
			}
			enumerator11 = base.EnemyUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_684:
				switch (num)
				{
				case 5u:
					Block_95:
					try
					{
						switch (num)
						{
						}
						if (enumerator12.MoveNext())
						{
							_5 = enumerator12.Current;
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
							if ((disposable5 = (enumerator12 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator11.MoveNext())
				{
					battleUnit2 = enumerator11.Current;
					enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(battleUnit2, AdventureEventType.TurnSetupCompleted, this)).GetEnumerator();
					num = 4294967293u;
					goto Block_95;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator11).Dispose();
				}
			}
			enumerator13 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(base.PlayerUnits.FirstOrDefault<IBattleUnit>(), AdventureEventType.EncounterSetupCompleted, this)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_7B3:
				switch (num)
				{
				}
				if (enumerator13.MoveNext())
				{
					_6 = enumerator13.Current;
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
					if ((disposable6 = (enumerator13 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			if (base.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating != -1 || base.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 700.0)
			{
				base.CurrentAdventure.ActionCountSoFar = new double?(0.0);
				base.CurrentAdventure.ActionCountPossible = new double?(Adventure.CalculateMaxActionCounts(260.0, base.CurrentAdventure.Adventurers));
			}
			if (base.CurrentAdventure.RunePower == null)
			{
				goto IL_97E;
			}
			enumerator14 = base.CurrentAdventure.RunePower.TryRun().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_8FC:
				switch (num)
				{
				}
				if (enumerator14.MoveNext())
				{
					_7 = enumerator14.Current;
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
					if ((disposable7 = (enumerator14 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
			}
			IL_97E:
			iversedmandateProcess = ((!SpecialEffectType.InversedMandate.HasProcessor()) ? null : (SpecialEffectType.InversedMandate.GetSpecialProcessor() as InversedMandateEffectProcess));
			goto IL_1712;
			Block_25:
			try
			{
				IL_AE8:
				switch (num)
				{
				}
				if (enumerator15.MoveNext())
				{
					_8 = enumerator15.Current;
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
					if ((disposable8 = (enumerator15 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
			}
			IL_B6A:
			prvTime = (int)timer;
			timer += (double)Time.deltaTime;
			crtTime = (int)timer;
			if (crtTime > prvTime)
			{
				this._numberOfUnfinishedEncounterPerSecProcess++;
				enumerator16 = base.EncounterPerSecondProcess(timer).GetEnumerator();
				num = 4294967293u;
				goto Block_27;
			}
			IL_C5E:
			dots = new Dictionary<IBattleUnit, List<BattleEffectBase>>();
			enumerator17 = turnCounter.Keys.ToList<IBattleUnit>().GetEnumerator();
			num = 4294967293u;
			goto Block_28;
			Block_29:
			try
			{
				IL_1672:
				switch (num)
				{
				}
				if (enumerator26.MoveNext())
				{
					_15 = enumerator26.Current;
					this.$current = _15;
					if (!this.$disposing)
					{
						this.$PC = 15;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable15 = (enumerator26 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
			}
			IL_16F6:
			this.$current = null;
			if (!this.$disposing)
			{
				this.$PC = 16;
			}
			return true;
			IL_1722:
			goto IL_1743;
		}

		// Token: 0x1700120C RID: 4620
		// (get) Token: 0x0600550F RID: 21775 RVA: 0x000D08F0 File Offset: 0x000CECF0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700120D RID: 4621
		// (get) Token: 0x06005510 RID: 21776 RVA: 0x000D08F8 File Offset: 0x000CECF8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005511 RID: 21777 RVA: 0x000D0900 File Offset: 0x000CED00
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
						if ((disposable2 = (enumerator6 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			case 3u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator8 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator7).Dispose();
				}
				break;
			case 4u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable4 = (enumerator10 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator9).Dispose();
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
						if ((disposable5 = (enumerator12 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator11).Dispose();
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator13 as IDisposable)) != null)
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
					if ((disposable7 = (enumerator14 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				break;
			case 8u:
				try
				{
				}
				finally
				{
					if ((disposable8 = (enumerator15 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
				break;
			case 9u:
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
				break;
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
				try
				{
					switch (num)
					{
					case 10u:
						try
						{
						}
						finally
						{
							if ((disposable10 = (enumerator19 as IDisposable)) != null)
							{
								disposable10.Dispose();
							}
						}
						break;
					case 11u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable11 = (enumerator21 as IDisposable)) != null)
								{
									disposable11.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator20).Dispose();
						}
						break;
					case 12u:
					case 13u:
						try
						{
							switch (num)
							{
							case 12u:
								try
								{
								}
								finally
								{
									if ((disposable12 = (enumerator23 as IDisposable)) != null)
									{
										disposable12.Dispose();
									}
								}
								break;
							case 13u:
								try
								{
								}
								finally
								{
									if ((disposable13 = (enumerator24 as IDisposable)) != null)
									{
										disposable13.Dispose();
									}
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator22).Dispose();
						}
						break;
					case 14u:
						try
						{
						}
						finally
						{
							if ((disposable14 = (enumerator25 as IDisposable)) != null)
							{
								disposable14.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator17).Dispose();
				}
				break;
			case 15u:
				try
				{
				}
				finally
				{
					if ((disposable15 = (enumerator26 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005512 RID: 21778 RVA: 0x000D0F20 File Offset: 0x000CF320
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005513 RID: 21779 RVA: 0x000D0F27 File Offset: 0x000CF327
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005514 RID: 21780 RVA: 0x000D0F30 File Offset: 0x000CF330
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<Run>c__Iterator3 <Run>c__Iterator = new BattleEncounter.<Run>c__Iterator3();
			<Run>c__Iterator.$this = this;
			return <Run>c__Iterator;
		}

		// Token: 0x06005515 RID: 21781 RVA: 0x000D0F64 File Offset: 0x000CF364
		internal bool <>m__0(IBattleUnit u)
		{
			return base.TurnCounter.ContainsKey(u) && base.TurnCounter[u] >= PlayerProfile.TurnSpeedGauge && u.IsTurnRelevant() && u.CanAct();
		}

		// Token: 0x06005516 RID: 21782 RVA: 0x000D0FB6 File Offset: 0x000CF3B6
		private static double <>m__1(IBattleUnit u)
		{
			return u.GetSpeed(AttributeRetrievalLevel.Skill);
		}

		// Token: 0x06005517 RID: 21783 RVA: 0x000D0FC0 File Offset: 0x000CF3C0
		private static bool <>m__2(LockTimeEffect ef)
		{
			return ef.MaxNumberOfLastingSeconds > ef.Timer;
		}

		// Token: 0x06005518 RID: 21784 RVA: 0x000D0FF2 File Offset: 0x000CF3F2
		private static BattleEffectBase <>m__3(BattleEffectBase b)
		{
			return b;
		}

		// Token: 0x06005519 RID: 21785 RVA: 0x000D0FF5 File Offset: 0x000CF3F5
		private static AdventureUnitSkill <>m__4(AdventureUnitSkill s)
		{
			return s;
		}

		// Token: 0x0600551A RID: 21786 RVA: 0x000D0FF8 File Offset: 0x000CF3F8
		private static bool <>m__5(int v)
		{
			return v > 0;
		}

		// Token: 0x0600551B RID: 21787 RVA: 0x000D0FFE File Offset: 0x000CF3FE
		private static bool <>m__6(int v)
		{
			return v > 0;
		}

		// Token: 0x040042F0 RID: 17136
		internal IEnumerator $locvar0;

		// Token: 0x040042F1 RID: 17137
		internal object <_>__1;

		// Token: 0x040042F2 RID: 17138
		internal IDisposable $locvar1;

		// Token: 0x040042F3 RID: 17139
		internal Dictionary<IBattleUnit, double> <turnCounter>__2;

		// Token: 0x040042F4 RID: 17140
		internal List<IBattleUnit>.Enumerator $locvar3;

		// Token: 0x040042F5 RID: 17141
		internal List<IBattleUnit>.Enumerator $locvar4;

		// Token: 0x040042F6 RID: 17142
		internal double <timer>__2;

		// Token: 0x040042F7 RID: 17143
		internal List<IBattleUnit>.Enumerator $locvar5;

		// Token: 0x040042F8 RID: 17144
		internal IBattleUnit <playerUnit>__3;

		// Token: 0x040042F9 RID: 17145
		internal IEnumerator $locvar6;

		// Token: 0x040042FA RID: 17146
		internal object <_>__4;

		// Token: 0x040042FB RID: 17147
		internal IDisposable $locvar7;

		// Token: 0x040042FC RID: 17148
		internal List<IBattleUnit>.Enumerator $locvar8;

		// Token: 0x040042FD RID: 17149
		internal IBattleUnit <battleUnit>__5;

		// Token: 0x040042FE RID: 17150
		internal IEnumerator $locvar9;

		// Token: 0x040042FF RID: 17151
		internal object <_>__6;

		// Token: 0x04004300 RID: 17152
		internal IDisposable $locvarA;

		// Token: 0x04004301 RID: 17153
		internal List<IBattleUnit>.Enumerator $locvarB;

		// Token: 0x04004302 RID: 17154
		internal IBattleUnit <playerUnit>__7;

		// Token: 0x04004303 RID: 17155
		internal IEnumerator $locvarC;

		// Token: 0x04004304 RID: 17156
		internal object <_>__8;

		// Token: 0x04004305 RID: 17157
		internal IDisposable $locvarD;

		// Token: 0x04004306 RID: 17158
		internal List<IBattleUnit>.Enumerator $locvarE;

		// Token: 0x04004307 RID: 17159
		internal IBattleUnit <battleUnit>__9;

		// Token: 0x04004308 RID: 17160
		internal IEnumerator $locvarF;

		// Token: 0x04004309 RID: 17161
		internal object <_>__10;

		// Token: 0x0400430A RID: 17162
		internal IDisposable $locvar10;

		// Token: 0x0400430B RID: 17163
		internal IEnumerator $locvar11;

		// Token: 0x0400430C RID: 17164
		internal object <_>__11;

		// Token: 0x0400430D RID: 17165
		internal IDisposable $locvar12;

		// Token: 0x0400430E RID: 17166
		internal IEnumerator $locvar13;

		// Token: 0x0400430F RID: 17167
		internal object <_>__12;

		// Token: 0x04004310 RID: 17168
		internal IDisposable $locvar14;

		// Token: 0x04004311 RID: 17169
		internal InversedMandateEffectProcess <iversedmandateProcess>__2;

		// Token: 0x04004312 RID: 17170
		internal List<IBattleUnit> <units>__13;

		// Token: 0x04004313 RID: 17171
		internal IBattleUnit <firstUnit>__14;

		// Token: 0x04004314 RID: 17172
		internal IEnumerator $locvar15;

		// Token: 0x04004315 RID: 17173
		internal object <_>__15;

		// Token: 0x04004316 RID: 17174
		internal IDisposable $locvar16;

		// Token: 0x04004317 RID: 17175
		internal int <prvTime>__14;

		// Token: 0x04004318 RID: 17176
		internal int <crtTime>__14;

		// Token: 0x04004319 RID: 17177
		internal IEnumerator $locvar17;

		// Token: 0x0400431A RID: 17178
		internal object <_>__16;

		// Token: 0x0400431B RID: 17179
		internal IDisposable $locvar18;

		// Token: 0x0400431C RID: 17180
		internal Dictionary<IBattleUnit, List<BattleEffectBase>> <dots>__14;

		// Token: 0x0400431D RID: 17181
		internal List<IBattleUnit>.Enumerator $locvar19;

		// Token: 0x0400431E RID: 17182
		internal IBattleUnit <unit>__17;

		// Token: 0x0400431F RID: 17183
		internal List<LockTimeEffect> <timeLockEffects>__18;

		// Token: 0x04004320 RID: 17184
		internal List<LockTimeEffect> <activeConfusions>__18;

		// Token: 0x04004321 RID: 17185
		internal double <speedBase>__19;

		// Token: 0x04004322 RID: 17186
		internal List<InversedMandateData> <inversedMandateEffect>__19;

		// Token: 0x04004323 RID: 17187
		internal IEnumerator $locvar1B;

		// Token: 0x04004324 RID: 17188
		internal object <_>__20;

		// Token: 0x04004325 RID: 17189
		internal IDisposable $locvar1C;

		// Token: 0x04004326 RID: 17190
		internal List<BattleEffectBase> <effects>__18;

		// Token: 0x04004327 RID: 17191
		internal List<BattleEffectBase>.Enumerator $locvar1D;

		// Token: 0x04004328 RID: 17192
		internal BattleEffectBase <effect>__21;

		// Token: 0x04004329 RID: 17193
		internal int <prsbTm>__22;

		// Token: 0x0400432A RID: 17194
		internal int <crtbTm>__22;

		// Token: 0x0400432B RID: 17195
		internal IEnumerator $locvar1E;

		// Token: 0x0400432C RID: 17196
		internal object <_>__23;

		// Token: 0x0400432D RID: 17197
		internal IDisposable $locvar1F;

		// Token: 0x0400432E RID: 17198
		internal List<AdventureUnitSkill> <skills>__18;

		// Token: 0x0400432F RID: 17199
		internal List<AdventureUnitSkill>.Enumerator $locvar20;

		// Token: 0x04004330 RID: 17200
		internal AdventureUnitSkill <skill>__24;

		// Token: 0x04004331 RID: 17201
		internal int <prsStim>__25;

		// Token: 0x04004332 RID: 17202
		internal int <crtStime>__25;

		// Token: 0x04004333 RID: 17203
		internal IEnumerator $locvar21;

		// Token: 0x04004334 RID: 17204
		internal object <_>__26;

		// Token: 0x04004335 RID: 17205
		internal IDisposable $locvar22;

		// Token: 0x04004336 RID: 17206
		internal IEnumerator $locvar23;

		// Token: 0x04004337 RID: 17207
		internal object <_>__27;

		// Token: 0x04004338 RID: 17208
		internal IDisposable $locvar24;

		// Token: 0x04004339 RID: 17209
		internal IEnumerator $locvar25;

		// Token: 0x0400433A RID: 17210
		internal object <_>__28;

		// Token: 0x0400433B RID: 17211
		internal IDisposable $locvar26;

		// Token: 0x0400433C RID: 17212
		internal IEnumerator $locvar27;

		// Token: 0x0400433D RID: 17213
		internal object <_>__29;

		// Token: 0x0400433E RID: 17214
		internal IDisposable $locvar28;

		// Token: 0x0400433F RID: 17215
		internal List<IBattleUnit>.Enumerator $locvar29;

		// Token: 0x04004340 RID: 17216
		internal List<IBattleUnit>.Enumerator $locvar2B;

		// Token: 0x04004341 RID: 17217
		internal BattleEncounter $this;

		// Token: 0x04004342 RID: 17218
		internal object $current;

		// Token: 0x04004343 RID: 17219
		internal bool $disposing;

		// Token: 0x04004344 RID: 17220
		internal int $PC;

		// Token: 0x04004345 RID: 17221
		private static Func<IBattleUnit, double> <>f__am$cache0;

		// Token: 0x04004346 RID: 17222
		private static Func<LockTimeEffect, bool> <>f__am$cache1;

		// Token: 0x04004347 RID: 17223
		private static Func<BattleEffectBase, BattleEffectBase> <>f__am$cache2;

		// Token: 0x04004348 RID: 17224
		private static Func<AdventureUnitSkill, AdventureUnitSkill> <>f__am$cache3;

		// Token: 0x04004349 RID: 17225
		private static Func<int, bool> <>f__am$cache4;

		// Token: 0x0400434A RID: 17226
		private static Func<int, bool> <>f__am$cache5;

		// Token: 0x02000CEB RID: 3307
		private sealed class <Run>c__AnonStorey10
		{
			// Token: 0x06005581 RID: 21889 RVA: 0x000D1004 File Offset: 0x000CF404
			public <Run>c__AnonStorey10()
			{
			}

			// Token: 0x06005582 RID: 21890 RVA: 0x000D100C File Offset: 0x000CF40C
			internal bool <>m__0(IBattleUnit u)
			{
				return u.GetId() == this.currentAdventureAutoTacticRule.AdventurerId;
			}

			// Token: 0x04004418 RID: 17432
			internal StrategyRule currentAdventureAutoTacticRule;

			// Token: 0x04004419 RID: 17433
			internal BattleEncounter.<Run>c__Iterator3 <>f__ref$3;
		}
	}

	// Token: 0x02000CDF RID: 3295
	[CompilerGenerated]
	private sealed class <SkillPerSecondProcess>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600551C RID: 21788 RVA: 0x000D1024 File Offset: 0x000CF424
		[DebuggerHidden]
		public <SkillPerSecondProcess>c__Iterator4()
		{
		}

		// Token: 0x0600551D RID: 21789 RVA: 0x000D102C File Offset: 0x000CF42C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!unit.IsAliveInBattle())
				{
					enumerator2 = skill.GetSkillLogic().PerSecondLogic_InactiveUnit(skill, unit).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
				enumerator = skill.GetSkillLogic().PerSecondLogic_ActiveUnit(skill, unit).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_112;
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
			goto IL_194;
			Block_4:
			try
			{
				IL_112:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_194:
			if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
			{
				Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
				AdventureUnitSkill key;
				(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[key = skill] = numberOfUnfinishedSkillPerSecProcess[key] - 1;
			}
			else
			{
				UnityEngine.Debug.LogError("Invalid skill per sec workload!");
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700120E RID: 4622
		// (get) Token: 0x0600551E RID: 21790 RVA: 0x000D1244 File Offset: 0x000CF644
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700120F RID: 4623
		// (get) Token: 0x0600551F RID: 21791 RVA: 0x000D124C File Offset: 0x000CF64C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005520 RID: 21792 RVA: 0x000D1254 File Offset: 0x000CF654
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005521 RID: 21793 RVA: 0x000D1304 File Offset: 0x000CF704
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005522 RID: 21794 RVA: 0x000D130B File Offset: 0x000CF70B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005523 RID: 21795 RVA: 0x000D1314 File Offset: 0x000CF714
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<SkillPerSecondProcess>c__Iterator4 <SkillPerSecondProcess>c__Iterator = new BattleEncounter.<SkillPerSecondProcess>c__Iterator4();
			<SkillPerSecondProcess>c__Iterator.$this = this;
			<SkillPerSecondProcess>c__Iterator.unit = unit;
			<SkillPerSecondProcess>c__Iterator.skill = skill;
			return <SkillPerSecondProcess>c__Iterator;
		}

		// Token: 0x0400434B RID: 17227
		internal IBattleUnit unit;

		// Token: 0x0400434C RID: 17228
		internal AdventureUnitSkill skill;

		// Token: 0x0400434D RID: 17229
		internal IEnumerator $locvar0;

		// Token: 0x0400434E RID: 17230
		internal object <_>__1;

		// Token: 0x0400434F RID: 17231
		internal IDisposable $locvar1;

		// Token: 0x04004350 RID: 17232
		internal IEnumerator $locvar2;

		// Token: 0x04004351 RID: 17233
		internal object <_>__2;

		// Token: 0x04004352 RID: 17234
		internal IDisposable $locvar3;

		// Token: 0x04004353 RID: 17235
		internal BattleEncounter $this;

		// Token: 0x04004354 RID: 17236
		internal object $current;

		// Token: 0x04004355 RID: 17237
		internal bool $disposing;

		// Token: 0x04004356 RID: 17238
		internal int $PC;
	}

	// Token: 0x02000CE0 RID: 3296
	[CompilerGenerated]
	private sealed class <SkillCoolingDownLogic>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005524 RID: 21796 RVA: 0x000D1360 File Offset: 0x000CF760
		[DebuggerHidden]
		public <SkillCoolingDownLogic>c__Iterator5()
		{
		}

		// Token: 0x06005525 RID: 21797 RVA: 0x000D1368 File Offset: 0x000CF768
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.ActiveBattleSkillCompletesCoolingDowns, skill)).GetEnumerator();
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
			if (this._numberOfUnfinishedSkillPerSecProcess.ContainsKey(skill))
			{
				Dictionary<AdventureUnitSkill, int> numberOfUnfinishedSkillPerSecProcess;
				AdventureUnitSkill key;
				(numberOfUnfinishedSkillPerSecProcess = this._numberOfUnfinishedSkillPerSecProcess)[key = skill] = numberOfUnfinishedSkillPerSecProcess[key] - 1;
			}
			else
			{
				UnityEngine.Debug.LogError("Invalid skill cooling down workload!");
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001210 RID: 4624
		// (get) Token: 0x06005526 RID: 21798 RVA: 0x000D14B4 File Offset: 0x000CF8B4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001211 RID: 4625
		// (get) Token: 0x06005527 RID: 21799 RVA: 0x000D14BC File Offset: 0x000CF8BC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005528 RID: 21800 RVA: 0x000D14C4 File Offset: 0x000CF8C4
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

		// Token: 0x06005529 RID: 21801 RVA: 0x000D1534 File Offset: 0x000CF934
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600552A RID: 21802 RVA: 0x000D153B File Offset: 0x000CF93B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600552B RID: 21803 RVA: 0x000D1544 File Offset: 0x000CF944
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<SkillCoolingDownLogic>c__Iterator5 <SkillCoolingDownLogic>c__Iterator = new BattleEncounter.<SkillCoolingDownLogic>c__Iterator5();
			<SkillCoolingDownLogic>c__Iterator.$this = this;
			<SkillCoolingDownLogic>c__Iterator.skill = skill;
			return <SkillCoolingDownLogic>c__Iterator;
		}

		// Token: 0x04004357 RID: 17239
		internal AdventureUnitSkill skill;

		// Token: 0x04004358 RID: 17240
		internal IEnumerator $locvar0;

		// Token: 0x04004359 RID: 17241
		internal object <_>__1;

		// Token: 0x0400435A RID: 17242
		internal IDisposable $locvar1;

		// Token: 0x0400435B RID: 17243
		internal BattleEncounter $this;

		// Token: 0x0400435C RID: 17244
		internal object $current;

		// Token: 0x0400435D RID: 17245
		internal bool $disposing;

		// Token: 0x0400435E RID: 17246
		internal int $PC;
	}

	// Token: 0x02000CE1 RID: 3297
	[CompilerGenerated]
	private sealed class <DamageOverTimePerSecondProcess>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600552C RID: 21804 RVA: 0x000D1584 File Offset: 0x000CF984
		[DebuggerHidden]
		public <DamageOverTimePerSecondProcess>c__Iterator6()
		{
		}

		// Token: 0x0600552D RID: 21805 RVA: 0x000D158C File Offset: 0x000CF98C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!dots.Any<KeyValuePair<IBattleUnit, List<BattleEffectBase>>>())
				{
					goto IL_18C;
				}
				enumerator = DamageOverTimeEffect.PerSecondLogic_ActiveUnit_Batch(dots).GetEnumerator();
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
			enumerator2 = dots.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					KeyValuePair<IBattleUnit, List<BattleEffectBase>> keyValuePair = enumerator2.Current;
					foreach (BattleEffectBase battleEffectBase in keyValuePair.Value)
					{
						if (this._numberOfUnfinishedBattleEffectPerSecProcess.ContainsKey(battleEffectBase))
						{
							Dictionary<BattleEffectBase, int> numberOfUnfinishedBattleEffectPerSecProcess;
							BattleEffectBase key;
							(numberOfUnfinishedBattleEffectPerSecProcess = this._numberOfUnfinishedBattleEffectPerSecProcess)[key = battleEffectBase] = numberOfUnfinishedBattleEffectPerSecProcess[key] - 1;
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			IL_18C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001212 RID: 4626
		// (get) Token: 0x0600552E RID: 21806 RVA: 0x000D1758 File Offset: 0x000CFB58
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001213 RID: 4627
		// (get) Token: 0x0600552F RID: 21807 RVA: 0x000D1760 File Offset: 0x000CFB60
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005530 RID: 21808 RVA: 0x000D1768 File Offset: 0x000CFB68
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

		// Token: 0x06005531 RID: 21809 RVA: 0x000D17D8 File Offset: 0x000CFBD8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005532 RID: 21810 RVA: 0x000D17DF File Offset: 0x000CFBDF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005533 RID: 21811 RVA: 0x000D17E8 File Offset: 0x000CFBE8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<DamageOverTimePerSecondProcess>c__Iterator6 <DamageOverTimePerSecondProcess>c__Iterator = new BattleEncounter.<DamageOverTimePerSecondProcess>c__Iterator6();
			<DamageOverTimePerSecondProcess>c__Iterator.$this = this;
			<DamageOverTimePerSecondProcess>c__Iterator.dots = dots;
			return <DamageOverTimePerSecondProcess>c__Iterator;
		}

		// Token: 0x0400435F RID: 17247
		internal Dictionary<IBattleUnit, List<BattleEffectBase>> dots;

		// Token: 0x04004360 RID: 17248
		internal IEnumerator $locvar0;

		// Token: 0x04004361 RID: 17249
		internal object <_>__1;

		// Token: 0x04004362 RID: 17250
		internal IDisposable $locvar1;

		// Token: 0x04004363 RID: 17251
		internal Dictionary<IBattleUnit, List<BattleEffectBase>>.Enumerator $locvar2;

		// Token: 0x04004364 RID: 17252
		internal BattleEncounter $this;

		// Token: 0x04004365 RID: 17253
		internal object $current;

		// Token: 0x04004366 RID: 17254
		internal bool $disposing;

		// Token: 0x04004367 RID: 17255
		internal int $PC;
	}

	// Token: 0x02000CE2 RID: 3298
	[CompilerGenerated]
	private sealed class <BattleEffectPerSecondProcess>c__Iterator7 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005534 RID: 21812 RVA: 0x000D1828 File Offset: 0x000CFC28
		[DebuggerHidden]
		public <BattleEffectPerSecondProcess>c__Iterator7()
		{
		}

		// Token: 0x06005535 RID: 21813 RVA: 0x000D1830 File Offset: 0x000CFC30
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!unit.IsAliveInBattle())
				{
					enumerator2 = effect.PerSecondLogic_InactiveUnit(unit).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
				enumerator = effect.PerSecondLogic_ActiveUnit(unit).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_100;
			case 3u:
				Block_8:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
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
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				goto IL_274;
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
			goto IL_182;
			Block_4:
			try
			{
				IL_100:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_182:
			if (effect.MaxNumberOfLastingSeconds != null)
			{
				float? maxNumberOfLastingSeconds = effect.MaxNumberOfLastingSeconds;
				if (effect.Timer >= maxNumberOfLastingSeconds)
				{
					enumerator3 = unit.LooseSkillEffect(effect, EffectWearsOffType.Expiration).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			IL_274:
			if (this._numberOfUnfinishedBattleEffectPerSecProcess.ContainsKey(effect))
			{
				Dictionary<BattleEffectBase, int> numberOfUnfinishedBattleEffectPerSecProcess;
				BattleEffectBase key;
				(numberOfUnfinishedBattleEffectPerSecProcess = this._numberOfUnfinishedBattleEffectPerSecProcess)[key = effect] = numberOfUnfinishedBattleEffectPerSecProcess[key] - 1;
			}
			else
			{
				UnityEngine.Debug.LogError("Invalid effect per second workload!");
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001214 RID: 4628
		// (get) Token: 0x06005536 RID: 21814 RVA: 0x000D1B34 File Offset: 0x000CFF34
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001215 RID: 4629
		// (get) Token: 0x06005537 RID: 21815 RVA: 0x000D1B3C File Offset: 0x000CFF3C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005538 RID: 21816 RVA: 0x000D1B44 File Offset: 0x000CFF44
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005539 RID: 21817 RVA: 0x000D1C34 File Offset: 0x000D0034
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600553A RID: 21818 RVA: 0x000D1C3B File Offset: 0x000D003B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600553B RID: 21819 RVA: 0x000D1C44 File Offset: 0x000D0044
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<BattleEffectPerSecondProcess>c__Iterator7 <BattleEffectPerSecondProcess>c__Iterator = new BattleEncounter.<BattleEffectPerSecondProcess>c__Iterator7();
			<BattleEffectPerSecondProcess>c__Iterator.$this = this;
			<BattleEffectPerSecondProcess>c__Iterator.unit = unit;
			<BattleEffectPerSecondProcess>c__Iterator.effect = effect;
			return <BattleEffectPerSecondProcess>c__Iterator;
		}

		// Token: 0x04004368 RID: 17256
		internal IBattleUnit unit;

		// Token: 0x04004369 RID: 17257
		internal BattleEffectBase effect;

		// Token: 0x0400436A RID: 17258
		internal IEnumerator $locvar0;

		// Token: 0x0400436B RID: 17259
		internal object <_>__1;

		// Token: 0x0400436C RID: 17260
		internal IDisposable $locvar1;

		// Token: 0x0400436D RID: 17261
		internal IEnumerator $locvar2;

		// Token: 0x0400436E RID: 17262
		internal object <_>__2;

		// Token: 0x0400436F RID: 17263
		internal IDisposable $locvar3;

		// Token: 0x04004370 RID: 17264
		internal IEnumerator $locvar4;

		// Token: 0x04004371 RID: 17265
		internal object <_>__3;

		// Token: 0x04004372 RID: 17266
		internal IDisposable $locvar5;

		// Token: 0x04004373 RID: 17267
		internal BattleEncounter $this;

		// Token: 0x04004374 RID: 17268
		internal object $current;

		// Token: 0x04004375 RID: 17269
		internal bool $disposing;

		// Token: 0x04004376 RID: 17270
		internal int $PC;
	}

	// Token: 0x02000CE3 RID: 3299
	[CompilerGenerated]
	private sealed class <EncounterPerSecondProcess>c__Iterator8 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600553C RID: 21820 RVA: 0x000D1C90 File Offset: 0x000D0090
		[DebuggerHidden]
		public <EncounterPerSecondProcess>c__Iterator8()
		{
		}

		// Token: 0x0600553D RID: 21821 RVA: 0x000D1C98 File Offset: 0x000D0098
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				IEnumerable<IBattleUnit> playerUnits = base.PlayerUnits;
				if (BattleEncounter.<>f__mg$cache0 == null)
				{
					BattleEncounter.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				enumerator = playerUnits.Where(BattleEncounter.<>f__mg$cache0).ToList<IBattleUnit>().GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_18A;
			case 3u:
				goto IL_2BB;
			case 4u:
			case 5u:
				goto IL_3E7;
			case 6u:
			case 7u:
				goto IL_6BE;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_9:
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
					un = enumerator.Current;
					enumerator2 = un.SelfEventCallback(un, AdventureEventType.AttributeCheckup, null).GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enumerator3 = base.CurrentAdventure.DungeonEffects.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_18A:
				switch (num)
				{
				case 2u:
					Block_21:
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
				while (enumerator3.MoveNext())
				{
					dungeonEffects = enumerator3.Current;
					if (dungeonEffects.GetSpecialEffectType().HasProcessor())
					{
						enumerator4 = dungeonEffects.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectPerSecondProcess(dungeonEffects, this).GetEnumerator();
						num = 4294967293u;
						goto Block_21;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			enumerator5 = base.CurrentAdventure.PlayerEffects.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2BB:
				switch (num)
				{
				case 3u:
					Block_33:
					try
					{
						switch (num)
						{
						}
						if (enumerator6.MoveNext())
						{
							_3 = enumerator6.Current;
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
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator5.MoveNext())
				{
					playereffect = enumerator5.Current;
					if (playereffect.GetSpecialEffectType().HasProcessor())
					{
						enumerator6 = playereffect.GetSpecialEffectType().GetSpecialProcessor().AsAdventureEffectPerSecondProcess(playereffect, this).GetEnumerator();
						num = 4294967293u;
						goto Block_33;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			enumerator7 = base.PlayerUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_3E7:
				switch (num)
				{
				case 4u:
					Block_45:
					try
					{
						switch (num)
						{
						case 4u:
							Block_50:
							try
							{
								switch (num)
								{
								}
								if (enumerator9.MoveNext())
								{
									_4 = enumerator9.Current;
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
									if ((disposable4 = (enumerator9 as IDisposable)) != null)
									{
										disposable4.Dispose();
									}
								}
							}
							break;
						}
						while (enumerator8.MoveNext())
						{
							playerunitSpecialEffect = enumerator8.Current;
							if (playerunitSpecialEffect.GetSpecialEffectType().HasProcessor())
							{
								enumerator9 = playerunitSpecialEffect.GetSpecialEffectType().GetSpecialProcessor().AsActiveUnitPerSecondProcess(playerunitSpecialEffect, unit).GetEnumerator();
								num = 4294967293u;
								goto Block_50;
							}
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator8).Dispose();
						}
					}
					break;
				case 5u:
					Block_46:
					try
					{
						switch (num)
						{
						case 5u:
							Block_62:
							try
							{
								switch (num)
								{
								}
								if (enumerator11.MoveNext())
								{
									_5 = enumerator11.Current;
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
									if ((disposable5 = (enumerator11 as IDisposable)) != null)
									{
										disposable5.Dispose();
									}
								}
							}
							break;
						}
						while (enumerator10.MoveNext())
						{
							playerunitSpecialEffect2 = enumerator10.Current;
							if (playerunitSpecialEffect2.GetSpecialEffectType().HasProcessor())
							{
								enumerator11 = playerunitSpecialEffect2.GetSpecialEffectType().GetSpecialProcessor().AsInactiveUnitPerSecondProcess(playerunitSpecialEffect2, unit).GetEnumerator();
								num = 4294967293u;
								goto Block_62;
							}
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator10).Dispose();
						}
					}
					break;
				}
				if (enumerator7.MoveNext())
				{
					unit = enumerator7.Current;
					if (unit.IsAliveInBattle())
					{
						enumerator8 = unit.SpecialEffects.GetEnumerator();
						num = 4294967293u;
						goto Block_45;
					}
					enumerator10 = unit.SpecialEffects.GetEnumerator();
					num = 4294967293u;
					goto Block_46;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator7).Dispose();
				}
			}
			enumerator12 = base.EnemyUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_6BE:
				switch (num)
				{
				case 6u:
					Block_76:
					try
					{
						switch (num)
						{
						case 6u:
							Block_81:
							try
							{
								switch (num)
								{
								}
								if (enumerator14.MoveNext())
								{
									_6 = enumerator14.Current;
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
									if ((disposable6 = (enumerator14 as IDisposable)) != null)
									{
										disposable6.Dispose();
									}
								}
							}
							break;
						}
						while (enumerator13.MoveNext())
						{
							playerunitSpecialEffect3 = enumerator13.Current;
							if (playerunitSpecialEffect3.GetSpecialEffectType().HasProcessor())
							{
								enumerator14 = playerunitSpecialEffect3.GetSpecialEffectType().GetSpecialProcessor().AsActiveUnitPerSecondProcess(playerunitSpecialEffect3, unit2).GetEnumerator();
								num = 4294967293u;
								goto Block_81;
							}
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator13).Dispose();
						}
					}
					break;
				case 7u:
					Block_77:
					try
					{
						switch (num)
						{
						case 7u:
							Block_93:
							try
							{
								switch (num)
								{
								}
								if (enumerator16.MoveNext())
								{
									_7 = enumerator16.Current;
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
									if ((disposable7 = (enumerator16 as IDisposable)) != null)
									{
										disposable7.Dispose();
									}
								}
							}
							break;
						}
						while (enumerator15.MoveNext())
						{
							playerunitSpecialEffect4 = enumerator15.Current;
							if (playerunitSpecialEffect4.GetSpecialEffectType().HasProcessor())
							{
								enumerator16 = playerunitSpecialEffect4.GetSpecialEffectType().GetSpecialProcessor().AsInactiveUnitPerSecondProcess(playerunitSpecialEffect4, unit2).GetEnumerator();
								num = 4294967293u;
								goto Block_93;
							}
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator15).Dispose();
						}
					}
					break;
				}
				if (enumerator12.MoveNext())
				{
					unit2 = enumerator12.Current;
					if (unit2.IsAliveInBattle())
					{
						enumerator13 = unit2.SpecialEffects.GetEnumerator();
						num = 4294967293u;
						goto Block_76;
					}
					enumerator15 = unit2.SpecialEffects.GetEnumerator();
					num = 4294967293u;
					goto Block_77;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator12).Dispose();
				}
			}
			this._numberOfUnfinishedEncounterPerSecProcess--;
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001216 RID: 4630
		// (get) Token: 0x0600553E RID: 21822 RVA: 0x000D27C4 File Offset: 0x000D0BC4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001217 RID: 4631
		// (get) Token: 0x0600553F RID: 21823 RVA: 0x000D27CC File Offset: 0x000D0BCC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005540 RID: 21824 RVA: 0x000D27D4 File Offset: 0x000D0BD4
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
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator6 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			case 4u:
			case 5u:
				try
				{
					switch (num)
					{
					case 4u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable4 = (enumerator9 as IDisposable)) != null)
								{
									disposable4.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator8).Dispose();
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
								if ((disposable5 = (enumerator11 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator10).Dispose();
						}
						break;
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
							try
							{
							}
							finally
							{
								if ((disposable6 = (enumerator14 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator13).Dispose();
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
								if ((disposable7 = (enumerator16 as IDisposable)) != null)
								{
									disposable7.Dispose();
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
				finally
				{
					((IDisposable)enumerator12).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005541 RID: 21825 RVA: 0x000D2B24 File Offset: 0x000D0F24
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005542 RID: 21826 RVA: 0x000D2B2B File Offset: 0x000D0F2B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005543 RID: 21827 RVA: 0x000D2B34 File Offset: 0x000D0F34
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<EncounterPerSecondProcess>c__Iterator8 <EncounterPerSecondProcess>c__Iterator = new BattleEncounter.<EncounterPerSecondProcess>c__Iterator8();
			<EncounterPerSecondProcess>c__Iterator.$this = this;
			return <EncounterPerSecondProcess>c__Iterator;
		}

		// Token: 0x04004377 RID: 17271
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004378 RID: 17272
		internal IBattleUnit <un>__1;

		// Token: 0x04004379 RID: 17273
		internal IEnumerator $locvar1;

		// Token: 0x0400437A RID: 17274
		internal object <_>__2;

		// Token: 0x0400437B RID: 17275
		internal IDisposable $locvar2;

		// Token: 0x0400437C RID: 17276
		internal List<ISpecialEffectDataLoad>.Enumerator $locvar3;

		// Token: 0x0400437D RID: 17277
		internal ISpecialEffectDataLoad <dungeonEffects>__3;

		// Token: 0x0400437E RID: 17278
		internal IEnumerator $locvar4;

		// Token: 0x0400437F RID: 17279
		internal object <_>__4;

		// Token: 0x04004380 RID: 17280
		internal IDisposable $locvar5;

		// Token: 0x04004381 RID: 17281
		internal List<ISpecialEffectDataLoad>.Enumerator $locvar6;

		// Token: 0x04004382 RID: 17282
		internal ISpecialEffectDataLoad <playereffect>__5;

		// Token: 0x04004383 RID: 17283
		internal IEnumerator $locvar7;

		// Token: 0x04004384 RID: 17284
		internal object <_>__6;

		// Token: 0x04004385 RID: 17285
		internal IDisposable $locvar8;

		// Token: 0x04004386 RID: 17286
		internal List<IBattleUnit>.Enumerator $locvar9;

		// Token: 0x04004387 RID: 17287
		internal IBattleUnit <unit>__7;

		// Token: 0x04004388 RID: 17288
		internal List<ISpecialEffectDataLoad>.Enumerator $locvarA;

		// Token: 0x04004389 RID: 17289
		internal ISpecialEffectDataLoad <playerunitSpecialEffect>__8;

		// Token: 0x0400438A RID: 17290
		internal IEnumerator $locvarB;

		// Token: 0x0400438B RID: 17291
		internal object <_>__9;

		// Token: 0x0400438C RID: 17292
		internal IDisposable $locvarC;

		// Token: 0x0400438D RID: 17293
		internal List<ISpecialEffectDataLoad>.Enumerator $locvarD;

		// Token: 0x0400438E RID: 17294
		internal ISpecialEffectDataLoad <playerunitSpecialEffect>__10;

		// Token: 0x0400438F RID: 17295
		internal IEnumerator $locvarE;

		// Token: 0x04004390 RID: 17296
		internal object <_>__11;

		// Token: 0x04004391 RID: 17297
		internal IDisposable $locvarF;

		// Token: 0x04004392 RID: 17298
		internal List<IBattleUnit>.Enumerator $locvar10;

		// Token: 0x04004393 RID: 17299
		internal IBattleUnit <unit>__12;

		// Token: 0x04004394 RID: 17300
		internal List<ISpecialEffectDataLoad>.Enumerator $locvar11;

		// Token: 0x04004395 RID: 17301
		internal ISpecialEffectDataLoad <playerunitSpecialEffect>__13;

		// Token: 0x04004396 RID: 17302
		internal IEnumerator $locvar12;

		// Token: 0x04004397 RID: 17303
		internal object <_>__14;

		// Token: 0x04004398 RID: 17304
		internal IDisposable $locvar13;

		// Token: 0x04004399 RID: 17305
		internal List<ISpecialEffectDataLoad>.Enumerator $locvar14;

		// Token: 0x0400439A RID: 17306
		internal ISpecialEffectDataLoad <playerunitSpecialEffect>__15;

		// Token: 0x0400439B RID: 17307
		internal IEnumerator $locvar15;

		// Token: 0x0400439C RID: 17308
		internal object <_>__16;

		// Token: 0x0400439D RID: 17309
		internal IDisposable $locvar16;

		// Token: 0x0400439E RID: 17310
		internal BattleEncounter $this;

		// Token: 0x0400439F RID: 17311
		internal object $current;

		// Token: 0x040043A0 RID: 17312
		internal bool $disposing;

		// Token: 0x040043A1 RID: 17313
		internal int $PC;
	}

	// Token: 0x02000CE4 RID: 3300
	[CompilerGenerated]
	private sealed class <InversedMandateProcess>c__Iterator9 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005544 RID: 21828 RVA: 0x000D2B68 File Offset: 0x000D0F68
		[DebuggerHidden]
		public <InversedMandateProcess>c__Iterator9()
		{
		}

		// Token: 0x06005545 RID: 21829 RVA: 0x000D2B70 File Offset: 0x000D0F70
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				turnProgressChangedPercentage = PlayerProfile.TurnSpeedbase * (double)Time.deltaTime * (1.0 + unit.GetSpeed(AttributeRetrievalLevel.Skill) / 20.0) / PlayerProfile.TurnSpeedGauge;
				enumerator = inversedMandateEffect.GetEnumerator();
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
				case 1u:
					Block_4:
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
					inversedMandateData = enumerator.Current;
					enumerator2 = iversedmandateProcess.TurnChangeProcess(turnProgressChangedPercentage, inversedMandateData, unit, unit).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this._inversedMandateInProcess = false;
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001218 RID: 4632
		// (get) Token: 0x06005546 RID: 21830 RVA: 0x000D2D20 File Offset: 0x000D1120
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001219 RID: 4633
		// (get) Token: 0x06005547 RID: 21831 RVA: 0x000D2D28 File Offset: 0x000D1128
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005548 RID: 21832 RVA: 0x000D2D30 File Offset: 0x000D1130
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
			}
		}

		// Token: 0x06005549 RID: 21833 RVA: 0x000D2DC4 File Offset: 0x000D11C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600554A RID: 21834 RVA: 0x000D2DCB File Offset: 0x000D11CB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600554B RID: 21835 RVA: 0x000D2DD4 File Offset: 0x000D11D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<InversedMandateProcess>c__Iterator9 <InversedMandateProcess>c__Iterator = new BattleEncounter.<InversedMandateProcess>c__Iterator9();
			<InversedMandateProcess>c__Iterator.$this = this;
			<InversedMandateProcess>c__Iterator.unit = unit;
			<InversedMandateProcess>c__Iterator.inversedMandateEffect = inversedMandateEffect;
			<InversedMandateProcess>c__Iterator.iversedmandateProcess = iversedmandateProcess;
			return <InversedMandateProcess>c__Iterator;
		}

		// Token: 0x040043A2 RID: 17314
		internal IBattleUnit unit;

		// Token: 0x040043A3 RID: 17315
		internal double <turnProgressChangedPercentage>__0;

		// Token: 0x040043A4 RID: 17316
		internal List<InversedMandateData> inversedMandateEffect;

		// Token: 0x040043A5 RID: 17317
		internal List<InversedMandateData>.Enumerator $locvar0;

		// Token: 0x040043A6 RID: 17318
		internal InversedMandateData <inversedMandateData>__1;

		// Token: 0x040043A7 RID: 17319
		internal InversedMandateEffectProcess iversedmandateProcess;

		// Token: 0x040043A8 RID: 17320
		internal IEnumerator $locvar1;

		// Token: 0x040043A9 RID: 17321
		internal object <_>__2;

		// Token: 0x040043AA RID: 17322
		internal IDisposable $locvar2;

		// Token: 0x040043AB RID: 17323
		internal BattleEncounter $this;

		// Token: 0x040043AC RID: 17324
		internal object $current;

		// Token: 0x040043AD RID: 17325
		internal bool $disposing;

		// Token: 0x040043AE RID: 17326
		internal int $PC;
	}

	// Token: 0x02000CE5 RID: 3301
	[CompilerGenerated]
	private sealed class <ConfusionExpiration>c__IteratorA : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600554C RID: 21836 RVA: 0x000D2E2C File Offset: 0x000D122C
		[DebuggerHidden]
		public <ConfusionExpiration>c__IteratorA()
		{
		}

		// Token: 0x0600554D RID: 21837 RVA: 0x000D2E34 File Offset: 0x000D1234
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				expiredConfusions = (from ef in timeLockEffects
				where ef.MaxNumberOfLastingSeconds <= ef.Timer
				select ef).ToList<LockTimeEffect>();
				enumerator = expiredConfusions.GetEnumerator();
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
				case 1u:
					Block_5:
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
					expiredConfusion = enumerator.Current;
					enumerator2 = unit.LooseSkillEffect(expiredConfusion, EffectWearsOffType.Expiration).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this._expiraConfusionInProgress = false;
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700121A RID: 4634
		// (get) Token: 0x0600554E RID: 21838 RVA: 0x000D2FCC File Offset: 0x000D13CC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700121B RID: 4635
		// (get) Token: 0x0600554F RID: 21839 RVA: 0x000D2FD4 File Offset: 0x000D13D4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005550 RID: 21840 RVA: 0x000D2FDC File Offset: 0x000D13DC
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
			}
		}

		// Token: 0x06005551 RID: 21841 RVA: 0x000D3070 File Offset: 0x000D1470
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005552 RID: 21842 RVA: 0x000D3077 File Offset: 0x000D1477
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005553 RID: 21843 RVA: 0x000D3080 File Offset: 0x000D1480
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<ConfusionExpiration>c__IteratorA <ConfusionExpiration>c__IteratorA = new BattleEncounter.<ConfusionExpiration>c__IteratorA();
			<ConfusionExpiration>c__IteratorA.$this = this;
			<ConfusionExpiration>c__IteratorA.timeLockEffects = timeLockEffects;
			<ConfusionExpiration>c__IteratorA.unit = unit;
			return <ConfusionExpiration>c__IteratorA;
		}

		// Token: 0x06005554 RID: 21844 RVA: 0x000D30CC File Offset: 0x000D14CC
		private static bool <>m__0(LockTimeEffect ef)
		{
			return ef.MaxNumberOfLastingSeconds <= ef.Timer;
		}

		// Token: 0x040043AF RID: 17327
		internal List<LockTimeEffect> timeLockEffects;

		// Token: 0x040043B0 RID: 17328
		internal List<LockTimeEffect> <expiredConfusions>__0;

		// Token: 0x040043B1 RID: 17329
		internal List<LockTimeEffect>.Enumerator $locvar0;

		// Token: 0x040043B2 RID: 17330
		internal LockTimeEffect <expiredConfusion>__1;

		// Token: 0x040043B3 RID: 17331
		internal IBattleUnit unit;

		// Token: 0x040043B4 RID: 17332
		internal IEnumerator $locvar1;

		// Token: 0x040043B5 RID: 17333
		internal object <_>__2;

		// Token: 0x040043B6 RID: 17334
		internal IDisposable $locvar2;

		// Token: 0x040043B7 RID: 17335
		internal BattleEncounter $this;

		// Token: 0x040043B8 RID: 17336
		internal object $current;

		// Token: 0x040043B9 RID: 17337
		internal bool $disposing;

		// Token: 0x040043BA RID: 17338
		internal int $PC;

		// Token: 0x040043BB RID: 17339
		private static Func<LockTimeEffect, bool> <>f__am$cache0;
	}

	// Token: 0x02000CE6 RID: 3302
	[CompilerGenerated]
	private sealed class <DoTurnLogic>c__IteratorB : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005555 RID: 21845 RVA: 0x000D3101 File Offset: 0x000D1501
		[DebuggerHidden]
		public <DoTurnLogic>c__IteratorB()
		{
		}

		// Token: 0x06005556 RID: 21846 RVA: 0x000D310C File Offset: 0x000D150C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				turnCounter[unit] = 0.0;
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPriorTurnStart, null)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_211;
			case 3u:
				Block_10:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
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
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				enumerator4 = unit.DoTurn().GetEnumerator();
				num = 4294967293u;
				goto Block_11;
			case 4u:
				goto IL_374;
			case 5u:
				goto IL_41B;
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
			if (unit.IsPlayer)
			{
				goto IL_293;
			}
			nightBlade = base.PlayerUnits.FirstOrDefault((IBattleUnit u) => u.GetUnitType() == UnitClass.NightBlade);
			if (nightBlade == null)
			{
				goto IL_293;
			}
			exclusive = nightBlade.SpecialEffects.OfType<NightBladeEnhancementData>().FirstOrDefault<NightBladeEnhancementData>();
			if (exclusive == null)
			{
				goto IL_293;
			}
			releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(unit, new SpecialEffectTriggerSource(nightBlade, exclusive.GetSpecialEffectType()), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(nightBlade, unit, OutputType.Physical, exclusive.DamageRate)
					}, unit, nightBlade, true, false)
				})
			}, nightBlade);
			enumerator2 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_211:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_293:
			if (!base.IsWinningConditionMet() && unit.Status == BattleUnitStatus.Active)
			{
				enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitRegularTurnStarts, null)).GetEnumerator();
				num = 4294967293u;
				goto Block_10;
			}
			goto IL_49D;
			Block_11:
			try
			{
				IL_374:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitRegularTurnEnds, null)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_41B:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_5 = enumerator5.Current;
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
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			IL_49D:
			this._doTurnInProgress = false;
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700121C RID: 4636
		// (get) Token: 0x06005557 RID: 21847 RVA: 0x000D360C File Offset: 0x000D1A0C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700121D RID: 4637
		// (get) Token: 0x06005558 RID: 21848 RVA: 0x000D3614 File Offset: 0x000D1A14
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005559 RID: 21849 RVA: 0x000D361C File Offset: 0x000D1A1C
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600555A RID: 21850 RVA: 0x000D3788 File Offset: 0x000D1B88
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600555B RID: 21851 RVA: 0x000D378F File Offset: 0x000D1B8F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600555C RID: 21852 RVA: 0x000D3798 File Offset: 0x000D1B98
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<DoTurnLogic>c__IteratorB <DoTurnLogic>c__IteratorB = new BattleEncounter.<DoTurnLogic>c__IteratorB();
			<DoTurnLogic>c__IteratorB.$this = this;
			<DoTurnLogic>c__IteratorB.turnCounter = turnCounter;
			<DoTurnLogic>c__IteratorB.unit = unit;
			return <DoTurnLogic>c__IteratorB;
		}

		// Token: 0x0600555D RID: 21853 RVA: 0x000D37E4 File Offset: 0x000D1BE4
		private static bool <>m__0(IBattleUnit u)
		{
			return u.GetUnitType() == UnitClass.NightBlade;
		}

		// Token: 0x040043BC RID: 17340
		internal Dictionary<IBattleUnit, double> turnCounter;

		// Token: 0x040043BD RID: 17341
		internal IBattleUnit unit;

		// Token: 0x040043BE RID: 17342
		internal IEnumerator $locvar0;

		// Token: 0x040043BF RID: 17343
		internal object <_>__1;

		// Token: 0x040043C0 RID: 17344
		internal IDisposable $locvar1;

		// Token: 0x040043C1 RID: 17345
		internal IBattleUnit <nightBlade>__2;

		// Token: 0x040043C2 RID: 17346
		internal NightBladeEnhancementData <exclusive>__3;

		// Token: 0x040043C3 RID: 17347
		internal ReleaseableDamage <releaseableDamage>__4;

		// Token: 0x040043C4 RID: 17348
		internal IEnumerator $locvar2;

		// Token: 0x040043C5 RID: 17349
		internal object <_>__5;

		// Token: 0x040043C6 RID: 17350
		internal IDisposable $locvar3;

		// Token: 0x040043C7 RID: 17351
		internal IEnumerator $locvar4;

		// Token: 0x040043C8 RID: 17352
		internal object <_>__6;

		// Token: 0x040043C9 RID: 17353
		internal IDisposable $locvar5;

		// Token: 0x040043CA RID: 17354
		internal IEnumerator $locvar6;

		// Token: 0x040043CB RID: 17355
		internal object <_>__7;

		// Token: 0x040043CC RID: 17356
		internal IDisposable $locvar7;

		// Token: 0x040043CD RID: 17357
		internal IEnumerator $locvar8;

		// Token: 0x040043CE RID: 17358
		internal object <_>__8;

		// Token: 0x040043CF RID: 17359
		internal IDisposable $locvar9;

		// Token: 0x040043D0 RID: 17360
		internal BattleEncounter $this;

		// Token: 0x040043D1 RID: 17361
		internal object $current;

		// Token: 0x040043D2 RID: 17362
		internal bool $disposing;

		// Token: 0x040043D3 RID: 17363
		internal int $PC;

		// Token: 0x040043D4 RID: 17364
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}

	// Token: 0x02000CE7 RID: 3303
	[CompilerGenerated]
	private sealed class <UpdatePlayerGauge>c__IteratorC : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600555E RID: 21854 RVA: 0x000D37F3 File Offset: 0x000D1BF3
		[DebuggerHidden]
		public <UpdatePlayerGauge>c__IteratorC()
		{
		}

		// Token: 0x0600555F RID: 21855 RVA: 0x000D37FC File Offset: 0x000D1BFC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (updateValue == 0.0)
				{
					goto IL_3D2;
				}
				original = base.PlayerGauge;
				base.PlayerGauge += updateValue;
				if (base.PlayerGauge < 0.0)
				{
					base.PlayerGauge = 0.0;
				}
				if (base.PlayerGauge > base.GetMaxPlayerGauge())
				{
					base.PlayerGauge = base.GetMaxPlayerGauge();
				}
				if (original == base.PlayerGauge)
				{
					goto IL_1B8;
				}
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterPlayerGaugeUpdated, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					ChangeSource = changeSource,
					CurrentValue = base.PlayerGauge
				})).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_9:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						_2 = enumerator2.Current;
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
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				goto IL_2C5;
			case 3u:
				Block_12:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
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
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				goto IL_3D2;
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
			IL_1B8:
			if (original != base.GetMaxPlayerGauge() && base.PlayerGauge == base.GetMaxPlayerGauge())
			{
				enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterPlayerGaugeFullyCharged, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = base.PlayerGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				num = 4294967293u;
				goto Block_9;
			}
			IL_2C5:
			if (original == base.GetMaxPlayerGauge() && base.PlayerGauge != base.GetMaxPlayerGauge())
			{
				enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterPlayerGaugeReleased, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = base.PlayerGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				num = 4294967293u;
				goto Block_12;
			}
			IL_3D2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700121E RID: 4638
		// (get) Token: 0x06005560 RID: 21856 RVA: 0x000D3C10 File Offset: 0x000D2010
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700121F RID: 4639
		// (get) Token: 0x06005561 RID: 21857 RVA: 0x000D3C18 File Offset: 0x000D2018
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005562 RID: 21858 RVA: 0x000D3C20 File Offset: 0x000D2020
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005563 RID: 21859 RVA: 0x000D3D10 File Offset: 0x000D2110
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005564 RID: 21860 RVA: 0x000D3D17 File Offset: 0x000D2117
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005565 RID: 21861 RVA: 0x000D3D20 File Offset: 0x000D2120
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<UpdatePlayerGauge>c__IteratorC <UpdatePlayerGauge>c__IteratorC = new BattleEncounter.<UpdatePlayerGauge>c__IteratorC();
			<UpdatePlayerGauge>c__IteratorC.$this = this;
			<UpdatePlayerGauge>c__IteratorC.updateValue = updateValue;
			<UpdatePlayerGauge>c__IteratorC.changeSource = changeSource;
			return <UpdatePlayerGauge>c__IteratorC;
		}

		// Token: 0x040043D5 RID: 17365
		internal double updateValue;

		// Token: 0x040043D6 RID: 17366
		internal double <original>__1;

		// Token: 0x040043D7 RID: 17367
		internal IBattleEffectSource changeSource;

		// Token: 0x040043D8 RID: 17368
		internal IEnumerator $locvar0;

		// Token: 0x040043D9 RID: 17369
		internal object <_>__2;

		// Token: 0x040043DA RID: 17370
		internal IDisposable $locvar1;

		// Token: 0x040043DB RID: 17371
		internal IEnumerator $locvar2;

		// Token: 0x040043DC RID: 17372
		internal object <_>__3;

		// Token: 0x040043DD RID: 17373
		internal IDisposable $locvar3;

		// Token: 0x040043DE RID: 17374
		internal IEnumerator $locvar4;

		// Token: 0x040043DF RID: 17375
		internal object <_>__4;

		// Token: 0x040043E0 RID: 17376
		internal IDisposable $locvar5;

		// Token: 0x040043E1 RID: 17377
		internal BattleEncounter $this;

		// Token: 0x040043E2 RID: 17378
		internal object $current;

		// Token: 0x040043E3 RID: 17379
		internal bool $disposing;

		// Token: 0x040043E4 RID: 17380
		internal int $PC;
	}

	// Token: 0x02000CE8 RID: 3304
	[CompilerGenerated]
	private sealed class <UpdateEnemyGauge>c__IteratorD : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005566 RID: 21862 RVA: 0x000D3D6C File Offset: 0x000D216C
		[DebuggerHidden]
		public <UpdateEnemyGauge>c__IteratorD()
		{
		}

		// Token: 0x06005567 RID: 21863 RVA: 0x000D3D74 File Offset: 0x000D2174
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (updateValue == 0.0)
				{
					goto IL_3D2;
				}
				original = base.EnemyGauge;
				base.EnemyGauge += updateValue;
				if (base.EnemyGauge < 0.0)
				{
					base.EnemyGauge = 0.0;
				}
				if (base.EnemyGauge > base.GetMaxEnemyGauge())
				{
					base.EnemyGauge = base.GetMaxEnemyGauge();
				}
				if (original == base.EnemyGauge)
				{
					goto IL_1B8;
				}
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterEnemyGaugeUpdated, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					ChangeSource = changeSource,
					CurrentValue = base.EnemyGauge
				})).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_9:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						_2 = enumerator2.Current;
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
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				goto IL_2C5;
			case 3u:
				Block_12:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
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
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				goto IL_3D2;
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
			IL_1B8:
			if (original != base.GetMaxEnemyGauge() && base.EnemyGauge == base.GetMaxEnemyGauge())
			{
				enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterEnemyGaugeFullyCharged, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = base.EnemyGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				num = 4294967293u;
				goto Block_9;
			}
			IL_2C5:
			if (original == base.GetMaxEnemyGauge() && base.EnemyGauge != base.GetMaxEnemyGauge())
			{
				enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(changeSource.SourceUnit, AdventureEventType.BattleEncounterEnemyGaugeReleased, new BattleGaugeUpdateEvent
				{
					ChangeAmount = updateValue,
					CurrentValue = base.EnemyGauge,
					ChangeSource = changeSource
				})).GetEnumerator();
				num = 4294967293u;
				goto Block_12;
			}
			IL_3D2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001220 RID: 4640
		// (get) Token: 0x06005568 RID: 21864 RVA: 0x000D4188 File Offset: 0x000D2588
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001221 RID: 4641
		// (get) Token: 0x06005569 RID: 21865 RVA: 0x000D4190 File Offset: 0x000D2590
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600556A RID: 21866 RVA: 0x000D4198 File Offset: 0x000D2598
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600556B RID: 21867 RVA: 0x000D4288 File Offset: 0x000D2688
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600556C RID: 21868 RVA: 0x000D428F File Offset: 0x000D268F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600556D RID: 21869 RVA: 0x000D4298 File Offset: 0x000D2698
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<UpdateEnemyGauge>c__IteratorD <UpdateEnemyGauge>c__IteratorD = new BattleEncounter.<UpdateEnemyGauge>c__IteratorD();
			<UpdateEnemyGauge>c__IteratorD.$this = this;
			<UpdateEnemyGauge>c__IteratorD.updateValue = updateValue;
			<UpdateEnemyGauge>c__IteratorD.changeSource = changeSource;
			return <UpdateEnemyGauge>c__IteratorD;
		}

		// Token: 0x040043E5 RID: 17381
		internal double updateValue;

		// Token: 0x040043E6 RID: 17382
		internal double <original>__1;

		// Token: 0x040043E7 RID: 17383
		internal IBattleEffectSource changeSource;

		// Token: 0x040043E8 RID: 17384
		internal IEnumerator $locvar0;

		// Token: 0x040043E9 RID: 17385
		internal object <_>__2;

		// Token: 0x040043EA RID: 17386
		internal IDisposable $locvar1;

		// Token: 0x040043EB RID: 17387
		internal IEnumerator $locvar2;

		// Token: 0x040043EC RID: 17388
		internal object <_>__3;

		// Token: 0x040043ED RID: 17389
		internal IDisposable $locvar3;

		// Token: 0x040043EE RID: 17390
		internal IEnumerator $locvar4;

		// Token: 0x040043EF RID: 17391
		internal object <_>__4;

		// Token: 0x040043F0 RID: 17392
		internal IDisposable $locvar5;

		// Token: 0x040043F1 RID: 17393
		internal BattleEncounter $this;

		// Token: 0x040043F2 RID: 17394
		internal object $current;

		// Token: 0x040043F3 RID: 17395
		internal bool $disposing;

		// Token: 0x040043F4 RID: 17396
		internal int $PC;
	}

	// Token: 0x02000CE9 RID: 3305
	[CompilerGenerated]
	private sealed class <CalculateDeadUnitRewards>c__IteratorE : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600556E RID: 21870 RVA: 0x000D42E4 File Offset: 0x000D26E4
		[DebuggerHidden]
		public <CalculateDeadUnitRewards>c__IteratorE()
		{
		}

		// Token: 0x0600556F RID: 21871 RVA: 0x000D42EC File Offset: 0x000D26EC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				adventure = unit.CurrentAdventure;
				if (adventure.CorrespondingDifficultyMeasurement.StarRating == -1)
				{
					goto IL_4D1;
				}
				deathUnitDroptypePresences = new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 100
					}
				};
				deadUnitDropConfiguration = new DropConfiguration(new List<ResourceType>(), new List<DropType>(), deathUnitDroptypePresences, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, adventure.CorrespondingDifficultyMeasurement.GetDefaultItemGenerationDistribution(ResourceSourceType.DungeonDrop));
				if (!(unit is EnemyBattleUnit))
				{
					goto IL_4D1;
				}
				monster = (unit as EnemyBattleUnit);
				baseDungeonTable = base.CurrentAdventure.CorrespondingDifficultyMeasurement.GetStandardDropableCompleteTable();
				hitsForUnit = adventure.CorrespondingDifficultyMeasurement.GetUnitDeathHits(monster);
				droptableForUnit = new DropTable(new List<DropTableParameter>());
				if (unit.IsBoss())
				{
					if (unit.CurrentEncounter.PlayerUnits.Any((IBattleUnit p) => p.SpecialEffects.OfType<BossMaterialDropData>().Any<BossMaterialDropData>()))
					{
						hitsForUnit.Add(1.0);
					}
				}
				droptableForUnit.CombineWith(baseDungeonTable);
				drops = droptableForUnit.GetDrops_LuckRelevance(hitsForUnit, deadUnitDropConfiguration, adventure.CorrespondingDifficultyMeasurement);
				enumerator = drops.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ResourceUpdate resourceUpdate = enumerator.Current;
						if (resourceUpdate.ResourceType.GetResourceCategory() == ResourceCategory.Ore)
						{
							double num2 = base.CurrentAdventure.Adventurers.Sum((AdventurerBattleUnit u) => u.GetAttributeValue_Final(AttributeType.Mining, AttributeRetrievalLevel.Skill)) + 1.0;
							if (num2 < 1.0)
							{
								num2 = 1.0;
							}
							int num3 = (int)Math.Round(resourceUpdate.ChangeAmount * num2);
							resourceUpdate.ChangeAmount = (double)num3;
						}
						if (resourceUpdate.ResourceType.GetResourceCategory() == ResourceCategory.Hides)
						{
							double num4 = base.CurrentAdventure.Adventurers.Sum((AdventurerBattleUnit u) => u.GetAttributeValue_Final(AttributeType.Hunting, AttributeRetrievalLevel.Skill)) + 1.0;
							if (num4 < 1.0)
							{
								num4 = 1.0;
							}
							int num5 = (int)Math.Round(resourceUpdate.ChangeAmount * num4);
							resourceUpdate.ChangeAmount = (double)num5;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				monsterConfig = (unit.GetUnitType().GetConfiguration() as MonsterUnitConfigurationBase);
				if (monsterConfig != null)
				{
					drops.AddRange(monsterConfig.GenerateGuarranteedDrops(adventure));
				}
				enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleUnitPreDrops, drops)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_437;
			case 3u:
				Block_17:
				try
				{
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						_3 = enumerator4.Current;
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
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.EnemyUnitDropsLoot, drops2)).GetEnumerator();
				num = 4294967293u;
				goto Block_18;
			case 4u:
				goto IL_678;
			default:
				return false;
			}
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
			enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.EnemyUnitDropsLoot, drops)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_437:
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
			this._drops.AddRange(drops);
			IL_4D1:
			if (adventure.CorrespondingDifficultyMeasurement.StarRating != -1 || !(unit is EnemyBattleUnit))
			{
				goto IL_712;
			}
			monster2 = (unit as EnemyBattleUnit);
			if (monster2.SlotSelection != AdventureEncounterSlotType.Boss)
			{
				goto IL_712;
			}
			drops2 = new List<ResourceUpdate>();
			if ((double)UnityEngine.Random.value <= adventure.CorrespondingDifficultyMeasurement.GetAmuletChance())
			{
				drops2.AddRange(adventure.CorrespondingDifficultyMeasurement.GetAmuletDrop());
			}
			if ((double)UnityEngine.Random.value <= 0.12)
			{
				drops2.AddRange(base.CurrentAdventure.CorrespondingDifficultyMeasurement.GenerateRandomDevice());
			}
			if (drops2.Any<ResourceUpdate>())
			{
				enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleUnitPreDrops, drops2)).GetEnumerator();
				num = 4294967293u;
				goto Block_17;
			}
			goto IL_712;
			Block_18:
			try
			{
				IL_678:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
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
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			this._drops.AddRange(drops2);
			IL_712:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001222 RID: 4642
		// (get) Token: 0x06005570 RID: 21872 RVA: 0x000D4A94 File Offset: 0x000D2E94
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001223 RID: 4643
		// (get) Token: 0x06005571 RID: 21873 RVA: 0x000D4A9C File Offset: 0x000D2E9C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005572 RID: 21874 RVA: 0x000D4AA4 File Offset: 0x000D2EA4
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
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
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
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
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005573 RID: 21875 RVA: 0x000D4BD0 File Offset: 0x000D2FD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005574 RID: 21876 RVA: 0x000D4BD7 File Offset: 0x000D2FD7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005575 RID: 21877 RVA: 0x000D4BE0 File Offset: 0x000D2FE0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEncounter.<CalculateDeadUnitRewards>c__IteratorE <CalculateDeadUnitRewards>c__IteratorE = new BattleEncounter.<CalculateDeadUnitRewards>c__IteratorE();
			<CalculateDeadUnitRewards>c__IteratorE.$this = this;
			<CalculateDeadUnitRewards>c__IteratorE.unit = unit;
			return <CalculateDeadUnitRewards>c__IteratorE;
		}

		// Token: 0x06005576 RID: 21878 RVA: 0x000D4C20 File Offset: 0x000D3020
		private static bool <>m__0(IBattleUnit p)
		{
			return p.SpecialEffects.OfType<BossMaterialDropData>().Any<BossMaterialDropData>();
		}

		// Token: 0x06005577 RID: 21879 RVA: 0x000D4C32 File Offset: 0x000D3032
		private static double <>m__1(AdventurerBattleUnit u)
		{
			return u.GetAttributeValue_Final(AttributeType.Mining, AttributeRetrievalLevel.Skill);
		}

		// Token: 0x06005578 RID: 21880 RVA: 0x000D4C40 File Offset: 0x000D3040
		private static double <>m__2(AdventurerBattleUnit u)
		{
			return u.GetAttributeValue_Final(AttributeType.Hunting, AttributeRetrievalLevel.Skill);
		}

		// Token: 0x040043F5 RID: 17397
		internal IBattleUnit unit;

		// Token: 0x040043F6 RID: 17398
		internal Adventure <adventure>__0;

		// Token: 0x040043F7 RID: 17399
		internal List<DropTypePresence> <deathUnitDroptypePresences>__1;

		// Token: 0x040043F8 RID: 17400
		internal DropConfiguration <deadUnitDropConfiguration>__1;

		// Token: 0x040043F9 RID: 17401
		internal EnemyBattleUnit <monster>__2;

		// Token: 0x040043FA RID: 17402
		internal DropTable <baseDungeonTable>__2;

		// Token: 0x040043FB RID: 17403
		internal List<double> <hitsForUnit>__2;

		// Token: 0x040043FC RID: 17404
		internal DropTable <droptableForUnit>__2;

		// Token: 0x040043FD RID: 17405
		internal List<ResourceUpdate> <drops>__2;

		// Token: 0x040043FE RID: 17406
		internal List<ResourceUpdate>.Enumerator $locvar0;

		// Token: 0x040043FF RID: 17407
		internal MonsterUnitConfigurationBase <monsterConfig>__2;

		// Token: 0x04004400 RID: 17408
		internal IEnumerator $locvar1;

		// Token: 0x04004401 RID: 17409
		internal object <_>__3;

		// Token: 0x04004402 RID: 17410
		internal IDisposable $locvar2;

		// Token: 0x04004403 RID: 17411
		internal IEnumerator $locvar3;

		// Token: 0x04004404 RID: 17412
		internal object <_>__4;

		// Token: 0x04004405 RID: 17413
		internal IDisposable $locvar4;

		// Token: 0x04004406 RID: 17414
		internal EnemyBattleUnit <monster>__5;

		// Token: 0x04004407 RID: 17415
		internal List<ResourceUpdate> <drops>__6;

		// Token: 0x04004408 RID: 17416
		internal IEnumerator $locvar5;

		// Token: 0x04004409 RID: 17417
		internal object <_>__7;

		// Token: 0x0400440A RID: 17418
		internal IDisposable $locvar6;

		// Token: 0x0400440B RID: 17419
		internal IEnumerator $locvar7;

		// Token: 0x0400440C RID: 17420
		internal object <_>__8;

		// Token: 0x0400440D RID: 17421
		internal IDisposable $locvar8;

		// Token: 0x0400440E RID: 17422
		internal BattleEncounter $this;

		// Token: 0x0400440F RID: 17423
		internal object $current;

		// Token: 0x04004410 RID: 17424
		internal bool $disposing;

		// Token: 0x04004411 RID: 17425
		internal int $PC;

		// Token: 0x04004412 RID: 17426
		private static Func<IBattleUnit, bool> <>f__am$cache0;

		// Token: 0x04004413 RID: 17427
		private static Func<AdventurerBattleUnit, double> <>f__am$cache1;

		// Token: 0x04004414 RID: 17428
		private static Func<AdventurerBattleUnit, double> <>f__am$cache2;
	}

	// Token: 0x02000CEA RID: 3306
	[CompilerGenerated]
	private sealed class <PerUpdateProcess>c__IteratorF : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005579 RID: 21881 RVA: 0x000D4C4E File Offset: 0x000D304E
		[DebuggerHidden]
		public <PerUpdateProcess>c__IteratorF()
		{
		}

		// Token: 0x0600557A RID: 21882 RVA: 0x000D4C56 File Offset: 0x000D3056
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001224 RID: 4644
		// (get) Token: 0x0600557B RID: 21883 RVA: 0x000D4C70 File Offset: 0x000D3070
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001225 RID: 4645
		// (get) Token: 0x0600557C RID: 21884 RVA: 0x000D4C78 File Offset: 0x000D3078
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600557D RID: 21885 RVA: 0x000D4C80 File Offset: 0x000D3080
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600557E RID: 21886 RVA: 0x000D4C82 File Offset: 0x000D3082
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600557F RID: 21887 RVA: 0x000D4C89 File Offset: 0x000D3089
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005580 RID: 21888 RVA: 0x000D4C91 File Offset: 0x000D3091
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEncounter.<PerUpdateProcess>c__IteratorF();
		}

		// Token: 0x04004415 RID: 17429
		internal object $current;

		// Token: 0x04004416 RID: 17430
		internal bool $disposing;

		// Token: 0x04004417 RID: 17431
		internal int $PC;
	}
}
