using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200073A RID: 1850
public class RoarEffect : BattleEffectBase
{
	// Token: 0x06003464 RID: 13412 RVA: 0x0015F008 File Offset: 0x0015D408
	public RoarEffect(AdventureUnitSkill causingSkill, double reductionRate, string sourceIdentityCode)
	{
		this._numberOfLastingTurns = null;
		this._maxNumberOfLastingSeconds = new float?(6f);
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._effectSource = causingSkill;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this.AdditionalModifiers = new List<AttributeModifier>
		{
			new AttributeModifier
			{
				Value = -reductionRate,
				AttributeType = AttributeType.PhysicalResistance,
				ModificationType = ModificationType.Multiplication,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
		this.CanBeDispersed = true;
		Description description = BattleEffectType.Roar.GetDescription();
		description.Details1 = description.Details1.Replace("{reductionrate}", (reductionRate * 100.0).ToExpression());
		base.Description = description;
	}

	// Token: 0x17000861 RID: 2145
	// (get) Token: 0x06003465 RID: 13413 RVA: 0x0015F0C6 File Offset: 0x0015D4C6
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000862 RID: 2146
	// (get) Token: 0x06003466 RID: 13414 RVA: 0x0015F0CE File Offset: 0x0015D4CE
	// (set) Token: 0x06003467 RID: 13415 RVA: 0x0015F0D6 File Offset: 0x0015D4D6
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

	// Token: 0x17000863 RID: 2147
	// (get) Token: 0x06003468 RID: 13416 RVA: 0x0015F0DF File Offset: 0x0015D4DF
	// (set) Token: 0x06003469 RID: 13417 RVA: 0x0015F0E7 File Offset: 0x0015D4E7
	public List<AttributeModifier> AdditionalModifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<AdditionalModifiers>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdditionalModifiers>k__BackingField = value;
		}
	}

	// Token: 0x17000864 RID: 2148
	// (get) Token: 0x0600346A RID: 13418 RVA: 0x0015F0F0 File Offset: 0x0015D4F0
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000865 RID: 2149
	// (get) Token: 0x0600346B RID: 13419 RVA: 0x0015F0F3 File Offset: 0x0015D4F3
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000866 RID: 2150
	// (get) Token: 0x0600346C RID: 13420 RVA: 0x0015F0F6 File Offset: 0x0015D4F6
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(5);
		}
	}

	// Token: 0x17000867 RID: 2151
	// (get) Token: 0x0600346D RID: 13421 RVA: 0x0015F0FE File Offset: 0x0015D4FE
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x0600346E RID: 13422 RVA: 0x0015F101 File Offset: 0x0015D501
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this.AdditionalModifiers;
	}

	// Token: 0x17000868 RID: 2152
	// (get) Token: 0x0600346F RID: 13423 RVA: 0x0015F109 File Offset: 0x0015D509
	// (set) Token: 0x06003470 RID: 13424 RVA: 0x0015F111 File Offset: 0x0015D511
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

	// Token: 0x06003471 RID: 13425 RVA: 0x0015F11A File Offset: 0x0015D51A
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000869 RID: 2153
	// (get) Token: 0x06003472 RID: 13426 RVA: 0x0015F121 File Offset: 0x0015D521
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700086A RID: 2154
	// (get) Token: 0x06003473 RID: 13427 RVA: 0x0015F129 File Offset: 0x0015D529
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.Roar;
		}
	}

	// Token: 0x1700086B RID: 2155
	// (get) Token: 0x06003474 RID: 13428 RVA: 0x0015F12D File Offset: 0x0015D52D
	// (set) Token: 0x06003475 RID: 13429 RVA: 0x0015F135 File Offset: 0x0015D535
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

	// Token: 0x040028AD RID: 10413
	private string _effectSourceIdentityCode;

	// Token: 0x040028AE RID: 10414
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040028AF RID: 10415
	private IBattleEffectSource _effectSource;

	// Token: 0x040028B0 RID: 10416
	private int? _numberOfLastingTurns;

	// Token: 0x040028B1 RID: 10417
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <AdditionalModifiers>k__BackingField;

	// Token: 0x040028B2 RID: 10418
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
