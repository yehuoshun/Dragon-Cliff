using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000743 RID: 1859
public class CrashExtraEffect : BattleEffectBase
{
	// Token: 0x060034EE RID: 13550 RVA: 0x00160120 File Offset: 0x0015E520
	public CrashExtraEffect(int extra, IBattleEffectSource effectSource, double extraStrength)
	{
		this._effectSourceIdentityCode = "extracrash";
		this._battleEffectType = BattleEffectType.CrashExtra;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.Extra = extra;
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = null;
		this.CanBeDispersed = false;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this.ExtraStrength = extraStrength;
		Description description = BattleEffectType.CrashExtra.GetDescription();
		description.Details1 = description.Details1.Replace("{damage}", extraStrength.ToExpression()).Replace("{number}", extra.ToString());
		base.Description = description;
	}

	// Token: 0x170008AD RID: 2221
	// (get) Token: 0x060034EF RID: 13551 RVA: 0x001601EE File Offset: 0x0015E5EE
	// (set) Token: 0x060034F0 RID: 13552 RVA: 0x001601F6 File Offset: 0x0015E5F6
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

	// Token: 0x170008AE RID: 2222
	// (get) Token: 0x060034F1 RID: 13553 RVA: 0x001601FF File Offset: 0x0015E5FF
	// (set) Token: 0x060034F2 RID: 13554 RVA: 0x00160207 File Offset: 0x0015E607
	public double ExtraStrength
	{
		[CompilerGenerated]
		get
		{
			return this.<ExtraStrength>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<ExtraStrength>k__BackingField = value;
		}
	}

	// Token: 0x060034F3 RID: 13555 RVA: 0x00160210 File Offset: 0x0015E610
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.Strength,
				ModificationType = ModificationType.Addition,
				Value = this.ExtraStrength,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
	}

	// Token: 0x060034F4 RID: 13556 RVA: 0x0016025D File Offset: 0x0015E65D
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170008AF RID: 2223
	// (get) Token: 0x060034F5 RID: 13557 RVA: 0x00160264 File Offset: 0x0015E664
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008B0 RID: 2224
	// (get) Token: 0x060034F6 RID: 13558 RVA: 0x0016026C File Offset: 0x0015E66C
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170008B1 RID: 2225
	// (get) Token: 0x060034F7 RID: 13559 RVA: 0x00160274 File Offset: 0x0015E674
	// (set) Token: 0x060034F8 RID: 13560 RVA: 0x0016027C File Offset: 0x0015E67C
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

	// Token: 0x170008B2 RID: 2226
	// (get) Token: 0x060034F9 RID: 13561 RVA: 0x00160285 File Offset: 0x0015E685
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170008B3 RID: 2227
	// (get) Token: 0x060034FA RID: 13562 RVA: 0x0016028D File Offset: 0x0015E68D
	// (set) Token: 0x060034FB RID: 13563 RVA: 0x00160295 File Offset: 0x0015E695
	public sealed override int? NumberOfLastingTurns
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

	// Token: 0x170008B4 RID: 2228
	// (get) Token: 0x060034FC RID: 13564 RVA: 0x0016029E File Offset: 0x0015E69E
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170008B5 RID: 2229
	// (get) Token: 0x060034FD RID: 13565 RVA: 0x001602A6 File Offset: 0x0015E6A6
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170008B6 RID: 2230
	// (get) Token: 0x060034FE RID: 13566 RVA: 0x001602AE File Offset: 0x0015E6AE
	// (set) Token: 0x060034FF RID: 13567 RVA: 0x001602B6 File Offset: 0x0015E6B6
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

	// Token: 0x170008B7 RID: 2231
	// (get) Token: 0x06003500 RID: 13568 RVA: 0x001602BF File Offset: 0x0015E6BF
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170008B8 RID: 2232
	// (get) Token: 0x06003501 RID: 13569 RVA: 0x001602C7 File Offset: 0x0015E6C7
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002965 RID: 10597
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002966 RID: 10598
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002967 RID: 10599
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002968 RID: 10600
	private readonly bool _isThroughEffect;

	// Token: 0x04002969 RID: 10601
	private readonly bool _canBeImmuned;

	// Token: 0x0400296A RID: 10602
	private readonly int? _maxStackableInstances;

	// Token: 0x0400296B RID: 10603
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x0400296C RID: 10604
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Extra>k__BackingField;

	// Token: 0x0400296D RID: 10605
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ExtraStrength>k__BackingField;

	// Token: 0x0400296E RID: 10606
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x0400296F RID: 10607
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002970 RID: 10608
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
