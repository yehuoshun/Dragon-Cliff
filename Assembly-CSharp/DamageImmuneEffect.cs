using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000745 RID: 1861
public class DamageImmuneEffect : BattleEffectBase
{
	// Token: 0x06003513 RID: 13587 RVA: 0x00160C28 File Offset: 0x0015F028
	public DamageImmuneEffect(string effectSourceIdentityCode, int? numberOfLastingTurns, float? lastingSeconds, IBattleEffectSource effectSource, List<OutputType> immuneDamageTypes, bool canbeDispersed, int maxStackable = 1)
	{
		Description description = BattleEffectType.DamageImmune.GetDescription();
		description.Details1 = description.Details1.Replace("{types}", string.Join(", ", (from t in immuneDamageTypes
		select t.GetDescription().Title.Replace(" Damage", string.Empty).Replace("伤害", string.Empty)).ToArray<string>()));
		this._effectSource = effectSource;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._numberOfLastingTurns = numberOfLastingTurns;
		this.ImmuneDamageTypes = immuneDamageTypes;
		this._maxNumberOfLastingSeconds = lastingSeconds;
		this._canBeDispersed = canbeDispersed;
		base.Description = description;
		this._maxStackableInstances = maxStackable;
	}

	// Token: 0x06003514 RID: 13588 RVA: 0x00160CE8 File Offset: 0x0015F0E8
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReceivesDamage_CompleteSet && eventTriggerUnit == listener)
		{
			BattleDamage damage = data as BattleDamage;
			if (damage.Target == listener)
			{
				foreach (DamageComponent damageComponent in damage.Damages)
				{
					using (List<DamageComponentPotion>.Enumerator enumerator2 = damageComponent.Potions.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							DamageComponentPotion potion = enumerator2.Current;
							if (this.ImmuneDamageTypes.Any((OutputType t) => t == potion.DamageType))
							{
								potion.SetNeutralize(true);
							}
						}
					}
				}
				IEnumerator enumerator3 = this.Triggered(listener).GetEnumerator();
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
		yield break;
	}

	// Token: 0x170008C3 RID: 2243
	// (get) Token: 0x06003515 RID: 13589 RVA: 0x00160D28 File Offset: 0x0015F128
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x06003516 RID: 13590 RVA: 0x00160D30 File Offset: 0x0015F130
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReceivesDamage_CompleteSet
		};
	}

	// Token: 0x170008C4 RID: 2244
	// (get) Token: 0x06003517 RID: 13591 RVA: 0x00160D4C File Offset: 0x0015F14C
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008C5 RID: 2245
	// (get) Token: 0x06003518 RID: 13592 RVA: 0x00160D54 File Offset: 0x0015F154
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170008C6 RID: 2246
	// (get) Token: 0x06003519 RID: 13593 RVA: 0x00160D5C File Offset: 0x0015F15C
	// (set) Token: 0x0600351A RID: 13594 RVA: 0x00160D64 File Offset: 0x0015F164
	public override float? MaxNumberOfLastingSeconds
	{
		get
		{
			return this._maxNumberOfLastingSeconds;
		}
		set
		{
			this._maxNumberOfLastingSeconds = value;
		}
	}

	// Token: 0x170008C7 RID: 2247
	// (get) Token: 0x0600351B RID: 13595 RVA: 0x00160D6D File Offset: 0x0015F16D
	// (set) Token: 0x0600351C RID: 13596 RVA: 0x00160D75 File Offset: 0x0015F175
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this._numberOfLastingTurns;
		}
		set
		{
			this._numberOfLastingTurns = value;
		}
	}

	// Token: 0x170008C8 RID: 2248
	// (get) Token: 0x0600351D RID: 13597 RVA: 0x00160D7E File Offset: 0x0015F17E
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170008C9 RID: 2249
	// (get) Token: 0x0600351E RID: 13598 RVA: 0x00160D86 File Offset: 0x0015F186
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170008CA RID: 2250
	// (get) Token: 0x0600351F RID: 13599 RVA: 0x00160D8E File Offset: 0x0015F18E
	// (set) Token: 0x06003520 RID: 13600 RVA: 0x00160D96 File Offset: 0x0015F196
	public override bool CanBeDispersed
	{
		get
		{
			return this._canBeDispersed;
		}
		set
		{
			this._canBeDispersed = value;
		}
	}

	// Token: 0x170008CB RID: 2251
	// (get) Token: 0x06003521 RID: 13601 RVA: 0x00160D9F File Offset: 0x0015F19F
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(this._maxStackableInstances);
		}
	}

	// Token: 0x170008CC RID: 2252
	// (get) Token: 0x06003522 RID: 13602 RVA: 0x00160DAC File Offset: 0x0015F1AC
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x06003523 RID: 13603 RVA: 0x00160DB4 File Offset: 0x0015F1B4
	// Note: this type is marked as 'beforefieldinit'.
	static DamageImmuneEffect()
	{
	}

	// Token: 0x06003524 RID: 13604 RVA: 0x00160DC0 File Offset: 0x0015F1C0
	[CompilerGenerated]
	private static string <DamageImmuneEffect>m__0(OutputType t)
	{
		return t.GetDescription().Title.Replace(" Damage", string.Empty).Replace("伤害", string.Empty);
	}

	// Token: 0x0400297D RID: 10621
	private List<OutputType> ImmuneDamageTypes = new List<OutputType>();

	// Token: 0x0400297E RID: 10622
	private string _effectSourceIdentityCode;

	// Token: 0x0400297F RID: 10623
	private BattleEffectType _battleEffectType = BattleEffectType.DamageImmune;

	// Token: 0x04002980 RID: 10624
	private int? _numberOfLastingTurns;

	// Token: 0x04002981 RID: 10625
	private bool _isThroughEffect;

	// Token: 0x04002982 RID: 10626
	private bool _canBeImmuned;

	// Token: 0x04002983 RID: 10627
	private bool _canBeDispersed;

	// Token: 0x04002984 RID: 10628
	private int _maxStackableInstances;

	// Token: 0x04002985 RID: 10629
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002986 RID: 10630
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002987 RID: 10631
	private IBattleEffectSource _effectSource;

	// Token: 0x04002988 RID: 10632
	public static string SingleSourceIdentityCode = "Damage Immune Single Source";

	// Token: 0x04002989 RID: 10633
	[CompilerGenerated]
	private static Func<OutputType, string> <>f__am$cache0;

	// Token: 0x02000E9F RID: 3743
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E54 RID: 24148 RVA: 0x00160DEB File Offset: 0x0015F1EB
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005E55 RID: 24149 RVA: 0x00160DF4 File Offset: 0x0015F1F4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReceivesDamage_CompleteSet || eventTriggerUnit != listener)
				{
					return false;
				}
				damage = (data as BattleDamage);
				if (damage.Target != listener)
				{
					return false;
				}
				enumerator = damage.Damages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DamageComponent damageComponent = enumerator.Current;
						using (List<DamageComponentPotion>.Enumerator enumerator4 = damageComponent.Potions.GetEnumerator())
						{
							while (enumerator4.MoveNext())
							{
								DamageComponentPotion potion = enumerator4.Current;
								if (this.ImmuneDamageTypes.Any((OutputType t) => t == potion.DamageType))
								{
									potion.SetNeutralize(true);
								}
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				enumerator3 = this.Triggered(listener).GetEnumerator();
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
			return false;
		}

		// Token: 0x170013B6 RID: 5046
		// (get) Token: 0x06005E56 RID: 24150 RVA: 0x00161010 File Offset: 0x0015F410
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013B7 RID: 5047
		// (get) Token: 0x06005E57 RID: 24151 RVA: 0x00161018 File Offset: 0x0015F418
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E58 RID: 24152 RVA: 0x00161020 File Offset: 0x0015F420
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

		// Token: 0x06005E59 RID: 24153 RVA: 0x00161090 File Offset: 0x0015F490
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E5A RID: 24154 RVA: 0x00161097 File Offset: 0x0015F497
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E5B RID: 24155 RVA: 0x001610A0 File Offset: 0x0015F4A0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageImmuneEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new DamageImmuneEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040051DD RID: 20957
		internal AdventureEventType eventType;

		// Token: 0x040051DE RID: 20958
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040051DF RID: 20959
		internal IBattleUnit listener;

		// Token: 0x040051E0 RID: 20960
		internal object data;

		// Token: 0x040051E1 RID: 20961
		internal BattleDamage <damage>__1;

		// Token: 0x040051E2 RID: 20962
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x040051E3 RID: 20963
		internal IEnumerator $locvar2;

		// Token: 0x040051E4 RID: 20964
		internal object <_>__2;

		// Token: 0x040051E5 RID: 20965
		internal IDisposable $locvar3;

		// Token: 0x040051E6 RID: 20966
		internal DamageImmuneEffect $this;

		// Token: 0x040051E7 RID: 20967
		internal object $current;

		// Token: 0x040051E8 RID: 20968
		internal bool $disposing;

		// Token: 0x040051E9 RID: 20969
		internal int $PC;

		// Token: 0x02000EA0 RID: 3744
		private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1
		{
			// Token: 0x06005E5C RID: 24156 RVA: 0x00161104 File Offset: 0x0015F504
			public <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1()
			{
			}

			// Token: 0x06005E5D RID: 24157 RVA: 0x0016110C File Offset: 0x0015F50C
			internal bool <>m__0(OutputType t)
			{
				return t == this.potion.DamageType;
			}

			// Token: 0x040051EA RID: 20970
			internal DamageComponentPotion potion;

			// Token: 0x040051EB RID: 20971
			internal DamageImmuneEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <>f__ref$0;
		}
	}
}
