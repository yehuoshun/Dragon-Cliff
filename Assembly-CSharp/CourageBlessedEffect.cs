using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000742 RID: 1858
public class CourageBlessedEffect : BattleEffectBase
{
	// Token: 0x060034DD RID: 13533 RVA: 0x0015FB7C File Offset: 0x0015DF7C
	public CourageBlessedEffect(int lastingTurns, double stunRate, double outputReductionRate, IBattleEffectSource effectSource)
	{
		this._effectSource = effectSource;
		this._effectSourceIdentityCode = "uniqueCourange";
		this._battleEffectType = BattleEffectType.CourageBlessed;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this._stunOnHitRate = stunRate;
		this._outputReductionRate = outputReductionRate;
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = new int?(lastingTurns);
		base.TurnEventsCollected = new List<AdventureEventType>();
		Description description = BattleEffectType.CourageBlessed.GetDescription();
		description.Details1 = description.Details1.Replace("{stunrate}", stunRate.ToExpressionMultiply100()).Replace("{outputreduction}", outputReductionRate.ToExpressionMultiply100());
		this.CanBeDispersed = true;
		base.Description = description;
	}

	// Token: 0x060034DE RID: 13534 RVA: 0x0015FC44 File Offset: 0x0015E044
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.StunOnHit,
				ModificationType = ModificationType.Addition,
				Value = this._stunOnHitRate,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
	}

	// Token: 0x060034DF RID: 13535 RVA: 0x0015FC98 File Offset: 0x0015E098
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && eventTriggerUnit == listener && data is ReleaseableDamage)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			foreach (BattleDamage battleDamage in (from d in damage.BattleDamages
			where d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage && !dd.IsMissed)
			select d).ToList<BattleDamage>())
			{
				IEnumerator enumerator2 = battleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(listener, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = battleDamage.Target.GetOutputAttributeType(),
						ModificationType = ModificationType.Multiplication,
						Value = -this._outputReductionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "courageblesseddebuff", new int?(3), null, new int?(2), true, true), false).GetEnumerator();
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

	// Token: 0x060034E0 RID: 13536 RVA: 0x0015FCD8 File Offset: 0x0015E0D8
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x170008A3 RID: 2211
	// (get) Token: 0x060034E1 RID: 13537 RVA: 0x0015FCF4 File Offset: 0x0015E0F4
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008A4 RID: 2212
	// (get) Token: 0x060034E2 RID: 13538 RVA: 0x0015FCFC File Offset: 0x0015E0FC
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170008A5 RID: 2213
	// (get) Token: 0x060034E3 RID: 13539 RVA: 0x0015FD04 File Offset: 0x0015E104
	// (set) Token: 0x060034E4 RID: 13540 RVA: 0x0015FD0C File Offset: 0x0015E10C
	public sealed override float? MaxNumberOfLastingSeconds
	{
		[CompilerGenerated]
		get
		{
			return this.<MaxNumberOfLastingSeconds>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MaxNumberOfLastingSeconds>k__BackingField = value;
		}
	}

	// Token: 0x170008A6 RID: 2214
	// (get) Token: 0x060034E5 RID: 13541 RVA: 0x0015FD15 File Offset: 0x0015E115
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170008A7 RID: 2215
	// (get) Token: 0x060034E6 RID: 13542 RVA: 0x0015FD1D File Offset: 0x0015E11D
	// (set) Token: 0x060034E7 RID: 13543 RVA: 0x0015FD25 File Offset: 0x0015E125
	public sealed override int? NumberOfLastingTurns
	{
		[CompilerGenerated]
		get
		{
			return this.<NumberOfLastingTurns>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NumberOfLastingTurns>k__BackingField = value;
		}
	}

	// Token: 0x170008A8 RID: 2216
	// (get) Token: 0x060034E8 RID: 13544 RVA: 0x0015FD2E File Offset: 0x0015E12E
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170008A9 RID: 2217
	// (get) Token: 0x060034E9 RID: 13545 RVA: 0x0015FD36 File Offset: 0x0015E136
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170008AA RID: 2218
	// (get) Token: 0x060034EA RID: 13546 RVA: 0x0015FD3E File Offset: 0x0015E13E
	// (set) Token: 0x060034EB RID: 13547 RVA: 0x0015FD46 File Offset: 0x0015E146
	public sealed override bool CanBeDispersed
	{
		[CompilerGenerated]
		get
		{
			return this.<CanBeDispersed>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CanBeDispersed>k__BackingField = value;
		}
	}

	// Token: 0x170008AB RID: 2219
	// (get) Token: 0x060034EC RID: 13548 RVA: 0x0015FD4F File Offset: 0x0015E14F
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170008AC RID: 2220
	// (get) Token: 0x060034ED RID: 13549 RVA: 0x0015FD57 File Offset: 0x0015E157
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002959 RID: 10585
	private string _effectSourceIdentityCode;

	// Token: 0x0400295A RID: 10586
	private BattleEffectType _battleEffectType;

	// Token: 0x0400295B RID: 10587
	private IBattleEffectSource _effectSource;

	// Token: 0x0400295C RID: 10588
	private bool _isThroughEffect;

	// Token: 0x0400295D RID: 10589
	private bool _canBeImmuned;

	// Token: 0x0400295E RID: 10590
	private int? _maxStackableInstances;

	// Token: 0x0400295F RID: 10591
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002960 RID: 10592
	private double _stunOnHitRate;

	// Token: 0x04002961 RID: 10593
	private double _outputReductionRate;

	// Token: 0x04002962 RID: 10594
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002963 RID: 10595
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002964 RID: 10596
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000E9C RID: 3740
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E39 RID: 24121 RVA: 0x0015FD5F File Offset: 0x0015E15F
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005E3A RID: 24122 RVA: 0x0015FD68 File Offset: 0x0015E168
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.DamageReleased || eventTriggerUnit != listener || !(data is ReleaseableDamage))
				{
					goto IL_20F;
				}
				damage = (data as ReleaseableDamage);
				enumerator = (from d in damage.BattleDamages
				where d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage && !dd.IsMissed)
				select d).ToList<BattleDamage>().GetEnumerator();
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
					Block_8:
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
					battleDamage = enumerator.Current;
					enumerator2 = battleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(listener, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = battleDamage.Target.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = -this._outputReductionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "courageblesseddebuff", new int?(3), null, new int?(2), true, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_20F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013B0 RID: 5040
		// (get) Token: 0x06005E3B RID: 24123 RVA: 0x0015FFC4 File Offset: 0x0015E3C4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013B1 RID: 5041
		// (get) Token: 0x06005E3C RID: 24124 RVA: 0x0015FFCC File Offset: 0x0015E3CC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E3D RID: 24125 RVA: 0x0015FFD4 File Offset: 0x0015E3D4
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

		// Token: 0x06005E3E RID: 24126 RVA: 0x00160068 File Offset: 0x0015E468
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E3F RID: 24127 RVA: 0x0016006F File Offset: 0x0015E46F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E40 RID: 24128 RVA: 0x00160078 File Offset: 0x0015E478
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CourageBlessedEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new CourageBlessedEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005E41 RID: 24129 RVA: 0x001600DC File Offset: 0x0015E4DC
		private static bool <>m__0(BattleDamage d)
		{
			return d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage && !dd.IsMissed);
		}

		// Token: 0x06005E42 RID: 24130 RVA: 0x00160106 File Offset: 0x0015E506
		private static bool <>m__1(DamageComponent dd)
		{
			return dd.IsDirectDamage && !dd.IsMissed;
		}

		// Token: 0x040051AE RID: 20910
		internal AdventureEventType eventType;

		// Token: 0x040051AF RID: 20911
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040051B0 RID: 20912
		internal IBattleUnit listener;

		// Token: 0x040051B1 RID: 20913
		internal object data;

		// Token: 0x040051B2 RID: 20914
		internal ReleaseableDamage <damage>__1;

		// Token: 0x040051B3 RID: 20915
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x040051B4 RID: 20916
		internal BattleDamage <battleDamage>__2;

		// Token: 0x040051B5 RID: 20917
		internal IEnumerator $locvar1;

		// Token: 0x040051B6 RID: 20918
		internal object <_>__3;

		// Token: 0x040051B7 RID: 20919
		internal IDisposable $locvar2;

		// Token: 0x040051B8 RID: 20920
		internal CourageBlessedEffect $this;

		// Token: 0x040051B9 RID: 20921
		internal object $current;

		// Token: 0x040051BA RID: 20922
		internal bool $disposing;

		// Token: 0x040051BB RID: 20923
		internal int $PC;

		// Token: 0x040051BC RID: 20924
		private static Func<BattleDamage, bool> <>f__am$cache0;

		// Token: 0x040051BD RID: 20925
		private static Func<DamageComponent, bool> <>f__am$cache1;
	}
}
