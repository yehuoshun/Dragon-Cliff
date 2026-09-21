using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000747 RID: 1863
public class DamageOverTimeEffect : BattleEffectBase, IDamageInstantlyReleaseable, ISpreadableDamageOverTime
{
	// Token: 0x06003537 RID: 13623 RVA: 0x0016188C File Offset: 0x0015FC8C
	private DamageOverTimeEffect()
	{
	}

	// Token: 0x06003538 RID: 13624 RVA: 0x00161894 File Offset: 0x0015FC94
	private static double GetDoTCritRatio(IBattleUnit dealer, IBattleUnit target)
	{
		double num = dealer.CritRate(AttributeRetrievalLevel.Skill);
		double num2 = dealer.GetAttributeValue_Final(AttributeType.CritDamage, AttributeRetrievalLevel.Skill);
		double critDamageReductionRate = target.GetCritDamageReductionRate(dealer, AttributeRetrievalLevel.Skill);
		num2 *= 1.0 - critDamageReductionRate;
		return 1.0 + num * num2;
	}

	// Token: 0x06003539 RID: 13625 RVA: 0x001618D8 File Offset: 0x0015FCD8
	public static IEnumerable AddDamageOverTurn(IBattleUnit target, IBattleEffectSource effectSource, double rawDamageValue, int numberOfTurns, OutputType damageType)
	{
		if (rawDamageValue > 0.0 && numberOfTurns > 0)
		{
			DamageOverTimeEffect existingTurn = target.BattleEffects.OfType<DamageOverTimeEffect>().FirstOrDefault((DamageOverTimeEffect ef) => ef.BattleEffectType == BattleEffectType.TurnDamage && ef._effectSourceIdentityCode == "damageperturn" + damageType);
			if (existingTurn != null)
			{
				if (!effectSource.SourceUnit.EffectApplySucceeded(target))
				{
					IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new DamageOverTimeEffect
					{
						_effectSource = effectSource,
						_effectSourceIdentityCode = "damageperturn" + damageType,
						Damage = 0.0,
						EffectWearer = target,
						_maxNumberOfLastingSeconds = null,
						_style = EffectOverTimeStyle.PerTurn,
						_maxStackableInstances = new int?(1),
						TurnEventsCollected = new List<AdventureEventType>(),
						Description = BattleEffectType.TurnDamage.GetDescription(),
						_battleEffectType = BattleEffectType.TurnDamage,
						_numberOfLastingTurns = new int?(numberOfTurns),
						_canBeDispersed = true,
						_canBeImmuned = true,
						_isThroughEffect = false,
						_damageType = damageType
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
				else
				{
					double num = (double)numberOfTurns * effectSource.SourceUnit.GetEffectTimeRatio(target);
					double num2 = 1.0 - target.SpecialEffects.OfType<NegativeEffectSpeedupData>().Sum((NegativeEffectSpeedupData n) => n.DecreaseRate);
					if (num2 < 0.0)
					{
						num2 = 0.0;
					}
					num *= num2;
					if (num < 1.0)
					{
						num = 1.0;
					}
					double num3 = rawDamageValue * Convert.ToDouble(num) * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
					int? num4 = existingTurn.NumberOfRemainingTurns();
					int? remainingSeconds = existingTurn.GetRemainingSeconds();
					int num5 = 10000;
					int num6 = (existingTurn._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds == null) ? num5 : remainingSeconds.Value) : ((num4 == null) ? num5 : num4.Value);
					double num7 = (double)num6 * existingTurn.Damage;
					double num8 = num3 + num7;
					existingTurn._numberOfLastingTurns = new int?((num < (double)num6) ? num6 : ((int)num));
					if (existingTurn._numberOfLastingTurns <= 1)
					{
						existingTurn._numberOfLastingTurns = new int?(1);
					}
					double damage2 = num8 / Convert.ToDouble(existingTurn._numberOfLastingTurns);
					existingTurn.Damage = damage2;
					existingTurn.TurnEventsCollected = new List<AdventureEventType>();
					Description description2 = BattleEffectType.TurnDamage.GetDescription();
					description2.Details1 = description2.Details1.Replace("{damage}", existingTurn.Damage.ToExpression());
					existingTurn.Description = description2;
				}
			}
			else
			{
				double damage = rawDamageValue * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
				Description description = BattleEffectType.TurnDamage.GetDescription();
				description.Details1 = description.Details1.Replace("{damage}", damage.ToExpression());
				DamageOverTimeEffect effect = new DamageOverTimeEffect
				{
					_effectSource = effectSource,
					_effectSourceIdentityCode = "damageperturn" + damageType,
					Damage = damage,
					EffectWearer = target,
					_maxNumberOfLastingSeconds = null,
					_style = EffectOverTimeStyle.PerTurn,
					_maxStackableInstances = new int?(1),
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = description,
					_battleEffectType = BattleEffectType.TurnDamage,
					_numberOfLastingTurns = new int?(numberOfTurns),
					_canBeDispersed = true,
					_canBeImmuned = true,
					_isThroughEffect = false,
					_damageType = damageType
				};
				IEnumerator enumerator2 = target.ApplySkillEffect(effect, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600353A RID: 13626 RVA: 0x00161918 File Offset: 0x0015FD18
	public static IEnumerable AddDamageOverSecond(IBattleUnit target, IBattleEffectSource effectSource, double rawDamage, int numberOfSeconds, OutputType damageType)
	{
		if (rawDamage > 0.0 && numberOfSeconds > 0)
		{
			DamageOverTimeEffect existingDoT = target.BattleEffects.OfType<DamageOverTimeEffect>().FirstOrDefault((DamageOverTimeEffect ef) => ef.BattleEffectType == BattleEffectType.DamagePerSecond && ef._effectSourceIdentityCode == "damagepersec" + damageType);
			if (existingDoT != null)
			{
				if (!effectSource.SourceUnit.EffectApplySucceeded(target))
				{
					IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new DamageOverTimeEffect
					{
						_effectSource = effectSource,
						_effectSourceIdentityCode = "damagepersec" + damageType,
						Damage = 0.0,
						EffectWearer = target,
						_maxNumberOfLastingSeconds = new float?((float)numberOfSeconds),
						_style = EffectOverTimeStyle.PerSecond,
						_maxStackableInstances = new int?(1),
						TurnEventsCollected = new List<AdventureEventType>(),
						Description = BattleEffectType.DamagePerSecond.GetDescription(),
						_battleEffectType = BattleEffectType.DamagePerSecond,
						_numberOfLastingTurns = null,
						_canBeDispersed = true,
						_canBeImmuned = true,
						_isThroughEffect = false,
						_damageType = damageType
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
				else
				{
					double num = Convert.ToDouble(numberOfSeconds) * effectSource.SourceUnit.GetEffectTimeRatio(target);
					double num2 = 1.0 - target.SpecialEffects.OfType<NegativeEffectSpeedupData>().Sum((NegativeEffectSpeedupData n) => n.DecreaseRate);
					if (num2 < 0.0)
					{
						num2 = 0.0;
					}
					num *= num2;
					double num3 = rawDamage * Convert.ToDouble(num) * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
					int? num4 = existingDoT.NumberOfRemainingTurns();
					int? remainingSeconds = existingDoT.GetRemainingSeconds();
					int num5 = 100;
					int num6 = (existingDoT._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds == null) ? num5 : remainingSeconds.Value) : ((num4 == null) ? num5 : num4.Value);
					double num7 = (double)num6 * existingDoT.Damage;
					double num8 = num3 + num7;
					existingDoT._maxNumberOfLastingSeconds = new float?((float)((num < (double)num6) ? num6 : ((int)num)));
					if (existingDoT._maxNumberOfLastingSeconds <= 1f)
					{
						existingDoT._maxNumberOfLastingSeconds = new float?(1f);
					}
					double damage2 = num8 / Convert.ToDouble(existingDoT._maxNumberOfLastingSeconds);
					existingDoT.Damage = damage2;
					existingDoT.Timer = 0f;
					Description description2 = BattleEffectType.DamagePerSecond.GetDescription();
					description2.Details1 = description2.Details1.Replace("{damage}", existingDoT.Damage.ToExpression());
					existingDoT.Description = description2;
				}
			}
			else
			{
				double damage = rawDamage * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
				Description description = BattleEffectType.DamagePerSecond.GetDescription();
				description.Details1 = description.Details1.Replace("{damage}", damage.ToExpression());
				DamageOverTimeEffect effect = new DamageOverTimeEffect
				{
					_effectSource = effectSource,
					_effectSourceIdentityCode = "damagepersec" + damageType,
					Damage = damage,
					EffectWearer = target,
					_maxNumberOfLastingSeconds = new float?((float)numberOfSeconds),
					_style = EffectOverTimeStyle.PerSecond,
					_maxStackableInstances = new int?(1),
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = description,
					_battleEffectType = BattleEffectType.DamagePerSecond,
					_numberOfLastingTurns = null,
					_canBeDispersed = true,
					_canBeImmuned = true,
					_isThroughEffect = false,
					_damageType = damageType
				};
				IEnumerator enumerator2 = target.ApplySkillEffect(effect, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600353B RID: 13627 RVA: 0x00161958 File Offset: 0x0015FD58
	public static DamageOverTimeEffect CreateDarknessRevengeEffect(double rawDamage, IBattleEffectSource effectSource, IBattleUnit effectCarrier)
	{
		Description description = BattleEffectType.DarknessRevenge.GetDescription();
		return new DamageOverTimeEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = DamageOverTimeEffect.DarknessRevengeEffectKey,
			Damage = rawDamage,
			EffectWearer = effectCarrier,
			_maxNumberOfLastingSeconds = null,
			_style = EffectOverTimeStyle.PerSecond,
			_maxStackableInstances = new int?(3),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description,
			_battleEffectType = BattleEffectType.DamagePerSecond,
			_numberOfLastingTurns = null,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = true,
			_damageType = OutputType.Shadow
		};
	}

	// Token: 0x170008D7 RID: 2263
	// (get) Token: 0x0600353C RID: 13628 RVA: 0x001619FB File Offset: 0x0015FDFB
	// (set) Token: 0x0600353D RID: 13629 RVA: 0x00161A03 File Offset: 0x0015FE03
	public double Damage
	{
		[CompilerGenerated]
		get
		{
			return this.<Damage>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Damage>k__BackingField = value;
		}
	}

	// Token: 0x170008D8 RID: 2264
	// (get) Token: 0x0600353E RID: 13630 RVA: 0x00161A0C File Offset: 0x0015FE0C
	// (set) Token: 0x0600353F RID: 13631 RVA: 0x00161A14 File Offset: 0x0015FE14
	public IBattleUnit EffectWearer
	{
		[CompilerGenerated]
		get
		{
			return this.<EffectWearer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EffectWearer>k__BackingField = value;
		}
	}

	// Token: 0x06003540 RID: 13632 RVA: 0x00161A20 File Offset: 0x0015FE20
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitEntersTurn && eventType == AdventureEventType.UnitEntersTurn && eventTriggerUnit == listener && eventTriggerUnit == this.EffectWearer && this.EffectWearer.Status == BattleUnitStatus.Active && this._style == EffectOverTimeStyle.PerTurn)
		{
			ReleaseableDamage damage = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(this.EffectWearer, this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(this.EffectWearer, this.EffectSource.SourceUnit, (this.BattleEffectType == BattleEffectType.DarknessRevenge) ? OutputType.Shadow : OutputType.RealDamage, this.Damage)
					}, this.EffectWearer, this.EffectSource.SourceUnit, false, false)
				})
			}, this.EffectSource.SourceUnit);
			IEnumerator enumerator = damage.Release().GetEnumerator();
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
			IEnumerator enumerator2 = this.Triggered(this.EffectWearer).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06003541 RID: 13633 RVA: 0x00161A58 File Offset: 0x0015FE58
	public static IEnumerable PerSecondLogic_ActiveUnit_Batch(Dictionary<IBattleUnit, List<BattleEffectBase>> perWearerDots)
	{
		Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamages = new Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>();
		Dictionary<IBattleUnit, List<BattleHeal>> heals = new Dictionary<IBattleUnit, List<BattleHeal>>();
		if (perWearerDots.Any<KeyValuePair<IBattleUnit, List<BattleEffectBase>>>())
		{
			using (Dictionary<IBattleUnit, List<BattleEffectBase>>.Enumerator enumerator = perWearerDots.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<IBattleUnit, List<BattleEffectBase>> dot = enumerator.Current;
					List<BattleEffectBase> effects = dot.Value;
					if (effects.Any<BattleEffectBase>())
					{
						foreach (BattleEffectBase damageOverTimeEffect in effects)
						{
							if (damageOverTimeEffect is DamageOverTimeEffect)
							{
								DamageOverTimeEffect damageOverTimeEffect2 = damageOverTimeEffect as DamageOverTimeEffect;
								if (damageOverTimeEffect2._style == EffectOverTimeStyle.PerSecond && dot.Key == damageOverTimeEffect2.EffectWearer && dot.Key.IsAliveInBattle())
								{
									if (!battleDamages.ContainsKey(damageOverTimeEffect2.SourceUnit))
									{
										battleDamages.Add(damageOverTimeEffect2.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
									}
									if (!battleDamages[damageOverTimeEffect2.SourceUnit].ContainsKey(dot.Key))
									{
										battleDamages[damageOverTimeEffect2.SourceUnit].Add(dot.Key, new List<DamagePotionValue>());
									}
									battleDamages[damageOverTimeEffect2.SourceUnit][dot.Key].Add(DamagePotionValue.CreateRawValuedDamageComponent(dot.Key, damageOverTimeEffect.SourceUnit, damageOverTimeEffect2._damageType, damageOverTimeEffect2.Damage));
								}
							}
							if (damageOverTimeEffect is LifeExtractionEffect)
							{
								LifeExtractionEffect ef2 = damageOverTimeEffect as LifeExtractionEffect;
								if (ef2._style == EffectOverTimeStyle.PerSecond && dot.Key == ef2._effectCarrier && dot.Key.IsAliveInBattle())
								{
									int second = (int)ef2.Timer;
									if (ef2.EffectSource.SourceUnit.SpecialEffects.OfType<ShadowEffectEnhancementData>().Any<ShadowEffectEnhancementData>() && second > 0 && second % 2 == 0)
									{
										int additionaTargets = ef2.EffectSource.SourceUnit.SpecialEffects.OfType<ShadowEffectEnhancementData>().First<ShadowEffectEnhancementData>().AdditionalTargets;
										List<IBattleUnit> targets = (from e in dot.Key.GetAllLiveFriendlyTargetsIncSelf(false)
										where e != dot.Key
										select e).Take(additionaTargets).ToList<IBattleUnit>();
										foreach (IBattleUnit battleUnit in targets)
										{
											IEnumerator enumerator4 = battleUnit.ApplySkillEffect(LifeExtractionEffect.CreateShadowProcEffect(ef2.EffectSource, ef2.DamageRawPerTick, ef2.HealPercentageOfDamagePerTick, battleUnit, 3f, "autospreaded"), false).GetEnumerator();
											try
											{
												while (enumerator4.MoveNext())
												{
													object _ = enumerator4.Current;
													yield return _;
												}
											}
											finally
											{
												IDisposable disposable;
												if ((disposable = (enumerator4 as IDisposable)) != null)
												{
													disposable.Dispose();
												}
											}
										}
									}
									if (!battleDamages.ContainsKey(ef2.SourceUnit))
									{
										battleDamages.Add(ef2.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
									}
									if (!battleDamages[ef2.SourceUnit].ContainsKey(dot.Key))
									{
										battleDamages[ef2.SourceUnit].Add(dot.Key, new List<DamagePotionValue>());
									}
									battleDamages[ef2.SourceUnit][dot.Key].Add(DamagePotionValue.CreateRawValuedDamageComponent(ef2._effectCarrier, ef2.EffectCausedCaster.SourceUnit, ef2._damageType, ef2.DamageRawPerTick));
									if (!heals.ContainsKey(ef2.EffectCausedCaster))
									{
										heals.Add(ef2.EffectCausedCaster, new List<BattleHeal>());
									}
									heals[ef2.EffectCausedCaster].Add(new BattleHeal(ef2.EffectCausedCaster, ef2, new List<HealComponentValue>
									{
										new HealComponentValue
										{
											RawHeal = ef2.HealPercentageOfDamagePerTick * ef2.DamageRawPerTick,
											IsDirectHeal = false,
											HealType = OutputType.RealHeal
										}
									}, false));
								}
							}
							if (damageOverTimeEffect is ShieldBurnEffect)
							{
								ShieldBurnEffect ef = damageOverTimeEffect as ShieldBurnEffect;
								if (!battleDamages.ContainsKey(ef.SourceUnit))
								{
									battleDamages.Add(ef.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
								}
								if (!battleDamages[ef.SourceUnit].ContainsKey(dot.Key))
								{
									battleDamages[ef.SourceUnit].Add(dot.Key, new List<DamagePotionValue>());
								}
								battleDamages[ef.SourceUnit][dot.Key].AddRange(ef._hits.SelectMany((DamageHitDefinition h) => h.Potions.Select(delegate(DamageHitModuleDefinition p)
								{
									IBattleUnit sourceUnit = ef.EffectSource.SourceUnit;
									IBattleUnit effectCarrier = ef._effectCarrier;
									OutputType? outputType = p.OutputType;
									return new DamagePotionValue(sourceUnit, effectCarrier, (outputType == null) ? ef.EffectSource.SourceUnit.GetOutputType() : outputType.Value, p.DamageRate);
								})));
							}
						}
					}
					IEnumerator enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(dot.Key, AdventureEventType.DamagePerSecondTrigger, dot.Value)).GetEnumerator();
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
			using (Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>.Enumerator enumerator6 = battleDamages.GetEnumerator())
			{
				while (enumerator6.MoveNext())
				{
					KeyValuePair<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamage = enumerator6.Current;
					List<BattleDamage> bds = (from b in battleDamage.Value
					select new BattleDamage(b.Key, new DamageOverTimeTickSource(battleDamage.Key), new List<DamageComponentValue>
					{
						new DamageComponentValue(b.Value, b.Key, battleDamage.Key, false, false)
					})).ToList<BattleDamage>();
					IEnumerator enumerator7 = new ReleaseableDamage(bds, battleDamage.Key).Release().GetEnumerator();
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
			}
			if (heals.Any<KeyValuePair<IBattleUnit, List<BattleHeal>>>())
			{
				foreach (KeyValuePair<IBattleUnit, List<BattleHeal>> heal in heals)
				{
					IEnumerator enumerator9 = new ReleaseableHeal(heal.Value, heal.Key).Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x170008D9 RID: 2265
	// (get) Token: 0x06003542 RID: 13634 RVA: 0x00161A7B File Offset: 0x0015FE7B
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170008DA RID: 2266
	// (get) Token: 0x06003543 RID: 13635 RVA: 0x00161A83 File Offset: 0x0015FE83
	// (set) Token: 0x06003544 RID: 13636 RVA: 0x00161A8B File Offset: 0x0015FE8B
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this._numberOfLastingTurns;
		}
		set
		{
			this._numberOfLastingTurns = value;
		}
	}

	// Token: 0x170008DB RID: 2267
	// (get) Token: 0x06003545 RID: 13637 RVA: 0x00161A94 File Offset: 0x0015FE94
	public List<AttributeModifier> AdditionalModifiers
	{
		get
		{
			return new List<AttributeModifier>();
		}
	}

	// Token: 0x170008DC RID: 2268
	// (get) Token: 0x06003546 RID: 13638 RVA: 0x00161A9B File Offset: 0x0015FE9B
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170008DD RID: 2269
	// (get) Token: 0x06003547 RID: 13639 RVA: 0x00161AA3 File Offset: 0x0015FEA3
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170008DE RID: 2270
	// (get) Token: 0x06003548 RID: 13640 RVA: 0x00161AAB File Offset: 0x0015FEAB
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170008DF RID: 2271
	// (get) Token: 0x06003549 RID: 13641 RVA: 0x00161AB3 File Offset: 0x0015FEB3
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x0600354A RID: 13642 RVA: 0x00161AB6 File Offset: 0x0015FEB6
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this.AdditionalModifiers;
	}

	// Token: 0x170008E0 RID: 2272
	// (get) Token: 0x0600354B RID: 13643 RVA: 0x00161ABE File Offset: 0x0015FEBE
	// (set) Token: 0x0600354C RID: 13644 RVA: 0x00161AC6 File Offset: 0x0015FEC6
	public override bool CanBeDispersed
	{
		get
		{
			return this._canBeDispersed;
		}
		set
		{
			this._canBeDispersed = value;
		}
	}

	// Token: 0x0600354D RID: 13645 RVA: 0x00161AD0 File Offset: 0x0015FED0
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitEntersTurn
		};
	}

	// Token: 0x170008E1 RID: 2273
	// (get) Token: 0x0600354E RID: 13646 RVA: 0x00161AEB File Offset: 0x0015FEEB
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008E2 RID: 2274
	// (get) Token: 0x0600354F RID: 13647 RVA: 0x00161AF3 File Offset: 0x0015FEF3
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170008E3 RID: 2275
	// (get) Token: 0x06003550 RID: 13648 RVA: 0x00161AFB File Offset: 0x0015FEFB
	// (set) Token: 0x06003551 RID: 13649 RVA: 0x00161B03 File Offset: 0x0015FF03
	public override float? MaxNumberOfLastingSeconds
	{
		get
		{
			return this._maxNumberOfLastingSeconds;
		}
		set
		{
			this._maxNumberOfLastingSeconds = value;
		}
	}

	// Token: 0x06003552 RID: 13650 RVA: 0x00161B0C File Offset: 0x0015FF0C
	public static IEnumerable InstantRun_Batch(Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>> effectsPerWearer, double rate = 1.0, double max = 30.0)
	{
		Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamages = new Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>();
		int maxTicks = 100;
		double maxRate = max;
		Dictionary<IBattleUnit, List<BattleHeal>> heals = new Dictionary<IBattleUnit, List<BattleHeal>>();
		foreach (KeyValuePair<IBattleUnit, List<IDamageInstantlyReleaseable>> perwearer in effectsPerWearer)
		{
			foreach (IDamageInstantlyReleaseable damageInstantlyReleaseable in perwearer.Value)
			{
				if (damageInstantlyReleaseable is DamageOverTimeEffect)
				{
					DamageOverTimeEffect damageOverTimeEffect = damageInstantlyReleaseable as DamageOverTimeEffect;
					int? num = damageOverTimeEffect.NumberOfRemainingTurns();
					int? remainingSeconds = damageOverTimeEffect.GetRemainingSeconds();
					int num2 = (damageOverTimeEffect._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds == null) ? maxTicks : remainingSeconds.Value) : ((num == null) ? maxTicks : num.Value);
					if (num2 > 0)
					{
						double num3 = damageOverTimeEffect.EffectSource.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * maxRate;
						double num4 = damageOverTimeEffect.Damage * (double)num2 * rate;
						if (num4 > num3)
						{
							num4 = num3;
						}
						if (!battleDamages.ContainsKey(damageOverTimeEffect.SourceUnit))
						{
							battleDamages.Add(damageOverTimeEffect.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
						}
						if (!battleDamages[damageOverTimeEffect.SourceUnit].ContainsKey(damageOverTimeEffect.EffectWearer))
						{
							battleDamages[damageOverTimeEffect.SourceUnit].Add(damageOverTimeEffect.EffectWearer, new List<DamagePotionValue>());
						}
						battleDamages[damageOverTimeEffect.SourceUnit][damageOverTimeEffect.EffectWearer].Add(DamagePotionValue.CreateRawValuedDamageComponent(damageOverTimeEffect.EffectWearer, damageOverTimeEffect.EffectSource.SourceUnit, OutputType.RealDamage, num4));
					}
				}
				if (damageInstantlyReleaseable is ShieldBurnEffect)
				{
					ShieldBurnEffect ef = damageInstantlyReleaseable as ShieldBurnEffect;
					int? remainingSeconds2 = ef.GetRemainingSeconds();
					int remainingNumberOfTicks = (remainingSeconds2 == null) ? maxTicks : remainingSeconds2.Value;
					if (remainingNumberOfTicks > 0)
					{
						if (!battleDamages.ContainsKey(ef.SourceUnit))
						{
							battleDamages.Add(ef.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
						}
						if (!battleDamages[ef.SourceUnit].ContainsKey(ef._effectCarrier))
						{
							battleDamages[ef.SourceUnit].Add(ef._effectCarrier, new List<DamagePotionValue>());
						}
						battleDamages[ef.SourceUnit][ef._effectCarrier].AddRange(ef._hits.SelectMany((DamageHitDefinition h) => (from p in h.Potions
						select new DamagePotionValue(ef.EffectSource.SourceUnit, ef._effectCarrier, OutputType.RealDamage, ef.FilterDamageValue(p.DamageRate * (double)remainingNumberOfTicks * rate, maxRate))).ToList<DamagePotionValue>()));
					}
				}
				if (damageInstantlyReleaseable is LifeExtractionEffect)
				{
					LifeExtractionEffect lifeExtractionEffect = damageInstantlyReleaseable as LifeExtractionEffect;
					int? num5 = lifeExtractionEffect.NumberOfRemainingTurns();
					int? remainingSeconds3 = lifeExtractionEffect.GetRemainingSeconds();
					int num6 = (lifeExtractionEffect._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds3 == null) ? maxTicks : remainingSeconds3.Value) : ((num5 == null) ? maxTicks : num5.Value);
					if (num6 > 0)
					{
						if (!battleDamages.ContainsKey(lifeExtractionEffect.SourceUnit))
						{
							battleDamages.Add(lifeExtractionEffect.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
						}
						if (!battleDamages[lifeExtractionEffect.SourceUnit].ContainsKey(lifeExtractionEffect._effectCarrier))
						{
							battleDamages[lifeExtractionEffect.SourceUnit].Add(lifeExtractionEffect._effectCarrier, new List<DamagePotionValue>());
						}
						battleDamages[lifeExtractionEffect.SourceUnit][lifeExtractionEffect._effectCarrier].Add(DamagePotionValue.CreateRawValuedDamageComponent(lifeExtractionEffect._effectCarrier, lifeExtractionEffect.EffectCausedCaster, OutputType.RealDamage, lifeExtractionEffect.FilterDamageValue(lifeExtractionEffect.DamageRawPerTick * (double)num6 * rate, maxRate)));
						if (!heals.ContainsKey(lifeExtractionEffect.EffectCausedCaster))
						{
							heals.Add(lifeExtractionEffect.EffectCausedCaster, new List<BattleHeal>());
						}
						heals[lifeExtractionEffect.EffectCausedCaster].Add(new BattleHeal(lifeExtractionEffect.EffectCausedCaster, lifeExtractionEffect, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = lifeExtractionEffect.HealPercentageOfDamagePerTick * (double)num6,
								IsDirectHeal = false,
								HealType = OutputType.RealHeal
							}
						}, false));
					}
				}
				IEnumerator enumerator3 = perwearer.Key.LooseSkillEffect(damageInstantlyReleaseable as BattleEffectBase, EffectWearsOffType.Expiration).GetEnumerator();
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
			using (Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>.Enumerator enumerator4 = battleDamages.GetEnumerator())
			{
				while (enumerator4.MoveNext())
				{
					KeyValuePair<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamage = enumerator4.Current;
					List<BattleDamage> bds = (from b in battleDamage.Value
					select new BattleDamage(b.Key, new DamageOverTimeInstantSource(battleDamage.Key), new List<DamageComponentValue>
					{
						new DamageComponentValue(b.Value, b.Key, battleDamage.Key, false, false)
					})).ToList<BattleDamage>();
					IEnumerator enumerator5 = new ReleaseableDamage(bds, battleDamage.Key).Release().GetEnumerator();
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
			if (heals.Any<KeyValuePair<IBattleUnit, List<BattleHeal>>>())
			{
				foreach (KeyValuePair<IBattleUnit, List<BattleHeal>> heal in heals)
				{
					IEnumerator enumerator7 = new ReleaseableHeal(heal.Value, heal.Key).Release().GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x06003553 RID: 13651 RVA: 0x00161B40 File Offset: 0x0015FF40
	public IEnumerable Spread(IBattleUnit fromUnit, List<IBattleUnit> tounits)
	{
		if (!this._effectSourceIdentityCode.Contains("spreaddot"))
		{
			string code = string.Concat(new object[]
			{
				"spreaddot",
				this._style,
				this._damageType,
				fromUnit.GetId()
			});
			foreach (IBattleUnit battleUnit in tounits)
			{
				IBattleUnit unit = battleUnit;
				DamageOverTimeEffect damageOverTimeEffect = new DamageOverTimeEffect();
				damageOverTimeEffect._damageType = this._damageType;
				damageOverTimeEffect._effectSourceIdentityCode = code;
				damageOverTimeEffect.Damage = this.Damage;
				damageOverTimeEffect.EffectWearer = battleUnit;
				damageOverTimeEffect._battleEffectType = this._battleEffectType;
				damageOverTimeEffect._canBeDispersed = this._canBeDispersed;
				damageOverTimeEffect._effectSource = this.EffectSource;
				DamageOverTimeEffect damageOverTimeEffect2 = damageOverTimeEffect;
				int? num = (this._maxNumberOfLastingSeconds == null) ? null : new int?(3);
				damageOverTimeEffect2._maxNumberOfLastingSeconds = ((num == null) ? null : new float?((float)num.Value));
				damageOverTimeEffect._style = this._style;
				damageOverTimeEffect._maxStackableInstances = new int?(1);
				damageOverTimeEffect.TurnEventsCollected = new List<AdventureEventType>();
				damageOverTimeEffect.Description = base.Description;
				damageOverTimeEffect._numberOfLastingTurns = ((this._numberOfLastingTurns == null) ? null : new int?(2));
				damageOverTimeEffect._canBeImmuned = this._canBeImmuned;
				damageOverTimeEffect._isThroughEffect = this._isThroughEffect;
				IEnumerator enumerator2 = unit.ApplySkillEffect(damageOverTimeEffect, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x170008E4 RID: 2276
	// (get) Token: 0x06003554 RID: 13652 RVA: 0x00161B71 File Offset: 0x0015FF71
	public OutputType? DamageOutputType
	{
		get
		{
			return new OutputType?(this._damageType);
		}
	}

	// Token: 0x06003555 RID: 13653 RVA: 0x00161B80 File Offset: 0x0015FF80
	// Note: this type is marked as 'beforefieldinit'.
	static DamageOverTimeEffect()
	{
	}

	// Token: 0x04002995 RID: 10645
	public static string PoisonDamageProc = "PoisonDamageDoTProc";

	// Token: 0x04002996 RID: 10646
	public static string BurningEffectKey = "BurningDoTEffectKey";

	// Token: 0x04002997 RID: 10647
	public static string NightmareEffectKey = "NightmareDoTEffectKey";

	// Token: 0x04002998 RID: 10648
	public static string DarknessRevengeEffectKey = "DARKNESSREVENGEKEY";

	// Token: 0x04002999 RID: 10649
	public static string TimeFallEffectKey = "m21bossskill";

	// Token: 0x0400299A RID: 10650
	public static string SecondPoisonKey = "SECONDPOISON";

	// Token: 0x0400299B RID: 10651
	public static string SecondBleedingKey = "SECONDBLEEDING";

	// Token: 0x0400299C RID: 10652
	private string _effectSourceIdentityCode;

	// Token: 0x0400299D RID: 10653
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x0400299E RID: 10654
	private IBattleEffectSource _effectSource;

	// Token: 0x0400299F RID: 10655
	private int? _maxStackableInstances;

	// Token: 0x040029A0 RID: 10656
	private BattleEffectType _battleEffectType;

	// Token: 0x040029A1 RID: 10657
	private int? _numberOfLastingTurns;

	// Token: 0x040029A2 RID: 10658
	private EffectOverTimeStyle _style;

	// Token: 0x040029A3 RID: 10659
	private bool _canBeDispersed;

	// Token: 0x040029A4 RID: 10660
	private bool _canBeImmuned;

	// Token: 0x040029A5 RID: 10661
	private bool _isThroughEffect;

	// Token: 0x040029A6 RID: 10662
	private OutputType _damageType;

	// Token: 0x040029A7 RID: 10663
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Damage>k__BackingField;

	// Token: 0x040029A8 RID: 10664
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <EffectWearer>k__BackingField;

	// Token: 0x02000EA2 RID: 3746
	[CompilerGenerated]
	private sealed class <AddDamageOverTurn>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E66 RID: 24166 RVA: 0x00161BD3 File Offset: 0x0015FFD3
		[DebuggerHidden]
		public <AddDamageOverTurn>c__Iterator0()
		{
		}

		// Token: 0x06005E67 RID: 24167 RVA: 0x00161BDC File Offset: 0x0015FFDC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (rawDamageValue <= 0.0 || numberOfTurns <= 0)
				{
					goto IL_61C;
				}
				existingTurn = target.BattleEffects.OfType<DamageOverTimeEffect>().FirstOrDefault((DamageOverTimeEffect ef) => ef.BattleEffectType == BattleEffectType.TurnDamage && ef._effectSourceIdentityCode == "damageperturn" + damageType);
				if (existingTurn == null)
				{
					damage = rawDamageValue * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
					description = BattleEffectType.TurnDamage.GetDescription();
					description.Details1 = description.Details1.Replace("{damage}", damage.ToExpression());
					effect = new DamageOverTimeEffect
					{
						_effectSource = effectSource,
						_effectSourceIdentityCode = "damageperturn" + damageType,
						Damage = damage,
						EffectWearer = target,
						_maxNumberOfLastingSeconds = null,
						_style = EffectOverTimeStyle.PerTurn,
						_maxStackableInstances = new int?(1),
						TurnEventsCollected = new List<AdventureEventType>(),
						Description = description,
						_battleEffectType = BattleEffectType.TurnDamage,
						_numberOfLastingTurns = new int?(numberOfTurns),
						_canBeDispersed = true,
						_canBeImmuned = true,
						_isThroughEffect = false,
						_damageType = damageType
					};
					enumerator2 = target.ApplySkillEffect(effect, false).GetEnumerator();
					num = 4294967293u;
					goto Block_16;
				}
				if (effectSource.SourceUnit.EffectApplySucceeded(target))
				{
					double num2 = (double)numberOfTurns * effectSource.SourceUnit.GetEffectTimeRatio(target);
					double num3 = 1.0 - target.SpecialEffects.OfType<NegativeEffectSpeedupData>().Sum((NegativeEffectSpeedupData n) => n.DecreaseRate);
					if (num3 < 0.0)
					{
						num3 = 0.0;
					}
					num2 *= num3;
					if (num2 < 1.0)
					{
						num2 = 1.0;
					}
					double num4 = rawDamageValue * Convert.ToDouble(num2) * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
					int? num5 = existingTurn.NumberOfRemainingTurns();
					int? remainingSeconds = existingTurn.GetRemainingSeconds();
					int num6 = 10000;
					int num7 = (existingTurn._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds == null) ? num6 : remainingSeconds.Value) : ((num5 == null) ? num6 : num5.Value);
					double num8 = (double)num7 * existingTurn.Damage;
					double num9 = num4 + num8;
					existingTurn._numberOfLastingTurns = new int?((num2 < (double)num7) ? num7 : ((int)num2));
					if (existingTurn._numberOfLastingTurns <= 1)
					{
						existingTurn._numberOfLastingTurns = new int?(1);
					}
					double damage2 = num9 / Convert.ToDouble(existingTurn._numberOfLastingTurns);
					existingTurn.Damage = damage2;
					existingTurn.TurnEventsCollected = new List<AdventureEventType>();
					Description description2 = BattleEffectType.TurnDamage.GetDescription();
					description2.Details1 = description2.Details1.Replace("{damage}", existingTurn.Damage.ToExpression());
					existingTurn.Description = description2;
					goto IL_451;
				}
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new DamageOverTimeEffect
				{
					_effectSource = effectSource,
					_effectSourceIdentityCode = "damageperturn" + damageType,
					Damage = 0.0,
					EffectWearer = target,
					_maxNumberOfLastingSeconds = null,
					_style = EffectOverTimeStyle.PerTurn,
					_maxStackableInstances = new int?(1),
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = BattleEffectType.TurnDamage.GetDescription(),
					_battleEffectType = BattleEffectType.TurnDamage,
					_numberOfLastingTurns = new int?(numberOfTurns),
					_canBeDispersed = true,
					_canBeImmuned = true,
					_isThroughEffect = false,
					_damageType = damageType
				})).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_598;
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
			IL_451:
			goto IL_61C;
			Block_16:
			try
			{
				IL_598:
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
			IL_61C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013BA RID: 5050
		// (get) Token: 0x06005E68 RID: 24168 RVA: 0x0016222C File Offset: 0x0016062C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013BB RID: 5051
		// (get) Token: 0x06005E69 RID: 24169 RVA: 0x00162234 File Offset: 0x00160634
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E6A RID: 24170 RVA: 0x0016223C File Offset: 0x0016063C
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

		// Token: 0x06005E6B RID: 24171 RVA: 0x001622EC File Offset: 0x001606EC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E6C RID: 24172 RVA: 0x001622F3 File Offset: 0x001606F3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E6D RID: 24173 RVA: 0x001622FC File Offset: 0x001606FC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageOverTimeEffect.<AddDamageOverTurn>c__Iterator0 <AddDamageOverTurn>c__Iterator = new DamageOverTimeEffect.<AddDamageOverTurn>c__Iterator0();
			<AddDamageOverTurn>c__Iterator.rawDamageValue = rawDamageValue;
			<AddDamageOverTurn>c__Iterator.numberOfTurns = numberOfTurns;
			<AddDamageOverTurn>c__Iterator.target = target;
			<AddDamageOverTurn>c__Iterator.damageType = damageType;
			<AddDamageOverTurn>c__Iterator.effectSource = effectSource;
			return <AddDamageOverTurn>c__Iterator;
		}

		// Token: 0x06005E6E RID: 24174 RVA: 0x00162360 File Offset: 0x00160760
		private static double <>m__0(NegativeEffectSpeedupData n)
		{
			return n.DecreaseRate;
		}

		// Token: 0x04005201 RID: 20993
		internal double rawDamageValue;

		// Token: 0x04005202 RID: 20994
		internal int numberOfTurns;

		// Token: 0x04005203 RID: 20995
		internal IBattleUnit target;

		// Token: 0x04005204 RID: 20996
		internal OutputType damageType;

		// Token: 0x04005205 RID: 20997
		internal DamageOverTimeEffect <existingTurn>__1;

		// Token: 0x04005206 RID: 20998
		internal IBattleEffectSource effectSource;

		// Token: 0x04005207 RID: 20999
		internal IEnumerator $locvar0;

		// Token: 0x04005208 RID: 21000
		internal object <_>__2;

		// Token: 0x04005209 RID: 21001
		internal IDisposable $locvar1;

		// Token: 0x0400520A RID: 21002
		internal double <damage>__3;

		// Token: 0x0400520B RID: 21003
		internal Description <description>__3;

		// Token: 0x0400520C RID: 21004
		internal DamageOverTimeEffect <effect>__3;

		// Token: 0x0400520D RID: 21005
		internal IEnumerator $locvar2;

		// Token: 0x0400520E RID: 21006
		internal object <_>__4;

		// Token: 0x0400520F RID: 21007
		internal IDisposable $locvar3;

		// Token: 0x04005210 RID: 21008
		internal object $current;

		// Token: 0x04005211 RID: 21009
		internal bool $disposing;

		// Token: 0x04005212 RID: 21010
		internal int $PC;

		// Token: 0x04005213 RID: 21011
		private DamageOverTimeEffect.<AddDamageOverTurn>c__Iterator0.<AddDamageOverTurn>c__AnonStorey6 $locvar4;

		// Token: 0x04005214 RID: 21012
		private static Func<NegativeEffectSpeedupData, double> <>f__am$cache0;

		// Token: 0x02000EA8 RID: 3752
		private sealed class <AddDamageOverTurn>c__AnonStorey6
		{
			// Token: 0x06005E98 RID: 24216 RVA: 0x00162368 File Offset: 0x00160768
			public <AddDamageOverTurn>c__AnonStorey6()
			{
			}

			// Token: 0x06005E99 RID: 24217 RVA: 0x00162370 File Offset: 0x00160770
			internal bool <>m__0(DamageOverTimeEffect ef)
			{
				return ef.BattleEffectType == BattleEffectType.TurnDamage && ef._effectSourceIdentityCode == "damageperturn" + this.damageType;
			}

			// Token: 0x04005281 RID: 21121
			internal OutputType damageType;

			// Token: 0x04005282 RID: 21122
			internal DamageOverTimeEffect.<AddDamageOverTurn>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000EA3 RID: 3747
	[CompilerGenerated]
	private sealed class <AddDamageOverSecond>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E6F RID: 24175 RVA: 0x001623A0 File Offset: 0x001607A0
		[DebuggerHidden]
		public <AddDamageOverSecond>c__Iterator1()
		{
		}

		// Token: 0x06005E70 RID: 24176 RVA: 0x001623A8 File Offset: 0x001607A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (rawDamage <= 0.0 || numberOfSeconds <= 0)
				{
					goto IL_612;
				}
				existingDoT = target.BattleEffects.OfType<DamageOverTimeEffect>().FirstOrDefault((DamageOverTimeEffect ef) => ef.BattleEffectType == BattleEffectType.DamagePerSecond && ef._effectSourceIdentityCode == "damagepersec" + damageType);
				if (existingDoT == null)
				{
					damage = rawDamage * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
					description = BattleEffectType.DamagePerSecond.GetDescription();
					description.Details1 = description.Details1.Replace("{damage}", damage.ToExpression());
					effect = new DamageOverTimeEffect
					{
						_effectSource = effectSource,
						_effectSourceIdentityCode = "damagepersec" + damageType,
						Damage = damage,
						EffectWearer = target,
						_maxNumberOfLastingSeconds = new float?((float)numberOfSeconds),
						_style = EffectOverTimeStyle.PerSecond,
						_maxStackableInstances = new int?(1),
						TurnEventsCollected = new List<AdventureEventType>(),
						Description = description,
						_battleEffectType = BattleEffectType.DamagePerSecond,
						_numberOfLastingTurns = null,
						_canBeDispersed = true,
						_canBeImmuned = true,
						_isThroughEffect = false,
						_damageType = damageType
					};
					enumerator2 = target.ApplySkillEffect(effect, false).GetEnumerator();
					num = 4294967293u;
					goto Block_15;
				}
				if (effectSource.SourceUnit.EffectApplySucceeded(target))
				{
					double num2 = Convert.ToDouble(numberOfSeconds) * effectSource.SourceUnit.GetEffectTimeRatio(target);
					double num3 = 1.0 - target.SpecialEffects.OfType<NegativeEffectSpeedupData>().Sum((NegativeEffectSpeedupData n) => n.DecreaseRate);
					if (num3 < 0.0)
					{
						num3 = 0.0;
					}
					num2 *= num3;
					double num4 = rawDamage * Convert.ToDouble(num2) * DamageOverTimeEffect.GetDoTCritRatio(effectSource.SourceUnit, target);
					int? num5 = existingDoT.NumberOfRemainingTurns();
					int? remainingSeconds = existingDoT.GetRemainingSeconds();
					int num6 = 100;
					int num7 = (existingDoT._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds == null) ? num6 : remainingSeconds.Value) : ((num5 == null) ? num6 : num5.Value);
					double num8 = (double)num7 * existingDoT.Damage;
					double num9 = num4 + num8;
					existingDoT._maxNumberOfLastingSeconds = new float?((float)((num2 < (double)num7) ? num7 : ((int)num2)));
					if (existingDoT._maxNumberOfLastingSeconds <= 1f)
					{
						existingDoT._maxNumberOfLastingSeconds = new float?(1f);
					}
					double damage2 = num9 / Convert.ToDouble(existingDoT._maxNumberOfLastingSeconds);
					existingDoT.Damage = damage2;
					existingDoT.Timer = 0f;
					Description description2 = BattleEffectType.DamagePerSecond.GetDescription();
					description2.Details1 = description2.Details1.Replace("{damage}", existingDoT.Damage.ToExpression());
					existingDoT.Description = description2;
					goto IL_444;
				}
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new DamageOverTimeEffect
				{
					_effectSource = effectSource,
					_effectSourceIdentityCode = "damagepersec" + damageType,
					Damage = 0.0,
					EffectWearer = target,
					_maxNumberOfLastingSeconds = new float?((float)numberOfSeconds),
					_style = EffectOverTimeStyle.PerSecond,
					_maxStackableInstances = new int?(1),
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = BattleEffectType.DamagePerSecond.GetDescription(),
					_battleEffectType = BattleEffectType.DamagePerSecond,
					_numberOfLastingTurns = null,
					_canBeDispersed = true,
					_canBeImmuned = true,
					_isThroughEffect = false,
					_damageType = damageType
				})).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_58E;
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
			IL_444:
			goto IL_612;
			Block_15:
			try
			{
				IL_58E:
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
			IL_612:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013BC RID: 5052
		// (get) Token: 0x06005E71 RID: 24177 RVA: 0x001629F0 File Offset: 0x00160DF0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013BD RID: 5053
		// (get) Token: 0x06005E72 RID: 24178 RVA: 0x001629F8 File Offset: 0x00160DF8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E73 RID: 24179 RVA: 0x00162A00 File Offset: 0x00160E00
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

		// Token: 0x06005E74 RID: 24180 RVA: 0x00162AB0 File Offset: 0x00160EB0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E75 RID: 24181 RVA: 0x00162AB7 File Offset: 0x00160EB7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E76 RID: 24182 RVA: 0x00162AC0 File Offset: 0x00160EC0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageOverTimeEffect.<AddDamageOverSecond>c__Iterator1 <AddDamageOverSecond>c__Iterator = new DamageOverTimeEffect.<AddDamageOverSecond>c__Iterator1();
			<AddDamageOverSecond>c__Iterator.rawDamage = rawDamage;
			<AddDamageOverSecond>c__Iterator.numberOfSeconds = numberOfSeconds;
			<AddDamageOverSecond>c__Iterator.target = target;
			<AddDamageOverSecond>c__Iterator.damageType = damageType;
			<AddDamageOverSecond>c__Iterator.effectSource = effectSource;
			return <AddDamageOverSecond>c__Iterator;
		}

		// Token: 0x06005E77 RID: 24183 RVA: 0x00162B24 File Offset: 0x00160F24
		private static double <>m__0(NegativeEffectSpeedupData n)
		{
			return n.DecreaseRate;
		}

		// Token: 0x04005215 RID: 21013
		internal double rawDamage;

		// Token: 0x04005216 RID: 21014
		internal int numberOfSeconds;

		// Token: 0x04005217 RID: 21015
		internal IBattleUnit target;

		// Token: 0x04005218 RID: 21016
		internal OutputType damageType;

		// Token: 0x04005219 RID: 21017
		internal DamageOverTimeEffect <existingDoT>__1;

		// Token: 0x0400521A RID: 21018
		internal IBattleEffectSource effectSource;

		// Token: 0x0400521B RID: 21019
		internal IEnumerator $locvar0;

		// Token: 0x0400521C RID: 21020
		internal object <_>__2;

		// Token: 0x0400521D RID: 21021
		internal IDisposable $locvar1;

		// Token: 0x0400521E RID: 21022
		internal double <damage>__3;

		// Token: 0x0400521F RID: 21023
		internal Description <description>__3;

		// Token: 0x04005220 RID: 21024
		internal DamageOverTimeEffect <effect>__3;

		// Token: 0x04005221 RID: 21025
		internal IEnumerator $locvar2;

		// Token: 0x04005222 RID: 21026
		internal object <_>__4;

		// Token: 0x04005223 RID: 21027
		internal IDisposable $locvar3;

		// Token: 0x04005224 RID: 21028
		internal object $current;

		// Token: 0x04005225 RID: 21029
		internal bool $disposing;

		// Token: 0x04005226 RID: 21030
		internal int $PC;

		// Token: 0x04005227 RID: 21031
		private DamageOverTimeEffect.<AddDamageOverSecond>c__Iterator1.<AddDamageOverSecond>c__AnonStorey7 $locvar4;

		// Token: 0x04005228 RID: 21032
		private static Func<NegativeEffectSpeedupData, double> <>f__am$cache0;

		// Token: 0x02000EA9 RID: 3753
		private sealed class <AddDamageOverSecond>c__AnonStorey7
		{
			// Token: 0x06005E9A RID: 24218 RVA: 0x00162B2C File Offset: 0x00160F2C
			public <AddDamageOverSecond>c__AnonStorey7()
			{
			}

			// Token: 0x06005E9B RID: 24219 RVA: 0x00162B34 File Offset: 0x00160F34
			internal bool <>m__0(DamageOverTimeEffect ef)
			{
				return ef.BattleEffectType == BattleEffectType.DamagePerSecond && ef._effectSourceIdentityCode == "damagepersec" + this.damageType;
			}

			// Token: 0x04005283 RID: 21123
			internal OutputType damageType;

			// Token: 0x04005284 RID: 21124
			internal DamageOverTimeEffect.<AddDamageOverSecond>c__Iterator1 <>f__ref$1;
		}
	}

	// Token: 0x02000EA4 RID: 3748
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E78 RID: 24184 RVA: 0x00162B66 File Offset: 0x00160F66
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator2()
		{
		}

		// Token: 0x06005E79 RID: 24185 RVA: 0x00162B70 File Offset: 0x00160F70
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitEntersTurn || eventType != AdventureEventType.UnitEntersTurn || eventTriggerUnit != listener || eventTriggerUnit != base.EffectWearer || base.EffectWearer.Status != BattleUnitStatus.Active || this._style != EffectOverTimeStyle.PerTurn)
				{
					goto IL_292;
				}
				damage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(base.EffectWearer, this, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(base.EffectWearer, this.EffectSource.SourceUnit, (this.BattleEffectType == BattleEffectType.DarknessRevenge) ? OutputType.Shadow : OutputType.RealDamage, base.Damage)
						}, base.EffectWearer, this.EffectSource.SourceUnit, false, false)
					})
				}, this.EffectSource.SourceUnit);
				enumerator = damage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_20E;
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
			enumerator2 = this.Triggered(base.EffectWearer).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_20E:
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
			IL_292:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013BE RID: 5054
		// (get) Token: 0x06005E7A RID: 24186 RVA: 0x00162E38 File Offset: 0x00161238
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013BF RID: 5055
		// (get) Token: 0x06005E7B RID: 24187 RVA: 0x00162E40 File Offset: 0x00161240
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E7C RID: 24188 RVA: 0x00162E48 File Offset: 0x00161248
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

		// Token: 0x06005E7D RID: 24189 RVA: 0x00162EF8 File Offset: 0x001612F8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E7E RID: 24190 RVA: 0x00162EFF File Offset: 0x001612FF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E7F RID: 24191 RVA: 0x00162F08 File Offset: 0x00161308
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageOverTimeEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator2 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new DamageOverTimeEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator2();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005229 RID: 21033
		internal AdventureEventType eventType;

		// Token: 0x0400522A RID: 21034
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400522B RID: 21035
		internal IBattleUnit listener;

		// Token: 0x0400522C RID: 21036
		internal ReleaseableDamage <damage>__1;

		// Token: 0x0400522D RID: 21037
		internal IEnumerator $locvar0;

		// Token: 0x0400522E RID: 21038
		internal object <_>__2;

		// Token: 0x0400522F RID: 21039
		internal IDisposable $locvar1;

		// Token: 0x04005230 RID: 21040
		internal IEnumerator $locvar2;

		// Token: 0x04005231 RID: 21041
		internal object <_>__3;

		// Token: 0x04005232 RID: 21042
		internal IDisposable $locvar3;

		// Token: 0x04005233 RID: 21043
		internal DamageOverTimeEffect $this;

		// Token: 0x04005234 RID: 21044
		internal object $current;

		// Token: 0x04005235 RID: 21045
		internal bool $disposing;

		// Token: 0x04005236 RID: 21046
		internal int $PC;
	}

	// Token: 0x02000EA5 RID: 3749
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit_Batch>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E80 RID: 24192 RVA: 0x00162F60 File Offset: 0x00161360
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit_Batch>c__Iterator3()
		{
		}

		// Token: 0x06005E81 RID: 24193 RVA: 0x00162F68 File Offset: 0x00161368
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				battleDamages = new Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>();
				heals = new Dictionary<IBattleUnit, List<BattleHeal>>();
				if (!perWearerDots.Any<KeyValuePair<IBattleUnit, List<BattleEffectBase>>>())
				{
					goto IL_AE0;
				}
				enumerator = perWearerDots.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			case 3u:
				goto IL_881;
			case 4u:
				goto IL_9E3;
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
						case 1u:
							Block_26:
							try
							{
								switch (num)
								{
								case 1u:
									Block_35:
									try
									{
										switch (num)
										{
										}
										if (enumerator4.MoveNext())
										{
											_ = enumerator4.Current;
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
											if ((disposable = (enumerator4 as IDisposable)) != null)
											{
												disposable.Dispose();
											}
										}
									}
									break;
								}
								if (enumerator3.MoveNext())
								{
									battleUnit = enumerator3.Current;
									enumerator4 = battleUnit.ApplySkillEffect(LifeExtractionEffect.CreateShadowProcEffect(ef.EffectSource, ef.DamageRawPerTick, ef.HealPercentageOfDamagePerTick, battleUnit, 3f, "autospreaded"), false).GetEnumerator();
									num = 4294967293u;
									goto Block_35;
								}
							}
							finally
							{
								if (!flag)
								{
									((IDisposable)enumerator3).Dispose();
								}
							}
							break;
						default:
							goto IL_756;
						}
						IL_48B:
						if (!battleDamages.ContainsKey(ef.SourceUnit))
						{
							battleDamages.Add(ef.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
						}
						if (!battleDamages[ef.SourceUnit].ContainsKey(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key))
						{
							battleDamages[ef.SourceUnit].Add(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key, new List<DamagePotionValue>());
						}
						battleDamages[ef.SourceUnit][<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key].Add(DamagePotionValue.CreateRawValuedDamageComponent(ef._effectCarrier, ef.EffectCausedCaster.SourceUnit, ef._damageType, ef.DamageRawPerTick));
						if (!heals.ContainsKey(ef.EffectCausedCaster))
						{
							heals.Add(ef.EffectCausedCaster, new List<BattleHeal>());
						}
						heals[ef.EffectCausedCaster].Add(new BattleHeal(ef.EffectCausedCaster, ef, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = ef.HealPercentageOfDamagePerTick * ef.DamageRawPerTick,
								IsDirectHeal = false,
								HealType = OutputType.RealHeal
							}
						}, false));
						IL_637:
						if (damageOverTimeEffect is ShieldBurnEffect)
						{
							ShieldBurnEffect ef = damageOverTimeEffect as ShieldBurnEffect;
							if (!battleDamages.ContainsKey(ef.SourceUnit))
							{
								battleDamages.Add(ef.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
							}
							if (!battleDamages[ef.SourceUnit].ContainsKey(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key))
							{
								battleDamages[ef.SourceUnit].Add(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key, new List<DamagePotionValue>());
							}
							battleDamages[ef.SourceUnit][<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key].AddRange(ef._hits.SelectMany((DamageHitDefinition h) => h.Potions.Select(delegate(DamageHitModuleDefinition p)
							{
								IBattleUnit sourceUnit = ef.EffectSource.SourceUnit;
								IBattleUnit effectCarrier = ef._effectCarrier;
								OutputType? outputType = p.OutputType;
								return new DamagePotionValue(sourceUnit, effectCarrier, (outputType == null) ? ef.EffectSource.SourceUnit.GetOutputType() : outputType.Value, p.DamageRate);
							})));
						}
						IL_756:
						if (enumerator2.MoveNext())
						{
							damageOverTimeEffect = enumerator2.Current;
							if (damageOverTimeEffect is DamageOverTimeEffect)
							{
								DamageOverTimeEffect damageOverTimeEffect2 = damageOverTimeEffect as DamageOverTimeEffect;
								if (damageOverTimeEffect2._style == EffectOverTimeStyle.PerSecond && <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key == damageOverTimeEffect2.EffectWearer && <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key.IsAliveInBattle())
								{
									if (!battleDamages.ContainsKey(damageOverTimeEffect2.SourceUnit))
									{
										battleDamages.Add(damageOverTimeEffect2.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
									}
									if (!battleDamages[damageOverTimeEffect2.SourceUnit].ContainsKey(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key))
									{
										battleDamages[damageOverTimeEffect2.SourceUnit].Add(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key, new List<DamagePotionValue>());
									}
									battleDamages[damageOverTimeEffect2.SourceUnit][<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key].Add(DamagePotionValue.CreateRawValuedDamageComponent(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key, damageOverTimeEffect.SourceUnit, damageOverTimeEffect2._damageType, damageOverTimeEffect2.Damage));
								}
							}
							if (!(damageOverTimeEffect is LifeExtractionEffect))
							{
								goto IL_637;
							}
							ef = (damageOverTimeEffect as LifeExtractionEffect);
							if (ef._style != EffectOverTimeStyle.PerSecond || <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key != ef._effectCarrier || !<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key.IsAliveInBattle())
							{
								goto IL_637;
							}
							second = (int)ef.Timer;
							if (ef.EffectSource.SourceUnit.SpecialEffects.OfType<ShadowEffectEnhancementData>().Any<ShadowEffectEnhancementData>() && second > 0 && second % 2 == 0)
							{
								additionaTargets = ef.EffectSource.SourceUnit.SpecialEffects.OfType<ShadowEffectEnhancementData>().First<ShadowEffectEnhancementData>().AdditionalTargets;
								targets = (from e in <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key.GetAllLiveFriendlyTargetsIncSelf(false)
								where e != <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key
								select e).Take(additionaTargets).ToList<IBattleUnit>();
								enumerator3 = targets.GetEnumerator();
								num = 4294967293u;
								goto Block_26;
							}
							goto IL_48B;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
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
					goto IL_842;
				default:
					goto IL_842;
				}
				IL_781:
				enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Key, AdventureEventType.DamagePerSecondTrigger, <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey.dot.Value)).GetEnumerator();
				num = 4294967293u;
				goto Block_10;
				IL_842:
				if (enumerator.MoveNext())
				{
					KeyValuePair<IBattleUnit, List<BattleEffectBase>> dot = enumerator.Current;
					effects = dot.Value;
					if (effects.Any<BattleEffectBase>())
					{
						enumerator2 = effects.GetEnumerator();
						num = 4294967293u;
						goto Block_9;
					}
					goto IL_781;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enumerator6 = battleDamages.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_881:
				switch (num)
				{
				case 3u:
					Block_56:
					try
					{
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
					break;
				}
				if (enumerator6.MoveNext())
				{
					KeyValuePair<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamage = enumerator6.Current;
					bds = (from b in battleDamage.Value
					select new BattleDamage(b.Key, new DamageOverTimeTickSource(battleDamage.Key), new List<DamageComponentValue>
					{
						new DamageComponentValue(b.Value, b.Key, battleDamage.Key, false, false)
					})).ToList<BattleDamage>();
					enumerator7 = new ReleaseableDamage(bds, battleDamage.Key).Release().GetEnumerator();
					num = 4294967293u;
					goto Block_56;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator6).Dispose();
				}
			}
			if (!heals.Any<KeyValuePair<IBattleUnit, List<BattleHeal>>>())
			{
				goto IL_AE0;
			}
			enumerator8 = heals.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_9E3:
				switch (num)
				{
				case 4u:
					Block_67:
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
				if (enumerator8.MoveNext())
				{
					heal = enumerator8.Current;
					enumerator9 = new ReleaseableHeal(heal.Value, heal.Key).Release().GetEnumerator();
					num = 4294967293u;
					goto Block_67;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator8).Dispose();
				}
			}
			IL_AE0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013C0 RID: 5056
		// (get) Token: 0x06005E82 RID: 24194 RVA: 0x00163B3C File Offset: 0x00161F3C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013C1 RID: 5057
		// (get) Token: 0x06005E83 RID: 24195 RVA: 0x00163B44 File Offset: 0x00161F44
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E84 RID: 24196 RVA: 0x00163B4C File Offset: 0x00161F4C
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
								try
								{
								}
								finally
								{
									if ((disposable = (enumerator4 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)enumerator3).Dispose();
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
							if ((disposable2 = (enumerator5 as IDisposable)) != null)
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
				}
				finally
				{
					((IDisposable)enumerator6).Dispose();
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
			}
		}

		// Token: 0x06005E85 RID: 24197 RVA: 0x00163D3C File Offset: 0x0016213C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E86 RID: 24198 RVA: 0x00163D43 File Offset: 0x00162143
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E87 RID: 24199 RVA: 0x00163D4C File Offset: 0x0016214C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageOverTimeEffect.<PerSecondLogic_ActiveUnit_Batch>c__Iterator3 <PerSecondLogic_ActiveUnit_Batch>c__Iterator = new DamageOverTimeEffect.<PerSecondLogic_ActiveUnit_Batch>c__Iterator3();
			<PerSecondLogic_ActiveUnit_Batch>c__Iterator.perWearerDots = perWearerDots;
			return <PerSecondLogic_ActiveUnit_Batch>c__Iterator;
		}

