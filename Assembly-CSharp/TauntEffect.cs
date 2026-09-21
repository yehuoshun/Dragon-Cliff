using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x02000775 RID: 1909
public class TauntEffect : BattleEffectBase
{
	// Token: 0x0600381E RID: 14366 RVA: 0x00170DB0 File Offset: 0x0016F1B0
	public TauntEffect(IBattleUnit caster, IBattleUnit carrier, IBattleEffectSource effectSource, int? numberOfLastingSeconds, bool canbeimmuned = true)
	{
		this._effectSourceIdentityCode = TauntEffect.UniqueTauntSourceIdentityCode;
		this.Caster = caster;
		this.Carrier = carrier;
		this._effectSource = effectSource;
		this._canbeimmuned = canbeimmuned;
		this._maxNumberOfLastingSeconds = ((numberOfLastingSeconds == null) ? null : new float?((float)numberOfLastingSeconds.Value));
		this.lastingTurns = null;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.Taunt.GetDescription();
		this.CanBeDispersed = true;
	}

	// Token: 0x0600381F RID: 14367 RVA: 0x00170E48 File Offset: 0x0016F248
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		if (this.Caster.SpecialEffects.OfType<TauntBoostData>().Any<TauntBoostData>() && (this.Caster.GetUnitClassStyle() == UnitClassStyle.PhysicalDefender || this.Caster.GetUnitClassStyle() == UnitClassStyle.SpellDefender || this.Caster.GetUnitClassStyle() == UnitClassStyle.Protector))
		{
			TauntBoostData tauntBoostData = this.Caster.SpecialEffects.OfType<TauntBoostData>().First<TauntBoostData>();
			list.Add(new AttributeModifier
			{
				AttributeType = wearer.GetOutputAttributeType(),
				Value = tauntBoostData.OutputCapacityBoost,
				ModificationType = ModificationType.Multiplication,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
		}
		if (this.Caster.GetUnitType() == UnitClass.Paladin)
		{
			PaladinDecayEnhancementData paladinDecayEnhancementData = this.Caster.SpecialEffects.OfType<PaladinDecayEnhancementData>().FirstOrDefault<PaladinDecayEnhancementData>();
			if (paladinDecayEnhancementData != null)
			{
				double attributeValue_Final = this.Caster.GetAttributeValue_Final(AttributeType.Resilience, AttributeRetrievalLevel.Skill);
				if (attributeValue_Final > 0.0)
				{
					list.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						ModificationType = ModificationType.Addition,
						Value = -attributeValue_Final * paladinDecayEnhancementData.Rate,
						AttributeModifierType = AttributeModifierType.Skill
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06003820 RID: 14368 RVA: 0x00170F84 File Offset: 0x0016F384
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitKilled && eventTriggerUnit == this.Caster)
		{
			IEnumerator enumerator = this.Carrier.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x17000A98 RID: 2712
	// (get) Token: 0x06003821 RID: 14369 RVA: 0x00170FB5 File Offset: 0x0016F3B5
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A99 RID: 2713
	// (get) Token: 0x06003822 RID: 14370 RVA: 0x00170FBD File Offset: 0x0016F3BD
	// (set) Token: 0x06003823 RID: 14371 RVA: 0x00170FC5 File Offset: 0x0016F3C5
	public IBattleUnit Caster
	{
		[CompilerGenerated]
		get
		{
			return this.<Caster>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Caster>k__BackingField = value;
		}
	}

	// Token: 0x17000A9A RID: 2714
	// (get) Token: 0x06003824 RID: 14372 RVA: 0x00170FCE File Offset: 0x0016F3CE
	// (set) Token: 0x06003825 RID: 14373 RVA: 0x00170FD6 File Offset: 0x0016F3D6
	public IBattleUnit Carrier
	{
		[CompilerGenerated]
		get
		{
			return this.<Carrier>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Carrier>k__BackingField = value;
		}
	}

	// Token: 0x17000A9B RID: 2715
	// (get) Token: 0x06003826 RID: 14374 RVA: 0x00170FDF File Offset: 0x0016F3DF
	// (set) Token: 0x06003827 RID: 14375 RVA: 0x00170FE7 File Offset: 0x0016F3E7
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this.lastingTurns;
		}
		set
		{
			this.lastingTurns = value;
		}
	}

	// Token: 0x17000A9C RID: 2716
	// (get) Token: 0x06003828 RID: 14376 RVA: 0x00170FF0 File Offset: 0x0016F3F0
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000A9D RID: 2717
	// (get) Token: 0x06003829 RID: 14377 RVA: 0x00170FF3 File Offset: 0x0016F3F3
	public override bool CanBeImmuned
	{
		get
		{
			return this._canbeimmuned;
		}
	}

	// Token: 0x17000A9E RID: 2718
	// (get) Token: 0x0600382A RID: 14378 RVA: 0x00170FFB File Offset: 0x0016F3FB
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x17000A9F RID: 2719
	// (get) Token: 0x0600382B RID: 14379 RVA: 0x00171003 File Offset: 0x0016F403
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x17000AA0 RID: 2720
	// (get) Token: 0x0600382C RID: 14380 RVA: 0x00171006 File Offset: 0x0016F406
	// (set) Token: 0x0600382D RID: 14381 RVA: 0x0017100E File Offset: 0x0016F40E
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

	// Token: 0x0600382E RID: 14382 RVA: 0x00171018 File Offset: 0x0016F418
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitKilled
		};
	}

	// Token: 0x17000AA1 RID: 2721
	// (get) Token: 0x0600382F RID: 14383 RVA: 0x00171034 File Offset: 0x0016F434
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000AA2 RID: 2722
	// (get) Token: 0x06003830 RID: 14384 RVA: 0x0017103C File Offset: 0x0016F43C
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.Taunt;
		}
	}

	// Token: 0x17000AA3 RID: 2723
	// (get) Token: 0x06003831 RID: 14385 RVA: 0x00171040 File Offset: 0x0016F440
	// (set) Token: 0x06003832 RID: 14386 RVA: 0x00171048 File Offset: 0x0016F448
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

	// Token: 0x06003833 RID: 14387 RVA: 0x00171051 File Offset: 0x0016F451
	// Note: this type is marked as 'beforefieldinit'.
	static TauntEffect()
	{
	}

	// Token: 0x04002B68 RID: 11112
	private int? lastingTurns;

	// Token: 0x04002B69 RID: 11113
	private string _effectSourceIdentityCode;

	// Token: 0x04002B6A RID: 11114
	private bool _canbeimmuned;

	// Token: 0x04002B6B RID: 11115
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002B6C RID: 11116
	private IBattleEffectSource _effectSource;

	// Token: 0x04002B6D RID: 11117
	public static string UniqueTauntSourceIdentityCode = "TauntIdentity";

	// Token: 0x04002B6E RID: 11118
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Caster>k__BackingField;

	// Token: 0x04002B6F RID: 11119
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Carrier>k__BackingField;

	// Token: 0x04002B70 RID: 11120
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000ED6 RID: 3798
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FBA RID: 24506 RVA: 0x0017105D File Offset: 0x0016F45D
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005FBB RID: 24507 RVA: 0x00171068 File Offset: 0x0016F468
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitKilled || eventTriggerUnit != base.Caster)
				{
					goto IL_ED;
				}
				enumerator = base.Carrier.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_ED:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001404 RID: 5124
		// (get) Token: 0x06005FBC RID: 24508 RVA: 0x0017117C File Offset: 0x0016F57C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001405 RID: 5125
		// (get) Token: 0x06005FBD RID: 24509 RVA: 0x00171184 File Offset: 0x0016F584
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FBE RID: 24510 RVA: 0x0017118C File Offset: 0x0016F58C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005FBF RID: 24511 RVA: 0x001711FC File Offset: 0x0016F5FC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FC0 RID: 24512 RVA: 0x00171203 File Offset: 0x0016F603
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FC1 RID: 24513 RVA: 0x0017120C File Offset: 0x0016F60C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TauntEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new TauntEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005489 RID: 21641
		internal AdventureEventType eventType;

		// Token: 0x0400548A RID: 21642
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400548B RID: 21643
		internal IEnumerator $locvar0;

		// Token: 0x0400548C RID: 21644
		internal object <_>__1;

		// Token: 0x0400548D RID: 21645
		internal IDisposable $locvar1;

		// Token: 0x0400548E RID: 21646
		internal TauntEffect $this;

		// Token: 0x0400548F RID: 21647
		internal object $current;

		// Token: 0x04005490 RID: 21648
		internal bool $disposing;

		// Token: 0x04005491 RID: 21649
		internal int $PC;
	}
}
