using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000906 RID: 2310
public class MindlessEffectprocess : SpecialEffectProcessBase
{
	// Token: 0x0600404F RID: 16463 RVA: 0x0019D7CC File Offset: 0x0019BBCC
	public MindlessEffectprocess()
	{
	}

	// Token: 0x17000BCC RID: 3020
	// (get) Token: 0x06004050 RID: 16464 RVA: 0x0019D804 File Offset: 0x0019BC04
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BCD RID: 3021
	// (get) Token: 0x06004051 RID: 16465 RVA: 0x0019D80C File Offset: 0x0019BC0C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06004052 RID: 16466 RVA: 0x0019D814 File Offset: 0x0019BC14
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is MindlessData)
		{
			MindlessData mindlessData = specialEffectData as MindlessData;
			mindlessData.CurrentCostIncreasedRate = 0.0;
		}
		if (evtType == AdventureEventType.UnitCastActiveSkill && triggerUnit == effectCarrier && specialEffectData is MindlessData)
		{
			MindlessData mindlessData2 = specialEffectData as MindlessData;
			mindlessData2.CurrentCostIncreasedRate += 0.3;
			if (mindlessData2.CurrentCostIncreasedRate > 0.9)
			{
				mindlessData2.CurrentCostIncreasedRate = 0.9;
			}
		}
		yield break;
	}

	// Token: 0x04002F9F RID: 12191
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Mindless;

	// Token: 0x04002FA0 RID: 12192
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.UnitReadyInBattle,
		AdventureEventType.UnitCastActiveSkill
	};

	// Token: 0x02000F93 RID: 3987
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064F1 RID: 25841 RVA: 0x0019D84D File Offset: 0x0019BC4D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060064F2 RID: 25842 RVA: 0x0019D858 File Offset: 0x0019BC58
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is MindlessData)
				{
					MindlessData mindlessData = specialEffectData as MindlessData;
					mindlessData.CurrentCostIncreasedRate = 0.0;
				}
				if (evtType == AdventureEventType.UnitCastActiveSkill && triggerUnit == effectCarrier && specialEffectData is MindlessData)
				{
					MindlessData mindlessData2 = specialEffectData as MindlessData;
					mindlessData2.CurrentCostIncreasedRate += 0.3;
					if (mindlessData2.CurrentCostIncreasedRate > 0.9)
					{
						mindlessData2.CurrentCostIncreasedRate = 0.9;
					}
				}
			}
			return false;
		}

		// Token: 0x17001525 RID: 5413
		// (get) Token: 0x060064F3 RID: 25843 RVA: 0x0019D939 File Offset: 0x0019BD39
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001526 RID: 5414
		// (get) Token: 0x060064F4 RID: 25844 RVA: 0x0019D941 File Offset: 0x0019BD41
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064F5 RID: 25845 RVA: 0x0019D949 File Offset: 0x0019BD49
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060064F6 RID: 25846 RVA: 0x0019D94B File Offset: 0x0019BD4B
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064F7 RID: 25847 RVA: 0x0019D952 File Offset: 0x0019BD52
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064F8 RID: 25848 RVA: 0x0019D95C File Offset: 0x0019BD5C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			MindlessEffectprocess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new MindlessEffectprocess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005D3B RID: 23867
		internal AdventureEventType evtType;

		// Token: 0x04005D3C RID: 23868
		internal IBattleUnit triggerUnit;

		// Token: 0x04005D3D RID: 23869
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D3E RID: 23870
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D3F RID: 23871
		internal object $current;

		// Token: 0x04005D40 RID: 23872
		internal bool $disposing;

		// Token: 0x04005D41 RID: 23873
		internal int $PC;
	}
}