		// Token: 0x04005237 RID: 21047
		internal Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> <battleDamages>__0;

		// Token: 0x04005238 RID: 21048
		internal Dictionary<IBattleUnit, List<BattleHeal>> <heals>__0;

		// Token: 0x04005239 RID: 21049
		internal Dictionary<IBattleUnit, List<BattleEffectBase>> perWearerDots;

		// Token: 0x0400523A RID: 21050
		internal Dictionary<IBattleUnit, List<BattleEffectBase>>.Enumerator $locvar0;

		// Token: 0x0400523B RID: 21051
		internal List<BattleEffectBase> <effects>__2;

		// Token: 0x0400523C RID: 21052
		internal List<BattleEffectBase>.Enumerator $locvar1;

		// Token: 0x0400523D RID: 21053
		internal BattleEffectBase <damageOverTimeEffect>__3;

		// Token: 0x0400523E RID: 21054
		internal LifeExtractionEffect <ef>__4;

		// Token: 0x0400523F RID: 21055
		internal int <second>__5;

		// Token: 0x04005240 RID: 21056
		internal int <additionaTargets>__6;

		// Token: 0x04005241 RID: 21057
		internal List<IBattleUnit> <targets>__6;

		// Token: 0x04005242 RID: 21058
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04005243 RID: 21059
		internal IBattleUnit <battleUnit>__7;

