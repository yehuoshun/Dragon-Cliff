using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000719 RID: 1817
public class Rage : SecondarySkillBase
{
	// Token: 0x06003283 RID: 12931 RVA: 0x00155D58 File Offset: 0x00154158
	public Rage()
	{
	}

	// Token: 0x1700078A RID: 1930
	// (get) Token: 0x06003284 RID: 12932 RVA: 0x00155D73 File Offset: 0x00154173
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Rage;
		}
	}

	// Token: 0x1700078B RID: 1931
	// (get) Token: 0x06003285 RID: 12933 RVA: 0x00155D7A File Offset: 0x0015417A
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003286 RID: 12934 RVA: 0x00155D82 File Offset: 0x00154182
	private double GetFocusBoost(Skill skill)
	{
		return 0.15 + (double)(skill.Level - 1) * 0.03;
	}

	// Token: 0x06003287 RID: 12935 RVA: 0x00155DA1 File Offset: 0x001541A1
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.BoostRateKey, this.GetFocusBoost(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003288 RID: 12936 RVA: 0x00155DC8 File Offset: 0x001541C8
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage)
		{
			List<IBattleUnit> friendlyUnits = processingSkill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(false);
			if (friendlyUnits.Any((IBattleUnit u) => u == eventTriggerUnit))
			{
				BattleDamage damage = data as BattleDamage;
				double focus = this.GetFocusBoost(processingSkill.Skill);
				foreach (DamageComponent damageComponent in damage.Damages)
				{
					if (damageComponent.IsCrit)
					{
						IEnumerator enumerator2 = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateRageEffect(processingSkill, focus, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x1700078C RID: 1932
	// (get) Token: 0x06003289 RID: 12937 RVA: 0x00155E09 File Offset: 0x00154209
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700078D RID: 1933
	// (get) Token: 0x0600328A RID: 12938 RVA: 0x00155E0C File Offset: 0x0015420C
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x1700078E RID: 1934
	// (get) Token: 0x0600328B RID: 12939 RVA: 0x00155E0F File Offset: 0x0015420F
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x0600328C RID: 12940 RVA: 0x00155E14 File Offset: 0x00154214
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x1700078F RID: 1935
	// (get) Token: 0x0600328D RID: 12941 RVA: 0x00155E30 File Offset: 0x00154230
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x17000790 RID: 1936
	// (get) Token: 0x0600328E RID: 12942 RVA: 0x00155E38 File Offset: 0x00154238
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027C7 RID: 10183
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027C8 RID: 10184
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E7C RID: 3708
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D5B RID: 23899 RVA: 0x00155E3B File Offset: 0x0015423B
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D5C RID: 23900 RVA: 0x00155E44 File Offset: 0x00154244
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage)
				{
					goto IL_1F5;
				}
				friendlyUnits = processingSkill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(false);
				if (!friendlyUnits.Any((IBattleUnit u) => u == eventTriggerUnit))
				{
					goto IL_1F5;
				}
				damage = (data as BattleDamage);
				focus = base.GetFocusBoost(processingSkill.Skill);
				enumerator = damage.Damages.GetEnumerator();
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
					damageComponent = enumerator.Current;
					if (damageComponent.IsCrit)
					{
						enumerator2 = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateRageEffect(processingSkill, focus, base.GetType().FullName), false).GetEnumerator();
						num = 4294967293u;
						goto Block_7;
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
			IL_1F5:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700137E RID: 4990
		// (get) Token: 0x06005D5D RID: 23901 RVA: 0x00156084 File Offset: 0x00154484
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700137F RID: 4991
		// (get) Token: 0x06005D5E RID: 23902 RVA: 0x0015608C File Offset: 0x0015448C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D5F RID: 23903 RVA: 0x00156094 File Offset: 0x00154494
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

		// Token: 0x06005D60 RID: 23904 RVA: 0x00156128 File Offset: 0x00154528
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D61 RID: 23905 RVA: 0x0015612F File Offset: 0x0015452F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D62 RID: 23906 RVA: 0x00156138 File Offset: 0x00154538
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Rage.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Rage.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005086 RID: 20614
		internal AdventureEventType eventType;

		// Token: 0x04005087 RID: 20615
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04005088 RID: 20616
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04005089 RID: 20617
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400508A RID: 20618
		internal object data;

		// Token: 0x0400508B RID: 20619
		internal BattleDamage <damage>__2;

		// Token: 0x0400508C RID: 20620
		internal double <focus>__2;

		// Token: 0x0400508D RID: 20621
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x0400508E RID: 20622
		internal DamageComponent <damageComponent>__3;

		// Token: 0x0400508F RID: 20623
		internal IEnumerator $locvar1;

		// Token: 0x04005090 RID: 20624
		internal object <_>__4;

		// Token: 0x04005091 RID: 20625
		internal IDisposable $locvar2;

		// Token: 0x04005092 RID: 20626
		internal Rage $this;

		// Token: 0x04005093 RID: 20627
		internal object $current;

		// Token: 0x04005094 RID: 20628
		internal bool $disposing;

		// Token: 0x04005095 RID: 20629
		internal int $PC;

		// Token: 0x04005096 RID: 20630
		private Rage.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0.<ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1 $locvar3;

		// Token: 0x02000E7D RID: 3709
		private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1
		{
			// Token: 0x06005D63 RID: 23907 RVA: 0x0015619C File Offset: 0x0015459C
			public <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1()
			{
			}

			// Token: 0x06005D64 RID: 23908 RVA: 0x001561A4 File Offset: 0x001545A4
			internal bool <>m__0(IBattleUnit u)
			{
				return u == this.eventTriggerUnit;
			}

			// Token: 0x04005097 RID: 20631
			internal IBattleUnit eventTriggerUnit;

			// Token: 0x04005098 RID: 20632
			internal Rage.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <>f__ref$0;
		}
	}
}
