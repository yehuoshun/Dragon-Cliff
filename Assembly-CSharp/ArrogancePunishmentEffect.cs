using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000733 RID: 1843
public sealed class ArrogancePunishmentEffect : BattleEffectBase
{
	// Token: 0x060033C3 RID: 13251 RVA: 0x0015B6D0 File Offset: 0x00159AD0
	public ArrogancePunishmentEffect(int lastingSeconds, int fearSeconds, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "uniquearrogance";
		this._battleEffectType = BattleEffectType.ArrogancePunishement;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this.CanBeDispersed = true;
		this.MaxNumberOfLastingSeconds = new float?((float)lastingSeconds);
		this._fearSeconds = fearSeconds;
		this.NumberOfLastingTurns = null;
		base.Description = this._battleEffectType.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x060033C4 RID: 13252 RVA: 0x0015B764 File Offset: 0x00159B64
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage_Single && data is DamageComponent)
		{
			DamageComponent damage = data as DamageComponent;
			if (damage.Dealer == listener && eventTriggerUnit.BattleEffects.OfType<RespiteShieldEffect>().Any<RespiteShieldEffect>())
			{
				IEnumerator enumerator = UnitStyleConfigurationBase.DispelPositiveEffects(listener, new int?(1)).GetEnumerator();
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
				IEnumerator enumerator2 = LockTimeEffect.AddFearSeconds(listener, (float)this._fearSeconds, eventTriggerUnit, false).GetEnumerator();
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

	// Token: 0x060033C5 RID: 13253 RVA: 0x0015B7A4 File Offset: 0x00159BA4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage_Single
		};
	}

	// Token: 0x17000817 RID: 2071
	// (get) Token: 0x060033C6 RID: 13254 RVA: 0x0015B7C0 File Offset: 0x00159BC0
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000818 RID: 2072
	// (get) Token: 0x060033C7 RID: 13255 RVA: 0x0015B7C8 File Offset: 0x00159BC8
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000819 RID: 2073
	// (get) Token: 0x060033C8 RID: 13256 RVA: 0x0015B7D0 File Offset: 0x00159BD0
	// (set) Token: 0x060033C9 RID: 13257 RVA: 0x0015B7D8 File Offset: 0x00159BD8
	public override float? MaxNumberOfLastingSeconds
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

	// Token: 0x1700081A RID: 2074
	// (get) Token: 0x060033CA RID: 13258 RVA: 0x0015B7E1 File Offset: 0x00159BE1
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700081B RID: 2075
	// (get) Token: 0x060033CB RID: 13259 RVA: 0x0015B7E9 File Offset: 0x00159BE9
	// (set) Token: 0x060033CC RID: 13260 RVA: 0x0015B7F1 File Offset: 0x00159BF1
	public override int? NumberOfLastingTurns
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

	// Token: 0x1700081C RID: 2076
	// (get) Token: 0x060033CD RID: 13261 RVA: 0x0015B7FA File Offset: 0x00159BFA
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700081D RID: 2077
	// (get) Token: 0x060033CE RID: 13262 RVA: 0x0015B802 File Offset: 0x00159C02
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700081E RID: 2078
	// (get) Token: 0x060033CF RID: 13263 RVA: 0x0015B80A File Offset: 0x00159C0A
	// (set) Token: 0x060033D0 RID: 13264 RVA: 0x0015B812 File Offset: 0x00159C12
	public override bool CanBeDispersed
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

	// Token: 0x1700081F RID: 2079
	// (get) Token: 0x060033D1 RID: 13265 RVA: 0x0015B81B File Offset: 0x00159C1B
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000820 RID: 2080
	// (get) Token: 0x060033D2 RID: 13266 RVA: 0x0015B823 File Offset: 0x00159C23
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x0400285C RID: 10332
	private readonly string _effectSourceIdentityCode;

	// Token: 0x0400285D RID: 10333
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x0400285E RID: 10334
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x0400285F RID: 10335
	private readonly bool _isThroughEffect;

	// Token: 0x04002860 RID: 10336
	private readonly bool _canBeImmuned;

	// Token: 0x04002861 RID: 10337
	private readonly int? _maxStackableInstances;

	// Token: 0x04002862 RID: 10338
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002863 RID: 10339
	private int _fearSeconds;

	// Token: 0x04002864 RID: 10340
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002865 RID: 10341
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002866 RID: 10342
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000E8C RID: 3724
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DBC RID: 23996 RVA: 0x0015B82B File Offset: 0x00159C2B
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005DBD RID: 23997 RVA: 0x0015B834 File Offset: 0x00159C34
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage_Single || !(data is DamageComponent))
				{
					goto IL_1D4;
				}
				damage = (data as DamageComponent);
				if (damage.Dealer != listener || !eventTriggerUnit.BattleEffects.OfType<RespiteShieldEffect>().Any<RespiteShieldEffect>())
				{
					goto IL_1D4;
				}
				enumerator = UnitStyleConfigurationBase.DispelPositiveEffects(listener, new int?(1)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_152;
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
			enumerator2 = LockTimeEffect.AddFearSeconds(listener, (float)this._fearSeconds, eventTriggerUnit, false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_152:
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
			IL_1D4:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001392 RID: 5010
		// (get) Token: 0x06005DBE RID: 23998 RVA: 0x0015BA3C File Offset: 0x00159E3C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001393 RID: 5011
		// (get) Token: 0x06005DBF RID: 23999 RVA: 0x0015BA44 File Offset: 0x00159E44
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DC0 RID: 24000 RVA: 0x0015BA4C File Offset: 0x00159E4C
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

		// Token: 0x06005DC1 RID: 24001 RVA: 0x0015BAFC File Offset: 0x00159EFC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DC2 RID: 24002 RVA: 0x0015BB03 File Offset: 0x00159F03
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DC3 RID: 24003 RVA: 0x0015BB0C File Offset: 0x00159F0C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ArrogancePunishmentEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new ArrogancePunishmentEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005138 RID: 20792
		internal AdventureEventType eventType;

		// Token: 0x04005139 RID: 20793
		internal object data;

		// Token: 0x0400513A RID: 20794
		internal DamageComponent <damage>__1;

		// Token: 0x0400513B RID: 20795
		internal IBattleUnit listener;

		// Token: 0x0400513C RID: 20796
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400513D RID: 20797
		internal IEnumerator $locvar0;

		// Token: 0x0400513E RID: 20798
		internal object <_>__2;

		// Token: 0x0400513F RID: 20799
		internal IDisposable $locvar1;

		// Token: 0x04005140 RID: 20800
		internal IEnumerator $locvar2;

		// Token: 0x04005141 RID: 20801
		internal object <_>__3;

		// Token: 0x04005142 RID: 20802
		internal IDisposable $locvar3;

		// Token: 0x04005143 RID: 20803
		internal ArrogancePunishmentEffect $this;

		// Token: 0x04005144 RID: 20804
		internal object $current;

		// Token: 0x04005145 RID: 20805
		internal bool $disposing;

		// Token: 0x04005146 RID: 20806
		internal int $PC;
	}
}
