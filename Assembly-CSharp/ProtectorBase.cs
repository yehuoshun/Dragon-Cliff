using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000A40 RID: 2624
public class ProtectorBase : UnitStyleConfigurationBase
{
	// Token: 0x06004778 RID: 18296 RVA: 0x001D7838 File Offset: 0x001D5C38
	public ProtectorBase()
	{
	}

	// Token: 0x17000DF6 RID: 3574
	// (get) Token: 0x06004779 RID: 18297 RVA: 0x001D7840 File Offset: 0x001D5C40
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.Protector;
		}
	}

	// Token: 0x0600477A RID: 18298 RVA: 0x001D7844 File Offset: 0x001D5C44
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 3.0, false).SetValue(AttributeType.Agility, 10.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 13.0, false).SetValue(AttributeType.TauntOnHit, 0.800000011920929, false);
		}
		if (measurement.DifficultyValue <= 900.0)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 4.0, false).SetValue(AttributeType.Agility, 12.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 30.0, false).SetValue(AttributeType.TauntOnHit, 0.800000011920929, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Strength, 4.0, false).SetValue(AttributeType.Agility, 12.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 50.0, false).SetValue(AttributeType.TauntOnHit, 0.800000011920929, false);
	}

	// Token: 0x0600477B RID: 18299 RVA: 0x001D7980 File Offset: 0x001D5D80
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating != 1)
		{
			list.Add(new ProtectorsPrideEffectData
			{
				ShieldCount = 2,
				TauntChance = 1.0
			});
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

	// Token: 0x0600477C RID: 18300 RVA: 0x001D79F8 File Offset: 0x001D5DF8
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.OutputCapacity, OrderingType.Desc, new int?(1)).GetTargets(unit);
		if (targets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), 1.2),
					new DamagePotionValue(unit, t, unit.GetOutputType(), 1.2)
				}, t, unit, true, false)
			})).ToList<BattleDamage>(), unit);
			foreach (IBattleUnit battleUnit in targets)
			{
				if (battleUnit.IsAliveInBattle() && (double)UnityEngine.Random.value <= 0.7)
				{
					IEnumerator enumerator2 = LockTimeEffect.AddStunSeconds(battleUnit, 2f, unit, false).GetEnumerator();
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
			IEnumerator enumerator3 = releaseableDamage.Release().GetEnumerator();
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

	// Token: 0x17000DF7 RID: 3575
	// (get) Token: 0x0600477D RID: 18301 RVA: 0x001D7A24 File Offset: 0x001D5E24
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Sword,
				ResourceCategory.Axe,
				ResourceCategory.Spear
			};
		}
	}

	// Token: 0x17000DF8 RID: 3576
	// (get) Token: 0x0600477E RID: 18302 RVA: 0x001D7A50 File Offset: 0x001D5E50
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

	// Token: 0x17000DF9 RID: 3577
	// (get) Token: 0x0600477F RID: 18303 RVA: 0x001D7A6C File Offset: 0x001D5E6C
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

	// Token: 0x06004780 RID: 18304 RVA: 0x001D7B1C File Offset: 0x001D5F1C
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(3));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1.0 : 1.5)
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

	// Token: 0x0200105D RID: 4189
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068D5 RID: 26837 RVA: 0x001D7B3F File Offset: 0x001D5F3F
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x060068D6 RID: 26838 RVA: 0x001D7B48 File Offset: 0x001D5F48
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.OutputCapacity, OrderingType.Desc, new int?(1)).GetTargets(unit);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_286;
				}
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, t, this.GetRandomElement(), 1.2),
						new DamagePotionValue(unit, t, unit.GetOutputType(), 1.2)
					}, t, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_204;
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
				while (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					if (battleUnit.IsAliveInBattle() && (double)UnityEngine.Random.value <= 0.7)
					{
						enumerator2 = LockTimeEffect.AddStunSeconds(battleUnit, 2f, <HardGradeAttackLogic>c__AnonStorey.unit, false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
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
			enumerator3 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_204:
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
			IL_286:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015E3 RID: 5603
		// (get) Token: 0x060068D7 RID: 26839 RVA: 0x001D7E34 File Offset: 0x001D6234
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015E4 RID: 5604
		// (get) Token: 0x060068D8 RID: 26840 RVA: 0x001D7E3C File Offset: 0x001D623C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068D9 RID: 26841 RVA: 0x001D7E44 File Offset: 0x001D6244
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

		// Token: 0x060068DA RID: 26842 RVA: 0x001D7F18 File Offset: 0x001D6318
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068DB RID: 26843 RVA: 0x001D7F1F File Offset: 0x001D631F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068DC RID: 26844 RVA: 0x001D7F28 File Offset: 0x001D6328
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ProtectorBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new ProtectorBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006308 RID: 25352
		internal IBattleUnit unit;

		// Token: 0x04006309 RID: 25353
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x0400630A RID: 25354
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400630B RID: 25355
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x0400630C RID: 25356
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x0400630D RID: 25357
		internal IEnumerator $locvar1;

		// Token: 0x0400630E RID: 25358
		internal object <_>__3;

		// Token: 0x0400630F RID: 25359
		internal IDisposable $locvar2;

		// Token: 0x04006310 RID: 25360
		internal IEnumerator $locvar3;

		// Token: 0x04006311 RID: 25361
		internal object <_>__4;

		// Token: 0x04006312 RID: 25362
		internal IDisposable $locvar4;

		// Token: 0x04006313 RID: 25363
		internal ProtectorBase $this;

		// Token: 0x04006314 RID: 25364
		internal object $current;

		// Token: 0x04006315 RID: 25365
		internal bool $disposing;

		// Token: 0x04006316 RID: 25366
		internal int $PC;

		// Token: 0x04006317 RID: 25367
		private ProtectorBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2 $locvar5;

		// Token: 0x0200105F RID: 4191
		private sealed class <HardGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x060068E5 RID: 26853 RVA: 0x001D7F68 File Offset: 0x001D6368
			public <HardGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x060068E6 RID: 26854 RVA: 0x001D7F70 File Offset: 0x001D6370
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, t, this.<>f__ref$0.$this.GetRandomElement(), 1.2),
						new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), 1.2)
					}, t, this.unit, true, false)
				});
			}

			// Token: 0x04006323 RID: 25379
			internal IBattleUnit unit;

			// Token: 0x04006324 RID: 25380
			internal ProtectorBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x0200105E RID: 4190
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068DD RID: 26845 RVA: 0x001D8001 File Offset: 0x001D6401
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x060068DE RID: 26846 RVA: 0x001D800C File Offset: 0x001D640C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(3));
				opponents = targetDf.GetTargets(unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_151;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1.0 : 1.5)
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
			IL_151:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015E5 RID: 5605
		// (get) Token: 0x060068DF RID: 26847 RVA: 0x001D8184 File Offset: 0x001D6584
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015E6 RID: 5606
		// (get) Token: 0x060068E0 RID: 26848 RVA: 0x001D818C File Offset: 0x001D658C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068E1 RID: 26849 RVA: 0x001D8194 File Offset: 0x001D6594
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

		// Token: 0x060068E2 RID: 26850 RVA: 0x001D8204 File Offset: 0x001D6604
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068E3 RID: 26851 RVA: 0x001D820B File Offset: 0x001D660B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068E4 RID: 26852 RVA: 0x001D8214 File Offset: 0x001D6614
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ProtectorBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new ProtectorBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006318 RID: 25368
		internal TargetDefinition <targetDf>__0;

		// Token: 0x04006319 RID: 25369
		internal IBattleUnit unit;

		// Token: 0x0400631A RID: 25370
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x0400631B RID: 25371
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400631C RID: 25372
		internal IEnumerator $locvar0;

		// Token: 0x0400631D RID: 25373
		internal object <_>__2;

		// Token: 0x0400631E RID: 25374
		internal IDisposable $locvar1;

		// Token: 0x0400631F RID: 25375
		internal object $current;

		// Token: 0x04006320 RID: 25376
		internal bool $disposing;

		// Token: 0x04006321 RID: 25377
		internal int $PC;

		// Token: 0x04006322 RID: 25378
		private ProtectorBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey3 $locvar2;

		// Token: 0x02001060 RID: 4192
		private sealed class <NormalGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x060068E7 RID: 26855 RVA: 0x001D8248 File Offset: 0x001D6648
			public <NormalGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x060068E8 RID: 26856 RVA: 0x001D8250 File Offset: 0x001D6650
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), (this.unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1.0 : 1.5)
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x04006325 RID: 25381
			internal IBattleUnit unit;
		}
	}
}
