using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000731 RID: 1841
public class AdditionaTargetEffect : BattleEffectBase
{
	// Token: 0x060033A1 RID: 13217 RVA: 0x0015B2E8 File Offset: 0x001596E8
	public AdditionaTargetEffect(string effectSourceIdentityCode, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns, int? additionalNumber, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._maxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
		this._numberOfLastingTurns = numberOfLastingTurns;
		this.AdditionalNumber = additionalNumber;
		base.Description = this.BattleEffectType.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSource = effectSource;
	}

	// Token: 0x17000802 RID: 2050
	// (get) Token: 0x060033A2 RID: 13218 RVA: 0x0015B357 File Offset: 0x00159757
	// (set) Token: 0x060033A3 RID: 13219 RVA: 0x0015B35F File Offset: 0x0015975F
	public int? AdditionalNumber
	{
		[CompilerGenerated]
		get
		{
			return this.<AdditionalNumber>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdditionalNumber>k__BackingField = value;
		}
	}

	// Token: 0x060033A4 RID: 13220 RVA: 0x0015B368 File Offset: 0x00159768
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000803 RID: 2051
	// (get) Token: 0x060033A5 RID: 13221 RVA: 0x0015B36F File Offset: 0x0015976F
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000804 RID: 2052
	// (get) Token: 0x060033A6 RID: 13222 RVA: 0x0015B377 File Offset: 0x00159777
	public sealed override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000805 RID: 2053
	// (get) Token: 0x060033A7 RID: 13223 RVA: 0x0015B37F File Offset: 0x0015977F
	// (set) Token: 0x060033A8 RID: 13224 RVA: 0x0015B387 File Offset: 0x00159787
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

	// Token: 0x17000806 RID: 2054
	// (get) Token: 0x060033A9 RID: 13225 RVA: 0x0015B390 File Offset: 0x00159790
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000807 RID: 2055
	// (get) Token: 0x060033AA RID: 13226 RVA: 0x0015B398 File Offset: 0x00159798
	// (set) Token: 0x060033AB RID: 13227 RVA: 0x0015B3A0 File Offset: 0x001597A0
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

	// Token: 0x17000808 RID: 2056
	// (get) Token: 0x060033AC RID: 13228 RVA: 0x0015B3A9 File Offset: 0x001597A9
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000809 RID: 2057
	// (get) Token: 0x060033AD RID: 13229 RVA: 0x0015B3B1 File Offset: 0x001597B1
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700080A RID: 2058
	// (get) Token: 0x060033AE RID: 13230 RVA: 0x0015B3B9 File Offset: 0x001597B9
	// (set) Token: 0x060033AF RID: 13231 RVA: 0x0015B3C1 File Offset: 0x001597C1
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

	// Token: 0x1700080B RID: 2059
	// (get) Token: 0x060033B0 RID: 13232 RVA: 0x0015B3CA File Offset: 0x001597CA
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700080C RID: 2060
	// (get) Token: 0x060033B1 RID: 13233 RVA: 0x0015B3D2 File Offset: 0x001597D2
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002844 RID: 10308
	private string _effectSourceIdentityCode;

	// Token: 0x04002845 RID: 10309
	private BattleEffectType _battleEffectType = BattleEffectType.AdditionalTarget;

	// Token: 0x04002846 RID: 10310
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002847 RID: 10311
	private int? _numberOfLastingTurns;

	// Token: 0x04002848 RID: 10312
	private bool _isThroughEffect;

	// Token: 0x04002849 RID: 10313
	private bool _canBeImmuned;

	// Token: 0x0400284A RID: 10314
	private bool _canBeDispersed = true;

	// Token: 0x0400284B RID: 10315
	private int? _maxStackableInstances = new int?(1);

	// Token: 0x0400284C RID: 10316
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x0400284D RID: 10317
	private IBattleEffectSource _effectSource;

	// Token: 0x0400284E RID: 10318
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <AdditionalNumber>k__BackingField;
}