		// Token: 0x04005244 RID: 21060
		internal IEnumerator $locvar3;

		// Token: 0x04005245 RID: 21061
		internal object <_>__8;

		// Token: 0x04005246 RID: 21062
		internal IDisposable $locvar4;

		// Token: 0x04005247 RID: 21063
		internal IEnumerator $locvar5;

		// Token: 0x04005248 RID: 21064
		internal object <_>__9;

		// Token: 0x04005249 RID: 21065
		internal IDisposable $locvar6;

		// Token: 0x0400524A RID: 21066
		internal Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>.Enumerator $locvar7;

		// Token: 0x0400524B RID: 21067
		internal List<BattleDamage> <bds>__11;

		// Token: 0x0400524C RID: 21068
		internal IEnumerator $locvar8;

		// Token: 0x0400524D RID: 21069
		internal object <_>__12;

		// Token: 0x0400524E RID: 21070
		internal IDisposable $locvar9;

		// Token: 0x0400524F RID: 21071
		internal Dictionary<IBattleUnit, List<BattleHeal>>.Enumerator $locvarA;

		// Token: 0x04005250 RID: 21072
		internal KeyValuePair<IBattleUnit, List<BattleHeal>> <heal>__13;

		// Token: 0x04005251 RID: 21073
		internal IEnumerator $locvarB;

