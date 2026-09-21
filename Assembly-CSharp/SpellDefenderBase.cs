using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000A42 RID: 2626
public class SpellDefenderBase : UnitStyleConfigurationBase
{
	// Token: 0x06004783 RID: 18307 RVA: 0x001D82EA File Offset: 0x001D66EA
	public SpellDefenderBase()
	{
	}

	// Token: 0x17000DFA RID: 3578
	// (get) Token: 0x06004784 RID: 18308 RVA: 0x001D82F2 File Offset: 0x001D66F2
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.SpellDefender;
		}
	}

	// Token: 0x06004785 RID: 18309 RVA: 0x001D82F8 File Offset: 0x001D66F8
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 5.0, false).SetValue(AttributeType.Agility, 15.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 20.0, false).SetValue(AttributeType.TauntOnHit, 1.0, false);
		}
		if (measurement.DifficultyValue <= 900.0)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 6.0, false).SetValue(AttributeType.Agility, 12.0, false).SetValue(AttributeType.CritRate, 0.20000000298023224, false).SetValue(AttributeType.Vitality, 32.0, false).SetValue(AttributeType.TauntOnHit, 1.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 6.0, false).SetValue(AttributeType.Agility, 12.0, false).SetValue(AttributeType.CritRate, 0.20000000298023224, false).SetValue(AttributeType.Vitality, 50.0, false).SetValue(AttributeType.TauntOnHit, 1.0, false);
	}

	// Token: 0x06004786 RID: 18310 RVA: 0x001D8434 File Offset: 0x001D6834
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> boostTargets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
		if (boostTargets.Any<IBattleUnit>())
		{
			foreach (IBattleUnit boostTarget in boostTargets)
			{
				IEnumerator enumerator2 = boostTarget.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(unit, (from r in UnitExtensions.GetAllResistances()
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = 0.3,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}).ToList<AttributeModifier>(), "spelldefenderproc", new int?(5), null, new int?(2), false, true, false), false).GetEnumerator();
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
		List<IBattleUnit> poisonTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.MaxHealth, OrderingType.Desc, new int?(3)).GetTargets(unit);
		if (poisonTargets.Any<IBattleUnit>())
		{
			int numberOfPosions = UnityEngine.Random.Range(1, 3);
			for (int i = 0; i < numberOfPosions; i++)
			{
				IBattleUnit selected = poisonTargets[UnityEngine.Random.Range(0, poisonTargets.Count)];
				IEnumerator enumerator3 = selected.ApplySkillEffect(new PoisonBaitEffect("spelldefenderproc", unit, new float?(2f), 0.2), false).GetEnumerator();
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

	// Token: 0x17000DFB RID: 3579
	// (get) Token: 0x06004787 RID: 18311 RVA: 0x001D8458 File Offset: 0x001D6858
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

	// Token: 0x17000DFC RID: 3580
	// (get) Token: 0x06004788 RID: 18312 RVA: 0x001D8474 File Offset: 0x001D6874
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

	// Token: 0x17000DFD RID: 3581
	// (get) Token: 0x06004789 RID: 18313 RVA: 0x001D8490 File Offset: 0x001D6890
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

	// Token: 0x0600478A RID: 18314 RVA: 0x001D8540 File Offset: 0x001D6940
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating != 1)
		{
			list.Add(new TrickyDefenceEffectData
			{
				HealRate = 0.05
			});
		}
		if (measurement.StarRating != 1)
		{
			list.Add(new FirstHandEffectData
			{
				IsStarEf = new bool?(false),
				StartProgress = 1.0
			});
		}
		return list;
	}

	// Token: 0x0600478B RID: 18315 RVA: 0x001D85B0 File Offset: 0x001D69B0
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), (double)((unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 2 : 3))
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

	// Token: 0x02001061 RID: 4193
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068E9 RID: 26857 RVA: 0x001D85D3 File Offset: 0x001D69D3
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x060068EA RID: 26858 RVA: 0x001D85DC File Offset: 0x001D69DC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				boostTargets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
				if (!boostTargets.Any<IBattleUnit>())
				{
					goto IL_1AC;
				}
				enumerator = boostTargets.GetEnumerator();
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
				i++;
				goto IL_2E5;
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
					boostTarget = enumerator.Current;
					enumerator2 = boostTarget.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(unit, (from r in UnitExtensions.GetAllResistances()
					select new AttributeModifier
					{
						AttributeType = r,
						ModificationType = ModificationType.Multiplication,
						Value = 0.3,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}).ToList<AttributeModifier>(), "spelldefenderproc", new int?(5), null, new int?(2), false, true, false), false).GetEnumerator();
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
			IL_1AC:
			poisonTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.MaxHealth, OrderingType.Desc, new int?(3)).GetTargets(unit);
			if (!poisonTargets.Any<IBattleUnit>())
			{
				goto IL_2F6;
			}
			numberOfPosions = UnityEngine.Random.Range(1, 3);
			i = 0;
			IL_2E5:
			if (i < numberOfPosions)
			{
				selected = poisonTargets[UnityEngine.Random.Range(0, poisonTargets.Count)];
				enumerator3 = selected.ApplySkillEffect(new PoisonBaitEffect("spelldefenderproc", unit, new float?(2f), 0.2), false).GetEnumerator();
				num = 4294967293u;
				goto Block_5;
			}
			IL_2F6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015E7 RID: 5607
		// (get) Token: 0x060068EB RID: 26859 RVA: 0x001D8938 File Offset: 0x001D6D38
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015E8 RID: 5608
		// (get) Token: 0x060068EC RID: 26860 RVA: 0x001D8940 File Offset: 0x001D6D40
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068ED RID: 26861 RVA: 0x001D8948 File Offset: 0x001D6D48
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

		// Token: 0x060068EE RID: 26862 RVA: 0x001D8A1C File Offset: 0x001D6E1C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068EF RID: 26863 RVA: 0x001D8A23 File Offset: 0x001D6E23
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068F0 RID: 26864 RVA: 0x001D8A2C File Offset: 0x001D6E2C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellDefenderBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new SpellDefenderBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x060068F1 RID: 26865 RVA: 0x001D8A60 File Offset: 0x001D6E60
		private static AttributeModifier <>m__0(AttributeType r)
		{
			return new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Multiplication,
				Value = 0.3,
				AttributeModifierType = AttributeModifierType.Skill,
				Key = string.Empty
			};
		}

		// Token: 0x04006326 RID: 25382
		internal IBattleUnit unit;

		// Token: 0x04006327 RID: 25383
		internal List<IBattleUnit> <boostTargets>__0;

		// Token: 0x04006328 RID: 25384
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04006329 RID: 25385
		internal IBattleUnit <boostTarget>__1;

		// Token: 0x0400632A RID: 25386
		internal IEnumerator $locvar1;

		// Token: 0x0400632B RID: 25387
		internal object <_>__2;

		// Token: 0x0400632C RID: 25388
		internal IDisposable $locvar2;

		// Token: 0x0400632D RID: 25389
		internal List<IBattleUnit> <poisonTargets>__0;

		// Token: 0x0400632E RID: 25390
		internal int <numberOfPosions>__3;

		// Token: 0x0400632F RID: 25391
		internal int <i>__4;

		// Token: 0x04006330 RID: 25392
		internal IBattleUnit <selected>__5;

		// Token: 0x04006331 RID: 25393
		internal IEnumerator $locvar3;

		// Token: 0x04006332 RID: 25394
		internal object <_>__6;

		// Token: 0x04006333 RID: 25395
		internal IDisposable $locvar4;

		// Token: 0x04006334 RID: 25396
		internal object $current;

		// Token: 0x04006335 RID: 25397
		internal bool $disposing;

		// Token: 0x04006336 RID: 25398
		internal int $PC;

		// Token: 0x04006337 RID: 25399
		private static Func<AttributeType, AttributeModifier> <>f__am$cache0;
	}

	// Token: 0x02001062 RID: 4194
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068F2 RID: 26866 RVA: 0x001D8AA3 File Offset: 0x001D6EA3
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x060068F3 RID: 26867 RVA: 0x001D8AAC File Offset: 0x001D6EAC
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
					goto IL_151;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), (double)((unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 2 : 3))
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

		// Token: 0x170015E9 RID: 5609
		// (get) Token: 0x060068F4 RID: 26868 RVA: 0x001D8C24 File Offset: 0x001D7024
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015EA RID: 5610
		// (get) Token: 0x060068F5 RID: 26869 RVA: 0x001D8C2C File Offset: 0x001D702C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068F6 RID: 26870 RVA: 0x001D8C34 File Offset: 0x001D7034
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

		// Token: 0x060068F7 RID: 26871 RVA: 0x001D8CA4 File Offset: 0x001D70A4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068F8 RID: 26872 RVA: 0x001D8CAB File Offset: 0x001D70AB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068F9 RID: 26873 RVA: 0x001D8CB4 File Offset: 0x001D70B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellDefenderBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new SpellDefenderBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006338 RID: 25400
		internal TargetDefinition <targetDf>__0;

		// Token: 0x04006339 RID: 25401
		internal IBattleUnit unit;

		// Token: 0x0400633A RID: 25402
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x0400633B RID: 25403
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400633C RID: 25404
		internal IEnumerator $locvar0;

		// Token: 0x0400633D RID: 25405
		internal object <_>__2;

		// Token: 0x0400633E RID: 25406
		internal IDisposable $locvar1;

		// Token: 0x0400633F RID: 25407
		internal object $current;

		// Token: 0x04006340 RID: 25408
		internal bool $disposing;

		// Token: 0x04006341 RID: 25409
		internal int $PC;

		// Token: 0x04006342 RID: 25410
		private SpellDefenderBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey2 $locvar2;

		// Token: 0x02001063 RID: 4195
		private sealed class <NormalGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x060068FA RID: 26874 RVA: 0x001D8CE8 File Offset: 0x001D70E8
			public <NormalGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x060068FB RID: 26875 RVA: 0x001D8CF0 File Offset: 0x001D70F0
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), (double)((this.unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 2 : 3))
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x04006343 RID: 25411
			internal IBattleUnit unit;
		}
	}
}
