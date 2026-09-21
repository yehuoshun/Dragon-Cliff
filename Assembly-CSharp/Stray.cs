using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200071F RID: 1823
public class Stray : SecondarySkillBase
{
	// Token: 0x060032C3 RID: 12995 RVA: 0x00157140 File Offset: 0x00155540
	public Stray()
	{
	}

	// Token: 0x170007B0 RID: 1968
	// (get) Token: 0x060032C4 RID: 12996 RVA: 0x0015715B File Offset: 0x0015555B
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x170007B1 RID: 1969
	// (get) Token: 0x060032C5 RID: 12997 RVA: 0x0015715E File Offset: 0x0015555E
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170007B2 RID: 1970
	// (get) Token: 0x060032C6 RID: 12998 RVA: 0x00157161 File Offset: 0x00155561
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x170007B3 RID: 1971
	// (get) Token: 0x060032C7 RID: 12999 RVA: 0x00157164 File Offset: 0x00155564
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x060032C8 RID: 13000 RVA: 0x00157167 File Offset: 0x00155567
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170007B4 RID: 1972
	// (get) Token: 0x060032C9 RID: 13001 RVA: 0x0015716E File Offset: 0x0015556E
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x170007B5 RID: 1973
	// (get) Token: 0x060032CA RID: 13002 RVA: 0x00157176 File Offset: 0x00155576
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Stray;
		}
	}

	// Token: 0x170007B6 RID: 1974
	// (get) Token: 0x060032CB RID: 13003 RVA: 0x0015717D File Offset: 0x0015557D
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060032CC RID: 13004 RVA: 0x00157185 File Offset: 0x00155585
	private double GetDamagePercentage(Skill skill)
	{
		return 0.26 + (double)(skill.Level - 1) * 0.03;
	}

	// Token: 0x060032CD RID: 13005 RVA: 0x001571A4 File Offset: 0x001555A4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060032CE RID: 13006 RVA: 0x001571D0 File Offset: 0x001555D0
	public IDamageDefinition StrayDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x060032CF RID: 13007 RVA: 0x00157230 File Offset: 0x00155630
	public override IEnumerable PerSecondLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit skillOwner)
	{
		ReleaseableDamage damage = this.StrayDamageDefinition(processingSkill).GetReleaseableDamage(skillOwner, processingSkill);
		IEnumerator enumerator = damage.Release().GetEnumerator();
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

	// Token: 0x040027D3 RID: 10195
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027D4 RID: 10196
	private int? _requiredSchoolLevel = new int?(2);

	// Token: 0x02000E83 RID: 3715
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D88 RID: 23944 RVA: 0x00157261 File Offset: 0x00155661
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D89 RID: 23945 RVA: 0x0015726C File Offset: 0x0015566C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damage = base.StrayDamageDefinition(processingSkill).GetReleaseableDamage(skillOwner, processingSkill);
				enumerator = damage.Release().GetEnumerator();
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

		// Token: 0x17001388 RID: 5000
		// (get) Token: 0x06005D8A RID: 23946 RVA: 0x0015737C File Offset: 0x0015577C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001389 RID: 5001
		// (get) Token: 0x06005D8B RID: 23947 RVA: 0x00157384 File Offset: 0x00155784
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D8C RID: 23948 RVA: 0x0015738C File Offset: 0x0015578C
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

		// Token: 0x06005D8D RID: 23949 RVA: 0x001573FC File Offset: 0x001557FC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D8E RID: 23950 RVA: 0x00157403 File Offset: 0x00155803
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D8F RID: 23951 RVA: 0x0015740C File Offset: 0x0015580C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Stray.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new Stray.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			<PerSecondLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<PerSecondLogic_ActiveUnit>c__Iterator.skillOwner = skillOwner;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040050D4 RID: 20692
		internal AdventureUnitSkill processingSkill;

		// Token: 0x040050D5 RID: 20693
		internal IBattleUnit skillOwner;

		// Token: 0x040050D6 RID: 20694
		internal ReleaseableDamage <damage>__0;

		// Token: 0x040050D7 RID: 20695
		internal IEnumerator $locvar0;

		// Token: 0x040050D8 RID: 20696
		internal object <_>__1;

		// Token: 0x040050D9 RID: 20697
		internal IDisposable $locvar1;

		// Token: 0x040050DA RID: 20698
		internal Stray $this;

		// Token: 0x040050DB RID: 20699
		internal object $current;

		// Token: 0x040050DC RID: 20700
		internal bool $disposing;

		// Token: 0x040050DD RID: 20701
		internal int $PC;
	}
}
