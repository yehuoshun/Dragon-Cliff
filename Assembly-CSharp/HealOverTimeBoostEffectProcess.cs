using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F4 RID: 2292
public class HealOverTimeBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FFD RID: 16381 RVA: 0x001980AA File Offset: 0x001964AA
	public HealOverTimeBoostEffectProcess()
	{
	}

	// Token: 0x17000BAA RID: 2986
	// (get) Token: 0x06003FFE RID: 16382 RVA: 0x001980BD File Offset: 0x001964BD
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.HealOverTimeBoost;
		}
	}

	// Token: 0x17000BAB RID: 2987
	// (get) Token: 0x06003FFF RID: 16383 RVA: 0x001980C4 File Offset: 0x001964C4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReceivesEffect,
				AdventureEventType.UnitLoosesEffect
			};
		}
	}

	// Token: 0x06004000 RID: 16384 RVA: 0x001980E8 File Offset: 0x001964E8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReceivesEffect && triggerUnit == effectCarrier && evtData is HealOverTimeEffect && specialEffectData is HealOverTimeData)
		{
			HealOverTimeData data = specialEffectData as HealOverTimeData;
			IEnumerator enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.DamageReduction,
					ModificationType = ModificationType.Addition,
					Value = data.ReductionRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, this._key, new int?(1), null, null, false, true, false), false).GetEnumerator();
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
		if (evtType == AdventureEventType.UnitLoosesEffect && triggerUnit == effectCarrier && evtData is HealOverTimeEffect && specialEffectData is HealOverTimeData && !effectCarrier.BattleEffects.OfType<HealOverTimeEffect>().Any<HealOverTimeEffect>())
		{
			List<AttributeModificationEffect> toremove = (from ef in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
			where ef.EffectSourceIdentityCode == this._key
			select ef).ToList<AttributeModificationEffect>();
			foreach (AttributeModificationEffect attributeModificationEffect in toremove)
			{
				IEnumerator enumerator3 = effectCarrier.LooseSkillEffect(attributeModificationEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F96 RID: 12182
	private string _key = "uniquehealovertimeboost";

	// Token: 0x02000F79 RID: 3961
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006433 RID: 25651 RVA: 0x00198130 File Offset: 0x00196530
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006434 RID: 25652 RVA: 0x00198138 File Offset: 0x00196538
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReceivesEffect || triggerUnit != effectCarrier || !(evtData is HealOverTimeEffect) || !(specialEffectData is HealOverTimeData))
				{
					goto IL_190;
				}
				data = (specialEffectData as HealOverTimeData);
				enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.DamageReduction,
						ModificationType = ModificationType.Addition,
						Value = data.ReductionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, this._key, new int?(1), null, null, false, true, false), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_12:
				try
				{
					switch (num)
					{
					case 2u:
						Block_20:
						try
						{
							switch (num)
							{
							}
							if (enumerator3.MoveNext())
							{
								_2 = enumerator3.Current;
								this.$current = _2;
								if (!this.$disposing)
								{
									this.$PC = 2;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable2 = (enumerator3 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator2.MoveNext())
					{
						attributeModificationEffect = enumerator2.Current;
						enumerator3 = effectCarrier.LooseSkillEffect(attributeModificationEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
						num = 4294967293u;
						goto Block_20;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				goto IL_319;
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
			IL_190:
			if (evtType == AdventureEventType.UnitLoosesEffect && triggerUnit == effectCarrier && evtData is HealOverTimeEffect && specialEffectData is HealOverTimeData && !effectCarrier.BattleEffects.OfType<HealOverTimeEffect>().Any<HealOverTimeEffect>())
			{
				toremove = (from ef in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == this._key
				select ef).ToList<AttributeModificationEffect>();
				enumerator2 = toremove.GetEnumerator();
				num = 4294967293u;
				goto Block_12;
			}
			IL_319:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014FB RID: 5371
		// (get) Token: 0x06006435 RID: 25653 RVA: 0x00198490 File Offset: 0x00196890
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014FC RID: 5372
		// (get) Token: 0x06006436 RID: 25654 RVA: 0x00198498 File Offset: 0x00196898
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006437 RID: 25655 RVA: 0x001984A0 File Offset: 0x001968A0
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
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006438 RID: 25656 RVA: 0x00198574 File Offset: 0x00196974
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006439 RID: 25657 RVA: 0x0019857B File Offset: 0x0019697B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600643A RID: 25658 RVA: 0x00198584 File Offset: 0x00196984
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealOverTimeBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new HealOverTimeBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600643B RID: 25659 RVA: 0x001985F4 File Offset: 0x001969F4
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == this._key;
		}

		// Token: 0x04005BED RID: 23533
		internal AdventureEventType evtType;

		// Token: 0x04005BEE RID: 23534
		internal IBattleUnit triggerUnit;

		// Token: 0x04005BEF RID: 23535
		internal IBattleUnit effectCarrier;

		// Token: 0x04005BF0 RID: 23536
		internal object evtData;

		// Token: 0x04005BF1 RID: 23537
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005BF2 RID: 23538
		internal HealOverTimeData <data>__1;

		// Token: 0x04005BF3 RID: 23539
		internal IEnumerator $locvar0;

		// Token: 0x04005BF4 RID: 23540
		internal object <_>__2;

		// Token: 0x04005BF5 RID: 23541
		internal IDisposable $locvar1;

		// Token: 0x04005BF6 RID: 23542
		internal List<AttributeModificationEffect> <toremove>__3;

		// Token: 0x04005BF7 RID: 23543
		internal List<AttributeModificationEffect>.Enumerator $locvar2;

		// Token: 0x04005BF8 RID: 23544
		internal AttributeModificationEffect <attributeModificationEffect>__4;

		// Token: 0x04005BF9 RID: 23545
		internal IEnumerator $locvar3;

		// Token: 0x04005BFA RID: 23546
		internal object <_>__5;

		// Token: 0x04005BFB RID: 23547
		internal IDisposable $locvar4;

		// Token: 0x04005BFC RID: 23548
		internal HealOverTimeBoostEffectProcess $this;

		// Token: 0x04005BFD RID: 23549
		internal object $current;

		// Token: 0x04005BFE RID: 23550
		internal bool $disposing;

		// Token: 0x04005BFF RID: 23551
		internal int $PC;
	}
}
