using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000A3F RID: 2623
public class PhysicalWarriorBase : UnitStyleConfigurationBase
{
	// Token: 0x0600476F RID: 18287 RVA: 0x001D652E File Offset: 0x001D492E
	public PhysicalWarriorBase()
	{
	}

	// Token: 0x17000DF2 RID: 3570
	// (get) Token: 0x06004770 RID: 18288 RVA: 0x001D6536 File Offset: 0x001D4936
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004771 RID: 18289 RVA: 0x001D653C File Offset: 0x001D493C
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 6.0, false).SetValue(AttributeType.Agility, 10.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 20.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Strength, 6.5, false).SetValue(AttributeType.Agility, 11.0, false).SetValue(AttributeType.CritRate, 0.20000000298023224, false).SetValue(AttributeType.Vitality, 20.0, false).SetValue(AttributeType.TurnStartHeal, 0.05000000074505806, false);
	}

	// Token: 0x06004772 RID: 18290 RVA: 0x001D65F4 File Offset: 0x001D49F4
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating != 1)
		{
			list.Add(new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 2
			});
		}
		return list;
	}

	// Token: 0x06004773 RID: 18291 RVA: 0x001D6648 File Offset: 0x001D4A48
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(unit);
		if (targets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
			{
				new DamagePotionValue(unit, t, this.GetRandomElement(), 1.0),
				new DamagePotionValue(unit, t, unit.GetOutputType(), 1.0)
			}, t, unit, true, false), 4).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
			IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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
			List<IBattleUnit> effectiveTargets = (from b in releaseableDamage.BattleDamages
			where b.Damages.Any((DamageComponent d) => !d.HasFullyNeutralized())
			select b.Target).Distinct<IBattleUnit>().ToList<IBattleUnit>();
			double totalRageRequired = (double)effectiveTargets.Count * 5.0;
			BattleEncounter battleEncounter = unit.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null)
			{
				double opponentMaxRage = (!unit.IsPlayer) ? battleEncounter.PlayerGauge : battleEncounter.EnemyGauge;
				double totalHeal = 0.0;
				double totalSuck = 0.0;
				bool rageTrigger = false;
				if (totalRageRequired <= opponentMaxRage)
				{
					totalSuck = totalRageRequired;
				}
				else
				{
					totalSuck = opponentMaxRage;
					rageTrigger = true;
				}
				totalHeal = totalSuck * unit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.05;
				if (unit.IsPlayer)
				{
					IEnumerator enumerator2 = battleEncounter.UpdateEnemyGauge(-totalSuck, unit).GetEnumerator();
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
				else
				{
					IEnumerator enumerator3 = battleEncounter.UpdatePlayerGauge(-totalSuck, unit).GetEnumerator();
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
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(unit, unit, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHeal,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, unit);
				IEnumerator enumerator4 = releaseableHeal.Release().GetEnumerator();
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
				if (rageTrigger)
				{
					IEnumerator enumerator5 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(unit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Multiplication,
							Value = 0.4,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						},
						new AttributeModifier
						{
							AttributeType = unit.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = 0.4,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "physicalwarriorproc", new int?(5), null, new int?(3), false, true, false), false).GetEnumerator();
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
					IEnumerator enumerator6 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(unit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Multiplication,
							Value = 0.4,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						},
						new AttributeModifier
						{
							AttributeType = unit.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = 0.4,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "physicalwarriorproc", new int?(5), null, new int?(3), false, true, false), false).GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							object _6 = enumerator6.Current;
							yield return _6;
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
			}
		}
		yield break;
	}

	// Token: 0x17000DF3 RID: 3571
	// (get) Token: 0x06004774 RID: 18292 RVA: 0x001D6674 File Offset: 0x001D4A74
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Sword,
				ResourceCategory.Knife,
				ResourceCategory.Axe,
				ResourceCategory.Spear
			};
		}
	}

	// Token: 0x17000DF4 RID: 3572
	// (get) Token: 0x06004775 RID: 18293 RVA: 0x001D66A4 File Offset: 0x001D4AA4
	public override List<ResourceCategory> ArmorCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Plate
			};
		}
	}

	// Token: 0x17000DF5 RID: 3573
	// (get) Token: 0x06004776 RID: 18294 RVA: 0x001D66C0 File Offset: 0x001D4AC0
	public override List<ResourceType> SuitableAccessories
	{
		get
		{
			return new List<ResourceType>
			{
				ResourceType.FameOne,
				ResourceType.FameTwo,
				ResourceType.FameThree,
				ResourceType.FameFour,
				ResourceType.PhenixOne,
				ResourceType.PhenixTwo,
				ResourceType.DragonSealOne,
				ResourceType.DragonSealTwo,
				ResourceType.DragonSealThree,
				ResourceType.DragonSealFour,
				ResourceType.SoulSealOne,
				ResourceType.SoulSealTwo,
				ResourceType.SoulSealThree,
				ResourceType.SoulSealFour
			};
		}
	}

	// Token: 0x06004777 RID: 18295 RVA: 0x001D6770 File Offset: 0x001D4B70
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			double damageRate = (unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 0.9 : 0.5;
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), damageRate)
				}, o, unit, true, false),
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), damageRate)
				}, o, unit, true, false),
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), damageRate)
				}, o, unit, true, false)
			} : new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), damageRate)
				}, o, unit, true, false),
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), damageRate)
				}, o, unit, true, false),
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), damageRate)
				}, o, unit, true, false),
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), damageRate)
				}, o, unit, true, false)
			})).ToList<BattleDamage>(), unit);
			IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x02001058 RID: 4184
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068BD RID: 26813 RVA: 0x001D6793 File Offset: 0x001D4B93
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x060068BE RID: 26814 RVA: 0x001D679C File Offset: 0x001D4B9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(unit);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_82C;
				}
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), 1.0),
					new DamagePotionValue(unit, t, unit.GetOutputType(), 1.0)
				}, t, unit, true, false), 4).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_2FE;
			case 3u:
				goto IL_3B0;
			case 4u:
				Block_12:
				try
				{
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
				if (rageTrigger)
				{
					enumerator5 = <HardGradeAttackLogic>c__AnonStorey.unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<HardGradeAttackLogic>c__AnonStorey.unit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Multiplication,
							Value = 0.4,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						},
						new AttributeModifier
						{
							AttributeType = <HardGradeAttackLogic>c__AnonStorey.unit.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = 0.4,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "physicalwarriorproc", new int?(5), null, new int?(3), false, true, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_14;
				}
				goto IL_82C;
			case 5u:
				goto IL_63B;
			case 6u:
				goto IL_7AA;
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
			effectiveTargets = (from b in releaseableDamage.BattleDamages
			where b.Damages.Any((DamageComponent d) => !d.HasFullyNeutralized())
			select b.Target).Distinct<IBattleUnit>().ToList<IBattleUnit>();
			totalRageRequired = (double)effectiveTargets.Count * 5.0;
			battleEncounter = (<HardGradeAttackLogic>c__AnonStorey.unit.CurrentEncounter as BattleEncounter);
			if (battleEncounter == null)
			{
				goto IL_82C;
			}
			opponentMaxRage = ((!<HardGradeAttackLogic>c__AnonStorey.unit.IsPlayer) ? battleEncounter.PlayerGauge : battleEncounter.EnemyGauge);
			totalHeal = 0.0;
			totalSuck = 0.0;
			rageTrigger = false;
			if (totalRageRequired <= opponentMaxRage)
			{
				totalSuck = totalRageRequired;
			}
			else
			{
				totalSuck = opponentMaxRage;
				rageTrigger = true;
			}
			totalHeal = totalSuck * <HardGradeAttackLogic>c__AnonStorey.unit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.05;
			if (!<HardGradeAttackLogic>c__AnonStorey.unit.IsPlayer)
			{
				enumerator3 = battleEncounter.UpdatePlayerGauge(-totalSuck, <HardGradeAttackLogic>c__AnonStorey.unit).GetEnumerator();
				num = 4294967293u;
				goto Block_11;
			}
			enumerator2 = battleEncounter.UpdateEnemyGauge(-totalSuck, <HardGradeAttackLogic>c__AnonStorey.unit).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2FE:
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
			goto IL_432;
			Block_11:
			try
			{
				IL_3B0:
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
			IL_432:
			releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(<HardGradeAttackLogic>c__AnonStorey.unit, <HardGradeAttackLogic>c__AnonStorey.unit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = totalHeal,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)
			}, <HardGradeAttackLogic>c__AnonStorey.unit);
			enumerator4 = releaseableHeal.Release().GetEnumerator();
			num = 4294967293u;
			goto Block_12;
			Block_14:
			try
			{
				IL_63B:
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
			enumerator6 = <HardGradeAttackLogic>c__AnonStorey.unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<HardGradeAttackLogic>c__AnonStorey.unit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Multiplication,
					Value = 0.4,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = <HardGradeAttackLogic>c__AnonStorey.unit.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					Value = 0.4,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			}, "physicalwarriorproc", new int?(5), null, new int?(3), false, true, false), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_7AA:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_6 = enumerator6.Current;
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
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			IL_82C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015DF RID: 5599
		// (get) Token: 0x060068BF RID: 26815 RVA: 0x001D702C File Offset: 0x001D542C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015E0 RID: 5600
		// (get) Token: 0x060068C0 RID: 26816 RVA: 0x001D7034 File Offset: 0x001D5434
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068C1 RID: 26817 RVA: 0x001D703C File Offset: 0x001D543C
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
			}
		}

		// Token: 0x060068C2 RID: 26818 RVA: 0x001D71E8 File Offset: 0x001D55E8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068C3 RID: 26819 RVA: 0x001D71EF File Offset: 0x001D55EF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068C4 RID: 26820 RVA: 0x001D71F8 File Offset: 0x001D55F8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalWarriorBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new PhysicalWarriorBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x060068C5 RID: 26821 RVA: 0x001D7238 File Offset: 0x001D5638
		private static bool <>m__0(BattleDamage b)
		{
			return b.Damages.Any((DamageComponent d) => !d.HasFullyNeutralized());
		}

		// Token: 0x060068C6 RID: 26822 RVA: 0x001D7262 File Offset: 0x001D5662
		private static IBattleUnit <>m__1(BattleDamage b)
		{
			return b.Target;
		}

		// Token: 0x060068C7 RID: 26823 RVA: 0x001D726A File Offset: 0x001D566A
		private static bool <>m__2(DamageComponent d)
		{
			return !d.HasFullyNeutralized();
		}

		// Token: 0x040062D1 RID: 25297
		internal IBattleUnit unit;

		// Token: 0x040062D2 RID: 25298
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x040062D3 RID: 25299
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x040062D4 RID: 25300
		internal IEnumerator $locvar0;

		// Token: 0x040062D5 RID: 25301
		internal object <_>__2;

		// Token: 0x040062D6 RID: 25302
		internal IDisposable $locvar1;

		// Token: 0x040062D7 RID: 25303
		internal List<IBattleUnit> <effectiveTargets>__1;

		// Token: 0x040062D8 RID: 25304
		internal double <totalRageRequired>__1;

		// Token: 0x040062D9 RID: 25305
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x040062DA RID: 25306
		internal double <opponentMaxRage>__3;

		// Token: 0x040062DB RID: 25307
		internal double <totalHeal>__3;

		// Token: 0x040062DC RID: 25308
		internal double <totalSuck>__3;

		// Token: 0x040062DD RID: 25309
		internal bool <rageTrigger>__3;

		// Token: 0x040062DE RID: 25310
		internal IEnumerator $locvar2;

		// Token: 0x040062DF RID: 25311
		internal object <_>__4;

		// Token: 0x040062E0 RID: 25312
		internal IDisposable $locvar3;

		// Token: 0x040062E1 RID: 25313
		internal IEnumerator $locvar4;

		// Token: 0x040062E2 RID: 25314
		internal object <_>__5;

		// Token: 0x040062E3 RID: 25315
		internal IDisposable $locvar5;

		// Token: 0x040062E4 RID: 25316
		internal ReleaseableHeal <releaseableHeal>__3;

		// Token: 0x040062E5 RID: 25317
		internal IEnumerator $locvar6;

		// Token: 0x040062E6 RID: 25318
		internal object <_>__6;

		// Token: 0x040062E7 RID: 25319
		internal IDisposable $locvar7;

		// Token: 0x040062E8 RID: 25320
		internal IEnumerator $locvar8;

		// Token: 0x040062E9 RID: 25321
		internal object <_>__7;

		// Token: 0x040062EA RID: 25322
		internal IDisposable $locvar9;

		// Token: 0x040062EB RID: 25323
		internal IEnumerator $locvarA;

		// Token: 0x040062EC RID: 25324
		internal object <_>__8;

		// Token: 0x040062ED RID: 25325
		internal IDisposable $locvarB;

		// Token: 0x040062EE RID: 25326
		internal PhysicalWarriorBase $this;

		// Token: 0x040062EF RID: 25327
		internal object $current;

		// Token: 0x040062F0 RID: 25328
		internal bool $disposing;

		// Token: 0x040062F1 RID: 25329
		internal int $PC;

		// Token: 0x040062F2 RID: 25330
		private PhysicalWarriorBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2 $locvarC;

		// Token: 0x040062F3 RID: 25331
		private static Func<BattleDamage, bool> <>f__am$cache0;

		// Token: 0x040062F4 RID: 25332
		private static Func<BattleDamage, IBattleUnit> <>f__am$cache1;

		// Token: 0x040062F5 RID: 25333
		private static Func<DamageComponent, bool> <>f__am$cache2;

		// Token: 0x0200105A RID: 4186
		private sealed class <HardGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x060068D0 RID: 26832 RVA: 0x001D7275 File Offset: 0x001D5675
			public <HardGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x060068D1 RID: 26833 RVA: 0x001D7280 File Offset: 0x001D5680
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(this.unit, t, this.<>f__ref$0.$this.GetRandomElement(), 1.0),
					new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), 1.0)
				}, t, this.unit, true, false), 4).ToList<DamageComponentValue>());
			}

			// Token: 0x04006302 RID: 25346
			internal IBattleUnit unit;

			// Token: 0x04006303 RID: 25347
			internal PhysicalWarriorBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02001059 RID: 4185
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068C8 RID: 26824 RVA: 0x001D730F File Offset: 0x001D570F
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x060068C9 RID: 26825 RVA: 0x001D7318 File Offset: 0x001D5718
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<NormalGradeAttackLogic>c__AnonStorey = new PhysicalWarriorBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey3();
				<NormalGradeAttackLogic>c__AnonStorey.unit = unit;
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
				opponents = targetDf.GetTargets(<NormalGradeAttackLogic>c__AnonStorey.unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_1B6;
				}
				double damageRate = (<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 0.9 : 0.5;
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(<NormalGradeAttackLogic>c__AnonStorey.unit), (<NormalGradeAttackLogic>c__AnonStorey.unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalGradeAttackLogic>c__AnonStorey.unit, o, <NormalGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), damageRate)
					}, o, <NormalGradeAttackLogic>c__AnonStorey.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalGradeAttackLogic>c__AnonStorey.unit, o, <NormalGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), damageRate)
					}, o, <NormalGradeAttackLogic>c__AnonStorey.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalGradeAttackLogic>c__AnonStorey.unit, o, <NormalGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), damageRate)
					}, o, <NormalGradeAttackLogic>c__AnonStorey.unit, true, false)
				} : new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalGradeAttackLogic>c__AnonStorey.unit, o, <NormalGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), damageRate)
					}, o, <NormalGradeAttackLogic>c__AnonStorey.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalGradeAttackLogic>c__AnonStorey.unit, o, <NormalGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), damageRate)
					}, o, <NormalGradeAttackLogic>c__AnonStorey.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalGradeAttackLogic>c__AnonStorey.unit, o, <NormalGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), damageRate)
					}, o, <NormalGradeAttackLogic>c__AnonStorey.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalGradeAttackLogic>c__AnonStorey.unit, o, <NormalGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), damageRate)
					}, o, <NormalGradeAttackLogic>c__AnonStorey.unit, true, false)
				})).ToList<BattleDamage>(), <NormalGradeAttackLogic>c__AnonStorey.unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			IL_1B6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015E1 RID: 5601
		// (get) Token: 0x060068CA RID: 26826 RVA: 0x001D74F8 File Offset: 0x001D58F8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015E2 RID: 5602
		// (get) Token: 0x060068CB RID: 26827 RVA: 0x001D7500 File Offset: 0x001D5900
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068CC RID: 26828 RVA: 0x001D7508 File Offset: 0x001D5908
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

		// Token: 0x060068CD RID: 26829 RVA: 0x001D7578 File Offset: 0x001D5978
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068CE RID: 26830 RVA: 0x001D757F File Offset: 0x001D597F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068CF RID: 26831 RVA: 0x001D7588 File Offset: 0x001D5988
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalWarriorBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new PhysicalWarriorBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x040062F6 RID: 25334
		internal TargetDefinition <targetDf>__0;

		// Token: 0x040062F7 RID: 25335
		internal IBattleUnit unit;

		// Token: 0x040062F8 RID: 25336
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x040062F9 RID: 25337
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x040062FA RID: 25338
		internal IEnumerator $locvar0;

		// Token: 0x040062FB RID: 25339
		internal object <_>__2;

		// Token: 0x040062FC RID: 25340
		internal IDisposable $locvar1;

		// Token: 0x040062FD RID: 25341
		internal object $current;

		// Token: 0x040062FE RID: 25342
		internal bool $disposing;

		// Token: 0x040062FF RID: 25343
		internal int $PC;

		// Token: 0x04006300 RID: 25344
		private PhysicalWarriorBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey3 $locvar2;

		// Token: 0x04006301 RID: 25345
		private PhysicalWarriorBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey4 $locvar3;

		// Token: 0x0200105B RID: 4187
		private sealed class <NormalGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x060068D2 RID: 26834 RVA: 0x001D75BC File Offset: 0x001D59BC
			public <NormalGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x04006304 RID: 25348
			internal IBattleUnit unit;
		}

		// Token: 0x0200105C RID: 4188
		private sealed class <NormalGradeAttackLogic>c__AnonStorey4
		{
			// Token: 0x060068D3 RID: 26835 RVA: 0x001D75C4 File Offset: 0x001D59C4
			public <NormalGradeAttackLogic>c__AnonStorey4()
			{
			}

			// Token: 0x060068D4 RID: 26836 RVA: 0x001D75CC File Offset: 0x001D59CC
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.<>f__ref$3.unit), (this.<>f__ref$3.unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.unit, o, this.<>f__ref$3.unit.GetOutputType(), this.damageRate)
					}, o, this.<>f__ref$3.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.unit, o, this.<>f__ref$3.unit.GetOutputType(), this.damageRate)
					}, o, this.<>f__ref$3.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.unit, o, this.<>f__ref$3.unit.GetOutputType(), this.damageRate)
					}, o, this.<>f__ref$3.unit, true, false)
				} : new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.unit, o, this.<>f__ref$3.unit.GetOutputType(), this.damageRate)
					}, o, this.<>f__ref$3.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.unit, o, this.<>f__ref$3.unit.GetOutputType(), this.damageRate)
					}, o, this.<>f__ref$3.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.unit, o, this.<>f__ref$3.unit.GetOutputType(), this.damageRate)
					}, o, this.<>f__ref$3.unit, true, false),
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.unit, o, this.<>f__ref$3.unit.GetOutputType(), this.damageRate)
					}, o, this.<>f__ref$3.unit, true, false)
				});
			}

			// Token: 0x04006305 RID: 25349
			internal double damageRate;

			// Token: 0x04006306 RID: 25350
			internal PhysicalWarriorBase.<NormalGradeAttackLogic>c__Iterator1 <>f__ref$1;

			// Token: 0x04006307 RID: 25351
			internal PhysicalWarriorBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey3 <>f__ref$3;
		}
	}
}
