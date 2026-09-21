using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006EC RID: 1772
public class Confusion : MainSkillBase
{
	// Token: 0x06003040 RID: 12352 RVA: 0x001490F1 File Offset: 0x001474F1
	public Confusion()
	{
	}

	// Token: 0x06003041 RID: 12353 RVA: 0x001490FC File Offset: 0x001474FC
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

	// Token: 0x06003042 RID: 12354 RVA: 0x0014917F File Offset: 0x0014757F
	private double GetDamagePercentage(Skill skill)
	{
		return 0.8 + (double)(skill.Level - 1) * 0.08;
	}

	// Token: 0x06003043 RID: 12355 RVA: 0x0014919E File Offset: 0x0014759E
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.22;
	}

	// Token: 0x06003044 RID: 12356 RVA: 0x001491C0 File Offset: 0x001475C0
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003045 RID: 12357 RVA: 0x0014920D File Offset: 0x0014760D
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003046 RID: 12358 RVA: 0x00149214 File Offset: 0x00147614
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		IBattleUnit caster = skill.SourceUnit;
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			if (damageBattleDamage.Target.Status == BattleUnitStatus.Active)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => !d.IsMissed))
				{
					IEnumerator enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new TauntEffect(caster, damageBattleDamage.Target, skill, new int?(2), true), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x17000678 RID: 1656
	// (get) Token: 0x06003047 RID: 12359 RVA: 0x0014923E File Offset: 0x0014763E
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Confusion;
		}
	}

	// Token: 0x17000679 RID: 1657
	// (get) Token: 0x06003048 RID: 12360 RVA: 0x00149245 File Offset: 0x00147645
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x1700067A RID: 1658
	// (get) Token: 0x06003049 RID: 12361 RVA: 0x0014924D File Offset: 0x0014764D
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700067B RID: 1659
	// (get) Token: 0x0600304A RID: 12362 RVA: 0x00149250 File Offset: 0x00147650
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Divine;
		}
	}

	// Token: 0x1700067C RID: 1660
	// (get) Token: 0x0600304B RID: 12363 RVA: 0x00149253 File Offset: 0x00147653
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x1700067D RID: 1661
	// (get) Token: 0x0600304C RID: 12364 RVA: 0x00149256 File Offset: 0x00147656
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x0400278F RID: 10127
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E51 RID: 3665
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C21 RID: 23585 RVA: 0x00149259 File Offset: 0x00147659
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C22 RID: 23586 RVA: 0x00149264 File Offset: 0x00147664
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				caster = skill.SourceUnit;
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
					Block_7:
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
					if (damageBattleDamage.Target.Status == BattleUnitStatus.Active)
					{
						if (damageBattleDamage.Damages.Any((DamageComponent d) => !d.IsMissed))
						{
							enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new TauntEffect(caster, damageBattleDamage.Target, skill, new int?(2), true), false).GetEnumerator();
							num = 4294967293u;
							goto Block_7;
						}
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

		// Token: 0x17001338 RID: 4920
		// (get) Token: 0x06005C23 RID: 23587 RVA: 0x00149458 File Offset: 0x00147858
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001339 RID: 4921
		// (get) Token: 0x06005C24 RID: 23588 RVA: 0x00149460 File Offset: 0x00147860
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C25 RID: 23589 RVA: 0x00149468 File Offset: 0x00147868
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

		// Token: 0x06005C26 RID: 23590 RVA: 0x001494FC File Offset: 0x001478FC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C27 RID: 23591 RVA: 0x00149503 File Offset: 0x00147903
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C28 RID: 23592 RVA: 0x0014950C File Offset: 0x0014790C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Confusion.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Confusion.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005C29 RID: 23593 RVA: 0x0014954C File Offset: 0x0014794C
		private static bool <>m__0(DamageComponent d)
		{
			return !d.IsMissed;
		}

		// Token: 0x04004E77 RID: 20087
		internal AdventureUnitSkill skill;

		// Token: 0x04004E78 RID: 20088
		internal IBattleUnit <caster>__0;

		// Token: 0x04004E79 RID: 20089
		internal ReleaseableDamage damage;

		// Token: 0x04004E7A RID: 20090
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004E7B RID: 20091
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004E7C RID: 20092
		internal IEnumerator $locvar1;

		// Token: 0x04004E7D RID: 20093
		internal object <_>__2;

		// Token: 0x04004E7E RID: 20094
		internal IDisposable $locvar2;

		// Token: 0x04004E7F RID: 20095
		internal object $current;

		// Token: 0x04004E80 RID: 20096
		internal bool $disposing;

		// Token: 0x04004E81 RID: 20097
		internal int $PC;

		// Token: 0x04004E82 RID: 20098
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
