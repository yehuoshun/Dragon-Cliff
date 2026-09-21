using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000753 RID: 1875
public sealed class FashionEnhancedEffect : BattleEffectBase
{
	// Token: 0x06003607 RID: 13831 RVA: 0x001675AC File Offset: 0x001659AC
	public FashionEnhancedEffect(int extra, IBattleEffectSource effectSource)
	{
		this.Extra = extra;
		this._effectSourceIdentityCode = "fashionboyenhanced";
		this._battleEffectType = BattleEffectType.FashionEnhanced;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = null;
		this.CanBeDispersed = false;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.FashionEnhanced.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{hits}", extra.ToString());
	}

	// Token: 0x17000953 RID: 2387
	// (get) Token: 0x06003608 RID: 13832 RVA: 0x0016766B File Offset: 0x00165A6B
	// (set) Token: 0x06003609 RID: 13833 RVA: 0x00167673 File Offset: 0x00165A73
	public int Extra
	{
		[CompilerGenerated]
		get
		{
			return this.<Extra>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Extra>k__BackingField = value;
		}
	}

	// Token: 0x0600360A RID: 13834 RVA: 0x0016767C File Offset: 0x00165A7C
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000954 RID: 2388
	// (get) Token: 0x0600360B RID: 13835 RVA: 0x00167683 File Offset: 0x00165A83
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000955 RID: 2389
	// (get) Token: 0x0600360C RID: 13836 RVA: 0x0016768B File Offset: 0x00165A8B
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000956 RID: 2390
	// (get) Token: 0x0600360D RID: 13837 RVA: 0x00167693 File Offset: 0x00165A93
	// (set) Token: 0x0600360E RID: 13838 RVA: 0x0016769B File Offset: 0x00165A9B
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

	// Token: 0x17000957 RID: 2391
	// (get) Token: 0x0600360F RID: 13839 RVA: 0x001676A4 File Offset: 0x00165AA4
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000958 RID: 2392
	// (get) Token: 0x06003610 RID: 13840 RVA: 0x001676AC File Offset: 0x00165AAC
	// (set) Token: 0x06003611 RID: 13841 RVA: 0x001676B4 File Offset: 0x00165AB4
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

	// Token: 0x17000959 RID: 2393
	// (get) Token: 0x06003612 RID: 13842 RVA: 0x001676BD File Offset: 0x00165ABD
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700095A RID: 2394
	// (get) Token: 0x06003613 RID: 13843 RVA: 0x001676C5 File Offset: 0x00165AC5
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700095B RID: 2395
	// (get) Token: 0x06003614 RID: 13844 RVA: 0x001676CD File Offset: 0x00165ACD
	// (set) Token: 0x06003615 RID: 13845 RVA: 0x001676D5 File Offset: 0x00165AD5
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

	// Token: 0x1700095C RID: 2396
	// (get) Token: 0x06003616 RID: 13846 RVA: 0x001676DE File Offset: 0x00165ADE
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700095D RID: 2397
	// (get) Token: 0x06003617 RID: 13847 RVA: 0x001676E6 File Offset: 0x00165AE6
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A11 RID: 10769
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002A12 RID: 10770
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002A13 RID: 10771
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002A14 RID: 10772
	private readonly bool _isThroughEffect;

	// Token: 0x04002A15 RID: 10773
	private readonly bool _canBeImmuned;

	// Token: 0x04002A16 RID: 10774
	private readonly int? _maxStackableInstances;

	// Token: 0x04002A17 RID: 10775
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A18 RID: 10776
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Extra>k__BackingField;

	// Token: 0x04002A19 RID: 10777
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002A1A RID: 10778
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002A1B RID: 10779
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
