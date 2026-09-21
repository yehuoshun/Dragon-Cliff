using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000A3C RID: 2620
public class PhysicalDefenderBase : UnitStyleConfigurationBase
{
	// Token: 0x06004753 RID: 18259 RVA: 0x001D3C6A File Offset: 0x001D206A
	public PhysicalDefenderBase()
	{
	}

	// Token: 0x17000DE6 RID: 3558
	// (get) Token: 0x06004754 RID: 18260 RVA: 0x001D3C72 File Offset: 0x001D2072
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}

	// Token: 0x06004755 RID: 18261 RVA: 0x001D3C78 File Offset: 0x001D2078
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 5.0, false).SetValue(AttributeType.Agility, 15.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 20.0, false).SetValue(AttributeType.TauntOnHit, 0.5, false);
		}
		if (measurement.DifficultyValue <= 900.0)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 5.5, false).SetValue(AttributeType.Agility, 15.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 32.0, false).SetValue(AttributeType.TauntOnHit, 0.699999988079071, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Strength, 5.5, false).SetValue(AttributeType.Agility, 19.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 50.0, false).SetValue(AttributeType.TauntOnHit, 0.89999997615814209, false);
	}

	// Token: 0x06004756 RID: 18262 RVA: 0x001D3DB4 File Offset: 0x001D21B4
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
		if (targets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
			{
				new DamagePotionValue(unit, t, this.GetRandomElement(), 0.8),
				new DamagePotionValue(unit, t, unit.GetOutputType(), 0.8)
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
			foreach (IBattleUnit battleUnit in targets)
			{
				if (battleUnit.IsAliveInBattle())
				{
					if (battleUnit.BattleEffects.OfType<TauntEffect>().Any<TauntEffect>())
					{
						IEnumerator enumerator3 = UnitStyleConfigurationBase.PushTargetProgress(battleUnit, unit, -0.3).GetEnumerator();
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
					else
					{
						IEnumerator enumerator4 = UnitStyleConfigurationBase.PushTargetProgress(battleUnit, unit, -0.1).GetEnumerator();
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
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x17000DE7 RID: 3559
	// (get) Token: 0x06004757 RID: 18263 RVA: 0x001D3DE0 File Offset: 0x001D21E0
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

	// Token: 0x17000DE8 RID: 3560
	// (get) Token: 0x06004758 RID: 18264 RVA: 0x001D3E0C File Offset: 0x001D220C
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

	// Token: 0x17000DE9 RID: 3561
	// (get) Token: 0x06004759 RID: 18265 RVA: 0x001D3E28 File Offset: 0x001D2228
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

	// Token: 0x0600475A RID: 18266 RVA: 0x001D3ED8 File Offset: 0x001D22D8
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating != 1)
		{
			list.Add(new TauntRecoveryData
			{
				IsStarEf = new bool?(false),
				RecoveryRate = 0.1
			});
		}
		if (measurement.StarRating != 1)
		{
			list.Add(new ImmortalShieldEffectData
			{
				IsStarEf = new bool?(false),
				NumberOfShields = 1
			});
		}
		return list;
	}

	// Token: 0x0600475B RID: 18267 RVA: 0x001D3F4C File Offset: 0x001D234C
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		int numberOfTargets = (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 2 : 3;
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(numberOfTargets));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), 1.8)
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

	// Token: 0x0200104B RID: 4171
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600687F RID: 26751 RVA: 0x001D3F6F File Offset: 0x001D236F
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x06006880 RID: 26752 RVA: 0x001D3F78 File Offset: 0x001D2378
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_34E;
				}
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), 0.8),
					new DamagePotionValue(unit, t, unit.GetOutputType(), 0.8)
				}, t, unit, true, false), 2).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
				goto IL_170;
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
			enumerator2 = targets.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_170:
				switch (num)
				{
				case 2u:
					Block_14:
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
				case 3u:
					Block_15:
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
					break;
				}
				while (enumerator2.MoveNext())
				{
					battleUnit = enumerator2.Current;
					if (battleUnit.IsAliveInBattle())
					{
						if (battleUnit.BattleEffects.OfType<TauntEffect>().Any<TauntEffect>())
						{
							enumerator3 = UnitStyleConfigurationBase.PushTargetProgress(battleUnit, <HardGradeAttackLogic>c__AnonStorey.unit, -0.3).GetEnumerator();
							num = 4294967293u;
							goto Block_14;
						}
						enumerator4 = UnitStyleConfigurationBase.PushTargetProgress(battleUnit, <HardGradeAttackLogic>c__AnonStorey.unit, -0.1).GetEnumerator();
						num = 4294967293u;
						goto Block_15;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_34E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015D3 RID: 5587
		// (get) Token: 0x06006881 RID: 26753 RVA: 0x001D4344 File Offset: 0x001D2744
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015D4 RID: 5588
		// (get) Token: 0x06006882 RID: 26754 RVA: 0x001D434C File Offset: 0x001D274C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006883 RID: 26755 RVA: 0x001D4354 File Offset: 0x001D2754
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
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006884 RID: 26756 RVA: 0x001D447C File Offset: 0x001D287C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006885 RID: 26757 RVA: 0x001D4483 File Offset: 0x001D2883
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006886 RID: 26758 RVA: 0x001D448C File Offset: 0x001D288C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalDefenderBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new PhysicalDefenderBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006256 RID: 25174
		internal IBattleUnit unit;

		// Token: 0x04006257 RID: 25175
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04006258 RID: 25176
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x04006259 RID: 25177
		internal IEnumerator $locvar0;

		// Token: 0x0400625A RID: 25178
		internal object <_>__2;

		// Token: 0x0400625B RID: 25179
		internal IDisposable $locvar1;

		// Token: 0x0400625C RID: 25180
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x0400625D RID: 25181
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x0400625E RID: 25182
		internal IEnumerator $locvar3;

		// Token: 0x0400625F RID: 25183
		internal object <_>__4;

		// Token: 0x04006260 RID: 25184
		internal IDisposable $locvar4;

		// Token: 0x04006261 RID: 25185
		internal IEnumerator $locvar5;

		// Token: 0x04006262 RID: 25186
		internal object <_>__5;

		// Token: 0x04006263 RID: 25187
		internal IDisposable $locvar6;

		// Token: 0x04006264 RID: 25188
		internal PhysicalDefenderBase $this;

		// Token: 0x04006265 RID: 25189
		internal object $current;

		// Token: 0x04006266 RID: 25190
		internal bool $disposing;

		// Token: 0x04006267 RID: 25191
		internal int $PC;

		// Token: 0x04006268 RID: 25192
		private PhysicalDefenderBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2 $locvar7;

		// Token: 0x0200104D RID: 4173
		private sealed class <HardGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x0600688F RID: 26767 RVA: 0x001D44CC File Offset: 0x001D28CC
			public <HardGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x06006890 RID: 26768 RVA: 0x001D44D4 File Offset: 0x001D28D4
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(this.unit, t, this.<>f__ref$0.$this.GetRandomElement(), 0.8),
					new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), 0.8)
				}, t, this.unit, true, false), 2).ToList<DamageComponentValue>());
			}

			// Token: 0x04006275 RID: 25205
			internal IBattleUnit unit;

			// Token: 0x04006276 RID: 25206
			internal PhysicalDefenderBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x0200104C RID: 4172
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006887 RID: 26759 RVA: 0x001D4563 File Offset: 0x001D2963
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x06006888 RID: 26760 RVA: 0x001D456C File Offset: 0x001D296C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				numberOfTargets = ((unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 2 : 3);
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(numberOfTargets));
				opponents = targetDf.GetTargets(unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_17E;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), 1.8)
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
			IL_17E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015D5 RID: 5589
		// (get) Token: 0x06006889 RID: 26761 RVA: 0x001D4714 File Offset: 0x001D2B14
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015D6 RID: 5590
		// (get) Token: 0x0600688A RID: 26762 RVA: 0x001D471C File Offset: 0x001D2B1C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600688B RID: 26763 RVA: 0x001D4724 File Offset: 0x001D2B24
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

		// Token: 0x0600688C RID: 26764 RVA: 0x001D4794 File Offset: 0x001D2B94
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600688D RID: 26765 RVA: 0x001D479B File Offset: 0x001D2B9B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600688E RID: 26766 RVA: 0x001D47A4 File Offset: 0x001D2BA4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalDefenderBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new PhysicalDefenderBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006269 RID: 25193
		internal IBattleUnit unit;

		// Token: 0x0400626A RID: 25194
		internal int <numberOfTargets>__0;

		// Token: 0x0400626B RID: 25195
		internal TargetDefinition <targetDf>__0;

		// Token: 0x0400626C RID: 25196
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x0400626D RID: 25197
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400626E RID: 25198
		internal IEnumerator $locvar0;

		// Token: 0x0400626F RID: 25199
		internal object <_>__2;

		// Token: 0x04006270 RID: 25200
		internal IDisposable $locvar1;

		// Token: 0x04006271 RID: 25201
		internal object $current;

		// Token: 0x04006272 RID: 25202
		internal bool $disposing;

		// Token: 0x04006273 RID: 25203
		internal int $PC;

		// Token: 0x04006274 RID: 25204
		private PhysicalDefenderBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey3 $locvar2;

		// Token: 0x0200104E RID: 4174
		private sealed class <NormalGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x06006891 RID: 26769 RVA: 0x001D47D8 File Offset: 0x001D2BD8
			public <NormalGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x06006892 RID: 26770 RVA: 0x001D47E0 File Offset: 0x001D2BE0
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), 1.8)
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x04006277 RID: 25207
			internal IBattleUnit unit;
		}
	}
}
