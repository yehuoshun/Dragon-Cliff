using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000939 RID: 2361
public class TimelessEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600413B RID: 16699 RVA: 0x001AB458 File Offset: 0x001A9858
	public TimelessEffectProcess()
	{
	}

	// Token: 0x17000C31 RID: 3121
	// (get) Token: 0x0600413C RID: 16700 RVA: 0x001AB460 File Offset: 0x001A9860
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Timeless;
		}
	}

	// Token: 0x17000C32 RID: 3122
	// (get) Token: 0x0600413D RID: 16701 RVA: 0x001AB468 File Offset: 0x001A9868
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReceivesEffect
			};
		}
	}

	// Token: 0x0600413E RID: 16702 RVA: 0x001AB484 File Offset: 0x001A9884
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x0600413F RID: 16703 RVA: 0x001AB488 File Offset: 0x001A9888
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TimelessData
			{
				IsStar = true,
				HitRate = (double)UnityEngine.Random.Range(0.01f, 0.03f),
				EffectMastery = (double)UnityEngine.Random.Range(0.15f, 0.25f)
			}
		};
	}

	// Token: 0x06004140 RID: 16704 RVA: 0x001AB4DC File Offset: 0x001A98DC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReceivesEffect && evtData is LockTimeEffect && specialEffectData is TimelessData)
		{
			LockTimeEffect effectr = evtData as LockTimeEffect;
			if (effectr.SourceUnit == effectCarrier)
			{
				TimelessData data = specialEffectData as TimelessData;
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.HitRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = data.HitRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectMastery,
						ModificationType = ModificationType.Multiplication,
						Value = data.EffectMastery,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "timelessspecialeffect", new int?(5), new float?(6f), null, false, true, false), false).GetEnumerator();
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

	// Token: 0x02000FDE RID: 4062
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066EC RID: 26348 RVA: 0x001AB516 File Offset: 0x001A9916
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060066ED RID: 26349 RVA: 0x001AB520 File Offset: 0x001A9920
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReceivesEffect || !(evtData is LockTimeEffect) || !(specialEffectData is TimelessData))
				{
					goto IL_1DE;
				}
				effectr = (evtData as LockTimeEffect);
				if (effectr.SourceUnit != effectCarrier)
				{
					goto IL_1DE;
				}
				data = (specialEffectData as TimelessData);
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.HitRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = data.HitRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectMastery,
						ModificationType = ModificationType.Multiplication,
						Value = data.EffectMastery,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "timelessspecialeffect", new int?(5), new float?(6f), null, false, true, false), false).GetEnumerator();
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
			IL_1DE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001597 RID: 5527
		// (get) Token: 0x060066EE RID: 26350 RVA: 0x001AB728 File Offset: 0x001A9B28
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001598 RID: 5528
		// (get) Token: 0x060066EF RID: 26351 RVA: 0x001AB730 File Offset: 0x001A9B30
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066F0 RID: 26352 RVA: 0x001AB738 File Offset: 0x001A9B38
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

		// Token: 0x060066F1 RID: 26353 RVA: 0x001AB7A8 File Offset: 0x001A9BA8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066F2 RID: 26354 RVA: 0x001AB7AF File Offset: 0x001A9BAF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066F3 RID: 26355 RVA: 0x001AB7B8 File Offset: 0x001A9BB8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TimelessEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new TimelessEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04006091 RID: 24721
		internal AdventureEventType evtType;

		// Token: 0x04006092 RID: 24722
		internal object evtData;

		// Token: 0x04006093 RID: 24723
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04006094 RID: 24724
		internal LockTimeEffect <effectr>__1;

		// Token: 0x04006095 RID: 24725
		internal IBattleUnit effectCarrier;

		// Token: 0x04006096 RID: 24726
		internal TimelessData <data>__2;

		// Token: 0x04006097 RID: 24727
		internal IEnumerator $locvar0;

		// Token: 0x04006098 RID: 24728
		internal object <_>__3;

		// Token: 0x04006099 RID: 24729
		internal IDisposable $locvar1;

		// Token: 0x0400609A RID: 24730
		internal object $current;

		// Token: 0x0400609B RID: 24731
		internal bool $disposing;

		// Token: 0x0400609C RID: 24732
		internal int $PC;
	}
}
