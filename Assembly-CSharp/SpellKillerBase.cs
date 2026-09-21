using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000A43 RID: 2627
public class SpellKillerBase : UnitStyleConfigurationBase
{
	// Token: 0x0600478C RID: 18316 RVA: 0x001D8D6B File Offset: 0x001D716B
	public SpellKillerBase()
	{
	}

	// Token: 0x17000DFE RID: 3582
	// (get) Token: 0x0600478D RID: 18317 RVA: 0x001D8D73 File Offset: 0x001D7173
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x0600478E RID: 18318 RVA: 0x001D8D78 File Offset: 0x001D7178
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 7.5, false).SetValue(AttributeType.Agility, 18.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 7.5, false);
		}
		if (measurement.DifficultyValue <= 900.0)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 8.0, false).SetValue(AttributeType.Agility, 20.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 18.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 8.0, false).SetValue(AttributeType.Agility, 28.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 21.0, false).SetValue(AttributeType.LifeOnHit, 0.1, false).SetValue(AttributeType.HealingAbsorbRate, 0.5, false);
	}

	// Token: 0x0600478F RID: 18319 RVA: 0x001D8EA0 File Offset: 0x001D72A0
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating != 1)
		{
			list.Add(new KillingIntentEffectData
			{
				BoostRate = 0.8,
				MaxStackSize = 3,
				ExtraTarget = 2,
				IsStarEf = new bool?(false),
				PushRate = 0.2,
				TickChancePerSecond = 0.6,
				NumberOfApplicationPerTick = 4
			});
		}
		return list;
	}

	// Token: 0x06004790 RID: 18320 RVA: 0x001D8F1C File Offset: 0x001D731C
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(unit);
		if (targets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
			{
				new DamagePotionValue(unit, t, this.GetRandomElement(), 1.2),
				new DamagePotionValue(unit, t, unit.GetOutputType(), 1.2)
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
		}
		yield break;
	}

	// Token: 0x17000DFF RID: 3583
	// (get) Token: 0x06004791 RID: 18321 RVA: 0x001D8F48 File Offset: 0x001D7348
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

	// Token: 0x17000E00 RID: 3584
	// (get) Token: 0x06004792 RID: 18322 RVA: 0x001D8F64 File Offset: 0x001D7364
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

	// Token: 0x17000E01 RID: 3585
	// (get) Token: 0x06004793 RID: 18323 RVA: 0x001D8F80 File Offset: 0x001D7380
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

	// Token: 0x06004794 RID: 18324 RVA: 0x001D9030 File Offset: 0x001D7430
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			List<BattleDamage> damages = new List<BattleDamage>();
			int maxHits = (unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 5 : 4) : 3;
			for (int i = 0; i < maxHits; i++)
			{
				IBattleUnit target = opponents[UnityEngine.Random.Range(0, opponents.Count)];
				damages.Add(new BattleDamage(target, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, target, unit.GetOutputType(), 1.0)
					}, target, unit, true, false)
				}));
			}
			ReleaseableDamage releaseable = new ReleaseableDamage(damages, unit);
			IEnumerator enumerator = releaseable.Release().GetEnumerator();
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

	// Token: 0x02001064 RID: 4196
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068FC RID: 26876 RVA: 0x001D9053 File Offset: 0x001D7453
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x060068FD RID: 26877 RVA: 0x001D905C File Offset: 0x001D745C
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
					goto IL_151;
				}
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), 1.2),
					new DamagePotionValue(unit, t, unit.GetOutputType(), 1.2)
				}, t, unit, true, false), 4).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
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
			IL_151:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015EB RID: 5611
		// (get) Token: 0x060068FE RID: 26878 RVA: 0x001D91D4 File Offset: 0x001D75D4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015EC RID: 5612
		// (get) Token: 0x060068FF RID: 26879 RVA: 0x001D91DC File Offset: 0x001D75DC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006900 RID: 26880 RVA: 0x001D91E4 File Offset: 0x001D75E4
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

		// Token: 0x06006901 RID: 26881 RVA: 0x001D9254 File Offset: 0x001D7654
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006902 RID: 26882 RVA: 0x001D925B File Offset: 0x001D765B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006903 RID: 26883 RVA: 0x001D9264 File Offset: 0x001D7664
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellKillerBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new SpellKillerBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006344 RID: 25412
		internal IBattleUnit unit;

		// Token: 0x04006345 RID: 25413
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04006346 RID: 25414
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x04006347 RID: 25415
		internal IEnumerator $locvar0;

		// Token: 0x04006348 RID: 25416
		internal object <_>__2;

		// Token: 0x04006349 RID: 25417
		internal IDisposable $locvar1;

		// Token: 0x0400634A RID: 25418
		internal SpellKillerBase $this;

		// Token: 0x0400634B RID: 25419
		internal object $current;

		// Token: 0x0400634C RID: 25420
		internal bool $disposing;

		// Token: 0x0400634D RID: 25421
		internal int $PC;

		// Token: 0x0400634E RID: 25422
		private SpellKillerBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2 $locvar2;

		// Token: 0x02001066 RID: 4198
		private sealed class <HardGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x0600690C RID: 26892 RVA: 0x001D92A4 File Offset: 0x001D76A4
			public <HardGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x0600690D RID: 26893 RVA: 0x001D92AC File Offset: 0x001D76AC
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(this.unit, t, this.<>f__ref$0.$this.GetRandomElement(), 1.2),
					new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), 1.2)
				}, t, this.unit, true, false), 4).ToList<DamageComponentValue>());
			}

			// Token: 0x0400635B RID: 25435
			internal IBattleUnit unit;

			// Token: 0x0400635C RID: 25436
			internal SpellKillerBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02001065 RID: 4197
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006904 RID: 26884 RVA: 0x001D933B File Offset: 0x001D773B
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x06006905 RID: 26885 RVA: 0x001D9344 File Offset: 0x001D7744
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
				opponents = targetDf.GetTargets(unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_1FA;
				}
				damages = new List<BattleDamage>();
				maxHits = ((unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 5 : 4) : 3);
				for (int i = 0; i < maxHits; i++)
				{
					IBattleUnit target = opponents[UnityEngine.Random.Range(0, opponents.Count)];
					damages.Add(new BattleDamage(target, new NormalAttackSource(unit), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(unit, target, unit.GetOutputType(), 1.0)
						}, target, unit, true, false)
					}));
				}
				releaseable = new ReleaseableDamage(damages, unit);
				enumerator = releaseable.Release().GetEnumerator();
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
			IL_1FA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015ED RID: 5613
		// (get) Token: 0x06006906 RID: 26886 RVA: 0x001D9568 File Offset: 0x001D7968
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015EE RID: 5614
		// (get) Token: 0x06006907 RID: 26887 RVA: 0x001D9570 File Offset: 0x001D7970
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006908 RID: 26888 RVA: 0x001D9578 File Offset: 0x001D7978
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

		// Token: 0x06006909 RID: 26889 RVA: 0x001D95E8 File Offset: 0x001D79E8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600690A RID: 26890 RVA: 0x001D95EF File Offset: 0x001D79EF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600690B RID: 26891 RVA: 0x001D95F8 File Offset: 0x001D79F8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellKillerBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new SpellKillerBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x0400634F RID: 25423
		internal TargetDefinition <targetDf>__0;

		// Token: 0x04006350 RID: 25424
		internal IBattleUnit unit;

		// Token: 0x04006351 RID: 25425
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x04006352 RID: 25426
		internal List<BattleDamage> <damages>__1;

		// Token: 0x04006353 RID: 25427
		internal int <maxHits>__1;

		// Token: 0x04006354 RID: 25428
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x04006355 RID: 25429
		internal IEnumerator $locvar0;

		// Token: 0x04006356 RID: 25430
		internal object <_>__2;

		// Token: 0x04006357 RID: 25431
		internal IDisposable $locvar1;

		// Token: 0x04006358 RID: 25432
		internal object $current;

		// Token: 0x04006359 RID: 25433
		internal bool $disposing;

		// Token: 0x0400635A RID: 25434
		internal int $PC;
	}
}
