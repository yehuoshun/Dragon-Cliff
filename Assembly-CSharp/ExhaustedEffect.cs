using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000751 RID: 1873
public class ExhaustedEffect : BattleEffectBase
{
	// Token: 0x060035E7 RID: 13799 RVA: 0x0016741C File Offset: 0x0016581C
	public ExhaustedEffect(AdventureUnitSkill causingSkill, string sourceIdentityCode)
	{
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._effectSource = causingSkill;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.Exhausted.GetDescription();
		this._numberOfLastingTurns = null;
		this.CanBeDispersed = false;
	}

	// Token: 0x1700093E RID: 2366
	// (get) Token: 0x060035E8 RID: 13800 RVA: 0x0016746A File Offset: 0x0016586A
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700093F RID: 2367
	// (get) Token: 0x060035E9 RID: 13801 RVA: 0x00167472 File Offset: 0x00165872
	// (set) Token: 0x060035EA RID: 13802 RVA: 0x0016747A File Offset: 0x0016587A
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

	// Token: 0x17000940 RID: 2368
	// (get) Token: 0x060035EB RID: 13803 RVA: 0x00167483 File Offset: 0x00165883
	public List<AttributeModifier> AdditionalModifiers
	{
		get
		{
			return new List<AttributeModifier>();
		}
	}

	// Token: 0x17000941 RID: 2369
	// (get) Token: 0x060035EC RID: 13804 RVA: 0x0016748A File Offset: 0x0016588A
	public override bool IsThroughEffect
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000942 RID: 2370
	// (get) Token: 0x060035ED RID: 13805 RVA: 0x0016748D File Offset: 0x0016588D
	public override bool CanBeImmuned
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000943 RID: 2371
	// (get) Token: 0x060035EE RID: 13806 RVA: 0x00167490 File Offset: 0x00165890
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x17000944 RID: 2372
	// (get) Token: 0x060035EF RID: 13807 RVA: 0x00167498 File Offset: 0x00165898
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Neutral;
		}
	}

	// Token: 0x060035F0 RID: 13808 RVA: 0x0016749B File Offset: 0x0016589B
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this.AdditionalModifiers;
	}

	// Token: 0x17000945 RID: 2373
	// (get) Token: 0x060035F1 RID: 13809 RVA: 0x001674A3 File Offset: 0x001658A3
	// (set) Token: 0x060035F2 RID: 13810 RVA: 0x001674AB File Offset: 0x001658AB
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

	// Token: 0x060035F3 RID: 13811 RVA: 0x001674B4 File Offset: 0x001658B4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000946 RID: 2374
	// (get) Token: 0x060035F4 RID: 13812 RVA: 0x001674BB File Offset: 0x001658BB
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000947 RID: 2375
	// (get) Token: 0x060035F5 RID: 13813 RVA: 0x001674C3 File Offset: 0x001658C3
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.Exhausted;
		}
	}

	// Token: 0x17000948 RID: 2376
	// (get) Token: 0x060035F6 RID: 13814 RVA: 0x001674C6 File Offset: 0x001658C6
	// (set) Token: 0x060035F7 RID: 13815 RVA: 0x001674CE File Offset: 0x001658CE
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

	// Token: 0x04002A02 RID: 10754
	private string _effectSourceIdentityCode;

	// Token: 0x04002A03 RID: 10755
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A04 RID: 10756
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A05 RID: 10757
	private int? _numberOfLastingTurns;

	// Token: 0x04002A06 RID: 10758
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
