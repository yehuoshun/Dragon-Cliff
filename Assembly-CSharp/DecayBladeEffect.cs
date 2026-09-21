using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200074D RID: 1869
public class DecayBladeEffect : BattleEffectBase
{
	// Token: 0x060035A4 RID: 13732 RVA: 0x00166630 File Offset: 0x00164A30
	public DecayBladeEffect(int lastingTurns, double resistanceReductionValue, double agilityReductionValue, List<AttributeType> resistances, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "uniquedecayblade";
		this._battleEffectType = BattleEffectType.DecayBlade;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this._resistanceReductionValue = resistanceReductionValue;
		this._resistances = resistances;
		this._agilityReductionValue = agilityReductionValue;
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = new int?(lastingTurns);
		base.TurnEventsCollected = new List<AdventureEventType>();
		Description description = BattleEffectType.DecayBlade.GetDescription();
		this.CanBeDispersed = true;
		base.Description = description;
	}

	// Token: 0x060035A5 RID: 13733 RVA: 0x001666D4 File Offset: 0x00164AD4
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && eventTriggerUnit == listener && data is ReleaseableDamage)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				foreach (DamageComponent bdamage in damageBattleDamage.Damages)
				{
					if (bdamage.IsDirectDamage && !bdamage.IsMissed)
					{
						List<AttributeModifier> modifiers = (from r in this._resistances
						select new AttributeModifier
						{
							AttributeType = r,
							ModificationType = ModificationType.Addition,
							Value = -this._resistanceReductionValue,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}).ToList<AttributeModifier>();
						modifiers.Add(new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Addition,
							Value = -this._agilityReductionValue,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						});
						IEnumerator enumerator3 = bdamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(bdamage.Target, modifiers, "decaybladenegative", null, null, new int?(2), true, true), false).GetEnumerator();
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
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060035A6 RID: 13734 RVA: 0x00166714 File Offset: 0x00164B14
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x17000914 RID: 2324
	// (get) Token: 0x060035A7 RID: 13735 RVA: 0x00166730 File Offset: 0x00164B30
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000915 RID: 2325
	// (get) Token: 0x060035A8 RID: 13736 RVA: 0x00166738 File Offset: 0x00164B38
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000916 RID: 2326
	// (get) Token: 0x060035A9 RID: 13737 RVA: 0x00166740 File Offset: 0x00164B40
	// (set) Token: 0x060035AA RID: 13738 RVA: 0x00166748 File Offset: 0x00164B48
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

	// Token: 0x17000917 RID: 2327
	// (get) Token: 0x060035AB RID: 13739 RVA: 0x00166751 File Offset: 0x00164B51
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000918 RID: 2328
	// (get) Token: 0x060035AC RID: 13740 RVA: 0x00166759 File Offset: 0x00164B59
	// (set) Token: 0x060035AD RID: 13741 RVA: 0x00166761 File Offset: 0x00164B61
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

	// Token: 0x17000919 RID: 2329
	// (get) Token: 0x060035AE RID: 13742 RVA: 0x0016676A File Offset: 0x00164B6A
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700091A RID: 2330
	// (get) Token: 0x060035AF RID: 13743 RVA: 0x00166772 File Offset: 0x00164B72
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700091B RID: 2331
	// (get) Token: 0x060035B0 RID: 13744 RVA: 0x0016677A File Offset: 0x00164B7A
	// (set) Token: 0x060035B1 RID: 13745 RVA: 0x00166782 File Offset: 0x00164B82
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

	// Token: 0x1700091C RID: 2332
	// (get) Token: 0x060035B2 RID: 13746 RVA: 0x0016678B File Offset: 0x00164B8B
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700091D RID: 2333
	// (get) Token: 0x060035B3 RID: 13747 RVA: 0x00166793 File Offset: 0x00164B93
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x040029D8 RID: 10712
	private string _effectSourceIdentityCode;

	// Token: 0x040029D9 RID: 10713
	private BattleEffectType _battleEffectType;

	// Token: 0x040029DA RID: 10714
	private IBattleEffectSource _effectSource;

	// Token: 0x040029DB RID: 10715
	private bool _isThroughEffect;

	// Token: 0x040029DC RID: 10716
	private bool _canBeImmuned;

	// Token: 0x040029DD RID: 10717
	private int? _maxStackableInstances;

	// Token: 0x040029DE RID: 10718
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x040029DF RID: 10719
	private List<AttributeType> _resistances;

	// Token: 0x040029E0 RID: 10720
	private double _resistanceReductionValue;

	// Token: 0x040029E1 RID: 10721
	private double _agilityReductionValue;

	// Token: 0x040029E2 RID: 10722
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x040029E3 RID: 10723
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x040029E4 RID: 10724
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000EB4 RID: 3764
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005ECB RID: 24267 RVA: 0x0016679B File Offset: 0x00164B9B
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005ECC RID: 24268 RVA: 0x001667A4 File Offset: 0x00164BA4
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
					goto IL_292;
				}
				damage = (data as ReleaseableDamage);
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
						case 1u:
							Block_12:
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
							break;
						}
						while (enumerator2.MoveNext())
						{
							bdamage = enumerator2.Current;
							if (bdamage.IsDirectDamage && !bdamage.IsMissed)
							{
								modifiers = (from r in this._resistances
								select new AttributeModifier
								{
									AttributeType = r,
									ModificationType = ModificationType.Addition,
									Value = -this._resistanceReductionValue,
									Key = string.Empty,
									AttributeModifierType = AttributeModifierType.Skill
								}).ToList<AttributeModifier>();
								modifiers.Add(new AttributeModifier
								{
									AttributeType = AttributeType.Agility,
									ModificationType = ModificationType.Addition,
									Value = -this._agilityReductionValue,
									Key = string.Empty,
									AttributeModifierType = AttributeModifierType.Skill
								});
								enumerator3 = bdamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(bdamage.Target, modifiers, "decaybladenegative", null, null, new int?(2), true, true), false).GetEnumerator();
								num = 4294967293u;
								goto Block_12;
							}
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					enumerator2 = damageBattleDamage.Damages.GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_292:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013CE RID: 5070
		// (get) Token: 0x06005ECD RID: 24269 RVA: 0x00166A9C File Offset: 0x00164E9C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013CF RID: 5071
		// (get) Token: 0x06005ECE RID: 24270 RVA: 0x00166AA4 File Offset: 0x00164EA4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005ECF RID: 24271 RVA: 0x00166AAC File Offset: 0x00164EAC
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
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005ED0 RID: 24272 RVA: 0x00166B64 File Offset: 0x00164F64
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005ED1 RID: 24273 RVA: 0x00166B6B File Offset: 0x00164F6B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005ED2 RID: 24274 RVA: 0x00166B74 File Offset: 0x00164F74
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DecayBladeEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new DecayBladeEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005ED3 RID: 24275 RVA: 0x00166BD8 File Offset: 0x00164FD8
		internal AttributeModifier <>m__0(AttributeType r)
		{
			return new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Addition,
				Value = -this._resistanceReductionValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x040052C4 RID: 21188
		internal AdventureEventType eventType;

		// Token: 0x040052C5 RID: 21189
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040052C6 RID: 21190
		internal IBattleUnit listener;

		// Token: 0x040052C7 RID: 21191
		internal object data;

		// Token: 0x040052C8 RID: 21192
		internal ReleaseableDamage <damage>__1;

		// Token: 0x040052C9 RID: 21193
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x040052CA RID: 21194
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x040052CB RID: 21195
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x040052CC RID: 21196
		internal DamageComponent <bdamage>__3;

		// Token: 0x040052CD RID: 21197
		internal List<AttributeModifier> <modifiers>__4;

		// Token: 0x040052CE RID: 21198
		internal IEnumerator $locvar2;

		// Token: 0x040052CF RID: 21199
		internal object <_>__5;

		// Token: 0x040052D0 RID: 21200
		internal IDisposable $locvar3;

		// Token: 0x040052D1 RID: 21201
		internal DecayBladeEffect $this;

		// Token: 0x040052D2 RID: 21202
		internal object $current;

		// Token: 0x040052D3 RID: 21203
		internal bool $disposing;

		// Token: 0x040052D4 RID: 21204
		internal int $PC;
	}
}
