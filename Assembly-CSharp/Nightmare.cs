using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006FD RID: 1789
public class Nightmare : MainSkillBase
{
	// Token: 0x0600311B RID: 12571 RVA: 0x0014DB9C File Offset: 0x0014BF9C
	public Nightmare()
	{
	}

	// Token: 0x170006DA RID: 1754
	// (get) Token: 0x0600311C RID: 12572 RVA: 0x0014DBA4 File Offset: 0x0014BFA4
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x170006DB RID: 1755
	// (get) Token: 0x0600311D RID: 12573 RVA: 0x0014DBA7 File Offset: 0x0014BFA7
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006DC RID: 1756
	// (get) Token: 0x0600311E RID: 12574 RVA: 0x0014DBAA File Offset: 0x0014BFAA
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x170006DD RID: 1757
	// (get) Token: 0x0600311F RID: 12575 RVA: 0x0014DBAD File Offset: 0x0014BFAD
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006DE RID: 1758
	// (get) Token: 0x06003120 RID: 12576 RVA: 0x0014DBB0 File Offset: 0x0014BFB0
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Nightmare;
		}
	}

	// Token: 0x170006DF RID: 1759
	// (get) Token: 0x06003121 RID: 12577 RVA: 0x0014DBB7 File Offset: 0x0014BFB7
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003122 RID: 12578 RVA: 0x0014DBBF File Offset: 0x0014BFBF
	private double GetDamagePercentage(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.15;
	}

	// Token: 0x06003123 RID: 12579 RVA: 0x0014DBDE File Offset: 0x0014BFDE
	private double GetSecondDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x06003124 RID: 12580 RVA: 0x0014DBFD File Offset: 0x0014BFFD
	private double GetSecondDamageValue(AdventureUnitSkill skill)
	{
		return base.CalculateDamageRaw(this.GetSecondDamagePercentage(skill.Skill), skill);
	}

	// Token: 0x06003125 RID: 12581 RVA: 0x0014DC14 File Offset: 0x0014C014
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.MainOvertimeDamageRatekey, this.GetSecondDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003126 RID: 12582 RVA: 0x0014DC64 File Offset: 0x0014C064
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
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x06003127 RID: 12583 RVA: 0x0014DCC6 File Offset: 0x0014C0C6
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003128 RID: 12584 RVA: 0x0014DCD0 File Offset: 0x0014C0D0
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			IEnumerator enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(target, skill, this.GetSecondDamageValue(skill), 5, OutputType.Shadow).GetEnumerator();
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

	// Token: 0x040027A3 RID: 10147
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E5F RID: 3679
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C87 RID: 23687 RVA: 0x0014DD01 File Offset: 0x0014C101
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C88 RID: 23688 RVA: 0x0014DD0C File Offset: 0x0014C10C
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
					enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(target, skill, base.GetSecondDamageValue(skill), 5, OutputType.Shadow).GetEnumerator();
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

		// Token: 0x1700134E RID: 4942
		// (get) Token: 0x06005C89 RID: 23689 RVA: 0x0014DE90 File Offset: 0x0014C290
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700134F RID: 4943
		// (get) Token: 0x06005C8A RID: 23690 RVA: 0x0014DE98 File Offset: 0x0014C298
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C8B RID: 23691 RVA: 0x0014DEA0 File Offset: 0x0014C2A0
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

		// Token: 0x06005C8C RID: 23692 RVA: 0x0014DF34 File Offset: 0x0014C334
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C8D RID: 23693 RVA: 0x0014DF3B File Offset: 0x0014C33B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C8E RID: 23694 RVA: 0x0014DF44 File Offset: 0x0014C344
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Nightmare.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Nightmare.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004F17 RID: 20247
		internal ReleaseableDamage damage;

		// Token: 0x04004F18 RID: 20248
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004F19 RID: 20249
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004F1A RID: 20250
		internal IBattleUnit <target>__2;

		// Token: 0x04004F1B RID: 20251
		internal AdventureUnitSkill skill;

		// Token: 0x04004F1C RID: 20252
		internal IEnumerator $locvar1;

		// Token: 0x04004F1D RID: 20253
		internal object <_>__3;

		// Token: 0x04004F1E RID: 20254
		internal IDisposable $locvar2;

		// Token: 0x04004F1F RID: 20255
		internal Nightmare $this;

		// Token: 0x04004F20 RID: 20256
		internal object $current;

		// Token: 0x04004F21 RID: 20257
		internal bool $disposing;

		// Token: 0x04004F22 RID: 20258
		internal int $PC;
	}
}
