using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000914 RID: 2324
public class RageHealEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600408F RID: 16527 RVA: 0x001A0990 File Offset: 0x0019ED90
	public RageHealEffectProcess()
	{
	}

	// Token: 0x17000BE9 RID: 3049
	// (get) Token: 0x06004090 RID: 16528 RVA: 0x001A09A0 File Offset: 0x0019EDA0
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BEA RID: 3050
	// (get) Token: 0x06004091 RID: 16529 RVA: 0x001A09A8 File Offset: 0x0019EDA8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterPlayerGaugeReleased,
				AdventureEventType.BattleEncounterEnemyGaugeReleased
			};
		}
	}

	// Token: 0x06004092 RID: 16530 RVA: 0x001A09CC File Offset: 0x0019EDCC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.BattleEncounterPlayerGaugeReleased || evtType == AdventureEventType.BattleEncounterEnemyGaugeReleased)
		{
			BattleGaugeUpdateEvent change = evtData as BattleGaugeUpdateEvent;
			RageHealData data = specialEffectData as RageHealData;
			if (change != null && data != null && change.ChangeAmount > 0.0 && ((effectCarrier.IsPlayer && evtType == AdventureEventType.BattleEncounterEnemyGaugeReleased) || (!effectCarrier.IsPlayer && evtType == AdventureEventType.BattleEncounterPlayerGaugeReleased)))
			{
				double healAmount = -change.ChangeAmount * data.HealRate;
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = healAmount,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
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

	// Token: 0x04002FA8 RID: 12200
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.RageHeal;

	// Token: 0x02000FA1 RID: 4001
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006561 RID: 25953 RVA: 0x001A0A06 File Offset: 0x0019EE06
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006562 RID: 25954 RVA: 0x001A0A10 File Offset: 0x0019EE10
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.BattleEncounterPlayerGaugeReleased && evtType != AdventureEventType.BattleEncounterEnemyGaugeReleased)
				{
					goto IL_1E7;
				}
				change = (evtData as BattleGaugeUpdateEvent);
				data = (specialEffectData as RageHealData);
				if (change == null || data == null || change.ChangeAmount <= 0.0 || ((!effectCarrier.IsPlayer || evtType != AdventureEventType.BattleEncounterEnemyGaugeReleased) && (effectCarrier.IsPlayer || evtType != AdventureEventType.BattleEncounterPlayerGaugeReleased)))
				{
					goto IL_1E7;
				}
				healAmount = -change.ChangeAmount * data.HealRate;
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = healAmount,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
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
			IL_1E7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700153F RID: 5439
		// (get) Token: 0x06006563 RID: 25955 RVA: 0x001A0C20 File Offset: 0x0019F020
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001540 RID: 5440
		// (get) Token: 0x06006564 RID: 25956 RVA: 0x001A0C28 File Offset: 0x0019F028
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006565 RID: 25957 RVA: 0x001A0C30 File Offset: 0x0019F030
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

		// Token: 0x06006566 RID: 25958 RVA: 0x001A0CA0 File Offset: 0x0019F0A0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006567 RID: 25959 RVA: 0x001A0CA7 File Offset: 0x0019F0A7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006568 RID: 25960 RVA: 0x001A0CB0 File Offset: 0x0019F0B0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RageHealEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new RageHealEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005DF7 RID: 24055
		internal AdventureEventType evtType;

		// Token: 0x04005DF8 RID: 24056
		internal object evtData;

		// Token: 0x04005DF9 RID: 24057
		internal BattleGaugeUpdateEvent <change>__1;

		// Token: 0x04005DFA RID: 24058
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005DFB RID: 24059
		internal RageHealData <data>__1;

		// Token: 0x04005DFC RID: 24060
		internal IBattleUnit effectCarrier;

		// Token: 0x04005DFD RID: 24061
		internal double <healAmount>__2;

		// Token: 0x04005DFE RID: 24062
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x04005DFF RID: 24063
		internal IEnumerator $locvar0;

		// Token: 0x04005E00 RID: 24064
		internal object <_>__3;

		// Token: 0x04005E01 RID: 24065
		internal IDisposable $locvar1;

		// Token: 0x04005E02 RID: 24066
		internal object $current;

		// Token: 0x04005E03 RID: 24067
		internal bool $disposing;

		// Token: 0x04005E04 RID: 24068
		internal int $PC;
	}
}
