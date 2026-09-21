using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000A45 RID: 2629
public class SpellWarriorBase : UnitStyleConfigurationBase
{
	// Token: 0x0600479E RID: 18334 RVA: 0x001DA5D2 File Offset: 0x001D89D2
	public SpellWarriorBase()
	{
	}

	// Token: 0x17000E06 RID: 3590
	// (get) Token: 0x0600479F RID: 18335 RVA: 0x001DA5DA File Offset: 0x001D89DA
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x060047A0 RID: 18336 RVA: 0x001DA5E0 File Offset: 0x001D89E0
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 6.0, false).SetValue(AttributeType.Agility, 10.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 15.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 7.0, false).SetValue(AttributeType.Agility, 16.0, false).SetValue(AttributeType.CritRate, 0.25, false).SetValue(AttributeType.Vitality, 27.0, false).SetValue(AttributeType.TurnStartHeal, 0.019999999552965164, false);
	}

	// Token: 0x060047A1 RID: 18337 RVA: 0x001DA698 File Offset: 0x001D8A98
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating > 1)
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
		if (measurement.StarRating > 1 && measurement.DifficultyValue > 40.0)
		{
			list.Add(new FirstHandEffectData
			{
				IsStarEf = new bool?(false),
				StartProgress = 0.8
			});
		}
		return list;
	}

	// Token: 0x060047A2 RID: 18338 RVA: 0x001DA734 File Offset: 0x001D8B34
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)).GetTargets(unit);
		if (targets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
			{
				new DamagePotionValue(unit, t, this.GetRandomElement(), 2.5),
				new DamagePotionValue(unit, t, unit.GetOutputType(), 2.5)
			}, t, unit, true, false), 2).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
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
			double? totalExcessiveDamage = releaseableDamage.BattleDamages.Sum((BattleDamage d) => d.Damages.Sum((DamageComponent dd) => dd.ExceededDamageValue));
			if (totalExcessiveDamage != null && (totalExcessiveDamage != null && totalExcessiveDamage.GetValueOrDefault() > 0.0))
			{
				List<IBattleUnit> extraTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
				if (extraTargets.Any<IBattleUnit>())
				{
					ReleaseableDamage extraDamage = new ReleaseableDamage((from t in extraTargets
					select new BattleDamage(t, new NormalAttackSource(unit), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(t, unit, OutputType.RealDamage, totalExcessiveDamage.Value)
						}, t, unit, true, false)
					})).ToList<BattleDamage>(), unit);
					IEnumerator enumerator2 = extraDamage.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x17000E07 RID: 3591
	// (get) Token: 0x060047A3 RID: 18339 RVA: 0x001DA760 File Offset: 0x001D8B60
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Staff
			};
		}
	}

	// Token: 0x17000E08 RID: 3592
	// (get) Token: 0x060047A4 RID: 18340 RVA: 0x001DA77C File Offset: 0x001D8B7C
	public override List<ResourceCategory> ArmorCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Robe
			};
		}
	}

	// Token: 0x17000E09 RID: 3593
	// (get) Token: 0x060047A5 RID: 18341 RVA: 0x001DA798 File Offset: 0x001D8B98
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

	// Token: 0x060047A6 RID: 18342 RVA: 0x001DA848 File Offset: 0x001D8C48
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null);
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1.5 : 1.0)
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

	// Token: 0x0200106C RID: 4204
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006924 RID: 26916 RVA: 0x001DA86B File Offset: 0x001D8C6B
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x06006925 RID: 26917 RVA: 0x001DA874 File Offset: 0x001D8C74
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				<HardGradeAttackLogic>c__AnonStorey = new SpellWarriorBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2();
				<HardGradeAttackLogic>c__AnonStorey.unit = unit;
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)).GetTargets(<HardGradeAttackLogic>c__AnonStorey.unit);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_2FF;
				}
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new NormalAttackSource(<HardGradeAttackLogic>c__AnonStorey.unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(<HardGradeAttackLogic>c__AnonStorey.unit, t, this.GetRandomElement(), 2.5),
					new DamagePotionValue(<HardGradeAttackLogic>c__AnonStorey.unit, t, <HardGradeAttackLogic>c__AnonStorey.unit.GetOutputType(), 2.5)
				}, t, <HardGradeAttackLogic>c__AnonStorey.unit, true, false), 2).ToList<DamageComponentValue>())).ToList<BattleDamage>(), <HardGradeAttackLogic>c__AnonStorey.unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_27D;
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
			<HardGradeAttackLogic>c__AnonStorey2.totalExcessiveDamage = releaseableDamage.BattleDamages.Sum((BattleDamage d) => d.Damages.Sum((DamageComponent dd) => dd.ExceededDamageValue));
			if (<HardGradeAttackLogic>c__AnonStorey2.totalExcessiveDamage == null || (<HardGradeAttackLogic>c__AnonStorey2.totalExcessiveDamage == null || <HardGradeAttackLogic>c__AnonStorey2.totalExcessiveDamage.GetValueOrDefault() <= 0.0))
			{
				goto IL_2FF;
			}
			extraTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(<HardGradeAttackLogic>c__AnonStorey.unit);
			if (!extraTargets.Any<IBattleUnit>())
			{
				goto IL_2FF;
			}
			extraDamage = new ReleaseableDamage((from t in extraTargets
			select new BattleDamage(t, new NormalAttackSource(<HardGradeAttackLogic>c__AnonStorey2.<>f__ref$2.unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					DamagePotionValue.CreateRawValuedDamageComponent(t, <HardGradeAttackLogic>c__AnonStorey2.<>f__ref$2.unit, OutputType.RealDamage, <HardGradeAttackLogic>c__AnonStorey2.totalExcessiveDamage.Value)
				}, t, <HardGradeAttackLogic>c__AnonStorey2.<>f__ref$2.unit, true, false)
			})).ToList<BattleDamage>(), <HardGradeAttackLogic>c__AnonStorey.unit);
			enumerator2 = extraDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_27D:
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
			IL_2FF:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015F3 RID: 5619
		// (get) Token: 0x06006926 RID: 26918 RVA: 0x001DABA8 File Offset: 0x001D8FA8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015F4 RID: 5620
		// (get) Token: 0x06006927 RID: 26919 RVA: 0x001DABB0 File Offset: 0x001D8FB0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006928 RID: 26920 RVA: 0x001DABB8 File Offset: 0x001D8FB8
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

		// Token: 0x06006929 RID: 26921 RVA: 0x001DAC68 File Offset: 0x001D9068
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600692A RID: 26922 RVA: 0x001DAC6F File Offset: 0x001D906F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600692B RID: 26923 RVA: 0x001DAC78 File Offset: 0x001D9078
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellWarriorBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new SpellWarriorBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x0600692C RID: 26924 RVA: 0x001DACB8 File Offset: 0x001D90B8
		private static double? <>m__0(BattleDamage d)
		{
			return d.Damages.Sum((DamageComponent dd) => dd.ExceededDamageValue);
		}

		// Token: 0x0600692D RID: 26925 RVA: 0x001DACE2 File Offset: 0x001D90E2
		private static double? <>m__1(DamageComponent dd)
		{
			return dd.ExceededDamageValue;
		}

		// Token: 0x0400638C RID: 25484
		internal IBattleUnit unit;

		// Token: 0x0400638D RID: 25485
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x0400638E RID: 25486
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400638F RID: 25487
		internal IEnumerator $locvar0;

		// Token: 0x04006390 RID: 25488
		internal object <_>__2;

		// Token: 0x04006391 RID: 25489
		internal IDisposable $locvar1;

		// Token: 0x04006392 RID: 25490
		internal List<IBattleUnit> <extraTargets>__3;

		// Token: 0x04006393 RID: 25491
		internal ReleaseableDamage <extraDamage>__4;

		// Token: 0x04006394 RID: 25492
		internal IEnumerator $locvar2;

		// Token: 0x04006395 RID: 25493
		internal object <_>__5;

		// Token: 0x04006396 RID: 25494
		internal IDisposable $locvar3;

		// Token: 0x04006397 RID: 25495
		internal SpellWarriorBase $this;

		// Token: 0x04006398 RID: 25496
		internal object $current;

		// Token: 0x04006399 RID: 25497
		internal bool $disposing;

		// Token: 0x0400639A RID: 25498
		internal int $PC;

		// Token: 0x0400639B RID: 25499
		private SpellWarriorBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2 $locvar4;

		// Token: 0x0400639C RID: 25500
		private SpellWarriorBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey3 $locvar5;

		// Token: 0x0400639D RID: 25501
		private static Func<BattleDamage, double?> <>f__am$cache0;

		// Token: 0x0400639E RID: 25502
		private static Func<DamageComponent, double?> <>f__am$cache1;

		// Token: 0x0200106E RID: 4206
		private sealed class <HardGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x06006936 RID: 26934 RVA: 0x001DACEA File Offset: 0x001D90EA
			public <HardGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x040063AA RID: 25514
			internal IBattleUnit unit;
		}

		// Token: 0x0200106F RID: 4207
		private sealed class <HardGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x06006937 RID: 26935 RVA: 0x001DACF2 File Offset: 0x001D90F2
			public <HardGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x06006938 RID: 26936 RVA: 0x001DACFC File Offset: 0x001D90FC
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.<>f__ref$2.unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(this.<>f__ref$2.unit, t, this.<>f__ref$0.$this.GetRandomElement(), 2.5),
					new DamagePotionValue(this.<>f__ref$2.unit, t, this.<>f__ref$2.unit.GetOutputType(), 2.5)
				}, t, this.<>f__ref$2.unit, true, false), 2).ToList<DamageComponentValue>());
			}

			// Token: 0x06006939 RID: 26937 RVA: 0x001DADA4 File Offset: 0x001D91A4
			internal BattleDamage <>m__1(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.<>f__ref$2.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(t, this.<>f__ref$2.unit, OutputType.RealDamage, this.totalExcessiveDamage.Value)
					}, t, this.<>f__ref$2.unit, true, false)
				});
			}

			// Token: 0x040063AB RID: 25515
			internal double? totalExcessiveDamage;

			// Token: 0x040063AC RID: 25516
			internal SpellWarriorBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;

			// Token: 0x040063AD RID: 25517
			internal SpellWarriorBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2 <>f__ref$2;
		}
	}

	// Token: 0x0200106D RID: 4205
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600692E RID: 26926 RVA: 0x001DAE11 File Offset: 0x001D9211
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x0600692F RID: 26927 RVA: 0x001DAE1C File Offset: 0x001D921C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null);
				opponents = targetDf.GetTargets(unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_154;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1.5 : 1.0)
					}, o, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
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
			IL_154:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015F5 RID: 5621
		// (get) Token: 0x06006930 RID: 26928 RVA: 0x001DAF98 File Offset: 0x001D9398
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015F6 RID: 5622
		// (get) Token: 0x06006931 RID: 26929 RVA: 0x001DAFA0 File Offset: 0x001D93A0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006932 RID: 26930 RVA: 0x001DAFA8 File Offset: 0x001D93A8
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

		// Token: 0x06006933 RID: 26931 RVA: 0x001DB018 File Offset: 0x001D9418
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006934 RID: 26932 RVA: 0x001DB01F File Offset: 0x001D941F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006935 RID: 26933 RVA: 0x001DB028 File Offset: 0x001D9428
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellWarriorBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new SpellWarriorBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x0400639F RID: 25503
		internal TargetDefinition <targetDf>__0;

		// Token: 0x040063A0 RID: 25504
		internal IBattleUnit unit;

		// Token: 0x040063A1 RID: 25505
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x040063A2 RID: 25506
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x040063A3 RID: 25507
		internal IEnumerator $locvar0;

		// Token: 0x040063A4 RID: 25508
		internal object <_>__2;

		// Token: 0x040063A5 RID: 25509
		internal IDisposable $locvar1;

		// Token: 0x040063A6 RID: 25510
		internal object $current;

		// Token: 0x040063A7 RID: 25511
		internal bool $disposing;

		// Token: 0x040063A8 RID: 25512
		internal int $PC;

		// Token: 0x040063A9 RID: 25513
		private SpellWarriorBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey4 $locvar2;

		// Token: 0x02001070 RID: 4208
		private sealed class <NormalGradeAttackLogic>c__AnonStorey4
		{
			// Token: 0x0600693A RID: 26938 RVA: 0x001DB05C File Offset: 0x001D945C
			public <NormalGradeAttackLogic>c__AnonStorey4()
			{
			}

			// Token: 0x0600693B RID: 26939 RVA: 0x001DB064 File Offset: 0x001D9464
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), (this.unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1.5 : 1.0)
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x040063AE RID: 25518
			internal IBattleUnit unit;
		}
	}
}
