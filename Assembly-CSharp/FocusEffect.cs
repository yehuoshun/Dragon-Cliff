using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000756 RID: 1878
public sealed class FocusEffect : BattleEffectBase
{
	// Token: 0x0600363F RID: 13887 RVA: 0x001682AC File Offset: 0x001666AC
	public FocusEffect(double extraDamage, double reductionRate, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "focusedeffectdirectdamageunique";
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = null;
		this._battleEffectType = BattleEffectType.Focused;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		base.Description = BattleEffectType.Focused.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{damagerate}", extraDamage.ToExpressionMultiply100()).Replace("{reduction}", reductionRate.ToExpressionMultiply100());
		this.ExtraDamageRate = extraDamage;
		this.DamageReductPerExtraTarget = reductionRate;
		this.CanBeDispersed = false;
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x06003640 RID: 13888 RVA: 0x0016837B File Offset: 0x0016677B
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000973 RID: 2419
	// (get) Token: 0x06003641 RID: 13889 RVA: 0x00168382 File Offset: 0x00166782
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000974 RID: 2420
	// (get) Token: 0x06003642 RID: 13890 RVA: 0x0016838A File Offset: 0x0016678A
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000975 RID: 2421
	// (get) Token: 0x06003643 RID: 13891 RVA: 0x00168392 File Offset: 0x00166792
	// (set) Token: 0x06003644 RID: 13892 RVA: 0x0016839A File Offset: 0x0016679A
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

	// Token: 0x17000976 RID: 2422
	// (get) Token: 0x06003645 RID: 13893 RVA: 0x001683A3 File Offset: 0x001667A3
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000977 RID: 2423
	// (get) Token: 0x06003646 RID: 13894 RVA: 0x001683AB File Offset: 0x001667AB
	// (set) Token: 0x06003647 RID: 13895 RVA: 0x001683B3 File Offset: 0x001667B3
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

	// Token: 0x17000978 RID: 2424
	// (get) Token: 0x06003648 RID: 13896 RVA: 0x001683BC File Offset: 0x001667BC
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000979 RID: 2425
	// (get) Token: 0x06003649 RID: 13897 RVA: 0x001683C4 File Offset: 0x001667C4
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700097A RID: 2426
	// (get) Token: 0x0600364A RID: 13898 RVA: 0x001683CC File Offset: 0x001667CC
	// (set) Token: 0x0600364B RID: 13899 RVA: 0x001683D4 File Offset: 0x001667D4
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

	// Token: 0x1700097B RID: 2427
	// (get) Token: 0x0600364C RID: 13900 RVA: 0x001683DD File Offset: 0x001667DD
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700097C RID: 2428
	// (get) Token: 0x0600364D RID: 13901 RVA: 0x001683E5 File Offset: 0x001667E5
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A2A RID: 10794
	private string _effectSourceIdentityCode;

	// Token: 0x04002A2B RID: 10795
	private BattleEffectType _battleEffectType;

	// Token: 0x04002A2C RID: 10796
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A2D RID: 10797
	private bool _isThroughEffect;

	// Token: 0x04002A2E RID: 10798
	private bool _canBeImmuned;

	// Token: 0x04002A2F RID: 10799
	private int? _maxStackableInstances;

	// Token: 0x04002A30 RID: 10800
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A31 RID: 10801
	public double ExtraDamageRate;

	// Token: 0x04002A32 RID: 10802
	public double DamageReductPerExtraTarget;

	// Token: 0x04002A33 RID: 10803
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002A34 RID: 10804
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002A35 RID: 10805
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
