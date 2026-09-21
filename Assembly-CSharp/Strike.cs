using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200070B RID: 1803
public class Strike : MainSkillBase
{
	// Token: 0x060031D4 RID: 12756 RVA: 0x00152160 File Offset: 0x00150560
	public Strike()
	{
	}

	// Token: 0x1700072E RID: 1838
	// (get) Token: 0x060031D5 RID: 12757 RVA: 0x00152168 File Offset: 0x00150568
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Strike;
		}
	}

	// Token: 0x1700072F RID: 1839
	// (get) Token: 0x060031D6 RID: 12758 RVA: 0x0015216F File Offset: 0x0015056F
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060031D7 RID: 12759 RVA: 0x00152178 File Offset: 0x00150578
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

	// Token: 0x060031D8 RID: 12760 RVA: 0x001521F7 File Offset: 0x001505F7
	private double GetDamagePercentage(Skill skill)
	{
		return 0.8 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060031D9 RID: 12761 RVA: 0x00152218 File Offset: 0x00150618
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060031DA RID: 12762 RVA: 0x00152265 File Offset: 0x00150665
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031DB RID: 12763 RVA: 0x0015226C File Offset: 0x0015066C
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		List<BattleDamage> extraDamages = new List<BattleDamage>();
		List<IBattleUnit> targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
		foreach (BattleDamage battleDamage in damage.BattleDamages)
		{
			IBattleUnit battleUnit = battleDamage.Target;
			foreach (DamageComponent damageComponent in battleDamage.Damages)
			{
				if (damageComponent.IsCrit && targets.Any<IBattleUnit>())
				{
					if (battleUnit.Status != BattleUnitStatus.Active)
					{
						battleUnit = targets.GetRandomUnit();
					}
					BattleDamage item = new BattleDamage(battleUnit, skill, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(skill.SourceUnit, battleUnit, OutputType.Physical, this.GetDamagePercentage(skill.Skill)),
							new DamagePotionValue(skill.SourceUnit, battleUnit, skill.SourceUnit.GetOutputType(), this.GetDamagePercentage(skill.Skill))
						}, battleUnit, skill.SourceUnit, true, true)
					});
					extraDamages.Add(item);
				}
			}
		}
		ReleaseableDamage releaseable = new ReleaseableDamage(extraDamages, skill.SourceUnit);
		IEnumerator enumerator3 = releaseable.Release().GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				object _ = enumerator3.Current;
				yield return _;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator3 as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x17000730 RID: 1840
	// (get) Token: 0x060031DC RID: 12764 RVA: 0x0015229D File Offset: 0x0015069D
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000731 RID: 1841
	// (get) Token: 0x060031DD RID: 12765 RVA: 0x001522A0 File Offset: 0x001506A0
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000732 RID: 1842
	// (get) Token: 0x060031DE RID: 12766 RVA: 0x001522A3 File Offset: 0x001506A3
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000733 RID: 1843
	// (get) Token: 0x060031DF RID: 12767 RVA: 0x001522A6 File Offset: 0x001506A6
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027B1 RID: 10161
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E6F RID: 3695
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CEF RID: 23791 RVA: 0x001522A9 File Offset: 0x001506A9
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CF0 RID: 23792 RVA: 0x001522B4 File Offset: 0x001506B4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				extraDamages = new List<BattleDamage>();
				targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
				enumerator = damage.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleDamage battleDamage = enumerator.Current;
						IBattleUnit battleUnit = battleDamage.Target;
						foreach (DamageComponent damageComponent in battleDamage.Damages)
						{
							if (damageComponent.IsCrit && targets.Any<IBattleUnit>())
							{
								if (battleUnit.Status != BattleUnitStatus.Active)
								{
									battleUnit = targets.GetRandomUnit();
								}
								BattleDamage item = new BattleDamage(battleUnit, skill, new List<DamageComponentValue>
								{
									new DamageComponentValue(new List<DamagePotionValue>
									{
										new DamagePotionValue(skill.SourceUnit, battleUnit, OutputType.Physical, base.GetDamagePercentage(skill.Skill)),
										new DamagePotionValue(skill.SourceUnit, battleUnit, skill.SourceUnit.GetOutputType(), base.GetDamagePercentage(skill.Skill))
									}, battleUnit, skill.SourceUnit, true, true)
								});
								extraDamages.Add(item);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				releaseable = new ReleaseableDamage(extraDamages, skill.SourceUnit);
				enumerator3 = releaseable.Release().GetEnumerator();
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
				if (enumerator3.MoveNext())
				{
					_ = enumerator3.Current;
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
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001364 RID: 4964
		// (get) Token: 0x06005CF1 RID: 23793 RVA: 0x00152590 File Offset: 0x00150990
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001365 RID: 4965
		// (get) Token: 0x06005CF2 RID: 23794 RVA: 0x00152598 File Offset: 0x00150998
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CF3 RID: 23795 RVA: 0x001525A0 File Offset: 0x001509A0
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
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005CF4 RID: 23796 RVA: 0x00152610 File Offset: 0x00150A10
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CF5 RID: 23797 RVA: 0x00152617 File Offset: 0x00150A17
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CF6 RID: 23798 RVA: 0x00152620 File Offset: 0x00150A20
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Strike.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Strike.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004FCB RID: 20427
		internal List<BattleDamage> <extraDamages>__0;

		// Token: 0x04004FCC RID: 20428
		internal AdventureUnitSkill skill;

		// Token: 0x04004FCD RID: 20429
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04004FCE RID: 20430
		internal ReleaseableDamage damage;

		// Token: 0x04004FCF RID: 20431
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004FD0 RID: 20432
		internal ReleaseableDamage <releaseable>__0;

		// Token: 0x04004FD1 RID: 20433
		internal IEnumerator $locvar2;

		// Token: 0x04004FD2 RID: 20434
		internal object <_>__1;

		// Token: 0x04004FD3 RID: 20435
		internal IDisposable $locvar3;

		// Token: 0x04004FD4 RID: 20436
		internal Strike $this;

		// Token: 0x04004FD5 RID: 20437
		internal object $current;

		// Token: 0x04004FD6 RID: 20438
		internal bool $disposing;

		// Token: 0x04004FD7 RID: 20439
		internal int $PC;
	}
}
