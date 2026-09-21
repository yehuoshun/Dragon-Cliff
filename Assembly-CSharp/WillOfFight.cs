using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000710 RID: 1808
public class WillOfFight : MainSkillBase
{
	// Token: 0x06003214 RID: 12820 RVA: 0x00153C53 File Offset: 0x00152053
	public WillOfFight()
	{
	}

	// Token: 0x06003215 RID: 12821 RVA: 0x00153C5C File Offset: 0x0015205C
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
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Speed, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x06003216 RID: 12822 RVA: 0x00153CDC File Offset: 0x001520DC
	private double GetDamagePercentage(Skill skill)
	{
		return 0.7 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06003217 RID: 12823 RVA: 0x00153CFB File Offset: 0x001520FB
	private double GetSpeedReductionRate(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x06003218 RID: 12824 RVA: 0x00153D1C File Offset: 0x0015211C
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.DecreaseRateKey, this.GetSpeedReductionRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003219 RID: 12825 RVA: 0x00153D80 File Offset: 0x00152180
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600321A RID: 12826 RVA: 0x00153D88 File Offset: 0x00152188
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		IBattleUnit caster = skill.SourceUnit;
		IEnumerator enumerator = caster.ApplySkillEffect(AttributeModificationEffect.CreateMoraleReductionEffect(skill, this.GetSpeedReductionRate(skill.Skill), base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x1700074C RID: 1868
	// (get) Token: 0x0600321B RID: 12827 RVA: 0x00153DB2 File Offset: 0x001521B2
	public override SkillType SkillType
	{
		get
		{
			return SkillType.WillOfFight;
		}
	}

	// Token: 0x1700074D RID: 1869
	// (get) Token: 0x0600321C RID: 12828 RVA: 0x00153DB9 File Offset: 0x001521B9
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x1700074E RID: 1870
	// (get) Token: 0x0600321D RID: 12829 RVA: 0x00153DC1 File Offset: 0x001521C1
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700074F RID: 1871
	// (get) Token: 0x0600321E RID: 12830 RVA: 0x00153DC4 File Offset: 0x001521C4
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000750 RID: 1872
	// (get) Token: 0x0600321F RID: 12831 RVA: 0x00153DC7 File Offset: 0x001521C7
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000751 RID: 1873
	// (get) Token: 0x06003220 RID: 12832 RVA: 0x00153DCA File Offset: 0x001521CA
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027B6 RID: 10166
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E73 RID: 3699
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D11 RID: 23825 RVA: 0x00153DCD File Offset: 0x001521CD
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005D12 RID: 23826 RVA: 0x00153DD8 File Offset: 0x001521D8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				caster = skill.SourceUnit;
				enumerator = caster.ApplySkillEffect(AttributeModificationEffect.CreateMoraleReductionEffect(skill, base.GetSpeedReductionRate(skill.Skill), base.GetType().FullName), false).GetEnumerator();
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

		// Token: 0x1700136C RID: 4972
		// (get) Token: 0x06005D13 RID: 23827 RVA: 0x00153F00 File Offset: 0x00152300
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700136D RID: 4973
		// (get) Token: 0x06005D14 RID: 23828 RVA: 0x00153F08 File Offset: 0x00152308
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D15 RID: 23829 RVA: 0x00153F10 File Offset: 0x00152310
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

		// Token: 0x06005D16 RID: 23830 RVA: 0x00153F80 File Offset: 0x00152380
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D17 RID: 23831 RVA: 0x00153F87 File Offset: 0x00152387
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D18 RID: 23832 RVA: 0x00153F90 File Offset: 0x00152390
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			WillOfFight.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new WillOfFight.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x0400500F RID: 20495
		internal AdventureUnitSkill skill;

		// Token: 0x04005010 RID: 20496
		internal IBattleUnit <caster>__0;

		// Token: 0x04005011 RID: 20497
		internal IEnumerator $locvar0;

		// Token: 0x04005012 RID: 20498
		internal object <_>__1;

		// Token: 0x04005013 RID: 20499
		internal IDisposable $locvar1;

		// Token: 0x04005014 RID: 20500
		internal WillOfFight $this;

		// Token: 0x04005015 RID: 20501
		internal object $current;

		// Token: 0x04005016 RID: 20502
		internal bool $disposing;

		// Token: 0x04005017 RID: 20503
		internal int $PC;
	}
}
