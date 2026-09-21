using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000711 RID: 1809
public class BloodThirst : SecondarySkillBase
{
	// Token: 0x06003221 RID: 12833 RVA: 0x00153FF9 File Offset: 0x001523F9
	public BloodThirst()
	{
	}

	// Token: 0x17000752 RID: 1874
	// (get) Token: 0x06003222 RID: 12834 RVA: 0x00154014 File Offset: 0x00152414
	public override SkillType SkillType
	{
		get
		{
			return SkillType.BloodThirst;
		}
	}

	// Token: 0x17000753 RID: 1875
	// (get) Token: 0x06003223 RID: 12835 RVA: 0x0015401B File Offset: 0x0015241B
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003224 RID: 12836 RVA: 0x00154023 File Offset: 0x00152423
	private double GetDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06003225 RID: 12837 RVA: 0x00154042 File Offset: 0x00152442
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainOvertimeDamageRatekey, (this.GetDamagePercentage(skill) * 100.0).ToExpression()).ToString();
		return description;
	}

	// Token: 0x06003226 RID: 12838 RVA: 0x00154078 File Offset: 0x00152478
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		IBattleUnit caster = processingSkill.SourceUnit;
		if (eventType == AdventureEventType.DamageReleased && data is ReleaseableDamage && eventTriggerUnit == skillOwner)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			if (damage.Dealer == caster)
			{
				foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
				{
					double totalDamageDone = (from d in damageBattleDamage.Damages
					where d.IsDirectDamage
					select d).Sum((DamageComponent b) => b.GetTotalDamageSoFar());
					if (totalDamageDone > 0.0)
					{
						IEnumerator enumerator2 = DamageOverTimeEffect.AddDamageOverTurn(damageBattleDamage.Target, processingSkill, this.GetDamagePercentage(processingSkill.Skill) * processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, 2, OutputType.Physical).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x17000754 RID: 1876
	// (get) Token: 0x06003227 RID: 12839 RVA: 0x001540C0 File Offset: 0x001524C0
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000755 RID: 1877
	// (get) Token: 0x06003228 RID: 12840 RVA: 0x001540C3 File Offset: 0x001524C3
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000756 RID: 1878
	// (get) Token: 0x06003229 RID: 12841 RVA: 0x001540C6 File Offset: 0x001524C6
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.None;
		}
	}

	// Token: 0x0600322A RID: 12842 RVA: 0x001540CC File Offset: 0x001524CC
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x17000757 RID: 1879
	// (get) Token: 0x0600322B RID: 12843 RVA: 0x001540E8 File Offset: 0x001524E8
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x17000758 RID: 1880
	// (get) Token: 0x0600322C RID: 12844 RVA: 0x001540F0 File Offset: 0x001524F0
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027B7 RID: 10167
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027B8 RID: 10168
	private int? _requiredSchoolLevel = new int?(2);

	// Token: 0x02000E74 RID: 3700
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D19 RID: 23833 RVA: 0x001540F3 File Offset: 0x001524F3
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D1A RID: 23834 RVA: 0x001540FC File Offset: 0x001524FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				caster = processingSkill.SourceUnit;
				if (eventType != AdventureEventType.DamageReleased || !(data is ReleaseableDamage) || eventTriggerUnit != skillOwner)
				{
					goto IL_22D;
				}
				damage = (data as ReleaseableDamage);
				if (damage.Dealer != caster)
				{
					goto IL_22D;
				}
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
					Block_11:
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
					totalDamageDone = (from d in damageBattleDamage.Damages
					where d.IsDirectDamage
					select d).Sum((DamageComponent b) => b.GetTotalDamageSoFar());
					if (totalDamageDone > 0.0)
					{
						enumerator2 = DamageOverTimeEffect.AddDamageOverTurn(damageBattleDamage.Target, processingSkill, base.GetDamagePercentage(processingSkill.Skill) * processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, 2, OutputType.Physical).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
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
			IL_22D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700136E RID: 4974
		// (get) Token: 0x06005D1B RID: 23835 RVA: 0x00154374 File Offset: 0x00152774
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700136F RID: 4975
		// (get) Token: 0x06005D1C RID: 23836 RVA: 0x0015437C File Offset: 0x0015277C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D1D RID: 23837 RVA: 0x00154384 File Offset: 0x00152784
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

		// Token: 0x06005D1E RID: 23838 RVA: 0x00154418 File Offset: 0x00152818
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D1F RID: 23839 RVA: 0x0015441F File Offset: 0x0015281F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D20 RID: 23840 RVA: 0x00154428 File Offset: 0x00152828
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BloodThirst.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new BloodThirst.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.skillOwner = skillOwner;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005D21 RID: 23841 RVA: 0x00154498 File Offset: 0x00152898
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage;
		}

		// Token: 0x06005D22 RID: 23842 RVA: 0x001544A0 File Offset: 0x001528A0
		private static double <>m__1(DamageComponent b)
		{
			return b.GetTotalDamageSoFar();
		}

		// Token: 0x04005018 RID: 20504
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04005019 RID: 20505
		internal IBattleUnit <caster>__0;

		// Token: 0x0400501A RID: 20506
		internal AdventureEventType eventType;

		// Token: 0x0400501B RID: 20507
		internal object data;

		// Token: 0x0400501C RID: 20508
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400501D RID: 20509
		internal IBattleUnit skillOwner;

		// Token: 0x0400501E RID: 20510
		internal ReleaseableDamage <damage>__1;

		// Token: 0x0400501F RID: 20511
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005020 RID: 20512
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005021 RID: 20513
		internal double <totalDamageDone>__3;

		// Token: 0x04005022 RID: 20514
		internal IEnumerator $locvar1;

		// Token: 0x04005023 RID: 20515
		internal object <_>__4;

		// Token: 0x04005024 RID: 20516
		internal IDisposable $locvar2;

		// Token: 0x04005025 RID: 20517
		internal BloodThirst $this;

		// Token: 0x04005026 RID: 20518
		internal object $current;

		// Token: 0x04005027 RID: 20519
		internal bool $disposing;

		// Token: 0x04005028 RID: 20520
		internal int $PC;

		// Token: 0x04005029 RID: 20521
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x0400502A RID: 20522
		private static Func<DamageComponent, double> <>f__am$cache1;
	}
}
