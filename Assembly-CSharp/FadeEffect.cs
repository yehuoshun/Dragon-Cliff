using System;
using System.Collections.Generic;

// Token: 0x02000752 RID: 1874
public class FadeEffect : BattleEffectBase
{
	// Token: 0x060035F8 RID: 13816 RVA: 0x001674D8 File Offset: 0x001658D8
	public FadeEffect(IBattleEffectSource causingSource, string effectSourceIdentityCode, int lastingTurns)
	{
		this._effectSource = causingSource;
		this._numberOfLastingTurns = new int?(lastingTurns);
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		base.Description = BattleEffectType.Fade.GetDescription();
	}

	// Token: 0x060035F9 RID: 13817 RVA: 0x00167533 File Offset: 0x00165933
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000949 RID: 2377
	// (get) Token: 0x060035FA RID: 13818 RVA: 0x0016753A File Offset: 0x0016593A
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700094A RID: 2378
	// (get) Token: 0x060035FB RID: 13819 RVA: 0x00167542 File Offset: 0x00165942
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x1700094B RID: 2379
	// (get) Token: 0x060035FC RID: 13820 RVA: 0x0016754A File Offset: 0x0016594A
	// (set) Token: 0x060035FD RID: 13821 RVA: 0x00167552 File Offset: 0x00165952
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

	// Token: 0x1700094C RID: 2380
	// (get) Token: 0x060035FE RID: 13822 RVA: 0x0016755B File Offset: 0x0016595B
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700094D RID: 2381
	// (get) Token: 0x060035FF RID: 13823 RVA: 0x00167563 File Offset: 0x00165963
	// (set) Token: 0x06003600 RID: 13824 RVA: 0x0016756B File Offset: 0x0016596B
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

	// Token: 0x1700094E RID: 2382
	// (get) Token: 0x06003601 RID: 13825 RVA: 0x00167574 File Offset: 0x00165974
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700094F RID: 2383
	// (get) Token: 0x06003602 RID: 13826 RVA: 0x0016757C File Offset: 0x0016597C
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000950 RID: 2384
	// (get) Token: 0x06003603 RID: 13827 RVA: 0x00167584 File Offset: 0x00165984
	// (set) Token: 0x06003604 RID: 13828 RVA: 0x0016758C File Offset: 0x0016598C
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

	// Token: 0x17000951 RID: 2385
	// (get) Token: 0x06003605 RID: 13829 RVA: 0x00167595 File Offset: 0x00165995
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(this._maxStackableInstances);
		}
	}

	// Token: 0x17000952 RID: 2386
	// (get) Token: 0x06003606 RID: 13830 RVA: 0x001675A2 File Offset: 0x001659A2
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A07 RID: 10759
	private string _effectSourceIdentityCode;

	// Token: 0x04002A08 RID: 10760
	private BattleEffectType _battleEffectType = BattleEffectType.Fade;

	// Token: 0x04002A09 RID: 10761
	private int? _numberOfLastingTurns;

	// Token: 0x04002A0A RID: 10762
	private bool _isThroughEffect;

	// Token: 0x04002A0B RID: 10763
	private bool _canBeImmuned;

	// Token: 0x04002A0C RID: 10764
	private bool _canBeDispersed = true;

	// Token: 0x04002A0D RID: 10765
	private int _maxStackableInstances = 1;

	// Token: 0x04002A0E RID: 10766
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A0F RID: 10767
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A10 RID: 10768
	private IBattleEffectSource _effectSource;
}
