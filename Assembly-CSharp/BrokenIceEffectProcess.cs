using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008B4 RID: 2228
public class BrokenIceEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EE4 RID: 16100 RVA: 0x001867AC File Offset: 0x00184BAC
	public BrokenIceEffectProcess()
	{
	}

	// Token: 0x17000B2A RID: 2858
	// (get) Token: 0x06003EE5 RID: 16101 RVA: 0x001867B4 File Offset: 0x00184BB4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.BrokenIce;
		}
	}

	// Token: 0x17000B2B RID: 2859
	// (get) Token: 0x06003EE6 RID: 16102 RVA: 0x001867BC File Offset: 0x00184BBC
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

	// Token: 0x06003EE7 RID: 16103 RVA: 0x001867D8 File Offset: 0x00184BD8
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06003EE8 RID: 16104 RVA: 0x001867DC File Offset: 0x00184BDC
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.8)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new BrokenIceData
				{
					IsStar = true,
					Seconds = (double)UnityEngine.Random.Range(2.5f, 4f)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new BrokenIceData
			{
				IsStar = true,
				Seconds = (double)UnityEngine.Random.Range(4f, 5f)
			}
		};
	}

	// Token: 0x06003EE9 RID: 16105 RVA: 0x00186860 File Offset: 0x00184C60
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && evtData is DamageComponent && specialEffectData is BrokenIceData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsDirectDamage && !damage.HasFullyNeutralized() && damage.IsCrit)
			{
				List<IBattleUnit> targets = triggerUnit.GetLiveEnemyTargets(false, true);
				BrokenIceData data = specialEffectData as BrokenIceData;
				foreach (IBattleUnit battleUnit in targets)
				{
					IEnumerator enumerator2 = LockTimeEffect.AddFrozenSeconds(battleUnit, Convert.ToSingle(data.Seconds), effectCarrier, false).GetEnumerator();
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
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F23 RID: 3875
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061EC RID: 25068 RVA: 0x001868A1 File Offset: 0x00184CA1
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060061ED RID: 25069 RVA: 0x001868AC File Offset: 0x00184CAC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(evtData is DamageComponent) || !(specialEffectData is BrokenIceData))
				{
					goto IL_1D9;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsDirectDamage || damage.HasFullyNeutralized() || !damage.IsCrit)
				{
					goto IL_1D9;
				}
				targets = triggerUnit.GetLiveEnemyTargets(false, true);
				data = (specialEffectData as BrokenIceData);
				enumerator = targets.GetEnumerator();
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
					break;
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					enumerator2 = LockTimeEffect.AddFrozenSeconds(battleUnit, Convert.ToSingle(data.Seconds), effectCarrier, false).GetEnumerator();
					num = 4294967293u;
					goto Block_11;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1D9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001481 RID: 5249
		// (get) Token: 0x060061EE RID: 25070 RVA: 0x00186AB8 File Offset: 0x00184EB8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001482 RID: 5250
		// (get) Token: 0x060061EF RID: 25071 RVA: 0x00186AC0 File Offset: 0x00184EC0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061F0 RID: 25072 RVA: 0x00186AC8 File Offset: 0x00184EC8
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
			}
		}

		// Token: 0x060061F1 RID: 25073 RVA: 0x00186B5C File Offset: 0x00184F5C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061F2 RID: 25074 RVA: 0x00186B63 File Offset: 0x00184F63
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061F3 RID: 25075 RVA: 0x00186B6C File Offset: 0x00184F6C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BrokenIceEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new BrokenIceEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040057DF RID: 22495
		internal AdventureEventType evtType;

		// Token: 0x040057E0 RID: 22496
		internal IBattleUnit triggerUnit;

		// Token: 0x040057E1 RID: 22497
		internal IBattleUnit effectCarrier;

		// Token: 0x040057E2 RID: 22498
		internal object evtData;

		// Token: 0x040057E3 RID: 22499
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040057E4 RID: 22500
		internal DamageComponent <damage>__1;

		// Token: 0x040057E5 RID: 22501
		internal List<IBattleUnit> <targets>__2;

		// Token: 0x040057E6 RID: 22502
		internal BrokenIceData <data>__2;

		// Token: 0x040057E7 RID: 22503
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040057E8 RID: 22504
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x040057E9 RID: 22505
		internal IEnumerator $locvar1;

		// Token: 0x040057EA RID: 22506
		internal object <_>__4;

		// Token: 0x040057EB RID: 22507
		internal IDisposable $locvar2;

		// Token: 0x040057EC RID: 22508
		internal object $current;

		// Token: 0x040057ED RID: 22509
		internal bool $disposing;

		// Token: 0x040057EE RID: 22510
		internal int $PC;
	}
}
