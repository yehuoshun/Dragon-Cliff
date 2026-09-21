using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000707 RID: 1799
public class ShieldBurn : MainSkillBase
{
	// Token: 0x060031A0 RID: 12704 RVA: 0x00150E0D File Offset: 0x0014F20D
	public ShieldBurn()
	{
	}

	// Token: 0x17000716 RID: 1814
	// (get) Token: 0x060031A1 RID: 12705 RVA: 0x00150E15 File Offset: 0x0014F215
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x17000717 RID: 1815
	// (get) Token: 0x060031A2 RID: 12706 RVA: 0x00150E18 File Offset: 0x0014F218
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000718 RID: 1816
	// (get) Token: 0x060031A3 RID: 12707 RVA: 0x00150E1B File Offset: 0x0014F21B
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Divine;
		}
	}

	// Token: 0x17000719 RID: 1817
	// (get) Token: 0x060031A4 RID: 12708 RVA: 0x00150E1E File Offset: 0x0014F21E
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x1700071A RID: 1818
	// (get) Token: 0x060031A5 RID: 12709 RVA: 0x00150E21 File Offset: 0x0014F221
	public override SkillType SkillType
	{
		get
		{
			return SkillType.ShieldBurn;
		}
	}

	// Token: 0x1700071B RID: 1819
	// (get) Token: 0x060031A6 RID: 12710 RVA: 0x00150E28 File Offset: 0x0014F228
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060031A7 RID: 12711 RVA: 0x00150E30 File Offset: 0x0014F230
	private double GetDamagePercentage(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x060031A8 RID: 12712 RVA: 0x00150E4F File Offset: 0x0014F24F
	private double GetSecondDamagePercentage(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x060031A9 RID: 12713 RVA: 0x00150E6E File Offset: 0x0014F26E
	private double PenetrationRate(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x060031AA RID: 12714 RVA: 0x00150E90 File Offset: 0x0014F290
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.MainOvertimeDamageRatekey, this.GetSecondDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterOvertimeDamageRatekey, this.GetSecondDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.DecreaseRateKey, this.PenetrationRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060031AB RID: 12715 RVA: 0x00150F24 File Offset: 0x0014F324
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Divine), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PhysicalResistance, OrderingType.Asc, new int?(1)), skill);
	}

	// Token: 0x060031AC RID: 12716 RVA: 0x00150FA4 File Offset: 0x0014F3A4
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031AD RID: 12717 RVA: 0x00150FAC File Offset: 0x0014F3AC
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			IEnumerator enumerator2 = target.ApplySkillEffect(new ShieldBurnEffect(3f, this.PenetrationRate(skill.Skill), new List<DamageHitDefinition>
			{
				new DamageHitDefinition
				{
					Potions = new List<DamageHitModuleDefinition>
					{
						new DamageHitModuleDefinition(null, this.GetSecondDamagePercentage(skill.Skill)),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Divine), this.GetSecondDamagePercentage(skill.Skill))
					}
				}
			}, skill, base.GetType().FullName, target), false).GetEnumerator();
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

	// Token: 0x040027AD RID: 10157
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E6C RID: 3692
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CD6 RID: 23766 RVA: 0x00150FDD File Offset: 0x0014F3DD
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CD7 RID: 23767 RVA: 0x00150FE8 File Offset: 0x0014F3E8
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
					target = damageBattleDamage.Target;
					enumerator2 = target.ApplySkillEffect(new ShieldBurnEffect(3f, base.PenetrationRate(skill.Skill), new List<DamageHitDefinition>
					{
						new DamageHitDefinition
						{
							Potions = new List<DamageHitModuleDefinition>
							{
								new DamageHitModuleDefinition(null, base.GetSecondDamagePercentage(skill.Skill)),
								new DamageHitModuleDefinition(new OutputType?(OutputType.Divine), base.GetSecondDamagePercentage(skill.Skill))
							}
						}
					}, skill, base.GetType().FullName, target), false).GetEnumerator();
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

		// Token: 0x1700135E RID: 4958
		// (get) Token: 0x06005CD8 RID: 23768 RVA: 0x00151220 File Offset: 0x0014F620
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700135F RID: 4959
		// (get) Token: 0x06005CD9 RID: 23769 RVA: 0x00151228 File Offset: 0x0014F628
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CDA RID: 23770 RVA: 0x00151230 File Offset: 0x0014F630
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

		// Token: 0x06005CDB RID: 23771 RVA: 0x001512C4 File Offset: 0x0014F6C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CDC RID: 23772 RVA: 0x001512CB File Offset: 0x0014F6CB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CDD RID: 23773 RVA: 0x001512D4 File Offset: 0x0014F6D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ShieldBurn.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new ShieldBurn.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004F9A RID: 20378
		internal ReleaseableDamage damage;

		// Token: 0x04004F9B RID: 20379
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004F9C RID: 20380
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004F9D RID: 20381
		internal IBattleUnit <target>__2;

		// Token: 0x04004F9E RID: 20382
		internal AdventureUnitSkill skill;

		// Token: 0x04004F9F RID: 20383
		internal IEnumerator $locvar1;

		// Token: 0x04004FA0 RID: 20384
		internal object <_>__3;

		// Token: 0x04004FA1 RID: 20385
		internal IDisposable $locvar2;

		// Token: 0x04004FA2 RID: 20386
		internal ShieldBurn $this;

		// Token: 0x04004FA3 RID: 20387
		internal object $current;

		// Token: 0x04004FA4 RID: 20388
		internal bool $disposing;

		// Token: 0x04004FA5 RID: 20389
		internal int $PC;
	}
}
