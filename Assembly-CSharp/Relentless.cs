using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000701 RID: 1793
public class Relentless : MainSkillBase
{
	// Token: 0x0600314D RID: 12621 RVA: 0x0014EAE8 File Offset: 0x0014CEE8
	public Relentless()
	{
	}

	// Token: 0x170006F2 RID: 1778
	// (get) Token: 0x0600314E RID: 12622 RVA: 0x0014EAF0 File Offset: 0x0014CEF0
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Relentless;
		}
	}

	// Token: 0x170006F3 RID: 1779
	// (get) Token: 0x0600314F RID: 12623 RVA: 0x0014EAF7 File Offset: 0x0014CEF7
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003150 RID: 12624 RVA: 0x0014EB00 File Offset: 0x0014CF00
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x06003151 RID: 12625 RVA: 0x0014EB62 File Offset: 0x0014CF62
	private double GetDamagePercentage(Skill skill)
	{
		return 1.5 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06003152 RID: 12626 RVA: 0x0014EB81 File Offset: 0x0014CF81
	private double GetArmorReductionRate(Skill skill)
	{
		return 0.1;
	}

	// Token: 0x06003153 RID: 12627 RVA: 0x0014EB8C File Offset: 0x0014CF8C
	private double GetStrengthBoostRate(Skill skill)
	{
		return 0.3;
	}

	// Token: 0x06003154 RID: 12628 RVA: 0x0014EB98 File Offset: 0x0014CF98
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.DecreaseRateKey, this.GetArmorReductionRate(skill).ToExpressionMultiply100()).Replace(this.BoostRateKey, this.GetStrengthBoostRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003155 RID: 12629 RVA: 0x0014EBFC File Offset: 0x0014CFFC
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003156 RID: 12630 RVA: 0x0014EC04 File Offset: 0x0014D004
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateRelentlessEffect(skill, this.GetArmorReductionRate(skill.Skill), this.GetStrengthBoostRate(skill.Skill), base.GetType().FullName), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x170006F4 RID: 1780
	// (get) Token: 0x06003157 RID: 12631 RVA: 0x0014EC2E File Offset: 0x0014D02E
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006F5 RID: 1781
	// (get) Token: 0x06003158 RID: 12632 RVA: 0x0014EC31 File Offset: 0x0014D031
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x170006F6 RID: 1782
	// (get) Token: 0x06003159 RID: 12633 RVA: 0x0014EC34 File Offset: 0x0014D034
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006F7 RID: 1783
	// (get) Token: 0x0600315A RID: 12634 RVA: 0x0014EC37 File Offset: 0x0014D037
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027A7 RID: 10151
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E63 RID: 3683
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C9E RID: 23710 RVA: 0x0014EC3A File Offset: 0x0014D03A
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C9F RID: 23711 RVA: 0x0014EC44 File Offset: 0x0014D044
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateRelentlessEffect(skill, base.GetArmorReductionRate(skill.Skill), base.GetStrengthBoostRate(skill.Skill), base.GetType().FullName), false).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001352 RID: 4946
		// (get) Token: 0x06005CA0 RID: 23712 RVA: 0x0014ED78 File Offset: 0x0014D178
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001353 RID: 4947
		// (get) Token: 0x06005CA1 RID: 23713 RVA: 0x0014ED80 File Offset: 0x0014D180
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CA2 RID: 23714 RVA: 0x0014ED88 File Offset: 0x0014D188
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

		// Token: 0x06005CA3 RID: 23715 RVA: 0x0014EDF8 File Offset: 0x0014D1F8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CA4 RID: 23716 RVA: 0x0014EDFF File Offset: 0x0014D1FF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CA5 RID: 23717 RVA: 0x0014EE08 File Offset: 0x0014D208
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Relentless.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Relentless.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004F41 RID: 20289
		internal AdventureUnitSkill skill;

		// Token: 0x04004F42 RID: 20290
		internal IEnumerator $locvar0;

		// Token: 0x04004F43 RID: 20291
		internal object <_>__1;

		// Token: 0x04004F44 RID: 20292
		internal IDisposable $locvar1;

		// Token: 0x04004F45 RID: 20293
		internal Relentless $this;

		// Token: 0x04004F46 RID: 20294
		internal object $current;

		// Token: 0x04004F47 RID: 20295
		internal bool $disposing;

		// Token: 0x04004F48 RID: 20296
		internal int $PC;
	}
}
