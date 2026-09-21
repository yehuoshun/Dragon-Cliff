using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008B9 RID: 2233
public class ClearWaterEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EFF RID: 16127 RVA: 0x0018812C File Offset: 0x0018652C
	public ClearWaterEffectProcess()
	{
	}

	// Token: 0x17000B34 RID: 2868
	// (get) Token: 0x06003F00 RID: 16128 RVA: 0x0018813C File Offset: 0x0018653C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B35 RID: 2869
	// (get) Token: 0x06003F01 RID: 16129 RVA: 0x00188144 File Offset: 0x00186544
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitEntersTurn
			};
		}
	}

	// Token: 0x06003F02 RID: 16130 RVA: 0x00188160 File Offset: 0x00186560
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitEntersTurn && triggerUnit == effectCarrier)
		{
			ClearWaterData data = specialEffectData as ClearWaterData;
			List<BattleEffectBase> effects = effectCarrier.BattleEffects.GetDesperseableEffects().GetHarmfulEffects().Take(data.NumberOfCleanUps).ToList<BattleEffectBase>();
			bool triggered = false;
			foreach (BattleEffectBase battleEffectBase in effects)
			{
				if ((double)UnityEngine.Random.value <= data.Chance)
				{
					IEnumerator enumerator2 = effectCarrier.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _ = enumerator2.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
					triggered = true;
				}
			}
			ClearWaterDispelShieldData clearShield = effectCarrier.SpecialEffects.OfType<ClearWaterDispelShieldData>().FirstOrDefault<ClearWaterDispelShieldData>();
			if (clearShield != null && triggered)
			{
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * clearShield.HealRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, effectCarrier);
				IEnumerator enumerator3 = releaseableHeal.Release().GetEnumerator();
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
				IEnumerator enumerator4 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectResistanceRating,
						ModificationType = ModificationType.Addition,
						Value = 800.0,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "clearwaterunique", new int?(1), new float?((float)clearShield.ShieldSeconds), null, false, false, false), false).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _3 = enumerator4.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F6D RID: 12141
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.ClearWater;

	// Token: 0x02000F2C RID: 3884
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006221 RID: 25121 RVA: 0x00188199 File Offset: 0x00186599
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006222 RID: 25122 RVA: 0x001881A4 File Offset: 0x001865A4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitEntersTurn || triggerUnit != effectCarrier)
				{
					goto IL_416;
				}
				data = (specialEffectData as ClearWaterData);
				effects = effectCarrier.BattleEffects.GetDesperseableEffects().GetHarmfulEffects().Take(data.NumberOfCleanUps).ToList<BattleEffectBase>();
				triggered = false;
				enumerator = effects.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_273;
			case 3u:
				goto IL_394;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_11:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
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
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					triggered = true;
					break;
				}
				while (enumerator.MoveNext())
				{
					battleEffectBase = enumerator.Current;
					if ((double)UnityEngine.Random.value <= data.Chance)
					{
						enumerator2 = effectCarrier.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			clearShield = effectCarrier.SpecialEffects.OfType<ClearWaterDispelShieldData>().FirstOrDefault<ClearWaterDispelShieldData>();
			if (clearShield == null || !triggered)
			{
				goto IL_416;
			}
			releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * clearShield.HealRate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)
			}, effectCarrier);
			enumerator3 = releaseableHeal.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_273:
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
			enumerator4 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.EffectResistanceRating,
					ModificationType = ModificationType.Addition,
					Value = 800.0,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "clearwaterunique", new int?(1), new float?((float)clearShield.ShieldSeconds), null, false, false, false), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_394:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_3 = enumerator4.Current;
					this.$current = _3;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_416:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700148B RID: 5259
		// (get) Token: 0x06006223 RID: 25123 RVA: 0x00188608 File Offset: 0x00186A08
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700148C RID: 5260
		// (get) Token: 0x06006224 RID: 25124 RVA: 0x00188610 File Offset: 0x00186A10
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006225 RID: 25125 RVA: 0x00188618 File Offset: 0x00186A18
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
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			case 2u:
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
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06006226 RID: 25126 RVA: 0x00188728 File Offset: 0x00186B28
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006227 RID: 25127 RVA: 0x0018872F File Offset: 0x00186B2F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006228 RID: 25128 RVA: 0x00188738 File Offset: 0x00186B38
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ClearWaterEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ClearWaterEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005841 RID: 22593
		internal AdventureEventType evtType;

		// Token: 0x04005842 RID: 22594
		internal IBattleUnit triggerUnit;

		// Token: 0x04005843 RID: 22595
		internal IBattleUnit effectCarrier;

		// Token: 0x04005844 RID: 22596
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005845 RID: 22597
		internal ClearWaterData <data>__1;

		// Token: 0x04005846 RID: 22598
		internal List<BattleEffectBase> <effects>__1;

		// Token: 0x04005847 RID: 22599
		internal bool <triggered>__1;

		// Token: 0x04005848 RID: 22600
		internal List<BattleEffectBase>.Enumerator $locvar0;

		// Token: 0x04005849 RID: 22601
		internal BattleEffectBase <battleEffectBase>__2;

		// Token: 0x0400584A RID: 22602
		internal IEnumerator $locvar1;

		// Token: 0x0400584B RID: 22603
		internal object <_>__3;

		// Token: 0x0400584C RID: 22604
		internal IDisposable $locvar2;

		// Token: 0x0400584D RID: 22605
		internal ClearWaterDispelShieldData <clearShield>__1;

		// Token: 0x0400584E RID: 22606
		internal ReleaseableHeal <releaseableHeal>__4;

		// Token: 0x0400584F RID: 22607
		internal IEnumerator $locvar3;

		// Token: 0x04005850 RID: 22608
		internal object <_>__5;

		// Token: 0x04005851 RID: 22609
		internal IDisposable $locvar4;

		// Token: 0x04005852 RID: 22610
		internal IEnumerator $locvar5;

		// Token: 0x04005853 RID: 22611
		internal object <_>__6;

		// Token: 0x04005854 RID: 22612
		internal IDisposable $locvar6;

		// Token: 0x04005855 RID: 22613
		internal object $current;

		// Token: 0x04005856 RID: 22614
		internal bool $disposing;

		// Token: 0x04005857 RID: 22615
		internal int $PC;
	}
}
