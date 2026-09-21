using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using Core.Battle.RunePower;
using UnityEngine;

// Token: 0x02000493 RID: 1171
public static class DamageExtensions
{
	// Token: 0x06002229 RID: 8745 RVA: 0x000F2B28 File Offset: 0x000F0F28
	public static IEnumerable ReceivesDamage(this IBattleUnit unit, BattleDamage damage)
	{
		if (unit.Status == BattleUnitStatus.Active && damage.Damages.Any<DamageComponent>())
		{
			if (unit.HealthPoints < 0.0)
			{
				unit.HealthPoints = 0.0;
			}
			IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitReceivesDamage_CompleteSet, damage)).GetEnumerator();
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
			double priorPercentage = unit.HealthPoints / unit.GetMaxLife(AttributeRetrievalLevel.Skill);
			foreach (DamageComponent damageComponent in damage.Damages)
			{
				bool flag;
				if (damageComponent.IsDirectDamage)
				{
					flag = damage.Dealer.BattleEffects.All((BattleEffectBase e) => e.BattleEffectType != BattleEffectType.Fear);
				}
				else
				{
					flag = true;
				}
				bool unitCapableOfDealingDamage = flag;
				if (unit.HealthPoints < 0.0)
				{
					unit.HealthPoints = 0.0;
				}
				if (unitCapableOfDealingDamage)
				{
					if (damageComponent.CanMiss())
					{
						double attributeValue_Final = unit.GetAttributeValue_Final(AttributeType.DodgeRateAdjustment, AttributeRetrievalLevel.Skill);
						if (attributeValue_Final > 0.0)
						{
							double num = attributeValue_Final * unit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
							if (num > 0.0)
							{
								double num2 = damageComponent.Dealer.GetAttributeValue_Final(AttributeType.HitRateAdjustment, AttributeRetrievalLevel.Skill) * damageComponent.Dealer.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
								if (damageComponent.Dealer.SpecialEffects.OfType<EyeOfPrecisionEffectData>().Any<EyeOfPrecisionEffectData>())
								{
									double rate4 = damageComponent.Dealer.SpecialEffects.OfType<EyeOfPrecisionEffectData>().First<EyeOfPrecisionEffectData>().Rate;
									double num3 = damageComponent.Dealer.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill) * rate4;
									if (num3 > num2)
									{
										num3 = num2;
									}
									num2 += num3;
								}
								double num4 = num2 / (num2 + num) * 0.65 + 0.35;
								if ((double)UnityEngine.Random.value > num4)
								{
									damageComponent.SetMiss();
								}
							}
						}
					}
					IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitReceivesDamage_Single, damageComponent)).GetEnumerator();
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
					if (!damageComponent.HasFullyNeutralized())
					{
						if (unit.HealthPoints > 0.0)
						{
							double num5 = damageComponent.GetTotalDamageSoFar() - unit.HealthPoints;
							damageComponent.ExceededDamageValue = new double?((num5 <= 0.0) ? 0.0 : num5);
						}
						else
						{
							damageComponent.ExceededDamageValue = new double?(damageComponent.GetTotalDamageSoFar());
						}
						double originalHp = unit.HealthPoints;
						if (damageComponent.GetTotalDamageSoFar() > 0.0 && !unit.SpecialEffects.OfType<ProtectorData>().Any<ProtectorData>() && !unit.SpecialEffects.OfType<SacrificeEffectData>().Any<SacrificeEffectData>())
						{
							IBattleUnit protector = unit.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault((IBattleUnit u) => u.SpecialEffects.OfType<ProtectorData>().Any<ProtectorData>());
							if (protector != null && protector.HealthPoints > 0.0)
							{
								ProtectorData data = protector.SpecialEffects.OfType<ProtectorData>().First<ProtectorData>();
								ReleaseableDamage releaseable = new ReleaseableDamage(new List<BattleDamage>
								{
									new BattleDamage(protector, new SpecialEffectTriggerSource(damage.DamageSource.SourceUnit, SpecialEffectType.Protector), new List<DamageComponentValue>
									{
										new DamageComponentValue(new List<DamagePotionValue>
										{
											DamagePotionValue.CreateRawValuedDamageComponent(protector, damage.Dealer, OutputType.RealDamage, data.DamageReductionRate * damageComponent.GetTotalDamageSoFar() * data.DamageReceivedRate)
										}, protector, damage.Dealer, false, false)
									})
								}, damage.Dealer);
								IEnumerator enumerator4 = releaseable.Release().GetEnumerator();
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
								damageComponent.UpdateFinalDamageFilter(1.0 - data.DamageReductionRate);
							}
						}
						if (unit.BattleEffects.OfType<DamageReductionByValueEffect>().Any<DamageReductionByValueEffect>())
						{
							double countered = unit.BattleEffects.OfType<DamageReductionByValueEffect>().Sum((DamageReductionByValueEffect d) => d.ReductionValue);
							damageComponent.UpdateCounteredDamage(countered);
						}
						unit.HealthPoints -= damageComponent.GetTotalDamageSoFar();
						if (originalHp > 0.0 && unit.HealthPoints <= 0.0)
						{
							damageComponent.IsFatal = new bool?(true);
						}
					}
					else if (damageComponent.HasFullyNeutralized() && !damageComponent.IsMissed)
					{
						IEnumerator enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitDamageNeutralized, damageComponent)).GetEnumerator();
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
					}
					IEnumerator enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPostReceivesDamage_Single, damageComponent)).GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							object _5 = enumerator6.Current;
							yield return _5;
						}
					}
					finally
					{
						IDisposable disposable5;
						if ((disposable5 = (enumerator6 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				else
				{
					damageComponent.SetIneffective();
				}
			}
			double currentPercentage = unit.HealthPoints / unit.GetMaxLife(AttributeRetrievalLevel.Skill);
			BattleEncounter battleEncounter = unit.CurrentEncounter as BattleEncounter;
			string key = unit.GetId() + "halflifenoted";
			if (priorPercentage > 0.5 && currentPercentage <= 0.5 && battleEncounter != null && battleEncounter.AdditionalBookKeeping.All((string n) => n != key))
			{
				battleEncounter.AdditionalBookKeeping.Add(key);
				IEnumerator enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime, damage)).GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						object _6 = enumerator7.Current;
						yield return _6;
					}
				}
				finally
				{
					IDisposable disposable6;
					if ((disposable6 = (enumerator7 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			IEnumerator enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPostReceivesDamage, damage)).GetEnumerator();
			try
			{
				while (enumerator8.MoveNext())
				{
					object _7 = enumerator8.Current;
					yield return _7;
				}
			}
			finally
			{
				IDisposable disposable7;
				if ((disposable7 = (enumerator8 as IDisposable)) != null)
				{
					disposable7.Dispose();
				}
			}
			bool killedAtFirst = false;
			if (unit.HealthPoints <= 0.0)
			{
				killedAtFirst = true;
				unit.HealthPoints = 0.0;
				if (damage.Dealer.GetUnitType() == UnitClass.SnowMaiden)
				{
					bool star = damage.Dealer.SpecialEffects.OfType<SnowMaidenStarEffectData>().Any<SnowMaidenStarEffectData>();
					if (star)
					{
						IEnumerator enumerator9 = damage.Dealer.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(damage.Dealer, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.EffectHitRating,
								ModificationType = ModificationType.Multiplication,
								Value = 0.2,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "snowmaidenuniqueboost", new int?(5), null, null, false, false, true), false).GetEnumerator();
						try
						{
							while (enumerator9.MoveNext())
							{
								object _8 = enumerator9.Current;
								yield return _8;
							}
						}
						finally
						{
							IDisposable disposable8;
							if ((disposable8 = (enumerator9 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
					}
				}
				IEnumerator enumerator10 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPreKilled, damage)).GetEnumerator();
				try
				{
					while (enumerator10.MoveNext())
					{
						object _9 = enumerator10.Current;
						yield return _9;
					}
				}
				finally
				{
					IDisposable disposable9;
					if ((disposable9 = (enumerator10 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
				IEnumerator enumerator11 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPreKilledFinal, damage)).GetEnumerator();
				try
				{
					while (enumerator11.MoveNext())
					{
						object _10 = enumerator11.Current;
						yield return _10;
					}
				}
				finally
				{
					IDisposable disposable10;
					if ((disposable10 = (enumerator11 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
			}
			if (unit.HealthPoints <= 0.0 && unit.Status != BattleUnitStatus.Dead)
			{
				unit.HealthPoints = 0.0;
				unit.Status = BattleUnitStatus.Dead;
				IEnumerator enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPreRealKilled, damage)).GetEnumerator();
				try
				{
					while (enumerator12.MoveNext())
					{
						object _11 = enumerator12.Current;
						yield return _11;
					}
				}
				finally
				{
					IDisposable disposable11;
					if ((disposable11 = (enumerator12 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
				foreach (BattleEffectBase unitBattleEffect in (from ef in unit.BattleEffects
				select ef).ToList<BattleEffectBase>())
				{
					IEnumerator enumerator14 = unit.LooseSkillEffect(unitBattleEffect, EffectWearsOffType.WearerKilled).GetEnumerator();
					try
					{
						while (enumerator14.MoveNext())
						{
							object _12 = enumerator14.Current;
							yield return _12;
						}
					}
					finally
					{
						IDisposable disposable12;
						if ((disposable12 = (enumerator14 as IDisposable)) != null)
						{
							disposable12.Dispose();
						}
					}
				}
				IEnumerator enumerator15 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitKilled, damage)).GetEnumerator();
				try
				{
					while (enumerator15.MoveNext())
					{
						object _13 = enumerator15.Current;
						yield return _13;
					}
				}
				finally
				{
					IDisposable disposable13;
					if ((disposable13 = (enumerator15 as IDisposable)) != null)
					{
						disposable13.Dispose();
					}
				}
				if (!unit.IsPlayer)
				{
					IBattleUnit conjorurWithExclusive = unit.CurrentEncounter.PlayerUnits.FirstOrDefault((IBattleUnit u) => u.IsAliveInBattle() && u.GetUnitType() == UnitClass.Conjurer && u.SpecialEffects.OfType<DeathBoostData>().Any<DeathBoostData>());
					if (conjorurWithExclusive != null)
					{
						IEnumerator enumerator16 = ProtectionOfTheDeadEffect.AddLayer(1, conjorurWithExclusive, conjorurWithExclusive).GetEnumerator();
						try
						{
							while (enumerator16.MoveNext())
							{
								object _14 = enumerator16.Current;
								yield return _14;
							}
						}
						finally
						{
							IDisposable disposable14;
							if ((disposable14 = (enumerator16 as IDisposable)) != null)
							{
								disposable14.Dispose();
							}
						}
					}
				}
			}
			else if (killedAtFirst)
			{
				if (unit.IsPlayer && unit.CurrentAdventure.RunePower != null)
				{
					int rate = (int)Math.Round((double)unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.VitalEnergyRebirthCollection) * 0.4);
					if (rate > 0 && (double)UnityEngine.Random.value <= 0.5)
					{
						IEnumerator enumerator17 = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.VitalEnergy, rate, unit).GetEnumerator();
						try
						{
							while (enumerator17.MoveNext())
							{
								object _15 = enumerator17.Current;
								yield return _15;
							}
						}
						finally
						{
							IDisposable disposable15;
							if ((disposable15 = (enumerator17 as IDisposable)) != null)
							{
								disposable15.Dispose();
							}
						}
					}
				}
				if (unit.IsPlayer && unit.GetUnitType() == UnitClass.DrunkReader)
				{
					bool star2 = unit.SpecialEffects.OfType<DrunkReaderStarUndeadData>().Any<DrunkReaderStarUndeadData>();
					if (star2)
					{
						List<IBattleUnit> targets = unit.GetLiveEnemyTargets(false, false);
						ReleaseableDamage extraDamage = new ReleaseableDamage((from t in targets
						select new BattleDamage(t, new SpecialEffectTriggerSource(unit, SpecialEffectType.DrunkReaderStarUndead), new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(unit, t, unit.GetOutputType(), 100.0)
							}, t, unit, false, false)
						})).ToList<BattleDamage>(), unit);
						IEnumerator enumerator18 = extraDamage.Release().GetEnumerator();
						try
						{
							while (enumerator18.MoveNext())
							{
								object _16 = enumerator18.Current;
								yield return _16;
							}
						}
						finally
						{
							IDisposable disposable16;
							if ((disposable16 = (enumerator18 as IDisposable)) != null)
							{
								disposable16.Dispose();
							}
						}
					}
				}
				IEnumerator enumerator19 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitRevived, unit)).GetEnumerator();
				try
				{
					while (enumerator19.MoveNext())
					{
						object _17 = enumerator19.Current;
						yield return _17;
					}
				}
				finally
				{
					IDisposable disposable17;
					if ((disposable17 = (enumerator19 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
			}
			IEnumerator enumerator20 = DamageExtensions.ElementalDamageCalculation(unit, damage).GetEnumerator();
			try
			{
				while (enumerator20.MoveNext())
				{
					object p = enumerator20.Current;
					yield return p;
				}
			}
			finally
			{
				IDisposable disposable18;
				if ((disposable18 = (enumerator20 as IDisposable)) != null)
				{
					disposable18.Dispose();
				}
			}
			if (damage.Damages.Any((DamageComponent d) => d.IsDirectDamage))
			{
				List<DamageComponent> validDamages = (from d in damage.Damages
				where d.IsDirectDamage
				select d).ToList<DamageComponent>();
				double normalHitGaugeValue = 10.0;
				double crtGaugeValue = 20.0;
				double updateValue = 0.0;
				foreach (DamageComponent damageComponent2 in validDamages)
				{
					if (damageComponent2.IsCrit)
					{
						updateValue += crtGaugeValue;
					}
					else
					{
						updateValue += normalHitGaugeValue;
					}
				}
				double hurtRageRatio = 1.0;
				updateValue *= hurtRageRatio;
				if (battleEncounter != null)
				{
					if (damage.Target.IsPlayer)
					{
						IEnumerator enumerator22 = battleEncounter.UpdatePlayerGauge(updateValue, damage.Target).GetEnumerator();
						try
						{
							while (enumerator22.MoveNext())
							{
								object _18 = enumerator22.Current;
								yield return _18;
							}
						}
						finally
						{
							IDisposable disposable19;
							if ((disposable19 = (enumerator22 as IDisposable)) != null)
							{
								disposable19.Dispose();
							}
						}
					}
					else
					{
						IEnumerator enumerator23 = battleEncounter.UpdateEnemyGauge(updateValue, damage.Target).GetEnumerator();
						try
						{
							while (enumerator23.MoveNext())
							{
								object _19 = enumerator23.Current;
								yield return _19;
							}
						}
						finally
						{
							IDisposable disposable20;
							if ((disposable20 = (enumerator23 as IDisposable)) != null)
							{
								disposable20.Dispose();
							}
						}
					}
				}
			}
			if (unit.CurrentAdventure.RunePower != null)
			{
				int rate2 = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.ChaoticSpiritDirectKillCollection);
				if (rate2 > 0)
				{
					if (damage.Damages.Any((DamageComponent d) => d.IsReflectedDamage) && (double)UnityEngine.Random.value <= 0.5)
					{
						IEnumerator enumerator24 = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.ChaoticSpirit, rate2, unit).GetEnumerator();
						try
						{
							while (enumerator24.MoveNext())
							{
								object _20 = enumerator24.Current;
								yield return _20;
							}
						}
						finally
						{
							IDisposable disposable21;
							if ((disposable21 = (enumerator24 as IDisposable)) != null)
							{
								disposable21.Dispose();
							}
						}
					}
				}
			}
			if (!unit.IsPlayer && unit.CurrentAdventure.RunePower != null)
			{
				if (damage.Damages.Any((DamageComponent d) => d.IsReflectedDamage))
				{
					double rfrate = (from d in damage.Damages
					where d.IsReflectedDamage
					select d).Sum((DamageComponent d) => d.GetTotalDamageSoFar_WithoutNeutralization());
					double pct = rfrate / damage.Dealer.GetMaxLife(AttributeRetrievalLevel.Skill);
					if (pct >= 0.5 && (double)UnityEngine.Random.value <= 0.25)
					{
						int rate3 = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.CHaoticSpiritReflectionCollection);
						IEnumerator enumerator25 = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.ChaoticSpirit, rate3, unit).GetEnumerator();
						try
						{
							while (enumerator25.MoveNext())
							{
								object _21 = enumerator25.Current;
								yield return _21;
							}
						}
						finally
						{
							IDisposable disposable22;
							if ((disposable22 = (enumerator25 as IDisposable)) != null)
							{
								disposable22.Dispose();
							}
						}
					}
				}
			}
		}
		else if (unit.Status == BattleUnitStatus.Dead)
		{
			foreach (DamageComponent damageComponent3 in damage.Damages)
			{
				damageComponent3.ExceededDamageValue = new double?(damageComponent3.GetTotalDamageSoFar());
			}
		}
		yield break;
	}

	// Token: 0x0600222A RID: 8746 RVA: 0x000F2B54 File Offset: 0x000F0F54
	private static IEnumerable ElementalDamageCalculation(IBattleUnit unit, BattleDamage damage)
	{
		if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Fire))
		{
			IEnumerator enumerator = DamageExtensions.FireElementProcess(damage).GetEnumerator();
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
		}
		if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Physical))
		{
			IEnumerator enumerator2 = DamageExtensions.PhysicalElementProcess(damage).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object p3 = enumerator2.Current;
					yield return p3;
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
		if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Divine))
		{
			IEnumerator enumerator3 = DamageExtensions.DivineElementProcess(damage).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object p4 = enumerator3.Current;
					yield return p4;
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
		if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Shadow))
		{
			IEnumerator enumerator4 = DamageExtensions.ShadowDamageProcess(damage).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object p5 = enumerator4.Current;
					yield return p5;
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
		}
		if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Poison))
		{
			IEnumerator enumerator5 = DamageExtensions.PoisonElementProcess(damage).GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object p6 = enumerator5.Current;
					yield return p6;
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
		if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Lightening))
		{
			IEnumerator enumerator6 = DamageExtensions.LighteningProcess(damage).GetEnumerator();
			try
			{
				while (enumerator6.MoveNext())
				{
					object p7 = enumerator6.Current;
					yield return p7;
				}
			}
			finally
			{
				IDisposable disposable6;
				if ((disposable6 = (enumerator6 as IDisposable)) != null)
				{
					disposable6.Dispose();
				}
			}
		}
		if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Ice))
		{
			IEnumerator enumerator7 = DamageExtensions.IceElementProcess(damage).GetEnumerator();
			try
			{
				while (enumerator7.MoveNext())
				{
					object p8 = enumerator7.Current;
					yield return p8;
				}
			}
			finally
			{
				IDisposable disposable7;
				if ((disposable7 = (enumerator7 as IDisposable)) != null)
				{
					disposable7.Dispose();
				}
			}
		}
		IEnumerator enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.ElementDamageProcessCompleted, damage)).GetEnumerator();
		try
		{
			while (enumerator8.MoveNext())
			{
				object _ = enumerator8.Current;
				yield return _;
			}
		}
		finally
		{
			IDisposable disposable8;
			if ((disposable8 = (enumerator8 as IDisposable)) != null)
			{
				disposable8.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x0600222B RID: 8747 RVA: 0x000F2B80 File Offset: 0x000F0F80
	private static IEnumerable LighteningProcess(BattleDamage damage)
	{
		List<DamageExtensions.EffectiveDamage> effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Lightening);
		bool triggerSpread = false;
		using (List<DamageExtensions.EffectiveDamage>.Enumerator enumerator = effectiveDamages.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DamageExtensions.EffectiveDamage effectiveDamage = enumerator.Current;
				triggerSpread = true;
				double chance = 0.3;
				int numberOfAdditionalTargets = 2;
				double damageRate = 1.0;
				if ((double)UnityEngine.Random.value <= chance)
				{
					List<IBattleUnit> avaliableTargets = (from t in effectiveDamage.Target.GetAllLiveFriendlyTargetsIncSelf(true)
					where t != effectiveDamage.Target
					select t).Take(numberOfAdditionalTargets).ToList<IBattleUnit>();
					List<BattleDamage> damages = new List<BattleDamage>();
					double damageValue = damageRate * effectiveDamage.TotalDamage;
					if (damageValue > 0.0 && avaliableTargets.Any<IBattleUnit>())
					{
						foreach (IBattleUnit target in avaliableTargets)
						{
							damages.Add(new BattleDamage(target, new SpecialEffectTriggerSource(damage.Dealer, SpecialEffectType.ElementEffects), new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(target, damage.Dealer, OutputType.Lightening, damageValue)
								}, target, damage.Dealer, false, false)
							}));
						}
						ReleaseableDamage releaseable = new ReleaseableDamage(damages, damage.Dealer);
						IEnumerator enumerator3 = releaseable.Release().GetEnumerator();
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
							IDisposable disposable;
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
		}
		if (triggerSpread && damage.Dealer.SpecialEffects.OfType<LightningEnhancementData>().Any<LightningEnhancementData>() && damage.Target.BattleEffects.OfType<ISpreadableDamageOverTime>().Any<ISpreadableDamageOverTime>())
		{
			int extra = damage.Dealer.SpecialEffects.OfType<LightningEnhancementData>().First<LightningEnhancementData>().SpreadNumber;
			List<IBattleUnit> targets = (from u in damage.Target.GetAllLiveFriendlyTargetsIncSelf(true)
			select u).ToList<IBattleUnit>();
			targets.Shuffle<IBattleUnit>();
			targets = (from u in targets
			where u != damage.Target
			select u).Take(extra).ToList<IBattleUnit>();
			if (targets.Any<IBattleUnit>())
			{
				foreach (ISpreadableDamageOverTime spreadableDamageOverTime in damage.Target.BattleEffects.OfType<ISpreadableDamageOverTime>().ToList<ISpreadableDamageOverTime>())
				{
					IEnumerator enumerator5 = spreadableDamageOverTime.Spread(damage.Target, targets).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _2 = enumerator5.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator5 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x0600222C RID: 8748 RVA: 0x000F2BA4 File Offset: 0x000F0FA4
	private static IEnumerable ShadowDamageProcess(BattleDamage damage)
	{
		List<DamageExtensions.EffectiveDamage> effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Shadow);
		foreach (DamageExtensions.EffectiveDamage effectiveDamage in effectiveDamages)
		{
			float numberOfLastingSeconds = 3f;
			double damageRate = 0.25;
			double healRate = 0.2;
			double damagePerTick = effectiveDamage.TotalDamage * damageRate;
			IEnumerator enumerator2 = effectiveDamage.Target.ApplySkillEffect(LifeExtractionEffect.CreateShadowProcEffect(damage.DamageSource, damagePerTick, healRate, effectiveDamage.Target, numberOfLastingSeconds, "SHADOWPROC"), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600222D RID: 8749 RVA: 0x000F2BC8 File Offset: 0x000F0FC8
	private static IEnumerable PhysicalElementProcess(BattleDamage damage)
	{
		List<DamageExtensions.EffectiveDamage> effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Physical);
		foreach (DamageExtensions.EffectiveDamage effectiveDamage in effectiveDamages)
		{
			AttributeType reductionType = AttributeType.PhysicalResistance;
			double reductionRate = 0.2;
			double maxReductionRate = 0.5;
			string reductionKey = AttributeModificationEffect.PhysicalDamage_Proc;
			AttributeModificationEffect existingArmorReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
			double reductionValue = effectiveDamage.TotalDamage * reductionRate;
			double maxValue = effectiveDamage.Target.GetAttributeValue_Final(reductionType, AttributeRetrievalLevel.Gear) * maxReductionRate;
			double total = reductionValue;
			if (existingArmorReduction != null)
			{
				double num = -(from a in existingArmorReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
				where a.AttributeType == reductionType
				select a).Sum((AttributeModifier a) => a.Value);
				total += num;
			}
			if (total > maxValue)
			{
				total = maxValue;
			}
			if (total > 0.0)
			{
				IEnumerator enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreatePhysicalDamageProc(damage.Dealer, -total), false).GetEnumerator();
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
			double totalDodgeRate = damage.Dealer.SpecialEffects.OfType<PhysicalEffectEnhancementData>().Sum((PhysicalEffectEnhancementData e) => e.DodgeRate);
			if (totalDodgeRate > 0.0)
			{
				IEnumerator enumerator3 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(damage.Dealer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.DodgeRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = -totalDodgeRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, damage.Dealer.GetId() + "physicaladvanced", new int?(5), new float?(6f), null, true, true), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600222E RID: 8750 RVA: 0x000F2BEC File Offset: 0x000F0FEC
	private static IEnumerable IceElementProcess(BattleDamage damage)
	{
		List<DamageExtensions.EffectiveDamage> effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Ice);
		foreach (DamageExtensions.EffectiveDamage effectiveDamage in effectiveDamages)
		{
			AttributeType reductionType = AttributeType.Agility;
			double reductionRate = 0.3;
			double maxReductionRate = 0.6;
			string reductionKey = AttributeModificationEffect.IceDamage_Proc;
			AttributeModificationEffect existingArmorReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
			double reductionValue = effectiveDamage.TotalDamage * reductionRate;
			double maxValue = effectiveDamage.Target.GetAttributeValue_Final(reductionType, AttributeRetrievalLevel.Gear) * maxReductionRate;
			double total = reductionValue;
			if (existingArmorReduction != null)
			{
				double num = -(from a in existingArmorReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
				where a.AttributeType == reductionType
				select a).Sum((AttributeModifier a) => a.Value);
				total += num;
			}
			if (total > maxValue)
			{
				total = maxValue;
			}
			if (total > 0.0)
			{
				IEnumerator enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateIceDamageProc(damage.Dealer, -total), false).GetEnumerator();
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
			double effectiveRate = 0.5;
			double iceEffectiveness = DamageExtensions.GetElementalEffectEffectiveness(effectiveDamage.TotalDamage, damage.Dealer) * effectiveRate;
			double maxChance = 0.6;
			if (iceEffectiveness > maxChance)
			{
				iceEffectiveness = maxChance;
			}
			if ((double)UnityEngine.Random.value <= iceEffectiveness)
			{
				IEnumerator enumerator3 = LockTimeEffect.AddFrozenSeconds(effectiveDamage.Target, 1f, damage.Dealer, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600222F RID: 8751 RVA: 0x000F2C10 File Offset: 0x000F1010
	private static IEnumerable DivineElementProcess(BattleDamage damage)
	{
		List<DamageExtensions.EffectiveDamage> effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Divine);
		foreach (DamageExtensions.EffectiveDamage effectiveDamage in effectiveDamages)
		{
			AttributeType reductionType = effectiveDamage.Target.GetOutputAttributeType();
			double reductionRate = 0.6;
			double maxReductionRate = 0.35;
			string reductionKey = AttributeModificationEffect.DivineDamage_Proc;
			AttributeModificationEffect existingDivineReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
			double reductionValue = effectiveDamage.TotalDamage * reductionRate;
			double maxValue = effectiveDamage.Target.GetAttributeValue_Final(reductionType, AttributeRetrievalLevel.Gear) * maxReductionRate;
			double total = reductionValue;
			if (existingDivineReduction != null)
			{
				double num = -(from a in existingDivineReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
				where a.AttributeType == reductionType
				select a).Sum((AttributeModifier a) => a.Value);
				total += num;
			}
			if (total > maxValue)
			{
				total = maxValue;
			}
			if (total > 0.0)
			{
				IEnumerator enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateDivineDamageProc(damage.Dealer, -total, effectiveDamage.Target.GetOutputAttributeType()), false).GetEnumerator();
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
			if (damage.Dealer.SpecialEffects.OfType<DivineEffectEnhancementData>().Any<DivineEffectEnhancementData>())
			{
				DivineEffectEnhancementData enhance = damage.Dealer.SpecialEffects.OfType<DivineEffectEnhancementData>().First<DivineEffectEnhancementData>();
				if ((double)UnityEngine.Random.value <= enhance.Chance)
				{
					IEnumerator enumerator3 = damage.Target.ApplySkillEffect(new SealedEffect(new float?(6f), null, damage.Dealer), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06002230 RID: 8752 RVA: 0x000F2C34 File Offset: 0x000F1034
	private static IEnumerable FireElementProcess(BattleDamage damage)
	{
		List<DamageExtensions.EffectiveDamage> effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Fire);
		double fireSeedRate = 0.8;
		List<BattleDamage> explosionDamages = new List<BattleDamage>();
		foreach (DamageExtensions.EffectiveDamage effectiveDamage in effectiveDamages)
		{
			List<DamageComponentValue> hits = new List<DamageComponentValue>();
			if (effectiveDamage.Target.Status == BattleUnitStatus.Active)
			{
				IBattleUnit target = effectiveDamage.Target;
				IBattleUnit dealer = damage.Dealer;
				List<FireSeedEffect> fireSeeds = target.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>();
				foreach (FireSeedEffect fireSeedEffect in fireSeeds)
				{
					if (!dealer.SpecialEffects.OfType<DemonicFireData>().Any<DemonicFireData>())
					{
						IEnumerator enumerator3 = target.LooseSkillEffect(fireSeedEffect, EffectWearsOffType.Expiration).GetEnumerator();
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
							IDisposable disposable;
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					hits.Add(new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(target, dealer, OutputType.Fire, fireSeedEffect.DamgeValue)
					}, target, dealer, false, false));
				}
				if (hits.Any<DamageComponentValue>())
				{
					explosionDamages.Add(new BattleDamage(target, new FireSeedExplosionSource(dealer), hits));
				}
				IEnumerator enumerator4 = FireSeedEffect.AddFireSeed(effectiveDamage.Target, fireSeedRate * effectiveDamage.TotalDamage, damage.Dealer).GetEnumerator();
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
		if (explosionDamages.Any<BattleDamage>())
		{
			ReleaseableDamage releaseableExtraDamage = new ReleaseableDamage(explosionDamages, damage.DamageSource.SourceUnit);
			IEnumerator enumerator5 = releaseableExtraDamage.Release().GetEnumerator();
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
			if (damage.DamageSource is AdventureUnitSkill)
			{
				AdventureUnitSkill skill = damage.DamageSource as AdventureUnitSkill;
				if (skill.Skill.SkillType == SkillType.FireBreath && skill.GetActiveTalents().OfType<FirebreathDamageAbsorbTalent>().Any<FirebreathDamageAbsorbTalent>())
				{
					double rate = FirebreathDamageAbsorbTalent.Rate;
					double totalAbsorb = releaseableExtraDamage.BattleDamages.Sum((BattleDamage b) => b.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar())) * rate;
					if (totalAbsorb > 0.0)
					{
						IEnumerator enumerator6 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(skill.SourceUnit, damage.DamageSource, totalAbsorb).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002231 RID: 8753 RVA: 0x000F2C58 File Offset: 0x000F1058
	public static IEnumerable TriggerFireSeeds(List<IBattleUnit> targets, IBattleUnit dealer)
	{
		List<BattleDamage> explosionDamages = new List<BattleDamage>();
		foreach (IBattleUnit target in targets)
		{
			List<DamageComponentValue> hits = new List<DamageComponentValue>();
			if (target.Status == BattleUnitStatus.Active)
			{
				List<FireSeedEffect> fireSeeds = target.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>();
				foreach (FireSeedEffect fireSeedEffect in fireSeeds)
				{
					if (!dealer.SpecialEffects.OfType<DemonicFireData>().Any<DemonicFireData>())
					{
						IEnumerator enumerator3 = target.LooseSkillEffect(fireSeedEffect, EffectWearsOffType.Expiration).GetEnumerator();
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
							IDisposable disposable;
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					hits.Add(new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(target, dealer, OutputType.Fire, fireSeedEffect.DamgeValue)
					}, target, dealer, false, false));
				}
				if (hits.Any<DamageComponentValue>())
				{
					explosionDamages.Add(new BattleDamage(target, new FireSeedExplosionSource(dealer), hits));
				}
			}
		}
		if (explosionDamages.Any<BattleDamage>())
		{
			ReleaseableDamage releaseableExtraDamage = new ReleaseableDamage(explosionDamages, dealer);
			IEnumerator enumerator4 = releaseableExtraDamage.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002232 RID: 8754 RVA: 0x000F2C84 File Offset: 0x000F1084
	private static IEnumerable PoisonElementProcess(BattleDamage damage)
	{
		List<DamageExtensions.EffectiveDamage> effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Poison);
		foreach (DamageExtensions.EffectiveDamage effectiveDamage in effectiveDamages)
		{
			AttributeType reductionType = AttributeType.ReceivedHealEffectivenessChangeRate;
			double reductionRate = 0.5;
			double maxReductionRate = 0.5;
			string reductionKey = AttributeModificationEffect.PoisonDamage_Proc;
			double effectivenessRate = 0.5;
			AttributeModificationEffect existingArmorReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
			double reductionValue = DamageExtensions.GetElementalEffectEffectiveness(effectiveDamage.TotalDamage, damage.Dealer) * effectivenessRate * reductionRate;
			double total = reductionValue;
			if (existingArmorReduction != null)
			{
				double num = -(from a in existingArmorReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
				where a.AttributeType == reductionType
				select a).Sum((AttributeModifier a) => a.Value);
				total += num;
			}
			if (total > maxReductionRate)
			{
				total = maxReductionRate;
			}
			if (total > 0.0)
			{
				IEnumerator enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreatePoisonDamageProc(damage.Dealer, -total), false).GetEnumerator();
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
			double damageRate = 0.2 + damage.Dealer.SpecialEffects.OfType<PoisonEffectEnhancementData>().Sum((PoisonEffectEnhancementData p) => p.ExtraRate);
			double damageValue = effectiveDamage.TotalDamage * damageRate;
			IEnumerator enumerator3 = DamageOverTimeEffect.AddDamageOverSecond(effectiveDamage.Target, damage.Dealer, damageValue, 3, OutputType.Poison).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002233 RID: 8755 RVA: 0x000F2CA7 File Offset: 0x000F10A7
	private static double GetElementalEffectEffectiveness(double totalDamage, IBattleUnit dealer)
	{
		return totalDamage / (dealer.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 2.0);
	}

	// Token: 0x06002234 RID: 8756 RVA: 0x000F2CC4 File Offset: 0x000F10C4
	private static List<DamageExtensions.EffectiveDamage> GetEffectiveDamage(BattleDamage damage, OutputType outputType)
	{
		return (from d in damage.Damages
		where d.IsDirectDamage
		group d by d.Target into g
		select new DamageExtensions.EffectiveDamage
		{
			Target = g.Key,
			TotalDamage = g.Sum((DamageComponent d) => d.GetElementalTotal_WithoutNeutralization(outputType))
		} into t
		where t.TotalDamage > 0.0
		select t).ToList<DamageExtensions.EffectiveDamage>();
	}

	// Token: 0x06002235 RID: 8757 RVA: 0x000F2D60 File Offset: 0x000F1160
	[CompilerGenerated]
	private static bool <GetEffectiveDamage>m__0(DamageComponent d)
	{
		return d.IsDirectDamage;
	}

	// Token: 0x06002236 RID: 8758 RVA: 0x000F2D68 File Offset: 0x000F1168
	[CompilerGenerated]
	private static IBattleUnit <GetEffectiveDamage>m__1(DamageComponent d)
	{
		return d.Target;
	}

	// Token: 0x06002237 RID: 8759 RVA: 0x000F2D70 File Offset: 0x000F1170
	[CompilerGenerated]
	private static bool <GetEffectiveDamage>m__2(DamageExtensions.EffectiveDamage t)
	{
		return t.TotalDamage > 0.0;
	}

	// Token: 0x04001DEE RID: 7662
	[CompilerGenerated]
	private static Func<DamageComponent, bool> <>f__am$cache0;

	// Token: 0x04001DEF RID: 7663
	[CompilerGenerated]
	private static Func<DamageComponent, IBattleUnit> <>f__am$cache1;

	// Token: 0x04001DF0 RID: 7664
	[CompilerGenerated]
	private static Func<DamageExtensions.EffectiveDamage, bool> <>f__am$cache2;

	// Token: 0x02000494 RID: 1172
	private class EffectiveDamage
	{
		// Token: 0x06002238 RID: 8760 RVA: 0x000F2D83 File Offset: 0x000F1183
		public EffectiveDamage()
		{
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06002239 RID: 8761 RVA: 0x000F2D8B File Offset: 0x000F118B
		// (set) Token: 0x0600223A RID: 8762 RVA: 0x000F2D93 File Offset: 0x000F1193
		public IBattleUnit Target
		{
			[CompilerGenerated]
			get
			{
				return this.<Target>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Target>k__BackingField = value;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x0600223B RID: 8763 RVA: 0x000F2D9C File Offset: 0x000F119C
		// (set) Token: 0x0600223C RID: 8764 RVA: 0x000F2DA4 File Offset: 0x000F11A4
		public double TotalDamage
		{
			[CompilerGenerated]
			get
			{
				return this.<TotalDamage>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<TotalDamage>k__BackingField = value;
			}
		}

		// Token: 0x04001DF1 RID: 7665
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IBattleUnit <Target>k__BackingField;

		// Token: 0x04001DF2 RID: 7666
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double <TotalDamage>k__BackingField;
	}

	// Token: 0x02000D5C RID: 3420
	[CompilerGenerated]
	private sealed class <ReceivesDamage>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600573F RID: 22335 RVA: 0x000F2DAD File Offset: 0x000F11AD
		[DebuggerHidden]
		public <ReceivesDamage>c__Iterator0()
		{
		}

		// Token: 0x06005740 RID: 22336 RVA: 0x000F2DB8 File Offset: 0x000F11B8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (unit.Status == BattleUnitStatus.Active && damage.Damages.Any<DamageComponent>())
				{
					if (unit.HealthPoints < 0.0)
					{
						unit.HealthPoints = 0.0;
					}
					enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitReceivesDamage_CompleteSet, damage)).GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					if (unit.Status == BattleUnitStatus.Dead)
					{
						foreach (DamageComponent damageComponent2 in damage.Damages)
						{
							damageComponent2.ExceededDamageValue = new double?(damageComponent2.GetTotalDamageSoFar());
						}
						goto IL_1DE1;
					}
					goto IL_1DE1;
				}
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
			case 4u:
			case 5u:
				goto IL_21C;
			case 6u:
				goto IL_B44;
			case 7u:
				Block_12:
				try
				{
					switch (num)
					{
					}
					if (enumerator8.MoveNext())
					{
						_7 = enumerator8.Current;
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
						if ((disposable7 = (enumerator8 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				killedAtFirst = false;
				if (<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints > 0.0)
				{
					goto IL_F8E;
				}
				killedAtFirst = true;
				<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints = 0.0;
				if (damage.Dealer.GetUnitType() != UnitClass.SnowMaiden)
				{
					goto IL_E26;
				}
				star = damage.Dealer.SpecialEffects.OfType<SnowMaidenStarEffectData>().Any<SnowMaidenStarEffectData>();
				if (star)
				{
					enumerator9 = damage.Dealer.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(damage.Dealer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.EffectHitRating,
							ModificationType = ModificationType.Multiplication,
							Value = 0.2,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "snowmaidenuniqueboost", new int?(5), null, null, false, false, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_16;
				}
				goto IL_E26;
			case 8u:
				goto IL_DA4;
			case 9u:
				Block_17:
				try
				{
					switch (num)
					{
					}
					if (enumerator10.MoveNext())
					{
						_9 = enumerator10.Current;
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
						if ((disposable9 = (enumerator10 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
				enumerator11 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitPreKilledFinal, damage)).GetEnumerator();
				num = 4294967293u;
				goto Block_18;
			case 10u:
				goto IL_F0A;
			case 11u:
				Block_21:
				try
				{
					switch (num)
					{
					}
					if (enumerator12.MoveNext())
					{
						_11 = enumerator12.Current;
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
						if ((disposable11 = (enumerator12 as IDisposable)) != null)
						{
							disposable11.Dispose();
						}
					}
				}
				enumerator13 = (from ef in <ReceivesDamage>c__AnonStoreyB.unit.BattleEffects
				select ef).ToList<BattleEffectBase>().GetEnumerator();
				num = 4294967293u;
				goto Block_23;
			case 12u:
				goto IL_10E5;
			case 13u:
				goto IL_120C;
			case 14u:
				goto IL_130D;
			case 15u:
				Block_34:
				try
				{
					switch (num)
					{
					}
					if (enumerator17.MoveNext())
					{
						_15 = enumerator17.Current;
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
						if ((disposable15 = (enumerator17 as IDisposable)) != null)
						{
							disposable15.Dispose();
						}
					}
				}
				goto IL_14E4;
			case 16u:
				Block_38:
				try
				{
					switch (num)
					{
					}
					if (enumerator18.MoveNext())
					{
						_16 = enumerator18.Current;
						this.$current = _16;
						if (!this.$disposing)
						{
							this.$PC = 16;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable16 = (enumerator18 as IDisposable)) != null)
						{
							disposable16.Dispose();
						}
					}
				}
				goto IL_162A;
			case 17u:
				Block_39:
				try
				{
					switch (num)
					{
					}
					if (enumerator19.MoveNext())
					{
						_17 = enumerator19.Current;
						this.$current = _17;
						if (!this.$disposing)
						{
							this.$PC = 17;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable17 = (enumerator19 as IDisposable)) != null)
						{
							disposable17.Dispose();
						}
					}
				}
				goto IL_16E3;
			case 18u:
				Block_40:
				try
				{
					switch (num)
					{
					}
					if (enumerator20.MoveNext())
					{
						p = enumerator20.Current;
						this.$current = p;
						if (!this.$disposing)
						{
							this.$PC = 18;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable18 = (enumerator20 as IDisposable)) != null)
						{
							disposable18.Dispose();
						}
					}
				}
				if (!damage.Damages.Any((DamageComponent d) => d.IsDirectDamage))
				{
					goto IL_1A46;
				}
				validDamages = (from d in damage.Damages
				where d.IsDirectDamage
				select d).ToList<DamageComponent>();
				normalHitGaugeValue = 10.0;
				crtGaugeValue = 20.0;
				updateValue = 0.0;
				enumerator21 = validDamages.GetEnumerator();
				try
				{
					while (enumerator21.MoveNext())
					{
						DamageComponent damageComponent3 = enumerator21.Current;
						if (damageComponent3.IsCrit)
						{
							updateValue += crtGaugeValue;
						}
						else
						{
							updateValue += normalHitGaugeValue;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator21).Dispose();
				}
				hurtRageRatio = 1.0;
				updateValue *= hurtRageRatio;
				if (battleEncounter == null)
				{
					goto IL_1A46;
				}
				if (damage.Target.IsPlayer)
				{
					enumerator22 = battleEncounter.UpdatePlayerGauge(updateValue, damage.Target).GetEnumerator();
					num = 4294967293u;
					goto Block_47;
				}
				enumerator23 = battleEncounter.UpdateEnemyGauge(updateValue, damage.Target).GetEnumerator();
				num = 4294967293u;
				goto Block_48;
			case 19u:
				goto IL_190F;
			case 20u:
				goto IL_19C2;
			case 21u:
				Block_54:
				try
				{
					switch (num)
					{
					}
					if (enumerator24.MoveNext())
					{
						_20 = enumerator24.Current;
						this.$current = _20;
						if (!this.$disposing)
						{
							this.$PC = 21;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable21 = (enumerator24 as IDisposable)) != null)
						{
							disposable21.Dispose();
						}
					}
				}
				goto IL_1B95;
			case 22u:
				Block_63:
				try
				{
					switch (num)
					{
					}
					if (enumerator25.MoveNext())
					{
						_21 = enumerator25.Current;
						this.$current = _21;
						if (!this.$disposing)
						{
							this.$PC = 22;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable22 = (enumerator25 as IDisposable)) != null)
						{
							disposable22.Dispose();
						}
					}
				}
				goto IL_1D74;
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
			priorPercentage = <ReceivesDamage>c__AnonStoreyB.unit.HealthPoints / <ReceivesDamage>c__AnonStoreyB.unit.GetMaxLife(AttributeRetrievalLevel.Skill);
			enumerator2 = damage.Damages.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_21C:
				switch (num)
				{
				case 2u:
					Block_83:
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
					if (!damageComponent.HasFullyNeutralized())
					{
						if (<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints > 0.0)
						{
							double num2 = damageComponent.GetTotalDamageSoFar() - <ReceivesDamage>c__AnonStoreyB.unit.HealthPoints;
							damageComponent.ExceededDamageValue = new double?((num2 <= 0.0) ? 0.0 : num2);
						}
						else
						{
							damageComponent.ExceededDamageValue = new double?(damageComponent.GetTotalDamageSoFar());
						}
						originalHp = <ReceivesDamage>c__AnonStoreyB.unit.HealthPoints;
						if (damageComponent.GetTotalDamageSoFar() <= 0.0 || <ReceivesDamage>c__AnonStoreyB.unit.SpecialEffects.OfType<ProtectorData>().Any<ProtectorData>() || <ReceivesDamage>c__AnonStoreyB.unit.SpecialEffects.OfType<SacrificeEffectData>().Any<SacrificeEffectData>())
						{
							goto IL_7AA;
						}
						protector = <ReceivesDamage>c__AnonStoreyB.unit.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault((IBattleUnit u) => u.SpecialEffects.OfType<ProtectorData>().Any<ProtectorData>());
						if (protector != null && protector.HealthPoints > 0.0)
						{
							data = protector.SpecialEffects.OfType<ProtectorData>().First<ProtectorData>();
							releaseable = new ReleaseableDamage(new List<BattleDamage>
							{
								new BattleDamage(protector, new SpecialEffectTriggerSource(damage.DamageSource.SourceUnit, SpecialEffectType.Protector), new List<DamageComponentValue>
								{
									new DamageComponentValue(new List<DamagePotionValue>
									{
										DamagePotionValue.CreateRawValuedDamageComponent(protector, damage.Dealer, OutputType.RealDamage, data.DamageReductionRate * damageComponent.GetTotalDamageSoFar() * data.DamageReceivedRate)
									}, protector, damage.Dealer, false, false)
								})
							}, damage.Dealer);
							enumerator4 = releaseable.Release().GetEnumerator();
							num = 4294967293u;
							goto Block_93;
						}
						goto IL_7AA;
					}
					else
					{
						if (damageComponent.HasFullyNeutralized() && !damageComponent.IsMissed)
						{
							enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitDamageNeutralized, damageComponent)).GetEnumerator();
							num = 4294967293u;
							goto Block_100;
						}
						goto IL_94B;
					}
					break;
				case 3u:
					goto IL_708;
				case 4u:
					goto IL_8C9;
				case 5u:
					Block_101:
					try
					{
						switch (num)
						{
						}
						if (enumerator6.MoveNext())
						{
							_5 = enumerator6.Current;
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
							if ((disposable5 = (enumerator6 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator2.MoveNext())
				{
					damageComponent = enumerator2.Current;
					bool flag2;
					if (damageComponent.IsDirectDamage)
					{
						flag2 = damage.Dealer.BattleEffects.All((BattleEffectBase e) => e.BattleEffectType != BattleEffectType.Fear);
					}
					else
					{
						flag2 = true;
					}
					unitCapableOfDealingDamage = flag2;
					if (<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints < 0.0)
					{
						<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints = 0.0;
					}
					if (unitCapableOfDealingDamage)
					{
						if (damageComponent.CanMiss())
						{
							double attributeValue_Final = <ReceivesDamage>c__AnonStoreyB.unit.GetAttributeValue_Final(AttributeType.DodgeRateAdjustment, AttributeRetrievalLevel.Skill);
							if (attributeValue_Final > 0.0)
							{
								double num3 = attributeValue_Final * <ReceivesDamage>c__AnonStoreyB.unit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
								if (num3 > 0.0)
								{
									double num4 = damageComponent.Dealer.GetAttributeValue_Final(AttributeType.HitRateAdjustment, AttributeRetrievalLevel.Skill) * damageComponent.Dealer.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
									if (damageComponent.Dealer.SpecialEffects.OfType<EyeOfPrecisionEffectData>().Any<EyeOfPrecisionEffectData>())
									{
										double rate4 = damageComponent.Dealer.SpecialEffects.OfType<EyeOfPrecisionEffectData>().First<EyeOfPrecisionEffectData>().Rate;
										double num5 = damageComponent.Dealer.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill) * rate4;
										if (num5 > num4)
										{
											num5 = num4;
										}
										num4 += num5;
									}
									double num6 = num4 / (num4 + num3) * 0.65 + 0.35;
									if ((double)UnityEngine.Random.value > num6)
									{
										damageComponent.SetMiss();
									}
								}
							}
						}
						enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitReceivesDamage_Single, damageComponent)).GetEnumerator();
						num = 4294967293u;
						goto Block_83;
					}
					damageComponent.SetIneffective();
				}
				goto IL_A38;
				Block_93:
				try
				{
					IL_708:
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
				damageComponent.UpdateFinalDamageFilter(1.0 - data.DamageReductionRate);
				IL_7AA:
				if (<ReceivesDamage>c__AnonStoreyB.unit.BattleEffects.OfType<DamageReductionByValueEffect>().Any<DamageReductionByValueEffect>())
				{
					double countered = <ReceivesDamage>c__AnonStoreyB.unit.BattleEffects.OfType<DamageReductionByValueEffect>().Sum((DamageReductionByValueEffect d) => d.ReductionValue);
					damageComponent.UpdateCounteredDamage(countered);
				}
				<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints -= damageComponent.GetTotalDamageSoFar();
				if (originalHp > 0.0 && <ReceivesDamage>c__AnonStoreyB.unit.HealthPoints <= 0.0)
				{
					damageComponent.IsFatal = new bool?(true);
				}
				goto IL_94B;
				Block_100:
				try
				{
					IL_8C9:
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
				IL_94B:
				enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitPostReceivesDamage_Single, damageComponent)).GetEnumerator();
				num = 4294967293u;
				goto Block_101;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_A38:
			currentPercentage = <ReceivesDamage>c__AnonStoreyB.unit.HealthPoints / <ReceivesDamage>c__AnonStoreyB.unit.GetMaxLife(AttributeRetrievalLevel.Skill);
			battleEncounter = (<ReceivesDamage>c__AnonStoreyB.unit.CurrentEncounter as BattleEncounter);
			<ReceivesDamage>c__AnonStoreyA.key = <ReceivesDamage>c__AnonStoreyB.unit.GetId() + "halflifenoted";
			if (priorPercentage <= 0.5 || currentPercentage > 0.5 || battleEncounter == null || !battleEncounter.AdditionalBookKeeping.All((string n) => n != <ReceivesDamage>c__AnonStoreyA.key))
			{
				goto IL_BC6;
			}
			battleEncounter.AdditionalBookKeeping.Add(<ReceivesDamage>c__AnonStoreyA.key);
			enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime, damage)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_B44:
				switch (num)
				{
				}
				if (enumerator7.MoveNext())
				{
					_6 = enumerator7.Current;
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
					if ((disposable6 = (enumerator7 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			IL_BC6:
			enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitPostReceivesDamage, damage)).GetEnumerator();
			num = 4294967293u;
			goto Block_12;
			Block_16:
			try
			{
				IL_DA4:
				switch (num)
				{
				}
				if (enumerator9.MoveNext())
				{
					_8 = enumerator9.Current;
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
					if ((disposable8 = (enumerator9 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
			}
			IL_E26:
			enumerator10 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitPreKilled, damage)).GetEnumerator();
			num = 4294967293u;
			goto Block_17;
			Block_18:
			try
			{
				IL_F0A:
				switch (num)
				{
				}
				if (enumerator11.MoveNext())
				{
					_10 = enumerator11.Current;
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
					if ((disposable10 = (enumerator11 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
			}
			IL_F8E:
			if (<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints <= 0.0 && <ReceivesDamage>c__AnonStoreyB.unit.Status != BattleUnitStatus.Dead)
			{
				<ReceivesDamage>c__AnonStoreyB.unit.HealthPoints = 0.0;
				<ReceivesDamage>c__AnonStoreyB.unit.Status = BattleUnitStatus.Dead;
				enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitPreRealKilled, damage)).GetEnumerator();
				num = 4294967293u;
				goto Block_21;
			}
			if (!killedAtFirst)
			{
				goto IL_16E3;
			}
			if (!<ReceivesDamage>c__AnonStoreyB.unit.IsPlayer || <ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower == null)
			{
				goto IL_14E4;
			}
			rate = (int)Math.Round((double)<ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.VitalEnergyRebirthCollection) * 0.4);
			if (rate > 0 && (double)UnityEngine.Random.value <= 0.5)
			{
				enumerator17 = <ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower.AddPower(RunePowerType.VitalEnergy, rate, <ReceivesDamage>c__AnonStoreyB.unit).GetEnumerator();
				num = 4294967293u;
				goto Block_34;
			}
			goto IL_14E4;
			Block_23:
			try
			{
				IL_10E5:
				switch (num)
				{
				case 12u:
					Block_166:
					try
					{
						switch (num)
						{
						}
						if (enumerator14.MoveNext())
						{
							_12 = enumerator14.Current;
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
							if ((disposable12 = (enumerator14 as IDisposable)) != null)
							{
								disposable12.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator13.MoveNext())
				{
					unitBattleEffect = enumerator13.Current;
					enumerator14 = <ReceivesDamage>c__AnonStoreyB.unit.LooseSkillEffect(unitBattleEffect, EffectWearsOffType.WearerKilled).GetEnumerator();
					num = 4294967293u;
					goto Block_166;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator13).Dispose();
				}
			}
			enumerator15 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitKilled, damage)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_120C:
				switch (num)
				{
				}
				if (enumerator15.MoveNext())
				{
					_13 = enumerator15.Current;
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
					if ((disposable13 = (enumerator15 as IDisposable)) != null)
					{
						disposable13.Dispose();
					}
				}
			}
			if (<ReceivesDamage>c__AnonStoreyB.unit.IsPlayer)
			{
				goto IL_1391;
			}
			conjorurWithExclusive = <ReceivesDamage>c__AnonStoreyB.unit.CurrentEncounter.PlayerUnits.FirstOrDefault((IBattleUnit u) => u.IsAliveInBattle() && u.GetUnitType() == UnitClass.Conjurer && u.SpecialEffects.OfType<DeathBoostData>().Any<DeathBoostData>());
			if (conjorurWithExclusive == null)
			{
				goto IL_1391;
			}
			enumerator16 = ProtectionOfTheDeadEffect.AddLayer(1, conjorurWithExclusive, conjorurWithExclusive).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_130D:
				switch (num)
				{
				}
				if (enumerator16.MoveNext())
				{
					_14 = enumerator16.Current;
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
					if ((disposable14 = (enumerator16 as IDisposable)) != null)
					{
						disposable14.Dispose();
					}
				}
			}
			IL_1391:
			goto IL_16E3;
			IL_14E4:
			if (<ReceivesDamage>c__AnonStoreyB.unit.IsPlayer && <ReceivesDamage>c__AnonStoreyB.unit.GetUnitType() == UnitClass.DrunkReader)
			{
				star2 = <ReceivesDamage>c__AnonStoreyB.unit.SpecialEffects.OfType<DrunkReaderStarUndeadData>().Any<DrunkReaderStarUndeadData>();
				if (star2)
				{
					targets = <ReceivesDamage>c__AnonStoreyB.unit.GetLiveEnemyTargets(false, false);
					extraDamage = new ReleaseableDamage((from t in targets
					select new BattleDamage(t, new SpecialEffectTriggerSource(<ReceivesDamage>c__AnonStoreyA.<>f__ref$11.unit, SpecialEffectType.DrunkReaderStarUndead), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(<ReceivesDamage>c__AnonStoreyA.<>f__ref$11.unit, t, <ReceivesDamage>c__AnonStoreyA.<>f__ref$11.unit.GetOutputType(), 100.0)
						}, t, <ReceivesDamage>c__AnonStoreyA.<>f__ref$11.unit, false, false)
					})).ToList<BattleDamage>(), <ReceivesDamage>c__AnonStoreyB.unit);
					enumerator18 = extraDamage.Release().GetEnumerator();
					num = 4294967293u;
					goto Block_38;
				}
			}
			IL_162A:
			enumerator19 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<ReceivesDamage>c__AnonStoreyB.unit, AdventureEventType.UnitRevived, <ReceivesDamage>c__AnonStoreyB.unit)).GetEnumerator();
			num = 4294967293u;
			goto Block_39;
			IL_16E3:
			enumerator20 = DamageExtensions.ElementalDamageCalculation(<ReceivesDamage>c__AnonStoreyB.unit, damage).GetEnumerator();
			num = 4294967293u;
			goto Block_40;
			Block_47:
			try
			{
				IL_190F:
				switch (num)
				{
				}
				if (enumerator22.MoveNext())
				{
					_18 = enumerator22.Current;
					this.$current = _18;
					if (!this.$disposing)
					{
						this.$PC = 19;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable19 = (enumerator22 as IDisposable)) != null)
					{
						disposable19.Dispose();
					}
				}
			}
			goto IL_1A46;
			Block_48:
			try
			{
				IL_19C2:
				switch (num)
				{
				}
				if (enumerator23.MoveNext())
				{
					_19 = enumerator23.Current;
					this.$current = _19;
					if (!this.$disposing)
					{
						this.$PC = 20;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable20 = (enumerator23 as IDisposable)) != null)
					{
						disposable20.Dispose();
					}
				}
			}
			IL_1A46:
			if (<ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower != null)
			{
				rate2 = <ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.ChaoticSpiritDirectKillCollection);
				if (rate2 > 0)
				{
					if (damage.Damages.Any((DamageComponent d) => d.IsReflectedDamage) && (double)UnityEngine.Random.value <= 0.5)
					{
						enumerator24 = <ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower.AddPower(RunePowerType.ChaoticSpirit, rate2, <ReceivesDamage>c__AnonStoreyB.unit).GetEnumerator();
						num = 4294967293u;
						goto Block_54;
					}
				}
			}
			IL_1B95:
			if (!<ReceivesDamage>c__AnonStoreyB.unit.IsPlayer && <ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower != null)
			{
				if (damage.Damages.Any((DamageComponent d) => d.IsReflectedDamage))
				{
					rfrate = (from d in damage.Damages
					where d.IsReflectedDamage
					select d).Sum((DamageComponent d) => d.GetTotalDamageSoFar_WithoutNeutralization());
					pct = rfrate / damage.Dealer.GetMaxLife(AttributeRetrievalLevel.Skill);
					if (pct >= 0.5 && (double)UnityEngine.Random.value <= 0.25)
					{
						rate3 = <ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.CHaoticSpiritReflectionCollection);
						enumerator25 = <ReceivesDamage>c__AnonStoreyB.unit.CurrentAdventure.RunePower.AddPower(RunePowerType.ChaoticSpirit, rate3, <ReceivesDamage>c__AnonStoreyB.unit).GetEnumerator();
						num = 4294967293u;
						goto Block_63;
					}
				}
			}
			IL_1D74:
			IL_1DE1:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700125E RID: 4702
		// (get) Token: 0x06005741 RID: 22337 RVA: 0x000F4E24 File Offset: 0x000F3224
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700125F RID: 4703
		// (get) Token: 0x06005742 RID: 22338 RVA: 0x000F4E2C File Offset: 0x000F322C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005743 RID: 22339 RVA: 0x000F4E34 File Offset: 0x000F3234
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
			case 3u:
			case 4u:
			case 5u:
				try
				{
					switch (num)
					{
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
					case 5u:
						try
						{
						}
						finally
						{
							if ((disposable5 = (enumerator6 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator7 as IDisposable)) != null)
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
					if ((disposable7 = (enumerator8 as IDisposable)) != null)
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
					if ((disposable8 = (enumerator9 as IDisposable)) != null)
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
					if ((disposable9 = (enumerator10 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
				break;
			case 10u:
				try
				{
				}
				finally
				{
					if ((disposable10 = (enumerator11 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
				break;
			case 11u:
				try
				{
				}
				finally
				{
					if ((disposable11 = (enumerator12 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
				break;
			case 12u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable12 = (enumerator14 as IDisposable)) != null)
						{
							disposable12.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator13).Dispose();
				}
				break;
			case 13u:
				try
				{
				}
				finally
				{
					if ((disposable13 = (enumerator15 as IDisposable)) != null)
					{
						disposable13.Dispose();
					}
				}
				break;
			case 14u:
				try
				{
				}
				finally
				{
					if ((disposable14 = (enumerator16 as IDisposable)) != null)
					{
						disposable14.Dispose();
					}
				}
				break;
			case 15u:
				try
				{
				}
				finally
				{
					if ((disposable15 = (enumerator17 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
				break;
			case 16u:
				try
				{
				}
				finally
				{
					if ((disposable16 = (enumerator18 as IDisposable)) != null)
					{
						disposable16.Dispose();
					}
				}
				break;
			case 17u:
				try
				{
				}
				finally
				{
					if ((disposable17 = (enumerator19 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
				break;
			case 18u:
				try
				{
				}
				finally
				{
					if ((disposable18 = (enumerator20 as IDisposable)) != null)
					{
						disposable18.Dispose();
					}
				}
				break;
			case 19u:
				try
				{
				}
				finally
				{
					if ((disposable19 = (enumerator22 as IDisposable)) != null)
					{
						disposable19.Dispose();
					}
				}
				break;
			case 20u:
				try
				{
				}
				finally
				{
					if ((disposable20 = (enumerator23 as IDisposable)) != null)
					{
						disposable20.Dispose();
					}
				}
				break;
			case 21u:
				try
				{
				}
				finally
				{
					if ((disposable21 = (enumerator24 as IDisposable)) != null)
					{
						disposable21.Dispose();
					}
				}
				break;
			case 22u:
				try
				{
				}
				finally
				{
					if ((disposable22 = (enumerator25 as IDisposable)) != null)
					{
						disposable22.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005744 RID: 22340 RVA: 0x000F5554 File Offset: 0x000F3954
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005745 RID: 22341 RVA: 0x000F555B File Offset: 0x000F395B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005746 RID: 22342 RVA: 0x000F5564 File Offset: 0x000F3964
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<ReceivesDamage>c__Iterator0 <ReceivesDamage>c__Iterator = new DamageExtensions.<ReceivesDamage>c__Iterator0();
			<ReceivesDamage>c__Iterator.unit = unit;
			<ReceivesDamage>c__Iterator.damage = damage;
			return <ReceivesDamage>c__Iterator;
		}

		// Token: 0x06005747 RID: 22343 RVA: 0x000F55A4 File Offset: 0x000F39A4
		private static bool <>m__0(BattleEffectBase e)
		{
			return e.BattleEffectType != BattleEffectType.Fear;
		}

		// Token: 0x06005748 RID: 22344 RVA: 0x000F55B3 File Offset: 0x000F39B3
		private static bool <>m__1(IBattleUnit u)
		{
			return u.SpecialEffects.OfType<ProtectorData>().Any<ProtectorData>();
		}

		// Token: 0x06005749 RID: 22345 RVA: 0x000F55C5 File Offset: 0x000F39C5
		private static double <>m__2(DamageReductionByValueEffect d)
		{
			return d.ReductionValue;
		}

		// Token: 0x0600574A RID: 22346 RVA: 0x000F55CD File Offset: 0x000F39CD
		private static BattleEffectBase <>m__3(BattleEffectBase ef)
		{
			return ef;
		}

		// Token: 0x0600574B RID: 22347 RVA: 0x000F55D0 File Offset: 0x000F39D0
		private static bool <>m__4(IBattleUnit u)
		{
			return u.IsAliveInBattle() && u.GetUnitType() == UnitClass.Conjurer && u.SpecialEffects.OfType<DeathBoostData>().Any<DeathBoostData>();
		}

		// Token: 0x0600574C RID: 22348 RVA: 0x000F5600 File Offset: 0x000F3A00
		private static bool <>m__5(DamageComponent d)
		{
			return d.IsDirectDamage;
		}

		// Token: 0x0600574D RID: 22349 RVA: 0x000F5608 File Offset: 0x000F3A08
		private static bool <>m__6(DamageComponent d)
		{
			return d.IsDirectDamage;
		}

		// Token: 0x0600574E RID: 22350 RVA: 0x000F5610 File Offset: 0x000F3A10
		private static bool <>m__7(DamageComponent d)
		{
			return d.IsReflectedDamage;
		}

		// Token: 0x0600574F RID: 22351 RVA: 0x000F5618 File Offset: 0x000F3A18
		private static bool <>m__8(DamageComponent d)
		{
			return d.IsReflectedDamage;
		}

		// Token: 0x06005750 RID: 22352 RVA: 0x000F5620 File Offset: 0x000F3A20
		private static bool <>m__9(DamageComponent d)
		{
			return d.IsReflectedDamage;
		}

		// Token: 0x06005751 RID: 22353 RVA: 0x000F5628 File Offset: 0x000F3A28
		private static double <>m__A(DamageComponent d)
		{
			return d.GetTotalDamageSoFar_WithoutNeutralization();
		}

		// Token: 0x04004628 RID: 17960
		internal IBattleUnit unit;

		// Token: 0x04004629 RID: 17961
		internal BattleDamage damage;

		// Token: 0x0400462A RID: 17962
		internal IEnumerator $locvar0;

		// Token: 0x0400462B RID: 17963
		internal object <_>__1;

		// Token: 0x0400462C RID: 17964
		internal IDisposable $locvar1;

		// Token: 0x0400462D RID: 17965
		internal double <priorPercentage>__2;

		// Token: 0x0400462E RID: 17966
		internal List<DamageComponent>.Enumerator $locvar2;

		// Token: 0x0400462F RID: 17967
		internal DamageComponent <damageComponent>__3;

		// Token: 0x04004630 RID: 17968
		internal bool <unitCapableOfDealingDamage>__4;

		// Token: 0x04004631 RID: 17969
		internal IEnumerator $locvar3;

		// Token: 0x04004632 RID: 17970
		internal object <_>__5;

		// Token: 0x04004633 RID: 17971
		internal IDisposable $locvar4;

		// Token: 0x04004634 RID: 17972
		internal double <originalHp>__6;

		// Token: 0x04004635 RID: 17973
		internal IBattleUnit <protector>__7;

		// Token: 0x04004636 RID: 17974
		internal ProtectorData <data>__8;

		// Token: 0x04004637 RID: 17975
		internal ReleaseableDamage <releaseable>__8;

		// Token: 0x04004638 RID: 17976
		internal IEnumerator $locvar5;

		// Token: 0x04004639 RID: 17977
		internal object <_>__9;

		// Token: 0x0400463A RID: 17978
		internal IDisposable $locvar6;

		// Token: 0x0400463B RID: 17979
		internal IEnumerator $locvar7;

		// Token: 0x0400463C RID: 17980
		internal object <_>__10;

		// Token: 0x0400463D RID: 17981
		internal IDisposable $locvar8;

		// Token: 0x0400463E RID: 17982
		internal IEnumerator $locvar9;

		// Token: 0x0400463F RID: 17983
		internal object <_>__11;

		// Token: 0x04004640 RID: 17984
		internal IDisposable $locvarA;

		// Token: 0x04004641 RID: 17985
		internal double <currentPercentage>__2;

		// Token: 0x04004642 RID: 17986
		internal BattleEncounter <battleEncounter>__2;

		// Token: 0x04004643 RID: 17987
		internal IEnumerator $locvarB;

		// Token: 0x04004644 RID: 17988
		internal object <_>__12;

		// Token: 0x04004645 RID: 17989
		internal IDisposable $locvarC;

		// Token: 0x04004646 RID: 17990
		internal IEnumerator $locvarD;

		// Token: 0x04004647 RID: 17991
		internal object <_>__13;

		// Token: 0x04004648 RID: 17992
		internal IDisposable $locvarE;

		// Token: 0x04004649 RID: 17993
		internal bool <killedAtFirst>__2;

		// Token: 0x0400464A RID: 17994
		internal bool <star>__14;

		// Token: 0x0400464B RID: 17995
		internal IEnumerator $locvarF;

		// Token: 0x0400464C RID: 17996
		internal object <_>__15;

		// Token: 0x0400464D RID: 17997
		internal IDisposable $locvar10;

		// Token: 0x0400464E RID: 17998
		internal IEnumerator $locvar11;

		// Token: 0x0400464F RID: 17999
		internal object <_>__16;

		// Token: 0x04004650 RID: 18000
		internal IDisposable $locvar12;

		// Token: 0x04004651 RID: 18001
		internal IEnumerator $locvar13;

		// Token: 0x04004652 RID: 18002
		internal object <_>__17;

		// Token: 0x04004653 RID: 18003
		internal IDisposable $locvar14;

		// Token: 0x04004654 RID: 18004
		internal IEnumerator $locvar15;

		// Token: 0x04004655 RID: 18005
		internal object <_>__18;

		// Token: 0x04004656 RID: 18006
		internal IDisposable $locvar16;

		// Token: 0x04004657 RID: 18007
		internal List<BattleEffectBase>.Enumerator $locvar17;

		// Token: 0x04004658 RID: 18008
		internal BattleEffectBase <unitBattleEffect>__19;

		// Token: 0x04004659 RID: 18009
		internal IEnumerator $locvar18;

		// Token: 0x0400465A RID: 18010
		internal object <_>__20;

		// Token: 0x0400465B RID: 18011
		internal IDisposable $locvar19;

		// Token: 0x0400465C RID: 18012
		internal IEnumerator $locvar1A;

		// Token: 0x0400465D RID: 18013
		internal object <_>__21;

		// Token: 0x0400465E RID: 18014
		internal IDisposable $locvar1B;

		// Token: 0x0400465F RID: 18015
		internal IBattleUnit <conjorurWithExclusive>__22;

		// Token: 0x04004660 RID: 18016
		internal IEnumerator $locvar1C;

		// Token: 0x04004661 RID: 18017
		internal object <_>__23;

		// Token: 0x04004662 RID: 18018
		internal IDisposable $locvar1D;

		// Token: 0x04004663 RID: 18019
		internal int <rate>__24;

		// Token: 0x04004664 RID: 18020
		internal IEnumerator $locvar1E;

		// Token: 0x04004665 RID: 18021
		internal object <_>__25;

		// Token: 0x04004666 RID: 18022
		internal IDisposable $locvar1F;

		// Token: 0x04004667 RID: 18023
		internal bool <star>__26;

		// Token: 0x04004668 RID: 18024
		internal List<IBattleUnit> <targets>__27;

		// Token: 0x04004669 RID: 18025
		internal ReleaseableDamage <extraDamage>__27;

		// Token: 0x0400466A RID: 18026
		internal IEnumerator $locvar20;

		// Token: 0x0400466B RID: 18027
		internal object <_>__28;

		// Token: 0x0400466C RID: 18028
		internal IDisposable $locvar21;

		// Token: 0x0400466D RID: 18029
		internal IEnumerator $locvar22;

		// Token: 0x0400466E RID: 18030
		internal object <_>__29;

		// Token: 0x0400466F RID: 18031
		internal IDisposable $locvar23;

		// Token: 0x04004670 RID: 18032
		internal IEnumerator $locvar24;

		// Token: 0x04004671 RID: 18033
		internal object <p>__30;

		// Token: 0x04004672 RID: 18034
		internal IDisposable $locvar25;

		// Token: 0x04004673 RID: 18035
		internal List<DamageComponent> <validDamages>__31;

		// Token: 0x04004674 RID: 18036
		internal double <normalHitGaugeValue>__31;

		// Token: 0x04004675 RID: 18037
		internal double <crtGaugeValue>__31;

		// Token: 0x04004676 RID: 18038
		internal double <updateValue>__31;

		// Token: 0x04004677 RID: 18039
		internal List<DamageComponent>.Enumerator $locvar26;

		// Token: 0x04004678 RID: 18040
		internal double <hurtRageRatio>__31;

		// Token: 0x04004679 RID: 18041
		internal IEnumerator $locvar27;

		// Token: 0x0400467A RID: 18042
		internal object <_>__32;

		// Token: 0x0400467B RID: 18043
		internal IDisposable $locvar28;

		// Token: 0x0400467C RID: 18044
		internal IEnumerator $locvar29;

		// Token: 0x0400467D RID: 18045
		internal object <_>__33;

		// Token: 0x0400467E RID: 18046
		internal IDisposable $locvar2A;

		// Token: 0x0400467F RID: 18047
		internal int <rate>__34;

		// Token: 0x04004680 RID: 18048
		internal IEnumerator $locvar2B;

		// Token: 0x04004681 RID: 18049
		internal object <_>__35;

		// Token: 0x04004682 RID: 18050
		internal IDisposable $locvar2C;

		// Token: 0x04004683 RID: 18051
		internal double <rfrate>__36;

		// Token: 0x04004684 RID: 18052
		internal double <pct>__36;

		// Token: 0x04004685 RID: 18053
		internal int <rate>__37;

		// Token: 0x04004686 RID: 18054
		internal IEnumerator $locvar2D;

		// Token: 0x04004687 RID: 18055
		internal object <_>__38;

		// Token: 0x04004688 RID: 18056
		internal IDisposable $locvar2E;

		// Token: 0x04004689 RID: 18057
		internal object $current;

		// Token: 0x0400468A RID: 18058
		internal bool $disposing;

		// Token: 0x0400468B RID: 18059
		internal int $PC;

		// Token: 0x0400468C RID: 18060
		private DamageExtensions.<ReceivesDamage>c__Iterator0.<ReceivesDamage>c__AnonStoreyB $locvar30;

		// Token: 0x0400468D RID: 18061
		private DamageExtensions.<ReceivesDamage>c__Iterator0.<ReceivesDamage>c__AnonStoreyA $locvar31;

		// Token: 0x0400468E RID: 18062
		private static Func<BattleEffectBase, bool> <>f__am$cache0;

		// Token: 0x0400468F RID: 18063
		private static Func<IBattleUnit, bool> <>f__am$cache1;

		// Token: 0x04004690 RID: 18064
		private static Func<DamageReductionByValueEffect, double> <>f__am$cache2;

		// Token: 0x04004691 RID: 18065
		private static Func<BattleEffectBase, BattleEffectBase> <>f__am$cache3;

		// Token: 0x04004692 RID: 18066
		private static Func<IBattleUnit, bool> <>f__am$cache4;

		// Token: 0x04004693 RID: 18067
		private static Func<DamageComponent, bool> <>f__am$cache5;

		// Token: 0x04004694 RID: 18068
		private static Func<DamageComponent, bool> <>f__am$cache6;

		// Token: 0x04004695 RID: 18069
		private static Func<DamageComponent, bool> <>f__am$cache7;

		// Token: 0x04004696 RID: 18070
		private static Func<DamageComponent, bool> <>f__am$cache8;

		// Token: 0x04004697 RID: 18071
		private static Func<DamageComponent, bool> <>f__am$cache9;

		// Token: 0x04004698 RID: 18072
		private static Func<DamageComponent, double> <>f__am$cacheA;

		// Token: 0x02000D67 RID: 3431
		private sealed class <ReceivesDamage>c__AnonStoreyB
		{
			// Token: 0x060057AD RID: 22445 RVA: 0x000F5630 File Offset: 0x000F3A30
			public <ReceivesDamage>c__AnonStoreyB()
			{
			}

			// Token: 0x04004779 RID: 18297
			internal IBattleUnit unit;

			// Token: 0x0400477A RID: 18298
			internal DamageExtensions.<ReceivesDamage>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000D68 RID: 3432
		private sealed class <ReceivesDamage>c__AnonStoreyA
		{
			// Token: 0x060057AE RID: 22446 RVA: 0x000F5638 File Offset: 0x000F3A38
			public <ReceivesDamage>c__AnonStoreyA()
			{
			}

			// Token: 0x060057AF RID: 22447 RVA: 0x000F5640 File Offset: 0x000F3A40
			internal bool <>m__0(string n)
			{
				return n != this.key;
			}

			// Token: 0x060057B0 RID: 22448 RVA: 0x000F5650 File Offset: 0x000F3A50
			internal BattleDamage <>m__1(IBattleUnit t)
			{
				return new BattleDamage(t, new SpecialEffectTriggerSource(this.<>f__ref$11.unit, SpecialEffectType.DrunkReaderStarUndead), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$11.unit, t, this.<>f__ref$11.unit.GetOutputType(), 100.0)
					}, t, this.<>f__ref$11.unit, false, false)
				});
			}

			// Token: 0x0400477B RID: 18299
			internal string key;

			// Token: 0x0400477C RID: 18300
			internal DamageExtensions.<ReceivesDamage>c__Iterator0 <>f__ref$0;

			// Token: 0x0400477D RID: 18301
			internal DamageExtensions.<ReceivesDamage>c__Iterator0.<ReceivesDamage>c__AnonStoreyB <>f__ref$11;
		}
	}

	// Token: 0x02000D5D RID: 3421
	[CompilerGenerated]
	private sealed class <ElementalDamageCalculation>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005752 RID: 22354 RVA: 0x000F56CF File Offset: 0x000F3ACF
		[DebuggerHidden]
		public <ElementalDamageCalculation>c__Iterator1()
		{
		}

		// Token: 0x06005753 RID: 22355 RVA: 0x000F56D8 File Offset: 0x000F3AD8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Fire))
				{
					goto IL_116;
				}
				enumerator = DamageExtensions.FireElementProcess(damage).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_7:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						p3 = enumerator2.Current;
						this.$current = p3;
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
				goto IL_1ED;
			case 3u:
				Block_10:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						p4 = enumerator3.Current;
						this.$current = p4;
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
				goto IL_2C4;
			case 4u:
				Block_13:
				try
				{
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						p5 = enumerator4.Current;
						this.$current = p5;
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
				goto IL_39B;
			case 5u:
				Block_16:
				try
				{
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						p6 = enumerator5.Current;
						this.$current = p6;
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
				goto IL_472;
			case 6u:
				Block_19:
				try
				{
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						p7 = enumerator6.Current;
						this.$current = p7;
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
						if ((disposable6 = (enumerator6 as IDisposable)) != null)
						{
							disposable6.Dispose();
						}
					}
				}
				goto IL_549;
			case 7u:
				Block_22:
				try
				{
					switch (num)
					{
					}
					if (enumerator7.MoveNext())
					{
						p8 = enumerator7.Current;
						this.$current = p8;
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
						if ((disposable7 = (enumerator7 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				goto IL_620;
			case 8u:
				Block_23:
				try
				{
					switch (num)
					{
					}
					if (enumerator8.MoveNext())
					{
						_ = enumerator8.Current;
						this.$current = _;
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
						if ((disposable8 = (enumerator8 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
				}
				this.$PC = -1;
				return false;
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
					p2 = enumerator.Current;
					this.$current = p2;
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
			IL_116:
			if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Physical))
			{
				enumerator2 = DamageExtensions.PhysicalElementProcess(damage).GetEnumerator();
				num = 4294967293u;
				goto Block_7;
			}
			IL_1ED:
			if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Divine))
			{
				enumerator3 = DamageExtensions.DivineElementProcess(damage).GetEnumerator();
				num = 4294967293u;
				goto Block_10;
			}
			IL_2C4:
			if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Shadow))
			{
				enumerator4 = DamageExtensions.ShadowDamageProcess(damage).GetEnumerator();
				num = 4294967293u;
				goto Block_13;
			}
			IL_39B:
			if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Poison))
			{
				enumerator5 = DamageExtensions.PoisonElementProcess(damage).GetEnumerator();
				num = 4294967293u;
				goto Block_16;
			}
			IL_472:
			if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Lightening))
			{
				enumerator6 = DamageExtensions.LighteningProcess(damage).GetEnumerator();
				num = 4294967293u;
				goto Block_19;
			}
			IL_549:
			if (damage.Dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Ice))
			{
				enumerator7 = DamageExtensions.IceElementProcess(damage).GetEnumerator();
				num = 4294967293u;
				goto Block_22;
			}
			IL_620:
			enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.ElementDamageProcessCompleted, damage)).GetEnumerator();
			num = 4294967293u;
			goto Block_23;
		}

		// Token: 0x17001260 RID: 4704
		// (get) Token: 0x06005754 RID: 22356 RVA: 0x000F5E20 File Offset: 0x000F4220
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001261 RID: 4705
		// (get) Token: 0x06005755 RID: 22357 RVA: 0x000F5E28 File Offset: 0x000F4228
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005756 RID: 22358 RVA: 0x000F5E30 File Offset: 0x000F4230
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
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
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
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
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
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005757 RID: 22359 RVA: 0x000F6058 File Offset: 0x000F4458
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005758 RID: 22360 RVA: 0x000F605F File Offset: 0x000F445F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005759 RID: 22361 RVA: 0x000F6068 File Offset: 0x000F4468
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<ElementalDamageCalculation>c__Iterator1 <ElementalDamageCalculation>c__Iterator = new DamageExtensions.<ElementalDamageCalculation>c__Iterator1();
			<ElementalDamageCalculation>c__Iterator.damage = damage;
			<ElementalDamageCalculation>c__Iterator.unit = unit;
			return <ElementalDamageCalculation>c__Iterator;
		}

		// Token: 0x0600575A RID: 22362 RVA: 0x000F60A8 File Offset: 0x000F44A8
		private static bool <>m__0(ElementEffectData ef)
		{
			return ef.ElementType == OutputType.Fire;
		}

		// Token: 0x0600575B RID: 22363 RVA: 0x000F60B3 File Offset: 0x000F44B3
		private static bool <>m__1(ElementEffectData ef)
		{
			return ef.ElementType == OutputType.Physical;
		}

		// Token: 0x0600575C RID: 22364 RVA: 0x000F60BE File Offset: 0x000F44BE
		private static bool <>m__2(ElementEffectData ef)
		{
			return ef.ElementType == OutputType.Divine;
		}

		// Token: 0x0600575D RID: 22365 RVA: 0x000F60C9 File Offset: 0x000F44C9
		private static bool <>m__3(ElementEffectData ef)
		{
			return ef.ElementType == OutputType.Shadow;
		}

		// Token: 0x0600575E RID: 22366 RVA: 0x000F60D4 File Offset: 0x000F44D4
		private static bool <>m__4(ElementEffectData ef)
		{
			return ef.ElementType == OutputType.Poison;
		}

		// Token: 0x0600575F RID: 22367 RVA: 0x000F60DF File Offset: 0x000F44DF
		private static bool <>m__5(ElementEffectData ef)
		{
			return ef.ElementType == OutputType.Lightening;
		}

		// Token: 0x06005760 RID: 22368 RVA: 0x000F60EA File Offset: 0x000F44EA
		private static bool <>m__6(ElementEffectData ef)
		{
			return ef.ElementType == OutputType.Ice;
		}

		// Token: 0x04004699 RID: 18073
		internal BattleDamage damage;

		// Token: 0x0400469A RID: 18074
		internal IEnumerator $locvar0;

		// Token: 0x0400469B RID: 18075
		internal object <p2>__1;

		// Token: 0x0400469C RID: 18076
		internal IDisposable $locvar1;

		// Token: 0x0400469D RID: 18077
		internal IEnumerator $locvar2;

		// Token: 0x0400469E RID: 18078
		internal object <p2>__2;

		// Token: 0x0400469F RID: 18079
		internal IDisposable $locvar3;

		// Token: 0x040046A0 RID: 18080
		internal IEnumerator $locvar4;

		// Token: 0x040046A1 RID: 18081
		internal object <p2>__3;

		// Token: 0x040046A2 RID: 18082
		internal IDisposable $locvar5;

		// Token: 0x040046A3 RID: 18083
		internal IEnumerator $locvar6;

		// Token: 0x040046A4 RID: 18084
		internal object <p2>__4;

		// Token: 0x040046A5 RID: 18085
		internal IDisposable $locvar7;

		// Token: 0x040046A6 RID: 18086
		internal IEnumerator $locvar8;

		// Token: 0x040046A7 RID: 18087
		internal object <p2>__5;

		// Token: 0x040046A8 RID: 18088
		internal IDisposable $locvar9;

		// Token: 0x040046A9 RID: 18089
		internal IEnumerator $locvarA;

		// Token: 0x040046AA RID: 18090
		internal object <p2>__6;

		// Token: 0x040046AB RID: 18091
		internal IDisposable $locvarB;

		// Token: 0x040046AC RID: 18092
		internal IEnumerator $locvarC;

		// Token: 0x040046AD RID: 18093
		internal object <p2>__7;

		// Token: 0x040046AE RID: 18094
		internal IDisposable $locvarD;

		// Token: 0x040046AF RID: 18095
		internal IBattleUnit unit;

		// Token: 0x040046B0 RID: 18096
		internal IEnumerator $locvarE;

		// Token: 0x040046B1 RID: 18097
		internal object <_>__8;

		// Token: 0x040046B2 RID: 18098
		internal IDisposable $locvarF;

		// Token: 0x040046B3 RID: 18099
		internal object $current;

		// Token: 0x040046B4 RID: 18100
		internal bool $disposing;

		// Token: 0x040046B5 RID: 18101
		internal int $PC;

		// Token: 0x040046B6 RID: 18102
		private static Func<ElementEffectData, bool> <>f__am$cache0;

		// Token: 0x040046B7 RID: 18103
		private static Func<ElementEffectData, bool> <>f__am$cache1;

		// Token: 0x040046B8 RID: 18104
		private static Func<ElementEffectData, bool> <>f__am$cache2;

		// Token: 0x040046B9 RID: 18105
		private static Func<ElementEffectData, bool> <>f__am$cache3;

		// Token: 0x040046BA RID: 18106
		private static Func<ElementEffectData, bool> <>f__am$cache4;

		// Token: 0x040046BB RID: 18107
		private static Func<ElementEffectData, bool> <>f__am$cache5;

		// Token: 0x040046BC RID: 18108
		private static Func<ElementEffectData, bool> <>f__am$cache6;
	}

	// Token: 0x02000D5E RID: 3422
	[CompilerGenerated]
	private sealed class <LighteningProcess>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005761 RID: 22369 RVA: 0x000F60F5 File Offset: 0x000F44F5
		[DebuggerHidden]
		public <LighteningProcess>c__Iterator2()
		{
		}

		// Token: 0x06005762 RID: 22370 RVA: 0x000F6100 File Offset: 0x000F4500
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Lightening);
				triggerSpread = false;
				enumerator = effectiveDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_470;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_14:
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
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator.MoveNext())
				{
					DamageExtensions.EffectiveDamage effectiveDamage = enumerator.Current;
					triggerSpread = true;
					chance = 0.3;
					numberOfAdditionalTargets = 2;
					damageRate = 1.0;
					if ((double)UnityEngine.Random.value <= chance)
					{
						avaliableTargets = (from t in effectiveDamage.Target.GetAllLiveFriendlyTargetsIncSelf(true)
						where t != effectiveDamage.Target
						select t).Take(numberOfAdditionalTargets).ToList<IBattleUnit>();
						damages = new List<BattleDamage>();
						damageValue = damageRate * effectiveDamage.TotalDamage;
						if (damageValue > 0.0 && avaliableTargets.Any<IBattleUnit>())
						{
							enumerator2 = avaliableTargets.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									IBattleUnit target = enumerator2.Current;
									damages.Add(new BattleDamage(target, new SpecialEffectTriggerSource(<LighteningProcess>c__AnonStoreyD.damage.Dealer, SpecialEffectType.ElementEffects), new List<DamageComponentValue>
									{
										new DamageComponentValue(new List<DamagePotionValue>
										{
											DamagePotionValue.CreateRawValuedDamageComponent(target, <LighteningProcess>c__AnonStoreyD.damage.Dealer, OutputType.Lightening, damageValue)
										}, target, <LighteningProcess>c__AnonStoreyD.damage.Dealer, false, false)
									}));
								}
							}
							finally
							{
								((IDisposable)enumerator2).Dispose();
							}
							releaseable = new ReleaseableDamage(damages, <LighteningProcess>c__AnonStoreyD.damage.Dealer);
							enumerator3 = releaseable.Release().GetEnumerator();
							num = 4294967293u;
							goto Block_14;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			if (!triggerSpread || !<LighteningProcess>c__AnonStoreyD.damage.Dealer.SpecialEffects.OfType<LightningEnhancementData>().Any<LightningEnhancementData>() || !<LighteningProcess>c__AnonStoreyD.damage.Target.BattleEffects.OfType<ISpreadableDamageOverTime>().Any<ISpreadableDamageOverTime>())
			{
				goto IL_570;
			}
			extra = <LighteningProcess>c__AnonStoreyD.damage.Dealer.SpecialEffects.OfType<LightningEnhancementData>().First<LightningEnhancementData>().SpreadNumber;
			targets = (from u in <LighteningProcess>c__AnonStoreyD.damage.Target.GetAllLiveFriendlyTargetsIncSelf(true)
			select u).ToList<IBattleUnit>();
			targets.Shuffle<IBattleUnit>();
			targets = (from u in targets
			where u != <LighteningProcess>c__AnonStoreyD.damage.Target
			select u).Take(extra).ToList<IBattleUnit>();
			if (!targets.Any<IBattleUnit>())
			{
				goto IL_570;
			}
			enumerator4 = <LighteningProcess>c__AnonStoreyD.damage.Target.BattleEffects.OfType<ISpreadableDamageOverTime>().ToList<ISpreadableDamageOverTime>().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_470:
				switch (num)
				{
				case 2u:
					Block_28:
					try
					{
						switch (num)
						{
						}
						if (enumerator5.MoveNext())
						{
							_2 = enumerator5.Current;
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
							if ((disposable2 = (enumerator5 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator4.MoveNext())
				{
					spreadableDamageOverTime = enumerator4.Current;
					enumerator5 = spreadableDamageOverTime.Spread(<LighteningProcess>c__AnonStoreyD.damage.Target, targets).GetEnumerator();
					num = 4294967293u;
					goto Block_28;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
			IL_570:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001262 RID: 4706
		// (get) Token: 0x06005763 RID: 22371 RVA: 0x000F6704 File Offset: 0x000F4B04
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001263 RID: 4707
		// (get) Token: 0x06005764 RID: 22372 RVA: 0x000F670C File Offset: 0x000F4B0C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005765 RID: 22373 RVA: 0x000F6714 File Offset: 0x000F4B14
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
						if ((disposable = (enumerator3 as IDisposable)) != null)
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
						if ((disposable2 = (enumerator5 as IDisposable)) != null)
						{
							disposable2.Dispose();
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

		// Token: 0x06005766 RID: 22374 RVA: 0x000F6808 File Offset: 0x000F4C08
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005767 RID: 22375 RVA: 0x000F680F File Offset: 0x000F4C0F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005768 RID: 22376 RVA: 0x000F6818 File Offset: 0x000F4C18
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<LighteningProcess>c__Iterator2 <LighteningProcess>c__Iterator = new DamageExtensions.<LighteningProcess>c__Iterator2();
			<LighteningProcess>c__Iterator.damage = damage;
			return <LighteningProcess>c__Iterator;
		}

		// Token: 0x06005769 RID: 22377 RVA: 0x000F684C File Offset: 0x000F4C4C
		private static IBattleUnit <>m__0(IBattleUnit u)
		{
			return u;
		}

		// Token: 0x040046BD RID: 18109
		internal BattleDamage damage;

		// Token: 0x040046BE RID: 18110
		internal List<DamageExtensions.EffectiveDamage> <effectiveDamages>__0;

		// Token: 0x040046BF RID: 18111
		internal bool <triggerSpread>__0;

		// Token: 0x040046C0 RID: 18112
		internal List<DamageExtensions.EffectiveDamage>.Enumerator $locvar0;

		// Token: 0x040046C1 RID: 18113
		internal double <chance>__2;

		// Token: 0x040046C2 RID: 18114
		internal int <numberOfAdditionalTargets>__2;

		// Token: 0x040046C3 RID: 18115
		internal double <damageRate>__2;

		// Token: 0x040046C4 RID: 18116
		internal List<IBattleUnit> <avaliableTargets>__3;

		// Token: 0x040046C5 RID: 18117
		internal List<BattleDamage> <damages>__3;

		// Token: 0x040046C6 RID: 18118
		internal double <damageValue>__3;

		// Token: 0x040046C7 RID: 18119
		internal List<IBattleUnit>.Enumerator $locvar1;

		// Token: 0x040046C8 RID: 18120
		internal ReleaseableDamage <releaseable>__4;

		// Token: 0x040046C9 RID: 18121
		internal IEnumerator $locvar2;

		// Token: 0x040046CA RID: 18122
		internal object <_>__5;

		// Token: 0x040046CB RID: 18123
		internal IDisposable $locvar3;

		// Token: 0x040046CC RID: 18124
		internal int <extra>__6;

		// Token: 0x040046CD RID: 18125
		internal List<IBattleUnit> <targets>__6;

		// Token: 0x040046CE RID: 18126
		internal List<ISpreadableDamageOverTime>.Enumerator $locvar4;

		// Token: 0x040046CF RID: 18127
		internal ISpreadableDamageOverTime <spreadableDamageOverTime>__7;

		// Token: 0x040046D0 RID: 18128
		internal IEnumerator $locvar5;

		// Token: 0x040046D1 RID: 18129
		internal object <_>__8;

		// Token: 0x040046D2 RID: 18130
		internal IDisposable $locvar6;

		// Token: 0x040046D3 RID: 18131
		internal object $current;

		// Token: 0x040046D4 RID: 18132
		internal bool $disposing;

		// Token: 0x040046D5 RID: 18133
		internal int $PC;

		// Token: 0x040046D6 RID: 18134
		private DamageExtensions.<LighteningProcess>c__Iterator2.<LighteningProcess>c__AnonStoreyD $locvar7;

		// Token: 0x040046D7 RID: 18135
		private DamageExtensions.<LighteningProcess>c__Iterator2.<LighteningProcess>c__AnonStoreyC $locvar8;

		// Token: 0x040046D8 RID: 18136
		private static Func<IBattleUnit, IBattleUnit> <>f__am$cache0;

		// Token: 0x02000D69 RID: 3433
		private sealed class <LighteningProcess>c__AnonStoreyD
		{
			// Token: 0x060057B1 RID: 22449 RVA: 0x000F684F File Offset: 0x000F4C4F
			public <LighteningProcess>c__AnonStoreyD()
			{
			}

			// Token: 0x060057B2 RID: 22450 RVA: 0x000F6857 File Offset: 0x000F4C57
			internal bool <>m__0(IBattleUnit u)
			{
				return u != this.damage.Target;
			}

			// Token: 0x0400477E RID: 18302
			internal BattleDamage damage;

			// Token: 0x0400477F RID: 18303
			internal DamageExtensions.<LighteningProcess>c__Iterator2 <>f__ref$2;
		}

		// Token: 0x02000D6A RID: 3434
		private sealed class <LighteningProcess>c__AnonStoreyC
		{
			// Token: 0x060057B3 RID: 22451 RVA: 0x000F686A File Offset: 0x000F4C6A
			public <LighteningProcess>c__AnonStoreyC()
			{
			}

			// Token: 0x060057B4 RID: 22452 RVA: 0x000F6872 File Offset: 0x000F4C72
			internal bool <>m__0(IBattleUnit t)
			{
				return t != this.effectiveDamage.Target;
			}

			// Token: 0x04004780 RID: 18304
			internal DamageExtensions.EffectiveDamage effectiveDamage;

			// Token: 0x04004781 RID: 18305
			internal DamageExtensions.<LighteningProcess>c__Iterator2 <>f__ref$2;
		}
	}

	// Token: 0x02000D5F RID: 3423
	[CompilerGenerated]
	private sealed class <ShadowDamageProcess>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600576A RID: 22378 RVA: 0x000F6885 File Offset: 0x000F4C85
		[DebuggerHidden]
		public <ShadowDamageProcess>c__Iterator3()
		{
		}

		// Token: 0x0600576B RID: 22379 RVA: 0x000F6890 File Offset: 0x000F4C90
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Shadow);
				enumerator = effectiveDamages.GetEnumerator();
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
					effectiveDamage = enumerator.Current;
					numberOfLastingSeconds = 3f;
					damageRate = 0.25;
					healRate = 0.2;
					damagePerTick = effectiveDamage.TotalDamage * damageRate;
					enumerator2 = effectiveDamage.Target.ApplySkillEffect(LifeExtractionEffect.CreateShadowProcEffect(damage.DamageSource, damagePerTick, healRate, effectiveDamage.Target, numberOfLastingSeconds, "SHADOWPROC"), false).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001264 RID: 4708
		// (get) Token: 0x0600576C RID: 22380 RVA: 0x000F6A88 File Offset: 0x000F4E88
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001265 RID: 4709
		// (get) Token: 0x0600576D RID: 22381 RVA: 0x000F6A90 File Offset: 0x000F4E90
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600576E RID: 22382 RVA: 0x000F6A98 File Offset: 0x000F4E98
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

		// Token: 0x0600576F RID: 22383 RVA: 0x000F6B2C File Offset: 0x000F4F2C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005770 RID: 22384 RVA: 0x000F6B33 File Offset: 0x000F4F33
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005771 RID: 22385 RVA: 0x000F6B3C File Offset: 0x000F4F3C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<ShadowDamageProcess>c__Iterator3 <ShadowDamageProcess>c__Iterator = new DamageExtensions.<ShadowDamageProcess>c__Iterator3();
			<ShadowDamageProcess>c__Iterator.damage = damage;
			return <ShadowDamageProcess>c__Iterator;
		}

		// Token: 0x040046D9 RID: 18137
		internal BattleDamage damage;

		// Token: 0x040046DA RID: 18138
		internal List<DamageExtensions.EffectiveDamage> <effectiveDamages>__0;

		// Token: 0x040046DB RID: 18139
		internal List<DamageExtensions.EffectiveDamage>.Enumerator $locvar0;

		// Token: 0x040046DC RID: 18140
		internal DamageExtensions.EffectiveDamage <effectiveDamage>__1;

		// Token: 0x040046DD RID: 18141
		internal float <numberOfLastingSeconds>__2;

		// Token: 0x040046DE RID: 18142
		internal double <damageRate>__2;

		// Token: 0x040046DF RID: 18143
		internal double <healRate>__2;

		// Token: 0x040046E0 RID: 18144
		internal double <damagePerTick>__2;

		// Token: 0x040046E1 RID: 18145
		internal IEnumerator $locvar1;

		// Token: 0x040046E2 RID: 18146
		internal object <_>__3;

		// Token: 0x040046E3 RID: 18147
		internal IDisposable $locvar2;

		// Token: 0x040046E4 RID: 18148
		internal object $current;

		// Token: 0x040046E5 RID: 18149
		internal bool $disposing;

		// Token: 0x040046E6 RID: 18150
		internal int $PC;
	}

	// Token: 0x02000D60 RID: 3424
	[CompilerGenerated]
	private sealed class <PhysicalElementProcess>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005772 RID: 22386 RVA: 0x000F6B70 File Offset: 0x000F4F70
		[DebuggerHidden]
		public <PhysicalElementProcess>c__Iterator4()
		{
		}

		// Token: 0x06005773 RID: 22387 RVA: 0x000F6B78 File Offset: 0x000F4F78
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Physical);
				enumerator = effectiveDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
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
				case 2u:
					Block_11:
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
					goto IL_42B;
				default:
					goto IL_42B;
				}
				IL_2A4:
				totalDodgeRate = damage.Dealer.SpecialEffects.OfType<PhysicalEffectEnhancementData>().Sum((PhysicalEffectEnhancementData e) => e.DodgeRate);
				if (totalDodgeRate > 0.0)
				{
					enumerator3 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(damage.Dealer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.DodgeRateAdjustment,
							ModificationType = ModificationType.Addition,
							Value = -totalDodgeRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, damage.Dealer.GetId() + "physicaladvanced", new int?(5), new float?(6f), null, true, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_11;
				}
				IL_42B:
				if (enumerator.MoveNext())
				{
					effectiveDamage = enumerator.Current;
					AttributeType reductionType = AttributeType.PhysicalResistance;
					reductionRate = 0.2;
					maxReductionRate = 0.5;
					string reductionKey = AttributeModificationEffect.PhysicalDamage_Proc;
					existingArmorReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
					reductionValue = effectiveDamage.TotalDamage * reductionRate;
					maxValue = effectiveDamage.Target.GetAttributeValue_Final(reductionType, AttributeRetrievalLevel.Gear) * maxReductionRate;
					total = reductionValue;
					if (existingArmorReduction != null)
					{
						double num2 = -(from a in existingArmorReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
						where a.AttributeType == reductionType
						select a).Sum((AttributeModifier a) => a.Value);
						total += num2;
					}
					if (total > maxValue)
					{
						total = maxValue;
					}
					if (total > 0.0)
					{
						enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreatePhysicalDamageProc(damage.Dealer, -total), false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
					goto IL_2A4;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001266 RID: 4710
		// (get) Token: 0x06005774 RID: 22388 RVA: 0x000F7034 File Offset: 0x000F5434
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001267 RID: 4711
		// (get) Token: 0x06005775 RID: 22389 RVA: 0x000F703C File Offset: 0x000F543C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005776 RID: 22390 RVA: 0x000F7044 File Offset: 0x000F5444
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005777 RID: 22391 RVA: 0x000F712C File Offset: 0x000F552C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005778 RID: 22392 RVA: 0x000F7133 File Offset: 0x000F5533
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005779 RID: 22393 RVA: 0x000F713C File Offset: 0x000F553C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<PhysicalElementProcess>c__Iterator4 <PhysicalElementProcess>c__Iterator = new DamageExtensions.<PhysicalElementProcess>c__Iterator4();
			<PhysicalElementProcess>c__Iterator.damage = damage;
			return <PhysicalElementProcess>c__Iterator;
		}

		// Token: 0x0600577A RID: 22394 RVA: 0x000F7170 File Offset: 0x000F5570
		private static double <>m__0(AttributeModifier a)
		{
			return a.Value;
		}

		// Token: 0x0600577B RID: 22395 RVA: 0x000F7178 File Offset: 0x000F5578
		private static double <>m__1(PhysicalEffectEnhancementData e)
		{
			return e.DodgeRate;
		}

		// Token: 0x040046E7 RID: 18151
		internal BattleDamage damage;

		// Token: 0x040046E8 RID: 18152
		internal List<DamageExtensions.EffectiveDamage> <effectiveDamages>__0;

		// Token: 0x040046E9 RID: 18153
		internal List<DamageExtensions.EffectiveDamage>.Enumerator $locvar0;

		// Token: 0x040046EA RID: 18154
		internal DamageExtensions.EffectiveDamage <effectiveDamage>__1;

		// Token: 0x040046EB RID: 18155
		internal double <reductionRate>__2;

		// Token: 0x040046EC RID: 18156
		internal double <maxReductionRate>__2;

		// Token: 0x040046ED RID: 18157
		internal AttributeModificationEffect <existingArmorReduction>__2;

		// Token: 0x040046EE RID: 18158
		internal double <reductionValue>__2;

		// Token: 0x040046EF RID: 18159
		internal double <maxValue>__2;

		// Token: 0x040046F0 RID: 18160
		internal double <total>__2;

		// Token: 0x040046F1 RID: 18161
		internal IEnumerator $locvar1;

		// Token: 0x040046F2 RID: 18162
		internal object <_>__3;

		// Token: 0x040046F3 RID: 18163
		internal IDisposable $locvar2;

		// Token: 0x040046F4 RID: 18164
		internal double <totalDodgeRate>__2;

		// Token: 0x040046F5 RID: 18165
		internal IEnumerator $locvar3;

		// Token: 0x040046F6 RID: 18166
		internal object <_>__4;

		// Token: 0x040046F7 RID: 18167
		internal IDisposable $locvar4;

		// Token: 0x040046F8 RID: 18168
		internal object $current;

		// Token: 0x040046F9 RID: 18169
		internal bool $disposing;

		// Token: 0x040046FA RID: 18170
		internal int $PC;

		// Token: 0x040046FB RID: 18171
		private DamageExtensions.<PhysicalElementProcess>c__Iterator4.<PhysicalElementProcess>c__AnonStoreyE $locvar5;

		// Token: 0x040046FC RID: 18172
		private static Func<AttributeModifier, double> <>f__am$cache0;

		// Token: 0x040046FD RID: 18173
		private static Func<PhysicalEffectEnhancementData, double> <>f__am$cache1;

		// Token: 0x02000D6B RID: 3435
		private sealed class <PhysicalElementProcess>c__AnonStoreyE
		{
			// Token: 0x060057B5 RID: 22453 RVA: 0x000F7180 File Offset: 0x000F5580
			public <PhysicalElementProcess>c__AnonStoreyE()
			{
			}

			// Token: 0x060057B6 RID: 22454 RVA: 0x000F7188 File Offset: 0x000F5588
			internal bool <>m__0(AttributeModificationEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.reductionKey;
			}

			// Token: 0x060057B7 RID: 22455 RVA: 0x000F719B File Offset: 0x000F559B
			internal bool <>m__1(AttributeModifier a)
			{
				return a.AttributeType == this.reductionType;
			}

			// Token: 0x04004782 RID: 18306
			internal string reductionKey;

			// Token: 0x04004783 RID: 18307
			internal AttributeType reductionType;

			// Token: 0x04004784 RID: 18308
			internal DamageExtensions.<PhysicalElementProcess>c__Iterator4 <>f__ref$4;
		}
	}

	// Token: 0x02000D61 RID: 3425
	[CompilerGenerated]
	private sealed class <IceElementProcess>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600577C RID: 22396 RVA: 0x000F71AB File Offset: 0x000F55AB
		[DebuggerHidden]
		public <IceElementProcess>c__Iterator5()
		{
		}

		// Token: 0x0600577D RID: 22397 RVA: 0x000F71B4 File Offset: 0x000F55B4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Ice);
				enumerator = effectiveDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
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
				case 2u:
					Block_11:
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
					goto IL_3C9;
				default:
					goto IL_3C9;
				}
				IL_2A4:
				effectiveRate = 0.5;
				iceEffectiveness = DamageExtensions.GetElementalEffectEffectiveness(effectiveDamage.TotalDamage, damage.Dealer) * effectiveRate;
				maxChance = 0.6;
				if (iceEffectiveness > maxChance)
				{
					iceEffectiveness = maxChance;
				}
				if ((double)UnityEngine.Random.value <= iceEffectiveness)
				{
					enumerator3 = LockTimeEffect.AddFrozenSeconds(effectiveDamage.Target, 1f, damage.Dealer, false).GetEnumerator();
					num = 4294967293u;
					goto Block_11;
				}
				IL_3C9:
				if (enumerator.MoveNext())
				{
					effectiveDamage = enumerator.Current;
					AttributeType reductionType = AttributeType.Agility;
					reductionRate = 0.3;
					maxReductionRate = 0.6;
					string reductionKey = AttributeModificationEffect.IceDamage_Proc;
					existingArmorReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
					reductionValue = effectiveDamage.TotalDamage * reductionRate;
					maxValue = effectiveDamage.Target.GetAttributeValue_Final(reductionType, AttributeRetrievalLevel.Gear) * maxReductionRate;
					total = reductionValue;
					if (existingArmorReduction != null)
					{
						double num2 = -(from a in existingArmorReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
						where a.AttributeType == reductionType
						select a).Sum((AttributeModifier a) => a.Value);
						total += num2;
					}
					if (total > maxValue)
					{
						total = maxValue;
					}
					if (total > 0.0)
					{
						enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateIceDamageProc(damage.Dealer, -total), false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
					goto IL_2A4;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001268 RID: 4712
		// (get) Token: 0x0600577E RID: 22398 RVA: 0x000F760C File Offset: 0x000F5A0C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001269 RID: 4713
		// (get) Token: 0x0600577F RID: 22399 RVA: 0x000F7614 File Offset: 0x000F5A14
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005780 RID: 22400 RVA: 0x000F761C File Offset: 0x000F5A1C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005781 RID: 22401 RVA: 0x000F7704 File Offset: 0x000F5B04
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005782 RID: 22402 RVA: 0x000F770B File Offset: 0x000F5B0B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005783 RID: 22403 RVA: 0x000F7714 File Offset: 0x000F5B14
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<IceElementProcess>c__Iterator5 <IceElementProcess>c__Iterator = new DamageExtensions.<IceElementProcess>c__Iterator5();
			<IceElementProcess>c__Iterator.damage = damage;
			return <IceElementProcess>c__Iterator;
		}

		// Token: 0x06005784 RID: 22404 RVA: 0x000F7748 File Offset: 0x000F5B48
		private static double <>m__0(AttributeModifier a)
		{
			return a.Value;
		}

		// Token: 0x040046FE RID: 18174
		internal BattleDamage damage;

		// Token: 0x040046FF RID: 18175
		internal List<DamageExtensions.EffectiveDamage> <effectiveDamages>__0;

		// Token: 0x04004700 RID: 18176
		internal List<DamageExtensions.EffectiveDamage>.Enumerator $locvar0;

		// Token: 0x04004701 RID: 18177
		internal DamageExtensions.EffectiveDamage <effectiveDamage>__1;

		// Token: 0x04004702 RID: 18178
		internal double <reductionRate>__2;

		// Token: 0x04004703 RID: 18179
		internal double <maxReductionRate>__2;

		// Token: 0x04004704 RID: 18180
		internal AttributeModificationEffect <existingArmorReduction>__2;

		// Token: 0x04004705 RID: 18181
		internal double <reductionValue>__2;

		// Token: 0x04004706 RID: 18182
		internal double <maxValue>__2;

		// Token: 0x04004707 RID: 18183
		internal double <total>__2;

		// Token: 0x04004708 RID: 18184
		internal IEnumerator $locvar1;

		// Token: 0x04004709 RID: 18185
		internal object <_>__3;

		// Token: 0x0400470A RID: 18186
		internal IDisposable $locvar2;

		// Token: 0x0400470B RID: 18187
		internal double <effectiveRate>__2;

		// Token: 0x0400470C RID: 18188
		internal double <iceEffectiveness>__2;

		// Token: 0x0400470D RID: 18189
		internal double <maxChance>__2;

		// Token: 0x0400470E RID: 18190
		internal IEnumerator $locvar3;

		// Token: 0x0400470F RID: 18191
		internal object <_>__4;

		// Token: 0x04004710 RID: 18192
		internal IDisposable $locvar4;

		// Token: 0x04004711 RID: 18193
		internal object $current;

		// Token: 0x04004712 RID: 18194
		internal bool $disposing;

		// Token: 0x04004713 RID: 18195
		internal int $PC;

		// Token: 0x04004714 RID: 18196
		private DamageExtensions.<IceElementProcess>c__Iterator5.<IceElementProcess>c__AnonStoreyF $locvar5;

		// Token: 0x04004715 RID: 18197
		private static Func<AttributeModifier, double> <>f__am$cache0;

		// Token: 0x02000D6C RID: 3436
		private sealed class <IceElementProcess>c__AnonStoreyF
		{
			// Token: 0x060057B8 RID: 22456 RVA: 0x000F7750 File Offset: 0x000F5B50
			public <IceElementProcess>c__AnonStoreyF()
			{
			}

			// Token: 0x060057B9 RID: 22457 RVA: 0x000F7758 File Offset: 0x000F5B58
			internal bool <>m__0(AttributeModificationEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.reductionKey;
			}

			// Token: 0x060057BA RID: 22458 RVA: 0x000F776B File Offset: 0x000F5B6B
			internal bool <>m__1(AttributeModifier a)
			{
				return a.AttributeType == this.reductionType;
			}

			// Token: 0x04004785 RID: 18309
			internal string reductionKey;

			// Token: 0x04004786 RID: 18310
			internal AttributeType reductionType;

			// Token: 0x04004787 RID: 18311
			internal DamageExtensions.<IceElementProcess>c__Iterator5 <>f__ref$5;
		}
	}

	// Token: 0x02000D62 RID: 3426
	[CompilerGenerated]
	private sealed class <DivineElementProcess>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005785 RID: 22405 RVA: 0x000F777B File Offset: 0x000F5B7B
		[DebuggerHidden]
		public <DivineElementProcess>c__Iterator6()
		{
		}

		// Token: 0x06005786 RID: 22406 RVA: 0x000F7784 File Offset: 0x000F5B84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Divine);
				enumerator = effectiveDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
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
				case 2u:
					Block_11:
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
					goto IL_3DD;
				default:
					goto IL_3DD;
				}
				IL_2C3:
				if (damage.Dealer.SpecialEffects.OfType<DivineEffectEnhancementData>().Any<DivineEffectEnhancementData>())
				{
					enhance = damage.Dealer.SpecialEffects.OfType<DivineEffectEnhancementData>().First<DivineEffectEnhancementData>();
					if ((double)UnityEngine.Random.value <= enhance.Chance)
					{
						enumerator3 = damage.Target.ApplySkillEffect(new SealedEffect(new float?(6f), null, damage.Dealer), false).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
				}
				IL_3DD:
				if (enumerator.MoveNext())
				{
					effectiveDamage = enumerator.Current;
					AttributeType reductionType = effectiveDamage.Target.GetOutputAttributeType();
					reductionRate = 0.6;
					maxReductionRate = 0.35;
					string reductionKey = AttributeModificationEffect.DivineDamage_Proc;
					existingDivineReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
					reductionValue = effectiveDamage.TotalDamage * reductionRate;
					maxValue = effectiveDamage.Target.GetAttributeValue_Final(reductionType, AttributeRetrievalLevel.Gear) * maxReductionRate;
					total = reductionValue;
					if (existingDivineReduction != null)
					{
						double num2 = -(from a in existingDivineReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
						where a.AttributeType == reductionType
						select a).Sum((AttributeModifier a) => a.Value);
						total += num2;
					}
					if (total > maxValue)
					{
						total = maxValue;
					}
					if (total > 0.0)
					{
						enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateDivineDamageProc(damage.Dealer, -total, effectiveDamage.Target.GetOutputAttributeType()), false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
					goto IL_2C3;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700126A RID: 4714
		// (get) Token: 0x06005787 RID: 22407 RVA: 0x000F7BF0 File Offset: 0x000F5FF0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700126B RID: 4715
		// (get) Token: 0x06005788 RID: 22408 RVA: 0x000F7BF8 File Offset: 0x000F5FF8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005789 RID: 22409 RVA: 0x000F7C00 File Offset: 0x000F6000
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600578A RID: 22410 RVA: 0x000F7CE8 File Offset: 0x000F60E8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600578B RID: 22411 RVA: 0x000F7CEF File Offset: 0x000F60EF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600578C RID: 22412 RVA: 0x000F7CF8 File Offset: 0x000F60F8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<DivineElementProcess>c__Iterator6 <DivineElementProcess>c__Iterator = new DamageExtensions.<DivineElementProcess>c__Iterator6();
			<DivineElementProcess>c__Iterator.damage = damage;
			return <DivineElementProcess>c__Iterator;
		}

		// Token: 0x0600578D RID: 22413 RVA: 0x000F7D2C File Offset: 0x000F612C
		private static double <>m__0(AttributeModifier a)
		{
			return a.Value;
		}

		// Token: 0x04004716 RID: 18198
		internal BattleDamage damage;

		// Token: 0x04004717 RID: 18199
		internal List<DamageExtensions.EffectiveDamage> <effectiveDamages>__0;

		// Token: 0x04004718 RID: 18200
		internal List<DamageExtensions.EffectiveDamage>.Enumerator $locvar0;

		// Token: 0x04004719 RID: 18201
		internal DamageExtensions.EffectiveDamage <effectiveDamage>__1;

		// Token: 0x0400471A RID: 18202
		internal double <reductionRate>__2;

		// Token: 0x0400471B RID: 18203
		internal double <maxReductionRate>__2;

		// Token: 0x0400471C RID: 18204
		internal AttributeModificationEffect <existingDivineReduction>__2;

		// Token: 0x0400471D RID: 18205
		internal double <reductionValue>__2;

		// Token: 0x0400471E RID: 18206
		internal double <maxValue>__2;

		// Token: 0x0400471F RID: 18207
		internal double <total>__2;

		// Token: 0x04004720 RID: 18208
		internal IEnumerator $locvar1;

		// Token: 0x04004721 RID: 18209
		internal object <_>__3;

		// Token: 0x04004722 RID: 18210
		internal IDisposable $locvar2;

		// Token: 0x04004723 RID: 18211
		internal DivineEffectEnhancementData <enhance>__4;

		// Token: 0x04004724 RID: 18212
		internal IEnumerator $locvar3;

		// Token: 0x04004725 RID: 18213
		internal object <_>__5;

		// Token: 0x04004726 RID: 18214
		internal IDisposable $locvar4;

		// Token: 0x04004727 RID: 18215
		internal object $current;

		// Token: 0x04004728 RID: 18216
		internal bool $disposing;

		// Token: 0x04004729 RID: 18217
		internal int $PC;

		// Token: 0x0400472A RID: 18218
		private DamageExtensions.<DivineElementProcess>c__Iterator6.<DivineElementProcess>c__AnonStorey10 $locvar5;

		// Token: 0x0400472B RID: 18219
		private static Func<AttributeModifier, double> <>f__am$cache0;

		// Token: 0x02000D6D RID: 3437
		private sealed class <DivineElementProcess>c__AnonStorey10
		{
			// Token: 0x060057BB RID: 22459 RVA: 0x000F7D34 File Offset: 0x000F6134
			public <DivineElementProcess>c__AnonStorey10()
			{
			}

			// Token: 0x060057BC RID: 22460 RVA: 0x000F7D3C File Offset: 0x000F613C
			internal bool <>m__0(AttributeModificationEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.reductionKey;
			}

			// Token: 0x060057BD RID: 22461 RVA: 0x000F7D4F File Offset: 0x000F614F
			internal bool <>m__1(AttributeModifier a)
			{
				return a.AttributeType == this.reductionType;
			}

			// Token: 0x04004788 RID: 18312
			internal string reductionKey;

			// Token: 0x04004789 RID: 18313
			internal AttributeType reductionType;

			// Token: 0x0400478A RID: 18314
			internal DamageExtensions.<DivineElementProcess>c__Iterator6 <>f__ref$6;
		}
	}

	// Token: 0x02000D63 RID: 3427
	[CompilerGenerated]
	private sealed class <FireElementProcess>c__Iterator7 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600578E RID: 22414 RVA: 0x000F7D5F File Offset: 0x000F615F
		[DebuggerHidden]
		public <FireElementProcess>c__Iterator7()
		{
		}

		// Token: 0x0600578F RID: 22415 RVA: 0x000F7D68 File Offset: 0x000F6168
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Fire);
				fireSeedRate = 0.8;
				explosionDamages = new List<BattleDamage>();
				enumerator = effectiveDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			case 3u:
				goto IL_3C1;
			case 4u:
				goto IL_52A;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_13:
					try
					{
						switch (num)
						{
						case 1u:
							Block_19:
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
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							break;
						default:
							goto IL_22D;
						}
						IL_1E5:
						hits.Add(new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(target, dealer, OutputType.Fire, fireSeedEffect.DamgeValue)
						}, target, dealer, false, false));
						IL_22D:
						if (enumerator2.MoveNext())
						{
							fireSeedEffect = enumerator2.Current;
							if (!dealer.SpecialEffects.OfType<DemonicFireData>().Any<DemonicFireData>())
							{
								enumerator3 = target.LooseSkillEffect(fireSeedEffect, EffectWearsOffType.Expiration).GetEnumerator();
								num = 4294967293u;
								goto Block_19;
							}
							goto IL_1E5;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					if (hits.Any<DamageComponentValue>())
					{
						explosionDamages.Add(new BattleDamage(target, new FireSeedExplosionSource(dealer), hits));
					}
					enumerator4 = FireSeedEffect.AddFireSeed(effectiveDamage.Target, fireSeedRate * effectiveDamage.TotalDamage, damage.Dealer).GetEnumerator();
					num = 4294967293u;
					goto Block_15;
				case 2u:
					goto IL_2CA;
				}
				IL_34C:
				while (enumerator.MoveNext())
				{
					effectiveDamage = enumerator.Current;
					hits = new List<DamageComponentValue>();
					if (effectiveDamage.Target.Status == BattleUnitStatus.Active)
					{
						target = effectiveDamage.Target;
						dealer = damage.Dealer;
						fireSeeds = target.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>();
						enumerator2 = fireSeeds.GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
				}
				goto IL_377;
				Block_15:
				try
				{
					IL_2CA:
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
				goto IL_34C;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_377:
			if (!explosionDamages.Any<BattleDamage>())
			{
				goto IL_5AC;
			}
			releaseableExtraDamage = new ReleaseableDamage(explosionDamages, damage.DamageSource.SourceUnit);
			enumerator5 = releaseableExtraDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_3C1:
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
			if (!(damage.DamageSource is AdventureUnitSkill))
			{
				goto IL_5AC;
			}
			skill = (damage.DamageSource as AdventureUnitSkill);
			if (skill.Skill.SkillType != SkillType.FireBreath || !skill.GetActiveTalents().OfType<FirebreathDamageAbsorbTalent>().Any<FirebreathDamageAbsorbTalent>())
			{
				goto IL_5AC;
			}
			rate = FirebreathDamageAbsorbTalent.Rate;
			totalAbsorb = releaseableExtraDamage.BattleDamages.Sum((BattleDamage b) => b.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar())) * rate;
			if (totalAbsorb <= 0.0)
			{
				goto IL_5AC;
			}
			enumerator6 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(skill.SourceUnit, damage.DamageSource, totalAbsorb).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_52A:
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
			IL_5AC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700126C RID: 4716
		// (get) Token: 0x06005790 RID: 22416 RVA: 0x000F83C0 File Offset: 0x000F67C0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700126D RID: 4717
		// (get) Token: 0x06005791 RID: 22417 RVA: 0x000F83C8 File Offset: 0x000F67C8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005792 RID: 22418 RVA: 0x000F83D0 File Offset: 0x000F67D0
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
								if ((disposable = (enumerator3 as IDisposable)) != null)
								{
									disposable.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						break;
					case 2u:
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
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
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
			}
		}

		// Token: 0x06005793 RID: 22419 RVA: 0x000F8558 File Offset: 0x000F6958
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005794 RID: 22420 RVA: 0x000F855F File Offset: 0x000F695F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005795 RID: 22421 RVA: 0x000F8568 File Offset: 0x000F6968
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<FireElementProcess>c__Iterator7 <FireElementProcess>c__Iterator = new DamageExtensions.<FireElementProcess>c__Iterator7();
			<FireElementProcess>c__Iterator.damage = damage;
			return <FireElementProcess>c__Iterator;
		}

		// Token: 0x06005796 RID: 22422 RVA: 0x000F859C File Offset: 0x000F699C
		private static double <>m__0(BattleDamage b)
		{
			return b.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar());
		}

		// Token: 0x06005797 RID: 22423 RVA: 0x000F85C6 File Offset: 0x000F69C6
		private static double <>m__1(DamageComponent d)
		{
			return d.GetTotalDamageSoFar();
		}

		// Token: 0x0400472C RID: 18220
		internal BattleDamage damage;

		// Token: 0x0400472D RID: 18221
		internal List<DamageExtensions.EffectiveDamage> <effectiveDamages>__0;

		// Token: 0x0400472E RID: 18222
		internal double <fireSeedRate>__0;

		// Token: 0x0400472F RID: 18223
		internal List<BattleDamage> <explosionDamages>__0;

		// Token: 0x04004730 RID: 18224
		internal List<DamageExtensions.EffectiveDamage>.Enumerator $locvar0;

		// Token: 0x04004731 RID: 18225
		internal DamageExtensions.EffectiveDamage <effectiveDamage>__1;

		// Token: 0x04004732 RID: 18226
		internal List<DamageComponentValue> <hits>__2;

		// Token: 0x04004733 RID: 18227
		internal IBattleUnit <target>__3;

		// Token: 0x04004734 RID: 18228
		internal IBattleUnit <dealer>__3;

		// Token: 0x04004735 RID: 18229
		internal List<FireSeedEffect> <fireSeeds>__3;

		// Token: 0x04004736 RID: 18230
		internal List<FireSeedEffect>.Enumerator $locvar1;

		// Token: 0x04004737 RID: 18231
		internal FireSeedEffect <fireSeedEffect>__4;

		// Token: 0x04004738 RID: 18232
		internal IEnumerator $locvar2;

		// Token: 0x04004739 RID: 18233
		internal object <_>__5;

		// Token: 0x0400473A RID: 18234
		internal IDisposable $locvar3;

		// Token: 0x0400473B RID: 18235
		internal IEnumerator $locvar4;

		// Token: 0x0400473C RID: 18236
		internal object <_>__6;

		// Token: 0x0400473D RID: 18237
		internal IDisposable $locvar5;

		// Token: 0x0400473E RID: 18238
		internal ReleaseableDamage <releaseableExtraDamage>__7;

		// Token: 0x0400473F RID: 18239
		internal IEnumerator $locvar6;

		// Token: 0x04004740 RID: 18240
		internal object <_>__8;

		// Token: 0x04004741 RID: 18241
		internal IDisposable $locvar7;

		// Token: 0x04004742 RID: 18242
		internal AdventureUnitSkill <skill>__9;

		// Token: 0x04004743 RID: 18243
		internal double <rate>__10;

		// Token: 0x04004744 RID: 18244
		internal double <totalAbsorb>__10;

		// Token: 0x04004745 RID: 18245
		internal IEnumerator $locvar8;

		// Token: 0x04004746 RID: 18246
		internal object <_>__11;

		// Token: 0x04004747 RID: 18247
		internal IDisposable $locvar9;

		// Token: 0x04004748 RID: 18248
		internal object $current;

		// Token: 0x04004749 RID: 18249
		internal bool $disposing;

		// Token: 0x0400474A RID: 18250
		internal int $PC;

		// Token: 0x0400474B RID: 18251
		private static Func<BattleDamage, double> <>f__am$cache0;

		// Token: 0x0400474C RID: 18252
		private static Func<DamageComponent, double> <>f__am$cache1;
	}

	// Token: 0x02000D64 RID: 3428
	[CompilerGenerated]
	private sealed class <TriggerFireSeeds>c__Iterator8 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005798 RID: 22424 RVA: 0x000F85CE File Offset: 0x000F69CE
		[DebuggerHidden]
		public <TriggerFireSeeds>c__Iterator8()
		{
		}

		// Token: 0x06005799 RID: 22425 RVA: 0x000F85D8 File Offset: 0x000F69D8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				explosionDamages = new List<BattleDamage>();
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_2A6;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_7:
					try
					{
						switch (num)
						{
						case 1u:
							Block_12:
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
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							break;
						default:
							goto IL_1D9;
						}
						IL_191:
						hits.Add(new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(target, dealer, OutputType.Fire, fireSeedEffect.DamgeValue)
						}, target, dealer, false, false));
						IL_1D9:
						if (enumerator2.MoveNext())
						{
							fireSeedEffect = enumerator2.Current;
							if (!dealer.SpecialEffects.OfType<DemonicFireData>().Any<DemonicFireData>())
							{
								enumerator3 = target.LooseSkillEffect(fireSeedEffect, EffectWearsOffType.Expiration).GetEnumerator();
								num = 4294967293u;
								goto Block_12;
							}
							goto IL_191;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					if (hits.Any<DamageComponentValue>())
					{
						explosionDamages.Add(new BattleDamage(target, new FireSeedExplosionSource(dealer), hits));
					}
					break;
				}
				while (enumerator.MoveNext())
				{
					target = enumerator.Current;
					hits = new List<DamageComponentValue>();
					if (target.Status == BattleUnitStatus.Active)
					{
						fireSeeds = target.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>();
						enumerator2 = fireSeeds.GetEnumerator();
						num = 4294967293u;
						goto Block_7;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			if (!explosionDamages.Any<BattleDamage>())
			{
				goto IL_328;
			}
			releaseableExtraDamage = new ReleaseableDamage(explosionDamages, dealer);
			enumerator4 = releaseableExtraDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2A6:
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
			IL_328:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700126E RID: 4718
		// (get) Token: 0x0600579A RID: 22426 RVA: 0x000F897C File Offset: 0x000F6D7C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700126F RID: 4719
		// (get) Token: 0x0600579B RID: 22427 RVA: 0x000F8984 File Offset: 0x000F6D84
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600579C RID: 22428 RVA: 0x000F898C File Offset: 0x000F6D8C
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
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
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
				}
				finally
				{
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600579D RID: 22429 RVA: 0x000F8A80 File Offset: 0x000F6E80
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600579E RID: 22430 RVA: 0x000F8A87 File Offset: 0x000F6E87
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600579F RID: 22431 RVA: 0x000F8A90 File Offset: 0x000F6E90
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<TriggerFireSeeds>c__Iterator8 <TriggerFireSeeds>c__Iterator = new DamageExtensions.<TriggerFireSeeds>c__Iterator8();
			<TriggerFireSeeds>c__Iterator.targets = targets;
			<TriggerFireSeeds>c__Iterator.dealer = dealer;
			return <TriggerFireSeeds>c__Iterator;
		}

		// Token: 0x0400474D RID: 18253
		internal List<BattleDamage> <explosionDamages>__0;

		// Token: 0x0400474E RID: 18254
		internal List<IBattleUnit> targets;

		// Token: 0x0400474F RID: 18255
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004750 RID: 18256
		internal IBattleUnit <target>__1;

		// Token: 0x04004751 RID: 18257
		internal List<DamageComponentValue> <hits>__2;

		// Token: 0x04004752 RID: 18258
		internal List<FireSeedEffect> <fireSeeds>__3;

		// Token: 0x04004753 RID: 18259
		internal List<FireSeedEffect>.Enumerator $locvar1;

		// Token: 0x04004754 RID: 18260
		internal FireSeedEffect <fireSeedEffect>__4;

		// Token: 0x04004755 RID: 18261
		internal IBattleUnit dealer;

		// Token: 0x04004756 RID: 18262
		internal IEnumerator $locvar2;

		// Token: 0x04004757 RID: 18263
		internal object <_>__5;

		// Token: 0x04004758 RID: 18264
		internal IDisposable $locvar3;

		// Token: 0x04004759 RID: 18265
		internal ReleaseableDamage <releaseableExtraDamage>__6;

		// Token: 0x0400475A RID: 18266
		internal IEnumerator $locvar4;

		// Token: 0x0400475B RID: 18267
		internal object <_>__7;

		// Token: 0x0400475C RID: 18268
		internal IDisposable $locvar5;

		// Token: 0x0400475D RID: 18269
		internal object $current;

		// Token: 0x0400475E RID: 18270
		internal bool $disposing;

		// Token: 0x0400475F RID: 18271
		internal int $PC;
	}

	// Token: 0x02000D65 RID: 3429
	[CompilerGenerated]
	private sealed class <PoisonElementProcess>c__Iterator9 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060057A0 RID: 22432 RVA: 0x000F8AD0 File Offset: 0x000F6ED0
		[DebuggerHidden]
		public <PoisonElementProcess>c__Iterator9()
		{
		}

		// Token: 0x060057A1 RID: 22433 RVA: 0x000F8AD8 File Offset: 0x000F6ED8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectiveDamages = DamageExtensions.GetEffectiveDamage(damage, OutputType.Poison);
				enumerator = effectiveDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
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
				case 2u:
					Block_10:
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
					goto IL_3B7;
				default:
					goto IL_3B7;
				}
				IL_2A5:
				damageRate = 0.2 + damage.Dealer.SpecialEffects.OfType<PoisonEffectEnhancementData>().Sum((PoisonEffectEnhancementData p) => p.ExtraRate);
				damageValue = effectiveDamage.TotalDamage * damageRate;
				enumerator3 = DamageOverTimeEffect.AddDamageOverSecond(effectiveDamage.Target, damage.Dealer, damageValue, 3, OutputType.Poison).GetEnumerator();
				num = 4294967293u;
				goto Block_10;
				IL_3B7:
				if (enumerator.MoveNext())
				{
					effectiveDamage = enumerator.Current;
					AttributeType reductionType = AttributeType.ReceivedHealEffectivenessChangeRate;
					reductionRate = 0.5;
					maxReductionRate = 0.5;
					string reductionKey = AttributeModificationEffect.PoisonDamage_Proc;
					effectivenessRate = 0.5;
					existingArmorReduction = effectiveDamage.Target.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect ef) => ef.EffectSourceIdentityCode == reductionKey);
					reductionValue = DamageExtensions.GetElementalEffectEffectiveness(effectiveDamage.TotalDamage, damage.Dealer) * effectivenessRate * reductionRate;
					total = reductionValue;
					if (existingArmorReduction != null)
					{
						double num2 = -(from a in existingArmorReduction.GetAdditionalModifiers(effectiveDamage.Target, effectiveDamage.Target.CurrentEncounter)
						where a.AttributeType == reductionType
						select a).Sum((AttributeModifier a) => a.Value);
						total += num2;
					}
					if (total > maxReductionRate)
					{
						total = maxReductionRate;
					}
					if (total > 0.0)
					{
						enumerator2 = effectiveDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreatePoisonDamageProc(damage.Dealer, -total), false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
					goto IL_2A5;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001270 RID: 4720
		// (get) Token: 0x060057A2 RID: 22434 RVA: 0x000F8F20 File Offset: 0x000F7320
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001271 RID: 4721
		// (get) Token: 0x060057A3 RID: 22435 RVA: 0x000F8F28 File Offset: 0x000F7328
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060057A4 RID: 22436 RVA: 0x000F8F30 File Offset: 0x000F7330
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060057A5 RID: 22437 RVA: 0x000F9018 File Offset: 0x000F7418
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060057A6 RID: 22438 RVA: 0x000F901F File Offset: 0x000F741F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060057A7 RID: 22439 RVA: 0x000F9028 File Offset: 0x000F7428
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageExtensions.<PoisonElementProcess>c__Iterator9 <PoisonElementProcess>c__Iterator = new DamageExtensions.<PoisonElementProcess>c__Iterator9();
			<PoisonElementProcess>c__Iterator.damage = damage;
			return <PoisonElementProcess>c__Iterator;
		}

		// Token: 0x060057A8 RID: 22440 RVA: 0x000F905C File Offset: 0x000F745C
		private static double <>m__0(AttributeModifier a)
		{
			return a.Value;
		}

		// Token: 0x060057A9 RID: 22441 RVA: 0x000F9064 File Offset: 0x000F7464
		private static double <>m__1(PoisonEffectEnhancementData p)
		{
			return p.ExtraRate;
		}

		// Token: 0x04004760 RID: 18272
		internal BattleDamage damage;

		// Token: 0x04004761 RID: 18273
		internal List<DamageExtensions.EffectiveDamage> <effectiveDamages>__0;

		// Token: 0x04004762 RID: 18274
		internal List<DamageExtensions.EffectiveDamage>.Enumerator $locvar0;

		// Token: 0x04004763 RID: 18275
		internal DamageExtensions.EffectiveDamage <effectiveDamage>__1;

		// Token: 0x04004764 RID: 18276
		internal double <reductionRate>__2;

		// Token: 0x04004765 RID: 18277
		internal double <maxReductionRate>__2;

		// Token: 0x04004766 RID: 18278
		internal double <effectivenessRate>__2;

		// Token: 0x04004767 RID: 18279
		internal AttributeModificationEffect <existingArmorReduction>__2;

		// Token: 0x04004768 RID: 18280
		internal double <reductionValue>__2;

		// Token: 0x04004769 RID: 18281
		internal double <total>__2;

		// Token: 0x0400476A RID: 18282
		internal IEnumerator $locvar1;

		// Token: 0x0400476B RID: 18283
		internal object <_>__3;

		// Token: 0x0400476C RID: 18284
		internal IDisposable $locvar2;

		// Token: 0x0400476D RID: 18285
		internal double <damageRate>__2;

		// Token: 0x0400476E RID: 18286
		internal double <damageValue>__2;

		// Token: 0x0400476F RID: 18287
		internal IEnumerator $locvar3;

		// Token: 0x04004770 RID: 18288
		internal object <_>__4;

		// Token: 0x04004771 RID: 18289
		internal IDisposable $locvar4;

		// Token: 0x04004772 RID: 18290
		internal object $current;

		// Token: 0x04004773 RID: 18291
		internal bool $disposing;

		// Token: 0x04004774 RID: 18292
		internal int $PC;

		// Token: 0x04004775 RID: 18293
		private DamageExtensions.<PoisonElementProcess>c__Iterator9.<PoisonElementProcess>c__AnonStorey11 $locvar5;

		// Token: 0x04004776 RID: 18294
		private static Func<AttributeModifier, double> <>f__am$cache0;

		// Token: 0x04004777 RID: 18295
		private static Func<PoisonEffectEnhancementData, double> <>f__am$cache1;

		// Token: 0x02000D6E RID: 3438
		private sealed class <PoisonElementProcess>c__AnonStorey11
		{
			// Token: 0x060057BE RID: 22462 RVA: 0x000F906C File Offset: 0x000F746C
			public <PoisonElementProcess>c__AnonStorey11()
			{
			}

			// Token: 0x060057BF RID: 22463 RVA: 0x000F9074 File Offset: 0x000F7474
			internal bool <>m__0(AttributeModificationEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.reductionKey;
			}

			// Token: 0x060057C0 RID: 22464 RVA: 0x000F9087 File Offset: 0x000F7487
			internal bool <>m__1(AttributeModifier a)
			{
				return a.AttributeType == this.reductionType;
			}

			// Token: 0x0400478B RID: 18315
			internal string reductionKey;

			// Token: 0x0400478C RID: 18316
			internal AttributeType reductionType;

			// Token: 0x0400478D RID: 18317
			internal DamageExtensions.<PoisonElementProcess>c__Iterator9 <>f__ref$9;
		}
	}

	// Token: 0x02000D66 RID: 3430
	[CompilerGenerated]
	private sealed class <GetEffectiveDamage>c__AnonStorey12
	{
		// Token: 0x060057AA RID: 22442 RVA: 0x000F9097 File Offset: 0x000F7497
		public <GetEffectiveDamage>c__AnonStorey12()
		{
		}

		// Token: 0x060057AB RID: 22443 RVA: 0x000F90A0 File Offset: 0x000F74A0
		internal DamageExtensions.EffectiveDamage <>m__0(IGrouping<IBattleUnit, DamageComponent> g)
		{
			return new DamageExtensions.EffectiveDamage
			{
				Target = g.Key,
				TotalDamage = g.Sum((DamageComponent d) => d.GetElementalTotal_WithoutNeutralization(this.outputType))
			};
		}

		// Token: 0x060057AC RID: 22444 RVA: 0x000F90D8 File Offset: 0x000F74D8
		internal double <>m__1(DamageComponent d)
		{
			return d.GetElementalTotal_WithoutNeutralization(this.outputType);
		}

		// Token: 0x04004778 RID: 18296
		internal OutputType outputType;
	}
}
