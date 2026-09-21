using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200074E RID: 1870
public class EffectImmuneEffect : BattleEffectBase
{
	// Token: 0x060035B4 RID: 13748 RVA: 0x00166C20 File Offset: 0x00165020
	public EffectImmuneEffect(IBattleEffectSource effectSource, int? numberOfLastingTurns, float? lastingSeconds, string sourceIdentityCode, double chance)
	{
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._effectSource = effectSource;
		this.Chance = chance;
		this._lastingTurns = numberOfLastingTurns;
		this._maxNumberOfLastingSeconds = lastingSeconds;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.EffectImmune.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{chance}", chance.ToExpressionMultiply100());
		this.CanBeDispersed = false;
	}

	// Token: 0x1700091E RID: 2334
	// (get) Token: 0x060035B5 RID: 13749 RVA: 0x00166C9E File Offset: 0x0016509E
	// (set) Token: 0x060035B6 RID: 13750 RVA: 0x00166CA6 File Offset: 0x001650A6
	public double Chance
	{
		[CompilerGenerated]
		get
		{
			return this.<Chance>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Chance>k__BackingField = value;
		}
	}

	// Token: 0x1700091F RID: 2335
	// (get) Token: 0x060035B7 RID: 13751 RVA: 0x00166CAF File Offset: 0x001650AF
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000920 RID: 2336
	// (get) Token: 0x060035B8 RID: 13752 RVA: 0x00166CB7 File Offset: 0x001650B7
	// (set) Token: 0x060035B9 RID: 13753 RVA: 0x00166CBF File Offset: 0x001650BF
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this._lastingTurns;
		}
		set
		{
			this._lastingTurns = value;
		}
	}

	// Token: 0x17000921 RID: 2337
	// (get) Token: 0x060035BA RID: 13754 RVA: 0x00166CC8 File Offset: 0x001650C8
	public List<AttributeModifier> AdditionalModifiers
	{
		get
		{
			return new List<AttributeModifier>();
		}
	}

	// Token: 0x17000922 RID: 2338
	// (get) Token: 0x060035BB RID: 13755 RVA: 0x00166CCF File Offset: 0x001650CF
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000923 RID: 2339
	// (get) Token: 0x060035BC RID: 13756 RVA: 0x00166CD2 File Offset: 0x001650D2
	public override bool CanBeImmuned
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000924 RID: 2340
	// (get) Token: 0x060035BD RID: 13757 RVA: 0x00166CD5 File Offset: 0x001650D5
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x17000925 RID: 2341
	// (get) Token: 0x060035BE RID: 13758 RVA: 0x00166CDD File Offset: 0x001650DD
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Positive;
		}
	}

	// Token: 0x060035BF RID: 13759 RVA: 0x00166CE0 File Offset: 0x001650E0
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this.AdditionalModifiers;
	}

	// Token: 0x17000926 RID: 2342
	// (get) Token: 0x060035C0 RID: 13760 RVA: 0x00166CE8 File Offset: 0x001650E8
	// (set) Token: 0x060035C1 RID: 13761 RVA: 0x00166CF0 File Offset: 0x001650F0
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

	// Token: 0x060035C2 RID: 13762 RVA: 0x00166CF9 File Offset: 0x001650F9
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000927 RID: 2343
	// (get) Token: 0x060035C3 RID: 13763 RVA: 0x00166D00 File Offset: 0x00165100
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000928 RID: 2344
	// (get) Token: 0x060035C4 RID: 13764 RVA: 0x00166D08 File Offset: 0x00165108
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.EffectImmune;
		}
	}

	// Token: 0x17000929 RID: 2345
	// (get) Token: 0x060035C5 RID: 13765 RVA: 0x00166D0C File Offset: 0x0016510C
	// (set) Token: 0x060035C6 RID: 13766 RVA: 0x00166D14 File Offset: 0x00165114
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

	// Token: 0x060035C7 RID: 13767 RVA: 0x00166D1D File Offset: 0x0016511D
	// Note: this type is marked as 'beforefieldinit'.
	static EffectImmuneEffect()
	{
	}

	// Token: 0x040029E5 RID: 10725
	private int? _lastingTurns;

	// Token: 0x040029E6 RID: 10726
	private string _effectSourceIdentityCode;

	// Token: 0x040029E7 RID: 10727
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040029E8 RID: 10728
	private IBattleEffectSource _effectSource;

	// Token: 0x040029E9 RID: 10729
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Chance>k__BackingField;

	// Token: 0x040029EA RID: 10730
	public static string SingleSourceIdentityCode = "Effect Immune Single Source";

	// Token: 0x040029EB RID: 10731
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
