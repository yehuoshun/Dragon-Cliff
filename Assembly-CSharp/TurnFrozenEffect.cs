using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000778 RID: 1912
public class TurnFrozenEffect : BattleEffectBase
{
	// Token: 0x06003854 RID: 14420 RVA: 0x00171B80 File Offset: 0x0016FF80
	public TurnFrozenEffect(float? maxSeconds, IBattleEffectSource effectSource)
	{
		this._effectSource = effectSource;
		this._effectSourceIdentityCode = "unique";
		this._battleEffectType = BattleEffectType.TurnFrozen;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Neutral;
		this.MaxNumberOfLastingSeconds = maxSeconds;
		this.CanBeDispersed = false;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.TurnFrozen.GetDescription();
	}

	// Token: 0x06003855 RID: 14421 RVA: 0x00171BF4 File Offset: 0x0016FFF4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000AB8 RID: 2744
	// (get) Token: 0x06003856 RID: 14422 RVA: 0x00171BFB File Offset: 0x0016FFFB
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000AB9 RID: 2745
	// (get) Token: 0x06003857 RID: 14423 RVA: 0x00171C03 File Offset: 0x00170003
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000ABA RID: 2746
	// (get) Token: 0x06003858 RID: 14424 RVA: 0x00171C0B File Offset: 0x0017000B
	// (set) Token: 0x06003859 RID: 14425 RVA: 0x00171C13 File Offset: 0x00170013
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

	// Token: 0x17000ABB RID: 2747
	// (get) Token: 0x0600385A RID: 14426 RVA: 0x00171C1C File Offset: 0x0017001C
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000ABC RID: 2748
	// (get) Token: 0x0600385B RID: 14427 RVA: 0x00171C24 File Offset: 0x00170024
	// (set) Token: 0x0600385C RID: 14428 RVA: 0x00171C2C File Offset: 0x0017002C
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

	// Token: 0x17000ABD RID: 2749
	// (get) Token: 0x0600385D RID: 14429 RVA: 0x00171C35 File Offset: 0x00170035
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000ABE RID: 2750
	// (get) Token: 0x0600385E RID: 14430 RVA: 0x00171C3D File Offset: 0x0017003D
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000ABF RID: 2751
	// (get) Token: 0x0600385F RID: 14431 RVA: 0x00171C45 File Offset: 0x00170045
	// (set) Token: 0x06003860 RID: 14432 RVA: 0x00171C4D File Offset: 0x0017004D
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

	// Token: 0x17000AC0 RID: 2752
	// (get) Token: 0x06003861 RID: 14433 RVA: 0x00171C56 File Offset: 0x00170056
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000AC1 RID: 2753
	// (get) Token: 0x06003862 RID: 14434 RVA: 0x00171C5E File Offset: 0x0017005E
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B8A RID: 11146
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B8B RID: 11147
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B8C RID: 11148
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B8D RID: 11149
	private readonly bool _isThroughEffect;

	// Token: 0x04002B8E RID: 11150
	private readonly bool _canBeImmuned;

	// Token: 0x04002B8F RID: 11151
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B90 RID: 11152
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B91 RID: 11153
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B92 RID: 11154
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002B93 RID: 11155
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
