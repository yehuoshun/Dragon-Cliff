using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200076B RID: 1899
public sealed class RespiteShieldEffect : BattleEffectBase
{
	// Token: 0x06003781 RID: 14209 RVA: 0x0016F4E0 File Offset: 0x0016D8E0
	public RespiteShieldEffect(int? lastingSeconds, int? lastingTurns, int fearSeconds, int punishmentSeconds, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "uniquerespite";
		this._battleEffectType = BattleEffectType.RespiteShield;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.CanBeDispersed = true;
		this.MaxNumberOfLastingSeconds = ((lastingSeconds == null) ? null : new float?((float)lastingSeconds.Value));
		this._punishmentSeconds = punishmentSeconds;
		this.NumberOfLastingTurns = lastingTurns;
		base.Description = this._battleEffectType.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._fearSeconds = fearSeconds;
	}

	// Token: 0x06003782 RID: 14210 RVA: 0x0016F598 File Offset: 0x0016D998
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage_Single && listener == eventTriggerUnit && data is DamageComponent)
		{
			DamageComponent damage = data as DamageComponent;
			IEnumerator enumerator = damage.Dealer.ApplySkillEffect(new ArrogancePunishmentEffect(this._punishmentSeconds, this._fearSeconds, listener), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06003783 RID: 14211 RVA: 0x0016F5D8 File Offset: 0x0016D9D8
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage_Single
		};
	}

	// Token: 0x17000A34 RID: 2612
	// (get) Token: 0x06003784 RID: 14212 RVA: 0x0016F5F4 File Offset: 0x0016D9F4
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A35 RID: 2613
	// (get) Token: 0x06003785 RID: 14213 RVA: 0x0016F5FC File Offset: 0x0016D9FC
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A36 RID: 2614
	// (get) Token: 0x06003786 RID: 14214 RVA: 0x0016F604 File Offset: 0x0016DA04
	// (set) Token: 0x06003787 RID: 14215 RVA: 0x0016F60C File Offset: 0x0016DA0C
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

	// Token: 0x17000A37 RID: 2615
	// (get) Token: 0x06003788 RID: 14216 RVA: 0x0016F615 File Offset: 0x0016DA15
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A38 RID: 2616
	// (get) Token: 0x06003789 RID: 14217 RVA: 0x0016F61D File Offset: 0x0016DA1D
	// (set) Token: 0x0600378A RID: 14218 RVA: 0x0016F625 File Offset: 0x0016DA25
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

	// Token: 0x17000A39 RID: 2617
	// (get) Token: 0x0600378B RID: 14219 RVA: 0x0016F62E File Offset: 0x0016DA2E
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A3A RID: 2618
	// (get) Token: 0x0600378C RID: 14220 RVA: 0x0016F636 File Offset: 0x0016DA36
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A3B RID: 2619
	// (get) Token: 0x0600378D RID: 14221 RVA: 0x0016F63E File Offset: 0x0016DA3E
	// (set) Token: 0x0600378E RID: 14222 RVA: 0x0016F646 File Offset: 0x0016DA46
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

	// Token: 0x17000A3C RID: 2620
	// (get) Token: 0x0600378F RID: 14223 RVA: 0x0016F64F File Offset: 0x0016DA4F
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A3D RID: 2621
	// (get) Token: 0x06003790 RID: 14224 RVA: 0x0016F657 File Offset: 0x0016DA57
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002AFB RID: 11003
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002AFC RID: 11004
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002AFD RID: 11005
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002AFE RID: 11006
	private readonly bool _isThroughEffect;

	// Token: 0x04002AFF RID: 11007
	private readonly bool _canBeImmuned;

	// Token: 0x04002B00 RID: 11008
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B01 RID: 11009
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B02 RID: 11010
	private int _punishmentSeconds;

	// Token: 0x04002B03 RID: 11011
	private int _fearSeconds;

	// Token: 0x04002B04 RID: 11012
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B05 RID: 11013
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002B06 RID: 11014
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000ED2 RID: 3794
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F9F RID: 24479 RVA: 0x0016F65F File Offset: 0x0016DA5F
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005FA0 RID: 24480 RVA: 0x0016F668 File Offset: 0x0016DA68
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage_Single || listener != eventTriggerUnit || !(data is DamageComponent))
				{
					goto IL_124;
				}
				damage = (data as DamageComponent);
				enumerator = damage.Dealer.ApplySkillEffect(new ArrogancePunishmentEffect(this._punishmentSeconds, this._fearSeconds, listener), false).GetEnumerator();
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
			IL_124:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013FE RID: 5118
		// (get) Token: 0x06005FA1 RID: 24481 RVA: 0x0016F7B4 File Offset: 0x0016DBB4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013FF RID: 5119
		// (get) Token: 0x06005FA2 RID: 24482 RVA: 0x0016F7BC File Offset: 0x0016DBBC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FA3 RID: 24483 RVA: 0x0016F7C4 File Offset: 0x0016DBC4
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
			}
		}

		// Token: 0x06005FA4 RID: 24484 RVA: 0x0016F834 File Offset: 0x0016DC34
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FA5 RID: 24485 RVA: 0x0016F83B File Offset: 0x0016DC3B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FA6 RID: 24486 RVA: 0x0016F844 File Offset: 0x0016DC44
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RespiteShieldEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new RespiteShieldEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005453 RID: 21587
		internal AdventureEventType eventType;

		// Token: 0x04005454 RID: 21588
		internal IBattleUnit listener;

		// Token: 0x04005455 RID: 21589
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04005456 RID: 21590
		internal object data;

		// Token: 0x04005457 RID: 21591
		internal DamageComponent <damage>__1;

		// Token: 0x04005458 RID: 21592
		internal IEnumerator $locvar0;

		// Token: 0x04005459 RID: 21593
		internal object <_>__2;

		// Token: 0x0400545A RID: 21594
		internal IDisposable $locvar1;

		// Token: 0x0400545B RID: 21595
		internal RespiteShieldEffect $this;

		// Token: 0x0400545C RID: 21596
		internal object $current;

		// Token: 0x0400545D RID: 21597
		internal bool $disposing;

		// Token: 0x0400545E RID: 21598
		internal int $PC;
	}
}
