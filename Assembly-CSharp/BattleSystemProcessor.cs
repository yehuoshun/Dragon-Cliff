using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000486 RID: 1158
public class BattleSystemProcessor : IFactionProcessor
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x000E4478 File Offset: 0x000E2878
	public BattleSystemProcessor()
	{
	}

	// Token: 0x17000227 RID: 551
	// (get) Token: 0x060020D9 RID: 8409 RVA: 0x000E4480 File Offset: 0x000E2880
	public GameFactionType CorrespondingGameFactionType
	{
		get
		{
			return GameFactionType.BattleSystem;
		}
	}

	// Token: 0x060020DA RID: 8410 RVA: 0x000E4483 File Offset: 0x000E2883
	public void ProcessGameEvent(GameWorldEvent evt, object data)
	{
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x000E4488 File Offset: 0x000E2888
	public IEnumerable ProcessBattleEvent(BroadcastEvent evt)
	{
		IEnumerator enumerator = BattleSystemProcessor.CalculateDeadUnitRewards(evt).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object p2 = enumerator.Current;
				yield return p2;
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
		if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single && evt.AdditionalData is DamageComponent)
		{
			DamageComponent damageComponent = evt.AdditionalData as DamageComponent;
			if (damageComponent.IsFatal != null && damageComponent.IsFatal.Value)
			{
				string text = UIComponentType.UnitKilled.GetName();
				IBattleUnit eventTriggeringUnit = evt.EventTriggeringUnit;
				IBattleUnit dealer = damageComponent.Dealer;
				string newValue = string.Join(", ", (from p in damageComponent.Potions
				select p.GetFinalDamageSoFar().DoubleToShortNumber() + " " + p.DamageType.GetDescription().Title).ToArray<string>());
				string text2 = string.Empty;
				if (dealer is AdventurerBattleUnit)
				{
					text2 = (dealer as AdventurerBattleUnit).AdventurerProfile.GetUnitName();
				}
				if (dealer is PetBattleUnit)
				{
					text2 = dealer.GetUnitType().GetDescription().Title;
				}
				if (dealer is EnemyBattleUnit)
				{
					text2 = (dealer as EnemyBattleUnit).SlotSelection.GetDescription().Title;
				}
				string ncontent = string.Empty;
				if (eventTriggeringUnit is AdventurerBattleUnit)
				{
					ncontent = (eventTriggeringUnit as AdventurerBattleUnit).AdventurerProfile.GetUnitName();
				}
				if (eventTriggeringUnit is PetBattleUnit)
				{
					ncontent = eventTriggeringUnit.GetUnitType().GetDescription().Title;
				}
				if (eventTriggeringUnit is EnemyBattleUnit)
				{
					ncontent = (eventTriggeringUnit as EnemyBattleUnit).SlotSelection.GetDescription().Title;
				}
				if (damageComponent.DamageSource is AdventureUnitSkill)
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"(",
						UIComponentType.BattleLogSkillName.GetName(),
						(damageComponent.DamageSource as AdventureUnitSkill).Skill.SkillType.GetDescription().Title,
						")"
					});
				}
				else if (damageComponent.DamageSource is BattleEffectBase)
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"(",
						UIComponentType.BattleLogEffectName.GetName(),
						(damageComponent.DamageSource as BattleEffectBase).BattleEffectType.GetDescription().Title,
						")"
					});
				}
				else if (damageComponent.DamageSource is SpecialEffectTriggerSource)
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"(",
						UIComponentType.BattleLogSpecialEffectName.GetName(),
						(damageComponent.DamageSource as SpecialEffectTriggerSource).SpecialEffectType.GetDescription().Title,
						")"
					});
				}
				else if (damageComponent.DamageSource is NormalAttackSource)
				{
					text2 = text2 + "(" + UIComponentType.BattleLogNormalAttackName.GetName() + ")";
				}
				else if (damageComponent.DamageSource is ReflectDamageSource)
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"(",
						UIComponentType.BattleLogReflectionDamageName.GetName(),
						this.GetFrom((damageComponent.DamageSource as ReflectDamageSource).ReflectDamageFrom),
						")"
					});
				}
				else if (damageComponent.DamageSource is DamageOverTimeTickSource)
				{
					text2 = text2 + "(" + UIComponentType.BattleLogDamageOverTimeTickName.GetName() + ")";
				}
				else if (damageComponent.DamageSource is DamageOverTimeInstantSource)
				{
					text2 = text2 + "(" + UIComponentType.BattleLogDamageOverTimeInstantName.GetName() + ")";
				}
				else if (damageComponent.DamageSource is FireSeedExplosionSource)
				{
					text2 = text2 + "(" + UIComponentType.BattleLogFireSeedExplosionName.GetName() + ")";
				}
				text = text.ReplaceToBuilder("{unit}", ncontent).Replace("{damage}", damageComponent.GetTotalDamageSoFar().DoubleToShortNumber()).Replace("{from}", text2).Replace("{types}", newValue).ToString();
				evt.EventTriggeringUnit.CurrentEncounter.Log.AddLog(text);
			}
			if (damageComponent.Dealer.IsPlayer && damageComponent.Dealer is AdventurerBattleUnit)
			{
				evt.EventTriggeringUnit.CurrentEncounter.CurrentAdventure.AddDamageRecord(damageComponent.Dealer as AdventurerBattleUnit, damageComponent.GetTotalDamageSoFar());
			}
		}
		if (evt.EventType == AdventureEventType.UnitPostCastSkill)
		{
			List<BattleEffectBase> toRemove = (from ef in evt.EventTriggeringUnit.BattleEffects
			where ef.EffectSourceIdentityCode.StartsWith(AttributeModificationEffect.PostDamageReleaseRemovePartial)
			select ef).ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase in toRemove)
			{
				IEnumerator enumerator3 = evt.EventTriggeringUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _ = enumerator3.Current;
						yield return _;
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
		if (evt.EventType == AdventureEventType.BattleEncounterStarts)
		{
			BattleEncounter battleEncounter = evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null)
			{
				List<AdventurerCombatController> currentAdventurers = BattleManager.instance.Spawner.GetCurrentAdventurers();
				foreach (AdventurerCombatController adventurerCombatController in currentAdventurers)
				{
					if (adventurerCombatController != null && adventurerCombatController.BattleUnit != null && adventurerCombatController.BattleUnit.IsAliveInBattle())
					{
						adventurerCombatController.UpdateHealthBar();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x000E44B4 File Offset: 0x000E28B4
	private string GetFrom(IBattleEffectSource damageSource)
	{
		string str = "[";
		if (damageSource.SourceUnit is AdventurerBattleUnit)
		{
			str += (damageSource.SourceUnit as AdventurerBattleUnit).AdventurerProfile.GetUnitName();
		}
		if (damageSource.SourceUnit is PetBattleUnit)
		{
			str += damageSource.SourceUnit.GetUnitType().GetDescription().Title;
		}
		if (damageSource.SourceUnit is EnemyBattleUnit)
		{
			str += (damageSource.SourceUnit as EnemyBattleUnit).SlotSelection.GetDescription().Title;
		}
		if (damageSource is AdventureUnitSkill)
		{
			str = str + "-" + UIComponentType.BattleLogSkillName.GetName() + (damageSource as AdventureUnitSkill).Skill.SkillType.GetDescription().Title;
		}
		else if (damageSource is BattleEffectBase)
		{
			str = str + "-" + UIComponentType.BattleLogEffectName.GetName() + (damageSource as BattleEffectBase).BattleEffectType.GetDescription().Title;
		}
		else if (damageSource is SpecialEffectTriggerSource)
		{
			str = str + "-" + UIComponentType.BattleLogSpecialEffectName.GetName() + (damageSource as SpecialEffectTriggerSource).SpecialEffectType.GetDescription().Title;
		}
		else if (damageSource is NormalAttackSource)
		{
			str = str + "-" + UIComponentType.BattleLogNormalAttackName.GetName();
		}
		else if (damageSource is ReflectDamageSource)
		{
			str = str + "-" + UIComponentType.BattleLogReflectionDamageName.GetName();
		}
		else if (damageSource is DamageOverTimeTickSource)
		{
			str = str + "-" + UIComponentType.BattleLogDamageOverTimeTickName.GetName();
		}
		else if (damageSource is DamageOverTimeInstantSource)
		{
			str = str + "-" + UIComponentType.BattleLogDamageOverTimeInstantName.GetName();
		}
		else if (damageSource is FireSeedExplosionSource)
		{
			str = str + "-" + UIComponentType.BattleLogFireSeedExplosionName.GetName();
		}
		return str + "]";
	}

	// Token: 0x060020DD RID: 8413 RVA: 0x000E46CC File Offset: 0x000E2ACC
	public List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage_Single,
			AdventureEventType.UnitKilled,
			AdventureEventType.UnitPostCastSkill,
			AdventureEventType.BattleEncounterStarts
		};
	}

	// Token: 0x060020DE RID: 8414 RVA: 0x000E4700 File Offset: 0x000E2B00
	private static IEnumerable CalculateDeadUnitRewards(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitKilled && evt.EventTriggeringUnit.CurrentEncounter is BattleEncounter)
		{
			IEncounter encounter = evt.EventTriggeringUnit.CurrentEncounter;
			IEnumerator enumerator = (encounter as BattleEncounter).CalculateDeadUnitRewards(evt.EventTriggeringUnit).GetEnumerator();
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
			BattleEncounter battleEncounter = encounter as BattleEncounter;
			if (evt.EventTriggeringUnit.IsPlayer)
			{
				List<PetBattleUnit> pets = (from u in battleEncounter.PlayerUnits.OfType<PetBattleUnit>()
				where u.OwnerUnit == evt.EventTriggeringUnit
				select u).ToList<PetBattleUnit>();
				foreach (PetBattleUnit petBattleUnit in pets)
				{
					IEnumerator enumerator3 = battleEncounter.RemovePet(petBattleUnit).GetEnumerator();
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
			else
			{
				List<PetBattleUnit> pets2 = (from u in battleEncounter.EnemyUnits.OfType<PetBattleUnit>()
				where u.OwnerUnit == evt.EventTriggeringUnit
				select u).ToList<PetBattleUnit>();
				foreach (PetBattleUnit petBattleUnit2 in pets2)
				{
					IEnumerator enumerator5 = battleEncounter.RemovePet(petBattleUnit2).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x02000D2E RID: 3374
	[CompilerGenerated]
	private sealed class <ProcessBattleEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005659 RID: 22105 RVA: 0x000E4723 File Offset: 0x000E2B23
		[DebuggerHidden]
		public <ProcessBattleEvent>c__Iterator0()
		{
		}

		// Token: 0x0600565A RID: 22106 RVA: 0x000E472C File Offset: 0x000E2B2C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = BattleSystemProcessor.CalculateDeadUnitRewards(evt).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_5B7;
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
					p = enumerator.Current;
					this.$current = p;
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
			if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single && evt.AdditionalData is DamageComponent)
			{
				DamageComponent damageComponent = evt.AdditionalData as DamageComponent;
				if (damageComponent.IsFatal != null && damageComponent.IsFatal.Value)
				{
					string text = UIComponentType.UnitKilled.GetName();
					IBattleUnit eventTriggeringUnit = evt.EventTriggeringUnit;
					IBattleUnit dealer = damageComponent.Dealer;
					string newValue = string.Join(", ", (from p in damageComponent.Potions
					select p.GetFinalDamageSoFar().DoubleToShortNumber() + " " + p.DamageType.GetDescription().Title).ToArray<string>());
					string text2 = string.Empty;
					if (dealer is AdventurerBattleUnit)
					{
						text2 = (dealer as AdventurerBattleUnit).AdventurerProfile.GetUnitName();
					}
					if (dealer is PetBattleUnit)
					{
						text2 = dealer.GetUnitType().GetDescription().Title;
					}
					if (dealer is EnemyBattleUnit)
					{
						text2 = (dealer as EnemyBattleUnit).SlotSelection.GetDescription().Title;
					}
					string ncontent = string.Empty;
					if (eventTriggeringUnit is AdventurerBattleUnit)
					{
						ncontent = (eventTriggeringUnit as AdventurerBattleUnit).AdventurerProfile.GetUnitName();
					}
					if (eventTriggeringUnit is PetBattleUnit)
					{
						ncontent = eventTriggeringUnit.GetUnitType().GetDescription().Title;
					}
					if (eventTriggeringUnit is EnemyBattleUnit)
					{
						ncontent = (eventTriggeringUnit as EnemyBattleUnit).SlotSelection.GetDescription().Title;
					}
					if (damageComponent.DamageSource is AdventureUnitSkill)
					{
						string text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							"(",
							UIComponentType.BattleLogSkillName.GetName(),
							(damageComponent.DamageSource as AdventureUnitSkill).Skill.SkillType.GetDescription().Title,
							")"
						});
					}
					else if (damageComponent.DamageSource is BattleEffectBase)
					{
						string text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							"(",
							UIComponentType.BattleLogEffectName.GetName(),
							(damageComponent.DamageSource as BattleEffectBase).BattleEffectType.GetDescription().Title,
							")"
						});
					}
					else if (damageComponent.DamageSource is SpecialEffectTriggerSource)
					{
						string text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							"(",
							UIComponentType.BattleLogSpecialEffectName.GetName(),
							(damageComponent.DamageSource as SpecialEffectTriggerSource).SpecialEffectType.GetDescription().Title,
							")"
						});
					}
					else if (damageComponent.DamageSource is NormalAttackSource)
					{
						text2 = text2 + "(" + UIComponentType.BattleLogNormalAttackName.GetName() + ")";
					}
					else if (damageComponent.DamageSource is ReflectDamageSource)
					{
						string text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							"(",
							UIComponentType.BattleLogReflectionDamageName.GetName(),
							base.GetFrom((damageComponent.DamageSource as ReflectDamageSource).ReflectDamageFrom),
							")"
						});
					}
					else if (damageComponent.DamageSource is DamageOverTimeTickSource)
					{
						text2 = text2 + "(" + UIComponentType.BattleLogDamageOverTimeTickName.GetName() + ")";
					}
					else if (damageComponent.DamageSource is DamageOverTimeInstantSource)
					{
						text2 = text2 + "(" + UIComponentType.BattleLogDamageOverTimeInstantName.GetName() + ")";
					}
					else if (damageComponent.DamageSource is FireSeedExplosionSource)
					{
						text2 = text2 + "(" + UIComponentType.BattleLogFireSeedExplosionName.GetName() + ")";
					}
					text = text.ReplaceToBuilder("{unit}", ncontent).Replace("{damage}", damageComponent.GetTotalDamageSoFar().DoubleToShortNumber()).Replace("{from}", text2).Replace("{types}", newValue).ToString();
					evt.EventTriggeringUnit.CurrentEncounter.Log.AddLog(text);
				}
				if (damageComponent.Dealer.IsPlayer && damageComponent.Dealer is AdventurerBattleUnit)
				{
					evt.EventTriggeringUnit.CurrentEncounter.CurrentAdventure.AddDamageRecord(damageComponent.Dealer as AdventurerBattleUnit, damageComponent.GetTotalDamageSoFar());
				}
			}
			if (evt.EventType != AdventureEventType.UnitPostCastSkill)
			{
				goto IL_6AB;
			}
			toRemove = (from ef in evt.EventTriggeringUnit.BattleEffects
			where ef.EffectSourceIdentityCode.StartsWith(AttributeModificationEffect.PostDamageReleaseRemovePartial)
			select ef).ToList<BattleEffectBase>();
			enumerator2 = toRemove.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_5B7:
				switch (num)
				{
				case 2u:
					Block_37:
					try
					{
						switch (num)
						{
						}
						if (enumerator3.MoveNext())
						{
							_ = enumerator3.Current;
							this.$current = _;
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
					battleEffectBase = enumerator2.Current;
					enumerator3 = evt.EventTriggeringUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					num = 4294967293u;
					goto Block_37;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_6AB:
			if (evt.EventType == AdventureEventType.BattleEncounterStarts)
			{
				BattleEncounter battleEncounter = evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter;
				if (battleEncounter != null)
				{
					List<AdventurerCombatController> currentAdventurers = BattleManager.instance.Spawner.GetCurrentAdventurers();
					foreach (AdventurerCombatController adventurerCombatController in currentAdventurers)
					{
						if (adventurerCombatController != null && adventurerCombatController.BattleUnit != null && adventurerCombatController.BattleUnit.IsAliveInBattle())
						{
							adventurerCombatController.UpdateHealthBar();
						}
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001238 RID: 4664
		// (get) Token: 0x0600565B RID: 22107 RVA: 0x000E4ECC File Offset: 0x000E32CC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001239 RID: 4665
		// (get) Token: 0x0600565C RID: 22108 RVA: 0x000E4ED4 File Offset: 0x000E32D4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600565D RID: 22109 RVA: 0x000E4EDC File Offset: 0x000E32DC
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
			}
		}

		// Token: 0x0600565E RID: 22110 RVA: 0x000E4FB0 File Offset: 0x000E33B0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600565F RID: 22111 RVA: 0x000E4FB7 File Offset: 0x000E33B7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005660 RID: 22112 RVA: 0x000E4FC0 File Offset: 0x000E33C0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleSystemProcessor.<ProcessBattleEvent>c__Iterator0 <ProcessBattleEvent>c__Iterator = new BattleSystemProcessor.<ProcessBattleEvent>c__Iterator0();
			<ProcessBattleEvent>c__Iterator.$this = this;
			<ProcessBattleEvent>c__Iterator.evt = evt;
			return <ProcessBattleEvent>c__Iterator;
		}

		// Token: 0x06005661 RID: 22113 RVA: 0x000E5000 File Offset: 0x000E3400
		private static string <>m__0(DamageComponentPotion p)
		{
			return p.GetFinalDamageSoFar().DoubleToShortNumber() + " " + p.DamageType.GetDescription().Title;
		}

		// Token: 0x06005662 RID: 22114 RVA: 0x000E5027 File Offset: 0x000E3427
		private static bool <>m__1(BattleEffectBase ef)
		{
			return ef.EffectSourceIdentityCode.StartsWith(AttributeModificationEffect.PostDamageReleaseRemovePartial);
		}

		// Token: 0x040044D5 RID: 17621
		internal BroadcastEvent evt;

		// Token: 0x040044D6 RID: 17622
		internal IEnumerator $locvar0;

		// Token: 0x040044D7 RID: 17623
		internal object <p>__1;

		// Token: 0x040044D8 RID: 17624
		internal IDisposable $locvar1;

		// Token: 0x040044D9 RID: 17625
		internal List<BattleEffectBase> <toRemove>__2;

		// Token: 0x040044DA RID: 17626
		internal List<BattleEffectBase>.Enumerator $locvar2;

		// Token: 0x040044DB RID: 17627
		internal BattleEffectBase <battleEffectBase>__3;

		// Token: 0x040044DC RID: 17628
		internal IEnumerator $locvar3;

		// Token: 0x040044DD RID: 17629
		internal object <_>__4;

		// Token: 0x040044DE RID: 17630
		internal IDisposable $locvar4;

		// Token: 0x040044DF RID: 17631
		internal BattleSystemProcessor $this;

		// Token: 0x040044E0 RID: 17632
		internal object $current;

		// Token: 0x040044E1 RID: 17633
		internal bool $disposing;

		// Token: 0x040044E2 RID: 17634
		internal int $PC;

		// Token: 0x040044E3 RID: 17635
		private static Func<DamageComponentPotion, string> <>f__am$cache0;

		// Token: 0x040044E4 RID: 17636
		private static Func<BattleEffectBase, bool> <>f__am$cache1;
	}

	// Token: 0x02000D2F RID: 3375
	[CompilerGenerated]
	private sealed class <CalculateDeadUnitRewards>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005663 RID: 22115 RVA: 0x000E5039 File Offset: 0x000E3439
		[DebuggerHidden]
		public <CalculateDeadUnitRewards>c__Iterator1()
		{
		}

		// Token: 0x06005664 RID: 22116 RVA: 0x000E5044 File Offset: 0x000E3444
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitKilled || !(evt.EventTriggeringUnit.CurrentEncounter is BattleEncounter))
				{
					goto IL_3EA;
				}
				encounter = evt.EventTriggeringUnit.CurrentEncounter;
				enumerator = (encounter as BattleEncounter).CalculateDeadUnitRewards(evt.EventTriggeringUnit).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1C4;
			case 3u:
				goto IL_2FC;
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
			battleEncounter = (encounter as BattleEncounter);
			if (!<CalculateDeadUnitRewards>c__AnonStorey.evt.EventTriggeringUnit.IsPlayer)
			{
				pets2 = (from u in battleEncounter.EnemyUnits.OfType<PetBattleUnit>()
				where u.OwnerUnit == <CalculateDeadUnitRewards>c__AnonStorey.evt.EventTriggeringUnit
				select u).ToList<PetBattleUnit>();
				enumerator4 = pets2.GetEnumerator();
				num = 4294967293u;
				goto Block_7;
			}
			pets = (from u in battleEncounter.PlayerUnits.OfType<PetBattleUnit>()
			where u.OwnerUnit == <CalculateDeadUnitRewards>c__AnonStorey.evt.EventTriggeringUnit
			select u).ToList<PetBattleUnit>();
			enumerator2 = pets.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1C4:
				switch (num)
				{
				case 2u:
					Block_15:
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
					petBattleUnit = enumerator2.Current;
					enumerator3 = battleEncounter.RemovePet(petBattleUnit).GetEnumerator();
					num = 4294967293u;
					goto Block_15;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			goto IL_3EA;
			Block_7:
			try
			{
				IL_2FC:
				switch (num)
				{
				case 3u:
					Block_26:
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
				}
				if (enumerator4.MoveNext())
				{
					petBattleUnit2 = enumerator4.Current;
					enumerator5 = battleEncounter.RemovePet(petBattleUnit2).GetEnumerator();
					num = 4294967293u;
					goto Block_26;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
			IL_3EA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700123A RID: 4666
		// (get) Token: 0x06005665 RID: 22117 RVA: 0x000E5488 File Offset: 0x000E3888
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700123B RID: 4667
		// (get) Token: 0x06005666 RID: 22118 RVA: 0x000E5490 File Offset: 0x000E3890
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005667 RID: 22119 RVA: 0x000E5498 File Offset: 0x000E3898
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
				try
				{
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
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005668 RID: 22120 RVA: 0x000E55CC File Offset: 0x000E39CC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005669 RID: 22121 RVA: 0x000E55D3 File Offset: 0x000E39D3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600566A RID: 22122 RVA: 0x000E55DC File Offset: 0x000E39DC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleSystemProcessor.<CalculateDeadUnitRewards>c__Iterator1 <CalculateDeadUnitRewards>c__Iterator = new BattleSystemProcessor.<CalculateDeadUnitRewards>c__Iterator1();
			<CalculateDeadUnitRewards>c__Iterator.evt = evt;
			return <CalculateDeadUnitRewards>c__Iterator;
		}

		// Token: 0x040044E5 RID: 17637
		internal BroadcastEvent evt;

		// Token: 0x040044E6 RID: 17638
		internal IEncounter <encounter>__1;

		// Token: 0x040044E7 RID: 17639
		internal IEnumerator $locvar0;

		// Token: 0x040044E8 RID: 17640
		internal object <_>__2;

		// Token: 0x040044E9 RID: 17641
		internal IDisposable $locvar1;

		// Token: 0x040044EA RID: 17642
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x040044EB RID: 17643
		internal List<PetBattleUnit> <pets>__3;

		// Token: 0x040044EC RID: 17644
		internal List<PetBattleUnit>.Enumerator $locvar2;

		// Token: 0x040044ED RID: 17645
		internal PetBattleUnit <petBattleUnit>__4;

		// Token: 0x040044EE RID: 17646
		internal IEnumerator $locvar3;

		// Token: 0x040044EF RID: 17647
		internal object <_>__5;

		// Token: 0x040044F0 RID: 17648
		internal IDisposable $locvar4;

		// Token: 0x040044F1 RID: 17649
		internal List<PetBattleUnit> <pets>__6;

		// Token: 0x040044F2 RID: 17650
		internal List<PetBattleUnit>.Enumerator $locvar5;

		// Token: 0x040044F3 RID: 17651
		internal PetBattleUnit <petBattleUnit>__7;

		// Token: 0x040044F4 RID: 17652
		internal IEnumerator $locvar6;

		// Token: 0x040044F5 RID: 17653
		internal object <_>__8;

		// Token: 0x040044F6 RID: 17654
		internal IDisposable $locvar7;

		// Token: 0x040044F7 RID: 17655
		internal object $current;

		// Token: 0x040044F8 RID: 17656
		internal bool $disposing;

		// Token: 0x040044F9 RID: 17657
		internal int $PC;

		// Token: 0x040044FA RID: 17658
		private BattleSystemProcessor.<CalculateDeadUnitRewards>c__Iterator1.<CalculateDeadUnitRewards>c__AnonStorey2 $locvar8;

		// Token: 0x02000D30 RID: 3376
		private sealed class <CalculateDeadUnitRewards>c__AnonStorey2
		{
			// Token: 0x0600566B RID: 22123 RVA: 0x000E5610 File Offset: 0x000E3A10
			public <CalculateDeadUnitRewards>c__AnonStorey2()
			{
			}

			// Token: 0x0600566C RID: 22124 RVA: 0x000E5618 File Offset: 0x000E3A18
			internal bool <>m__0(PetBattleUnit u)
			{
				return u.OwnerUnit == this.evt.EventTriggeringUnit;
			}

			// Token: 0x0600566D RID: 22125 RVA: 0x000E562D File Offset: 0x000E3A2D
			internal bool <>m__1(PetBattleUnit u)
			{
				return u.OwnerUnit == this.evt.EventTriggeringUnit;
			}

			// Token: 0x040044FB RID: 17659
			internal BroadcastEvent evt;

			// Token: 0x040044FC RID: 17660
			internal BattleSystemProcessor.<CalculateDeadUnitRewards>c__Iterator1 <>f__ref$1;
		}
	}
}
