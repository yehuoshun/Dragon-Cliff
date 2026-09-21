using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006C6 RID: 1734
public class HeartlessFire : ActiveSkillLogicBase
{
	// Token: 0x06002EA1 RID: 11937 RVA: 0x0013A239 File Offset: 0x00138639
	public HeartlessFire()
	{
	}

	// Token: 0x06002EA2 RID: 11938 RVA: 0x0013A25C File Offset: 0x0013865C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new HeartlessTriggerTalent(SkillType.HeartlessFire, 1),
			new HeartlessExtraSeedTalent(SkillType.HeartlessFire, 2),
			new HeartlessSingleHitTalent(SkillType.HeartlessFire, 3)
		};
	}

	// Token: 0x17000602 RID: 1538
	// (get) Token: 0x06002EA3 RID: 11939 RVA: 0x0013A2A3 File Offset: 0x001386A3
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x17000603 RID: 1539
	// (get) Token: 0x06002EA4 RID: 11940 RVA: 0x0013A2AB File Offset: 0x001386AB
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000604 RID: 1540
	// (get) Token: 0x06002EA5 RID: 11941 RVA: 0x0013A2B3 File Offset: 0x001386B3
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000605 RID: 1541
	// (get) Token: 0x06002EA6 RID: 11942 RVA: 0x0013A2BB File Offset: 0x001386BB
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002EA7 RID: 11943 RVA: 0x0013A2C3 File Offset: 0x001386C3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		if (profile.GetSpecialEffects().OfType<HeartlessSingleHitData>().Any<HeartlessSingleHitData>())
		{
			return ActiveSkillLogicBase.IsSelfResolvable<HostileSingleStrategy>();
		}
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002EA8 RID: 11944 RVA: 0x0013A2E5 File Offset: 0x001386E5
	public override double GetGaugeCost(Skill skill)
	{
		return 30.0;
	}

	// Token: 0x06002EA9 RID: 11945 RVA: 0x0013A2F0 File Offset: 0x001386F0
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(0f);
	}

	// Token: 0x06002EAA RID: 11946 RVA: 0x0013A2FC File Offset: 0x001386FC
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		if (skill.SourceUnit.SpecialEffects.OfType<HeartlessSingleHitData>().Any<HeartlessSingleHitData>())
		{
			return new HostileSingleStrategy(skill);
		}
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002EAB RID: 11947 RVA: 0x0013A325 File Offset: 0x00138725
	private int TotalNumberOfFireSeeds(Skill skill)
	{
		return skill.Level;
	}

	// Token: 0x06002EAC RID: 11948 RVA: 0x0013A32D File Offset: 0x0013872D
	private double PassiveChance(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06002EAD RID: 11949 RVA: 0x0013A34C File Offset: 0x0013874C
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		HeartlessSingleHitData single = skill.SourceUnit.SpecialEffects.OfType<HeartlessSingleHitData>().FirstOrDefault<HeartlessSingleHitData>();
		if (single != null)
		{
			ReleaseableDamage releaseable = new ReleaseableDamage((from s in strategy.Selections
			select new BattleDamage(s, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, s, skill.SourceUnit.GetOutputType(), single.DamageRate)
				}, s, skill.SourceUnit, true, false)
			})).ToList<BattleDamage>(), skill.SourceUnit);
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
		else if (skill.SourceUnit.SpecialEffects.OfType<HeartlessTriggerData>().Any<HeartlessTriggerData>())
		{
			IEnumerator enumerator2 = DamageExtensions.TriggerFireSeeds(strategy.Selections, skill.SourceUnit).GetEnumerator();
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
			int totalSeeds = this.TotalNumberOfFireSeeds(skill.Skill);
			double totalDamage = skill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * (2.0 + skill.SourceUnit.SpecialEffects.OfType<HeartlessSeedEnhancementData>().Sum((HeartlessSeedEnhancementData s) => s.ExtraRate));
			foreach (IBattleUnit unit in strategy.Selections)
			{
				for (int i = 0; i < totalSeeds; i++)
				{
					IEnumerator enumerator4 = FireSeedEffect.AddFireSeed(unit, totalDamage, skill.SourceUnit).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002EAE RID: 11950 RVA: 0x0013A380 File Offset: 0x00138780
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.DamageRateKey, ((double)this.TotalNumberOfFireSeeds(skill) * 2.0).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002EAF RID: 11951 RVA: 0x0013A3E0 File Offset: 0x001387E0
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002EB0 RID: 11952 RVA: 0x0013A3FC File Offset: 0x001387FC
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && skillOwner == eventTriggerUnit)
		{
			List<IBattleUnit> hostileUnits = processingSkill.SourceUnit.GetLiveEnemyTargets(false, true);
			if ((double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill) && hostileUnits.Any<IBattleUnit>())
			{
				int totalApplies = UnityEngine.Random.Range(1, 3);
				IBattleUnit unit = hostileUnits[UnityEngine.Random.Range(0, hostileUnits.Count)];
				double totalDamage = processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 1.5;
				for (int i = 0; i < totalApplies; i++)
				{
					IEnumerator enumerator = FireSeedEffect.AddFireSeed(unit, totalDamage, processingSkill.SourceUnit).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x04002719 RID: 10009
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x0400271A RID: 10010
	private OutputType _skillOutputType;

	// Token: 0x0400271B RID: 10011
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x0400271C RID: 10012
	private SkillType _skillType = SkillType.HeartlessFire;

	// Token: 0x02000E19 RID: 3609
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005ACA RID: 23242 RVA: 0x0013A43C File Offset: 0x0013883C
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005ACB RID: 23243 RVA: 0x0013A444 File Offset: 0x00138844
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				HeartlessSingleHitData single = skill.SourceUnit.SpecialEffects.OfType<HeartlessSingleHitData>().FirstOrDefault<HeartlessSingleHitData>();
				if (single != null)
				{
					releaseable = new ReleaseableDamage((from s in strategy.Selections
					select new BattleDamage(s, skill, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(skill.SourceUnit, s, skill.SourceUnit.GetOutputType(), single.DamageRate)
						}, s, skill.SourceUnit, true, false)
					})).ToList<BattleDamage>(), skill.SourceUnit);
					enumerator = releaseable.Release().GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					if (skill.SourceUnit.SpecialEffects.OfType<HeartlessTriggerData>().Any<HeartlessTriggerData>())
					{
						enumerator2 = DamageExtensions.TriggerFireSeeds(strategy.Selections, skill.SourceUnit).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					}
					totalSeeds = base.TotalNumberOfFireSeeds(skill.Skill);
					totalDamage = skill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * (2.0 + skill.SourceUnit.SpecialEffects.OfType<HeartlessSeedEnhancementData>().Sum((HeartlessSeedEnhancementData s) => s.ExtraRate));
					enumerator3 = strategy.Selections.GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_1C0;
			case 3u:
				goto IL_2E9;
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
			goto IL_412;
			Block_5:
			try
			{
				IL_1C0:
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
			goto IL_412;
			Block_7:
			try
			{
				IL_2E9:
				switch (num)
				{
				case 3u:
					Block_21:
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
					i++;
					break;
				default:
					goto IL_3E7;
				}
				IL_3D6:
				if (i < totalSeeds)
				{
					enumerator4 = FireSeedEffect.AddFireSeed(unit, totalDamage, <CastSkillLogic>c__AnonStorey.skill.SourceUnit).GetEnumerator();
					num = 4294967293u;
					goto Block_21;
				}
				IL_3E7:
				if (enumerator3.MoveNext())
				{
					unit = enumerator3.Current;
					i = 0;
					goto IL_3D6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			IL_412:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012F2 RID: 4850
		// (get) Token: 0x06005ACC RID: 23244 RVA: 0x0013A8D4 File Offset: 0x00138CD4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012F3 RID: 4851
		// (get) Token: 0x06005ACD RID: 23245 RVA: 0x0013A8DC File Offset: 0x00138CDC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005ACE RID: 23246 RVA: 0x0013A8E4 File Offset: 0x00138CE4
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
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005ACF RID: 23247 RVA: 0x0013A9F4 File Offset: 0x00138DF4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AD0 RID: 23248 RVA: 0x0013A9FB File Offset: 0x00138DFB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AD1 RID: 23249 RVA: 0x0013AA04 File Offset: 0x00138E04
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HeartlessFire.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new HeartlessFire.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005AD2 RID: 23250 RVA: 0x0013AA50 File Offset: 0x00138E50
		private static double <>m__0(HeartlessSeedEnhancementData s)
		{
			return s.ExtraRate;
		}

		// Token: 0x04004BC5 RID: 19397
		internal AdventureUnitSkill skill;

		// Token: 0x04004BC6 RID: 19398
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004BC7 RID: 19399
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x04004BC8 RID: 19400
		internal IEnumerator $locvar0;

		// Token: 0x04004BC9 RID: 19401
		internal object <_>__2;

		// Token: 0x04004BCA RID: 19402
		internal IDisposable $locvar1;

		// Token: 0x04004BCB RID: 19403
		internal IEnumerator $locvar2;

		// Token: 0x04004BCC RID: 19404
		internal object <_>__3;

		// Token: 0x04004BCD RID: 19405
		internal IDisposable $locvar3;

		// Token: 0x04004BCE RID: 19406
		internal int <totalSeeds>__4;

		// Token: 0x04004BCF RID: 19407
		internal double <totalDamage>__4;

		// Token: 0x04004BD0 RID: 19408
		internal List<IBattleUnit>.Enumerator $locvar4;

		// Token: 0x04004BD1 RID: 19409
		internal IBattleUnit <unit>__5;

		// Token: 0x04004BD2 RID: 19410
		internal int <i>__6;

		// Token: 0x04004BD3 RID: 19411
		internal IEnumerator $locvar5;

		// Token: 0x04004BD4 RID: 19412
		internal object <_>__7;

		// Token: 0x04004BD5 RID: 19413
		internal IDisposable $locvar6;

		// Token: 0x04004BD6 RID: 19414
		internal HeartlessFire $this;

		// Token: 0x04004BD7 RID: 19415
		internal object $current;

		// Token: 0x04004BD8 RID: 19416
		internal bool $disposing;

		// Token: 0x04004BD9 RID: 19417
		internal int $PC;

		// Token: 0x04004BDA RID: 19418
		private HeartlessFire.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey2 $locvar7;

		// Token: 0x04004BDB RID: 19419
		private static Func<HeartlessSeedEnhancementData, double> <>f__am$cache0;

		// Token: 0x02000E1B RID: 3611
		private sealed class <CastSkillLogic>c__AnonStorey2
		{
			// Token: 0x06005ADB RID: 23259 RVA: 0x0013AA58 File Offset: 0x00138E58
			public <CastSkillLogic>c__AnonStorey2()
			{
			}

			// Token: 0x06005ADC RID: 23260 RVA: 0x0013AA60 File Offset: 0x00138E60
			internal BattleDamage <>m__0(IBattleUnit s)
			{
				return new BattleDamage(s, this.skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.skill.SourceUnit, s, this.skill.SourceUnit.GetOutputType(), this.single.DamageRate)
					}, s, this.skill.SourceUnit, true, false)
				});
			}

			// Token: 0x04004BEC RID: 19436
			internal AdventureUnitSkill skill;

			// Token: 0x04004BED RID: 19437
			internal HeartlessSingleHitData single;

			// Token: 0x04004BEE RID: 19438
			internal HeartlessFire.<CastSkillLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000E1A RID: 3610
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AD3 RID: 23251 RVA: 0x0013AAD2 File Offset: 0x00138ED2
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005AD4 RID: 23252 RVA: 0x0013AADC File Offset: 0x00138EDC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || skillOwner != eventTriggerUnit)
				{
					goto IL_1B5;
				}
				hostileUnits = processingSkill.SourceUnit.GetLiveEnemyTargets(false, true);
				if ((double)UnityEngine.Random.value > base.PassiveChance(processingSkill.Skill) || !hostileUnits.Any<IBattleUnit>())
				{
					goto IL_1B5;
				}
				totalApplies = UnityEngine.Random.Range(1, 3);
				unit = hostileUnits[UnityEngine.Random.Range(0, hostileUnits.Count)];
				totalDamage = processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 1.5;
				i = 0;
				break;
			case 1u:
				Block_6:
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
				i++;
				break;
			default:
				return false;
			}
			if (i < totalApplies)
			{
				enumerator = FireSeedEffect.AddFireSeed(unit, totalDamage, processingSkill.SourceUnit).GetEnumerator();
				num = 4294967293u;
				goto Block_6;
			}
			IL_1B5:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012F4 RID: 4852
		// (get) Token: 0x06005AD5 RID: 23253 RVA: 0x0013ACB8 File Offset: 0x001390B8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012F5 RID: 4853
		// (get) Token: 0x06005AD6 RID: 23254 RVA: 0x0013ACC0 File Offset: 0x001390C0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AD7 RID: 23255 RVA: 0x0013ACC8 File Offset: 0x001390C8
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

		// Token: 0x06005AD8 RID: 23256 RVA: 0x0013AD38 File Offset: 0x00139138
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AD9 RID: 23257 RVA: 0x0013AD3F File Offset: 0x0013913F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005ADA RID: 23258 RVA: 0x0013AD48 File Offset: 0x00139148
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HeartlessFire.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new HeartlessFire.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004BDC RID: 19420
		internal AdventureEventType eventType;

		// Token: 0x04004BDD RID: 19421
		internal IBattleUnit skillOwner;

		// Token: 0x04004BDE RID: 19422
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004BDF RID: 19423
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004BE0 RID: 19424
		internal List<IBattleUnit> <hostileUnits>__1;

		// Token: 0x04004BE1 RID: 19425
		internal int <totalApplies>__2;

		// Token: 0x04004BE2 RID: 19426
		internal IBattleUnit <unit>__2;

		// Token: 0x04004BE3 RID: 19427
		internal double <totalDamage>__2;

		// Token: 0x04004BE4 RID: 19428
		internal int <i>__3;

		// Token: 0x04004BE5 RID: 19429
		internal IEnumerator $locvar0;

		// Token: 0x04004BE6 RID: 19430
		internal object <_>__4;

		// Token: 0x04004BE7 RID: 19431
		internal IDisposable $locvar1;

		// Token: 0x04004BE8 RID: 19432
		internal HeartlessFire $this;

		// Token: 0x04004BE9 RID: 19433
		internal object $current;

		// Token: 0x04004BEA RID: 19434
		internal bool $disposing;

		// Token: 0x04004BEB RID: 19435
		internal int $PC;
	}
}
