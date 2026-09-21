using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006ED RID: 1773
public class CorruptedPower : MainSkillBase
{
	// Token: 0x0600304D RID: 12365 RVA: 0x00149557 File Offset: 0x00147957
	public CorruptedPower()
	{
	}

	// Token: 0x0600304E RID: 12366 RVA: 0x00149560 File Offset: 0x00147960
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Poison), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Strength, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x0600304F RID: 12367 RVA: 0x001495DF File Offset: 0x001479DF
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06003050 RID: 12368 RVA: 0x001495FE File Offset: 0x001479FE
	private double GetStrengthDecayRate(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06003051 RID: 12369 RVA: 0x00149620 File Offset: 0x00147A20
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.DecreaseRateKey, this.GetStrengthDecayRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003052 RID: 12370 RVA: 0x00149684 File Offset: 0x00147A84
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003053 RID: 12371 RVA: 0x0014968C File Offset: 0x00147A8C
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active)
			{
				double decayStrength = this.GetStrengthDecayRate(skill.Skill);
				IEnumerator enumerator2 = target.ApplySkillEffect(new CorruptedPowerEffect(skill, decayStrength, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x1700067E RID: 1662
	// (get) Token: 0x06003054 RID: 12372 RVA: 0x001496BD File Offset: 0x00147ABD
	public override SkillType SkillType
	{
		get
		{
			return SkillType.CorruptedPower;
		}
	}

	// Token: 0x1700067F RID: 1663
	// (get) Token: 0x06003055 RID: 12373 RVA: 0x001496C4 File Offset: 0x00147AC4
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x17000680 RID: 1664
	// (get) Token: 0x06003056 RID: 12374 RVA: 0x001496CC File Offset: 0x00147ACC
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000681 RID: 1665
	// (get) Token: 0x06003057 RID: 12375 RVA: 0x001496CF File Offset: 0x00147ACF
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000682 RID: 1666
	// (get) Token: 0x06003058 RID: 12376 RVA: 0x001496D2 File Offset: 0x00147AD2
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000683 RID: 1667
	// (get) Token: 0x06003059 RID: 12377 RVA: 0x001496D5 File Offset: 0x00147AD5
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002790 RID: 10128
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E52 RID: 3666
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C2A RID: 23594 RVA: 0x001496D8 File Offset: 0x00147AD8
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C2B RID: 23595 RVA: 0x001496E0 File Offset: 0x00147AE0
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
					Block_5:
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
					damageBattleDamage = enumerator.Current;
					target = damageBattleDamage.Target;
					if (target.Status == BattleUnitStatus.Active)
					{
						decayStrength = base.GetStrengthDecayRate(skill.Skill);
						enumerator2 = target.ApplySkillEffect(new CorruptedPowerEffect(skill, decayStrength, base.GetType().FullName), false).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700133A RID: 4922
		// (get) Token: 0x06005C2C RID: 23596 RVA: 0x001498B0 File Offset: 0x00147CB0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700133B RID: 4923
		// (get) Token: 0x06005C2D RID: 23597 RVA: 0x001498B8 File Offset: 0x00147CB8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C2E RID: 23598 RVA: 0x001498C0 File Offset: 0x00147CC0
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

		// Token: 0x06005C2F RID: 23599 RVA: 0x00149954 File Offset: 0x00147D54
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C30 RID: 23600 RVA: 0x0014995B File Offset: 0x00147D5B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C31 RID: 23601 RVA: 0x00149964 File Offset: 0x00147D64
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CorruptedPower.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new CorruptedPower.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004E83 RID: 20099
		internal ReleaseableDamage damage;

		// Token: 0x04004E84 RID: 20100
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004E85 RID: 20101
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004E86 RID: 20102
		internal IBattleUnit <target>__2;

		// Token: 0x04004E87 RID: 20103
		internal AdventureUnitSkill skill;

		// Token: 0x04004E88 RID: 20104
		internal double <decayStrength>__3;

		// Token: 0x04004E89 RID: 20105
		internal IEnumerator $locvar1;

		// Token: 0x04004E8A RID: 20106
		internal object <_>__4;

		// Token: 0x04004E8B RID: 20107
		internal IDisposable $locvar2;

		// Token: 0x04004E8C RID: 20108
		internal CorruptedPower $this;

		// Token: 0x04004E8D RID: 20109
		internal object $current;

		// Token: 0x04004E8E RID: 20110
		internal bool $disposing;

		// Token: 0x04004E8F RID: 20111
		internal int $PC;
	}
}