		// Token: 0x04005252 RID: 21074
		internal object <_>__14;

		// Token: 0x04005253 RID: 21075
		internal IDisposable $locvarC;

		// Token: 0x04005254 RID: 21076
		internal object $current;

		// Token: 0x04005255 RID: 21077
		internal bool $disposing;

		// Token: 0x04005256 RID: 21078
		internal int $PC;

		// Token: 0x04005257 RID: 21079
		private DamageOverTimeEffect.<PerSecondLogic_ActiveUnit_Batch>c__Iterator3.<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey8 $locvarD;

		// Token: 0x04005258 RID: 21080
		private DamageOverTimeEffect.<PerSecondLogic_ActiveUnit_Batch>c__Iterator3.<PerSecondLogic_ActiveUnit_Batch>c__AnonStoreyA $locvarF;

		// Token: 0x02000EAA RID: 3754
		private sealed class <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey8
		{
			// Token: 0x06005E9C RID: 24220 RVA: 0x00163D80 File Offset: 0x00162180
			public <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey8()
			{
			}

			// Token: 0x06005E9D RID: 24221 RVA: 0x00163D88 File Offset: 0x00162188
			internal bool <>m__0(IBattleUnit e)
			{
				return e != this.dot.Key;
			}

			// Token: 0x04005285 RID: 21125
			internal KeyValuePair<IBattleUnit, List<BattleEffectBase>> dot;
		}

