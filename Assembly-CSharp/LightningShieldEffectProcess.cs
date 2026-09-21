using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000904 RID: 2308
public class LightningShieldEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004047 RID: 16455 RVA: 0x0019D0E4 File Offset: 0x0019B4E4
	public LightningShieldEffectProcess()
	{
	}

	// Token: 0x17000BC8 RID: 3016
	// (get) Token: 0x06004048 RID: 16456 RVA: 0x0019D0EC File Offset: 0x0019B4EC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.LightningShield;
		}
	}

	// Token: 0x17000BC9 RID: 3017
	// (get) Token: 0x06004049 RID: 16457 RVA: 0x0019D0F4 File Offset: 0x0019B4F4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x0600404A RID: 16458 RVA: 0x0019D110 File Offset: 0x0019B510
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && evtData is DamageComponent && specialEffectData is LightningShieldData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsDirectDamage && !damage.IsMissed)
			{
				LightningShieldData data = specialEffectData as LightningShieldData;
				IEnumerator enumerator = damage.Dealer.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						ModificationType = ModificationType.Multiplication,
						Value = -data.ResilienceReductionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "lightningshield", new int?(1), new float?(6f), null, true, true), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x02000F91 RID: 3985
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064E0 RID: 25824 RVA: 0x0019D151 File Offset: 0x0019B551
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060064E1 RID: 25825 RVA: 0x0019D15C File Offset: 0x0019B55C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(evtData is DamageComponent) || !(specialEffectData is LightningShieldData))
				{
					goto IL_1BC;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsDirectDamage || damage.IsMissed)
				{
					goto IL_1BC;
				}
				data = (specialEffectData as LightningShieldData);
				enumerator = damage.Dealer.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						ModificationType = ModificationType.Multiplication,
						Value = -data.ResilienceReductionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "lightningshield", new int?(1), new float?(6f), null, true, true), false).GetEnumerator();
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
			IL_1BC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001521 RID: 5409
		// (get) Token: 0x060064E2 RID: 25826 RVA: 0x0019D340 File Offset: 0x0019B740
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001522 RID: 5410
		// (get) Token: 0x060064E3 RID: 25827 RVA: 0x0019D348 File Offset: 0x0019B748
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064E4 RID: 25828 RVA: 0x0019D350 File Offset: 0x0019B750
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

		// Token: 0x060064E5 RID: 25829 RVA: 0x0019D3C0 File Offset: 0x0019B7C0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064E6 RID: 25830 RVA: 0x0019D3C7 File Offset: 0x0019B7C7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064E7 RID: 25831 RVA: 0x0019D3D0 File Offset: 0x0019B7D0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LightningShieldEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new LightningShieldEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005D22 RID: 23842
		internal AdventureEventType evtType;

		// Token: 0x04005D23 RID: 23843
		internal IBattleUnit triggerUnit;

		// Token: 0x04005D24 RID: 23844
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D25 RID: 23845
		internal object evtData;

		// Token: 0x04005D26 RID: 23846
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D27 RID: 23847
		internal DamageComponent <damage>__1;

		// Token: 0x04005D28 RID: 23848
		internal LightningShieldData <data>__2;

		// Token: 0x04005D29 RID: 23849
		internal IEnumerator $locvar0;

		// Token: 0x04005D2A RID: 23850
		internal object <_>__3;

		// Token: 0x04005D2B RID: 23851
		internal IDisposable $locvar1;

		// Token: 0x04005D2C RID: 23852
		internal object $current;

		// Token: 0x04005D2D RID: 23853
		internal bool $disposing;

		// Token: 0x04005D2E RID: 23854
		internal int $PC;
	}
}
