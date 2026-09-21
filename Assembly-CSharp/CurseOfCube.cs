using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006EE RID: 1774
public class CurseOfCube : MainSkillBase
{
	// Token: 0x0600305A RID: 12378 RVA: 0x001499B0 File Offset: 0x00147DB0
	public CurseOfCube()
	{
	}

	// Token: 0x0600305B RID: 12379 RVA: 0x001499B8 File Offset: 0x00147DB8
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.CurseOfCube,
				SlotNumber = 1
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.CurseOfCube,
				SlotNumber = 2
			},
			new GodSeedStablizeTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x0600305C RID: 12380 RVA: 0x00149AA0 File Offset: 0x00147EA0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Divine), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x0600305D RID: 12381 RVA: 0x00149B23 File Offset: 0x00147F23
	private double GetDamagePercentage(Skill skill)
	{
		return 0.8 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x0600305E RID: 12382 RVA: 0x00149B42 File Offset: 0x00147F42
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x0600305F RID: 12383 RVA: 0x00149B61 File Offset: 0x00147F61
	private double GetHealRate(Skill skill)
	{
		return 0.15 + (double)(skill.Level - 1) * 0.03;
	}

	// Token: 0x06003060 RID: 12384 RVA: 0x00149B80 File Offset: 0x00147F80
	private double GetHealRaw(AdventureUnitSkill skill)
	{
		return base.CalculateHeal(this.GetHealRate(skill.Skill), skill);
	}

	// Token: 0x06003061 RID: 12385 RVA: 0x00149B98 File Offset: 0x00147F98
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.HealRateKey, this.GetHealRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003062 RID: 12386 RVA: 0x00149BFC File Offset: 0x00147FFC
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003063 RID: 12387 RVA: 0x00149C04 File Offset: 0x00148004
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			double heal = this.GetHealRaw(skill);
			IEnumerator enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new GodSeedEffect(heal, skill, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x17000684 RID: 1668
	// (get) Token: 0x06003064 RID: 12388 RVA: 0x00149C35 File Offset: 0x00148035
	public override SkillType SkillType
	{
		get
		{
			return SkillType.CurseOfCube;
		}
	}

	// Token: 0x17000685 RID: 1669
	// (get) Token: 0x06003065 RID: 12389 RVA: 0x00149C3C File Offset: 0x0014803C
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x17000686 RID: 1670
	// (get) Token: 0x06003066 RID: 12390 RVA: 0x00149C44 File Offset: 0x00148044
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Supportive;
		}
	}

	// Token: 0x17000687 RID: 1671
	// (get) Token: 0x06003067 RID: 12391 RVA: 0x00149C47 File Offset: 0x00148047
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Divine;
		}
	}

	// Token: 0x17000688 RID: 1672
	// (get) Token: 0x06003068 RID: 12392 RVA: 0x00149C4A File Offset: 0x0014804A
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x17000689 RID: 1673
	// (get) Token: 0x06003069 RID: 12393 RVA: 0x00149C4D File Offset: 0x0014804D
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002791 RID: 10129
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E53 RID: 3667
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C32 RID: 23602 RVA: 0x00149C50 File Offset: 0x00148050
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C33 RID: 23603 RVA: 0x00149C58 File Offset: 0x00148058
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = damage.BattleDamages.GetEnumerator();
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
					damageBattleDamage = enumerator.Current;
					heal = base.GetHealRaw(skill);
					enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new GodSeedEffect(heal, skill, base.GetType().FullName), false).GetEnumerator();
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

		// Token: 0x1700133C RID: 4924
		// (get) Token: 0x06005C34 RID: 23604 RVA: 0x00149E08 File Offset: 0x00148208
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700133D RID: 4925
		// (get) Token: 0x06005C35 RID: 23605 RVA: 0x00149E10 File Offset: 0x00148210
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C36 RID: 23606 RVA: 0x00149E18 File Offset: 0x00148218
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

		// Token: 0x06005C37 RID: 23607 RVA: 0x00149EAC File Offset: 0x001482AC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C38 RID: 23608 RVA: 0x00149EB3 File Offset: 0x001482B3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C39 RID: 23609 RVA: 0x00149EBC File Offset: 0x001482BC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CurseOfCube.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new CurseOfCube.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004E90 RID: 20112
		internal ReleaseableDamage damage;

		// Token: 0x04004E91 RID: 20113
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004E92 RID: 20114
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004E93 RID: 20115
		internal AdventureUnitSkill skill;

		// Token: 0x04004E94 RID: 20116
		internal double <heal>__2;

		// Token: 0x04004E95 RID: 20117
		internal IEnumerator $locvar1;

		// Token: 0x04004E96 RID: 20118
		internal object <_>__3;

		// Token: 0x04004E97 RID: 20119
		internal IDisposable $locvar2;

		// Token: 0x04004E98 RID: 20120
		internal CurseOfCube $this;

		// Token: 0x04004E99 RID: 20121
		internal object $current;

		// Token: 0x04004E9A RID: 20122
		internal bool $disposing;

		// Token: 0x04004E9B RID: 20123
		internal int $PC;
	}
}
