using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200071A RID: 1818
public class Rebirth : SecondarySkillBase
{
	// Token: 0x0600328F RID: 12943 RVA: 0x001561AF File Offset: 0x001545AF
	public Rebirth()
	{
	}

	// Token: 0x17000791 RID: 1937
	// (get) Token: 0x06003290 RID: 12944 RVA: 0x001561CA File Offset: 0x001545CA
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Rebirth;
		}
	}

	// Token: 0x17000792 RID: 1938
	// (get) Token: 0x06003291 RID: 12945 RVA: 0x001561D1 File Offset: 0x001545D1
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003292 RID: 12946 RVA: 0x001561D9 File Offset: 0x001545D9
	private double GetHealLifeRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06003293 RID: 12947 RVA: 0x001561F8 File Offset: 0x001545F8
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.HealRateKey, this.GetHealLifeRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003294 RID: 12948 RVA: 0x00156220 File Offset: 0x00154620
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPreKilled && eventTriggerUnit.HealthPoints <= 0.0 && eventTriggerUnit == processingSkill.SourceUnit)
		{
			if (eventTriggerUnit.BattleEffects.All((BattleEffectBase ef) => !(ef is ExhaustedEffect)))
			{
				double healRate = this.GetHealLifeRate(processingSkill.Skill);
				double heal = healRate * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) - eventTriggerUnit.HealthPoints;
				ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(eventTriggerUnit, processingSkill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, true)
				}, processingSkill.SourceUnit);
				IEnumerator enumerator = releaseable.Release().GetEnumerator();
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
				IEnumerator enumerator2 = eventTriggerUnit.ApplySkillEffect(new ExhaustedEffect(processingSkill, base.GetType().FullName), false).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x17000793 RID: 1939
	// (get) Token: 0x06003295 RID: 12949 RVA: 0x00156259 File Offset: 0x00154659
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x17000794 RID: 1940
	// (get) Token: 0x06003296 RID: 12950 RVA: 0x0015625C File Offset: 0x0015465C
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000795 RID: 1941
	// (get) Token: 0x06003297 RID: 12951 RVA: 0x0015625F File Offset: 0x0015465F
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x06003298 RID: 12952 RVA: 0x00156264 File Offset: 0x00154664
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPreKilled
		};
	}

	// Token: 0x17000796 RID: 1942
	// (get) Token: 0x06003299 RID: 12953 RVA: 0x00156280 File Offset: 0x00154680
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x17000797 RID: 1943
	// (get) Token: 0x0600329A RID: 12954 RVA: 0x00156288 File Offset: 0x00154688
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027C9 RID: 10185
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027CA RID: 10186
	private int? _requiredSchoolLevel = new int?(2);

	// Token: 0x02000E7E RID: 3710
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D65 RID: 23909 RVA: 0x0015628B File Offset: 0x0015468B
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D66 RID: 23910 RVA: 0x00156294 File Offset: 0x00154694
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPreKilled || eventTriggerUnit.HealthPoints > 0.0 || eventTriggerUnit != processingSkill.SourceUnit)
				{
					goto IL_295;
				}
				if (!eventTriggerUnit.BattleEffects.All((BattleEffectBase ef) => !(ef is ExhaustedEffect)))
				{
					goto IL_295;
				}
				healRate = base.GetHealLifeRate(processingSkill.Skill);
				heal = healRate * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) - eventTriggerUnit.HealthPoints;
				releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(eventTriggerUnit, processingSkill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, true)
				}, processingSkill.SourceUnit);
				enumerator = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_211;
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
			enumerator2 = eventTriggerUnit.ApplySkillEffect(new ExhaustedEffect(processingSkill, base.GetType().FullName), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_211:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_295:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001380 RID: 4992
		// (get) Token: 0x06005D67 RID: 23911 RVA: 0x0015655C File Offset: 0x0015495C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001381 RID: 4993
		// (get) Token: 0x06005D68 RID: 23912 RVA: 0x00156564 File Offset: 0x00154964
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D69 RID: 23913 RVA: 0x0015656C File Offset: 0x0015496C
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005D6A RID: 23914 RVA: 0x0015661C File Offset: 0x00154A1C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D6B RID: 23915 RVA: 0x00156623 File Offset: 0x00154A23
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D6C RID: 23916 RVA: 0x0015662C File Offset: 0x00154A2C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Rebirth.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Rebirth.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005D6D RID: 23917 RVA: 0x00156684 File Offset: 0x00154A84
		private static bool <>m__0(BattleEffectBase ef)
		{
			return !(ef is ExhaustedEffect);
		}

		// Token: 0x04005099 RID: 20633
		internal AdventureEventType eventType;

		// Token: 0x0400509A RID: 20634
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400509B RID: 20635
		internal AdventureUnitSkill processingSkill;

		// Token: 0x0400509C RID: 20636
		internal double <healRate>__1;

		// Token: 0x0400509D RID: 20637
		internal double <heal>__1;

		// Token: 0x0400509E RID: 20638
		internal ReleaseableHeal <releaseable>__1;

		// Token: 0x0400509F RID: 20639
		internal IEnumerator $locvar0;

		// Token: 0x040050A0 RID: 20640
		internal object <_>__2;

		// Token: 0x040050A1 RID: 20641
		internal IDisposable $locvar1;

		// Token: 0x040050A2 RID: 20642
		internal IEnumerator $locvar2;

		// Token: 0x040050A3 RID: 20643
		internal object <_>__3;

		// Token: 0x040050A4 RID: 20644
		internal IDisposable $locvar3;

		// Token: 0x040050A5 RID: 20645
		internal Rebirth $this;

		// Token: 0x040050A6 RID: 20646
		internal object $current;

		// Token: 0x040050A7 RID: 20647
		internal bool $disposing;

		// Token: 0x040050A8 RID: 20648
		internal int $PC;

		// Token: 0x040050A9 RID: 20649
		private static Func<BattleEffectBase, bool> <>f__am$cache0;
	}
}
