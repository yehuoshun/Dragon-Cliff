using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200070D RID: 1805
public class SwallowFire : MainSkillBase
{
	// Token: 0x060031ED RID: 12781 RVA: 0x00152AA4 File Offset: 0x00150EA4
	public SwallowFire()
	{
	}

	// Token: 0x060031EE RID: 12782 RVA: 0x00152AAC File Offset: 0x00150EAC
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.SwallowFire,
				SlotNumber = 1
			},
			new AttributeBoostOnKillTalentByRate
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.SwallowFire,
				SlotNumber = 1
			},
			new AttributeBoostOnKillTalentByRate
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.SwallowFire,
				SlotNumber = 2
			}
		};
	}

	// Token: 0x060031EF RID: 12783 RVA: 0x00152BA0 File Offset: 0x00150FA0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x060031F0 RID: 12784 RVA: 0x00152C1F File Offset: 0x0015101F
	private double GetDamagePercentage(Skill skill)
	{
		return 0.9 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060031F1 RID: 12785 RVA: 0x00152C3E File Offset: 0x0015103E
	private double GetStrengthBoostRate(Skill skill)
	{
		return 0.05 * (double)(skill.Level - 1) + 0.6;
	}

	// Token: 0x060031F2 RID: 12786 RVA: 0x00152C60 File Offset: 0x00151060
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.BoostRateKey, this.GetStrengthBoostRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060031F3 RID: 12787 RVA: 0x00152CC4 File Offset: 0x001510C4
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031F4 RID: 12788 RVA: 0x00152CCC File Offset: 0x001510CC
	public override IEnumerable PriorDamageFormationProcess(TargetDefinition targetDefinition, AdventureUnitSkill skill)
	{
		foreach (IBattleUnit target in targetDefinition.GetTargets(skill.SourceUnit))
		{
			List<FireSeedEffect> fireSeeds = target.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>();
			if (fireSeeds.Any<FireSeedEffect>())
			{
				double increasedValue = this.GetStrengthBoostRate(skill.Skill) * fireSeeds.Sum((FireSeedEffect f) => f.DamgeValue);
				AttributeModificationEffect boostEffect = AttributeModificationEffect.CreateStrengthBoostEffect(skill, increasedValue, base.GetType().FullName, new int?(3));
				IEnumerator enumerator2 = skill.SourceUnit.ApplySkillEffect(boostEffect, false).GetEnumerator();
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
				foreach (FireSeedEffect fireSeedEffect in fireSeeds)
				{
					IEnumerator enumerator4 = target.LooseSkillEffect(fireSeedEffect, EffectWearsOffType.Consumed).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x1700073A RID: 1850
	// (get) Token: 0x060031F5 RID: 12789 RVA: 0x00152CFD File Offset: 0x001510FD
	public override SkillType SkillType
	{
		get
		{
			return SkillType.SwallowFire;
		}
	}

	// Token: 0x1700073B RID: 1851
	// (get) Token: 0x060031F6 RID: 12790 RVA: 0x00152D04 File Offset: 0x00151104
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x1700073C RID: 1852
	// (get) Token: 0x060031F7 RID: 12791 RVA: 0x00152D0C File Offset: 0x0015110C
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700073D RID: 1853
	// (get) Token: 0x060031F8 RID: 12792 RVA: 0x00152D0F File Offset: 0x0015110F
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x1700073E RID: 1854
	// (get) Token: 0x060031F9 RID: 12793 RVA: 0x00152D12 File Offset: 0x00151112
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x1700073F RID: 1855
	// (get) Token: 0x060031FA RID: 12794 RVA: 0x00152D15 File Offset: 0x00151115
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027B3 RID: 10163
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E71 RID: 3697
	[CompilerGenerated]
	private sealed class <PriorDamageFormationProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CFF RID: 23807 RVA: 0x00152D18 File Offset: 0x00151118
		[DebuggerHidden]
		public <PriorDamageFormationProcess>c__Iterator0()
		{
		}

		// Token: 0x06005D00 RID: 23808 RVA: 0x00152D20 File Offset: 0x00151120
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = targetDefinition.GetTargets(skill.SourceUnit).GetEnumerator();
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
					Block_6:
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
					enumerator3 = fireSeeds.GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				case 2u:
					goto IL_1C9;
				}
				IL_2B8:
				while (enumerator.MoveNext())
				{
					target = enumerator.Current;
					fireSeeds = target.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>();
					if (fireSeeds.Any<FireSeedEffect>())
					{
						increasedValue = base.GetStrengthBoostRate(skill.Skill) * fireSeeds.Sum((FireSeedEffect f) => f.DamgeValue);
						boostEffect = AttributeModificationEffect.CreateStrengthBoostEffect(skill, increasedValue, base.GetType().FullName, new int?(3));
						enumerator2 = skill.SourceUnit.ApplySkillEffect(boostEffect, false).GetEnumerator();
						num = 4294967293u;
						goto Block_6;
					}
				}
				goto IL_2E3;
				Block_7:
				try
				{
					IL_1C9:
					switch (num)
					{
					case 2u:
						Block_16:
						try
						{
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
						break;
					}
					if (enumerator3.MoveNext())
					{
						fireSeedEffect = enumerator3.Current;
						enumerator4 = target.LooseSkillEffect(fireSeedEffect, EffectWearsOffType.Consumed).GetEnumerator();
						num = 4294967293u;
						goto Block_16;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				goto IL_2B8;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_2E3:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001368 RID: 4968
		// (get) Token: 0x06005D01 RID: 23809 RVA: 0x00153080 File Offset: 0x00151480
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001369 RID: 4969
		// (get) Token: 0x06005D02 RID: 23810 RVA: 0x00153088 File Offset: 0x00151488
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D03 RID: 23811 RVA: 0x00153090 File Offset: 0x00151490
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
						}
						finally
						{
							((IDisposable)enumerator3).Dispose();
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

		// Token: 0x06005D04 RID: 23812 RVA: 0x0015319C File Offset: 0x0015159C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D05 RID: 23813 RVA: 0x001531A3 File Offset: 0x001515A3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D06 RID: 23814 RVA: 0x001531AC File Offset: 0x001515AC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SwallowFire.<PriorDamageFormationProcess>c__Iterator0 <PriorDamageFormationProcess>c__Iterator = new SwallowFire.<PriorDamageFormationProcess>c__Iterator0();
			<PriorDamageFormationProcess>c__Iterator.$this = this;
			<PriorDamageFormationProcess>c__Iterator.targetDefinition = targetDefinition;
			<PriorDamageFormationProcess>c__Iterator.skill = skill;
			return <PriorDamageFormationProcess>c__Iterator;
		}

		// Token: 0x06005D07 RID: 23815 RVA: 0x001531F8 File Offset: 0x001515F8
		private static double <>m__0(FireSeedEffect f)
		{
			return f.DamgeValue;
		}

		// Token: 0x04004FE4 RID: 20452
		internal TargetDefinition targetDefinition;

		// Token: 0x04004FE5 RID: 20453
		internal AdventureUnitSkill skill;

		// Token: 0x04004FE6 RID: 20454
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004FE7 RID: 20455
		internal IBattleUnit <target>__1;

		// Token: 0x04004FE8 RID: 20456
		internal List<FireSeedEffect> <fireSeeds>__2;

		// Token: 0x04004FE9 RID: 20457
		internal double <increasedValue>__3;

		// Token: 0x04004FEA RID: 20458
		internal AttributeModificationEffect <boostEffect>__3;

		// Token: 0x04004FEB RID: 20459
		internal IEnumerator $locvar1;

		// Token: 0x04004FEC RID: 20460
		internal object <_>__4;

		// Token: 0x04004FED RID: 20461
		internal IDisposable $locvar2;

		// Token: 0x04004FEE RID: 20462
		internal List<FireSeedEffect>.Enumerator $locvar3;

		// Token: 0x04004FEF RID: 20463
		internal FireSeedEffect <fireSeedEffect>__5;

		// Token: 0x04004FF0 RID: 20464
		internal IEnumerator $locvar4;

		// Token: 0x04004FF1 RID: 20465
		internal object <_>__6;

		// Token: 0x04004FF2 RID: 20466
		internal IDisposable $locvar5;

		// Token: 0x04004FF3 RID: 20467
		internal SwallowFire $this;

		// Token: 0x04004FF4 RID: 20468
		internal object $current;

		// Token: 0x04004FF5 RID: 20469
		internal bool $disposing;

		// Token: 0x04004FF6 RID: 20470
		internal int $PC;

		// Token: 0x04004FF7 RID: 20471
		private static Func<FireSeedEffect, double> <>f__am$cache0;
	}
}
