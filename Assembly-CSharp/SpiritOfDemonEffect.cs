using System;
using System.Collections.Generic;

// Token: 0x0200076E RID: 1902
public class SpiritOfDemonEffect : BattleEffectBase
{
	// Token: 0x060037AF RID: 14255 RVA: 0x0016FAAC File Offset: 0x0016DEAC
	public SpiritOfDemonEffect(string effectSourceIdentityCode, int? numberOfLastingTurns, bool asPassive, double boostRate, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._numberOfLastingTurns = numberOfLastingTurns;
		this._asPassive = asPassive;
		this._boostRate = boostRate;
		base.Description = this.BattleEffectType.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSource = effectSource;
	}

	// Token: 0x060037B0 RID: 14256 RVA: 0x0016FB1C File Offset: 0x0016DF1C
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				Value = this._boostRate,
				AttributeType = wearer.GetOutputAttributeType(),
				ModificationType = ModificationType.Multiplication,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
	}

	// Token: 0x060037B1 RID: 14257 RVA: 0x0016FB6E File Offset: 0x0016DF6E
	public bool AsPassive()
	{
		return this._asPassive;
	}

	// Token: 0x060037B2 RID: 14258 RVA: 0x0016FB76 File Offset: 0x0016DF76
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A52 RID: 2642
	// (get) Token: 0x060037B3 RID: 14259 RVA: 0x0016FB7D File Offset: 0x0016DF7D
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A53 RID: 2643
	// (get) Token: 0x060037B4 RID: 14260 RVA: 0x0016FB85 File Offset: 0x0016DF85
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A54 RID: 2644
	// (get) Token: 0x060037B5 RID: 14261 RVA: 0x0016FB8D File Offset: 0x0016DF8D
	// (set) Token: 0x060037B6 RID: 14262 RVA: 0x0016FB95 File Offset: 0x0016DF95
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

	// Token: 0x17000A55 RID: 2645
	// (get) Token: 0x060037B7 RID: 14263 RVA: 0x0016FB9E File Offset: 0x0016DF9E
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A56 RID: 2646
	// (get) Token: 0x060037B8 RID: 14264 RVA: 0x0016FBA6 File Offset: 0x0016DFA6
	// (set) Token: 0x060037B9 RID: 14265 RVA: 0x0016FBAE File Offset: 0x0016DFAE
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

	// Token: 0x17000A57 RID: 2647
	// (get) Token: 0x060037BA RID: 14266 RVA: 0x0016FBB7 File Offset: 0x0016DFB7
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A58 RID: 2648
	// (get) Token: 0x060037BB RID: 14267 RVA: 0x0016FBBF File Offset: 0x0016DFBF
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A59 RID: 2649
	// (get) Token: 0x060037BC RID: 14268 RVA: 0x0016FBC7 File Offset: 0x0016DFC7
	// (set) Token: 0x060037BD RID: 14269 RVA: 0x0016FBCF File Offset: 0x0016DFCF
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

	// Token: 0x17000A5A RID: 2650
	// (get) Token: 0x060037BE RID: 14270 RVA: 0x0016FBD8 File Offset: 0x0016DFD8
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A5B RID: 2651
	// (get) Token: 0x060037BF RID: 14271 RVA: 0x0016FBE0 File Offset: 0x0016DFE0
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B1B RID: 11035
	private string _effectSourceIdentityCode;

	// Token: 0x04002B1C RID: 11036
	private BattleEffectType _battleEffectType = BattleEffectType.SpiritOfDemon;

	// Token: 0x04002B1D RID: 11037
	private int? _numberOfLastingTurns;

	// Token: 0x04002B1E RID: 11038
	private bool _asPassive;

	// Token: 0x04002B1F RID: 11039
	private List<AttributeModifier> _modifiers;

	// Token: 0x04002B20 RID: 11040
	private double _boostRate;

	// Token: 0x04002B21 RID: 11041
	private bool _isThroughEffect;

	// Token: 0x04002B22 RID: 11042
	private bool _canBeImmuned;

	// Token: 0x04002B23 RID: 11043
	private bool _canBeDispersed = true;

	// Token: 0x04002B24 RID: 11044
	private int? _maxStackableInstances = new int?(1);

	// Token: 0x04002B25 RID: 11045
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B26 RID: 11046
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002B27 RID: 11047
	private IBattleEffectSource _effectSource;
}