		// Token: 0x02000EAB RID: 3755
		private sealed class <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey9
		{
			// Token: 0x06005E9E RID: 24222 RVA: 0x00163D9B File Offset: 0x0016219B
			public <PerSecondLogic_ActiveUnit_Batch>c__AnonStorey9()
			{
			}

			// Token: 0x06005E9F RID: 24223 RVA: 0x00163DA3 File Offset: 0x001621A3
			internal IEnumerable<DamagePotionValue> <>m__0(DamageHitDefinition h)
			{
				return h.Potions.Select(delegate(DamageHitModuleDefinition p)
				{
					IBattleUnit sourceUnit = this.ef.EffectSource.SourceUnit;
					IBattleUnit effectCarrier = this.ef._effectCarrier;
					OutputType? outputType = p.OutputType;
					return new DamagePotionValue(sourceUnit, effectCarrier, (outputType == null) ? this.ef.EffectSource.SourceUnit.GetOutputType() : outputType.Value, p.DamageRate);
				});
			}

			// Token: 0x06005EA0 RID: 24224 RVA: 0x00163DBC File Offset: 0x001621BC
			internal DamagePotionValue <>m__1(DamageHitModuleDefinition p)
			{
				IBattleUnit sourceUnit = this.ef.EffectSource.SourceUnit;
				IBattleUnit effectCarrier = this.ef._effectCarrier;
				OutputType? outputType = p.OutputType;
				return new DamagePotionValue(sourceUnit, effectCarrier, (outputType == null) ? this.ef.EffectSource.SourceUnit.GetOutputType() : outputType.Value, p.DamageRate);
			}

