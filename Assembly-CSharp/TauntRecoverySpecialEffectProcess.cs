using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000934 RID: 2356
public class TauntRecoverySpecialEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004122 RID: 16674 RVA: 0x001A8084 File Offset: 0x001A6484
	public TauntRecoverySpecialEffectProcess()
	{
	}

	// Token: 0x17000C27 RID: 3111
	// (get) Token: 0x06004123 RID: 16675 RVA: 0x001A8094 File Offset: 0x001A6494
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C28 RID: 3112
	// (get) Token: 0x06004124 RID: 16676 RVA: 0x001A809C File Offset: 0x001A649C
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

	// Token: 0x06004125 RID: 16677 RVA: 0x001A80B8 File Offset: 0x001A64B8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReceivesEffect)
		{
			BattleEffectBase effect = evtData as BattleEffectBase;
			if (effect is TauntEffect && effect.EffectSource.SourceUnit == effectCarrier)
			{
				TauntRecoveryData data = specialEffectData as TauntRecoveryData;
				double healValue = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.RecoveryRate;
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = healValue,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, effectCarrier);
				IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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

	// Token: 0x06004126 RID: 16678 RVA: 0x001A80F2 File Offset: 0x001A64F2
	public override bool CanBeRandomSpecialEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return itemType.GetResourceCategory() == ResourceCategory.Sword || itemType.GetResourceCategory() == ResourceCategory.Plate;
	}

	// Token: 0x06004127 RID: 16679 RVA: 0x001A8110 File Offset: 0x001A6510
	public override List<ISpecialEffectDataLoad> GenerateRandomEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TauntRecoveryData
			{
				RecoveryRate = 0.15 * (double)((grade != QualityGrade.Ancient) ? UnityEngine.Random.Range(0.6f, 0.8f) : UnityEngine.Random.Range(0.8f, 1f)),
				IsStarEf = new bool?(false)
			}
		};
	}

	// Token: 0x040030E2 RID: 12514
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.TauntRecovery;

	// Token: 0x02000FD4 RID: 4052
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066A8 RID: 26280 RVA: 0x001A8178 File Offset: 0x001A6578
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060066A9 RID: 26281 RVA: 0x001A8180 File Offset: 0x001A6580
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReceivesEffect)
				{
					goto IL_19C;
				}
				effect = (evtData as BattleEffectBase);
				if (!(effect is TauntEffect) || effect.EffectSource.SourceUnit != effectCarrier)
				{
					goto IL_19C;
				}
				data = (specialEffectData as TauntRecoveryData);
				healValue = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.RecoveryRate;
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = healValue,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, effectCarrier);
				enumerator = releaseableHeal.Release().GetEnumerator();
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
			IL_19C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001589 RID: 5513
		// (get) Token: 0x060066AA RID: 26282 RVA: 0x001A8344 File Offset: 0x001A6744
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700158A RID: 5514
		// (get) Token: 0x060066AB RID: 26283 RVA: 0x001A834C File Offset: 0x001A674C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066AC RID: 26284 RVA: 0x001A8354 File Offset: 0x001A6754
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

		// Token: 0x060066AD RID: 26285 RVA: 0x001A83C4 File Offset: 0x001A67C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066AE RID: 26286 RVA: 0x001A83CB File Offset: 0x001A67CB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066AF RID: 26287 RVA: 0x001A83D4 File Offset: 0x001A67D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TauntRecoverySpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new TauntRecoverySpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005FD6 RID: 24534
		internal AdventureEventType evtType;

		// Token: 0x04005FD7 RID: 24535
		internal object evtData;

		// Token: 0x04005FD8 RID: 24536
		internal BattleEffectBase <effect>__1;

		// Token: 0x04005FD9 RID: 24537
		internal IBattleUnit effectCarrier;

		// Token: 0x04005FDA RID: 24538
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005FDB RID: 24539
		internal TauntRecoveryData <data>__2;

		// Token: 0x04005FDC RID: 24540
		internal double <healValue>__2;

		// Token: 0x04005FDD RID: 24541
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x04005FDE RID: 24542
		internal IEnumerator $locvar0;

		// Token: 0x04005FDF RID: 24543
		internal object <_>__3;

		// Token: 0x04005FE0 RID: 24544
		internal IDisposable $locvar1;

		// Token: 0x04005FE1 RID: 24545
		internal object $current;

		// Token: 0x04005FE2 RID: 24546
		internal bool $disposing;

		// Token: 0x04005FE3 RID: 24547
		internal int $PC;
	}
}
