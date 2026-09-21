using System;
using System.Collections.Generic;

// Token: 0x0200074C RID: 1868
public sealed class DamageReductionEffect : BattleEffectBase
{
	// Token: 0x06003593 RID: 13715 RVA: 0x00166508 File Offset: 0x00164908
	public DamageReductionEffect(string effectSourceIdentityCode, List<OutputType> reductionTypes, float reductionRate, float totalAliveSeconds, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._reductionTypes = reductionTypes;
		this._reductionRate = reductionRate;
		this._maxNumberOfLastingSeconds = new float?(totalAliveSeconds);
		base.Description = this.BattleEffectType.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{rate}", Convert.ToDouble(this._reductionRate).ToExpressionMultiply100());
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSource = effectSource;
	}

	// Token: 0x17000908 RID: 2312
	// (get) Token: 0x06003594 RID: 13716 RVA: 0x001665AC File Offset: 0x001649AC
	public List<OutputType> ReductionTypes
	{
		get
		{
			return this._reductionTypes;
		}
	}

	// Token: 0x17000909 RID: 2313
	// (get) Token: 0x06003595 RID: 13717 RVA: 0x001665B4 File Offset: 0x001649B4
	public float ReductionRate
	{
		get
		{
			return this._reductionRate;
		}
	}

	// Token: 0x06003596 RID: 13718 RVA: 0x001665BC File Offset: 0x001649BC
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x1700090A RID: 2314
	// (get) Token: 0x06003597 RID: 13719 RVA: 0x001665C3 File Offset: 0x001649C3
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700090B RID: 2315
	// (get) Token: 0x06003598 RID: 13720 RVA: 0x001665CB File Offset: 0x001649CB
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x1700090C RID: 2316
	// (get) Token: 0x06003599 RID: 13721 RVA: 0x001665D3 File Offset: 0x001649D3
	// (set) Token: 0x0600359A RID: 13722 RVA: 0x001665DB File Offset: 0x001649DB
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

	// Token: 0x1700090D RID: 2317
	// (get) Token: 0x0600359B RID: 13723 RVA: 0x001665E4 File Offset: 0x001649E4
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700090E RID: 2318
	// (get) Token: 0x0600359C RID: 13724 RVA: 0x001665EC File Offset: 0x001649EC
	// (set) Token: 0x0600359D RID: 13725 RVA: 0x001665F4 File Offset: 0x001649F4
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

	// Token: 0x1700090F RID: 2319
	// (get) Token: 0x0600359E RID: 13726 RVA: 0x001665FD File Offset: 0x001649FD
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000910 RID: 2320
	// (get) Token: 0x0600359F RID: 13727 RVA: 0x00166605 File Offset: 0x00164A05
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000911 RID: 2321
	// (get) Token: 0x060035A0 RID: 13728 RVA: 0x0016660D File Offset: 0x00164A0D
	// (set) Token: 0x060035A1 RID: 13729 RVA: 0x00166615 File Offset: 0x00164A15
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

	// Token: 0x17000912 RID: 2322
	// (get) Token: 0x060035A2 RID: 13730 RVA: 0x0016661E File Offset: 0x00164A1E
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000913 RID: 2323
	// (get) Token: 0x060035A3 RID: 13731 RVA: 0x00166626 File Offset: 0x00164A26
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x040029CC RID: 10700
	private string _effectSourceIdentityCode;

	// Token: 0x040029CD RID: 10701
	private BattleEffectType _battleEffectType = BattleEffectType.DamageReduction;

	// Token: 0x040029CE RID: 10702
	private int? _numberOfLastingTurns;

	// Token: 0x040029CF RID: 10703
	private bool _isThroughEffect;

	// Token: 0x040029D0 RID: 10704
	private bool _canBeImmuned;

	// Token: 0x040029D1 RID: 10705
	private bool _canBeDispersed = true;

	// Token: 0x040029D2 RID: 10706
	private int? _maxStackableInstances = new int?(1);

	// Token: 0x040029D3 RID: 10707
	private List<OutputType> _reductionTypes;

	// Token: 0x040029D4 RID: 10708
	private float _reductionRate;

	// Token: 0x040029D5 RID: 10709
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x040029D6 RID: 10710
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040029D7 RID: 10711
	private IBattleEffectSource _effectSource;
}
