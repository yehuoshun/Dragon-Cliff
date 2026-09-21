using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200071B RID: 1819
public class ReturnSoul : SecondarySkillBase
{
	// Token: 0x0600329B RID: 12955 RVA: 0x00156692 File Offset: 0x00154A92
	public ReturnSoul()
	{
	}

	// Token: 0x17000798 RID: 1944
	// (get) Token: 0x0600329C RID: 12956 RVA: 0x001566A1 File Offset: 0x00154AA1
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x17000799 RID: 1945
	// (get) Token: 0x0600329D RID: 12957 RVA: 0x001566A4 File Offset: 0x00154AA4
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Supportive;
		}
	}

	// Token: 0x1700079A RID: 1946
	// (get) Token: 0x0600329E RID: 12958 RVA: 0x001566A7 File Offset: 0x00154AA7
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x1700079B RID: 1947
	// (get) Token: 0x0600329F RID: 12959 RVA: 0x001566AA File Offset: 0x00154AAA
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.None;
		}
	}

	// Token: 0x060032A0 RID: 12960 RVA: 0x001566B0 File Offset: 0x00154AB0
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitKilled
		};
	}

	// Token: 0x1700079C RID: 1948
	// (get) Token: 0x060032A1 RID: 12961 RVA: 0x001566CC File Offset: 0x00154ACC
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x060032A2 RID: 12962 RVA: 0x001566D4 File Offset: 0x00154AD4
	public override bool CanbeLearnedFromSchool()
	{
		return false;
	}

	// Token: 0x1700079D RID: 1949
	// (get) Token: 0x060032A3 RID: 12963 RVA: 0x001566D7 File Offset: 0x00154AD7
	public override SkillType SkillType
	{
		get
		{
			return SkillType.ReturningSoul;
		}
	}

	// Token: 0x1700079E RID: 1950
	// (get) Token: 0x060032A4 RID: 12964 RVA: 0x001566DE File Offset: 0x00154ADE
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060032A5 RID: 12965 RVA: 0x001566E8 File Offset: 0x00154AE8
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitKilled && skillOwner == eventTriggerUnit)
		{
			List<IBattleUnit> units = skillOwner.GetAllLiveFriendlyTargetsIncSelf(false);
			foreach (IBattleUnit battleUnit in units)
			{
				List<AttributeModifier> additionalModifiers = (from at in ItemExtensions.AllAttributeTypes
				select new AttributeModifier
				{
					AttributeType = at,
					Value = skillOwner.GetAttributeValue_Final(at, AttributeRetrievalLevel.Gear),
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>();
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateReturnedSoulEffect(additionalModifiers, processingSkill, base.GetType().FullName), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x040027CB RID: 10187
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027CC RID: 10188
	private int? _requiredSchoolLevel;

	// Token: 0x02000E7F RID: 3711
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D6E RID: 23918 RVA: 0x00156728 File Offset: 0x00154B28
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D6F RID: 23919 RVA: 0x00156730 File Offset: 0x00154B30
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitKilled || skillOwner != eventTriggerUnit)
				{
					goto IL_1C9;
				}
				units = skillOwner.GetAllLiveFriendlyTargetsIncSelf(false);
				enumerator = units.GetEnumerator();
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
					Block_6:
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
					battleUnit = enumerator.Current;
					additionalModifiers = (from at in ItemExtensions.AllAttributeTypes
					select new AttributeModifier
					{
						AttributeType = at,
						Value = <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey.skillOwner.GetAttributeValue_Final(at, AttributeRetrievalLevel.Gear),
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Skill
					}).ToList<AttributeModifier>();
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateReturnedSoulEffect(additionalModifiers, processingSkill, base.GetType().FullName), false).GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1C9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001382 RID: 4994
		// (get) Token: 0x06005D70 RID: 23920 RVA: 0x00156944 File Offset: 0x00154D44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001383 RID: 4995
		// (get) Token: 0x06005D71 RID: 23921 RVA: 0x0015694C File Offset: 0x00154D4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D72 RID: 23922 RVA: 0x00156954 File Offset: 0x00154D54
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

		// Token: 0x06005D73 RID: 23923 RVA: 0x001569E8 File Offset: 0x00154DE8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D74 RID: 23924 RVA: 0x001569EF File Offset: 0x00154DEF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D75 RID: 23925 RVA: 0x001569F8 File Offset: 0x00154DF8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReturnSoul.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new ReturnSoul.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.skillOwner = skillOwner;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040050AA RID: 20650
		internal AdventureEventType eventType;

		// Token: 0x040050AB RID: 20651
		internal IBattleUnit skillOwner;

		// Token: 0x040050AC RID: 20652
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040050AD RID: 20653
		internal List<IBattleUnit> <units>__1;

		// Token: 0x040050AE RID: 20654
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040050AF RID: 20655
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x040050B0 RID: 20656
		internal List<AttributeModifier> <additionalModifiers>__3;

		// Token: 0x040050B1 RID: 20657
		internal AdventureUnitSkill processingSkill;

		// Token: 0x040050B2 RID: 20658
		internal IEnumerator $locvar1;

		// Token: 0x040050B3 RID: 20659
		internal object <_>__4;

		// Token: 0x040050B4 RID: 20660
		internal IDisposable $locvar2;

		// Token: 0x040050B5 RID: 20661
		internal ReturnSoul $this;

		// Token: 0x040050B6 RID: 20662
		internal object $current;

		// Token: 0x040050B7 RID: 20663
		internal bool $disposing;

		// Token: 0x040050B8 RID: 20664
		internal int $PC;

		// Token: 0x040050B9 RID: 20665
		private ReturnSoul.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0.<ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1 $locvar3;

		// Token: 0x02000E80 RID: 3712
		private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1
		{
			// Token: 0x06005D76 RID: 23926 RVA: 0x00156A5C File Offset: 0x00154E5C
			public <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1()
			{
			}

			// Token: 0x06005D77 RID: 23927 RVA: 0x00156A64 File Offset: 0x00154E64
			internal AttributeModifier <>m__0(AttributeType at)
			{
				return new AttributeModifier
				{
					AttributeType = at,
					Value = this.skillOwner.GetAttributeValue_Final(at, AttributeRetrievalLevel.Gear),
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x040050BA RID: 20666
			internal IBattleUnit skillOwner;

			// Token: 0x040050BB RID: 20667
			internal ReturnSoul.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <>f__ref$0;
		}
	}
}