			// Token: 0x04005286 RID: 21126
			internal ShieldBurnEffect ef;

			// Token: 0x04005287 RID: 21127
			internal DamageOverTimeEffect.<PerSecondLogic_ActiveUnit_Batch>c__Iterator3.<PerSecondLogic_ActiveUnit_Batch>c__AnonStorey8 <>f__ref$8;
		}

		// Token: 0x02000EAC RID: 3756
		private sealed class <PerSecondLogic_ActiveUnit_Batch>c__AnonStoreyA
		{
			// Token: 0x06005EA1 RID: 24225 RVA: 0x00163E23 File Offset: 0x00162223
			public <PerSecondLogic_ActiveUnit_Batch>c__AnonStoreyA()
			{
			}

			// Token: 0x06005EA2 RID: 24226 RVA: 0x00163E2C File Offset: 0x0016222C
			internal BattleDamage <>m__0(KeyValuePair<IBattleUnit, List<DamagePotionValue>> b)
			{
				return new BattleDamage(b.Key, new DamageOverTimeTickSource(this.battleDamage.Key), new List<DamageComponentValue>
				{
					new DamageComponentValue(b.Value, b.Key, this.battleDamage.Key, false, false)
				});
			}

			// Token: 0x04005288 RID: 21128
			internal KeyValuePair<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamage;
		}
	}

	// Token: 0x02000EA6 RID: 3750
	[CompilerGenerated]
	private sealed class <InstantRun_Batch>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E88 RID: 24200 RVA: 0x00163E82 File Offset: 0x00162282
		[DebuggerHidden]
		public <InstantRun_Batch>c__Iterator4()
		{
		}

		// Token: 0x06005E89 RID: 24201 RVA: 0x00163E8C File Offset: 0x0016228C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				battleDamages = new Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>();
				maxTicks = 100;
				double maxRate = max;
				heals = new Dictionary<IBattleUnit, List<BattleHeal>>();
				enumerator = effectsPerWearer.GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
			case 2u:
			case 3u:
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
						case 1u:
							Block_31:
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
						if (enumerator2.MoveNext())
						{
							damageInstantlyReleaseable = enumerator2.Current;
							if (damageInstantlyReleaseable is DamageOverTimeEffect)
							{
								DamageOverTimeEffect damageOverTimeEffect = damageInstantlyReleaseable as DamageOverTimeEffect;
								int? num2 = damageOverTimeEffect.NumberOfRemainingTurns();
								int? remainingSeconds = damageOverTimeEffect.GetRemainingSeconds();
								int num3 = (damageOverTimeEffect._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds == null) ? maxTicks : remainingSeconds.Value) : ((num2 == null) ? maxTicks : num2.Value);
								if (num3 > 0)
								{
									double num4 = damageOverTimeEffect.EffectSource.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * <InstantRun_Batch>c__AnonStoreyC.maxRate;
									double num5 = damageOverTimeEffect.Damage * (double)num3 * <InstantRun_Batch>c__AnonStoreyC.rate;
									if (num5 > num4)
									{
										num5 = num4;
									}
									if (!battleDamages.ContainsKey(damageOverTimeEffect.SourceUnit))
									{
										battleDamages.Add(damageOverTimeEffect.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
									}
									if (!battleDamages[damageOverTimeEffect.SourceUnit].ContainsKey(damageOverTimeEffect.EffectWearer))
									{
										battleDamages[damageOverTimeEffect.SourceUnit].Add(damageOverTimeEffect.EffectWearer, new List<DamagePotionValue>());
									}
									battleDamages[damageOverTimeEffect.SourceUnit][damageOverTimeEffect.EffectWearer].Add(DamagePotionValue.CreateRawValuedDamageComponent(damageOverTimeEffect.EffectWearer, damageOverTimeEffect.EffectSource.SourceUnit, OutputType.RealDamage, num5));
								}
							}
							if (damageInstantlyReleaseable is ShieldBurnEffect)
							{
								ShieldBurnEffect ef = damageInstantlyReleaseable as ShieldBurnEffect;
								int? remainingSeconds2 = ef.GetRemainingSeconds();
								int remainingNumberOfTicks = (remainingSeconds2 == null) ? maxTicks : remainingSeconds2.Value;
								if (remainingNumberOfTicks > 0)
								{
									if (!battleDamages.ContainsKey(ef.SourceUnit))
									{
										battleDamages.Add(ef.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
									}
									if (!battleDamages[ef.SourceUnit].ContainsKey(ef._effectCarrier))
									{
										battleDamages[ef.SourceUnit].Add(ef._effectCarrier, new List<DamagePotionValue>());
									}
									battleDamages[ef.SourceUnit][ef._effectCarrier].AddRange(ef._hits.SelectMany((DamageHitDefinition h) => (from p in h.Potions
									select new DamagePotionValue(ef.EffectSource.SourceUnit, ef._effectCarrier, OutputType.RealDamage, ef.FilterDamageValue(p.DamageRate * (double)remainingNumberOfTicks * <InstantRun_Batch>c__AnonStoreyC.rate, <InstantRun_Batch>c__AnonStoreyC.maxRate))).ToList<DamagePotionValue>()));
								}
							}
							if (damageInstantlyReleaseable is LifeExtractionEffect)
							{
								LifeExtractionEffect lifeExtractionEffect = damageInstantlyReleaseable as LifeExtractionEffect;
								int? num6 = lifeExtractionEffect.NumberOfRemainingTurns();
								int? remainingSeconds3 = lifeExtractionEffect.GetRemainingSeconds();
								int num7 = (lifeExtractionEffect._style != EffectOverTimeStyle.PerTurn) ? ((remainingSeconds3 == null) ? maxTicks : remainingSeconds3.Value) : ((num6 == null) ? maxTicks : num6.Value);
								if (num7 > 0)
								{
									if (!battleDamages.ContainsKey(lifeExtractionEffect.SourceUnit))
									{
										battleDamages.Add(lifeExtractionEffect.SourceUnit, new Dictionary<IBattleUnit, List<DamagePotionValue>>());
									}
									if (!battleDamages[lifeExtractionEffect.SourceUnit].ContainsKey(lifeExtractionEffect._effectCarrier))
									{
										battleDamages[lifeExtractionEffect.SourceUnit].Add(lifeExtractionEffect._effectCarrier, new List<DamagePotionValue>());
									}
									battleDamages[lifeExtractionEffect.SourceUnit][lifeExtractionEffect._effectCarrier].Add(DamagePotionValue.CreateRawValuedDamageComponent(lifeExtractionEffect._effectCarrier, lifeExtractionEffect.EffectCausedCaster, OutputType.RealDamage, lifeExtractionEffect.FilterDamageValue(lifeExtractionEffect.DamageRawPerTick * (double)num7 * <InstantRun_Batch>c__AnonStoreyC.rate, <InstantRun_Batch>c__AnonStoreyC.maxRate)));
									if (!heals.ContainsKey(lifeExtractionEffect.EffectCausedCaster))
									{
										heals.Add(lifeExtractionEffect.EffectCausedCaster, new List<BattleHeal>());
									}
									heals[lifeExtractionEffect.EffectCausedCaster].Add(new BattleHeal(lifeExtractionEffect.EffectCausedCaster, lifeExtractionEffect, new List<HealComponentValue>
									{
										new HealComponentValue
										{
											RawHeal = lifeExtractionEffect.HealPercentageOfDamagePerTick * (double)num7,
											IsDirectHeal = false,
											HealType = OutputType.RealHeal
										}
									}, false));
								}
							}
							enumerator3 = perwearer.Key.LooseSkillEffect(damageInstantlyReleaseable as BattleEffectBase, EffectWearsOffType.Expiration).GetEnumerator();
							num = 4294967293u;
							goto Block_31;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					enumerator4 = battleDamages.GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				case 3u:
					goto IL_7FB;
				default:
					goto IL_8FA;
				}
				try
				{
					switch (num)
					{
					case 2u:
						Block_42:
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
						KeyValuePair<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamage = enumerator4.Current;
						bds = (from b in battleDamage.Value
						select new BattleDamage(b.Key, new DamageOverTimeInstantSource(battleDamage.Key), new List<DamageComponentValue>
						{
							new DamageComponentValue(b.Value, b.Key, battleDamage.Key, false, false)
						})).ToList<BattleDamage>();
						enumerator5 = new ReleaseableDamage(bds, battleDamage.Key).Release().GetEnumerator();
						num = 4294967293u;
						goto Block_42;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator4).Dispose();
					}
				}
				if (!heals.Any<KeyValuePair<IBattleUnit, List<BattleHeal>>>())
				{
					goto IL_8FA;
				}
				enumerator6 = heals.GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_7FB:
					switch (num)
					{
					case 3u:
						Block_53:
						try
						{
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
						break;
					}
					if (enumerator6.MoveNext())
					{
						heal = enumerator6.Current;
						enumerator7 = new ReleaseableHeal(heal.Value, heal.Key).Release().GetEnumerator();
						num = 4294967293u;
						goto Block_53;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator6).Dispose();
					}
				}
				IL_8FA:
				if (enumerator.MoveNext())
				{
					perwearer = enumerator.Current;
					enumerator2 = perwearer.Value.GetEnumerator();
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

		// Token: 0x170013C2 RID: 5058
		// (get) Token: 0x06005E8A RID: 24202 RVA: 0x00164874 File Offset: 0x00162C74
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013C3 RID: 5059
		// (get) Token: 0x06005E8B RID: 24203 RVA: 0x0016487C File Offset: 0x00162C7C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E8C RID: 24204 RVA: 0x00164884 File Offset: 0x00162C84
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
			case 3u:
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
					case 3u:
						try
						{
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
						}
						finally
						{
							((IDisposable)enumerator6).Dispose();
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

		// Token: 0x06005E8D RID: 24205 RVA: 0x00164A18 File Offset: 0x00162E18
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E8E RID: 24206 RVA: 0x00164A1F File Offset: 0x00162E1F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E8F RID: 24207 RVA: 0x00164A28 File Offset: 0x00162E28
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageOverTimeEffect.<InstantRun_Batch>c__Iterator4 <InstantRun_Batch>c__Iterator = new DamageOverTimeEffect.<InstantRun_Batch>c__Iterator4();
			<InstantRun_Batch>c__Iterator.max = max;
			<InstantRun_Batch>c__Iterator.effectsPerWearer = effectsPerWearer;
			<InstantRun_Batch>c__Iterator.rate = rate;
			return <InstantRun_Batch>c__Iterator;
		}

		// Token: 0x04005259 RID: 21081
		internal Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> <battleDamages>__0;

		// Token: 0x0400525A RID: 21082
		internal int <maxTicks>__0;

		// Token: 0x0400525B RID: 21083
		internal double max;

		// Token: 0x0400525C RID: 21084
		internal Dictionary<IBattleUnit, List<BattleHeal>> <heals>__0;

		// Token: 0x0400525D RID: 21085
		internal Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>> effectsPerWearer;

		// Token: 0x0400525E RID: 21086
		internal Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>>.Enumerator $locvar0;

		// Token: 0x0400525F RID: 21087
		internal KeyValuePair<IBattleUnit, List<IDamageInstantlyReleaseable>> <perwearer>__1;

		// Token: 0x04005260 RID: 21088
		internal List<IDamageInstantlyReleaseable>.Enumerator $locvar1;

		// Token: 0x04005261 RID: 21089
		internal IDamageInstantlyReleaseable <damageInstantlyReleaseable>__2;

		// Token: 0x04005262 RID: 21090
		internal double rate;

		// Token: 0x04005263 RID: 21091
		internal IEnumerator $locvar2;

		// Token: 0x04005264 RID: 21092
		internal object <_>__3;

		// Token: 0x04005265 RID: 21093
		internal IDisposable $locvar3;

		// Token: 0x04005266 RID: 21094
		internal Dictionary<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>>.Enumerator $locvar4;

		// Token: 0x04005267 RID: 21095
		internal List<BattleDamage> <bds>__5;

		// Token: 0x04005268 RID: 21096
		internal IEnumerator $locvar5;

		// Token: 0x04005269 RID: 21097
		internal object <_>__6;

		// Token: 0x0400526A RID: 21098
		internal IDisposable $locvar6;

		// Token: 0x0400526B RID: 21099
		internal Dictionary<IBattleUnit, List<BattleHeal>>.Enumerator $locvar7;

		// Token: 0x0400526C RID: 21100
		internal KeyValuePair<IBattleUnit, List<BattleHeal>> <heal>__7;

		// Token: 0x0400526D RID: 21101
		internal IEnumerator $locvar8;

		// Token: 0x0400526E RID: 21102
		internal object <_>__8;

		// Token: 0x0400526F RID: 21103
		internal IDisposable $locvar9;

		// Token: 0x04005270 RID: 21104
		internal object $current;

		// Token: 0x04005271 RID: 21105
		internal bool $disposing;

		// Token: 0x04005272 RID: 21106
		internal int $PC;

		// Token: 0x04005273 RID: 21107
		private DamageOverTimeEffect.<InstantRun_Batch>c__Iterator4.<InstantRun_Batch>c__AnonStoreyC $locvarA;

		// Token: 0x04005274 RID: 21108
		private DamageOverTimeEffect.<InstantRun_Batch>c__Iterator4.<InstantRun_Batch>c__AnonStoreyD $locvarC;

		// Token: 0x02000EAD RID: 3757
		private sealed class <InstantRun_Batch>c__AnonStoreyC
		{
			// Token: 0x06005EA3 RID: 24227 RVA: 0x00164A74 File Offset: 0x00162E74
			public <InstantRun_Batch>c__AnonStoreyC()
			{
			}

			// Token: 0x04005289 RID: 21129
			internal double rate;

			// Token: 0x0400528A RID: 21130
			internal double maxRate;

			// Token: 0x0400528B RID: 21131
			internal DamageOverTimeEffect.<InstantRun_Batch>c__Iterator4 <>f__ref$4;
		}

		// Token: 0x02000EAE RID: 3758
		private sealed class <InstantRun_Batch>c__AnonStoreyB
		{
			// Token: 0x06005EA4 RID: 24228 RVA: 0x00164A7C File Offset: 0x00162E7C
			public <InstantRun_Batch>c__AnonStoreyB()
			{
			}

			// Token: 0x06005EA5 RID: 24229 RVA: 0x00164A84 File Offset: 0x00162E84
			internal IEnumerable<DamagePotionValue> <>m__0(DamageHitDefinition h)
			{
				return (from p in h.Potions
				select new DamagePotionValue(this.ef.EffectSource.SourceUnit, this.ef._effectCarrier, OutputType.RealDamage, this.ef.FilterDamageValue(p.DamageRate * (double)this.remainingNumberOfTicks * this.<>f__ref$12.rate, this.<>f__ref$12.maxRate))).ToList<DamagePotionValue>();
			}

			// Token: 0x06005EA6 RID: 24230 RVA: 0x00164AA4 File Offset: 0x00162EA4
			internal DamagePotionValue <>m__1(DamageHitModuleDefinition p)
			{
				return new DamagePotionValue(this.ef.EffectSource.SourceUnit, this.ef._effectCarrier, OutputType.RealDamage, this.ef.FilterDamageValue(p.DamageRate * (double)this.remainingNumberOfTicks * this.<>f__ref$12.rate, this.<>f__ref$12.maxRate));
			}

			// Token: 0x0400528C RID: 21132
			internal ShieldBurnEffect ef;

			// Token: 0x0400528D RID: 21133
			internal int remainingNumberOfTicks;

			// Token: 0x0400528E RID: 21134
			internal DamageOverTimeEffect.<InstantRun_Batch>c__Iterator4.<InstantRun_Batch>c__AnonStoreyC <>f__ref$12;
		}

		// Token: 0x02000EAF RID: 3759
		private sealed class <InstantRun_Batch>c__AnonStoreyD
		{
			// Token: 0x06005EA7 RID: 24231 RVA: 0x00164B02 File Offset: 0x00162F02
			public <InstantRun_Batch>c__AnonStoreyD()
			{
			}

			// Token: 0x06005EA8 RID: 24232 RVA: 0x00164B0C File Offset: 0x00162F0C
			internal BattleDamage <>m__0(KeyValuePair<IBattleUnit, List<DamagePotionValue>> b)
			{
				return new BattleDamage(b.Key, new DamageOverTimeInstantSource(this.battleDamage.Key), new List<DamageComponentValue>
				{
					new DamageComponentValue(b.Value, b.Key, this.battleDamage.Key, false, false)
				});
			}

			// Token: 0x0400528F RID: 21135
			internal KeyValuePair<IBattleUnit, Dictionary<IBattleUnit, List<DamagePotionValue>>> battleDamage;
		}
	}

	// Token: 0x02000EA7 RID: 3751
	[CompilerGenerated]
	private sealed class <Spread>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E90 RID: 24208 RVA: 0x00164B62 File Offset: 0x00162F62
		[DebuggerHidden]
		public <Spread>c__Iterator5()
		{
		}

		// Token: 0x06005E91 RID: 24209 RVA: 0x00164B6C File Offset: 0x00162F6C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (this._effectSourceIdentityCode.Contains("spreaddot"))
				{
					goto IL_2E0;
				}
				code = string.Concat(new object[]
				{
					"spreaddot",
					this._style,
					this._damageType,
					fromUnit.GetId()
				});
				enumerator = tounits.GetEnumerator();
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
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					IBattleUnit unit = battleUnit;
					DamageOverTimeEffect damageOverTimeEffect = new DamageOverTimeEffect();
					damageOverTimeEffect._damageType = this._damageType;
					damageOverTimeEffect._effectSourceIdentityCode = code;
					damageOverTimeEffect.Damage = base.Damage;
					damageOverTimeEffect.EffectWearer = battleUnit;
					damageOverTimeEffect._battleEffectType = this._battleEffectType;
					damageOverTimeEffect._canBeDispersed = this._canBeDispersed;
					damageOverTimeEffect._effectSource = this.EffectSource;
					DamageOverTimeEffect damageOverTimeEffect2 = damageOverTimeEffect;
					int? num2 = (this._maxNumberOfLastingSeconds == null) ? null : new int?(3);
					damageOverTimeEffect2._maxNumberOfLastingSeconds = ((num2 == null) ? null : new float?((float)num2.Value));
					damageOverTimeEffect._style = this._style;
					damageOverTimeEffect._maxStackableInstances = new int?(1);
					damageOverTimeEffect.TurnEventsCollected = new List<AdventureEventType>();
					damageOverTimeEffect.Description = base.Description;
					damageOverTimeEffect._numberOfLastingTurns = ((this._numberOfLastingTurns == null) ? null : new int?(2));
					damageOverTimeEffect._canBeImmuned = this._canBeImmuned;
					damageOverTimeEffect._isThroughEffect = this._isThroughEffect;
					enumerator2 = unit.ApplySkillEffect(damageOverTimeEffect, false).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_2E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013C4 RID: 5060
		// (get) Token: 0x06005E92 RID: 24210 RVA: 0x00164E98 File Offset: 0x00163298
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013C5 RID: 5061
		// (get) Token: 0x06005E93 RID: 24211 RVA: 0x00164EA0 File Offset: 0x001632A0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E94 RID: 24212 RVA: 0x00164EA8 File Offset: 0x001632A8
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

		// Token: 0x06005E95 RID: 24213 RVA: 0x00164F3C File Offset: 0x0016333C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E96 RID: 24214 RVA: 0x00164F43 File Offset: 0x00163343
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E97 RID: 24215 RVA: 0x00164F4C File Offset: 0x0016334C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageOverTimeEffect.<Spread>c__Iterator5 <Spread>c__Iterator = new DamageOverTimeEffect.<Spread>c__Iterator5();
			<Spread>c__Iterator.$this = this;
			<Spread>c__Iterator.fromUnit = fromUnit;
			<Spread>c__Iterator.tounits = tounits;
			return <Spread>c__Iterator;
		}

		// Token: 0x04005275 RID: 21109
		internal IBattleUnit fromUnit;

		// Token: 0x04005276 RID: 21110
		internal string <code>__1;

		// Token: 0x04005277 RID: 21111
		internal List<IBattleUnit> tounits;

		// Token: 0x04005278 RID: 21112
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005279 RID: 21113
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x0400527A RID: 21114
		internal IEnumerator $locvar1;

		// Token: 0x0400527B RID: 21115
		internal object <_>__3;

		// Token: 0x0400527C RID: 21116
		internal IDisposable $locvar2;

		// Token: 0x0400527D RID: 21117
		internal DamageOverTimeEffect $this;

		// Token: 0x0400527E RID: 21118
		internal object $current;

		// Token: 0x0400527F RID: 21119
		internal bool $disposing;

		// Token: 0x04005280 RID: 21120
		internal int $PC;
	}
}
